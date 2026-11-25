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
    public partial class FormOrdemServico : Form
    {
        OrdemServicoDAO osdao = new OrdemServicoDAO();
        PecaOSDAO podao = new PecaOSDAO();
        List<Maquina> maquinas = new List<Maquina>();
        List<Funcionario> mecanicos = new List<Funcionario>();
        List<Peca> pecas = new List<Peca>();
        List<OrdemServico> ordens = new List<OrdemServico>();
        List<PecaOS> pecasOS = new List<PecaOS>();
        List<PecaOS> pecasOriginais = new List<PecaOS>();

        public FormOrdemServico()
        {
            InitializeComponent();
            cmb_situacao.Items.Add("Aberta");
            cmb_situacao.Items.Add("Em execução");
            cmb_situacao.Items.Add("Aguardando peça");
            cmb_situacao.Items.Add("Concluída");
            cmb_situacao.Items.Add("Cancelada");
            cmb_situacao.Text = "Aberta";
            dtp_dataFechamento.Checked = false;
            CarregaCombos();
            txt_precoUnitario.Clear();
            AtualizaList();
            AtualizaPecas();
        }

        private void btn_adicionarPeca_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_peca.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a peça!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PecaOS item = new PecaOS();
                item.Peca = (Peca)cmb_peca.SelectedItem;
                item.Quantidade = Convert.ToInt32(txt_quantidade.Text);
                item.PrecoUnitario = Convert.ToDouble(txt_precoUnitario.Text);
                pecasOS.Add(item);

                cmb_peca.SelectedIndex = -1;
                txt_quantidade.Clear();
                txt_precoUnitario.Clear();
                AtualizaPecas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_removerPeca_Click(object sender, EventArgs e)
        {
            if (dgv_pecas.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma peça da lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pecasOS.RemoveAt(dgv_pecas.CurrentRow.Index);
            AtualizaPecas();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_maquina.SelectedIndex == -1 || cmb_mecanico.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione a máquina e o mecânico!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OrdemServico os = new OrdemServico();
                os.DataAbertura = DateOnly.FromDateTime(dtp_dataAbertura.Value);
                if (dtp_dataFechamento.Checked)
                    os.DataFechamento = DateOnly.FromDateTime(dtp_dataFechamento.Value);
                os.DescricaoProblema = txt_descricaoProblema.Text;
                os.HorimetroEntrada = Convert.ToInt32(txt_horimetroEntrada.Text);
                os.ValorMaoObra = LerMaoObra();
                os.Situacao = cmb_situacao.Text;
                os.Maquina = new Maquina() { MaquinaID = Convert.ToInt32(cmb_maquina.SelectedValue) };
                os.Funcionario = new Funcionario() { FuncionarioID = Convert.ToInt32(cmb_mecanico.SelectedValue) };

                if (txt_id.Text == "")
                {
                    osdao.Insert(os);
                    os.OrdemServicoID = osdao.GetAll().Max(x => x.OrdemServicoID);
                }
                else
                {
                    os.OrdemServicoID = Convert.ToInt32(txt_id.Text);
                    osdao.Atualizar(os);

                    foreach (PecaOS original in pecasOriginais)
                    {
                        if (!pecasOS.Contains(original))
                            podao.Deletar(original.PecaOSID);
                    }
                }

                foreach (PecaOS item in pecasOS)
                {
                    if (item.PecaOSID == 0)
                    {
                        item.OrdemServico = os;
                        podao.Insert(item);
                    }
                }

                MessageBox.Show("Ordem de Serviço Salva com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Selecione uma ordem de serviço na lista!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir esta ordem de serviço e todas as suas peças?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (PecaOS original in pecasOriginais)
                    {
                        podao.Deletar(original.PecaOSID);
                    }
                    osdao.Deletar(Convert.ToInt32(txt_id.Text));
                    MessageBox.Show("Ordem de Serviço Excluída com Sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txt_valorMaoObra_TextChanged(object sender, EventArgs e)
        {
            AtualizaPecas();
        }

        private void dgv_ordens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int id = Convert.ToInt32(dgv_ordens.Rows[e.RowIndex].Cells["OrdemServicoID"].Value);
                    OrdemServico os = ordens.Find(x => x.OrdemServicoID == id);

                    txt_id.Text = os.OrdemServicoID.ToString();
                    dtp_dataAbertura.Value = os.DataAbertura.ToDateTime(TimeOnly.MinValue);
                    if (os.DataFechamento == DateOnly.MinValue)
                    {
                        dtp_dataFechamento.Value = DateTime.Now;
                        dtp_dataFechamento.Checked = false;
                    }
                    else
                    {
                        dtp_dataFechamento.Value = os.DataFechamento.ToDateTime(TimeOnly.MinValue);
                        dtp_dataFechamento.Checked = true;
                    }
                    cmb_maquina.SelectedValue = os.Maquina.MaquinaID;
                    cmb_mecanico.SelectedValue = os.Funcionario.FuncionarioID;
                    cmb_situacao.Text = os.Situacao;
                    txt_horimetroEntrada.Text = os.HorimetroEntrada.ToString();
                    txt_valorMaoObra.Text = os.ValorMaoObra.ToString();
                    txt_descricaoProblema.Text = os.DescricaoProblema;

                    pecasOS = new List<PecaOS>(os.Pecas);
                    pecasOriginais = new List<PecaOS>(os.Pecas);
                    AtualizaPecas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public double LerMaoObra()
        {
            if (txt_valorMaoObra.Text == "")
                return 0;
            return Convert.ToDouble(txt_valorMaoObra.Text);
        }

        public string TextoFechamento(DateOnly data)
        {
            if (data == DateOnly.MinValue)
                return "";
            return data.ToString();
        }

        public void LimparCampos()
        {
            txt_id.Clear();
            dtp_dataAbertura.Value = DateTime.Now;
            dtp_dataFechamento.Value = DateTime.Now;
            dtp_dataFechamento.Checked = false;
            cmb_maquina.SelectedIndex = -1;
            cmb_mecanico.SelectedIndex = -1;
            cmb_situacao.Text = "Aberta";
            txt_horimetroEntrada.Clear();
            txt_valorMaoObra.Clear();
            txt_descricaoProblema.Clear();
            cmb_peca.SelectedIndex = -1;
            txt_quantidade.Clear();
            txt_precoUnitario.Clear();
            pecasOS = new List<PecaOS>();
            pecasOriginais = new List<PecaOS>();
            AtualizaPecas();
        }

        public void CarregaCombos()
        {
            maquinas = new MaquinaDAO().GetAll();
            cmb_maquina.DisplayMember = "NumeroSerie";
            cmb_maquina.ValueMember = "MaquinaID";
            cmb_maquina.DataSource = maquinas;
            cmb_maquina.SelectedIndex = -1;

            mecanicos = new FuncionarioDAO().GetAll().FindAll(f => f.Cargo == "Mecânico");
            cmb_mecanico.DisplayMember = "Nome";
            cmb_mecanico.ValueMember = "FuncionarioID";
            cmb_mecanico.DataSource = mecanicos;
            cmb_mecanico.SelectedIndex = -1;

            pecas = new PecaDAO().GetAll();
            cmb_peca.DisplayMember = "Descricao";
            cmb_peca.ValueMember = "PecaID";
            cmb_peca.DataSource = pecas;
            cmb_peca.SelectedIndex = -1;
        }

        public void AtualizaPecas()
        {
            dgv_pecas.DataSource = pecasOS.Select(i => new
            {
                Peca = i.Peca.Descricao,
                i.Quantidade,
                i.PrecoUnitario,
                Subtotal = i.Quantidade * i.PrecoUnitario
            }).ToList();

            try
            {
                OrdemServico os = new OrdemServico();
                os.ValorMaoObra = LerMaoObra();
                os.Pecas.AddRange(pecasOS);
                lbl_total.Text = "Total da OS: " + os.CalcularValorTotal().ToString("C");
            }
            catch (Exception)
            {
                lbl_total.Text = "Total da OS: valor da mão de obra inválido";
            }
        }

        public void AtualizaList()
        {
            ordens = osdao.GetAll();
            List<PecaOS> todasPecas = podao.GetAll();

            foreach (OrdemServico os in ordens)
            {
                List<PecaOS> pecasDaOrdem = todasPecas.FindAll(i => i.OrdemServico.OrdemServicoID == os.OrdemServicoID);
                foreach (PecaOS item in pecasDaOrdem)
                {
                    item.Peca = pecas.Find(x => x.PecaID == item.Peca.PecaID);
                }
                os.Pecas.AddRange(pecasDaOrdem);
            }

            dgv_ordens.DataSource = ordens.Select(os => new
            {
                os.OrdemServicoID,
                Abertura = os.DataAbertura,
                Fechamento = TextoFechamento(os.DataFechamento),
                Maquina = maquinas.Find(x => x.MaquinaID == os.Maquina.MaquinaID).NumeroSerie,
                Mecanico = mecanicos.Find(x => x.FuncionarioID == os.Funcionario.FuncionarioID).Nome,
                os.Situacao,
                os.DescricaoProblema,
                os.ValorMaoObra,
                Total = os.CalcularValorTotal()
            }).ToList();
        }
    }
}
