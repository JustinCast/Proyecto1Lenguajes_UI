using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace Proyecto1Lenguajes_UI.usr.lib
{
    class Class1
    {
        [DllImport("main.dll", EntryPoint = "resolve_purchase_request")]
        static extern void resolve_purchase_request(string category, int tickets);
        public static void ConnectLib()
        {
            resolve_purchase_request("Platea", 10);
        }
    }
}
