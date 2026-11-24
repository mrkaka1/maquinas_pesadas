namespace MaquinasPesadas.Forms
{
    partial class FormPrincipal
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
            btn_marcas = new Button();
            btn_categorias = new Button();
            btn_fornecedores = new Button();
            btn_clientes = new Button();
            btn_funcionarios = new Button();
            btn_modelos = new Button();
            btn_pecas = new Button();
            btn_maquinas = new Button();
            btn_compatibilidades = new Button();
            btn_sair = new Button();
            SuspendLayout();
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(280, 25);
            label1.TabIndex = 0;
            label1.Text = "Sistema de Máquinas Pesadas";
            btn_marcas.Location = new Point(30, 70);
            btn_marcas.Name = "btn_marcas";
            btn_marcas.Size = new Size(180, 40);
            btn_marcas.TabIndex = 1;
            btn_marcas.Text = "Marcas";
            btn_marcas.UseVisualStyleBackColor = true;
            btn_marcas.Click += btn_marcas_Click;
            btn_categorias.Location = new Point(230, 70);
            btn_categorias.Name = "btn_categorias";
            btn_categorias.Size = new Size(180, 40);
            btn_categorias.TabIndex = 2;
            btn_categorias.Text = "Categorias";
            btn_categorias.UseVisualStyleBackColor = true;
            btn_categorias.Click += btn_categorias_Click;
            btn_fornecedores.Location = new Point(30, 120);
            btn_fornecedores.Name = "btn_fornecedores";
            btn_fornecedores.Size = new Size(180, 40);
            btn_fornecedores.TabIndex = 3;
            btn_fornecedores.Text = "Fornecedores";
            btn_fornecedores.UseVisualStyleBackColor = true;
            btn_fornecedores.Click += btn_fornecedores_Click;
            btn_clientes.Location = new Point(230, 120);
            btn_clientes.Name = "btn_clientes";
            btn_clientes.Size = new Size(180, 40);
            btn_clientes.TabIndex = 4;
            btn_clientes.Text = "Clientes";
            btn_clientes.UseVisualStyleBackColor = true;
            btn_clientes.Click += btn_clientes_Click;
            btn_funcionarios.Location = new Point(30, 170);
            btn_funcionarios.Name = "btn_funcionarios";
            btn_funcionarios.Size = new Size(180, 40);
            btn_funcionarios.TabIndex = 5;
            btn_funcionarios.Text = "Funcionários";
            btn_funcionarios.UseVisualStyleBackColor = true;
            btn_funcionarios.Click += btn_funcionarios_Click;
            btn_modelos.Location = new Point(230, 170);
            btn_modelos.Name = "btn_modelos";
            btn_modelos.Size = new Size(180, 40);
            btn_modelos.TabIndex = 6;
            btn_modelos.Text = "Modelos";
            btn_modelos.UseVisualStyleBackColor = true;
            btn_modelos.Click += btn_modelos_Click;
            btn_pecas.Location = new Point(30, 220);
            btn_pecas.Name = "btn_pecas";
            btn_pecas.Size = new Size(180, 40);
            btn_pecas.TabIndex = 7;
            btn_pecas.Text = "Peças";
            btn_pecas.UseVisualStyleBackColor = true;
            btn_pecas.Click += btn_pecas_Click;
            btn_maquinas.Location = new Point(230, 220);
            btn_maquinas.Name = "btn_maquinas";
            btn_maquinas.Size = new Size(180, 40);
            btn_maquinas.TabIndex = 8;
            btn_maquinas.Text = "Máquinas";
            btn_maquinas.UseVisualStyleBackColor = true;
            btn_maquinas.Click += btn_maquinas_Click;
            btn_compatibilidades.Location = new Point(30, 270);
            btn_compatibilidades.Name = "btn_compatibilidades";
            btn_compatibilidades.Size = new Size(180, 40);
            btn_compatibilidades.TabIndex = 9;
            btn_compatibilidades.Text = "Compatibilidade";
            btn_compatibilidades.UseVisualStyleBackColor = true;
            btn_compatibilidades.Click += btn_compatibilidades_Click;
            btn_sair.Location = new Point(230, 320);
            btn_sair.Name = "btn_sair";
            btn_sair.Size = new Size(180, 40);
            btn_sair.TabIndex = 10;
            btn_sair.Text = "Sair";
            btn_sair.UseVisualStyleBackColor = true;
            btn_sair.Click += btn_sair_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 380);
            Controls.Add(btn_sair);
            Controls.Add(btn_compatibilidades);
            Controls.Add(btn_maquinas);
            Controls.Add(btn_pecas);
            Controls.Add(btn_modelos);
            Controls.Add(btn_funcionarios);
            Controls.Add(btn_clientes);
            Controls.Add(btn_fornecedores);
            Controls.Add(btn_categorias);
            Controls.Add(btn_marcas);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_marcas;
        private Button btn_categorias;
        private Button btn_fornecedores;
        private Button btn_clientes;
        private Button btn_funcionarios;
        private Button btn_modelos;
        private Button btn_pecas;
        private Button btn_maquinas;
        private Button btn_compatibilidades;
        private Button btn_sair;
    }
}
