using LN;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FPAdquisiciones : frmPrincipal
    {
        private LNPersonalAdquisiciones _lnAdq;
        public FPAdquisiciones()
        {
            InitializeComponent();
        }
        public FPAdquisiciones(LNPersonalAdquisiciones ln) : base(ln)
        {
            InitializeComponent();
            _lnAdq = ln;

            this.altaDocumentoToolStripMenuItem.Click += new EventHandler(this.AltaDocumento_Click);
            this.bajaDocumentoToolStripMenuItem.Click += new EventHandler(this.BajaDocumento_Click);
            this.listadoToolStripMenuItem1.Click += new EventHandler(this.ListadoDocumentos_Click); 
            this.busquedaDocumentoToolStripMenuItem.Click += new EventHandler(this.BusquedaDocumento_Click);
            this.altaEjemplarToolStripMenuItem.Click += new EventHandler(this.AltaEjemplar_Click);
            this.bajaEjemplarToolStripMenuItem.Click += new EventHandler(this.BajaEjemplar_Click);
            this.busquedaEjemplarToolStripMenuItem.Click += new EventHandler(this.BusquedaEjemplar_Click);
            this.listadoEjemplaresToolStripMenuItem.Click += new EventHandler(this.ListadoEjemplares_Click);
            this.menuPrestamos.Visible = false;
        }

        private void AltaDocumento_Click(object sender, EventArgs e)
        {
            bool intentar = true;
            while (intentar)
            {
                frmSolicitarDato frmIsbn = new frmSolicitarDato("Introduzca ISBN:");
                if (frmIsbn.ShowDialog() != DialogResult.OK) return;

                if (int.TryParse(frmIsbn.ValorIntroducido, out int isbn))
                {
                    if (_lnAdq.ObtenerDocumento(isbn) != null)
                    {
                        if (MessageBox.Show("El documento ya existe. ¿Otro?", "Duplicado",
                            MessageBoxButtons.YesNo) == DialogResult.No)
                            intentar = false;
                    }
                    else
                    {
                        // Abrimos el formulario de Alta
                        frmDetalleDocumento frmDoc = new frmDetalleDocumento(isbn, _lnAdq);
                        if (frmDoc.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Documento creado con éxito.");
                        }
                        intentar = false;
                    }
                }
                else
                {
                    MessageBox.Show("ISBN numérico requerido.");
                }
            }
        }

        private void BajaDocumento_Click(object sender, EventArgs e)
        {
            // 1. Pedir ISBN
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca ISBN a borrar:");
            if (frm.ShowDialog() != DialogResult.OK) return;

            if (int.TryParse(frm.ValorIntroducido, out int isbn))
            {
                // 2. Verificar si existe
                if (_lnAdq.ObtenerDocumento(isbn) != null) // Usa tu variable _lnAdq
                {
                    // 3. Mostrar datos en modo lectura (false) para confirmar visualmente
                    frmDetalleDocumento detalle = new frmDetalleDocumento(isbn, _lnAdq, false);
                    detalle.Text = "Confirmar Baja";
                    detalle.ShowDialog();

                    // 4. Preguntar confirmación final
                    if (MessageBox.Show("¿Seguro que quiere eliminar este documento?", "Baja",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // Asegúrate de tener este método en tu LN o usar la persistencia
                        // Si no tienes método en LN, tendrás que crearlo o llamar a la persistencia
                        // _lnAdq.BajaDocumento(isbn); 
                        MessageBox.Show("Documento eliminado (simulado). Implementa el método en LN.");
                    }
                }
                else
                {
                    MessageBox.Show("El documento no existe.");
                }
            }
        }

        private void BusquedaDocumento_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca ISBN a buscar:");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int isbn))
                {
                    if (_lnAdq.ObtenerDocumento(isbn) != null)
                    {
                        // Abrir en modo lectura
                        frmDetalleDocumento detalle = new frmDetalleDocumento(isbn, _lnAdq, false);
                        detalle.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Documento no encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("El ISBN debe ser numérico.");
                }
            }
        }

        private void AltaEjemplar_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Código del Nuevo Ejemplar:");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int codigo))
                {
                    // Verificar si existe el ejemplar antes de abrir...
                    // (Omitido por brevedad, añade tu if _lnAdq.ExisteEjemplar...)

                    // Aquí pasamos los 3 datos que pide el constructor que te daba error:
                    // 1. Codigo, 2. La lógica de negocio, 3. True (porque es Alta)
                    frmDetalleEjemplar detalle = new frmDetalleEjemplar(codigo, _lnAdq, true);
                    detalle.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El código debe ser numérico");
                }
            }
        }

        private void BajaEjemplar_Click(object sender, EventArgs e)
        {
            // 1. Pedimos el código del ejemplar a borrar
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca Código del Ejemplar a borrar:");

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int codigo))
                {
                    // 2. Comprobamos si existe (usando tu lógica de negocio)
                    // Asegúrate de usar _lnAdq (tu variable de adquisiciones)
                    if (_lnAdq.ObtenerEjemplar(codigo) != null)
                    {
                        // 3. Confirmación
                        // Podrías abrir el detalle en modo lectura si quisieras ver qué libro es, 
                        // pero con un MessageBox basta para que funcione ahora mismo.
                        DialogResult respuesta = MessageBox.Show(
                            $"¿Está seguro de que desea eliminar el ejemplar {codigo}?",
                            "Confirmar Baja",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.Yes)
                        {
                            try
                            {
                                // 4. Llamada al borrado
                                _lnAdq.BajaEjemplar(codigo);
                                MessageBox.Show("Ejemplar eliminado correctamente.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún ejemplar con ese código.");
                    }
                }
                else
                {
                    MessageBox.Show("El código debe ser numérico.");
                }
            }
        }
        private void ListadoDocumentos_Click(object sender, EventArgs e)
        {
            frmListadoDocumentos frm = new frmListadoDocumentos(_lnAdq);
            frm.ShowDialog();
        }
        private void BusquedaEjemplar_Click(object sender, EventArgs e)
        {
            // 1. Pedir el código usando tu ventana auxiliar
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca Código del Ejemplar a buscar:");

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(frm.ValorIntroducido, out int codigo))
                {
                    // 2. Buscar en la LN
                    if (_lnAdq.ObtenerEjemplar(codigo) != null)
                    {
                        // 3. Abrir el detalle en modo SOLO LECTURA (false)
                        frmDetalleEjemplar detalle = new frmDetalleEjemplar(codigo, _lnAdq, false);
                        detalle.Text = "Consulta de Ejemplar";
                        detalle.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún ejemplar con ese código.");
                    }
                }
                else
                {
                    MessageBox.Show("El código debe ser numérico.");
                }
            }
        }
        private void ListadoEjemplares_Click(object sender, EventArgs e)
        {
            frmListadoEjemplares frm = new frmListadoEjemplares(_lnAdq);
            frm.ShowDialog();
        }

        private void FPAdquisiciones_Load(object sender, EventArgs e)
        {

        }
    }
}

