using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Helper
{
    public static class Estados
    {
        public static List<Estado> Lista
        {
            get
            {
                var lista = new List<Estado>();
                lista.Add(new Estado { Uf = "", Name = "Selecione" });
                lista.Add(new Estado { Uf = "AC", Name = "Acre" });
                lista.Add(new Estado { Uf = "AL", Name = "Alagoas" });
                lista.Add(new Estado { Uf = "AP", Name = "Amapá" });
                lista.Add(new Estado { Uf = "AM", Name = "Amazonas" });
                lista.Add(new Estado { Uf = "BA", Name = "Bahia" });
                lista.Add(new Estado { Uf = "CE", Name = "Ceará" });
                lista.Add(new Estado { Uf = "DF", Name = "Distrito Federal" });
                lista.Add(new Estado { Uf = "ES", Name = "Espírito Santo" });
                lista.Add(new Estado { Uf = "GO", Name = "Goiás" });
                lista.Add(new Estado { Uf = "MA", Name = "Maranhão" });
                lista.Add(new Estado { Uf = "MT", Name = "Mato Grosso" });
                lista.Add(new Estado { Uf = "MS", Name = "Mato Grosso do Sul" });
                lista.Add(new Estado { Uf = "MG", Name = "Minas Gerais" });
                lista.Add(new Estado { Uf = "PA", Name = "Pará" });
                lista.Add(new Estado { Uf = "PB", Name = "Paraíba" });
                lista.Add(new Estado { Uf = "PR", Name = "Paraná" });
                lista.Add(new Estado { Uf = "PE", Name = "Pernambuco" });
                lista.Add(new Estado { Uf = "PI", Name = "Piauí" });
                lista.Add(new Estado { Uf = "RJ", Name = "Rio de Janeiro" });
                lista.Add(new Estado { Uf = "RN", Name = "Rio Grande do Norte" });
                lista.Add(new Estado { Uf = "RS", Name = "Rio Grande do Sul" });
                lista.Add(new Estado { Uf = "RO", Name = "Rondônia" });
                lista.Add(new Estado { Uf = "RR", Name = "Roraima" });
                lista.Add(new Estado { Uf = "SC", Name = "Santa Catarina" });
                lista.Add(new Estado { Uf = "SP", Name = "São Paulo" });
                lista.Add(new Estado { Uf = "SE", Name = "Sergipe" });
                lista.Add(new Estado { Uf = "TO", Name = "Tocantins" });
                return lista;
            }
        }
        public class Estado
        {
            public string Uf { get; set; }
            public string Name { get; set; }
        }
    }
}
