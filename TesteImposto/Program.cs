using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace TesteImposto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UnityConfig.RegisterTypes(UnityConfig.Container);

            NotaFiscalService service = new NotaFiscalService();
            var form = new FormImposto(service);
            Application.Run(form);
        }
    }
}
