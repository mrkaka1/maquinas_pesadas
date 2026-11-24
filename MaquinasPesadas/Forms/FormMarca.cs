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
    public partial class FormMarca : Form
    {
        MarcaDAO mdao = new MarcaDAO();

        public FormMarca()
        {
            InitializeComponent();
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Marca m = new Marca();
                m.Nome = txt_nome.Text;
                m.PaisOrigem = txt_paisOrigem.Text;

                if (txt_id.Text == "")
                {
                    mdao.Insert(m);
                    MessageBox.Show("Marca Salva com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    m.MarcaID = Convert.ToInt32(txt_id.Text);
                    mdao.Atualizar(m);
                    MessageBox.Show("Marca Atualizada com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione uma marca na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir esta marca?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Marca Excluída com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_marcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_marcas.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["MarcaID"].Value.ToString();
                txt_nome.Text = linha.Cells["Nome"].Value.ToString();
                txt_paisOrigem.Text = linha.Cells["PaisOrigem"].Value.ToString();
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_nome.Clear();
            txt_paisOrigem.Clear();
        }

        public void AtualizaList()
        {
            dgv_marcas.DataSource = mdao.GetAll();
        }
    }
}
