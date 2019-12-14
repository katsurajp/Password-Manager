using PasswordManagerGUI.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class SetStoreFile : AwesomeFramelessForm {
        public string Input { get; set; }

        public string StoreFile { get; set; }

        private bool _isInitialSetup;

        public SetStoreFile(bool isInitialSetup) {
            InitializeComponent();
            _isInitialSetup = isInitialSetup;
            DoMagic();
            TbMasterPassword.Select();

            InputStoreFile.Text = $"{new FileInfo(Assembly.GetEntryAssembly().Location).DirectoryName}\\D6qA5QN31w.dat";

            if(!isInitialSetup) {
                btnCancel.Text = "Abbrechen";
            }
        }

        private void BtnShowPassword_Click(object sender, EventArgs e) {
            TbMasterPassword.UseSystemPasswordChar = !TbMasterPassword.UseSystemPasswordChar;
            TbPasswordConfirm.UseSystemPasswordChar = TbMasterPassword.UseSystemPasswordChar;
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            if (_isInitialSetup)
                DialogResult = DialogResult.Abort;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            string password = TbMasterPassword.Text;
            string passwordConfirmation = TbPasswordConfirm.Text;

            if (String.IsNullOrEmpty(password)) {
                MessageBox.Show("Es muss ein Master Passwort eingegeben werden.");
                return;
            }

            else if (password.Length < 4) {
                MessageBox.Show("Das Master Passwort muss mindestens 4 Zeichen lang sein.");
                return;
            }

            else if (string.Compare(password, passwordConfirmation, false) != 0) {
                MessageBox.Show("Die eingegebenen Passwörter stimmen nicht überein.");
                return;
            }

            //if (!Uri.IsWellFormedUriString(InputStoreFile.Text, UriKind.Absolute)) {
            //    MessageBox.Show("Ungültiger Pfad für Datei.");
            //    return;
            //}

            StoreFile = InputStoreFile.Text;
            Input = password;

            if (_isInitialSetup) {
                Settings.Default.StoreFile = StoreFile;
                Settings.Default.Save();
            }

            DialogResult = DialogResult.OK;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
                InputStoreFile.Text = saveFileDialog.FileName;
        }
    }
}
