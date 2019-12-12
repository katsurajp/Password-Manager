using System;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class PasswordPrompt : AwesomeFramelessForm {
        public string Input { get; set; }

        public PasswordPrompt() {
            InitializeComponent();
            DoMagic();
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            Input = tbPassword.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
