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
    public partial class FormCategoria : Form
    {
        CategoriaDAO cdao = new CategoriaDAO();

        public FormCategoria()
        {
            InitializeComponent();
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria c = new Categoria();
                c.Descricao = txt_descricao.Text;

                if (txt_id.Text == "")
                {
                    cdao.Insert(c);
                    MessageBox.Show("Categoria Salva com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    c.CategoriaID = Convert.ToInt32(txt_id.Text);
                    cdao.Atualizar(c);
                    MessageBox.Show("Categoria Atualizada com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione uma categoria na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir esta categoria?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Categoria Excluída com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_categorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_categorias.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["CategoriaID"].Value.ToString();
                txt_descricao.Text = linha.Cells["Descricao"].Value.ToString();
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_descricao.Clear();
        }

        public void AtualizaList()
        {
            dgv_categorias.DataSource = cdao.GetAll();
        }
    }
}
