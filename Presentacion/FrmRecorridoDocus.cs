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
    public partial class FrmRecorridoDocus : Form
    {
        private BindingSource bindingSource1;
        public FrmRecorridoDocus()
        {
            InitializeComponent();
        }
        public FrmRecorridoDocus(List<Documento> lista)
        {
            InitializeComponent();
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = lista;
            this.bindingNavigator1.BindingSource = bindingSource1;
            textTitulo.DataBindings.Add(new Binding("text",bindingSource1, "Titulo"));
            textISBN.DataBindings.Add(new Binding("text", bindingSource1, "Isbn"));
        }
    }
}
