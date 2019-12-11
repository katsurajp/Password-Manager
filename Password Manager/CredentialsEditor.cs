﻿using Password_Manager;
using Password_Manager.Contract;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class CredentialsEditor : Form {
        private IPasswordAnalyzer _passwordAnalyzer;
        private IController _passwordManager;
        private CredentialGroup _credentialGroup;
        private Credential _credential;

        public Credential EditedCredential { get; set; }

        public CredentialsEditor(IController passwordManager, Credential credential, WindowColorThemes theme) {
            InitializeComponent();
            if(theme == WindowColorThemes.Dark) {
                this.FormBorderStyle = FormBorderStyle.None;
                this.BackColor = Color.FromArgb(40, 40, 40);
                this.ForeColor = Color.White;
                btnOk.BackColor = Color.FromArgb(255, 107, 31);
                foreach(Control control in this.Controls) {
                    if(control.GetType() == typeof(TextBox)) {
                        ((TextBox)control).BackColor = Color.FromArgb(64, 64, 63);
                        ((TextBox)control).ForeColor = Color.White;
                        ((TextBox)control).BorderStyle = BorderStyle.FixedSingle;
                    }
                }
            }
            Strength.Visible = false;

            _passwordAnalyzer = new StandardPasswordAnalyzer();
            _passwordManager = passwordManager;

            EditedCredential = credential;
            _credential = (Credential)credential.Clone();

            tbName.Text = _credential.Name;
            tbUrl.Text = _credential.URL;
            tbUsername.Text = _credential.Username;
            tbPassword.Text = _credential.Password;
            tbNotes.Text = _credential.Notes;
        }

        public CredentialsEditor(IController passwordManager, CredentialGroup credentialGroup, WindowColorThemes theme) {
            InitializeComponent();
            if (theme == WindowColorThemes.Dark) {
                this.BackColor = Color.FromArgb(40, 40, 40);
                this.ForeColor = Color.White;
                btnOk.BackColor = Color.FromArgb(255, 107, 31);
            }
            Strength.Visible = false;

            _passwordAnalyzer = new StandardPasswordAnalyzer();
            _passwordManager = passwordManager;

            _credential = new Credential();
            _credentialGroup = credentialGroup;
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
