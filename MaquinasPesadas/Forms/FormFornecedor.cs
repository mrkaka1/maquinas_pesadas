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
    public partial class FormFornecedor : Form
    {
        FornecedorDAO fdao = new FornecedorDAO();

        public FormFornecedor()
        {
            InitializeComponent();
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor f = new Fornecedor();
                f.Razao = txt_razaoSocial.Text;
                f.CNPJ = txt_cnpj.Text;
                f.Telefone = txt_telefone.Text;
                f.Email = txt_email.Text;
                f.Cidade = txt_cidade.Text;
                f.UF = txt_uf.Text;

                if (txt_id.Text == "")
                {
                    fdao.Insert(f);
                    MessageBox.Show("Fornecedor Salvo com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    f.FornecedorID = Convert.ToInt32(txt_id.Text);
                    fdao.Atualizar(f);
                    MessageBox.Show("Fornecedor Atualizado com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione um fornecedor na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir este fornecedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Fornecedor Excluído com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_fornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_fornecedores.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["FornecedorID"].Value.ToString();
                txt_razaoSocial.Text = linha.Cells["Razao"].Value.ToString();
                txt_cnpj.Text = linha.Cells["CNPJ"].Value.ToString();
                txt_telefone.Text = linha.Cells["Telefone"].Value.ToString();
                txt_email.Text = linha.Cells["Email"].Value.ToString();
                txt_cidade.Text = linha.Cells["Cidade"].Value.ToString();
                txt_uf.Text = Convert.ToString(linha.Cells["UF"].Value);
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_razaoSocial.Clear();
            txt_cnpj.Clear();
            txt_telefone.Clear();
            txt_email.Clear();
            txt_cidade.Clear();
            txt_uf.Clear();
        }

        public void AtualizaList()
        {
            dgv_fornecedores.DataSource = fdao.GetAll();
        }
    }
}
