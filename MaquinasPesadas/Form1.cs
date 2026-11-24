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
                //new MaquinasPesadas.Forms.FormModelo().ShowDialog();

                //new MaquinasPesadas.Forms.FormPeca().ShowDialog();

                new MaquinasPesadas.Forms.FormMaquina().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
