namespace PasswordManagerGUI {
    partial class SettingsDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.GroupColorScheme = new System.Windows.Forms.GroupBox();
            this.RadioLightColorScheme = new System.Windows.Forms.RadioButton();
            this.RadioDarkColorScheme = new System.Windows.Forms.RadioButton();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.GroupColorScheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupColorScheme
            // 
            this.GroupColorScheme.Controls.Add(this.RadioDarkColorScheme);
            this.GroupColorScheme.Controls.Add(this.RadioLightColorScheme);
            this.GroupColorScheme.Location = new System.Drawing.Point(42, 46);
            this.GroupColorScheme.Name = "GroupColorScheme";
            this.GroupColorScheme.Size = new System.Drawing.Size(422, 60);
            this.GroupColorScheme.TabIndex = 0;
            this.GroupColorScheme.TabStop = false;
            this.GroupColorScheme.Text = "Farbschema";
            // 
            // RadioLightColorScheme
            // 
            this.RadioLightColorScheme.AutoSize = true;
            this.RadioLightColorScheme.Location = new System.Drawing.Point(20, 25);
            this.RadioLightColorScheme.Name = "RadioLightColorScheme";
            this.RadioLightColorScheme.Size = new System.Drawing.Size(43, 17);
            this.RadioLightColorScheme.TabIndex = 0;
            this.RadioLightColorScheme.TabStop = true;
            this.RadioLightColorScheme.Text = "Hell";
            this.RadioLightColorScheme.UseVisualStyleBackColor = true;
            // 
            // RadioDarkColorScheme
            // 
            this.RadioDarkColorScheme.AutoSize = true;
            this.RadioDarkColorScheme.Location = new System.Drawing.Point(99, 25);
            this.RadioDarkColorScheme.Name = "RadioDarkColorScheme";
            this.RadioDarkColorScheme.Size = new System.Drawing.Size(59, 17);
            this.RadioDarkColorScheme.TabIndex = 1;
            this.RadioDarkColorScheme.TabStop = true;
            this.RadioDarkColorScheme.Text = "Dunkel";
            this.RadioDarkColorScheme.UseVisualStyleBackColor = true;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(308, 128);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 1;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(389, 128);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Abbrechen";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // SettingsDialog
            // 
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 182);
            this.ContentContainer.Controls.Add(this.ButtonCancel);
            this.ContentContainer.Controls.Add(this.ButtonOk);
            this.ContentContainer.Controls.Add(this.GroupColorScheme);
            this.Name = "SettingsDialog";
            this.Text = "Optionen";
            this.GroupColorScheme.ResumeLayout(false);
            this.GroupColorScheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupColorScheme;
        private System.Windows.Forms.RadioButton RadioDarkColorScheme;
        private System.Windows.Forms.RadioButton RadioLightColorScheme;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
    }
}