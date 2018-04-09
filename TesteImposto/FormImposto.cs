using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imposto.Core.Domain;
using Imposto.Core.Service.Interface;
using Imposto.Core.Helper;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        INotaFiscalService service;

        public FormImposto(INotaFiscalService service)
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;                       
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();

            comboBoxOrigem.DisplayMember = "Name";
            comboBoxOrigem.ValueMember = "Uf";
            comboBoxOrigem.DataSource = Estados.Lista;

            comboBoxDestino.DisplayMember = "Name";
            comboBoxDestino.ValueMember = "Uf";
            comboBoxDestino.DataSource = Estados.Lista;

            this.service = service;
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }   
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));
                     
            return table;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            if(!Valido())
            {
                MessageBox.Show("Por favor, preencha todas as informações.");
                return;
            }
            Pedido pedido = new Pedido();
            pedido.EstadoOrigem = ((Estados.Estado)comboBoxOrigem.SelectedItem).Uf;
            pedido.EstadoDestino = ((Estados.Estado)comboBoxDestino.SelectedItem).Uf;
            pedido.NomeCliente = textBoxNomeCliente.Text;

            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            foreach (DataRow row in table.Rows)
            {
                bool brinde;
                pedido.ItensDoPedido.Add(
                    new PedidoItem()
                    {
                        Brinde = Boolean.TryParse(row["Brinde"].ToString(), out brinde) ? Convert.ToBoolean(row["Brinde"]): false,
                        CodigoProduto =  row["Codigo do produto"].ToString(),
                        NomeProduto = row["Nome do produto"].ToString(),
                        ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())
                    });
            }

            service.Adicionar(pedido);
            MessageBox.Show("Operação efetuada com sucesso");
            LimparControles();
        }

        protected bool Valido()
        {
            var result = true;

            if(String.IsNullOrEmpty(textBoxNomeCliente.Text))
            {
                result = false;
            } else if(comboBoxOrigem.SelectedIndex == 0)
            {
                result = false;
            }
            else if (comboBoxDestino.SelectedIndex == 0)
            {
                result = false;
            } else if(dataGridViewPedidos.Rows.Count == 0)
            {
                result = false;
            }
            return result;
        }

        private void LimparControles()
        {
            textBoxNomeCliente.Text = String.Empty;
            comboBoxOrigem.SelectedIndex = 0;
            comboBoxDestino.SelectedIndex = 0;
            dataGridViewPedidos.Columns.Clear();
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }
    }
}
