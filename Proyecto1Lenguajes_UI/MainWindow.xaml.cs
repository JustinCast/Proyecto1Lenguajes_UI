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
            //ConnectLib();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]{1,9}$/");
            e.Handled = regex.IsMatch(e.Text);
        }

        /*[DllImport("main.dll", EntryPoint = "resolve_purchase_request")]
        static extern void resolve_purchase_request(string category, int tickets);
        public static void ConnectLib()
        {
            resolve_purchase_request("Platea", 10);
        }*/
    }

}
