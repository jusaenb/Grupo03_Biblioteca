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
            bool intentarDeNuevo = true;

            // Bucle para permitir reintentos si el usuario elige "Sí"
            while (intentarDeNuevo)
            {
                // 1. Mostrar formulario para pedir DNI
                frmSolicitarDato frmDni = new frmSolicitarDato("Introduzca DNI del Usuario:");

                // Si el usuario da a Cancelar o cierra la ventanita, salimos del todo
                if (frmDni.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string dni = frmDni.ValorIntroducido;

                // 2. Comprobar si existe
                if (_ln.ExisteUsuario(dni))
                {
                    // Mostrar mensaje con botones Sí/No
                    DialogResult respuesta = MessageBox.Show(
                        $"El usuario con DNI {dni} ya existe.\n¿Desea introducir otro DNI?",
                        "Usuario duplicado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.No)
                    {
                        // Si dice NO, volvemos al formulario principal (rompemos el bucle)
                        intentarDeNuevo = false;
                    }
                    // Si dice SÍ, el bucle 'while' se repite y vuelve a salir la ventana de pedir DNI
                }
                else
                {
                    // 3. Si no existe, abrimos el formulario de Alta
                    frmDetalleUsuario frmDetalle = new frmDetalleUsuario(dni, _ln);
                    frmDetalle.ShowDialog();

                    // Una vez terminada el alta, salimos del bucle
                    intentarDeNuevo = false;
                }
            }
        }


        private void altaDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Solo personal de adquisiciones (Tu código ya lo filtra visualmente, pero doble check no sobra)
            if (_ln is LNPersonalAdquisiciones lnAdq)
            {
                bool intentar = true;
                while (intentar)
                {
                    frmSolicitarDato frmIsbn = new frmSolicitarDato("Introduzca ISBN del Documento:");
                    if (frmIsbn.ShowDialog() != DialogResult.OK) return;

                    if (int.TryParse(frmIsbn.ValorIntroducido, out int isbn))
                    {
                        // 1. Comprobar si YA EXISTE antes de abrir el formulario
                        if (lnAdq.ObtenerDocumento(isbn) != null)
                        {
                            // REQUISITO: Mensaje y permitir introducir otro
                            DialogResult res = MessageBox.Show(
                                $"El documento con ISBN {isbn} ya existe.\n¿Desea introducir otro?",
                                "Duplicado",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (res == DialogResult.No) intentar = false;
                        }
                        else
                        {
                            // 2. Si es NUEVO, abrimos el formulario de alta
                            try
                            {
                                frmDetalleDocumento frmDoc = new frmDetalleDocumento(isbn, lnAdq);
                                frmDoc.ShowDialog();
                                intentar = false; // Al terminar el alta, salimos
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ISBN debe ser numérico.");
                    }
                }
            }
        }

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
            bool intentar = true;

            while (intentar)
            {
                // 1. Pedir DNI
                frmSolicitarDato frm = new frmSolicitarDato("Introduzca DNI para Baja:");

                // Si el usuario cancela la ventanita de pedir DNI, salimos del todo
                if (frm.ShowDialog() != DialogResult.OK) return;

                string dni = frm.ValorIntroducido;

                if (!_ln.ExisteUsuario(dni))
                {
                    DialogResult res = MessageBox.Show(
                        "El usuario no existe.\n¿Desea introducir otro DNI?",
                        "Error",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (res == DialogResult.No)
                    {
                        intentar = false; // Rompemos el bucle y salimos
                    }
                    // Si dice Sí, el bucle se repite
                }
                else
                {
                    // 2. Si existe, mostramos los datos
                    // Usamos 'false' (Consulta) para que salga en modo lectura
                    frmDetalleUsuario detalle = new frmDetalleUsuario(dni, _ln, false);

                    // Truco visual: Cambiamos el texto del botón para que tenga sentido en un borrado
                    // (Si hiciste el cambio de Enum 'Modo.Baja' que hablamos antes, úsalo aquí. Si no, usa este parche)
                    detalle.Text = "Baja de Usuario";

                    // Mostramos la ventana. Esperamos a que el usuario la cierre.
                    detalle.ShowDialog();

                    // 3. Confirmación FINAL (Al volver de ver los datos)
                    DialogResult confirmacion = MessageBox.Show(
                        "¿Está seguro que desea dar de baja al usuario " + dni + "?",
                        "Confirmar Baja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {
                            _ln.BajaUsuario(dni);
                            MessageBox.Show("Usuario eliminado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al borrar: " + ex.Message);
                        }
                    }

                    // Una vez gestionado (borrado o cancelado), salimos del bucle
                    intentar = false;
                }
            }
        }

        private void busquedaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusquedaUsuario frm = new frmBusquedaUsuario(_ln);
            frm.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void altaEjemplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ln is LNPersonalAdquisiciones lnAdq)
            {
                bool intentar = true;
                while (intentar)
                {
                    frmSolicitarDato frm = new frmSolicitarDato("Introduzca Código del nuevo Ejemplar:");
                    if (frm.ShowDialog() != DialogResult.OK) return;

                    if (int.TryParse(frm.ValorIntroducido, out int codigo))
                    {
                        // 1. Comprobar existencia
                        if (lnAdq.ObtenerEjemplar(codigo) != null)
                        {
                            // REQUISITO: Mensaje y reintento
                            DialogResult res = MessageBox.Show(
                                $"El ejemplar {codigo} ya existe.\n¿Desea introducir otro?",
                                "Duplicado",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (res == DialogResult.No) intentar = false;
                        }
                        else
                        {
                            // 2. Si es NUEVO, abrir formulario
                            frmDetalleEjemplar detalle = new frmDetalleEjemplar(codigo, lnAdq);
                            detalle.ShowDialog();
                            intentar = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código debe ser numérico.");
                    }
                }
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
