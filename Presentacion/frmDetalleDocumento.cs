using System;
using System.Windows.Forms;
using LN;
using MD;

namespace Presentacion
{
    public partial class frmDetalleDocumento : Form
    {
        private int _isbn;
        private LNPersonalAdquisiciones _ln;

        public frmDetalleDocumento(int isbn, LNPersonalAdquisiciones ln)
        {
            InitializeComponent();
            _isbn = isbn;
            _ln = ln;
            txtISBN.Text = isbn.ToString();

            // Configuración inicial
            rbLibro.Checked = true;
            grpAudio.Enabled = false; // Deshabilitado por defecto
        }

        private void rbAudiolibro_CheckedChanged(object sender, EventArgs e)
        {
            // Habilitar campos extra si es audiolibro
            grpAudio.Enabled = rbAudiolibro.Checked;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recoger datos básicos
                string titulo = txtTitulo.Text;
                string autor = txtAutor.Text;
                string editorial = txtEditorial.Text;

                if (!int.TryParse(txtAno.Text, out int ano))
                {
                    MessageBox.Show("El año debe ser un número válido.");
                    return;
                }

                string tipo = rbAudiolibro.Checked ? "AudioLibro" : "Libro";
                string formato = "";
                float duracion = 0;

                // Recoger datos específicos si es audiolibro
                if (tipo == "AudioLibro")
                {
                    formato = txtFormato.Text;
                    if (!float.TryParse(txtDuracion.Text, out duracion))
                    {
                        MessageBox.Show("La duración debe ser un número válido.");
                        return;
                    }
                }

                // Llamar a la capa de negocio
                _ln.DarAltaDocumento(_isbn, titulo, autor, editorial, ano, tipo, formato, duracion);

                MessageBox.Show("Documento guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}