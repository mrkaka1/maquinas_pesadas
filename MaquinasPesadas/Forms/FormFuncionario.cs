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
    public partial class FormFuncionario : Form
    {
        FuncionarioDAO fdao = new FuncionarioDAO();

        public FormFuncionario()
        {
            InitializeComponent();
            cmb_cargo.Items.Add("Vendedor");
            cmb_cargo.Items.Add("Mecânico");
            cmb_cargo.Items.Add("Estoquista");
            cmb_cargo.Items.Add("Caixa");
            cmb_cargo.Items.Add("Gerente");
            chk_ativo.Checked = true;
            AtualizaList();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario f = new Funcionario();
                f.Matricula = Convert.ToInt32(txt_matricula.Text);
                f.Nome = txt_nome.Text;
                f.Cpf = txt_cpf.Text;
                f.Cargo = cmb_cargo.Text;
                f.DataAdmissao = DateOnly.FromDateTime(dtp_dataAdmissao.Value);
                f.Email = txt_email.Text;
                f.Ativo = chk_ativo.Checked;

                if (txt_id.Text == "")
                {
                    fdao.Insert(f);
                    MessageBox.Show("Funcionário Salvo com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    f.FuncionarioID = Convert.ToInt32(txt_id.Text);
                    fdao.Atualizar(f);
                    MessageBox.Show("Funcionário Atualizado com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione um funcionário na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir este funcionário?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Funcionário Excluído com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_funcionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha = dgv_funcionarios.Rows[e.RowIndex];
                txt_id.Text = linha.Cells["FuncionarioID"].Value.ToString();
                txt_matricula.Text = linha.Cells["Matricula"].Value.ToString();
                txt_nome.Text = linha.Cells["Nome"].Value.ToString();
                txt_cpf.Text = linha.Cells["Cpf"].Value.ToString();
                cmb_cargo.Text = linha.Cells["Cargo"].Value.ToString();
                DateOnly data = (DateOnly)linha.Cells["DataAdmissao"].Value;
                dtp_dataAdmissao.Value = data.ToDateTime(TimeOnly.MinValue);
                txt_email.Text = linha.Cells["Email"].Value.ToString();
                chk_ativo.Checked = Convert.ToBoolean(linha.Cells["Ativo"].Value);
            }
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            txt_matricula.Clear();
            txt_nome.Clear();
            txt_cpf.Clear();
            cmb_cargo.SelectedIndex = -1;
            dtp_dataAdmissao.Value = DateTime.Now;
            txt_email.Clear();
            chk_ativo.Checked = true;
        }

        public void AtualizaList()
        {
            dgv_funcionarios.DataSource = fdao.GetAll();
        }
    }
}
