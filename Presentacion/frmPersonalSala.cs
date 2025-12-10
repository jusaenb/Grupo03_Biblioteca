using System;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmPersonalSala : frmPrincipal
    {
        private LNPersonalSala _lnSala;

        // Pasamos la lógica al constructor padre (base) para que inicialice los menús comunes
        public frmPersonalSala(LNPersonalSala ln) : base(ln)
        {
            InitializeComponent();
            _lnSala = ln;

            // Vinculamos los eventos específicos de Sala
            this.altaPrestamoToolStripMenuItem.Click += new EventHandler(this.AltaPrestamo_Click);
            this.devolucionToolStripMenuItem.Click += new EventHandler(this.Devolucion_Click);
        }

        private void AltaPrestamo_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de alta de préstamo
            frmAltaPrestamo frm = new frmAltaPrestamo(_lnSala);
            frm.ShowDialog();
        }

        private void Devolucion_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca el código del ejemplar a devolver:");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int codigo))
                {
                    try
                    {
                        _lnSala.DevolverEjemplar(codigo);
                        MessageBox.Show("Ejemplar devuelto correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El código debe ser numérico.");
                }
            }
        }
    }
}