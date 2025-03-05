using System;
using System.Windows;

namespace WpfEmailBestand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _fileName = "Email.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void readFileButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory;
        }

        private void readDialogButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void readDictionaryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void writeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
