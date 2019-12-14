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
    public partial class MainWindow : AwesomeFramelessForm {
        private Ribbon _ribbon;
        private ObjectListView _details;
        private string _storeFile;

        private IPasswordSage _manager;

        public MainWindow() : base() {
            ColorScheme = Settings.Default.ColorScheme;

            InitializeComponent();
            CanMaximize = true;
            HasBorder = false;
            DoMagic();
            CenterToScreen();
            this.FormClosed += MainWindow_FormClosed;

            if (ColorScheme == WindowColorSchemes.Dark) {
                this.BackColor = Color.FromArgb(32, 36, 42);
            }

            _storeFile = Settings.Default.StoreFile;

            LoadForm();

            if (!File.Exists(_storeFile)) {
                if(string.IsNullOrEmpty(Settings.Default.StoreFile)) {
                    CreateNewStoreFileInstance(true);
                    _storeFile = Settings.Default.StoreFile;
                }
                else {
                    StoreFileNotFoundDialog dialog = new StoreFileNotFoundDialog();
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.Yes)
                        CreateNewStoreFileInstance(true);
                    else if (result == DialogResult.No)
                        OpenFileDialog();
                    else
                        Exit();
                }
            }
            else {
                LoadSavedPasswords();
            }

            this.SizeChanged += MainWindow_SizeChanged;
        }

        private void LoadForm() {
            SetDetailsView();
            SetRibbonBar();

            _ribbon.Tabs.First().Panels.Find(p => p.Name == "Credentials").Items.Where(i => new[] { "AddCredential" }.Contains(i.Name)).ToList().ForEach(i => i.Enabled = Groups.SelectedItem != null);
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e) {
            _details.AutoResizeColumns();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) {
            Exit();
        }

        private void BindGroups(ICollection<CredentialGroup> groups) {
            Groups.Items.Clear();

            IEnumerable<CredentialGroup> source = groups.OrderBy(g => g.Name);

            source.ToList().ForEach(g => {
                Groups.Items.Add(g.Name);
            });


            if (groups.Count > 0)
                Groups.SelectedIndex = 0;

            BindDetails(groups.FirstOrDefault());
        }

        private bool CreateNewStoreFileInstance(bool isInitialSetup) {
            SetStoreFile newStoreFileDialog = new SetStoreFile(isInitialSetup);
            DialogResult result = newStoreFileDialog.ShowDialog();

            if(result == DialogResult.OK) {
                _storeFile = newStoreFileDialog.StoreFile;
                GetAESKeyAndIV(newStoreFileDialog.Input, out byte[] key, out byte[] iv);
                CreatePasswordManagerInstance(key, iv);

                return true;
            }
            else if(result == DialogResult.Cancel) {
                newStoreFileDialog.Close();
                newStoreFileDialog.Dispose();
            }
            else {
                Exit();
            }

            return false;
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
            _manager = new PasswordSafe(store);
            ((PasswordSafe)_manager).OnCommandExecuted += MainWindow_OnCommandExecuted;
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
                editor = new CredentialsEditor(_manager, credential);
            else
                editor = new CredentialsEditor(_manager, group);

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
            _details.MultiSelect = false;

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

            if (ColorScheme == WindowColorSchemes.Light) {
                splitContainer1.BackColor = Color.FromArgb(239, 238, 239);
                _details.HeaderFormatStyle = new HeaderFormatStyle();
                _details.HeaderFormatStyle.Normal.BackColor = Color.FromArgb(206, 206, 217);
                _details.HeaderFormatStyle.Hot.BackColor = Color.FromArgb(215, 215, 214);
                _details.HeaderFormatStyle.Pressed = _details.HeaderFormatStyle.Hot;
                _details.BackColor = Color.FromArgb(255, 255, 252);
                _details.ForeColor = Color.Black;
                _details.SelectedBackColor = Color.FromArgb(0, 122, 226);
                _details.SelectedForeColor = Color.White;
                _details.HyperlinkStyle.Normal.ForeColor = Color.FromArgb(4, 145, 193);
                _details.HyperlinkStyle.Over = _details.HyperlinkStyle.Normal;
                _details.HyperlinkStyle.Visited = _details.HyperlinkStyle.Normal;
            }
            if(ColorScheme == WindowColorSchemes.Dark) {
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
            }

            DetailsContainer.BackColor = _details.BackColor;
            panel2.BackColor = _details.BackColor;
        }

        private void SetRibbonBar() {
            _ribbon = new Ribbon();
            _ribbon.Dock = DockStyle.Fill;
            _ribbon.OrbVisible = false;
            _ribbon.CaptionBarVisible = false;

            Groups.DrawMode = DrawMode.OwnerDrawFixed;

            if (ColorScheme == WindowColorSchemes.Light) {
                RibbonProfesionalRendererColorTable colors = new RibbonProfesionalRendererColorTable();

                Application.EnableVisualStyles();
                MenuBar.ForeColor = Color.Black;
                foreach (var item in MenuBar.Items) {
                    var dropDown = (ToolStripMenuItem)item;
                    foreach (var dropDownItem in dropDown.DropDownItems) {
                        if (dropDownItem.GetType() == typeof(ToolStripMenuItem))
                            ((ToolStripMenuItem)dropDownItem).ForeColor = Color.Black;
                    }
                }

                Groups.BackColor = Color.FromArgb(245, 245, 242);
                Groups.ForeColor = Color.Black;

                Groups.DrawItem += Groups_DrawItemLightColorScheme;

                foreach (FieldInfo field in colors.GetType().GetFields()) {
                    var type = Nullable.GetUnderlyingType(field.FieldType) ?? field.FieldType;
                    if (type == typeof(Color)) {
                        if (field.Name.ToLower().Contains("buttonchecked") || field.Name.ToLower().Contains("buttonselected"))
                            field.SetValue(colors, Color.FromArgb(196, 222, 247));
                        else if (field.Name.ToLower().Contains("text") && !field.Name.ToLower().Contains("textbackground"))
                            field.SetValue(colors, Color.Black);
                        else if (field.Name.ToLower().Contains("paneltextbackground"))
                            field.SetValue(colors, Color.FromArgb(206, 206, 217));
                        else
                            field.SetValue(colors, Color.FromArgb(239, 238, 239));
                    }
                }

                _ribbon.Theme.RendererColorTable = colors;
            }
            else if (ColorScheme == WindowColorSchemes.Dark) {
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

                Groups.DrawItem += Groups_DrawItemDarkColorScheme;

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

                _ribbon.Theme.RendererColorTable = colors;
            }

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

        private void Groups_DrawItemDarkColorScheme(object sender, DrawItemEventArgs e) {
            Color itemBgColor = Color.FromArgb(37, 37, 37);
            Color selectedItemBgColor = Color.FromArgb(0, 122, 226);
            Color textColor = Color.LightGray;
            Color seletedItemTextColor = Color.LightGray;

            DrawGroups(sender, e, itemBgColor, selectedItemBgColor, textColor, seletedItemTextColor);
        }

        private void Groups_DrawItemLightColorScheme(object sender, DrawItemEventArgs e) {
            Color itemBgColor = Color.FromArgb(245, 245, 242);
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

        private void Exit() {
            Environment.Exit(1);
        }

        private void MenuNew_Click(object sender, EventArgs e) {
            if (CreateNewStoreFileInstance(false)) {
                _manager.Save();
                LoadSavedPasswords();
            }
        }

        private void MenuOpen_Click(object sender, EventArgs e) {
            OpenFileDialog();
        }

        private void OpenFileDialog() {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "orz";
            openFileDialog.Filter = "Password Manager File (*.orz)|*.orz";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK) {
                _storeFile = openFileDialog.FileName;

                LoadSavedPasswords();

                if (MessageBox.Show(
                    "Soll diese Datei ab sofort beim Starten des Programms immer geöffnet werden?",
                    "Neue Standard-Datei?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Settings.Default.StoreFile = _storeFile;
                    Settings.Default.Save();
                }
            }
        }

        private void MenuSave_Click(object sender, EventArgs e) {
            SavePasswords();
        }

        private void MenuOptions_Click(object sender, EventArgs e) {
            SettingsDialog settingsDialog = new SettingsDialog();
            DialogResult result = settingsDialog.ShowDialog();

            if(result == DialogResult.OK) {
                MessageBox.Show("Änderung wird nach Neustart des Programms wirksam.");
            }
        }

        private void MenuSaveAs_Click(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.DefaultExt = "orz";
                saveFileDialog.Filter = "Password Manager File (*.orz)|*.orz";
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
