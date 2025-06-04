using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace WpfEmailBestand
{
    public partial class MainWindow : Window
    {
        private const string _fileName = "../../../../Email.txt";
        private Dictionary<string, string> _dictGeg = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void readFileButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory;
            string[] line;
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(_fileName))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine().Replace("\"", "").Split(',');
                    sb.AppendLine($"{line[0].PadRight(20, ' ')} \t : {line[1]}");
                }

                resultTextBox.Text = sb.ToString();
            }
        }

        private void readDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == true)
            {
                string unfilteredLine;
                string[] line;
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        unfilteredLine = sr.ReadLine();
                        if (unfilteredLine.Contains(","))
                        {
                            line = sr.ReadLine().Replace("\"", "").Split(',');
                        }
                        else
                        {
                            line = sr.ReadLine().Split(':');
                        }

                        sb.AppendLine($"{line[0].PadRight(20, ' ')} \t : {line[1]}");
                    }

                    resultTextBox.Text = sb.ToString();
                }
            }
        }

        private void readDictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == true)
            {
                string[] line;
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine().Replace("\"", "").Split(',');
                        _dictGeg.Add(line[0], line[1]);
                    }
                }

                if (_dictGeg.Count != 0)
                {
                    writeButton.IsEnabled = true;
                }
            }
        }

        private void writeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_dictGeg.Count != 0)
            {
                using (StreamWriter sw = new StreamWriter("Adressen.txt"))
                {
                    foreach (KeyValuePair<string, string> kvp in _dictGeg)
                    {
                        sw.WriteLine(kvp.Key.PadRight(20, ' ') + " \t : " + kvp.Value);
                    }
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            resultTextBox.Text += $"{name.PadRight(20, ' ')} \t : {email}\n";
        }
    }
}