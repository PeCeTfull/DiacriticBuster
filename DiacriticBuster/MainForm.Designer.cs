namespace DiacriticBuster
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.initialTextLabel = new System.Windows.Forms.Label();
            this.initialTextBox = new System.Windows.Forms.TextBox();
            this.finalTextBox = new System.Windows.Forms.TextBox();
            this.finalTextLabel = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.currentSchemeLabel = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoConvertClipboardContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiddenOnLaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moreOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialTextLabel
            // 
            resources.ApplyResources(this.initialTextLabel, "initialTextLabel");
            this.initialTextLabel.Name = "initialTextLabel";
            // 
            // initialTextBox
            // 
            resources.ApplyResources(this.initialTextBox, "initialTextBox");
            this.initialTextBox.Name = "initialTextBox";
            // 
            // finalTextBox
            // 
            resources.ApplyResources(this.finalTextBox, "finalTextBox");
            this.finalTextBox.Name = "finalTextBox";
            // 
            // finalTextLabel
            // 
            resources.ApplyResources(this.finalTextLabel, "finalTextLabel");
            this.finalTextLabel.Name = "finalTextLabel";
            // 
            // convertButton
            // 
            resources.ApplyResources(this.convertButton, "convertButton");
            this.convertButton.Name = "convertButton";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // optionsButton
            // 
            resources.ApplyResources(this.optionsButton, "optionsButton");
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // currentSchemeLabel
            // 
            resources.ApplyResources(this.currentSchemeLabel, "currentSchemeLabel");
            this.currentSchemeLabel.Name = "currentSchemeLabel";
            // 
            // aboutButton
            // 
            resources.ApplyResources(this.aboutButton, "aboutButton");
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.programOptionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeApplicationToolStripMenuItem,
            this.aboutProgramToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            // 
            // restoreToolStripMenuItem
            // 
            resources.ApplyResources(this.restoreToolStripMenuItem, "restoreToolStripMenuItem");
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // programOptionsToolStripMenuItem
            // 
            resources.ApplyResources(this.programOptionsToolStripMenuItem, "programOptionsToolStripMenuItem");
            this.programOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoConvertClipboardContentToolStripMenuItem,
            this.hiddenOnLaunchToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.toolStripSeparator2,
            this.moreOptionsToolStripMenuItem});
            this.programOptionsToolStripMenuItem.Name = "programOptionsToolStripMenuItem";
            // 
            // autoConvertClipboardContentToolStripMenuItem
            // 
            resources.ApplyResources(this.autoConvertClipboardContentToolStripMenuItem, "autoConvertClipboardContentToolStripMenuItem");
            this.autoConvertClipboardContentToolStripMenuItem.Name = "autoConvertClipboardContentToolStripMenuItem";
            this.autoConvertClipboardContentToolStripMenuItem.Click += new System.EventHandler(this.autoConvertClipboardContentToolStripMenuItem_Click);
            // 
            // hiddenOnLaunchToolStripMenuItem
            // 
            resources.ApplyResources(this.hiddenOnLaunchToolStripMenuItem, "hiddenOnLaunchToolStripMenuItem");
            this.hiddenOnLaunchToolStripMenuItem.Name = "hiddenOnLaunchToolStripMenuItem";
            this.hiddenOnLaunchToolStripMenuItem.Click += new System.EventHandler(this.hiddenOnLaunchToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            resources.ApplyResources(this.languagesToolStripMenuItem, "languagesToolStripMenuItem");
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.polskiToolStripMenuItem,
            this.deutschToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // polskiToolStripMenuItem
            // 
            resources.ApplyResources(this.polskiToolStripMenuItem, "polskiToolStripMenuItem");
            this.polskiToolStripMenuItem.Name = "polskiToolStripMenuItem";
            this.polskiToolStripMenuItem.Click += new System.EventHandler(this.polskiToolStripMenuItem_Click);
            // 
            // deutschToolStripMenuItem
            // 
            resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
            this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
            this.deutschToolStripMenuItem.Click += new System.EventHandler(this.deutschToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // moreOptionsToolStripMenuItem
            // 
            resources.ApplyResources(this.moreOptionsToolStripMenuItem, "moreOptionsToolStripMenuItem");
            this.moreOptionsToolStripMenuItem.Name = "moreOptionsToolStripMenuItem";
            this.moreOptionsToolStripMenuItem.Click += new System.EventHandler(this.moreOptionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // closeApplicationToolStripMenuItem
            // 
            resources.ApplyResources(this.closeApplicationToolStripMenuItem, "closeApplicationToolStripMenuItem");
            this.closeApplicationToolStripMenuItem.Name = "closeApplicationToolStripMenuItem";
            this.closeApplicationToolStripMenuItem.Click += new System.EventHandler(this.closeApplicationToolStripMenuItem_Click);
            // 
            // aboutProgramToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutProgramToolStripMenuItem, "aboutProgramToolStripMenuItem");
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.currentSchemeLabel);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.finalTextBox);
            this.Controls.Add(this.finalTextLabel);
            this.Controls.Add(this.initialTextBox);
            this.Controls.Add(this.initialTextLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label initialTextLabel;
        private System.Windows.Forms.TextBox initialTextBox;
        private System.Windows.Forms.TextBox finalTextBox;
        private System.Windows.Forms.Label finalTextLabel;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Label currentSchemeLabel;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polskiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem moreOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoConvertClipboardContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hiddenOnLaunchToolStripMenuItem;
    }
}

