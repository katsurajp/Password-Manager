namespace PasswordManagerGUI {
    partial class CredentialsEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CredentialsEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.StrengthContainer = new System.Windows.Forms.Panel();
            this.Strength = new System.Windows.Forms.Panel();
            this.ButtonPasswordGenerator = new System.Windows.Forms.Button();
            this.StrengthContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(106, 21);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(262, 20);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Benutzername:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(106, 50);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(262, 20);
            this.tbUsername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Passwort:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(106, 79);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(262, 20);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.TbPassword_TextChanged);
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTogglePassword.Location = new System.Drawing.Point(374, 77);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(75, 23);
            this.btnTogglePassword.TabIndex = 6;
            this.btnTogglePassword.Text = "Anzeigen";
            this.btnTogglePassword.UseVisualStyleBackColor = true;
            this.btnTogglePassword.Click += new System.EventHandler(this.BtnTogglePassword_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(13, 141);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(30, 14);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "URL:";
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUrl.Location = new System.Drawing.Point(106, 137);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(262, 20);
            this.tbUrl.TabIndex = 8;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(13, 169);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(46, 14);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "Notizen:";
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(106, 166);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(347, 241);
            this.tbNotes.TabIndex = 10;
            this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(293, 437);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(378, 437);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Passwortstärke:";
            // 
            // StrengthContainer
            // 
            this.StrengthContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StrengthContainer.Controls.Add(this.Strength);
            this.StrengthContainer.Location = new System.Drawing.Point(106, 108);
            this.StrengthContainer.Name = "StrengthContainer";
            this.StrengthContainer.Size = new System.Drawing.Size(262, 20);
            this.StrengthContainer.TabIndex = 14;
            // 
            // Strength
            // 
            this.Strength.BackColor = System.Drawing.Color.Green;
            this.Strength.Dock = System.Windows.Forms.DockStyle.Left;
            this.Strength.Location = new System.Drawing.Point(0, 0);
            this.Strength.Name = "Strength";
            this.Strength.Size = new System.Drawing.Size(20, 18);
            this.Strength.TabIndex = 0;
            // 
            // ButtonPasswordGenerator
            // 
            this.ButtonPasswordGenerator.Location = new System.Drawing.Point(374, 107);
            this.ButtonPasswordGenerator.Name = "ButtonPasswordGenerator";
            this.ButtonPasswordGenerator.Size = new System.Drawing.Size(75, 23);
            this.ButtonPasswordGenerator.TabIndex = 15;
            this.ButtonPasswordGenerator.Text = "Generieren";
            this.ButtonPasswordGenerator.UseVisualStyleBackColor = true;
            this.ButtonPasswordGenerator.Click += new System.EventHandler(this.ButtonPasswordGenerator_Click);
            // 
            // CredentialsEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 487);
            this.ContentContainer.Controls.Add(this.ButtonPasswordGenerator);
            this.ContentContainer.Controls.Add(this.StrengthContainer);
            this.ContentContainer.Controls.Add(this.label6);
            this.ContentContainer.Controls.Add(this.btnCancel);
            this.ContentContainer.Controls.Add(this.btnOk);
            this.ContentContainer.Controls.Add(this.tbNotes);
            this.ContentContainer.Controls.Add(this.Label5);
            this.ContentContainer.Controls.Add(this.tbUrl);
            this.ContentContainer.Controls.Add(this.Label4);
            this.ContentContainer.Controls.Add(this.btnTogglePassword);
            this.ContentContainer.Controls.Add(this.tbPassword);
            this.ContentContainer.Controls.Add(this.label3);
            this.ContentContainer.Controls.Add(this.tbUsername);
            this.ContentContainer.Controls.Add(this.label2);
            this.ContentContainer.Controls.Add(this.tbName);
            this.ContentContainer.Controls.Add(this.label1);
            this.BorderColor = System.Drawing.Color.FromArgb(67, 67, 67);
            this.Title = "Anmeldeinformationen";
            this.CanMinimize = false;
            this.CanMaximize = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CredentialsEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Credentials";
            this.StrengthContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel StrengthContainer;
        private System.Windows.Forms.Panel Strength;
        private System.Windows.Forms.Button ButtonPasswordGenerator;
    }
}