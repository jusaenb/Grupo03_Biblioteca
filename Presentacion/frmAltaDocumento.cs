using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAltaDocumento : Form
    {
        public frmAltaDocumento()
        {
            InitializeComponent();
        }

        // Evento para verificar el ISBN
        private void btAceptar_Click(object sender, EventArgs e)
        {
            string isbn = textBoxISBN.Text;

            // Verificar si el ISBN es válido y si ya existe
            if (string.IsNullOrWhiteSpace(isbn))
            {
                MessageBox.Show("Por favor, ingrese un ISBN válido.");
                return;
            }

            // Verificar si el ISBN ya existe en la base de datos
            if (_lnAdquisiciones.ExisteDocumento(isbn))
            {
                MessageBox.Show("El documento con este ISBN ya existe. Por favor, ingrese otro ISBN.");
                textBoxISBN.Clear();
                textBoxISBN.Focus();
            }
            else
            {
                // Si el ISBN no existe, abrir el formulario de detalle de documento
                frmDetalleDocumento frmDetalle = new frmDetalleDocumento(isbn); // Pasar el ISBN al siguiente formulario
                frmDetalle.ShowDialog();
            }
        }

        // Evento para cancelar el alta de documento
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario sin hacer nada
        }
    }
}
