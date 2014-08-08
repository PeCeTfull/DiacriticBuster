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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.Threading;
using System.IO;
using NAudio;
using NAudio.Wave;

namespace Przeliterowywacz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string configFileName = "Przeliterowywacz.ini"; // nazwa pliku konfiguracyjnego
        // Konfiguracja domyślna
        public bool includeDiacriticalChars = true;
        public Int16 inputScheme = 0;
        public string currentSpeechbank = "<domyślny>";

        public MainWindow()
        {
            if (File.Exists(configFileName)) // Odczytywanie pliku konfiguracyjnego (o ile istnieje)
            {
                var sr = new StreamReader(configFileName);
                string srLine;
                while ((srLine = sr.ReadLine()) != null)
                {
                    if (srLine.Contains("IncludeDiactricalChars="))
                        includeDiacriticalChars = Convert.ToBoolean(Convert.ToInt16(srLine.Substring(23)));
                    else if (srLine.Contains("InputScheme="))
                        inputScheme = Convert.ToInt16(srLine.Substring(12));
                    else if (srLine.Contains("Speechbank="))
                    {
                        currentSpeechbank = srLine.Substring(11);
                        if (currentSpeechbank == "<default>")
                            currentSpeechbank = "<domyślny>";
                    }
                }
                sr.Close();
            }
            else
            {
                var sw = new StreamWriter(new FileStream(configFileName, FileMode.CreateNew), Encoding.GetEncoding(1250));
                sw.WriteLine("; Nie modyfikować tego pliku ręcznie!\r\n[Przeliterowywacz]\r\nIncludeDiactricalChars=1\r\nInputScheme=0\r\nSpeechbank=<default>"); // Spisywanie konfiguracji domyślnej na plik o stronie kodowej Windows-1250
                sw.Close();
            }
            InitializeComponent();
            if (inputScheme == 1)
            {
                TextBox1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
                TextBox1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
            }
            else if (inputScheme == 2)
            {
                TextBox1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                TextBox1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00FF00"));
            }
        }

        public bool firstTimeRunning = true, isQuiet = true;
        OptionsWindow ow;
        AboutWindow aw;
        Thread T1;

        public static void Concatenate(string outputFile, IEnumerable<string> sourceFiles)
        {
            byte[] buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;

            try
            {
                foreach (string sourceFile in sourceFiles)
                {
                    using (WaveFileReader reader = new WaveFileReader(sourceFile))
                    {
                        if (waveFileWriter == null)
                            waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
                        else
                        {
                            if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                                throw new InvalidOperationException("Nie można powiązać plików dźwiękowych nie będących tego samego formatu!");
                        }

                        int read;
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                            waveFileWriter.WriteData(buffer, 0, read);
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                    waveFileWriter.Dispose();
            }
        }

        public string specifyFileName(int i, string toBeSaid)
        {
            string fileName = "Banki\\";
            if (currentSpeechbank != "<domyślny>")
                fileName += currentSpeechbank + '\\';
            if (toBeSaid.Substring(i, 1) == " ")
                fileName = null;
            else if (toBeSaid.Substring(i, 1) == "." || toBeSaid.Substring(i, 1) == "," || toBeSaid.Substring(i, 1) == ":" || toBeSaid.Substring(i, 1) == ";" || toBeSaid.Substring(i, 1) == "!" || toBeSaid.Substring(i, 1) == "?" || toBeSaid.Substring(i, 1) == "'" || toBeSaid.Substring(i, 1) == "\"" || toBeSaid.Substring(i, 1) == "\\" || toBeSaid.Substring(i, 1) == "/" || toBeSaid.Substring(i, 1) == "%" || toBeSaid.Substring(i, 1) == "*" || toBeSaid.Substring(i, 1) == "|" || toBeSaid.Substring(i, 1) == "<" || toBeSaid.Substring(i, 1) == ">" || toBeSaid.Substring(i, 1) == "=")
            {
                if (includeDiacriticalChars)
                {
                    if (toBeSaid.Substring(i, 1) == ".")
                        fileName += "kropka.wav";
                    else if (toBeSaid.Substring(i, 1) == ",")
                        fileName += "przecinek.wav";
                    else if (toBeSaid.Substring(i, 1) == ":")
                        fileName += "dwukropek.wav";
                    else if (toBeSaid.Substring(i, 1) == ";")
                        fileName += "srednik.wav";
                    else if (toBeSaid.Substring(i, 1) == "!")
                        fileName += "wykrzyknik.wav";
                    else if (toBeSaid.Substring(i, 1) == "?")
                        fileName += "pytajnik.wav";
                    else if (toBeSaid.Substring(i, 1) == "'")
                        fileName += "apostrof.wav";
                    else if (toBeSaid.Substring(i, 1) == "\"")
                        fileName += "cudzyslow.wav";
                    else if (toBeSaid.Substring(i, 1) == "\\")
                        fileName += "ukosnik_wsteczny.wav";
                    else if (toBeSaid.Substring(i, 1) == "/")
                        fileName += "ukosnik.wav";
                    else if (toBeSaid.Substring(i, 1) == "%")
                        fileName += "procent.wav";
                    else if (toBeSaid.Substring(i, 1) == "*")
                        fileName += "gwiazdka.wav";
                    else if (toBeSaid.Substring(i, 1) == "|")
                        fileName += "kreska_pionowa.wav";
                    else if (toBeSaid.Substring(i, 1) == "<")
                        fileName += "znak_mniejszosci.wav";
                    else if (toBeSaid.Substring(i, 1) == ">")
                        fileName += "znak_wiekszosci.wav";
                    else if (toBeSaid.Substring(i, 1) == "=")
                        fileName += "znak_rownosci.wav";
                }
                else
                    fileName = null;
            }
            else
                fileName += toBeSaid.Substring(i, 1).ToLower() + ".wav";
            return fileName;
        }

        void F1(object txt)
        {
            string toBeSpelled = (string)txt, waveFileName = "";
            SoundPlayer letterFile;
            try
            {
                for (int i = 0; i < toBeSpelled.Length; i++)
                {
                    waveFileName = specifyFileName(i, toBeSpelled);
                    if (isQuiet)
                        break;
                    if (waveFileName != null)
                    {
                        letterFile = new SoundPlayer((string)waveFileName);
                        letterFile.PlaySync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operacja przerwana, ponieważ wystąpił problem z następującym plikiem: " + AppDomain.CurrentDomain.BaseDirectory + waveFileName + ". " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            isQuiet = true;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (!firstTimeRunning)
            {
                if (isQuiet)
                {
                    if (ow != null)
                        ow.Close();
                    string textToSpell = TextBox1.Text;
                    isQuiet = false;
                    T1 = new Thread(F1);
                    T1.Start(textToSpell);
                }
                else
                    MessageBox.Show("Nie można teraz wykonać tej operacji, ponieważ poprzednio wywołana wciąż jest w toku. Aby móc to zrobić, należy poczekać na jej zakończenie.", MainSpeechWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
                MessageBox.Show("Wprowadź najpierw tekst do przeliterowania.", MainSpeechWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void TextBox1_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (firstTimeRunning)
            {
                TextBox1.Text = "";
                firstTimeRunning = false;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (ow != null)
            {
                ow.Close();
                ow = null;
            }
            if (isQuiet)
            {
                ow = new OptionsWindow(configFileName, includeDiacriticalChars, currentSpeechbank);
                ow.Show();
            }
            else
                MessageBox.Show("Program zajęty. Aby móc to zrobić, należy najpierw poczekać na zakończenie operacji.", MainSpeechWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private async void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (!firstTimeRunning)
            {
                var FD = new Microsoft.Win32.SaveFileDialog();
                FD.FileName = "*";
                FD.DefaultExt = "wav";
                FD.ValidateNames = true;
                FD.Filter = "Pliki dźwiękowe (*.wav)|*.wav|Wszystkie pliki|*.*";

                Nullable<bool> result = FD.ShowDialog();
                if (result == true)
                {
                    string textToRecord = TextBox1.Text, waveFileName = "";
                    List<string> filesToPlayList = new List<string>();
                    bool wasFailed = false;

                    for (int i = 0; i < textToRecord.Length; i++)
                    {
                        waveFileName = specifyFileName(i, textToRecord);
                        if (waveFileName != null)
                        {
                            if (File.Exists(waveFileName))
                                filesToPlayList.Add(waveFileName);
                            else
                            {
                                wasFailed = true;
                                break;
                            }
                        }
                    }

                    if (!wasFailed)
                    {
                        Concatenate(FD.FileName, filesToPlayList);
                        if (File.Exists(FD.FileName))
                        {
                            StatusLabel.Content = "Zapisano.";
                            await Task.Delay(5000);
                            StatusLabel.Content = "";
                        }
                    }
                    else
                        MessageBox.Show("Plik nie został pomyślnie zapisany, ponieważ jeden lub więcej plików wymaganych do odtworzenia nie zostało znalezionych.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else
                MessageBox.Show("Wprowadź najpierw tekst do nagrania.", MainSpeechWindow.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void MainSpeechWindow_Closed(object sender, EventArgs e)
        {
            isQuiet = true;
            if (ow != null)
                ow.Close();
            if (aw != null)
                aw.Close();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (aw != null)
            {
                aw.Close();
                aw = null;
            }
            aw = new AboutWindow();
            aw.Show();
        }
    }
}
