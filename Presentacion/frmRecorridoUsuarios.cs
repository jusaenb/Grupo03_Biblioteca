using System;
using System.Windows.Forms;
using LN;

namespace Presentacion
{
    public partial class frmRecorridoUsuarios : Form
    {
        private LNPersonal _ln;
        private BindingSource _bindingSource;

        public frmRecorridoUsuarios(LNPersonal ln)
        {
            InitializeComponent();
            _ln = ln;
            ConfigurarBinding();
        }

        private void ConfigurarBinding()
        {
            // 1. Crear el BindingSource
            _bindingSource = new BindingSource();

            // 2. Asignar la lista de usuarios como DataSource
            _bindingSource.DataSource = _ln.ListadoUsuarios();

            // 3. Vincular el BindingNavigator al BindingSource
            // Esto activa automáticamente los botones de siguiente/anterior
            bindingNavigator1.BindingSource = _bindingSource;

            // 4. Vincular los TextBoxes a las propiedades del objeto actual en el BindingSource
            // "Text" -> Propiedad del TextBox
            // _bindingSource -> Origen de datos
            // "Dni" -> Propiedad de la clase Usuario
            txtDni.DataBindings.Add(new Binding("Text", _bindingSource, "Dni"));

            // "Nombre" -> Propiedad de la clase Usuario
            txtNombre.DataBindings.Add(new Binding("Text", _bindingSource, "Nombre"));
        }
    }
}