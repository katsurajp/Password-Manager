using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public class AwesomeFramelessForm : Form {
        public Panel ContentContainer { get; set; }

        public Button ButtonExit;
        public Button ButtonMaximize;
        public Button ButtonMinimize;

        public Color BorderColor { get; set; } = Color.LightGray;

        public bool HasBorder { get; set; } = true;

        public bool CanMaximize { get; set; }

        public bool CanMinimize { get; set; }

        public bool IsMainWindow { get; set; } = false;

        public static WindowColorSchemes ColorScheme { get; set; }

        public string Title { get; set; }

        public AwesomeFramelessForm() {
            ContentContainer = new Panel();
            ContentContainer.Dock = DockStyle.Fill;
            ContentContainer.SuspendLayout();
            Controls.Add(this.ContentContainer);
            ContentContainer.ResumeLayout(false);
            ContentContainer.PerformLayout();

            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void DoMagic() {
            FormBorderStyle = FormBorderStyle.None;

            CenterToScreen();

            ButtonExit = new Button();
            ButtonExit.Text = "X";
            ButtonExit.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ButtonExit.Location = new System.Drawing.Point(1124, 0);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new System.Drawing.Size(20, 20);
            ButtonExit.TabIndex = 5;
            ButtonExit.Text = "X";
            ButtonExit.UseVisualStyleBackColor = true;
            ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);

            ButtonMaximize = new Button();
            ButtonMaximize.Text = "";
            ButtonMaximize.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            ButtonMaximize.Location = new System.Drawing.Point(1098, 0);
            ButtonMaximize.Name = "ButtonMaximize";
            ButtonMaximize.Size = new System.Drawing.Size(20, 20);
            ButtonMaximize.TabIndex = 6;
            ButtonMaximize.Text = "q";
            ButtonMaximize.UseVisualStyleBackColor = true;
            ButtonMaximize.Click += new System.EventHandler(this.ButtonMaximize_Click);

            ButtonMinimize = new Button();
            ButtonMinimize.Text = "-";
            ButtonMinimize.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ButtonMinimize.Location = new System.Drawing.Point(1072, 0);
            ButtonMinimize.Name = "ButtonMinimize";
            ButtonMinimize.Size = new System.Drawing.Size(20, 20);
            ButtonMinimize.TabIndex = 7;
            ButtonMinimize.UseVisualStyleBackColor = true;
            ButtonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);

            ButtonExit.Location = new Point(this.Width - 30, 5);
            ButtonMaximize.Location = new Point(ButtonExit.Location.X - 25, 5);
            ButtonMinimize.Location = new Point(ButtonMaximize.Location.X - 25, 5);

            ContentContainer.Controls.Add(ButtonExit);
            ContentContainer.Controls.Add(ButtonMaximize);
            ContentContainer.Controls.Add(ButtonMinimize);

            SetStyles();

            if (!CanMaximize)
                ButtonMaximize.Hide();

            if (!CanMinimize)
                ButtonMinimize.Hide();

            this.ClientSizeChanged += SizeChanged;

            this.MouseDown += MainWindow_MouseDown;
            ContentContainer.MouseDown += MainWindow_MouseDown;

            CenterToScreen();

            if(HasBorder) {
                ContentContainer.Paint += AwesomeFramelessForm_Paint;
                Update();
            }

            SetTitle();
            SizeChanged();
        }

        private void SetTitle() {
            if (!string.IsNullOrEmpty(Title)) {
                Panel titlePanel = new Panel();
                if (ColorScheme == WindowColorSchemes.Light)
                    titlePanel.BackColor = Color.FromArgb(0, 122, 226);
                else
                    titlePanel.BackColor = Color.FromArgb(20, 20, 19);
                Label titleLabel = new Label() {
                    Text = Title,
                    Location = new Point(10, 8)
                };
                titleLabel.ForeColor = Color.White;
                titlePanel.Controls.Add(titleLabel);
                titlePanel.Dock = DockStyle.Top;
                titlePanel.Height = 30;

                foreach(Control control in ContentContainer.Controls) {
                    control.Location = new Point(control.Location.X, control.Location.Y + 35);
                }

                this.Height += 25;

                titlePanel.MouseDown += MainWindow_MouseDown;

                ContentContainer.Controls.Add(titlePanel);
            }
        }

        private void SetStyles() {
            ButtonMinimize.FlatStyle = FlatStyle.Flat;
            ButtonMinimize.FlatAppearance.BorderSize = 0;
            ButtonMaximize.FlatStyle = ButtonMinimize.FlatStyle;
            ButtonMaximize.FlatAppearance.BorderSize = ButtonMinimize.FlatAppearance.BorderSize;
            ButtonExit.FlatStyle = ButtonMinimize.FlatStyle;
            ButtonExit.FlatAppearance.BorderSize = ButtonMinimize.FlatAppearance.BorderSize;

            if (ColorScheme == WindowColorSchemes.Light)
                SetLightColorScheme();
            else if (ColorScheme == WindowColorSchemes.Dark)
                SetDarkColorScheme();

            ButtonMinimize.BackColor = ContentContainer.BackColor;
            ButtonMaximize.BackColor = ButtonMinimize.BackColor;
            ButtonExit.BackColor = ButtonMinimize.BackColor;
            ButtonMaximize.ForeColor = ButtonMinimize.ForeColor;
            ButtonExit.ForeColor = ButtonMinimize.ForeColor;
        }

        private void SetDarkColorScheme() {
            if (!IsMainWindow)
                ContentContainer.BackColor = Color.FromArgb(27, 27, 28);
            else
                ContentContainer.BackColor = Color.FromArgb(46, 45, 48);

            foreach (Control control in ContentContainer.Controls) {
                if (control.GetType() == typeof(Label)) {
                    ((Label)control).ForeColor = Color.LightGray;
                }
                else if (control.GetType() == typeof(TextBox)) {
                    control.BackColor = Color.FromArgb(52, 51, 54);
                    ((TextBox)control).BorderStyle = BorderStyle.FixedSingle;
                    ((TextBox)control).Font = new Font("Verdana", 9);
                    ((TextBox)control).ForeColor = Color.LightGray;
                }
                else if (control.GetType() == typeof(Button)) {
                    ((Button)control).FlatStyle = FlatStyle.Flat;
                    if (this.AcceptButton == (Button)control) {
                        control.BackColor = Color.FromArgb(255, 107, 31);
                        ((Button)control).ForeColor = Color.FromArgb(10, 10, 10);
                    }
                    else {
                        ((Button)control).BackColor = Color.FromArgb(51, 51, 51);
                        ((Button)control).ForeColor = Color.FromArgb(140, 140, 140);
                    }
                }
                else if (control.GetType() == typeof(NumericUpDown)) {
                    control.BackColor = Color.FromArgb(52, 51, 54);
                    ((NumericUpDown)control).ForeColor = Color.LightGray;
                }
                else if(control.GetType() == typeof(GroupBox)) {
                    control.ForeColor = Color.LightGray;
                }
            }

            ButtonMinimize.ForeColor = Color.LightGray;
            ContentContainer.ForeColor = Color.LightGray;

            BorderColor = Color.FromArgb(10, 10, 10);
            ContentContainer.Update();
        }

        private void SetLightColorScheme() {
            ButtonMinimize.ForeColor = Color.Black;
            BorderColor = Color.FromArgb(0, 122, 226);
            if (!IsMainWindow)
                ContentContainer.BackColor = Color.FromArgb(239, 238, 239);
            else
                ContentContainer.BackColor = Color.FromArgb(240, 240, 237);
        }

        private void AwesomeFramelessForm_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            Brush brush = new SolidBrush(BorderColor);
            Rectangle rec = new Rectangle(0, 0, Width - 1, Height - 1);
            g.DrawRectangle(new Pen(brush), rec);
        }

        protected override void WndProc(ref Message m) {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg) {
                case 0x0084:
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01) {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12;
                            else
                                m.Result = (IntPtr)14;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE)) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2;
                            else
                                m.Result = (IntPtr)11;
                        }
                        else {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15;
                            else
                                m.Result = (IntPtr)17;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private DateTime lastClick = DateTime.Now;

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000;
                return cp;
            }
        }

        private void MainWindow_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (DateTime.Now.Subtract(lastClick).TotalMilliseconds < 200 && CanMaximize)
                ChangeWindowState();
            lastClick = DateTime.Now;
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private new void SizeChanged(object sender, EventArgs e) {
            SizeChanged();
        }

        private void SizeChanged() {
            ButtonExit.Location = new Point(this.Width - 30, 5);
            ButtonMaximize.Location = new Point(ButtonExit.Location.X - 25, 5);
            ButtonMinimize.Location = new Point(ButtonMaximize.Location.X - 25, 5);
        }

        private void ButtonMinimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, EventArgs e) {
            ChangeWindowState();
        }

        private void ButtonExit_Click(object sender, EventArgs e) {
            Exit();
        }

        private void Exit() {
            Close();
        }

        private void ChangeWindowState() {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeComponent() {
            this.ContentContainer = new Panel();
            this.SuspendLayout();
            // 
            // ContentContainer
            // 
            this.ContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentContainer.Location = new System.Drawing.Point(0, 0);
            this.ContentContainer.Name = "ContentContainer";
            this.ContentContainer.Size = new System.Drawing.Size(284, 261);
            this.ContentContainer.TabIndex = 0;
            // 
            // AwesomeFramelessForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ContentContainer);
            this.Name = "AwesomeFramelessForm";
            this.ResumeLayout(false);

        }
    }
}
