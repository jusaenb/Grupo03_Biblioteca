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
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            String nombre=textBoxNombre.Text;
            String contraseña=textBoxContraseña.Text;
            String dni=textBoxDNI.Text;

            if (string.IsNullOrEmpty(nombre)||string.IsNullOrEmpty(contraseña)||string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor ingrese su nombre y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Personal personal=null;

            if (radioButtonPersonalSala.Checked)
            {
                personal = new PersonalSala(dni, nombre);
            }
            else if (radioButtonPersonalAdquisiciones.Checked)
            {
                personal=new PersonalAdquisiciones(dni, nombre);
            }

            if (personal == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de personal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LNPersonal lnPersonal = new LNPersonal(personal);

            if (lnPersonal.Loguearse(contraseña))
            {                
                if (personal is PersonalSala)
                {
                    LNPersonalSala lnPersonalSala = new LNPersonalSala((PersonalSala)personal);
                    frmPersonalSala frm = new frmPersonalSala();
                    frm.Inicializar(lnPersonalSala);
                    frm.Show();
                }
                else if (personal is PersonalAdquisiciones)
                {
                    LNPersonalAdquisiciones lnAdquisiciones = new LNPersonalAdquisiciones((PersonalAdquisiciones)personal);
                    FPAdquisiciones frm = new FPAdquisiciones();
                    frm.Inicializar(lnAdquisiciones); 
                    frm.Show();
                }
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
