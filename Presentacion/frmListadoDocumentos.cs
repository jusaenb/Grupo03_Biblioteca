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
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            try
            {
                // 1. Crear BindingSource
                _bindingSource = new BindingSource();

                // 2. Asignar lista de documentos
                _bindingSource.DataSource = _ln.ListadoDocumentos();

                // 3. Vincular DataGridView al BindingSource
                // Esto generará automáticamente las columnas Isbn, Titulo, Autor, etc.
                dgvDocumentos.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar documentos: " + ex.Message);
            }
        }
    }
}