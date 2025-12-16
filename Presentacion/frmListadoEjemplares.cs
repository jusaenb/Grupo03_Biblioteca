using System;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmListadoEjemplares : Form
    {
        private LNPersonalAdquisiciones _ln;

        public frmListadoEjemplares(LNPersonalAdquisiciones ln)
        {
            InitializeComponent();
            _ln = ln;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            // Obtenemos la lista desde la lógica que acabamos de crear
            dataGridView1.DataSource = _ln.ListadoEjemplares();

            // Ajuste visual opcional
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}