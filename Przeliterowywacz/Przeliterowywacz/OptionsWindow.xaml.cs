using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Przeliterowywacz
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        MainWindow main = (MainWindow)Application.Current.MainWindow;
        string configFileName;

        public OptionsWindow(string configFileName, bool diacriticalOption, string speechbankName)
        {
            this.configFileName = configFileName;
            InitializeComponent();
            CheckBox1.IsChecked = diacriticalOption;
            // Wyszukuje wszystkie podfoldery w folderze Banki i dodaje znalezione elementy do listy dostępnych banków mowy
            ComboBoxItem cbi;
            string[] folderNames = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + "Banki\\");
            for (int i = 0; i < folderNames.Length; i++)
            {
                string[] folderNameStructure = folderNames[i].Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                string folderName = "NIE ZNALEZIONO FOLDERU „Banki”";
                for (int j = 0; j < folderNameStructure.Length - 1; j++)
                    if (folderNameStructure[j] == "Banki")
                    {
                        folderName = folderNameStructure[j + 1];
                        break;
                    }
                cbi = new ComboBoxItem();
                cbi.Content = folderName;
                ComboBox1.Items.Add(cbi);
            }
            // Sprawdza, czy ostatnio wybrany bank mowy dalej występuje w folderze „Banki”
            for (int i = 0; i < ComboBox1.Items.Count; i++)
            {
                ComboBox1.SelectedIndex = i;
                if (ComboBox1.SelectedItem.ToString().Substring(38) == speechbankName)
                    break;
                if (i == ComboBox1.Items.Count - 1)
                {
                    ComboBox1.SelectedIndex = 0;
                    MessageBox.Show("Folder banku mowy o nazwie „" + speechbankName + "” nie został znaleziony, przywrócono ustawienie domyślne.", main.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void DockButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            main.includeDiacriticalChars = true;
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            main.includeDiacriticalChars = false;
        }

        private void StyleButton1_Click(object sender, RoutedEventArgs e)
        {
            main.TextBox1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFFFFC0"));
            main.TextBox1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            main.inputScheme = 0;
        }

        private void StyleButton2_Click(object sender, RoutedEventArgs e)
        {
            main.TextBox1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            main.TextBox1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            main.inputScheme = 1;
        }

        private void StyleButton3_Click(object sender, RoutedEventArgs e)
        {
            main.TextBox1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            main.TextBox1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00FF00"));
            main.inputScheme = 2;
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            main.currentSpeechbank = ComboBox1.SelectedItem.ToString().Substring(38);
        }

        private void DockButton2_Click(object sender, RoutedEventArgs e)
        {
            string speechbank = main.currentSpeechbank;
            if (speechbank == "<domyślny>")
                speechbank = "<default>";
            var sw = new StreamWriter(new FileStream(configFileName, FileMode.Create), Encoding.GetEncoding(1250));
            sw.WriteLine("; Nie modyfikować tego pliku ręcznie!\r\n[Przeliterowywacz]\r\nIncludeDiactricalChars=" + Convert.ToInt16(main.includeDiacriticalChars) + "\r\nInputScheme=" + main.inputScheme + "\r\nSpeechbank=" + speechbank); // Spisywanie konfiguracji domyślnej na plik o stronie kodowej Windows-1250
            sw.Close();
        }
    }
}
