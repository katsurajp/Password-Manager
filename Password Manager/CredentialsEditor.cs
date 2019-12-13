using Password_Manager;
using Password_Manager.Contract;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class CredentialsEditor : AwesomeFramelessForm {
        private IPasswordAnalyzer _passwordAnalyzer;
        private IPasswordSage _passwordManager;
        private CredentialGroup _credentialGroup;
        private Credential _credential;

        public Credential EditedCredential { get; set; }

        public CredentialsEditor(IPasswordSage passwordManager, Credential credential) {
            InitializeComponent();
            DoMagic();
            SetInstance(passwordManager);

            EditedCredential = credential;
            _credential = (Credential)credential.Clone();

            tbName.Text = _credential.Name;
            tbUrl.Text = _credential.URL;
            tbUsername.Text = _credential.Username;
            tbPassword.Text = _credential.Password;
            tbNotes.Text = _credential.Notes;
        }

        public CredentialsEditor(IPasswordSage passwordManager, CredentialGroup credentialGroup) {
            InitializeComponent();
            DoMagic();
            SetInstance(passwordManager);

            _credential = new Credential();
            _credentialGroup = credentialGroup;
        }

        private void SetInstance(IPasswordSage passwordManager) {
            _passwordAnalyzer = new StandardPasswordAnalyzer();
            _passwordManager = passwordManager;

            Strength.Visible = false;
            AcceptButton = null;

            if (ColorScheme == WindowColorSchemes.Dark)
                Strength.BackColor = Color.FromArgb(0, 176, 69);
        }

        private void BtnTogglePassword_Click(object sender, System.EventArgs e) {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }

        private void BtnCancel_Click(object sender, System.EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnOk_Click(object sender, System.EventArgs e) {
            _credential.Name = tbName.Text;
            _credential.URL = tbUrl.Text;
            _credential.Username = tbUsername.Text;
            _credential.Password = tbPassword.Text;
            _credential.Notes = tbNotes.Text;

            try {
                if (_credential.ID > 0)
                    EditedCredential = _passwordManager.UpdateCredential(EditedCredential, _credential);
                else
                    EditedCredential = _passwordManager.AddCredential(_credentialGroup, _credential);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void TbPassword_TextChanged(object sender, System.EventArgs e) {
            if(string.IsNullOrEmpty(tbPassword.Text)) {
                Strength.Visible = false;
            }
            else {
                Strength.Visible = true;
                int strength = (int)_passwordAnalyzer.CheckStrength(tbPassword.Text);
                Strength.Width = (int)((float)StrengthContainer.Width / 100 * (float)strength / 5 * 100);
            }
        }

        private void ButtonPasswordGenerator_Click(object sender, EventArgs e) {
            PasswordGeneratorDialog passwordGeneratorDialog = new PasswordGeneratorDialog();
            DialogResult result = passwordGeneratorDialog.ShowDialog();

            if(result == DialogResult.OK) {
                tbPassword.Text = passwordGeneratorDialog.Password;
            }
        }
    }
}
