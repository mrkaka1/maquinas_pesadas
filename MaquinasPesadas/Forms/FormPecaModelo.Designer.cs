namespace MaquinasPesadas.Forms
{
    partial class FormPecaModelo
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
            txt_id = new TextBox();
            cmb_peca = new ComboBox();
            cmb_modelo = new ComboBox();
            btn_novo = new Button();
            btn_salvar = new Button();
            btn_excluir = new Button();
            btn_fechar = new Button();
            dgv_compatibilidades = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_compatibilidades).BeginInit();
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
            label2.Text = "Peça";
            label3.AutoSize = true;
            label3.Location = new Point(395, 15);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Modelo";
            txt_id.Location = new Point(12, 35);
            txt_id.Name = "txt_id";
            txt_id.ReadOnly = true;
            txt_id.Size = new Size(70, 23);
            txt_id.TabIndex = 3;
            cmb_peca.Location = new Point(100, 35);
            cmb_peca.Name = "cmb_peca";
            cmb_peca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_peca.FormattingEnabled = true;
            cmb_peca.Size = new Size(280, 23);
            cmb_peca.TabIndex = 4;
            cmb_modelo.Location = new Point(395, 35);
            cmb_modelo.Name = "cmb_modelo";
            cmb_modelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_modelo.FormattingEnabled = true;
            cmb_modelo.Size = new Size(190, 23);
            cmb_modelo.TabIndex = 5;
            btn_novo.Location = new Point(12, 70);
            btn_novo.Name = "btn_novo";
            btn_novo.Size = new Size(75, 27);
            btn_novo.TabIndex = 6;
            btn_novo.Text = "Novo";
            btn_novo.UseVisualStyleBackColor = true;
            btn_novo.Click += btn_novo_Click;
            btn_salvar.Location = new Point(95, 70);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(75, 27);
            btn_salvar.TabIndex = 7;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            btn_excluir.Location = new Point(178, 70);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 27);
            btn_excluir.TabIndex = 8;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            btn_fechar.Location = new Point(510, 70);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(75, 27);
            btn_fechar.TabIndex = 9;
            btn_fechar.Text = "Fechar";
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            dgv_compatibilidades.AllowUserToAddRows = false;
            dgv_compatibilidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_compatibilidades.Location = new Point(12, 110);
            dgv_compatibilidades.Name = "dgv_compatibilidades";
            dgv_compatibilidades.ReadOnly = true;
            dgv_compatibilidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_compatibilidades.Size = new Size(573, 295);
            dgv_compatibilidades.TabIndex = 10;
            dgv_compatibilidades.CellClick += dgv_compatibilidades_CellClick;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 420);
            Controls.Add(dgv_compatibilidades);
            Controls.Add(btn_fechar);
            Controls.Add(btn_excluir);
            Controls.Add(btn_salvar);
            Controls.Add(btn_novo);
            Controls.Add(cmb_modelo);
            Controls.Add(cmb_peca);
            Controls.Add(txt_id);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormPecaModelo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compatibilidade de Peças e Modelos";
            ((System.ComponentModel.ISupportInitialize)dgv_compatibilidades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_id;
        private ComboBox cmb_peca;
        private ComboBox cmb_modelo;
        private Button btn_novo;
        private Button btn_salvar;
        private Button btn_excluir;
        private Button btn_fechar;
        private DataGridView dgv_compatibilidades;
    }
}
