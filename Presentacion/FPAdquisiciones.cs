using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FPAdquisiciones : frmPrincipal
    {
        public FPAdquisiciones()
        {
            InitializeComponent();
            // Configurar eventos
            this.altaDocumentoToolStripMenuItem.Click += new EventHandler(this.AltaDocumento_Click);
            this.bajaDocumentoToolStripMenuItem.Click += new EventHandler(this.BajaDocumento_Click);
            this.busquedaDocumentoToolStripMenuItem.Click += new EventHandler(this.BusquedaDocumento_Click);
            this.altaEjemplarToolStripMenuItem.Click += new EventHandler(this.AltaEjemplar_Click);
            this.bajaEjemplarToolStripMenuItem.Click += new EventHandler(this.BajaEjemplar_Click);
        }

        private void AltaDocumento_Click(object sender, EventArgs e)
        {
            // Abre el formulario para alta de documento
            frmAltaDocumento frm = new frmAltaDocumento();
            frm.ShowDialog();
        }

        private void BajaDocumento_Click(object sender, EventArgs e)
        {
            // Abre el formulario para baja de documento
            frmBajaDocumento frm = new frmBajaDocumento();
            frm.ShowDialog();
        }

        private void BusquedaDocumento_Click(object sender, EventArgs e)
        {
            // Abre el formulario para buscar documentos
            frmBusquedaDocumento frm = new frmBusquedaDocumento();
            frm.ShowDialog();
        }

        private void AltaEjemplar_Click(object sender, EventArgs e)
        {
            // Abre el formulario para alta de ejemplar
            frmDetalleEjemplar frm = new frmDetalleEjemplar();
            frm.ShowDialog();
        }

        private void BajaEjemplar_Click(object sender, EventArgs e)
        {
            // Abre el formulario para baja de ejemplar
            frmBajaEjemplar frm = new frmBajaEjemplar();
            frm.ShowDialog();
        }
    }
}
