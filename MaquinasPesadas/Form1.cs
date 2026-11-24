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
                var vendas = new MaquinasPesadas.DAO.VendaDAO().GetAll();
                var os = new MaquinasPesadas.DAO.OrdemServicoDAO().GetAll();
                MessageBox.Show($"Vendas: {vendas.Count}\nOS: {os.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
