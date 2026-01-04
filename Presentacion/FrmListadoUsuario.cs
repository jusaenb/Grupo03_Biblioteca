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
    public partial class FrmListadoUsuario : Form
    {
        public FrmListadoUsuario()
        {
            InitializeComponent();
        }
        public FrmListadoUsuario(List<Usuario> usuarios)
        {
            InitializeComponent();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = usuarios;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bindingSource;
        }
    }
}
