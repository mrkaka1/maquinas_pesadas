namespace MaquinasPesadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var con = MaquinasPesadas.DataBase.Conexao.Conectar())
                {
                    MessageBox.Show("Conectado ao banco maquinas_pesadas!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
