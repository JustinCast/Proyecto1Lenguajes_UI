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
            ReadFile();
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
            System.IO.StreamReader file =
                new System.IO.StreamReader(
                    @"C:\Users\Justin\CLionProjects\Proyecto1Lenguajes\cmake-build-debug\result.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                string[] result = line.Split(':');
                Console.WriteLine("Result[0]: {0}\nResult[1]: {1}", result[0], result[1]);
                ManageCategory(result[0], result[1]);
            }
            file.Close();

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

        }

        private void ManageCategory(string category, string seats)
        {
            switch(category)
            {
                case "Platea":
                    FillCategory(PlateaGrid, seats);
                    break;
                case "Platea Sur":
                    FillCategory(PlateaSurGrid, seats);
                    break;
                case "Platea Norte":
                    FillCategory(PlateaNorteGrid, seats);
                    break;
                case "Tribuna":
                    FillCategory(TribunaGrid, seats);
                    break;
                default: break;
            }
        }

        private void FillCategory(Grid grid, string s)
        {
            string[] seats = s.Split('-');
            string[] btnNameSplitted;
            for (int index = 0; index < grid.Children.Count; index++)
                for (int i = 0; i < seats.Length; i++)
                {
                    btnNameSplitted = (grid.Children[index] as Button).Name.Split('_');
                    if (seats[i].Equals(btnNameSplitted[1]))
                    {                     
                        (grid.Children[index] as Button).Background = Brushes.Blue;
                    }
                }                  
        }

        private void SeatClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name);
        }
    }

}
