using System;
using System.Windows.Forms;
using LN;
using Logica_Negocio;
using MD;

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        protected ILNPersonal _ln;

        // Constructor vacío (necesario para el diseñador visual)
        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Constructor principal que recibe la sesión
        public frmPrincipal(ILNPersonal ln)
        {
            InitializeComponent();
            _ln = ln;
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            if (this._ln is ILNPersonalSala)
            {
                // Sala no ve la gestión de acervo
                menuDocumentos.Visible = false;
                menuEjemplares.Visible = false;
            }
            else if (this._ln is ILNPersonalAdquisiciones)
            {
                // Adquisiciones no ve préstamos
                menuPrestamos.Visible = false;
            }
        }

        // =========================================================================
        // LÓGICA COMÚN: GESTIÓN DE USUARIOS
        // (Al ser común a ambos roles, se implementa aquí en el Padre)
        // =========================================================================

        protected void altaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frmDni = new frmSolicitarDato("Introduzca DNI del Usuario:");
            if (frmDni.ShowDialog() == DialogResult.OK)
            {
                string dni = frmDni.ValorIntroducido;
                if (_ln.ExisteUsuario(dni))
                {
                    MessageBox.Show($"El usuario con DNI {dni} ya existe.");
                }
                else
                {
                    frmDetalleUsuario frmDetalle = new frmDetalleUsuario(dni, _ln);
                    frmDetalle.MdiParent = this;
                    frmDetalle.Show();
                }
            }
        }

        protected void bajaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca DNI a borrar:");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if(!_ln.ExisteUsuario(frm.ValorIntroducido))
                    {
                        MessageBox.Show($"El usuario con DNI {frm.ValorIntroducido} no existe.");
                        return;
                    }
                    else
                    {
                        frmDetalleUsuario frmDetalle = new frmDetalleUsuario(frm.ValorIntroducido, _ln);
                        frmDetalle.ShowDialog();
                       
                    }
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        protected void busquedaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmBusquedaUsuario frm = new frmBusquedaUsuario(_ln);
            frm.MdiParent = this;
            frm.Show();
        }

        protected void listadoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista= _ln.ListadoUsuarios();
            frmListadoUsuarios frm = new frmListadoUsuarios(lista);
            frm.MdiParent = this;
            frm.Show();
        }

        protected void recorridoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista=_ln.ListadoUsuarios();
            FrmRecorridoUs frm= new FrmRecorridoUs(lista);
            frm.MdiParent = this;
            frm.Show();
        }

        
    }
}