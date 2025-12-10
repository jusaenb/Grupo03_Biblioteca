using System;
using System.Linq;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmListadoUsuarios : Form
    {
        private LNPersonal _ln;
        private BindingSource _bindingSource;

        public frmListadoUsuarios(LNPersonal ln)
        {
            InitializeComponent();
            _ln = ln;

            // 1. Instanciar BindingSource
            _bindingSource = new BindingSource();

            // 2. Asignar los datos iniciales
            _bindingSource.DataSource = _ln.ListadoUsuarios();

            // 3. Enlazar los ListBox al BindingSource
            // lstDNI mostrará la propiedad "Dni"
            lstDNI.DataSource = _bindingSource;
            lstDNI.DisplayMember = "Dni";

            // lstNombre mostrará la propiedad "Nombre"
            lstNombre.DataSource = _bindingSource;
            lstNombre.DisplayMember = "Nombre";
        }

        private void btnOrdenDNI_Click(object sender, EventArgs e)
        {
            // Ordenamos la lista y actualizamos el DataSource del BindingSource
            _bindingSource.DataSource = _ln.ListadoUsuarios().OrderBy(u => u.Dni).ToList();

            // Opcional: ResetBindings refresca los controles enlazados
            _bindingSource.ResetBindings(false);
        }

        private void btnOrdenNombre_Click(object sender, EventArgs e)
        {
            // Ordenamos por nombre
            _bindingSource.DataSource = _ln.ListadoUsuarios().OrderBy(u => u.Nombre).ToList();
            _bindingSource.ResetBindings(false);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}