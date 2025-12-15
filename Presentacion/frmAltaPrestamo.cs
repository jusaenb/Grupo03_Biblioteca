using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LN;
using MD;

namespace Presentacion
{
    public partial class frmAltaPrestamo : Form
    {
        private LNPersonalSala _ln;
        private List<int> _codigosEjemplaresSeleccionados;

        public frmAltaPrestamo(LNPersonalSala ln)
        {
            InitializeComponent();
            _ln = ln;
            _codigosEjemplaresSeleccionados = new List<int>();

            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            // Poner fecha actual
            txtFecha.Text = DateTime.Now.ToShortDateString();

            // Cargar usuarios en el ComboBox
            try
            {
                cmbUsuarios.DataSource = _ln.ListadoUsuarios();
                cmbUsuarios.DisplayMember = "Dni"; // Mostramos DNI según PDF
                cmbUsuarios.ValueMember = "Dni";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void btnAnadirEjemplar_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduce Código del Ejemplar:");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int codigo))
                {
                    // 2. Comprobamos si ya lo hemos añadido a la lista visual
                    if (_codigosEjemplaresSeleccionados.Contains(codigo))
                    {
                        MessageBox.Show("Este ejemplar ya está en la lista.");
                        return;
                    }

                    // 3. Buscamos el ejemplar en la BBDD para ver si existe y obtener título
                    // (Necesitarás añadir ObtenerEjemplar en LNPersonalSala, ver Paso 2)
                    Ejemplar ej = _ln.ObtenerEjemplar(codigo);

                    if (ej != null)
                    {
                        if (ej.Disponible)
                        {
                            _codigosEjemplaresSeleccionados.Add(ej.CodigoEjemplar);
                            // Añadimos al ListBox visual con el título del libro
                            string info = $"ID: {ej.CodigoEjemplar} - {ej.Documento.Titulo}";
                            lstEjemplares.Items.Add(info);
                        }
                        else
                        {
                            MessageBox.Show("El ejemplar no está disponible (ya está prestado).");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe ningún ejemplar con ese código.");
                    }
                }
                else
                {
                    MessageBox.Show("El código debe ser un número.");
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            if (_codigosEjemplaresSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe añadir al menos un ejemplar.");
                return;
            }

            // Nota sobre el ID manual: 
            // Tu lógica de negocio actual genera el ID automáticamente (GetHashCode).
            // Aunque el PDF pide un campo ID visual, no podemos forzarlo en la lógica actual sin modificar Persistencia.
            // Procedemos con la lógica existente ignorando txtID.Text o lo pasamos si refactorizas LN.
            // Aquí seguiremos la lógica existente:

            try
            {
                string dniUsuario = (string)cmbUsuarios.SelectedValue;

                // Llamada a la lógica
                _ln.DarAltaPrestamo(dniUsuario, _codigosEjemplaresSeleccionados);

                MessageBox.Show("Préstamo realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAltaPrestamo_Load(object sender, EventArgs e)
        {

        }
    }
}
