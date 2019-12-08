namespace PasswordManagerGUI {
    partial class MainWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GroupPanel = new System.Windows.Forms.Panel();
            this.Groups = new System.Windows.Forms.ListBox();
            this.DetailsContainer = new System.Windows.Forms.Panel();
            this.RibbonContainer = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1152, 534);
            this.panel2.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 534);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GroupPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DetailsContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1152, 534);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 5;
            // 
            // GroupPanel
            // 
            this.GroupPanel.Controls.Add(this.Groups);
            this.GroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupPanel.Location = new System.Drawing.Point(0, 0);
            this.GroupPanel.Name = "GroupPanel";
            this.GroupPanel.Size = new System.Drawing.Size(264, 534);
            this.GroupPanel.TabIndex = 1;
            // 
            // Groups
            // 
            this.Groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Groups.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Groups.FormattingEnabled = true;
            this.Groups.ItemHeight = 16;
            this.Groups.Location = new System.Drawing.Point(0, 0);
            this.Groups.Name = "Groups";
            this.Groups.Size = new System.Drawing.Size(264, 534);
            this.Groups.TabIndex = 1;
            this.Groups.SelectedIndexChanged += new System.EventHandler(this.Groups_SelectedIndexChanged);
            // 
            // DetailsContainer
            // 
            this.DetailsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.DetailsContainer.Name = "DetailsContainer";
            this.DetailsContainer.Size = new System.Drawing.Size(884, 534);
            this.DetailsContainer.TabIndex = 2;
            // 
            // RibbonContainer
            // 
            this.RibbonContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.RibbonContainer.Location = new System.Drawing.Point(0, 0);
            this.RibbonContainer.Name = "RibbonContainer";
            this.RibbonContainer.Size = new System.Drawing.Size(1152, 149);
            this.RibbonContainer.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 683);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.RibbonContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GroupPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel GroupPanel;
        private System.Windows.Forms.ListBox Groups;
        private System.Windows.Forms.Panel DetailsContainer;
        private System.Windows.Forms.Panel RibbonContainer;
    }
}