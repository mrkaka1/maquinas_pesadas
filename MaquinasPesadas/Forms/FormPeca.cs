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
    public partial class FormPeca : Form
    {
        PecaDAO pdao = new PecaDAO();
        List<Categoria> categorias = new List<Categoria>();
        List<Marca> marcas = new List<Marca>();
        List<Fornecedor> fornecedores = new List<Fornecedor>();

        public FormPeca()
        {
            InitializeComponent();
            chk_ativo.Checked = true;
            CarregaCombos();
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_categoria.SelectedIndex == -1 || cmb_marca.SelectedIndex == -1 || cmb_fornecedor.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a categoria, a marca e o fornecedor da peça!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Peca p = new Peca();
                p.CodigoFabricante = txt_codigoFabricante.Text;
                p.Descricao = txt_descricao.Text;
                p.PrecoCusto = Convert.ToDouble(txt_precoCusto.Text);
                p.PrecoVenda = Convert.ToDouble(txt_precoVenda.Text);
                p.Estoque = Convert.ToInt32(txt_estoque.Text);
                p.EstoqueMinimo = Convert.ToInt32(txt_estoqueMinimo.Text);
                p.Ativo = chk_ativo.Checked;
                p.Categoria = new Categoria() { CategoriaID = Convert.ToInt32(cmb_categoria.SelectedValue) };
                p.Marca = new Marca() { MarcaID = Convert.ToInt32(cmb_marca.SelectedValue) };
                p.Fornecedor = new Fornecedor() { FornecedorID = Convert.ToInt32(cmb_fornecedor.SelectedValue) };

                if (txt_id.Text == "")
                {
                    pdao.Insert(p);
                    MessageBox.Show("Peça Salva com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    p.PecaID = Convert.ToInt32(txt_id.Text);
                    pdao.Atualizar(p);
                    MessageBox.Show("Peça Atualizada com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                    MessageBox.Show("Selecione uma peça na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir esta peça?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Peça Excluída com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_pecas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_pecas.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["PecaID"].Value.ToString();
                txt_codigoFabricante.Text = linha.Cells["CodigoFabricante"].Value.ToString();
                txt_descricao.Text = linha.Cells["Descricao"].Value.ToString();
                txt_precoCusto.Text = linha.Cells["PrecoCusto"].Value.ToString();
                txt_precoVenda.Text = linha.Cells["PrecoVenda"].Value.ToString();
                txt_estoque.Text = linha.Cells["Estoque"].Value.ToString();
                txt_estoqueMinimo.Text = linha.Cells["EstoqueMinimo"].Value.ToString();
                chk_ativo.Checked = Convert.ToBoolean(linha.Cells["Ativo"].Value);
                cmb_categoria.SelectedValue = Convert.ToInt32(linha.Cells["CategoriaID"].Value);
                cmb_marca.SelectedValue = Convert.ToInt32(linha.Cells["MarcaID"].Value);
                cmb_fornecedor.SelectedValue = Convert.ToInt32(linha.Cells["FornecedorID"].Value);
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_codigoFabricante.Clear();
            txt_descricao.Clear();
            txt_precoCusto.Clear();
            txt_precoVenda.Clear();
            txt_estoque.Clear();
            txt_estoqueMinimo.Clear();
            chk_ativo.Checked = true;
            cmb_categoria.SelectedIndex = -1;
            cmb_marca.SelectedIndex = -1;
            cmb_fornecedor.SelectedIndex = -1;
        }

        public void CarregaCombos()
        {
            categorias = new CategoriaDAO().GetAll();
            cmb_categoria.DisplayMember = "Descricao";
            cmb_categoria.ValueMember = "CategoriaID";
            cmb_categoria.DataSource = categorias;
            cmb_categoria.SelectedIndex = -1;

            marcas = new MarcaDAO().GetAll();
            cmb_marca.DisplayMember = "Nome";
            cmb_marca.ValueMember = "MarcaID";
            cmb_marca.DataSource = marcas;
            cmb_marca.SelectedIndex = -1;

            fornecedores = new FornecedorDAO().GetAll();
            cmb_fornecedor.DisplayMember = "Razao";
            cmb_fornecedor.ValueMember = "FornecedorID";
            cmb_fornecedor.DataSource = fornecedores;
            cmb_fornecedor.SelectedIndex = -1;
        }

        public void AtualizaList()
        {
            dgv_pecas.DataSource = pdao.GetAll().Select(p => new
            {
                p.PecaID,
                p.CodigoFabricante,
                p.Descricao,
                p.PrecoCusto,
                p.PrecoVenda,
                p.Estoque,
                p.EstoqueMinimo,
                p.Ativo,
                CategoriaID = p.Categoria.CategoriaID,
                Categoria = categorias.Find(x => x.CategoriaID == p.Categoria.CategoriaID).Descricao,
                MarcaID = p.Marca.MarcaID,
                Marca = marcas.Find(x => x.MarcaID == p.Marca.MarcaID).Nome,
                FornecedorID = p.Fornecedor.FornecedorID,
                Fornecedor = fornecedores.Find(x => x.FornecedorID == p.Fornecedor.FornecedorID).Razao
            }).ToList();
        }
    }
}
