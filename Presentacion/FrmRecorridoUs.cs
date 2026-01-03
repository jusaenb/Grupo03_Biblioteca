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
    public partial class FrmRecorridoUs : Form
    {
        private BindingSource bindingSource1;
        public FrmRecorridoUs()
        {
            InitializeComponent();
        }
        public FrmRecorridoUs(List<Usuario> lista)
        {
            InitializeComponent();
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = lista;
            this.bindingNavigator1.BindingSource = bindingSource1;
            textNombre.DataBindings.Add(new Binding("text",bindingSource1, "Nombre"));
            textDNI.DataBindings.Add(new Binding("text", bindingSource1, "Dni"));

        }
    }
}
