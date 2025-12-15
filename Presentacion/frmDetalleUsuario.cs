using LN;
using MD;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDetalleUsuario : Form
    {
        private string _dni;
        private LNPersonal _ln;
        private bool _esAlta;

        public frmDetalleUsuario(string dni, LNPersonal ln, bool esAlta = true)
        {
            InitializeComponent();
            _dni = dni;
            _ln = ln;
            txtDni.Text = dni; // Mostramos el DNI introducido previamente
            _esAlta = esAlta;

            ConfigurarModoFormulario();
        }
        private void ConfigurarModoFormulario()
        {
            if (_esAlta)
            {
                // --- MODO ALTA ---
                this.Text = "Alta de Usuario";
                txtDni.ReadOnly = true;
            }
            else
            {
                // --- MODO CONSULTA/BAJA ---
                this.Text = "Datos de Usuario"; // Título de la ventana

                Usuario u = _ln.ObtenerUsuario(_dni);
                if (u != null)
                {
                    txtNombre.Text = u.Nombre; // Muestra el nombre
                }

                // Bloqueamos la edición (solo lectura)
                txtNombre.ReadOnly = true;
                txtDni.ReadOnly = true;

                // Cambiamos el botón "Aceptar" para que sirva solo para cerrar
                btnAceptar.Text = "Cerrar";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Cerrar")
            {
                this.Close();
                return;
            }

            // Lógica de Alta
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debes introducir un nombre para el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _ln.AltaUsuario(_dni, txtNombre.Text);
                MessageBox.Show("Usuario dado de alta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void frmDetalleUsuario_Load(object sender, EventArgs e)
        {
        }
    }
}