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
        public enum Modo { Alta, Baja, Consulta }
        private Modo _modo;

        public frmDetalleUsuario(string dni, LNPersonal ln, Modo modo)
        {
            InitializeComponent();
            _dni = dni;
            _ln = ln;
            _modo = modo;

            ConfigurarFormulario();
        }
        public frmDetalleUsuario(string dni, LNPersonal ln, bool esAlta = true)
            : this(dni, ln, esAlta ? Modo.Alta : Modo.Consulta) { }
        private void ConfigurarFormulario()
        {
            txtDni.Text = _dni;

            switch (_modo)
            {
                case Modo.Alta:
                    this.Text = "Alta de Usuario";
                    txtDni.ReadOnly = true; // El DNI ya viene validado de fuera
                    txtNombre.ReadOnly = false;
                    btnAceptar.Text = "Dar alta";
                    break;

                case Modo.Baja:
                    this.Text = "Baja de Usuario";
                    CargarDatosUsuario();
                    txtDni.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    btnAceptar.Text = "Aceptar"; // Según enunciado
                    break;

                case Modo.Consulta:
                    this.Text = "Consulta de Usuario";
                    CargarDatosUsuario();
                    txtDni.ReadOnly = true;
                    txtNombre.ReadOnly = true;
                    btnAceptar.Text = "Cerrar";
                    break;
            }
        }
        private void CargarDatosUsuario()
        {
            Usuario u = _ln.ObtenerUsuario(_dni);
            if (u != null)
            {
                txtNombre.Text = u.Nombre;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_modo == Modo.Consulta)
                {
                    this.Close();
                }
                else if (_modo == Modo.Alta)
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("Debes introducir un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _ln.AltaUsuario(_dni, txtNombre.Text);
                    MessageBox.Show("Usuario dado de alta correctamente.");
                    this.DialogResult = DialogResult.OK; // Indicamos éxito
                    this.Close();
                }
                else if (_modo == Modo.Baja)
                {
                    // --- LÓGICA ESPECÍFICA DE BAJA (Según enunciado) ---
                    DialogResult res = MessageBox.Show(
                        "¿Está seguro de que desea dar de baja al usuario?",
                        "Confirmar Baja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        _ln.BajaUsuario(_dni);
                        MessageBox.Show("El usuario ha sido dado de baja correctamente.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // Si dice NO, "se volverá al formulario principal sin hacer nada"
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void frmDetalleUsuario_Load(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}