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
            // Abrimos el formulario de selección
            frmAnadirEjemplar frm = new frmAnadirEjemplar(_ln);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Ejemplar ej = frm.EjemplarSeleccionado;
                if (ej != null)
                {
                    // Comprobamos que no esté ya añadido en la lista temporal de este préstamo
                    if (!_codigosEjemplaresSeleccionados.Contains(ej.CodigoEjemplar))
                    {
                        _codigosEjemplaresSeleccionados.Add(ej.CodigoEjemplar);
                        // Añadimos al ListBox visual
                        lstEjemplares.Items.Add($"ID ejemplar: {ej.CodigoEjemplar} - {ej.Documento.Titulo}");
                    }
                    else
                    {
                        MessageBox.Show("Este ejemplar ya está en la lista.");
                    }
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
    }
}