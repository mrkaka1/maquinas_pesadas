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
    public partial class FormPecaModelo : Form
    {
        PecaModeloDAO pmdao = new PecaModeloDAO();
        List<Peca> pecas = new List<Peca>();
        List<Modelo> modelos = new List<Modelo>();

        public FormPecaModelo()
        {
            InitializeComponent();
            CarregaCombos();
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_peca.SelectedIndex == -1 || cmb_modelo.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a peça e o modelo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PecaModelo pm = new PecaModelo();
                pm.Peca = new Peca() { PecaID = Convert.ToInt32(cmb_peca.SelectedValue) };
                pm.Modelo = new Modelo() { ModeloID = Convert.ToInt32(cmb_modelo.SelectedValue) };

                if (txt_id.Text == "")
                {
                    pmdao.Insert(pm);
                    MessageBox.Show("Compatibilidade Salva com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    pm.PecaModeloID = Convert.ToInt32(txt_id.Text);
                    pmdao.Atualizar(pm);
                    MessageBox.Show("Compatibilidade Atualizada com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione uma compatibilidade na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir esta compatibilidade?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pmdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Compatibilidade Excluída com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_compatibilidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_compatibilidades.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["PecaModeloID"].Value.ToString();
                cmb_peca.SelectedValue = Convert.ToInt32(linha.Cells["PecaID"].Value);
                cmb_modelo.SelectedValue = Convert.ToInt32(linha.Cells["ModeloID"].Value);
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            cmb_peca.SelectedIndex = -1;
            cmb_modelo.SelectedIndex = -1;
        }

        public void CarregaCombos()
        {
            pecas = new PecaDAO().GetAll();
            cmb_peca.DisplayMember = "Descricao";
            cmb_peca.ValueMember = "PecaID";
            cmb_peca.DataSource = pecas;
            cmb_peca.SelectedIndex = -1;

            modelos = new ModeloDAO().GetAll();
            cmb_modelo.DisplayMember = "Nome";
            cmb_modelo.ValueMember = "ModeloID";
            cmb_modelo.DataSource = modelos;
            cmb_modelo.SelectedIndex = -1;
        }

        public void AtualizaList()
        {
            dgv_compatibilidades.DataSource = pmdao.GetAll().Select(pm => new
            {
                pm.PecaModeloID,
                PecaID = pm.Peca.PecaID,
                Peca = pecas.Find(x => x.PecaID == pm.Peca.PecaID).Descricao,
                ModeloID = pm.Modelo.ModeloID,
                Modelo = modelos.Find(x => x.ModeloID == pm.Modelo.ModeloID).Nome
            }).ToList();
        }
    }
}
