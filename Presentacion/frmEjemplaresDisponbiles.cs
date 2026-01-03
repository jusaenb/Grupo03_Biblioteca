using LN;
using Logica_Negocio;
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
    public partial class frmEjemplaresDisponbiles : Form
    {
        private Ejemplar e;
        private frmEjemplaresDisponbiles()
        {
            InitializeComponent();
        }
        public frmEjemplaresDisponbiles(ILNPersonalSala ln,List<int>excluir)
        {
            InitializeComponent();
            if(excluir!=null && excluir.Count>0)
                this.comboBox1.DataSource = ln.ListadoEjemplaresDisponibles().Where(x=>!excluir.Contains(x.CodigoEjemplar)).ToList();
            else
            {
                this.comboBox1.DataSource = ln.ListadoEjemplaresDisponibles();
            }
                
            
            this.comboBox1.DisplayMember = "CodigoEjemplar";
            this.comboBox1.ValueMember = "CodigoEjemplar";
            this.comboBox1.Format+=(s,ev)=>
            {
                if(ev.ListItem is Ejemplar)
                {
                    Ejemplar ejemplar = (Ejemplar)ev.ListItem;
                    ev.Value = ejemplar.CodigoEjemplar + " - " + ejemplar.Documento.Titulo;
                }
                  
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.e = (Ejemplar)this.comboBox1.SelectedItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public Ejemplar EjemplarSeleccionado
        {
            get { return e; }
        }
    }
}
