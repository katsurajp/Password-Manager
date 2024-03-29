﻿using System;
using System.Windows.Forms;

namespace PluginServiceApplication {
    public partial class PasswordPrompt : Form {
        public string Input { get; set; }

        public PasswordPrompt() {
            InitializeComponent();
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
