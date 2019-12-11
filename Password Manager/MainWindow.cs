using BrightIdeasSoftware;
using Password_Manager;
using Password_Manager.Contract;
using PasswordManagerGUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class MainWindow : Form {
        private Ribbon _ribbon;
        private ObjectListView _details;
        private string _storeFile;
        private WindowColorThemes _windowColorTheme = WindowColorThemes.Dark;

        private IController _manager;

        public MainWindow() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            ButtonExit.Location = new Point(this.Width - 30, 5);
            ButtonMaximize.Location = new Point(ButtonExit.Location.X - 25, 5);
            ButtonMinimize.Location = new Point(ButtonMaximize.Location.X - 25, 5);

            if (_windowColorTheme == WindowColorThemes.Dark) {
                this.BackColor = Color.FromArgb(32, 36, 42);
            }

            _storeFile = Settings.Default.StoreFile;

            SetDetailsView();
            SetRibbonBar();

            if (!File.Exists(_storeFile)) {
                if(Settings.Default.StoreFile == null) {
                    CreateNewStoreFileInstance();
                    _storeFile = Settings.Default.StoreFile;
                }
                else {
                    StoreFileNotFoundDialog dialog = new StoreFileNotFoundDialog();
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.Yes)
                        CreateNewStoreFileInstance();
                    else if (result == DialogResult.No)
                        OpenFileDialog();
                    else
                        Exit();
                }
            }
            else {
                LoadSavedPasswords();
            }

            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Credentials").Items.Where(i => new[] { "AddCredential" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = Groups.SelectedItem != null);
        }

        private void BindGroups(ICollection<CredentialGroup> groups) {
            if (groups.Count > 0) {
                Groups.Items.Clear();

                IEnumerable<CredentialGroup> source = groups.OrderBy(g => g.Name);

                source.ToList().ForEach(g => {
                    Groups.Items.Add(g.Name);
                });

                Groups.SelectedIndex = 0;
                BindDetails(groups.First());
            }
        }

        private void CreateNewStoreFileInstance() {
            SetStoreFile newStoreFileDialog = new SetStoreFile();
            DialogResult result = newStoreFileDialog.ShowDialog();

            if(result == DialogResult.OK) {
                GetAESKeyAndIV(newStoreFileDialog.Input, out byte[] key, out byte[] iv);
                CreatePasswordManagerInstance(key, iv);
            }
            else {
                Exit();
            }
        }

        private void LoadSavedPasswords() {
            bool success = false;

            while (!success) {
                PasswordPrompt prompt = new PasswordPrompt();
                DialogResult result = prompt.ShowDialog();

                if(result == DialogResult.OK) {
                    try {
                        GetAESKeyAndIV(prompt.Input, out byte[] key, out byte[] iv);
                        CreatePasswordManagerInstance(key, iv);
                        _manager.Load();
                        ICollection<CredentialGroup> groups = _manager.GetGroups();
                        BindGroups(groups);

                        success = true;
                    }
                    catch {
                        MessageBox.Show("Passwort nicht korrekt.");
                        prompt.Close();
                    }
                }
                else {
                    Exit();
                }
            }
        }

        private void CreatePasswordManagerInstance(byte[] aesKey, byte[] aesIV) {
            ICrypt aesCrypt = new AesCrypt(aesKey, aesIV);
            ICrypt byteShift = new ByteShifter(4190, "vmqup4amöovcb86mnoöbsaen");
            ICredentialsStore<ICollection<CredentialGroup>> store = new CredentialFileStore(_storeFile, new [] { aesCrypt, byteShift });
            _manager = new Controller(store);
            ((Controller)_manager).OnCommandExecuted += MainWindow_OnCommandExecuted;
        }

        private void MainWindow_OnCommandExecuted(object sender, EventArgs e) {
            Thread.Sleep(200);
            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Functions").Items.Where(i => new[] { "Undo" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = _manager.HasUndoableAction);
            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Functions").Items.Where(i => new[] { "Redo" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = _manager.HasRedoableAction);
        }

        private static void GetAESKeyAndIV(string password, out byte[] key, out byte[] iv) {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] salt = Encoding.UTF8.GetBytes("aâí?©Êç“­µ¬f}þ¨^x!18");
            var derivedBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 5000);
            key = derivedBytes.GetBytes(32);
            iv = derivedBytes.GetBytes(16);
        }

        private void _details_ItemActivate(object sender, System.EventArgs e) {
            ObjectListView objectListView = sender as ObjectListView;
            CredentialGroup group = GetSelectedGroup();
            Credential credential = (Credential)objectListView.SelectedObject;

            if (credential == null)
                MessageBox.Show("Kein Eintrag selektiert.");
            else
                EditCredential(group, credential);
        }

        private CredentialGroup GetSelectedGroup() {
            string selectedGroupName = (string)Groups.SelectedItem;
            CredentialGroup group = null;

            try {
                group = _manager.FindGroup(selectedGroupName);
            }
            catch {
                ;
            }

            return group;
        }

        private Credential GetSelectedCredential() {
            Credential selectedObject = (Credential)_details.SelectedObject;
            Credential Credential = null;
            try {
                Credential = _manager.FindCredentialById(selectedObject.ID);
            }
            catch {
                ;
            }

            return Credential;
        }

        private void EditCredential(CredentialGroup group, Credential credential) {
            CredentialsEditor editor;

            if (credential != null)
                editor = new CredentialsEditor(_manager, credential, _windowColorTheme);
            else
                editor = new CredentialsEditor(_manager, group, _windowColorTheme);

            DialogResult result = editor.ShowDialog();

            if(result == DialogResult.OK) {
                BindDetails(editor.EditedCredential.Group);
            }
        }

        private void AddGroup_Click(object sender, System.EventArgs e) {
            EditGroupDialog addGroupDialog = new EditGroupDialog(_manager);
            DialogResult result = addGroupDialog.ShowDialog();

            if(result == DialogResult.OK) {
                CredentialGroup created = addGroupDialog.EditedGroup;
                int newItemIndex = Groups.Items.Add(created.Name);
                Groups.SelectedIndex = newItemIndex;
            }
        }

        private void RenameGroup_Click(object sender, System.EventArgs e) {
            CredentialGroup toEdit = GetSelectedGroup();

            if(toEdit != null) {
                EditGroupDialog editDialog = new EditGroupDialog(_manager, toEdit);
                DialogResult result = editDialog.ShowDialog();

                if (result == DialogResult.OK) {
                    CredentialGroup updated = editDialog.EditedGroup;
                    Groups.Items[Groups.SelectedIndex] = updated.Name;
                }
            }
            else {
                MessageBox.Show("Gruppe konnte nicht gefunden werden.");
            }
        }

        private void RemoveGroup_Click(object sender, System.EventArgs e) {
            RemoveSelectedGroup();
        }

        private void RemoveSelectedGroup() {
            int listBoxIndexToRemove = Groups.SelectedIndex;
            string groupName = Groups.SelectedItem as string;
            CredentialGroup toDelete = _manager.FindGroup(groupName);

            if (toDelete != null) {
                var confirmation = MessageBox.Show(
                    $"Gruppe \"{toDelete.Name}\" wirklich löschen?\r\nAlle Passwörter in dieser Gruppe werden ebenfalls entfernt.",
                    "Bestätigen",
                    MessageBoxButtons.YesNo
                );

                if (confirmation == DialogResult.Yes) {
                    _manager.RemoveGroup(toDelete);

                    Groups.Items.RemoveAt(listBoxIndexToRemove);
                    Groups.SelectedItem = null;
                }
            }
            else {
                MessageBox.Show("Gruppe konnte nicht gefunden werden.");
            }
        }

        private void AddCredentials_Click(object sender, System.EventArgs e) {
            CredentialGroup group = GetSelectedGroup();
            EditCredential(group, null);
        }

        private void RemoveCredentials_Click(object sender, System.EventArgs e) {
            RemoveSelectedCredential();
        }

        private void RemoveSelectedCredential() {
            Credential credential = GetSelectedCredential();
            _manager.RemoveCredential(credential);

            _details.SelectedItem = null;

            BindDetails(GetSelectedGroup());
        }

        private void EditCredentials_Click(object sender, System.EventArgs e) {
            Credential credential = GetSelectedCredential();
            EditCredential(credential.Group, credential);
        }

        private void Item_Click(object sender, System.EventArgs e) {
            SavePasswords();
        }

        private void SavePasswords() {
            _ribbon.Tabs[0].Panels.Find(p => p.Name == "Functions").Items.First(b => b.Name == "Save").Enabled = false;
            _manager.Save();
            Thread.Sleep(200);
            _ribbon.Tabs[0].Panels.Find(p => p.Name == "Functions").Items.First(b => b.Name == "Save").Enabled = true;
        }

        private void BindDetails(CredentialGroup group) {
            _details.SelectedItem = null;
            _details.Objects = null;

            if(group != null) {
                group.Credentials.ToList().ForEach(i => {
                    _details.AddObject(i);
                });

                _details.Sort(0);
            }

            _details.AutoResizeColumns();
        }

        private void SpeichernToolStripMenuItem_Click(object sender, System.EventArgs e) {
            SavePasswords();
        }

        private void Groups_SelectedIndexChanged(object sender, System.EventArgs e) {
            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Groups").Items.Where(i => new[] { "RenameGroup", "RemoveGroup" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = Groups.SelectedItem != null);
            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Credentials").Items.Where(i => new[] { "AddCredential" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = Groups.SelectedItem != null);

            BindDetails(GetSelectedGroup());
        }

        private void _details_SelectedIndexChanged(object sender, System.EventArgs e) {
            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Credentials").Items.Where(i => new[] { "RemoveCredentials", "EditCredentials", "Login" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = _details.SelectedItem != null);
        }

        private void Undo_Click(object sender, EventArgs e) {
            Undo();
        }

        private void Redo_Click(object sender, EventArgs e) {
            Redo();
        }

        private void Undo() {
            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Functions").Items.Where(i => new[] { "Undo" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = false);
            string[] groupsBefore = _manager.GetGroups().Select(g => g.Name).ToArray();
            _manager.Undo();
            string[] groupsAfter = _manager.GetGroups().Select(g => g.Name).ToArray();

            if (string.Join(",", groupsBefore) != string.Join(",", groupsAfter)) {
                BindGroups(_manager.GetGroups());

                string newGroup = groupsAfter.ToList().Except(groupsBefore.ToList()).FirstOrDefault();
                if(newGroup != null) {
                    int newIndex = Groups.FindStringExact(newGroup);
                    Groups.SelectedIndex = newIndex;
                }
            }
            else {
                CredentialGroup group = GetSelectedGroup();
                if (group != null)
                    BindDetails(group);
            }
        }

        private void Redo() {
            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Functions").Items.Where(i => new[] { "Redo" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = false);
            string[] groupsBefore = _manager.GetGroups().Select(g => g.Name).ToArray();
            _manager.Redo();
            string[] groupsAfter = _manager.GetGroups().Select(g => g.Name).ToArray();

            if (string.Join(",", groupsBefore) != string.Join(",", groupsAfter)) {
                BindGroups(_manager.GetGroups());

                string newGroup = groupsAfter.ToList().Except(groupsBefore.ToList()).FirstOrDefault();
                if (newGroup != null) {
                    int newIndex = Groups.FindStringExact(newGroup);
                    Groups.SelectedIndex = newIndex;
                }
            }
            else {
                CredentialGroup group = GetSelectedGroup();
                if (group != null)
                    BindDetails(group);
            }
        }

        private void SetDetailsView() {
            _details = new ObjectListView();
            _details.BorderStyle = BorderStyle.None;
            
            _details.UseHyperlinks = true;
            _details.ItemActivate += _details_ItemActivate;
            DetailsContainer.Controls.Add(_details);
            _details.Dock = DockStyle.Fill;

            _details.FullRowSelect = true;
            _details.ShowGroups = false;
            _details.UseCustomSelectionColors = true;

            _details.AllColumns.Add(new OLVColumn("Name", "Name"));
            OLVColumn urlColumn = new OLVColumn("URL", "URL");
            urlColumn.Hyperlink = true;
            _details.AllColumns.Add(urlColumn);
            _details.AllColumns.Add(new OLVColumn("Username", "Username"));
            _details.AllColumns.Add(new OLVColumn("Password", "Password") { AspectToStringConverter = delegate (object value) { return "****"; } });
            _details.AllColumns.Add(new OLVColumn("Notes", "Notes") { AspectToStringConverter = delegate(object value) {
                string notes = Convert.ToString(value);
                if (notes.Length < 25)
                    return notes;
                else
                    return notes.Substring(0, 22) + "...";
            }});
            OLVColumn idColumn = new OLVColumn("ID", "ID");
            idColumn.IsVisible = false;
            _details.AllColumns.Add(idColumn);

            _details.SelectedIndexChanged += _details_SelectedIndexChanged;

            _details.HeaderMinimumHeight = 32;
            _details.RebuildColumns();

            if(_windowColorTheme == WindowColorThemes.Default) {
                splitContainer1.BackColor = Color.FromArgb(104, 104, 103);
                Groups.BackColor = Color.FromArgb(255, 254, 255);
                _details.UseAlternatingBackColors = true;
                _details.AlternateRowBackColor = Color.FromArgb(246, 246, 246);
                _details.SelectedBackColor = Color.FromArgb(53, 152, 255);
                _details.SelectedForeColor = Color.White;
            }
            if(_windowColorTheme == WindowColorThemes.Dark) {
                splitContainer1.BackColor = Color.FromArgb(32, 36, 42);
                _details.HeaderFormatStyle = new HeaderFormatStyle();
                _details.HeaderFormatStyle.Normal.BackColor = Color.FromArgb(52, 51, 54);
                _details.HeaderFormatStyle.Hot.BackColor = Color.FromArgb(64, 63, 69);
                _details.HeaderFormatStyle.Pressed = _details.HeaderFormatStyle.Hot;
                _details.BackColor = Color.FromArgb(30, 30, 30);
                _details.ForeColor = Color.LightGray;
                _details.SelectedBackColor = Color.FromArgb(0, 122, 226);
                _details.SelectedForeColor = Color.White;
                _details.HyperlinkStyle.Normal.ForeColor = Color.FromArgb(255, 107, 31);
                _details.HyperlinkStyle.Over = _details.HyperlinkStyle.Normal;
                _details.HyperlinkStyle.Visited = _details.HyperlinkStyle.Normal;
                DetailsContainer.BackColor = _details.BackColor;
            }
        }

        private void SetRibbonBar() {
            this.MouseDown += MainWindow_MouseDown;
            ContentContainer.MouseDown += MainWindow_MouseDown;

            _ribbon = new Ribbon();
            _ribbon.Dock = DockStyle.Fill;
            _ribbon.OrbVisible = false;
            _ribbon.CaptionBarVisible = false;

            ButtonMinimize.FlatStyle = FlatStyle.Flat;
            ButtonMinimize.FlatAppearance.BorderSize = 0;
            ButtonMaximize.FlatStyle = ButtonMinimize.FlatStyle;
            ButtonMaximize.FlatAppearance.BorderSize = ButtonMinimize.FlatAppearance.BorderSize;
            ButtonExit.FlatStyle = ButtonMinimize.FlatStyle;
            ButtonExit.FlatAppearance.BorderSize = ButtonMinimize.FlatAppearance.BorderSize;

            Groups.DrawMode = DrawMode.OwnerDrawFixed;

            if (_windowColorTheme == WindowColorThemes.Default) {
                ContentContainer.BackColor = Color.FromArgb(187, 208, 233);
                MenuBar.ForeColor = Color.FromArgb(0, 0, 0);
                ButtonMinimize.ForeColor = Color.Black;

                Groups.DrawItem += Groups_DrawItemDefaultColorTheme;
            }
            else if (_windowColorTheme == WindowColorThemes.Dark) {
                ContentContainer.BackColor = Color.FromArgb(46, 45, 48);
                ButtonMinimize.ForeColor = Color.LightGray;

                RibbonProfesionalRendererColorTable colors = new RibbonProfesionalRendererColorTable();

                Application.EnableVisualStyles();
                MenuBar.Renderer = new ToolStripProfessionalRenderer(new DarkSchemeMenuStripColorTable());
                MenuBar.ForeColor = Color.LightGray;
                foreach(var item in MenuBar.Items) {
                    var dropDown = (ToolStripMenuItem)item;
                    foreach(var dropDownItem in dropDown.DropDownItems) {
                        if (dropDownItem.GetType() == typeof(ToolStripMenuItem))
                            ((ToolStripMenuItem)dropDownItem).ForeColor = Color.LightGray;
                    }
                }

                Groups.BackColor = Color.FromArgb(37, 37, 38);
                Groups.ForeColor = Color.LightGray;

                Groups.DrawItem += Groups_DrawItemDarkColorTheme;

                foreach (FieldInfo field in colors.GetType().GetFields()) {
                    var type = Nullable.GetUnderlyingType(field.FieldType) ?? field.FieldType;
                    if (type == typeof(Color)) {
                        if (field.Name.ToLower().Contains("buttonchecked") || field.Name.ToLower().Contains("buttonselected"))
                            field.SetValue(colors, Color.FromArgb(62, 62, 63));
                        else if (field.Name.ToLower().Contains("text") && !field.Name.ToLower().Contains("textbackground"))
                            field.SetValue(colors, Color.LightGray);
                        else if (field.Name.ToLower().Contains("paneltextbackground"))
                            field.SetValue(colors, Color.FromArgb(52, 51, 54));
                        else
                            field.SetValue(colors, Color.FromArgb(46, 45, 48));
                    }
                }

                //colors.PanelDarkBorder = Color.FromArgb(52, 51, 54);

                _ribbon.Theme.RendererColorTable = colors;
            }

            ButtonMinimize.BackColor = ContentContainer.BackColor;

            ButtonMaximize.BackColor = ButtonMinimize.BackColor;
            ButtonExit.BackColor = ButtonMinimize.BackColor;
            ButtonMaximize.ForeColor = ButtonMinimize.ForeColor;
            ButtonExit.ForeColor = ButtonMinimize.ForeColor;

            MenuBar.BackColor = ContentContainer.BackColor;

            RibbonContainer.Height = 100;

            RibbonTab tab = new RibbonTab();
            RibbonPanel panel = new RibbonPanel("Funktionen");
            panel.Name = "Functions";
            RibbonItem save = new RibbonButton("Speichern");
            save.ToolTip = "Speichern (Strg + s)";
            save.Name = "Save";
            save.Image = Resources.save;
            save.Click += Item_Click;
            RibbonItem undo = new RibbonButton("Rückgängig");
            undo.ToolTip = "Rückgängig machen (Strg + z)";
            undo.Name = "Undo";
            undo.Image = Resources.undo;
            undo.Click += Undo_Click;
            undo.Enabled = false;
            RibbonItem redo = new RibbonButton("Wiederholen");
            redo.ToolTip = "Wiederholen (Strg + y)";
            redo.Name = "Redo";
            redo.Image = Resources.redo;
            redo.Click += Redo_Click;
            redo.Enabled = false;
            panel.Items.Add(save);
            panel.Items.Add(undo);
            panel.Items.Add(redo);

            RibbonPanel groupsPanel = new RibbonPanel("Gruppen");
            groupsPanel.Name = "Groups";
            RibbonItem addGroup = new RibbonButton("Hinzufügen");
            addGroup.Image = Resources.addGroup;
            addGroup.Click += AddGroup_Click;
            RibbonItem renameGroup = new RibbonButton("Umbenennen");
            renameGroup.Name = "RenameGroup";
            renameGroup.Image = Resources.rename;
            renameGroup.Click += RenameGroup_Click;
            renameGroup.Enabled = false;
            RibbonItem removeGroup = new RibbonButton("Entfernen");
            removeGroup.Name = "RemoveGroup";
            removeGroup.Image = Resources.removeGroup;
            removeGroup.Click += RemoveGroup_Click;
            removeGroup.Enabled = false;
            groupsPanel.Items.Add(addGroup);
            groupsPanel.Items.Add(renameGroup);
            groupsPanel.Items.Add(removeGroup);

            RibbonPanel credentialsPanel = new RibbonPanel("Passwörter");
            credentialsPanel.Name = "Credentials";
            RibbonItem addCredential = new RibbonButton("Hinzufügen");
            addCredential.Name = "AddCredential";
            addCredential.Image = Resources.add;
            addCredential.Click += AddCredentials_Click;
            RibbonItem editCredentials = new RibbonButton("Bearbeiten");
            editCredentials.Name = "EditCredentials";
            editCredentials.Image = Resources.edit;
            editCredentials.Click += EditCredentials_Click;
            editCredentials.Enabled = false;
            RibbonItem removeCredentials = new RibbonButton("Entfernen");
            removeCredentials.Name = "RemoveCredentials";
            removeCredentials.Image = Resources.delete;
            removeCredentials.Click += RemoveCredentials_Click;
            removeCredentials.Enabled = false;
            RibbonItem login = new RibbonButton("Anmelden");
            login.ToolTip = "Anmeldung durchführen (Strg + x)";
            login.Name = "Login";
            login.Image = Resources.login;
            login.Click += Login_Click;
            login.Enabled = false;
            credentialsPanel.Items.Add(addCredential);
            credentialsPanel.Items.Add(editCredentials);
            credentialsPanel.Items.Add(removeCredentials);
            credentialsPanel.Items.Add(login);

            tab.Panels.Add(panel);
            tab.Panels.Add(groupsPanel);
            tab.Panels.Add(credentialsPanel);
            _ribbon.Tabs.Add(tab);

            RibbonContainer.Controls.Add(_ribbon);
        }

        private void Groups_DrawItemDarkColorTheme(object sender, DrawItemEventArgs e) {
            Color itemBgColor = Color.FromArgb(37, 37, 37);
            Color selectedItemBgColor = Color.FromArgb(0, 122, 226);
            Color textColor = Color.LightGray;
            Color seletedItemTextColor = Color.LightGray;

            DrawGroups(sender, e, itemBgColor, selectedItemBgColor, textColor, seletedItemTextColor);
        }

        private void Groups_DrawItemDefaultColorTheme(object sender, DrawItemEventArgs e) {
            Color itemBgColor = Color.White;
            Color selectedItemBgColor = Color.FromArgb(0, 122, 226);
            Color textColor = Color.Black;
            Color seletedItemTextColor = Color.White;

            DrawGroups(sender, e, itemBgColor, selectedItemBgColor, textColor, seletedItemTextColor);
        }

        private void DrawGroups(object sender, DrawItemEventArgs e, Color itemBgColor, Color selectedItemBgColor, Color textColor, Color seletedItemTextColor) {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;

            if (itemIndex >= 0 && itemIndex < ((ListBox)sender).Items.Count) {
                Graphics g = e.Graphics;

                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? selectedItemBgColor : itemBgColor);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                string itemText = ((ListBox)sender).Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(seletedItemTextColor) : new SolidBrush(textColor);
                g.DrawString(
                    itemText,
                    e.Font,
                    itemTextColorBrush, new PointF(
                        ((ListBox)sender).GetItemRectangle(itemIndex).Location.X + 5,
                        ((ListBox)sender).GetItemRectangle(itemIndex).Location.Y
                    )
                );
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        private void Login_Click(object sender, EventArgs e) {
            Credential credential = GetSelectedCredential();
            if (credential != null && !string.IsNullOrEmpty(credential.Username) && !string.IsNullOrEmpty(credential.Password)) {
                SendKeys.Send("%{Tab}");
                Thread.Sleep(200);
                SendKeys.Send(credential.Username);
                Thread.Sleep(200);
                SendKeys.Send("{Tab}");
                Thread.Sleep(200);
                SendKeys.Send(credential.Password);
                Thread.Sleep(200);
                SendKeys.Send("{ENTER}");
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.S) {
                SavePasswords();
                e.SuppressKeyPress = true;
            }
            else if(e.Control && e.KeyCode == Keys.X) {
                Credential credential = GetSelectedCredential();
                if (credential != null && !string.IsNullOrEmpty(credential.Username) && !string.IsNullOrEmpty(credential.Password)) {
                    SendKeys.Send("%{Tab}");
                    Thread.Sleep(50);
                    SendKeys.Send("{ENTER}");
                    Thread.Sleep(200);
                    SendKeys.Send(credential.Username);
                    Thread.Sleep(200);
                    SendKeys.Send("{Tab}");
                    Thread.Sleep(200);
                    SendKeys.Send(credential.Password);
                    Thread.Sleep(200);
                    SendKeys.Send("{ENTER}");
                }
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Z) {
                Undo();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y) {
                Redo();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete) {
                if (GetSelectedCredential() != null)
                    RemoveSelectedCredential();
                else if (GetSelectedGroup() != null)
                    RemoveSelectedGroup();
                e.SuppressKeyPress = true;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private DateTime lastClick = DateTime.Now;

        private void MainWindow_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (DateTime.Now.Subtract(lastClick).TotalMilliseconds < 200)
                ChangeWindowState();
            lastClick = DateTime.Now;
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ChangeWindowState() {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void ButtonMinimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, EventArgs e) {
            ChangeWindowState();
        }

        private void ButtonExit_Click(object sender, EventArgs e) {
            Exit();
        }

        private void Exit() {
            Close();
            Environment.Exit(1);
        }

        protected override void WndProc(ref Message m) {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg) {
                case 0x0084:
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01) {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12;
                            else
                                m.Result = (IntPtr)14;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE)) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2;
                            else
                                m.Result = (IntPtr)11;
                        }
                        else {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15;
                            else
                                m.Result = (IntPtr)17;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000;
                return cp;
            }
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e) {
            ButtonExit.Location = new Point(this.Width - 30, 5);
            ButtonMaximize.Location = new Point(ButtonExit.Location.X - 25, 5);
            ButtonMinimize.Location = new Point(ButtonMaximize.Location.X - 25, 5);
        }

        private void MenuOpen_Click(object sender, EventArgs e) {
            OpenFileDialog();
        }

        private void OpenFileDialog() {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK) {
                _storeFile = openFileDialog.FileName;
                LoadSavedPasswords();
            }
        }

        private void MenuSave_Click(object sender, EventArgs e) {
            SavePasswords();
        }

        private void MenuSaveAs_Click(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK) {
                    _manager.ChangeStoreFile(saveFileDialog.FileName);
                    SavePasswords();
                }
            }
        }

        private void MenuExit_Click(object sender, EventArgs e) {
            Exit();
        }
    }
}
