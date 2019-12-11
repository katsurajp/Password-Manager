using System;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class StoreFileNotFoundDialog : Form {
        public StoreFileNotFoundDialog() {
            InitializeComponent();
        }

        private void ButtonNewFile_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Yes;
        }

        private void ButtonOpen_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
        }
    }
}
