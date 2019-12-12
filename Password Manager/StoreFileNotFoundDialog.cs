using PasswordManagerGUI.Properties;
using System;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class StoreFileNotFoundDialog : AwesomeFramelessForm {
        public StoreFileNotFoundDialog() {
            InitializeComponent();
            DoMagic();

            lblStoreFileLocation.Text = Settings.Default.StoreFile;
        }

        private void ButtonNewFile_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Yes;
        }

        private void ButtonOpen_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
        }
    }
}
