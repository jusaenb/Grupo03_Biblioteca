using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSolicitarDato : Form
    {
        // Propiedad para que el formulario padre pueda leer lo que escribió el usuario
        public string ValorIntroducido
        {
            get { return txtValor.Text.Trim(); } 
        }

        public frmSolicitarDato(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK; // Esto indica al padre que se pulsó Aceptar
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Esto indica al padre que se canceló
            this.Close();
        }
    }
}