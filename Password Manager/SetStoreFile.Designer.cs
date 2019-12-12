namespace PasswordManagerGUI {
    partial class SetStoreFile {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetStoreFile));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TbPasswordConfirm = new System.Windows.Forms.TextBox();
            this.TbMasterPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.BtnShowPassword = new System.Windows.Forms.Button();
            this.InputStoreFile = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Die Passwörter werden verschlüsselt in einer Datei gespeichert.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(403, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Für die Verschlüsselung muss ein Master Passwort festgelegt werden.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(718, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Zum Laden der gespeicherten Passwörter ist die Eingabe des hier gewählten Master " +
    "Passwortes erforderlich!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Master Passwort:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Master Passwort wiederholen:";
            // 
            // TbPasswordConfirm
            // 
            this.TbPasswordConfirm.Location = new System.Drawing.Point(169, 130);
            this.TbPasswordConfirm.Name = "TbPasswordConfirm";
            this.TbPasswordConfirm.Size = new System.Drawing.Size(263, 20);
            this.TbPasswordConfirm.TabIndex = 1;
            this.TbPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // TbMasterPassword
            // 
            this.TbMasterPassword.Location = new System.Drawing.Point(169, 100);
            this.TbMasterPassword.Name = "TbMasterPassword";
            this.TbMasterPassword.Size = new System.Drawing.Size(263, 20);
            this.TbMasterPassword.TabIndex = 0;
            this.TbMasterPassword.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(619, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Beenden";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOk.Location = new System.Drawing.Point(538, 227);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 3;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // BtnShowPassword
            // 
            this.BtnShowPassword.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowPassword.Location = new System.Drawing.Point(438, 99);
            this.BtnShowPassword.Name = "BtnShowPassword";
            this.BtnShowPassword.Size = new System.Drawing.Size(100, 23);
            this.BtnShowPassword.TabIndex = 2;
            this.BtnShowPassword.Text = "Anzeigen";
            this.BtnShowPassword.UseVisualStyleBackColor = true;
            this.BtnShowPassword.Click += new System.EventHandler(this.BtnShowPassword_Click);
            // 
            // InputStoreFile
            // 
            this.InputStoreFile.Location = new System.Drawing.Point(169, 174);
            this.InputStoreFile.Name = "InputStoreFile";
            this.InputStoreFile.Size = new System.Drawing.Size(263, 20);
            this.InputStoreFile.TabIndex = 5;
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBrowse.Location = new System.Drawing.Point(438, 173);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(100, 23);
            this.ButtonBrowse.TabIndex = 6;
            this.ButtonBrowse.Text = "Durchsuchen...";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Speicherort der Datei:";
            // 
            // CreateStoreFile
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 274);
            this.ContentContainer.Controls.Add(this.label6);
            this.ContentContainer.Controls.Add(this.ButtonBrowse);
            this.ContentContainer.Controls.Add(this.InputStoreFile);
            this.ContentContainer.Controls.Add(this.BtnShowPassword);
            this.ContentContainer.Controls.Add(this.btnCancel);
            this.ContentContainer.Controls.Add(this.ButtonOk);
            this.ContentContainer.Controls.Add(this.TbMasterPassword);
            this.ContentContainer.Controls.Add(this.TbPasswordConfirm);
            this.ContentContainer.Controls.Add(this.label5);
            this.ContentContainer.Controls.Add(this.label4);
            this.ContentContainer.Controls.Add(this.label3);
            this.ContentContainer.Controls.Add(this.label2);
            this.ContentContainer.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateStoreFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Master Passwort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbMasterPassword;
        private System.Windows.Forms.TextBox TbPasswordConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button BtnShowPassword;
        private System.Windows.Forms.TextBox InputStoreFile;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Label label6;
    }
}