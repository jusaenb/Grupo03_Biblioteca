using System;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmPersonalSala : frmPrincipal
    {
        private LNPersonalSala _lnSala;

        // Constructor que recibe la lógica específica de Sala
        public frmPersonalSala():base()
        {

        }
        public void Inicializar(LNPersonalSala ln) 
        {
           
            _lnSala = ln;

            // Conectamos los eventos de los botones del menú Préstamos
           
            this.altaPrestamoToolStripMenuItem.Click += new System.EventHandler(this.altaPrestamoToolStripMenuItem_Click);
            this.devolucionToolStripMenuItem.Click += new System.EventHandler(this.devolucionToolStripMenuItem_Click);
        }

        // Evento para Alta de Préstamo
        private void altaPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de Alta de Préstamo pasándole la lógica de sala
            frmAltaPrestamo frm = new frmAltaPrestamo(_lnSala);
            frm.ShowDialog();
        }

        // Evento para Devolución
        private void devolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Pedir el código del ejemplar a devolver usando el formulario genérico
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca el código del ejemplar a devolver:");
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int codigoEjemplar))
                {
                    try
                    {
                        // 2. Llamar a la lógica de negocio para procesar la devolución
                        _lnSala.DevolverEjemplar(codigoEjemplar);
                        MessageBox.Show("Ejemplar devuelto correctamente.\nSi era el último del préstamo, este se ha finalizado.", "Devolución Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al realizar la devolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El código del ejemplar debe ser un número válido.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}