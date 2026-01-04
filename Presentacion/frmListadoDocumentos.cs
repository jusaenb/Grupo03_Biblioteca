using LN;
using Logica_Negocio;
using MD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmListadoDocumentos : Form
    { 
        private BindingSource _bindingSource=new BindingSource();
        private ILNPersonal ln;
       
        public frmListadoDocumentos()
        {
            InitializeComponent();
          
        }
        public frmListadoDocumentos(List<Documento> o,ILNPersonal l)
        {
            InitializeComponent();
            this.ln = l;

            _bindingSource.DataSource = o;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = _bindingSource;
            this.dataGridView1.CellClick += DataGridView1_CellClick;
            

        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
               Documento d =(Documento) _bindingSource.Current;
                if (ln is LNPersonalAdquisiciones)
                {
                    LNPersonalAdquisiciones ln2 = (LNPersonalAdquisiciones)ln;
                    List<Ejemplar> ejemplares = ln2.ListadoEjemplares().Where(ej => ej.Documento.Isbn.Equals(d.Isbn)).ToList();
                    BindingSource bind= new BindingSource();
                    bind.DataSource = ejemplares;
                    dataGridView2.AutoGenerateColumns = true;
                    dataGridView2.ReadOnly = true;
                    dataGridView2.DataSource = bind;
                    dataGridView2.Visible = true;
                }

            }
            catch(IOException ex)
            {
                MessageBox.Show("Error al cargar los ejemplares: "+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
