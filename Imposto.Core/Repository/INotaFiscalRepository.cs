using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Repository
{
    public interface INotaFiscalRepository
    {
        void Adicionar(NotaFiscal n);
    }
}
