using System;
using System.Windows.Forms;
using LN;
using Logica_Negocio;

namespace Presentacion
{
    public partial class frmPersonalSala : frmPrincipal
    {
        private ILNPersonalSala _lnSala;

        
        private frmPersonalSala() { InitializeComponent(); }

       
        public frmPersonalSala(ILNPersonalSala ln) : base(ln)
        {
            InitializeComponent();
            _lnSala = ln;

            // Vinculamos los eventos específicos de Sala
            this.altaPrestamoToolStripMenuItem.Click += new EventHandler(this.AltaPrestamo_Click);
            this.devolucionToolStripMenuItem.Click += this.Devolucion_Click;
            this.listadoEjemplar.Click += new EventHandler(this.ListadoEjemplar_Click);
            this.listadoPrestamo.Click += new EventHandler(this.Listado_Prestamo_Click);
            this.búsquedaToolStripMenuItem.Click += new EventHandler(this.Busqueda_Click);
        }

       
        private void AltaPrestamo_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de alta de préstamo
            frmAltaPrestamo frm = new frmAltaPrestamo(_lnSala,0);
            frm.ShowDialog();
        }

       
        private void Devolucion_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca el código del prestamo a devolver:");
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int codigo))
                {
                    try
                    {
                        
                        // Llamamos a la lógica para procesar la devolución completa
                        _lnSala.DevolverPrestamoCompleto(codigo);

                        MessageBox.Show("Prestamo finalizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

       
        private void ListadoEjemplar_Click(object sender, EventArgs e)
        {
            var o= _lnSala.ListadoEjemplaresDisponibles();
            FrmListadoEjemplares frm = new FrmListadoEjemplares(o);
            frm.MdiParent = this;
            frm.Show();
        }

        
        private void Listado_Prestamo_Click(object sender, EventArgs e)
        {
            var o = _lnSala.ListadoPrestamosActivos();
            FrmListadoPrestamo frm = new FrmListadoPrestamo(o);
            frm.MdiParent = this;
            frm.Show();
        }
        private void Busqueda_Click(object obj, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduze el código del prestamo");
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if(_lnSala.ExistePrestamo(frm.ValorIntroducido)==false)
                {
                    MessageBox.Show("El prestamo no existe");
                    return;
                }
                else
                {
                    String numero = frm.ValorIntroducido;
                    int.TryParse(numero, out int valor);
                    frmAltaPrestamo alta = new frmAltaPrestamo(_lnSala, valor);
                    alta.ShowDialog();
                }

                   
            }
        }
    }
}