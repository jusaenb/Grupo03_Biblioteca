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

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                // Configurar que las columnas se creen solas según las propiedades de la clase
                dgvDocumentos.AutoGenerateColumns = true;

                var lista = _ln.ListadoDocumentos();

                dgvDocumentos.DataSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        // Ya puedes borrar el método frmListadoDocumentos_Load si quieres
    }
}