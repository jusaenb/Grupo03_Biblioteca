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
        private bool Alta;

        public frmDetalleDocumento(int isbn, LNPersonalAdquisiciones ln, bool alta = true)
        {
            InitializeComponent();
            _isbn = isbn;
            _ln = ln;
            txtISBN.Text = isbn.ToString();
            Alta = alta;

            ConfigurarFormulario();
            rbLibro.Checked = true;
            ActualizarInterfaz();
        }
        private void ConfigurarFormulario()
        {
            txtISBN.Text = _isbn.ToString();

            if (Alta)
            {
                this.Text = "Alta de Documento";
                txtISBN.ReadOnly = true;
            }
            else
            {
                // MODO CONSULTA/BAJA
                this.Text = "Datos del Documento";

                // Recuperamos el documento
                Documento doc = _ln.ObtenerDocumento(_isbn);

                if (doc != null)
                {
                    // 1. Rellenar datos comunes
                    txtTitulo.Text = doc.Titulo;
                    txtAutor.Text = doc.Autor;
                    txtEditorial.Text = doc.Editorial;
                    txtAno.Text = doc.AñoPublicacion.ToString(); // ¡Te faltaba mostrar el año!

                    // 2. COMPROBACIÓN DE TIPO (Aquí está la solución a tu problema)
                    if (doc is AudioLibro)
                    {
                        rbAudiolibro.Checked = true; // Marcamos el circulito de AudioLibro

                        // Convertimos la variable 'doc' a 'AudioLibro' para poder ver sus campos específicos
                        AudioLibro audio = (AudioLibro)doc;

                        txtFormato.Text = audio.Formato;
                        txtDuracion.Text = audio.Duracion.ToString();
                    }
                    else
                    {
                        // Si tienes un rbLibro, lo marcas aquí. Si no, basta con desmarcar el otro.
                        // rbLibro.Checked = true; 
                        rbAudiolibro.Checked = false;
                    }
                }

                // 3. Bloquear todos los campos para que no se puedan editar
                txtTitulo.ReadOnly = true;
                txtAutor.ReadOnly = true;
                txtEditorial.ReadOnly = true;
                txtAno.ReadOnly = true;
                txtFormato.ReadOnly = true;  // Bloqueamos también los específicos
                txtDuracion.ReadOnly = true;

                grpTipo.Enabled = false; // Bloquear radio buttons
                grpAudio.Enabled = false; // Bloquear el grupo de campos de audio (opcional, ya que los textbox son readonly)

                btnAceptar.Visible = false; // Ocultar botón guardar
                btnCancelar.Text = "Cerrar";
            }
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

        private void frmDetalleDocumento_Load(object sender, EventArgs e)
        {

        }

        private void ActualizarInterfaz()
        {

            bool esAudiolibro = rbAudiolibro.Checked;

            grpAudio.Enabled = esAudiolibro;

        }

        private void rbTipo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarInterfaz();
        }
    }
}