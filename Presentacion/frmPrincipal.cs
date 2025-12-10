using System;
using System.Windows.Forms;
using LN;
using MD;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        protected LNPersonal _ln;
        public frmPrincipal()
        {
            InitializeComponent();
        }
        public frmPrincipal(LNPersonal ln)
        {
            InitializeComponent ();
            _ln = ln;
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            
            if (_ln.Personal.Rol == Rol.Sala)
            {
                menuDocumentos.Visible = false; 
                menuEjemplares.Visible = false; 
            }
            
            else if (_ln.Personal.Rol == Rol.Adquisiciones)
            {
                menuPrestamos.Visible = false;
            }
        }

       
        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Solicitar DNI
            frmSolicitarDato frmDni = new frmSolicitarDato("Introduzca DNI del Usuario:");
            if (frmDni.ShowDialog() == DialogResult.OK)
            {
                string dni = frmDni.ValorIntroducido;

                // 2. Comprobar si existe
                if (_ln.ExisteUsuario(dni))
                {
                    MessageBox.Show($"El usuario con DNI {dni} ya existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Aquí podrías preguntar si quiere intentar con otro DNI (bucle)
                }
                else
                {
                    // 3. Abrir formulario de detalle para Alta
                    frmDetalleUsuario frmDetalle = new frmDetalleUsuario(dni, _ln);
                    frmDetalle.ShowDialog();
                }
            }
        }

        
        private void altaDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frmIsbn = new frmSolicitarDato("Introduzca ISBN del Documento:");
            if (frmIsbn.ShowDialog() == DialogResult.OK)
            {
                int isbn;
                if (int.TryParse(frmIsbn.ValorIntroducido, out isbn))
                {
                    
                    var lnAdq = (LNPersonalAdquisiciones)_ln;

                   
                    try
                    {
                        
                        frmDetalleDocumento frmDoc = new frmDetalleDocumento(isbn, lnAdq);
                        frmDoc.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("El ISBN debe ser numérico.");
                }
            }
        }
        // Añadir en Presentacion/frmPrincipal.cs

        // 1. Evento para Listado de Usuarios
        private void listadoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoUsuarios frm = new frmListadoUsuarios(_ln);
            frm.ShowDialog();
        }

        // 2. Evento para Recorrido Uno a Uno
        private void recorridoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecorridoUsuarios frm = new frmRecorridoUsuarios(_ln);
            frm.ShowDialog();
        }

        // 3. Evento para Listado de Documentos (Solo Adquisiciones)
        private void listadoDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificamos si el personal tiene permisos (es Adquisiciones)
            if (_ln is LNPersonalAdquisiciones lnAdq)
            {
                frmListadoDocumentos frm = new frmListadoDocumentos(lnAdq);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso denegado. Solo personal de adquisiciones puede ver este listado.");
            }
        }
    }
}
