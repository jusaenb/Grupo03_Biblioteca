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
        private bool Alta;

        public frmDetalleEjemplar(int codigo, LNPersonalAdquisiciones ln, bool alta = true)
        {
            InitializeComponent();
            _codigoEjemplar = codigo;
            _ln = ln;
            Alta = alta;
            ConfigurarFormulario();
        }
        private void ConfigurarFormulario()
        {
            txtCodigo.Text = _codigoEjemplar.ToString();
            txtCodigo.ReadOnly = true; // El código nunca se cambia
            txtPersonal.Text = _ln.Personal.Nombre;
            txtPersonal.ReadOnly = true;

            if (Alta)
            {
                // --- MODO ALTA ---
                this.Text = "Alta de Ejemplar";
                CargarDocumentos();
            }
            else
            {
                // --- MODO BAJA / CONSULTA ---
                this.Text = "Detalle del Ejemplar";

                // Ocultamos el combo de elegir libro y mostramos un TextBox solo lectura
                cmbDocumentos.Visible = false;
                // (Si tienes un TextBox 'txtTituloLibro' úsalo, si no, reutiliza el combo bloqueado)

                // Buscamos datos del ejemplar
                Ejemplar ej = _ln.ObtenerEjemplar(_codigoEjemplar);
                if (ej != null)
                {
                    // Mostramos el título del libro asociado en algún control
                    // Por simplicidad, si no tienes un label extra, lo mostramos en el título de la ventana
                    this.Text += " - Libro: " + ej.Documento.Titulo;
                }

                btnAceptar.Visible = false; // Ocultar botón Guardar
                // Si tienes botón cancelar, cámbialo a Cerrar
            }
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

        private void altaEjemplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificamos que sea personal de adquisiciones
            if (_ln is LNPersonalAdquisiciones lnAdq)
            {
                frmSolicitarDato frm = new frmSolicitarDato("Introduzca Código del nuevo Ejemplar:");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Validamos que sea numérico (según tu modelo es int)
                    if (int.TryParse(frm.ValorIntroducido, out int codigo))
                    {
                        // Abrimos el formulario de detalle pasándole el código y la lógica
                        frmDetalleEjemplar detalle = new frmDetalleEjemplar(codigo, lnAdq);
                        detalle.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El código debe ser numérico.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Acceso denegado. Solo Adquisiciones puede dar de alta ejemplares.");
            }
        }

        private void frmDetalleEjemplar_Load(object sender, EventArgs e)
        {

        }
    }
}