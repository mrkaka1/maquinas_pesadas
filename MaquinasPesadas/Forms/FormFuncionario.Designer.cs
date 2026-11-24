namespace MaquinasPesadas.Forms
{
    partial class FormFuncionario
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
            label7 = new Label();
            label8 = new Label();
            txt_id = new TextBox();
            txt_matricula = new TextBox();
            txt_nome = new TextBox();
            txt_cpf = new TextBox();
            cmb_cargo = new ComboBox();
            dtp_dataAdmissao = new DateTimePicker();
            txt_email = new TextBox();
            chk_ativo = new CheckBox();
            btn_novo = new Button();
            btn_salvar = new Button();
            btn_excluir = new Button();
            btn_fechar = new Button();
            dgv_funcionarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_funcionarios).BeginInit();
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
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Matrícula";
            label3.AutoSize = true;
            label3.Location = new Point(205, 15);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "Nome";
            label4.AutoSize = true;
            label4.Location = new Point(12, 65);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 3;
            label4.Text = "CPF";
            label5.AutoSize = true;
            label5.Location = new Point(155, 65);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 4;
            label5.Text = "Cargo";
            label6.AutoSize = true;
            label6.Location = new Point(300, 65);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 5;
            label6.Text = "Data de admissão";
            label7.AutoSize = true;
            label7.Location = new Point(425, 65);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 6;
            label7.Text = "E-mail";
            label8.AutoSize = true;
            label8.Location = new Point(12, 115);
            label8.Name = "label8";
            label8.Size = new Size(56, 15);
            label8.TabIndex = 7;
            label8.Text = "Situação";
            txt_id.Location = new Point(12, 35);
            txt_id.Name = "txt_id";
            txt_id.ReadOnly = true;
            txt_id.Size = new Size(70, 23);
            txt_id.TabIndex = 8;
            txt_matricula.Location = new Point(100, 35);
            txt_matricula.Name = "txt_matricula";
            txt_matricula.Size = new Size(90, 23);
            txt_matricula.TabIndex = 9;
            txt_nome.Location = new Point(205, 35);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(380, 23);
            txt_nome.TabIndex = 10;
            txt_cpf.Location = new Point(12, 85);
            txt_cpf.Name = "txt_cpf";
            txt_cpf.Size = new Size(130, 23);
            txt_cpf.TabIndex = 11;
            cmb_cargo.Location = new Point(155, 85);
            cmb_cargo.Name = "cmb_cargo";
            cmb_cargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_cargo.FormattingEnabled = true;
            cmb_cargo.Size = new Size(130, 23);
            cmb_cargo.TabIndex = 12;
            dtp_dataAdmissao.Location = new Point(300, 85);
            dtp_dataAdmissao.Name = "dtp_dataAdmissao";
            dtp_dataAdmissao.Format = DateTimePickerFormat.Short;
            dtp_dataAdmissao.Size = new Size(110, 23);
            dtp_dataAdmissao.TabIndex = 13;
            txt_email.Location = new Point(425, 85);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(160, 23);
            txt_email.TabIndex = 14;
            chk_ativo.Location = new Point(12, 135);
            chk_ativo.Name = "chk_ativo";
            chk_ativo.AutoSize = true;
            chk_ativo.Text = "Ativo";
            chk_ativo.UseVisualStyleBackColor = true;
            chk_ativo.Size = new Size(60, 23);
            chk_ativo.TabIndex = 15;
            btn_novo.Location = new Point(12, 170);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(75, 27);
            btn_novo.TabIndex = 16;
            btn_novo.Text = "Novo";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            btn_salvar.Location = new Point(95, 170);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(75, 27);
            btn_salvar.TabIndex = 17;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            btn_excluir.Location = new Point(178, 170);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 27);
            btn_excluir.TabIndex = 18;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            btn_fechar.Location = new Point(510, 170);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(75, 27);
            btn_fechar.TabIndex = 19;
            btn_fechar.Text = "Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            dgv_funcionarios.AllowUserToAddRows = false;
            dgv_funcionarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_funcionarios.Location = new Point(12, 210);
            dgv_funcionarios.Name = "dgv_funcionarios";
            dgv_funcionarios.ReadOnly = true;
            dgv_funcionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_funcionarios.Size = new Size(573, 195);
            dgv_funcionarios.TabIndex = 20;
            dgv_funcionarios.CellClick += dgv_funcionarios_CellClick;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(dgv_funcionarios);
            Controls.Add(btn_fechar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_salvar);
            Controls.Add(btn_novo);
            Controls.Add(chk_ativo);
            Controls.Add(txt_email);
            Controls.Add(dtp_dataAdmissao);
            Controls.Add(cmb_cargo);
            Controls.Add(txt_cpf);
            Controls.Add(txt_nome);
            Controls.Add(txt_matricula);
            Controls.Add(txt_id);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormFuncionario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Funcionários";
            ((System.ComponentModel.ISupportInitialize)dgv_funcionarios).EndInit();
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
        private Label label7;
        private Label label8;
        private TextBox txt_id;
        private TextBox txt_matricula;
        private TextBox txt_nome;
        private TextBox txt_cpf;
        private ComboBox cmb_cargo;
        private DateTimePicker dtp_dataAdmissao;
        private TextBox txt_email;
        private CheckBox chk_ativo;
        private Button btn_novo;
        private Button btn_salvar;
        private Button btn_excluir;
        private Button btn_fechar;
        private DataGridView dgv_funcionarios;
    }
}
