using Imposto.Core.Domain;
using Imposto.Core.Helper;
using Imposto.Core.Repository;
using Imposto.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository repository;

        public NotaFiscalService()
        {
            repository = new NotaFiscalRepository();
        }

        public void Adicionar(Pedido pedido)
        {
            try
            {
                NotaFiscal obj = new NotaFiscal();
                obj.NumeroNotaFiscal = 99999;
                obj.Serie = new Random().Next(Int32.MaxValue);
                obj.NomeCliente = pedido.NomeCliente;

                obj.EstadoOrigem = pedido.EstadoOrigem;
                obj.EstadoDestino = pedido.EstadoDestino;

                foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
                {
                    NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
                    notaFiscalItem.Cfop = "N/D";

                    if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "RJ"))
                    {
                        notaFiscalItem.Cfop = "6.000";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "PE"))
                    {
                        notaFiscalItem.Cfop = "6.001";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "MG"))
                    {
                        notaFiscalItem.Cfop = "6.002";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "PB"))
                    {
                        notaFiscalItem.Cfop = "6.003";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "PR"))
                    {
                        notaFiscalItem.Cfop = "6.004";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "PI"))
                    {
                        notaFiscalItem.Cfop = "6.005";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "RO"))
                    {
                        notaFiscalItem.Cfop = "6.006";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.007";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "TO"))
                    {
                        notaFiscalItem.Cfop = "6.008";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.009";
                    }
                    else if ((obj.EstadoOrigem == "SP") && (obj.EstadoDestino == "PA"))
                    {
                        notaFiscalItem.Cfop = "6.010";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "RJ"))
                    {
                        notaFiscalItem.Cfop = "6.000";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "PE"))
                    {
                        notaFiscalItem.Cfop = "6.001";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "MG"))
                    {
                        notaFiscalItem.Cfop = "6.002";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "PB"))
                    {
                        notaFiscalItem.Cfop = "6.003";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "PR"))
                    {
                        notaFiscalItem.Cfop = "6.004";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "PI"))
                    {
                        notaFiscalItem.Cfop = "6.005";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "RO"))
                    {
                        notaFiscalItem.Cfop = "6.006";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.007";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "TO"))
                    {
                        notaFiscalItem.Cfop = "6.008";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "SE"))
                    {
                        notaFiscalItem.Cfop = "6.009";
                    }
                    else if ((obj.EstadoOrigem == "MG") && (obj.EstadoDestino == "PA"))
                    {
                        notaFiscalItem.Cfop = "6.010";
                    }
                    if (obj.EstadoDestino == obj.EstadoOrigem)
                    {
                        notaFiscalItem.TipoIcms = "60";
                        notaFiscalItem.AliquotaIcms = 0.18;
                    }
                    else
                    {
                        notaFiscalItem.TipoIcms = "10";
                        notaFiscalItem.AliquotaIcms = 0.17;
                    }
                    if (notaFiscalItem.Cfop == "6.009")
                    {
                        notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; //redução de base
                    }
                    else
                    {
                        notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                    }
                    notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                    if (itemPedido.Brinde)
                    {
                        notaFiscalItem.TipoIcms = "60";
                        notaFiscalItem.AliquotaIcms = 0.18;
                        notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
                    } else
                    {
                        notaFiscalItem.AliquotaIpi = 0.1;
                    }

                    //Novos cálculos IPI
                    notaFiscalItem.BaseIpi = itemPedido.ValorItemPedido;
                    notaFiscalItem.ValorIpi = notaFiscalItem.BaseIpi * notaFiscalItem.AliquotaIpi;

                    //Calculando desconto
                    if(obj.EstadoDestino == "SP" || obj.EstadoDestino == "RJ" || obj.EstadoDestino == "ES" || obj.EstadoDestino == "MG")
                    {
                        notaFiscalItem.BaseDesconto = itemPedido.ValorItemPedido * 0.1;
                    } else
                    {
                        notaFiscalItem.BaseDesconto = 0;
                    }

                    notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                    notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;
                    obj.ItensDaNotaFiscal.Add(notaFiscalItem);
                }

                XmlHelper.Criar(obj);
                repository.Adicionar(obj);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
