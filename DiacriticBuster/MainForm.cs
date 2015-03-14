using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DiacriticBuster
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        const string configFileName = "DiacriticBuster.ini"; // the configuration filename
        // DEFAULT CONFIGURATION
        string currentScheme = Properties.Resources.Default;
        string currentLanguage = "en-CA";
        bool autoConvertClipboardContentOnAltC = true;
        bool hiddenOnStartup = false;

        // FORM'S 'PERSONAL' OPTIONS
        private bool allowShowDisplay = false;
        string schemesDirectory = Environment.CurrentDirectory + "\\Schemes\\";
        int currentSchemeBasicStringLength;
        Dictionary<string, string> currentDiacriticDealingMethods = new Dictionary<string, string>();

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowShowDisplay ? value : allowShowDisplay);
        }

        public void LoadScheme()
        {
            if (currentScheme != "<default>")
            {
                currentDiacriticDealingMethods.Clear();
                string schemeFileLocation = schemesDirectory + currentScheme + ".txt";
                if (File.Exists(schemeFileLocation))
                {
                    var sr = new StreamReader(schemeFileLocation);
                    string srLine;
                    int i = 0;
                    bool isAnyKeyRepeated = false;
                    while ((srLine = sr.ReadLine()) != null)
                    {
                        string[] diacriticRule = srLine.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            currentDiacriticDealingMethods.Add(diacriticRule[0], diacriticRule[1]);
                        }
                        catch (ArgumentException) // happens mostly when the key is already added to the dictionary - when it repeats, it's simply omitted
                        {
                            if (!isAnyKeyRepeated)
                            {
                                MessageBox.Show(Properties.Resources.AnyKeyRepeatedMessage, FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                isAnyKeyRepeated = true;
                            }
                            continue;
                        }
                        i++;
                    }
                    sr.Close();
                }
                else
                    currentScheme = Properties.Resources.Default;
            }
        }

        public void ChangeLanguage(string chosenLanguage)
        {
            foreach (Control c in this.Controls)
            {
                var crm = new ComponentResourceManager(typeof(MainForm));
                crm.ApplyResources(c, c.Name, new CultureInfo(chosenLanguage));
            }
            currentLanguage = chosenLanguage;
            currentSchemeBasicStringLength = this.label3.Text.Length;
            if (currentLanguage.IndexOf("pl") > -1)
            {
                englishToolStripMenuItem.Checked = false;
                polskiToolStripMenuItem.Checked = true;
                deutschToolStripMenuItem.Checked = false;
            }
            else if (currentLanguage.IndexOf("de") > -1)
            {
                englishToolStripMenuItem.Checked = false;
                polskiToolStripMenuItem.Checked = false;
                deutschToolStripMenuItem.Checked = true;
            }
            else
            {
                englishToolStripMenuItem.Checked = true;
                polskiToolStripMenuItem.Checked = false;
                deutschToolStripMenuItem.Checked = false;
            }
        }

        public MainForm()
        {
            if (File.Exists(configFileName)) // reading the configuration file
            {
                var sr = new StreamReader(configFileName);
                string srLine;
                while ((srLine = sr.ReadLine()) != null)
                {
                    if (srLine.Contains("Language="))
                    {
                        currentLanguage = srLine.Substring(9);
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(currentLanguage);
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);
                    }
                    else if (srLine.Contains("Scheme="))
                    {
                        currentScheme = srLine.Substring(7);
                        if (currentScheme == "<default>")
                            currentScheme = Properties.Resources.Default;
                    }
                    else if (srLine.Contains("AutoConvertClipboardContentOnAltC="))
                        autoConvertClipboardContentOnAltC = Convert.ToBoolean(Convert.ToInt16(srLine.Substring(34)));
                    else if (srLine.Contains("HiddenOnStartup="))
                        hiddenOnStartup = Convert.ToBoolean(Convert.ToInt16(srLine.Substring(16)));
                }
                sr.Close();
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(currentLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);
            }

            InitializeComponent();

            this.Text = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName;
            this.notifyIcon1.Text = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName;
            this.restoreToolStripMenuItem.Font = new Font(this.restoreToolStripMenuItem.Font, FontStyle.Bold);
            this.aboutProgramToolStripMenuItem.Text = Properties.Resources.BeforeAboutMenuName + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName + Properties.Resources.AfterAboutMenuName;
            if (currentLanguage.IndexOf("pl") > -1)
                polskiToolStripMenuItem.Checked = true;
            else if (currentLanguage.IndexOf("de") > -1)
                deutschToolStripMenuItem.Checked = true;
            else
                englishToolStripMenuItem.Checked = true;

            LoadScheme();
            currentSchemeBasicStringLength = this.label3.Text.Length;
            this.label3.Text += currentScheme;

            if (autoConvertClipboardContentOnAltC)
            {
                RegisterHotKey(this.Handle, 0, (int)KeyModifier.Alt, Keys.C.GetHashCode());
                autoConvertClipboardContentToolStripMenuItem.Checked = true;
            }

            if (!hiddenOnStartup)
                this.allowShowDisplay = true;
            else
                hiddenOnStartupToolStripMenuItem.Checked = true;
        }

        public string ReturnSchemesDirectoryName()
        {
            return schemesDirectory;
        }

        public string ReturnCurrentSchemeName()
        {
            return currentScheme;
        }

        public bool ReturnAutoConvertClipboardContentProperty()
        {
            return autoConvertClipboardContentOnAltC;
        }

        public bool ReturnHiddenOnStartupProperty()
        {
            return hiddenOnStartup;
        }

        public void ChangeSchemePublicInfo(string switchedScheme)
        {
            label3.Text = label3.Text.Substring(0, currentSchemeBasicStringLength);
            currentScheme = switchedScheme;
            string schemeName;
            if (currentScheme.Length > 52)
                schemeName = currentScheme.Substring(0, 50) + "...";
            else
                schemeName = currentScheme;
            label3.Text += schemeName;
            LoadScheme();
        }

        public void ChangeAutoConvertClipboardContentProperty(bool switchedProperty)
        {
            autoConvertClipboardContentOnAltC = switchedProperty;
            if (switchedProperty)
                RegisterHotKey(this.Handle, 0, (int)KeyModifier.Alt, Keys.C.GetHashCode());
            else
                UnregisterHotKey(this.Handle, 0);
            autoConvertClipboardContentToolStripMenuItem.Checked = switchedProperty;
        }

        public void ChangeHiddenOnStartupProperty(bool switchedProperty)
        {
            hiddenOnStartup = switchedProperty;
            hiddenOnStartupToolStripMenuItem.Checked = switchedProperty;
        }

        public void SaveSettings(string chosenLanguage)
        {
            string scheme = currentScheme;
            if (scheme == Properties.Resources.Default)
                scheme = "<default>";
            try
            {
                var sw = new StreamWriter(new FileStream(configFileName, FileMode.Create), Encoding.UTF8);
                sw.WriteLine("; Don't modify this file manually! Nie modyfikować tego pliku ręcznie! Modifizieren Sie nicht diese Datei manuell!\r\n[" + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName + "]\r\nLanguage=" + chosenLanguage + "\r\nScheme=" + scheme + "\r\nAutoConvertClipboardContentOnAltC=" + Convert.ToInt16(autoConvertClipboardContentOnAltC) + "\r\nHiddenOnStartup=" + Convert.ToInt16(hiddenOnStartup)); // rewriting the configuration into the file using UTF-8 conversion
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Properties.Resources.CannotOverwriteConfigFileMessage, configFileName), Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private string ConvertText(string initialText)
        {
            string finalText = "";
            if (currentScheme == Properties.Resources.Default)
            {
                byte[] textBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(initialText);
                finalText = System.Text.Encoding.UTF8.GetString(textBytes);
            }
            else
            {
                int charDebt = 0;
                for (int i = 0; i < initialText.Length; i++)
                {
                    if (charDebt > 0)
                    {
                        charDebt--;
                        continue;
                    }
                    bool accentNotFound = true;
                    foreach (var accent in currentDiacriticDealingMethods)
                    {
                        try
                        {
                            if (accent.Key == initialText.Substring(i, accent.Key.Length))
                            {
                                if (accent.Value == "#") // if the value is just a number sign (hash), then a conventional converting task is done
                                {
                                    byte[] textBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accent.Key);
                                    finalText += System.Text.Encoding.UTF8.GetString(textBytes);
                                }
                                else
                                    finalText += accent.Value;
                                accentNotFound = false;
                                if (accent.Key.Length > 1)
                                    charDebt += accent.Key.Length - 1;
                                break;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            continue;
                        }
                    }
                    if (accentNotFound)
                        finalText += initialText.Substring(i, 1);
                }
            }
            return finalText;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (autoConvertClipboardContentOnAltC && m.Msg == 0x0312)
            {
                try
                {
                    string textToConvert = Clipboard.GetText();
                    if (textToConvert != null && textToConvert != "")
                        Clipboard.SetText(ConvertText(textToConvert));
                }
                catch (AccessViolationException) // happens mostly when the Clipboard is completely empty
                {
                    ;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textToConvert = textBox1.Text;
            textBox2.Text = "";
            textBox2.Text = ConvertText(textToConvert);
        }

        OptionsForm of;
        AboutBox ab;

        private void ShowProgramOptions()
        {
            if (of != null)
            {
                of.Close();
                of = null;
            }
            of = new OptionsForm(currentLanguage);
            of.Show(this);
        }

        private void ShowAboutBox()
        {
            ab = new AboutBox();
            ab.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowProgramOptions();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }

        private void HideOrShowMainForm()
        {
            if (this.allowShowDisplay == false)
            {
                this.allowShowDisplay = true;
                this.Visible = !this.Visible;
            }
            else if (this.Visible)
                this.Hide();
            else
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HideOrShowMainForm();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideOrShowMainForm();
        }

        private void closeApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ab == null)
                ShowAboutBox();
            else if (!ab.Visible)
                ShowAboutBox();
        }

        private void moreOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowProgramOptions();
        }

        private void ChangeLanguageFromMenu(string chosenLanguage)
        {
            ChangeLanguage(chosenLanguage);
            MessageBox.Show(Properties.Resources.ChangedLanguageMessage, FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location).ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            SaveSettings(chosenLanguage);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedLanguage = "en-CA";
            if (!englishToolStripMenuItem.Checked)
                ChangeLanguageFromMenu(selectedLanguage);
        }

        private void polskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedLanguage = "pl-PL";
            if (!polskiToolStripMenuItem.Checked)
                ChangeLanguageFromMenu(selectedLanguage);
        }

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedLanguage = "de-DE";
            if (!deutschToolStripMenuItem.Checked)
                ChangeLanguageFromMenu(selectedLanguage);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
        }

        private void autoConvertClipboardContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeAutoConvertClipboardContentProperty(!autoConvertClipboardContentToolStripMenuItem.Checked);
            SaveSettings(currentLanguage);
        }

        private void hiddenOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeHiddenOnStartupProperty(!hiddenOnStartupToolStripMenuItem.Checked);
            SaveSettings(currentLanguage);
        }
    }
}
