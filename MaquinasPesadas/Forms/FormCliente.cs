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
    public partial class FormCliente : Form
    {
        ClienteDAO cdao = new ClienteDAO();

        public FormCliente()
        {
            InitializeComponent();
            cmb_tipoPessoa.Items.Add("F");
            cmb_tipoPessoa.Items.Add("J");
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                c.Nome = txt_nome.Text;
                c.CpfCnpj = txt_cpfCnpj.Text;
                c.TipoPessoa = cmb_tipoPessoa.Text;
                c.Telefone = txt_telefone.Text;
                c.Email = txt_email.Text;
                c.Cidade = txt_cidade.Text;
                c.UF = txt_uf.Text;
                c.DataCadastro = DateOnly.FromDateTime(dtp_dataCadastro.Value);

                if (txt_id.Text == "")
                {
                    cdao.Insert(c);
                    MessageBox.Show("Cliente Salvo com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    c.ClienteID = Convert.ToInt32(txt_id.Text);
                    cdao.Atualizar(c);
                    MessageBox.Show("Cliente Atualizado com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione um cliente na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Cliente Excluído com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_clientes.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["ClienteID"].Value.ToString();
                txt_nome.Text = linha.Cells["Nome"].Value.ToString();
                txt_cpfCnpj.Text = linha.Cells["CpfCnpj"].Value.ToString();
                cmb_tipoPessoa.Text = linha.Cells["TipoPessoa"].Value.ToString();
                txt_telefone.Text = linha.Cells["Telefone"].Value.ToString();
                txt_email.Text = linha.Cells["Email"].Value.ToString();
                txt_cidade.Text = linha.Cells["Cidade"].Value.ToString();
                txt_uf.Text = Convert.ToString(linha.Cells["UF"].Value);
                DateOnly data = (DateOnly)linha.Cells["DataCadastro"].Value;
                dtp_dataCadastro.Value = data.ToDateTime(TimeOnly.MinValue);
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_nome.Clear();
            txt_cpfCnpj.Clear();
            cmb_tipoPessoa.SelectedIndex = -1;
            txt_telefone.Clear();
            txt_email.Clear();
            txt_cidade.Clear();
            txt_uf.Clear();
            dtp_dataCadastro.Value = DateTime.Now;
        }

        public void AtualizaList()
        {
            dgv_clientes.DataSource = cdao.GetAll();
        }
    }
}
