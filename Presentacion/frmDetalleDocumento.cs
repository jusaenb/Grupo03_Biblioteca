using System;
using System.Windows.Forms;
using LN;
using Logica_Negocio;
using MD;

namespace Presentacion
{
    public partial class frmDetalleDocumento : Form
    {
        private int _isbn;
        private ILNPersonalAdquisiciones _ln;
        private bool _esBaja; // Variable para saber si estamos borrando

        // Constructor: Añadimos 'esBaja' con valor por defecto false
        public frmDetalleDocumento(int isbn, ILNPersonalAdquisiciones ln, bool esBaja = false)
        {
            InitializeComponent();
            _isbn = isbn;
            _ln = ln;
            _esBaja = esBaja;
            txtISBN.Text = _isbn.ToString();
            frmDetalleDocumento_Load(this, EventArgs.Empty);
        }

        private void frmDetalleDocumento_Load(object sender, EventArgs e)
        {
            
            txtISBN.ReadOnly = true;
            

            // === EL DOCUMENTO YA EXISTE (Modo Búsqueda o Baja) ===
            if (_ln.ExisteDocumento(_isbn))
            {
                // Cargar datos comunes
                Documento doc = _ln.ObtenerDocumento(_isbn);
                txtTitulo.Text = doc.Titulo;
                txtAutor.Text = doc.Autor;
                txtEditorial.Text = doc.Editorial;
                txtAno.Text = doc.AñoPublicacion.ToString();

                // Detectar si es Libro o Audiolibro
                if (doc is AudioLibro audio)
                {
                    rbAudiolibro.Checked = true;
                    txtFormato.Text = audio.Formato;
                    txtDuracion.Text = audio.Duracion.ToString();
                    grpAudio.Visible = true;
                }
                else
                {
                    rbLibro.Checked = true;
                    grpAudio.Visible = false;
                }

                // Bloquear todo (Solo lectura)
                BloquearControles();

                // DECIDIR QUÉ HACE EL BOTÓN
                if (_esBaja)
                {
                    this.Text = "Baja de Documento";
                    btnAceptar.Text = "Eliminar"; // Modo Borrar
                }
                else
                {
                    this.Text = "Detalle del Documento";
                    btnAceptar.Text = "Cerrar";   // Modo Mirar
                    btnCancelar.Visible = false;  // No hace falta cancelar si solo miras
                }
            }
            
            else
            {
                this.Text = "Alta de Nuevo Documento";
                btnAceptar.Text = "Guardar";

                // Configuración inicial de Alta
                if (rbLibro.Checked){
                    grpAudio.Visible = false;
                }
                else if(rbAudiolibro.Checked){  grpAudio.Visible = true; }
                    
                
                
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // CASO 1: SOLO CERRAR
                if (btnAceptar.Text == "Cerrar")
                {
                    this.Close();
                    return;
                }

                // CASO 2: ELIMINAR (BAJA)
                if (btnAceptar.Text == "Eliminar")
                {
                    if (MessageBox.Show("¿Seguro que quieres eliminar este documento y todos sus ejemplares?",
                        "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        
                        _ln.DarBajaDocumento(_isbn);
                        
                        MessageBox.Show("Documento eliminado correctamente.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    return;
                }

                // CASO 3: GUARDAR (ALTA) - Tu lógica de siempre
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                   errorProvider1.SetError(txtTitulo, "El título es obligatorio.");
                    return;
                }

                if (!int.TryParse(txtAno.Text, out int anyo))
                {
                    errorProvider2.SetError(txtAno, "Año de publicación incorrecto.");
                    return;
                }

                Documento nuevoDoc;
                if (rbAudiolibro.Checked)
                {
                    if (!int.TryParse(txtDuracion.Text, out int dur)) {errorProvider3.SetError(txtDuracion,"Inserte una duración valida"); return; }
                    nuevoDoc = new AudioLibro(txtTitulo.Text, txtAutor.Text,txtEditorial.Text,anyo, int.Parse(txtISBN.Text), txtFormato.Text, dur);
                }
                else
                {
                    nuevoDoc = new Documento(anyo, txtTitulo.Text,txtAutor.Text,int.Parse(txtISBN.Text),txtEditorial.Text);
                }

                _ln.DarAltaDocumento(nuevoDoc);
                MessageBox.Show("Documento guardado.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

      
        

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        private void BloquearControles()
        {
            txtTitulo.ReadOnly = true; txtAutor.ReadOnly = true;
            txtEditorial.ReadOnly = true; txtAno.ReadOnly = true;
            rbLibro.Enabled = false; rbAudiolibro.Enabled = false;
            txtFormato.ReadOnly = true; txtDuracion.ReadOnly = true;
        }

        private void rbAudiolibro_CheckedChanged(object sender, EventArgs e)
        {this.grpAudio.Visible = true;
        }

        private void rbLibro_CheckedChanged(object sender, EventArgs e)
        {
            this.grpAudio.Visible = false;
        }
    }
}