using System;
using System.Windows.Forms;
using LN;
using Logica_Negocio;

namespace Presentacion
{
    public partial class frmDetalleUsuario : Form
    {
        private string _dni;
        private ILNPersonal _ln;

        public frmDetalleUsuario(string dni, ILNPersonal ln)
        {
            InitializeComponent();
            _dni = dni;
            _ln = ln;
            txtDni.Text = dni; // Mostramos el DNI introducido previamente
            CargarDatos();
        }
        public void CargarDatos()
        {
            if(_ln.ExisteUsuario(_dni))
            {
                this.Text="Dar de baja Usuario";
                var usuario = _ln.ObtenerUsuario(_dni);
                txtNombre.Text = usuario.Nombre;
                txtNombre.ReadOnly = true;
                txtDni.Text = usuario.Dni;
                btnAceptar.Click -= btnAceptar_Click;
                btnAceptar.Click += (s, e) =>
                {
                    try
                    {
                        _ln.BajaUsuario(_dni);
                        MessageBox.Show("Usuario dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                };
            }
            else
            {
                this.Text="Dar de alta Usuario";
                txtNombre.ReadOnly = false;
                btnAceptar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre no puede estar vacío.");
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
    }
}