using LN;
using MD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmBusquedaUsuarios : Form
    {
        private LNPersonal _ln;
        private BindingSource bs = new BindingSource();
        public frmBusquedaUsuarios(LNPersonal ln)
        {
            InitializeComponent();
            _ln = ln;
        }
        private void frmBusquedaUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> listaUsuarios = _ln.ListadoUsuarios();
                bs.DataSource = listaUsuarios;

                cmbDni.DataSource = bs;
                cmbDni.DisplayMember = "Dni";

                txtNombre.DataBindings.Add("Text", bs, "Nombre");

                cmbDni.SelectedIndex = -1;
                txtNombre.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }
    }
}
