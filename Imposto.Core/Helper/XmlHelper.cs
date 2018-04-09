using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Imposto.Core.Helper
{
    public static class XmlHelper
    {
        public static void Criar(NotaFiscal notaFical)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NotaFiscal));

            bool folderExists = Directory.Exists(Variaveis.XmlPath);
            if (!folderExists)
                Directory.CreateDirectory(Variaveis.XmlPath);

            var fileName = Path.Combine(Variaveis.XmlPath, String.Format("{0}.xml", notaFical.Serie));
            serializer.Serialize(File.Create(fileName), notaFical);
        }
    }
}
