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

        protected void listadoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
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

        protected void bajaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
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

        protected void busquedaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusquedaUsuario frm = new frmBusquedaUsuario(_ln);
            frm.ShowDialog();
        }

    }
}
