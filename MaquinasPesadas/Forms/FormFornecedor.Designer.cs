namespace MaquinasPesadas.Forms
{
    partial class FormFornecedor
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
            txt_id = new TextBox();
            txt_razaoSocial = new TextBox();
            txt_cnpj = new TextBox();
            txt_telefone = new TextBox();
            txt_email = new TextBox();
            txt_cidade = new TextBox();
            txt_uf = new TextBox();
            btn_novo = new Button();
            btn_salvar = new Button();
            btn_excluir = new Button();
            btn_fechar = new Button();
            dgv_fornecedores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_fornecedores).BeginInit();
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
            label2.Size = new Size(84, 15);
            label2.TabIndex = 1;
            label2.Text = "Razão social";
            label3.AutoSize = true;
            label3.Location = new Point(420, 15);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "CNPJ";
            label4.AutoSize = true;
            label4.Location = new Point(12, 65);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 3;
            label4.Text = "Telefone";
            label5.AutoSize = true;
            label5.Location = new Point(175, 65);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 4;
            label5.Text = "E-mail";
            label6.AutoSize = true;
            label6.Location = new Point(408, 65);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 5;
            label6.Text = "Cidade";
            label7.AutoSize = true;
            label7.Location = new Point(540, 65);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 6;
            label7.Text = "UF";
            txt_id.Location = new Point(12, 35);
            txt_id.Name = "txt_id";
            txt_id.ReadOnly = true;
            txt_id.Size = new Size(70, 23);
            txt_id.TabIndex = 7;
            txt_razaoSocial.Location = new Point(100, 35);
            txt_razaoSocial.Name = "txt_razaoSocial";
            txt_razaoSocial.Size = new Size(300, 23);
            txt_razaoSocial.TabIndex = 8;
            txt_cnpj.Location = new Point(420, 35);
            txt_cnpj.Name = "txt_cnpj";
            txt_cnpj.Size = new Size(165, 23);
            txt_cnpj.TabIndex = 9;
            txt_telefone.Location = new Point(12, 85);
            txt_telefone.Name = "txt_telefone";
            txt_telefone.Size = new Size(150, 23);
            txt_telefone.TabIndex = 10;
            txt_email.Location = new Point(175, 85);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(220, 23);
            txt_email.TabIndex = 11;
            txt_cidade.Location = new Point(408, 85);
            txt_cidade.Name = "txt_cidade";
            txt_cidade.Size = new Size(120, 23);
            txt_cidade.TabIndex = 12;
            txt_uf.Location = new Point(540, 85);
            txt_uf.Name = "txt_uf";
            txt_uf.Size = new Size(45, 23);
            txt_uf.TabIndex = 13;
            btn_novo.Location = new Point(12, 120);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(75, 27);
            btn_novo.TabIndex = 14;
            btn_novo.Text = "Novo";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            btn_salvar.Location = new Point(95, 120);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(75, 27);
            btn_salvar.TabIndex = 15;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            btn_excluir.Location = new Point(178, 120);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 27);
            btn_excluir.TabIndex = 16;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            btn_fechar.Location = new Point(510, 120);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(75, 27);
            btn_fechar.TabIndex = 17;
            btn_fechar.Text = "Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            dgv_fornecedores.AllowUserToAddRows = false;
            dgv_fornecedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_fornecedores.Location = new Point(12, 160);
            dgv_fornecedores.Name = "dgv_fornecedores";
            dgv_fornecedores.ReadOnly = true;
            dgv_fornecedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_fornecedores.Size = new Size(573, 245);
            dgv_fornecedores.TabIndex = 18;
            dgv_fornecedores.CellClick += dgv_fornecedores_CellClick;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(dgv_fornecedores);
            Controls.Add(btn_fechar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_salvar);
            Controls.Add(btn_novo);
            Controls.Add(txt_uf);
            Controls.Add(txt_cidade);
            Controls.Add(txt_email);
            Controls.Add(txt_telefone);
            Controls.Add(txt_cnpj);
            Controls.Add(txt_razaoSocial);
            Controls.Add(txt_id);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormFornecedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Fornecedores";
            ((System.ComponentModel.ISupportInitialize)dgv_fornecedores).EndInit();
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
        private TextBox txt_id;
        private TextBox txt_razaoSocial;
        private TextBox txt_cnpj;
        private TextBox txt_telefone;
        private TextBox txt_email;
        private TextBox txt_cidade;
        private TextBox txt_uf;
        private Button btn_novo;
        private Button btn_salvar;
        private Button btn_excluir;
        private Button btn_fechar;
        private DataGridView dgv_fornecedores;
    }
}
