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
            //Class1.ConnectLib();
            ConnectLib();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]{1,9}$/");
            e.Handled = regex.IsMatch(e.Text);
        }

        [DllImport(
            "C:\\Users\\Justin\\Documents\\Visual Studio 2017\\Projects\\DllTranslator\\Debug\\DllTranslator.dll",
            CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "resolve_purchase_request")]
        static extern string resolve_purchase_request(string category, int tickets, int flag);
        public static void ConnectLib()
        {
            Console.WriteLine(resolve_purchase_request("Platea", 10, 0));
        }

        private void PurchaseClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Click");
        }
        private void SeatClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Console.WriteLine(button.Name);
        }
    }

}
