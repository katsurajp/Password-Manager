using System;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class CreateStoreFile : Form {
        public string Input { get; set; }

        public CreateStoreFile() {
            InitializeComponent();
            TbMasterPassword.Select();
        }

        private void BtnShowPassword_Click(object sender, EventArgs e) {
            TbMasterPassword.UseSystemPasswordChar = !TbMasterPassword.UseSystemPasswordChar;
            TbPasswordConfirm.UseSystemPasswordChar = TbMasterPassword.UseSystemPasswordChar;
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
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
                MessageBox.Show("Die eingegebenen Passwörter stimmen nicht überein");
                return;
            }

            Input = password;

            DialogResult = DialogResult.OK;
        }
    }
}
