using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.IO;

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
            SliderConfig();
            //ReadFile();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]{1,9}$/");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PurchaseClick(object sender, RoutedEventArgs e)
        {
            string fileName = "Proyecto1Lenguajes.exe";
            string workingDirectory =
                "C:\\Users\\Justin\\CLionProjects\\Proyecto1Lenguajes\\cmake-build-debug\\";
            int tickets;
            int.TryParse(TicketsCuantity.Text, out tickets);

            ProcessStartInfo info = new ProcessStartInfo();
           
            info.UseShellExecute = true;
            info.FileName = fileName;
            info.WorkingDirectory = workingDirectory;
            if((bool) PreFillSeats.IsChecked)
                info.Arguments = tickets + " " + CategoryCmbx.Text + " " + Percentage.Content + " " + PreFillCategoriesCmbx.Text;
            else
                info.Arguments = tickets + " " + CategoryCmbx.Text +" " + 0 + " " + "Platea";

            var process = Process.Start(info);
            while (!process.HasExited && process.Responding)
            {
                Thread.Sleep(100);
            }
            if(process.HasExited)
                ReadFile();
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
                ManageCategory(result[0], result[1]);
            }
            
            file.Close();        
        }

        private void ManageCategory(string category, string seats)
        {
            switch(category)
            {
                case "Platea":
                    FillCategory(PlateaGrid, seats);
                    break;
                case "Sur":
                    FillCategory(PlateaSurGrid, seats);
                    break;
                case "Norte":
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

        private void SliderConfig()
        {
            FilledSeats.Minimum = 10;
            FilledSeats.Maximum = 15;
        }

        private void SeatClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name);
        }

        private void FilledSeats_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double distanceFromMin = (FilledSeats.Value - FilledSeats.Minimum);
            double sliderRange = (FilledSeats.Maximum - FilledSeats.Minimum);
            int sliderPercent = (int) (100 * (distanceFromMin / sliderRange));

            int seats = sliderPercent * 15 / 100;
            Console.WriteLine("Slider percentaje: " + seats);
        }
    }

}
