using PasswordManagerGUI.Properties;
using System;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class SettingsDialog : AwesomeFramelessForm {
        public SettingsDialog() {
            InitializeComponent();
            DoMagic();

            if (ColorScheme == WindowColorSchemes.Dark)
                RadioDarkColorScheme.Checked = true;
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            bool settingsChanged = false;
            if (RadioLightColorScheme.Checked && ColorScheme != WindowColorSchemes.Light) {
                ColorScheme = WindowColorSchemes.Light;
                Settings.Default.ColorScheme = WindowColorSchemes.Light;
                settingsChanged = true;
            }
            if (RadioDarkColorScheme.Checked && ColorScheme != WindowColorSchemes.Dark) {
                ColorScheme = WindowColorSchemes.Dark;
                Settings.Default.ColorScheme = WindowColorSchemes.Dark;
                settingsChanged = true;
            }

            if (settingsChanged) {
                DialogResult = DialogResult.OK;
                Settings.Default.Save();
            }
            else {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }
    }
}
