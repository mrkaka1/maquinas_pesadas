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
    public partial class FormMaquina : Form
    {
        MaquinaDAO mdao = new MaquinaDAO();
        List<Cliente> clientes = new List<Cliente>();
        List<Modelo> modelos = new List<Modelo>();

        public FormMaquina()
        {
            InitializeComponent();
            CarregaCombos();
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_cliente.SelectedIndex == -1 || cmb_modelo.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o cliente e o modelo da máquina!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Maquina m = new Maquina();
                m.NumeroSerie = txt_numeroSerie.Text;
                m.AnoFabricacao = Convert.ToInt32(txt_anoFabricacao.Text);
                m.Horimetro = Convert.ToInt32(txt_horimetro.Text);
                m.Cliente = new Cliente() { ClienteID = Convert.ToInt32(cmb_cliente.SelectedValue) };
                m.Modelo = new Modelo() { ModeloID = Convert.ToInt32(cmb_modelo.SelectedValue) };

                if (txt_id.Text == "")
                {
                    mdao.Insert(m);
                    MessageBox.Show("Máquina Salva com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    m.MaquinaID = Convert.ToInt32(txt_id.Text);
                    mdao.Atualizar(m);
                    MessageBox.Show("Máquina Atualizada com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione uma máquina na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir esta máquina?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Máquina Excluída com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_maquinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_maquinas.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["MaquinaID"].Value.ToString();
                txt_numeroSerie.Text = linha.Cells["NumeroSerie"].Value.ToString();
                txt_anoFabricacao.Text = linha.Cells["AnoFabricacao"].Value.ToString();
                txt_horimetro.Text = linha.Cells["Horimetro"].Value.ToString();
                cmb_cliente.SelectedValue = Convert.ToInt32(linha.Cells["ClienteID"].Value);
                cmb_modelo.SelectedValue = Convert.ToInt32(linha.Cells["ModeloID"].Value);
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_numeroSerie.Clear();
            txt_anoFabricacao.Clear();
            txt_horimetro.Clear();
            cmb_cliente.SelectedIndex = -1;
            cmb_modelo.SelectedIndex = -1;
        }

        public void CarregaCombos()
        {
            clientes = new ClienteDAO().GetAll();
            cmb_cliente.DisplayMember = "Nome";
            cmb_cliente.ValueMember = "ClienteID";
            cmb_cliente.DataSource = clientes;
            cmb_cliente.SelectedIndex = -1;

            modelos = new ModeloDAO().GetAll();
            cmb_modelo.DisplayMember = "Nome";
            cmb_modelo.ValueMember = "ModeloID";
            cmb_modelo.DataSource = modelos;
            cmb_modelo.SelectedIndex = -1;
        }

        public void AtualizaList()
        {
            dgv_maquinas.DataSource = mdao.GetAll().Select(m => new
            {
                m.MaquinaID,
                m.NumeroSerie,
                m.AnoFabricacao,
                m.Horimetro,
                ClienteID = m.Cliente.ClienteID,
                Cliente = clientes.Find(x => x.ClienteID == m.Cliente.ClienteID).Nome,
                ModeloID = m.Modelo.ModeloID,
                Modelo = modelos.Find(x => x.ModeloID == m.Modelo.ModeloID).Nome
            }).ToList();
        }
    }
}
