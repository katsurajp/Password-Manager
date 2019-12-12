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
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GroupPanel.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentContainer
            // 
            this.ContentContainer.Controls.Add(this.panel2);
            this.ContentContainer.Controls.Add(this.RibbonContainer);
            this.ContentContainer.Controls.Add(this.MenuBar);
            this.ContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentContainer.Location = new System.Drawing.Point(1, 1);
            this.ContentContainer.Name = "ContentContainer";
            this.ContentContainer.Padding = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.ContentContainer.Size = new System.Drawing.Size(1150, 681);
            this.ContentContainer.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1144, 485);
            this.panel2.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 485);
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
            this.splitContainer1.Size = new System.Drawing.Size(1144, 485);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 5;
            // 
            // GroupPanel
            // 
            this.GroupPanel.Controls.Add(this.Groups);
            this.GroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupPanel.Location = new System.Drawing.Point(0, 0);
            this.GroupPanel.Name = "GroupPanel";
            this.GroupPanel.Size = new System.Drawing.Size(261, 485);
            this.GroupPanel.TabIndex = 1;
            // 
            // Groups
            // 
            this.Groups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Groups.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Groups.FormattingEnabled = true;
            this.Groups.ItemHeight = 16;
            this.Groups.Location = new System.Drawing.Point(0, 0);
            this.Groups.Name = "Groups";
            this.Groups.Size = new System.Drawing.Size(261, 485);
            this.Groups.TabIndex = 1;
            this.Groups.SelectedIndexChanged += new System.EventHandler(this.Groups_SelectedIndexChanged);
            // 
            // DetailsContainer
            // 
            this.DetailsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.DetailsContainer.Name = "DetailsContainer";
            this.DetailsContainer.Size = new System.Drawing.Size(879, 485);
            this.DetailsContainer.TabIndex = 2;
            // 
            // RibbonContainer
            // 
            this.RibbonContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.RibbonContainer.Location = new System.Drawing.Point(3, 44);
            this.RibbonContainer.Name = "RibbonContainer";
            this.RibbonContainer.Size = new System.Drawing.Size(1144, 149);
            this.RibbonContainer.TabIndex = 2;
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.extrasToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(3, 20);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1144, 24);
            this.MenuBar.TabIndex = 4;
            this.MenuBar.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.speichernUnterToolStripMenuItem,
            this.MenuSave,
            this.MenuSaveAs,
            this.toolStripMenuItem1,
            this.MenuExit});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(177, 22);
            this.MenuOpen.Text = "Öffnen";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // speichernUnterToolStripMenuItem
            // 
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(177, 22);
            this.MenuSave.Text = "Speichern (Strg + s)";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuSaveAs
            // 
            this.MenuSaveAs.Name = "MenuSaveAs";
            this.MenuSaveAs.Size = new System.Drawing.Size(177, 22);
            this.MenuSaveAs.Text = "Speichern unter...";
            this.MenuSaveAs.Click += new System.EventHandler(this.MenuSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(177, 22);
            this.MenuExit.Text = "Beenden";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.optionenToolStripMenuItem.Text = "Optionen";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 683);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Manager";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GroupPanel.ResumeLayout(false);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);

            this.CanMaximize = true;
            this.CanMinimize = true;
            this.IsMainWindow = true;
        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel GroupPanel;
        private System.Windows.Forms.ListBox Groups;
        private System.Windows.Forms.Panel DetailsContainer;
        private System.Windows.Forms.Panel RibbonContainer;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripSeparator speichernUnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
    }
}