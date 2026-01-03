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
        private DataGridView data2;
        public frmListadoDocumentos()
        {
            InitializeComponent();
          
        }
        public frmListadoDocumentos(Object o,ILNPersonal l)
        {
            InitializeComponent();
            this.ln = l;

            _bindingSource.DataSource = o;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = _bindingSource;
            if(o is List<Documento> li)
            {
                dataGridView1.CellClick += DataGridView1_CellClick;
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               Documento d =(Documento) _bindingSource.Current;
                if(ln is LNPersonalAdquisiciones)
                {
                    LNPersonalAdquisiciones ln2 = (LNPersonalAdquisiciones)ln;
                    List<Ejemplar> ejemplares = ln2.ListadoEjemplares().Where(ej => ej.Documento.Isbn.Equals(d.Isbn)).ToList();
                    if(data2!=null)
                    {
                        this.Controls.Remove(data2);
                        data2.Dispose();
                    }
                     data2 = new DataGridView();
                    data2.AutoGenerateColumns = true;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = ejemplares;
                    data2.DataSource = bs;
                    data2.ReadOnly = true;
                    int x = dataGridView1.Location.X;
                    int y = dataGridView1.Location.Y + dataGridView1.Height + 20;
                    data2.Location = new Point(x,y);
                    int ancho = dataGridView1.Width;
                    int alto = this.ClientSize.Height - y - 10;
                    data2.Size = new Size(ancho, alto);
                    this.Controls.Add(data2);

                }

            }
            catch(IOException ex)
            {
                MessageBox.Show("Error al cargar los ejemplares: "+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
