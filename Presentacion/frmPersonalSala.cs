using System;
using System.Windows.Forms;
using LN;
using Logica_Negocio;

namespace Presentacion
{
    public partial class frmPersonalSala : frmPrincipal
    {
        private ILNPersonalSala _lnSala;

        // Constructor privado para el diseñador
        // PRE: Ninguna
        // POST: Inicializa los componentes visuales del formulario.
        private frmPersonalSala() { InitializeComponent(); }

        // Pasamos la lógica al constructor padre (base) para que inicialice los menús comunes
        // PRE: El parámetro 'ln' no debe ser nulo.
        // POST: Se inicializa el formulario, se asigna la lógica de negocio y se suscriben los eventos de los menús específicos.
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

        // PRE: El usuario ha seleccionado la opción de menú "Alta Préstamo".
        // POST: Se abre el formulario modal para gestionar el alta de un nuevo préstamo.
        private void AltaPrestamo_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de alta de préstamo
            frmAltaPrestamo frm = new frmAltaPrestamo(_lnSala,0);
            frm.ShowDialog();
        }

        // PRE: El usuario ha seleccionado la opción de menú "Devolución".
        // POST: Solicita el ID del préstamo. Si es válido y existe, se realiza la devolución completa (liberación y borrado) y se notifica el éxito. En caso de error, muestra el mensaje correspondiente.
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

        // PRE: El usuario ha seleccionado la opción de menú "Listado Ejemplares".
        // POST: Abre el formulario de listados mostrando los ejemplares disponibles.
        private void ListadoEjemplar_Click(object sender, EventArgs e)
        {
            var o= _lnSala.ListadoEjemplaresDisponibles();
            FrmListadoEjemplares frm = new FrmListadoEjemplares(o);
            frm.ShowDialog();
        }

        // PRE: El usuario ha seleccionado la opción de menú "Listado Préstamos".
        // POST: Abre el formulario de listados mostrando los préstamos activos.
        private void Listado_Prestamo_Click(object sender, EventArgs e)
        {
            var o = _lnSala.ListadoPrestamosActivos();
            FrmListadoPrestamo frm = new FrmListadoPrestamo(o);
            frm.ShowDialog();
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