namespace MaquinasPesadas.Forms
{
    partial class FormMaquina
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txt_id = new TextBox();
            txt_numeroSerie = new TextBox();
            txt_anoFabricacao = new TextBox();
            txt_horimetro = new TextBox();
            cmb_cliente = new ComboBox();
            cmb_modelo = new ComboBox();
            btn_novo = new Button();
            btn_salvar = new Button();
            btn_excluir = new Button();
            btn_fechar = new Button();
            dgv_maquinas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_maquinas).BeginInit();
            SuspendLayout();
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Código";
            label2.AutoSize = true;
            label2.Location = new Point(100, 15);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Número de série";
            label3.AutoSize = true;
            label3.Location = new Point(285, 15);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 2;
            label3.Text = "Ano";
            label4.AutoSize = true;
            label4.Location = new Point(380, 15);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "Horímetro";
            label5.AutoSize = true;
            label5.Location = new Point(12, 65);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 4;
            label5.Text = "Cliente";
            label6.AutoSize = true;
            label6.Location = new Point(325, 65);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 5;
            label6.Text = "Modelo";
            txt_id.Location = new Point(12, 35);
            txt_id.Name = "txt_id";
            txt_id.ReadOnly = true;
            txt_id.Size = new Size(70, 23);
            txt_id.TabIndex = 6;
            txt_numeroSerie.Location = new Point(100, 35);
            txt_numeroSerie.Name = "txt_numeroSerie";
            txt_numeroSerie.Size = new Size(170, 23);
            txt_numeroSerie.TabIndex = 7;
            txt_anoFabricacao.Location = new Point(285, 35);
            txt_anoFabricacao.Name = "txt_anoFabricacao";
            txt_anoFabricacao.Size = new Size(80, 23);
            txt_anoFabricacao.TabIndex = 8;
            txt_horimetro.Location = new Point(380, 35);
            txt_horimetro.Name = "txt_horimetro";
            txt_horimetro.Size = new Size(100, 23);
            txt_horimetro.TabIndex = 9;
            cmb_cliente.Location = new Point(12, 85);
            cmb_cliente.Name = "cmb_cliente";
            cmb_cliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_cliente.FormattingEnabled = true;
            cmb_cliente.Size = new Size(300, 23);
            cmb_cliente.TabIndex = 10;
            cmb_modelo.Location = new Point(325, 85);
            cmb_modelo.Name = "cmb_modelo";
            cmb_modelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_modelo.FormattingEnabled = true;
            cmb_modelo.Size = new Size(260, 23);
            cmb_modelo.TabIndex = 11;
            btn_novo.Location = new Point(12, 120);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(75, 27);
            btn_novo.TabIndex = 12;
            btn_novo.Text = "Novo";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            btn_salvar.Location = new Point(95, 120);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(75, 27);
            btn_salvar.TabIndex = 13;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            btn_excluir.Location = new Point(178, 120);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 27);
            btn_excluir.TabIndex = 14;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            btn_fechar.Location = new Point(510, 120);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(75, 27);
            btn_fechar.TabIndex = 15;
            btn_fechar.Text = "Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            dgv_maquinas.AllowUserToAddRows = false;
            dgv_maquinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_maquinas.Location = new Point(12, 160);
            dgv_maquinas.Name = "dgv_maquinas";
            dgv_maquinas.ReadOnly = true;
            dgv_maquinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_maquinas.Size = new Size(573, 245);
            dgv_maquinas.TabIndex = 16;
            dgv_maquinas.CellClick += dgv_maquinas_CellClick;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(dgv_maquinas);
            Controls.Add(btn_fechar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_salvar);
            Controls.Add(btn_novo);
            Controls.Add(cmb_modelo);
            Controls.Add(cmb_cliente);
            Controls.Add(txt_horimetro);
            Controls.Add(txt_anoFabricacao);
            Controls.Add(txt_numeroSerie);
            Controls.Add(txt_id);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormMaquina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Máquinas";
            ((System.ComponentModel.ISupportInitialize)dgv_maquinas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txt_id;
        private TextBox txt_numeroSerie;
        private TextBox txt_anoFabricacao;
        private TextBox txt_horimetro;
        private ComboBox cmb_cliente;
        private ComboBox cmb_modelo;
        private Button btn_novo;
        private Button btn_salvar;
        private Button btn_excluir;
        private Button btn_fechar;
        private DataGridView dgv_maquinas;
    }
}
