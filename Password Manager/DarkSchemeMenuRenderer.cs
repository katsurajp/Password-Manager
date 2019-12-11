using System.Drawing;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public class DarkSchemeMenuRenderer : ToolStripProfessionalRenderer {
        public DarkSchemeMenuRenderer(ProfessionalColorTable colorTable) : base(colorTable) {
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);

            Color color = Color.FromArgb(27, 27, 28);

            using (SolidBrush brush = new SolidBrush(color)) {
                e.Graphics.FillRectangle(brush, rc);
            }
        }
    }
}
