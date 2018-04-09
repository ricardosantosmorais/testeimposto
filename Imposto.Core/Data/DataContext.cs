using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("TesteImposto") {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<NotaFiscalItem> NotaFiscalItem { get; set; }
    }
}
