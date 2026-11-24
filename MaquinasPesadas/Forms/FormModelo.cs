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
    public partial class FormModelo : Form
    {
        ModeloDAO mdao = new ModeloDAO();
        List<Marca> marcas = new List<Marca>();

        public FormModelo()
        {
            InitializeComponent();
            cmb_tipo.Items.Add("Trator de esteira");
            cmb_tipo.Items.Add("Escavadeira");
            cmb_tipo.Items.Add("Pá carregadeira");
            cmb_tipo.Items.Add("Retroescavadeira");
            cmb_tipo.Items.Add("Motoniveladora");
            cmb_tipo.Items.Add("Trator agrícola");
            cmb_tipo.Items.Add("Rolo compactador");
            CarregaMarcas();
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_marca.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a marca do modelo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Modelo mo = new Modelo();
                mo.Nome = txt_nome.Text;
                mo.Tipo = cmb_tipo.Text;
                mo.PotenciaCV = Convert.ToInt32(txt_potenciaCV.Text);
                mo.Marca = new Marca() { MarcaID = Convert.ToInt32(cmb_marca.SelectedValue) };

                if (txt_id.Text == "")
                {
                    mdao.Insert(mo);
                    MessageBox.Show("Modelo Salvo com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    mo.ModeloID = Convert.ToInt32(txt_id.Text);
                    mdao.Atualizar(mo);
                    MessageBox.Show("Modelo Atualizado com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione um modelo na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir este modelo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Modelo Excluído com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_modelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_modelos.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["ModeloID"].Value.ToString();
                txt_nome.Text = linha.Cells["Nome"].Value.ToString();
                cmb_tipo.Text = linha.Cells["Tipo"].Value.ToString();
                txt_potenciaCV.Text = linha.Cells["PotenciaCV"].Value.ToString();
                cmb_marca.SelectedValue = Convert.ToInt32(linha.Cells["MarcaID"].Value);
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_nome.Clear();
            cmb_tipo.SelectedIndex = -1;
            txt_potenciaCV.Clear();
            cmb_marca.SelectedIndex = -1;
        }

        public void CarregaMarcas()
        {
            marcas = new MarcaDAO().GetAll();
            cmb_marca.DisplayMember = "Nome";
            cmb_marca.ValueMember = "MarcaID";
            cmb_marca.DataSource = marcas;
            cmb_marca.SelectedIndex = -1;
        }

        public void AtualizaList()
        {
            dgv_modelos.DataSource = mdao.GetAll().Select(mo => new
            {
                mo.ModeloID,
                mo.Nome,
                mo.Tipo,
                mo.PotenciaCV,
                MarcaID = mo.Marca.MarcaID,
                Marca = marcas.Find(x => x.MarcaID == mo.Marca.MarcaID).Nome
            }).ToList();
        }
    }
}
