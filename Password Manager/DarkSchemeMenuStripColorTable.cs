using System.Drawing;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public class DarkSchemeMenuStripColorTable : ProfessionalColorTable {
        public DarkSchemeMenuStripColorTable() {
            base.UseSystemColors = false;
        }

        public override Color ToolStripDropDownBackground => Color.FromArgb(27, 27, 28);

        public override Color MenuItemSelected => Color.FromArgb(51, 51, 51);

        public override Color SeparatorDark => Color.FromArgb(51, 51, 51);

        public override Color SeparatorLight => Color.FromArgb(51, 51, 51);

        public override Color MenuBorder => Color.FromArgb(27, 27, 28);

        public override Color MenuItemBorder => Color.FromArgb(51, 51, 51);

        public override Color ImageMarginGradientBegin => Color.FromArgb(51, 51, 51);

        public override Color ImageMarginGradientMiddle => Color.FromArgb(51, 51, 51);

        public override Color ImageMarginGradientEnd => Color.FromArgb(51, 51, 51);

        public override Color MenuStripGradientBegin => Color.FromArgb(51, 51, 51);

        public override Color MenuStripGradientEnd => Color.FromArgb(51, 51, 51);

        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(51, 51, 51);

        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(51, 51, 51);

        public override Color MenuItemPressedGradientBegin => Color.FromArgb(51, 51, 51);

        public override Color MenuItemPressedGradientEnd => Color.FromArgb(51, 51, 51);
    }
}
