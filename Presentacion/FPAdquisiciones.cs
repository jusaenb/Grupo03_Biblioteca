using System;
using System.Windows.Forms;
using LN;
using MD;

namespace Presentacion
{
    public partial class frmPersonalAdquisiciones : frmPrincipal
    {
        private LNPersonalAdquisiciones _lnAdquisiciones;

        // Constructor vacío, usado por el diseñador
        public frmPersonalAdquisiciones() : base(null)  // Pasamos null solo para el diseñador
        {
            InitializeComponent();
        }

        // Método para inicializar el formulario con la lógica de negocio real
        public void Inicializar(LNPersonalAdquisiciones lnAdquisiciones)
        {
            _lnAdquisiciones = lnAdquisiciones;
            // Llamamos al método base para hacer la configuración de permisos
            ConfigurarPermisos();
        }

        // En esta función, configuramos los permisos de acuerdo al rol de Adquisiciones
        protected override void ConfigurarPermisos()
        {
            base.ConfigurarPermisos(); // Llamamos a la configuración de permisos de la clase base (frmPrincipal)

            // Personal de adquisiciones puede acceder a funcionalidades de "Documentos" y "Ejemplares"
            menuPrestamos.Visible = false; // Los "prestamos" están deshabilitados para adquisiciones
        }

        // Event handler para Alta de Documento
        private void altaDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Solicitar ISBN
            frmSolicitarDato frmIsbn = new frmSolicitarDato("Introduzca ISBN del Documento:");
            if (frmIsbn.ShowDialog() == DialogResult.OK)
            {
                int isbn;
                if (int.TryParse(frmIsbn.ValorIntroducido, out isbn))
                {
                    try
                    {
                        // Usamos LNAdquisiciones para manejar la alta de documentos
                        frmDetalleDocumento frmDoc = new frmDetalleDocumento(isbn, _lnAdquisiciones);
                        frmDoc.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El ISBN debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Event handler para Alta de Ejemplar
        private void altaEjemplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Similar al alta de documentos, pero para ejemplares.
            frmSolicitarDato frmCodigo = new frmSolicitarDato("Introduzca Código del Ejemplar:");
            if (frmCodigo.ShowDialog() == DialogResult.OK)
            {
                int codigoEjemplar;
                if (int.TryParse(frmCodigo.ValorIntroducido, out codigoEjemplar))
                {
                    try
                    {
                        // Código para alta de ejemplar
                        frmDetalleEjemplar frmEjemplar = new frmDetalleEjemplar(codigoEjemplar, _lnAdquisiciones);
                        frmEjemplar.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El código del ejemplar debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
