using Imposto.Core.Data;
using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Repository
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        public void Adicionar(NotaFiscal n)
        {
            using(var context = new DataContext())
            {
                context.NotaFiscal.Add(n);
                context.SaveChanges();
            }
        }
    }
}
