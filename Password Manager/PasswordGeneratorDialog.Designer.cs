namespace PasswordManagerGUI {
    partial class PasswordGeneratorDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordGeneratorDialog));
            this.PasswordLength = new System.Windows.Forms.NumericUpDown();
            this.CheckUpperCaseLetters = new System.Windows.Forms.CheckBox();
            this.CheckLowerCaseLetters = new System.Windows.Forms.CheckBox();
            this.CheckDigits = new System.Windows.Forms.CheckBox();
            this.CheckSpecialCharacters = new System.Windows.Forms.CheckBox();
            this.InputSpecialCharacters = new System.Windows.Forms.TextBox();
            this.InputPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLength)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordLength
            // 
            this.PasswordLength.Location = new System.Drawing.Point(128, 29);
            this.PasswordLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PasswordLength.Name = "PasswordLength";
            this.PasswordLength.Size = new System.Drawing.Size(120, 20);
            this.PasswordLength.TabIndex = 1;
            this.PasswordLength.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // CheckUpperCaseLetters
            // 
            this.CheckUpperCaseLetters.AutoSize = true;
            this.CheckUpperCaseLetters.Location = new System.Drawing.Point(25, 83);
            this.CheckUpperCaseLetters.Name = "CheckUpperCaseLetters";
            this.CheckUpperCaseLetters.Size = new System.Drawing.Size(105, 17);
            this.CheckUpperCaseLetters.TabIndex = 2;
            this.CheckUpperCaseLetters.Text = "Großbuchstaben";
            this.CheckUpperCaseLetters.UseVisualStyleBackColor = true;
            // 
            // CheckLowerCaseLetters
            // 
            this.CheckLowerCaseLetters.AutoSize = true;
            this.CheckLowerCaseLetters.Location = new System.Drawing.Point(25, 60);
            this.CheckLowerCaseLetters.Name = "CheckLowerCaseLetters";
            this.CheckLowerCaseLetters.Size = new System.Drawing.Size(105, 17);
            this.CheckLowerCaseLetters.TabIndex = 3;
            this.CheckLowerCaseLetters.Text = "Kleinbuchstaben";
            this.CheckLowerCaseLetters.UseVisualStyleBackColor = true;
            // 
            // CheckDigits
            // 
            this.CheckDigits.AutoSize = true;
            this.CheckDigits.Location = new System.Drawing.Point(25, 106);
            this.CheckDigits.Name = "CheckDigits";
            this.CheckDigits.Size = new System.Drawing.Size(59, 17);
            this.CheckDigits.TabIndex = 4;
            this.CheckDigits.Text = "Zahlen";
            this.CheckDigits.UseVisualStyleBackColor = true;
            // 
            // CheckSpecialCharacters
            // 
            this.CheckSpecialCharacters.AutoSize = true;
            this.CheckSpecialCharacters.Location = new System.Drawing.Point(25, 130);
            this.CheckSpecialCharacters.Name = "CheckSpecialCharacters";
            this.CheckSpecialCharacters.Size = new System.Drawing.Size(100, 17);
            this.CheckSpecialCharacters.TabIndex = 5;
            this.CheckSpecialCharacters.Text = "Sonderzeichen:";
            this.CheckSpecialCharacters.UseVisualStyleBackColor = true;
            this.CheckSpecialCharacters.CheckedChanged += new System.EventHandler(this.CheckSpecialCharacters_CheckedChanged);
            // 
            // InputSpecialCharacters
            // 
            this.InputSpecialCharacters.Location = new System.Drawing.Point(128, 128);
            this.InputSpecialCharacters.Name = "InputSpecialCharacters";
            this.InputSpecialCharacters.Size = new System.Drawing.Size(172, 20);
            this.InputSpecialCharacters.TabIndex = 6;
            // 
            // InputPassword
            // 
            this.InputPassword.Location = new System.Drawing.Point(81, 250);
            this.InputPassword.Name = "InputPassword";
            this.InputPassword.Size = new System.Drawing.Size(188, 20);
            this.InputPassword.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Passwort:";
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Location = new System.Drawing.Point(275, 248);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
            this.ButtonGenerate.TabIndex = 9;
            this.ButtonGenerate.Text = "Generieren";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(194, 323);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 10;
            this.ButtonOk.Text = "OK";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(275, 323);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 11;
            this.ButtonCancel.Text = "Abbrechen";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Passwortlänge:";
            // 
            // PasswordGeneratorDialog
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContentContainer.Controls.Add(this.label2);
            this.ContentContainer.Controls.Add(this.ButtonCancel);
            this.ContentContainer.Controls.Add(this.ButtonOk);
            this.ContentContainer.Controls.Add(this.ButtonGenerate);
            this.ContentContainer.Controls.Add(this.label1);
            this.ContentContainer.Controls.Add(this.InputPassword);
            this.ContentContainer.Controls.Add(this.InputSpecialCharacters);
            this.ContentContainer.Controls.Add(this.CheckSpecialCharacters);
            this.ContentContainer.Controls.Add(this.CheckDigits);
            this.ContentContainer.Controls.Add(this.CheckLowerCaseLetters);
            this.ContentContainer.Controls.Add(this.CheckUpperCaseLetters);
            this.ContentContainer.Controls.Add(this.PasswordLength);
            this.ClientSize = new System.Drawing.Size(383, 375);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Title = "Passwort Generator";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordGeneratorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Generator";
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown PasswordLength;
        private System.Windows.Forms.CheckBox CheckUpperCaseLetters;
        private System.Windows.Forms.CheckBox CheckLowerCaseLetters;
        private System.Windows.Forms.CheckBox CheckDigits;
        private System.Windows.Forms.CheckBox CheckSpecialCharacters;
        private System.Windows.Forms.TextBox InputSpecialCharacters;
        private System.Windows.Forms.TextBox InputPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label2;
    }
}