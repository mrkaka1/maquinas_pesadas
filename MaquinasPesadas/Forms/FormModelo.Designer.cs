namespace MaquinasPesadas.Forms
{
    partial class FormModelo
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
            txt_id = new TextBox();
            txt_nome = new TextBox();
            cmb_tipo = new ComboBox();
            txt_potenciaCV = new TextBox();
            cmb_marca = new ComboBox();
            btn_novo = new Button();
            btn_salvar = new Button();
            btn_excluir = new Button();
            btn_fechar = new Button();
            dgv_modelos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_modelos).BeginInit();
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
            label2.Size = new Size(28, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome";
            label3.AutoSize = true;
            label3.Location = new Point(315, 15);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "Tipo";
            label4.AutoSize = true;
            label4.Location = new Point(480, 15);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 3;
            label4.Text = "Potência (CV)";
            label5.AutoSize = true;
            label5.Location = new Point(12, 65);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 4;
            label5.Text = "Marca";
            txt_id.Location = new Point(12, 35);
            txt_id.Name = "txt_id";
            txt_id.ReadOnly = true;
            txt_id.Size = new Size(70, 23);
            txt_id.TabIndex = 5;
            txt_nome.Location = new Point(100, 35);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(200, 23);
            txt_nome.TabIndex = 6;
            cmb_tipo.Location = new Point(315, 35);
            cmb_tipo.Name = "cmb_tipo";
            cmb_tipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_tipo.FormattingEnabled = true;
            cmb_tipo.Size = new Size(150, 23);
            cmb_tipo.TabIndex = 7;
            txt_potenciaCV.Location = new Point(480, 35);
            txt_potenciaCV.Name = "txt_potenciaCV";
            txt_potenciaCV.Size = new Size(105, 23);
            txt_potenciaCV.TabIndex = 8;
            cmb_marca.Location = new Point(12, 85);
            cmb_marca.Name = "cmb_marca";
            cmb_marca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_marca.FormattingEnabled = true;
            cmb_marca.Size = new Size(250, 23);
            cmb_marca.TabIndex = 9;
            btn_novo.Location = new Point(12, 120);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(75, 27);
            btn_novo.TabIndex = 10;
            btn_novo.Text = "Novo";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            btn_salvar.Location = new Point(95, 120);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(75, 27);
            btn_salvar.TabIndex = 11;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            btn_excluir.Location = new Point(178, 120);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 27);
            btn_excluir.TabIndex = 12;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            btn_fechar.Location = new Point(510, 120);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(75, 27);
            btn_fechar.TabIndex = 13;
            btn_fechar.Text = "Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            dgv_modelos.AllowUserToAddRows = false;
            dgv_modelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_modelos.Location = new Point(12, 160);
            dgv_modelos.Name = "dgv_modelos";
            dgv_modelos.ReadOnly = true;
            dgv_modelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_modelos.Size = new Size(573, 245);
            dgv_modelos.TabIndex = 14;
            dgv_modelos.CellClick += dgv_modelos_CellClick;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(dgv_modelos);
            Controls.Add(btn_fechar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_salvar);
            Controls.Add(btn_novo);
            Controls.Add(cmb_marca);
            Controls.Add(txt_potenciaCV);
            Controls.Add(cmb_tipo);
            Controls.Add(txt_nome);
            Controls.Add(txt_id);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormModelo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Modelos";
            ((System.ComponentModel.ISupportInitialize)dgv_modelos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txt_id;
        private TextBox txt_nome;
        private ComboBox cmb_tipo;
        private TextBox txt_potenciaCV;
        private ComboBox cmb_marca;
        private Button btn_novo;
        private Button btn_salvar;
        private Button btn_excluir;
        private Button btn_fechar;
        private DataGridView dgv_modelos;
    }
}
