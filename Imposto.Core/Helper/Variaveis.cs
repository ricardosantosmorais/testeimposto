using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Helper
{
    public static class Variaveis
    {
        public static string XmlPath { get
            {
                return System.Configuration.ConfigurationManager.AppSettings["PathXml"];
            }
        }
    }
}
