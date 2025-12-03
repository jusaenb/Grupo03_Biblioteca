using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LN;
using MD;

namespace Presentacion
{
    public partial class frmDetalleEjemplar : Form
    {
        private int _codigoEjemplar;
        private LNPersonalAdquisiciones _ln;

        public frmDetalleEjemplar(int codigo, LNPersonalAdquisiciones ln)
        {
            InitializeComponent();
            _codigoEjemplar = codigo;
            _ln = ln;

            // Inicializar datos fijos
            txtCodigo.Text = _codigoEjemplar.ToString();
            txtPersonal.Text = _ln.Personal.Nombre; // Nombre del trabajador logueado

            CargarDocumentos();
        }

        private void CargarDocumentos()
        {
            try
            {
                // Obtenemos la lista de documentos para llenar el combo
                List<Documento> docs = _ln.ListadoDocumentos();

                // Configuramos el ComboBox para mostrar el Título pero guardar el ISBN
                cmbDocumentos.DataSource = docs;
                cmbDocumentos.DisplayMember = "Titulo"; // Lo que ve el usuario
                cmbDocumentos.ValueMember = "Isbn";     // El valor real (ISBN)

                // Formato personalizado para ver "ISBN - Título" (Opcional, mejora usabilidad)
                cmbDocumentos.Format += (s, e) =>
                {
                    if (e.ListItem is Documento d)
                        e.Value = $"{d.Isbn} - {d.Titulo}";
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar documentos: " + ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbDocumentos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un documento asociado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtenemos el ISBN seleccionado
                int isbnSeleccionado = (int)cmbDocumentos.SelectedValue;

                // Llamamos a la lógica de negocio
                _ln.DarAltaEjemplar(_codigoEjemplar, isbnSeleccionado);

                MessageBox.Show("Ejemplar dado de alta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}