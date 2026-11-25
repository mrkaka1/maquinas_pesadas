using MaquinasPesadas.DAO;
using MaquinasPesadas.Models;
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
    public partial class FormVenda : Form
    {
        VendaDAO vdao = new VendaDAO();
        ItemVendaDAO idao = new ItemVendaDAO();
        List<Cliente> clientes = new List<Cliente>();
        List<Funcionario> vendedores = new List<Funcionario>();
        List<Peca> pecas = new List<Peca>();
        List<ItemVenda> itensVenda = new List<ItemVenda>();
        List<ItemVenda> itensOriginais = new List<ItemVenda>();

        public FormVenda()
        {
            InitializeComponent();
            cmb_formaPagamento.Items.Add("Dinheiro");
            cmb_formaPagamento.Items.Add("Pix");
            cmb_formaPagamento.Items.Add("Cartão de débito");
            cmb_formaPagamento.Items.Add("Cartão de crédito");
            cmb_formaPagamento.Items.Add("Boleto");
            cmb_situacao.Items.Add("Aberta");
            cmb_situacao.Items.Add("Faturada");
            cmb_situacao.Items.Add("Cancelada");
            cmb_situacao.Text = "Aberta";
            CarregaCombos();
            txt_precoUnitario.Clear();
            AtualizaList();
            AtualizaItens();
        }

        private void btn_adicionarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_peca.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a peça!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ItemVenda item = new ItemVenda();
                item.Peca = (Peca)cmb_peca.SelectedItem;
                item.Quantidade = Convert.ToInt32(txt_quantidade.Text);
                item.PrecoUnitario = Convert.ToDouble(txt_precoUnitario.Text);
                itensVenda.Add(item);

                cmb_peca.SelectedIndex = -1;
                txt_quantidade.Clear();
                txt_precoUnitario.Clear();
                AtualizaItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_removerItem_Click(object sender, EventArgs e)
        {
            if (dgv_itens.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item da lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            itensVenda.RemoveAt(dgv_itens.CurrentRow.Index);
            AtualizaItens();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_cliente.SelectedIndex == -1 || cmb_vendedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o cliente e o vendedor!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (itensVenda.Count == 0)
                {
                    MessageBox.Show("Adicione pelo menos um item na venda!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Venda v = new Venda();
                v.DataHoraVenda = dtp_dataHora.Value;
                v.FormaPagamento = cmb_formaPagamento.Text;
                v.Situacao = cmb_situacao.Text;
                v.Desconto = LerDesconto();
                v.Cliente = new Cliente() { ClienteID = Convert.ToInt32(cmb_cliente.SelectedValue) };
                v.Funcionario = new Funcionario() { FuncionarioID = Convert.ToInt32(cmb_vendedor.SelectedValue) };

                if (txt_id.Text == "")
                {
                    vdao.Insert(v);
                    v.VendaID = vdao.GetAll().Max(x => x.VendaID);
                }
                else
                {
                    v.VendaID = Convert.ToInt32(txt_id.Text);
                    vdao.Atualizar(v);

                    foreach (ItemVenda original in itensOriginais)
                    {
                        if (!itensVenda.Contains(original))
                            idao.Deletar(original.ItemVendaID);
                    }
                }

                foreach (ItemVenda item in itensVenda)
                {
                    if (item.ItemVendaID == 0)
                    {
                        item.Venda = v;
                        idao.Insert(item);
                    }
                }

                MessageBox.Show("Venda Salva com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                AtualizaList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id.Text == "")
                {
                    MessageBox.Show("Selecione uma venda na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir esta venda e todos os seus itens?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ItemVenda original in itensOriginais)
                    {
                        idao.Deletar(original.ItemVendaID);
                    }
                    vdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Venda Excluída com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    AtualizaList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_peca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_peca.SelectedIndex >= 0)
            {
                Peca p = (Peca)cmb_peca.SelectedItem;
                txt_precoUnitario.Text = p.PrecoVenda.ToString();
            }
        }

        private void txt_desconto_TextChanged(object sender, EventArgs e)
        {
            AtualizaItens();
        }

        private void dgv_vendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow linha = dgv_vendas.Rows[e.RowIndex];
                    txt_id.Text = linha.Cells["VendaID"].Value.ToString();
                    dtp_dataHora.Value = Convert.ToDateTime(linha.Cells["DataHoraVenda"].Value);
                    cmb_cliente.SelectedValue = Convert.ToInt32(linha.Cells["ClienteID"].Value);
                    cmb_vendedor.SelectedValue = Convert.ToInt32(linha.Cells["VendedorID"].Value);
                    cmb_formaPagamento.Text = linha.Cells["FormaPagamento"].Value.ToString();
                    cmb_situacao.Text = linha.Cells["Situacao"].Value.ToString();
                    txt_desconto.Text = linha.Cells["Desconto"].Value.ToString();

                    int vendaID = Convert.ToInt32(txt_id.Text);
                    itensVenda = idao.GetAll().FindAll(i => i.Venda.VendaID == vendaID);
                    foreach (ItemVenda item in itensVenda)
                    {
                        item.Peca = pecas.Find(x => x.PecaID == item.Peca.PecaID);
                    }
                    itensOriginais = new List<ItemVenda>(itensVenda);
                    AtualizaItens();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public double LerDesconto()
        {
            if (txt_desconto.Text == "")
                return 0;
            return Convert.ToDouble(txt_desconto.Text);
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            dtp_dataHora.Value = DateTime.Now;
            cmb_cliente.SelectedIndex = -1;
            cmb_vendedor.SelectedIndex = -1;
            cmb_formaPagamento.SelectedIndex = -1;
            cmb_situacao.Text = "Aberta";
            txt_desconto.Clear();
            cmb_peca.SelectedIndex = -1;
            txt_quantidade.Clear();
            txt_precoUnitario.Clear();
            itensVenda = new List<ItemVenda>();
            itensOriginais = new List<ItemVenda>();
            AtualizaItens();
        }

        public void CarregaCombos()
        {
            clientes = new ClienteDAO().GetAll();
            cmb_cliente.DisplayMember = "Nome";
            cmb_cliente.ValueMember = "ClienteID";
            cmb_cliente.DataSource = clientes;
            cmb_cliente.SelectedIndex = -1;

            vendedores = new FuncionarioDAO().GetAll().FindAll(f => f.Cargo == "Vendedor");
            cmb_vendedor.DisplayMember = "Nome";
            cmb_vendedor.ValueMember = "FuncionarioID";
            cmb_vendedor.DataSource = vendedores;
            cmb_vendedor.SelectedIndex = -1;

            pecas = new PecaDAO().GetAll();
            cmb_peca.DisplayMember = "Descricao";
            cmb_peca.ValueMember = "PecaID";
            cmb_peca.DataSource = pecas;
            cmb_peca.SelectedIndex = -1;
        }

        public void AtualizaItens()
        {
            dgv_itens.DataSource = itensVenda.Select(i => new
            {
                Peca = i.Peca.Descricao,
                i.Quantidade,
                i.PrecoUnitario,
                Subtotal = i.Quantidade * i.PrecoUnitario
            }).ToList();

            try
            {
                Venda v = new Venda();
                v.Desconto = LerDesconto();
                v.Itens.AddRange(itensVenda);
                lbl_total.Text = "Total da venda: " + v.CalcularValorTotal().ToString("C");
            }
            catch (Exception)
            {
                lbl_total.Text = "Total da venda: desconto inválido";
            }
        }

        public void AtualizaList()
        {
            List<Venda> vendas = vdao.GetAll();
            List<ItemVenda> todosItens = idao.GetAll();

            foreach (Venda v in vendas)
            {
                v.Itens.AddRange(todosItens.FindAll(i => i.Venda.VendaID == v.VendaID));
            }

            dgv_vendas.DataSource = vendas.Select(v => new
            {
                v.VendaID,
                v.DataHoraVenda,
                ClienteID = v.Cliente.ClienteID,
                Cliente = clientes.Find(x => x.ClienteID == v.Cliente.ClienteID).Nome,
                VendedorID = v.Funcionario.FuncionarioID,
                Vendedor = vendedores.Find(x => x.FuncionarioID == v.Funcionario.FuncionarioID).Nome,
                v.FormaPagamento,
                v.Situacao,
                v.Desconto,
                Total = v.CalcularValorTotal()
            }).ToList();
        }
    }
}
