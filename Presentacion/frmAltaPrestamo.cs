using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmAltaPrestamo : Form
    {
        private LNPersonalSala _ln;
        private List<int> _codigosEjemplares;

        public frmAltaPrestamo(LNPersonalSala ln)
        {
            InitializeComponent();
            _ln = ln;
            _codigosEjemplares = new List<int>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCodigoEjemplar.Text, out int codigo))
            {
                if (!_codigosEjemplares.Contains(codigo))
                {
                    _codigosEjemplares.Add(codigo);
                    lstEjemplares.Items.Add($"Ejemplar: {codigo}");
                    txtCodigoEjemplar.Clear();
                    txtCodigoEjemplar.Focus();
                }
                else
                {
                    MessageBox.Show("Este ejemplar ya está en la lista.");
                }
            }
            else
            {
                MessageBox.Show("El código del ejemplar debe ser numérico.");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDniUsuario.Text))
            {
                MessageBox.Show("Debe indicar el DNI del usuario.");
                return;
            }

            if (_codigosEjemplares.Count == 0)
            {
                MessageBox.Show("Debe añadir al menos un ejemplar al préstamo.");
                return;
            }

            try
            {
                // Llamada al método de la capa de lógica que gestiona todo el proceso
                _ln.DarAltaPrestamo(txtDniUsuario.Text, _codigosEjemplares);

                MessageBox.Show("Préstamo realizado con éxito.", "Operación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}