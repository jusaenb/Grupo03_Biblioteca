using System;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmListadoDocumentos : Form
    {
        private LNPersonalAdquisiciones _ln;
        private BindingSource _bindingSource;

        public frmListadoDocumentos(LNPersonalAdquisiciones ln)
        {
            InitializeComponent();
            _ln = ln;
        }

        private void frmListadoDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                _bindingSource = new BindingSource();
                var lista = _ln.ListadoDocumentos();
                dgvDocumentos.AutoGenerateColumns = true;

                _bindingSource.DataSource = lista;

                dgvDocumentos.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar documentos: " + ex.Message);
            }
        }
    }
}
