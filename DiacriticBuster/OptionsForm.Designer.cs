namespace DiacriticBuster
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.schemesListBox = new System.Windows.Forms.ListBox();
            this.availableSchemesLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.languagesGroupBox = new System.Windows.Forms.GroupBox();
            this.deutschRadioButton = new System.Windows.Forms.RadioButton();
            this.polskiRadioButton = new System.Windows.Forms.RadioButton();
            this.englishRadioButton = new System.Windows.Forms.RadioButton();
            this.applyButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.generalSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.hiddenOnLaunchCheckBox = new System.Windows.Forms.CheckBox();
            this.convertClipboardWithHotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.languagesGroupBox.SuspendLayout();
            this.generalSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // schemesListBox
            // 
            resources.ApplyResources(this.schemesListBox, "schemesListBox");
            this.schemesListBox.FormattingEnabled = true;
            this.schemesListBox.Name = "schemesListBox";
            this.schemesListBox.SelectedIndexChanged += new System.EventHandler(this.schemesListBox_SelectedIndexChanged);
            // 
            // availableSchemesLabel
            // 
            resources.ApplyResources(this.availableSchemesLabel, "availableSchemesLabel");
            this.availableSchemesLabel.Name = "availableSchemesLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // languagesGroupBox
            // 
            resources.ApplyResources(this.languagesGroupBox, "languagesGroupBox");
            this.languagesGroupBox.Controls.Add(this.deutschRadioButton);
            this.languagesGroupBox.Controls.Add(this.polskiRadioButton);
            this.languagesGroupBox.Controls.Add(this.englishRadioButton);
            this.languagesGroupBox.Name = "languagesGroupBox";
            this.languagesGroupBox.TabStop = false;
            // 
            // deutschRadioButton
            // 
            resources.ApplyResources(this.deutschRadioButton, "deutschRadioButton");
            this.deutschRadioButton.Name = "deutschRadioButton";
            this.deutschRadioButton.TabStop = true;
            this.deutschRadioButton.UseVisualStyleBackColor = true;
            this.deutschRadioButton.CheckedChanged += new System.EventHandler(this.deutschRadioButton_CheckedChanged);
            // 
            // polskiRadioButton
            // 
            resources.ApplyResources(this.polskiRadioButton, "polskiRadioButton");
            this.polskiRadioButton.Name = "polskiRadioButton";
            this.polskiRadioButton.TabStop = true;
            this.polskiRadioButton.UseVisualStyleBackColor = true;
            this.polskiRadioButton.CheckedChanged += new System.EventHandler(this.polskiRadioButton_CheckedChanged);
            // 
            // englishRadioButton
            // 
            resources.ApplyResources(this.englishRadioButton, "englishRadioButton");
            this.englishRadioButton.Name = "englishRadioButton";
            this.englishRadioButton.TabStop = true;
            this.englishRadioButton.UseVisualStyleBackColor = true;
            this.englishRadioButton.CheckedChanged += new System.EventHandler(this.englishRadioButton_CheckedChanged);
            // 
            // applyButton
            // 
            resources.ApplyResources(this.applyButton, "applyButton");
            this.applyButton.Name = "applyButton";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // importButton
            // 
            resources.ApplyResources(this.importButton, "importButton");
            this.importButton.Name = "importButton";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // generalSettingsGroupBox
            // 
            resources.ApplyResources(this.generalSettingsGroupBox, "generalSettingsGroupBox");
            this.generalSettingsGroupBox.Controls.Add(this.hiddenOnLaunchCheckBox);
            this.generalSettingsGroupBox.Controls.Add(this.convertClipboardWithHotkeyCheckBox);
            this.generalSettingsGroupBox.Name = "generalSettingsGroupBox";
            this.generalSettingsGroupBox.TabStop = false;
            // 
            // hiddenOnLaunchCheckBox
            // 
            resources.ApplyResources(this.hiddenOnLaunchCheckBox, "hiddenOnLaunchCheckBox");
            this.hiddenOnLaunchCheckBox.Name = "hiddenOnLaunchCheckBox";
            this.hiddenOnLaunchCheckBox.UseVisualStyleBackColor = true;
            // 
            // convertClipboardWithHotkeyCheckBox
            // 
            resources.ApplyResources(this.convertClipboardWithHotkeyCheckBox, "convertClipboardWithHotkeyCheckBox");
            this.convertClipboardWithHotkeyCheckBox.Name = "convertClipboardWithHotkeyCheckBox";
            this.convertClipboardWithHotkeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.generalSettingsGroupBox);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.languagesGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.availableSchemesLabel);
            this.Controls.Add(this.schemesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.languagesGroupBox.ResumeLayout(false);
            this.languagesGroupBox.PerformLayout();
            this.generalSettingsGroupBox.ResumeLayout(false);
            this.generalSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox schemesListBox;
        private System.Windows.Forms.Label availableSchemesLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox languagesGroupBox;
        private System.Windows.Forms.RadioButton deutschRadioButton;
        private System.Windows.Forms.RadioButton polskiRadioButton;
        private System.Windows.Forms.RadioButton englishRadioButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.GroupBox generalSettingsGroupBox;
        private System.Windows.Forms.CheckBox hiddenOnLaunchCheckBox;
        private System.Windows.Forms.CheckBox convertClipboardWithHotkeyCheckBox;
    }
}