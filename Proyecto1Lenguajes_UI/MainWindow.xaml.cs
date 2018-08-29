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
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Proyecto1Lenguajes_UI.usr.lib;
using System.Diagnostics;

namespace Proyecto1Lenguajes_UI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ReadFile();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]{1,9}$/");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ResolvePurchase()
        {
            string fileName = "Proyecto1Lenguajes.exe";
            string workingDirectory =
                "C:\\Users\\Justin\\CLionProjects\\Proyecto1Lenguajes\\cmake-build-debug\\";

            ProcessStartInfo info = new ProcessStartInfo();

            info.UseShellExecute = true;
            info.FileName = fileName;
            info.WorkingDirectory = workingDirectory;
            info.Arguments = 10 + " Platea";

            Process.Start(info);
        }

        private void PurchaseClick(object sender, RoutedEventArgs e)
        {
            string fileName = "Proyecto1Lenguajes.exe";
            string workingDirectory =
                "C:\\Users\\Justin\\CLionProjects\\Proyecto1Lenguajes\\cmake-build-debug\\";

            ProcessStartInfo info = new ProcessStartInfo();

            info.UseShellExecute = true;
            info.FileName = fileName;
            info.WorkingDirectory = workingDirectory;
            info.Arguments = 10 + " Platea";

            Process.Start(info);
        }

        private void ReadFile()
        {
            string text = 
                System.IO.File.ReadAllText(
                    @"C:\Users\Justin\CLionProjects\Proyecto1Lenguajes\cmake-build-debug\result.txt");

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

        }

        private void SeatClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name);
        }
    }

}
