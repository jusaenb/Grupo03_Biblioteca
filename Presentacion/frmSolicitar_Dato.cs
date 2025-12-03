using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmSolicitarDato : Form
    {
        public string ValorIntroducido { get { return txtValor.Text; } }

        public frmSolicitarDato(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }
    }
}