using Password_Manager;
using Password_Manager.Contract;
using PasswordManagerGUI.Properties;
using System;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class PasswordGeneratorDialog : AwesomeFramelessForm {
        public string Password { get; set; }

        public PasswordGeneratorDialog() {
            InitializeComponent();
            DoMagic();

            PasswordLength.Value = Settings.Default.PasswordLength;
            InputSpecialCharacters.Text = Settings.Default.SpecialCharacters;
            CheckLowerCaseLetters.Checked = Settings.Default.ContainsLowerCaseLetters;
            CheckUpperCaseLetters.Checked = Settings.Default.ContainsUpperCaseLetters;
            CheckDigits.Checked = Settings.Default.ContainsDigits;
            CheckSpecialCharacters.Checked = Settings.Default.ContainsSpecialCharacters;
            InputSpecialCharacters.Enabled = CheckSpecialCharacters.Checked;

            Generate();
        }

        private void ButtonGenerate_Click(object sender, EventArgs e) {
            Generate();
        }

        private void Generate() {
            IPasswordGenerator passwordGenerator;

            bool containsLowerCaseLetters = CheckLowerCaseLetters.Checked;
            bool containsUpperCaseLetters = CheckUpperCaseLetters.Checked;
            bool containsDigits = CheckDigits.Checked;
            bool containsSpecialCharacters = CheckSpecialCharacters.Checked;

            PasswordRules rules = new PasswordRules() {
                ContainsLowerCaseLetters = containsLowerCaseLetters,
                ContainsUpperCaseLetters = containsUpperCaseLetters,
                ContainsDigits = containsDigits,
                ContainsSpecialCharacters = containsSpecialCharacters
            };

            int passwordLength = (int)PasswordLength.Value;

            if (containsSpecialCharacters && InputSpecialCharacters.Text.Length < 1) {
                MessageBox.Show("Keine Sonderzeichen angegeben.");
                return;
            }

            passwordGenerator = new PasswordGenerator(rules, InputSpecialCharacters.Text.ToCharArray());

            string password = passwordGenerator.Generate(passwordLength);
            InputPassword.Text = password;
            Password = password;

            Settings.Default.PasswordLength = (int)PasswordLength.Value;
            Settings.Default.ContainsLowerCaseLetters = CheckLowerCaseLetters.Checked;
            Settings.Default.ContainsUpperCaseLetters = CheckUpperCaseLetters.Checked;
            Settings.Default.ContainsDigits = CheckDigits.Checked;
            Settings.Default.ContainsSpecialCharacters = CheckSpecialCharacters.Checked;
            Settings.Default.SpecialCharacters = InputSpecialCharacters.Text;

            Settings.Default.Save();
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CheckSpecialCharacters_CheckedChanged(object sender, EventArgs e) {
            InputSpecialCharacters.Enabled = CheckSpecialCharacters.Checked;
        }
    }
}
