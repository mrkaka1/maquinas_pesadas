using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinasPesadas.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btn_marcas_Click(object sender, EventArgs e)
        {
            new FormMarca().ShowDialog();
        }

        private void btn_categorias_Click(object sender, EventArgs e)
        {
            new FormCategoria().ShowDialog();
        }

        private void btn_fornecedores_Click(object sender, EventArgs e)
        {
            new FormFornecedor().ShowDialog();
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            new FormCliente().ShowDialog();
        }

        private void btn_funcionarios_Click(object sender, EventArgs e)
        {
            new FormFuncionario().ShowDialog();
        }

        private void btn_modelos_Click(object sender, EventArgs e)
        {
            new FormModelo().ShowDialog();
        }

        private void btn_pecas_Click(object sender, EventArgs e)
        {
            new FormPeca().ShowDialog();
        }

        private void btn_maquinas_Click(object sender, EventArgs e)
        {
            new FormMaquina().ShowDialog();
        }

        private void btn_compatibilidades_Click(object sender, EventArgs e)
        {
            new FormPecaModelo().ShowDialog();
        }

        private void btn_vendas_Click(object sender, EventArgs e)
        {
            new FormVenda().ShowDialog();
        }

        private void btn_ordens_Click(object sender, EventArgs e)
        {
            new FormOrdemServico().ShowDialog();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
