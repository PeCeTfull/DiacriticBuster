using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DiacriticBuster
{
    public partial class OptionsForm : Form
    {
        //MainForm mf = (MainForm)Form.ActiveForm; // this way is incompatible with VS breakpoints and makes the debugging application crash
        MainForm mf = (MainForm)Application.OpenForms[0];
        string activeLanguage;
        string selectedLanguage;

        public OptionsForm(string language)
        {
            activeLanguage = language;
            selectedLanguage = activeLanguage;
            InitializeComponent();
            schemesListBox.Items.Add(Properties.Resources.Default);
            // insert all the schemes found inside Schemes folder into "Available schemes" list
            DirectoryInfo schemes = new DirectoryInfo(mf.ReturnSchemesDirectoryName());
            FileInfo[] files = schemes.GetFiles("*.txt");
            foreach (FileInfo file in files)
                schemesListBox.Items.Add(file.Name.Substring(0, file.Name.Length - 4));
            // select the currently chosen scheme
            for (int i = 0; i < schemesListBox.Items.Count; i++)
            {
                schemesListBox.SelectedIndex = i;
                if (schemesListBox.SelectedItem.ToString() == mf.ReturnCurrentSchemeName())
                    break;
                else
                    schemesListBox.SelectedIndex = 0;
            }
            // determine which program language is currently being used
            if (activeLanguage.IndexOf("pl") > -1)
                polskiRadioButton.Checked = true;
            else if (activeLanguage.IndexOf("de") > -1)
                deutschRadioButton.Checked = true;
            else
                englishRadioButton.Checked = true;
            // check current general settings
            convertClipboardWithHotkeyCheckBox.Checked = mf.ReturnAutoConvertClipboardContentProperty();
            hiddenOnLaunchCheckBox.Checked = mf.ReturnHiddenOnStartupProperty();
        }

        private void ShowNoSchemeSelectedMessageBox()
        {
            MessageBox.Show(Properties.Resources.NoSchemeSelectedMessage, FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ApplySettings()
        {
            if (selectedLanguage != activeLanguage)
            {
                mf.ChangeLanguage(selectedLanguage);
                activeLanguage = selectedLanguage;
                MessageBox.Show(Properties.Resources.ChangedLanguageMessage, FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            mf.ChangeSchemePublicInfo(schemesListBox.SelectedItem.ToString());
            mf.ChangeAutoConvertClipboardContentProperty(convertClipboardWithHotkeyCheckBox.Checked);
            mf.ChangeHiddenOnStartupProperty(hiddenOnLaunchCheckBox.Checked);
            mf.SaveSettings(selectedLanguage);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (schemesListBox.SelectedItem != null)
            {
                ApplySettings();
                this.Close();
            }
            else
                ShowNoSchemeSelectedMessageBox();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (schemesListBox.SelectedItem != null)
                ApplySettings();
            else
                ShowNoSchemeSelectedMessageBox();
        }

        private void schemesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (schemesListBox.SelectedIndex == 0)
                removeButton.Enabled = false;
            else
                removeButton.Enabled = true;
        }

        private void englishRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (englishRadioButton.Checked)
                selectedLanguage = "en-CA";
        }

        private void polskiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (polskiRadioButton.Checked)
                selectedLanguage = "pl-PL";
        }

        private void deutschRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (deutschRadioButton.Checked)
                selectedLanguage = "de-DE";
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string schemeFileLocation = mf.ReturnSchemesDirectoryName() + schemesListBox.SelectedItem.ToString() + ".txt";
            if (File.Exists(schemeFileLocation))
                File.Delete(schemeFileLocation);
            schemesListBox.Items.Remove(schemesListBox.SelectedItem);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            FD.DefaultExt = "txt";
            FD.ValidateNames = true;
            FD.Filter = Properties.Resources.FileTypes;
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(FD.FileName))
                {
                    // Scheme file compatibility check
                    var sr = new StreamReader(FD.FileName);
                    string srLine;
                    int i = 0;
                    bool isPassed = true; // a variable determining if the test is passed
                    while ((srLine = sr.ReadLine()) != null)
                    {
                        if (srLine.Length > 0 && (srLine.IndexOf('|') == -1 || srLine.IndexOf('|') != srLine.LastIndexOf('|') || srLine.Contains("�"))) // there must be only one single '|' char per line and the file mustn't be encoded in ANSI if it contains any diacritic or other char from miscellaneous writing systems
	                    {
                            isPassed = false; // TEST NOT PASSED
		                    break;
	                    }
                        i++;
                    }
                    sr.Close();
                    // Importing process
                    if (isPassed)
                    {
                        string destinationFileName = mf.ReturnSchemesDirectoryName() + FD.SafeFileName;
                        if (File.Exists(destinationFileName))
                        {
                            var overwriteMB = MessageBox.Show(Properties.Resources.OverwriteFileMessage, FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (overwriteMB == DialogResult.Yes)
                                File.Copy(FD.FileName, destinationFileName, true);
                        }
                        else
                        {
                            File.Copy(FD.FileName, destinationFileName);
                            if (File.Exists(destinationFileName))
                                schemesListBox.Items.Add(FD.SafeFileName.Split('.')[0]);
                        }
                    }
                    else
                        MessageBox.Show(Properties.Resources.SchemeFileNotValidMessage, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    MessageBox.Show(Properties.Resources.FileNotFoundMessage, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
