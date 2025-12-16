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

        private void bajaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca DNI para Baja:");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string dni = frm.ValorIntroducido;
                if (!_ln.ExisteUsuario(dni))
                {
                    MessageBox.Show("El usuario no existe.");
                }
                else
                {
                    // Recuperamos el usuario para mostrar sus datos
                    frmDetalleUsuario detalle = new frmDetalleUsuario(dni, _ln, false);
                    // Si el usuario cierra el detalle, preguntamos confirmación de baja
                    if (detalle.ShowDialog() == DialogResult.OK || detalle.DialogResult == DialogResult.Cancel)
                    {
                        // Confirmación final de la Baja
                        DialogResult res = MessageBox.Show(
                            "¿Está seguro que desea dar de baja al usuario?",
                            "Aviso",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            try
                            {
                                _ln.BajaUsuario(dni);
                                MessageBox.Show("Usuario eliminado correctamente.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        private void busquedaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frm = new frmSolicitarDato("Introduzca DNI a buscar:");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string dni = frm.ValorIntroducido;
                if (_ln.ExisteUsuario(dni))
                {
                    // Abrimos el detalle en modo lectura (necesitas adaptar frmDetalleUsuario)
                    frmDetalleUsuario detalle = new frmDetalleUsuario(dni, _ln, false);                    // Truco: Podrías añadir una propiedad pública a frmDetalleUsuario para bloquear los textbox
                    detalle.Text = "Consulta de Usuario";
                    detalle.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void altaEjemplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificamos permisos y convertimos la lógica al tipo adecuado
            if (_ln is LNPersonalAdquisiciones lnAdq)
            {
                frmSolicitarDato frm = new frmSolicitarDato("Introduzca Código del nuevo Ejemplar:");

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(frm.ValorIntroducido, out int codigo))
                    {
                        

                        frmDetalleEjemplar detalle = new frmDetalleEjemplar(codigo, lnAdq);
                        detalle.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El código debe ser numérico.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Acceso denegado. Solo personal de adquisiciones.");
            }
        }

        private void bajaDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ln is LNPersonalAdquisiciones lnAdq)
            {
                // 1. Pedir ISBN
                frmSolicitarDato frm = new frmSolicitarDato("ISBN a borrar:");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(frm.ValorIntroducido, out int isbn))
                    {
                        // 2. Verificar si existe (usando el método que creamos en LNPersonalAdquisiciones)
                        if (lnAdq.ObtenerDocumento(isbn) != null)
                        {
                            // 3. Abrir detalle en modo LECTURA (false)
                            // NOTA: Asegúrate de que frmDetalleDocumento tenga el constructor con bool
                            frmDetalleDocumento detalle = new frmDetalleDocumento(isbn, lnAdq, false);
                            detalle.ShowDialog();

                            // 4. Preguntar y borrar
                            if (MessageBox.Show("¿Eliminar este documento?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                // IMPORTANTE: Debes tener este método en tu LNPersonalAdquisiciones
                                // Si no lo tienes, puedes llamar a PersistenciaDocumento.BajaDocumento(isbn);
                                lnAdq.DarBajaDocumento(isbn);
                                MessageBox.Show("Documento eliminado.");
                            }
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
        }

        private void busquedaDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ln is LNPersonalAdquisiciones lnAdq)
            {
                frmSolicitarDato frm = new frmSolicitarDato("ISBN a buscar:");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(frm.ValorIntroducido, out int isbn))
                    {
                        if (lnAdq.ObtenerDocumento(isbn) != null)
                        {
                            // Abrimos detalle en modo lectura
                            frmDetalleDocumento detalle = new frmDetalleDocumento(isbn, lnAdq, false);
                            detalle.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Documento no encontrado.");
                        }
                    }
                }
            }
        }
        private void altaPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificamos que sea Personal de Sala (por seguridad, aunque el menú ya filtra)
            if (_ln is LNPersonalSala lnSala)
            {
                // Abrimos el formulario de Alta de Préstamo pasándole la lógica correspondiente
                frmAltaPrestamo frm = new frmAltaPrestamo(lnSala);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Solo el personal de sala puede gestionar préstamos.");
            }
        }
        private void devolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ln is LNPersonalSala lnSala)
            {
                // Usamos tu formulario genérico para pedir el ID del ejemplar a devolver
                frmSolicitarDato frm = new frmSolicitarDato("Introduce el ID del Ejemplar a devolver:");

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(frm.ValorIntroducido, out int idEjemplar))
                    {
                        try
                        {
                            // Llamamos a la lógica de negocio para procesar la devolución
                            lnSala.DevolverEjemplar(idEjemplar);
                            MessageBox.Show("Ejemplar devuelto correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al devolver: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código debe ser un número.");
                    }
                }
            }
        }
    }
}
