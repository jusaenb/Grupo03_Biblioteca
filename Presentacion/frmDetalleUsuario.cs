using System;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmDetalleUsuario : Form
    {
        private string _dni;
        private LNPersonal _ln;

        public frmDetalleUsuario(string dni, LNPersonal ln)
        {
            InitializeComponent();
            _dni = dni;
            _ln = ln;
            txtDni.Text = dni; // Mostramos el DNI introducido previamente
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe introducir un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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