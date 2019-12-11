﻿namespace PasswordManagerGUI {
    partial class StoreFileNotFoundDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreFileNotFoundDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonNewFile = new System.Windows.Forms.Button();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Die Passwortdatenbank wurde nicht am erwarteten Speicherplatz gefunden :(";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Neue Datei erstellen oder vorhandene Datei?";
            // 
            // ButtonNewFile
            // 
            this.ButtonNewFile.Location = new System.Drawing.Point(24, 94);
            this.ButtonNewFile.Name = "ButtonNewFile";
            this.ButtonNewFile.Size = new System.Drawing.Size(153, 23);
            this.ButtonNewFile.TabIndex = 2;
            this.ButtonNewFile.Text = "Neue Passwortdatenbank";
            this.ButtonNewFile.UseVisualStyleBackColor = true;
            this.ButtonNewFile.Click += new System.EventHandler(this.ButtonNewFile_Click);
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(192, 94);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(153, 23);
            this.ButtonOpen.TabIndex = 3;
            this.ButtonOpen.Text = "Öffnen...";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // StoreFileNotFoundDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(427, 146);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.ButtonNewFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StoreFileNotFoundDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Passwortdatenbank nicht gefunden :(";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonNewFile;
        private System.Windows.Forms.Button ButtonOpen;
    }
}