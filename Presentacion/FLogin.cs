using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LN;
using Logica_Negocio;
using MD;

namespace Presentacion
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
            textBoxContraseña.PasswordChar = '*';
        }

        public LNPersonal LogicaNegocio { get; internal set; }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String contraseña = textBoxContraseña.Text;
            String dni = textBoxDNI.Text;

            // 1. Basic Validation
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor ingrese todos los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Determine Personal Type based on Radio Buttons
            Personal personal = null;
            if (radioButtonPersonalSala.Checked)
            {
                personal = new PersonalSala(dni, nombre);
            }
            else if (radioButtonPersonalAdquisiciones.Checked)
            {
                personal = new PersonalAdquisiciones(dni, nombre);
            }

            if (personal == null)
            {
                MessageBox.Show("Seleccione un tipo de personal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Attempt Login
            LNPersonal lnPersonal = new LNPersonal(personal);

            if (lnPersonal.Loguearse(contraseña))
            {
                this.Hide(); // Hide Login form

                // 4. INSTANTIATE THE CORRECT CHILD FORM
                // Instead of creating a generic frmPrincipal, we check the type
                // and create either frmPersonalSala or FPAdquisiciones.

                if (personal is PersonalSala)
                {
                    // Create specific Logic for Sala
                    LNPersonalSala lnSala = new LNPersonalSala((PersonalSala)personal);

                    // Launch the specific Child Form for Sala
                    frmPersonalSala frm = new frmPersonalSala(lnSala);
                    frm.ShowDialog();
                }
                else if (personal is PersonalAdquisiciones)
                {
                    // Create specific Logic for Adquisiciones
                    LNPersonalAdquisiciones lnAdq = new LNPersonalAdquisiciones((PersonalAdquisiciones)personal);

                    // Launch the specific Child Form for Adquisiciones
                    FPAdquisiciones frm = new FPAdquisiciones(lnAdq);
                    frm.ShowDialog();
                }

                // Close app when the main form is closed
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonEntrar_Click(sender, e);
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
