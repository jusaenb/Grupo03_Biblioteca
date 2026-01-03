using System;
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
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string contraseña = textBoxContraseña.Text;
            string dni = textBoxDNI.Text;

            // 1. Validaciones de campos vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor ingrese todos los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Variable polimórfica (Interfaz base)
            ILNPersonal lnPersonal = null;
            Personal personal = null;

            // 2. Creación de la Lógica de Negocio según el RadioButton
            
            if (radioButtonPersonalSala.Checked)
            {
                personal = new PersonalSala(dni, nombre);
                // Guardamos en la variable de interfaz base
                lnPersonal = new LNPersonalSala((PersonalSala)personal);
            }
            else if (radioButtonPersonalAdquisiciones.Checked)
            {
                personal = new PersonalAdquisiciones(dni, nombre);
                // Guardamos en la variable de interfaz base
                lnPersonal = new LNPersonalAdquisiciones((PersonalAdquisiciones)personal);
            }

            // Validación de selección
            if (lnPersonal == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de personal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Intento de Login (Usando el método de la interfaz base ILNPersonal)
            if (lnPersonal.Loguearse(contraseña))
            {
                this.Hide(); // Ocultamos el login si entra

                // 4. Redirección y Casteo Seguro
                // Verificamos de qué tipo específico es la interfaz para abrir el form correcto

                if (lnPersonal is ILNPersonalSala lnSala) 
                {
                    
                    frmPrincipal frm = new frmPersonalSala(lnSala);
                    frm.Show();
                }
                else if (lnPersonal is ILNPersonalAdquisiciones lnAdq) // C# Pattern Matching
                {
                    // Pasamos la interfaz específica (ILNPersonalAdquisiciones)
                    frmPrincipal frm = new FPAdquisiciones(lnAdq);
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas o usuario no registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonEntrar_Click(sender, e);
            }
        }
    }
}