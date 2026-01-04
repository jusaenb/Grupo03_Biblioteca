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
    public partial class FrmListadoEjemplares : Form
    {
        public FrmListadoEjemplares()
        {
            InitializeComponent();
        }
        public FrmListadoEjemplares(List<Ejemplar> lis)
        {
          InitializeComponent();
            BindingSource bind = new BindingSource();
            bind.DataSource = lis;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bind;
        }
    }
}
