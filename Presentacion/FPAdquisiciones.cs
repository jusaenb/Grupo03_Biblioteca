using LN;
using Logica_Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FPAdquisiciones : frmPrincipal
    {
        private ILNPersonalAdquisiciones _ln;
        private FPAdquisiciones()
        {

        }
        public FPAdquisiciones(ILNPersonalAdquisiciones ln):base(ln)
        {
            InitializeComponent();
            _ln = ln;
            // Configurar eventos
            this.altaDocumentoToolStripMenuItem.Click += new EventHandler(this.AltaDocumento_Click);
            this.bajaDocumentoToolStripMenuItem.Click += new EventHandler(this.BajaDocumento_Click);
            this.busquedaDocumentoToolStripMenuItem.Click += new EventHandler(this.BusquedaDocumento_Click);
            this.altaEjemplarToolStripMenuItem.Click += new EventHandler(this.AltaEjemplar_Click);
            this.bajaEjemplarToolStripMenuItem.Click += new EventHandler(this.BajaEjemplar_Click);
            this.listadoDocumentos.Click += new EventHandler(this.ListadoDocumentos_Click);
            this.recorridoToolStripMenuItem.Click += new EventHandler(this.RecorridoToolStripMenuItem_Click);
            this.listadoEjemplar.Click+=new EventHandler(this.ListadoEjemplares_Click);
            this.busquedaEjemplarToolStripMenuItem.Click += new EventHandler(this.BusquedaEjemplarToolStripMenuItem_Click);


        }

        private void AltaDocumento_Click(object sender, EventArgs e)
        {
            bool intentarDeNuevo = false;
            do
            {
                intentarDeNuevo = false; // Reiniciamos el flag

                frmSolicitarDato frm = new frmSolicitarDato("Introduzca el ISBN del Documento:");

                if (frm.ShowDialog() == DialogResult.OK)
                {

                    if (int.TryParse(frm.ValorIntroducido, out int isbn))
                    {

                        if (_ln.ExisteDocumento(isbn))
                        {

                            DialogResult respuesta = MessageBox.Show(
                                $"El documento con ISBN {isbn} ya existe.\n¿Quieres introducir otro?",
                                "Ya existe",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                            if (respuesta == DialogResult.Yes)
                            {
                                intentarDeNuevo = true; // Vuelve al inicio del bucle
                            }
                        }
                        else
                        {

                            frmDetalleDocumento detalle = new frmDetalleDocumento(isbn, _ln);
                            detalle.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ISBN debe ser numérico.");
                        intentarDeNuevo = true;
                    }
                }


            } while (intentarDeNuevo);
            } 
            

        private void BajaDocumento_Click(object sender, EventArgs e)
        {
            // Abre el formulario para baja de documento
            frmSolicitarDato frmIsbn = new frmSolicitarDato("Introduzca el ISBN del Documento a borrar:");
            frmIsbn.ShowDialog();
            if (frmIsbn.DialogResult == DialogResult.OK) {
                String n = frmIsbn.ValorIntroducido;
                int isbn = int.Parse(n);
                if (!_ln.ExisteDocumento(isbn))
                {
                    MessageBox.Show($"El documento con ISBN {isbn} no existe.");
                    return;
                }
                else
                {
                    frmDetalleDocumento frm = new frmDetalleDocumento(isbn, _ln, true);
                    frm.ShowDialog();
                }
            }
            
            
        }

        private void BusquedaDocumento_Click(object sender, EventArgs e)
        {
              frmSolicitarDato frmDni = new frmSolicitarDato("Introduzca ISBN del Documento:");
            frmDni.ShowDialog();
            if (frmDni.DialogResult == DialogResult.OK)
            {
                int isbn=int.Parse(frmDni.ValorIntroducido);
                if(!_ln.ExisteDocumento(isbn))
                {
                    MessageBox.Show($"El documento con ISBN {isbn} no existe.");
                    return;
                }
                else
                { 
                        
                      String nombre=_ln.ObtenerDocumento(isbn).Titulo;
                      frmDetalleDocumento frm= new frmDetalleDocumento(isbn, _ln);
                    frm.ShowDialog();

                }
                
            }
                
        }

        private void AltaEjemplar_Click(object sender, EventArgs e)
        {
            // Abre el formulario para alta de ejemplar
            frmSolicitarDato frmCodigo = new frmSolicitarDato("Introduzca el código del Ejemplar:");
            frmCodigo.ShowDialog();
            if (frmCodigo.DialogResult == DialogResult.OK)
            {
                
                String coidgo2 = frmCodigo.ValorIntroducido;
                if(_ln.ExisteEjemplar(int.Parse(coidgo2)))
                {
                    MessageBox.Show($"El ejemplar con código {coidgo2} ya existe.");
                    return;
                }
                int codigo = int.Parse(coidgo2);
                frmDetalleEjemplar frm = new frmDetalleEjemplar(codigo, _ln);
                frm.ShowDialog();
            }
            
        }

        private void BajaEjemplar_Click(object sender, EventArgs e)
        {
            // Abre el formulario para baja de ejemplar
            bool intentarDeNuevo = false;

            do
            {
                intentarDeNuevo = false; // Reiniciamos el flag

                
                frmSolicitarDato frm = new frmSolicitarDato("Introduzca el código del Ejemplar a borrar:");

                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                  
                    if (int.TryParse(frm.ValorIntroducido, out int codigo))
                    {
                        // 3. Comprobar si existe el EJEMPLAR (no el documento)
                        if (_ln.ExisteEjemplar(codigo))
                        {
                            // === ÉXITO ===
                            // Reutilizamos la Plantilla 2 (frmDetalleEjemplar)
                            // Le pasamos el código para que se cargue solo
                            frmDetalleEjemplar detalle = new frmDetalleEjemplar(codigo, _ln,true);
                            detalle.ShowDialog();
                        }
                        else
                        {
                            // === NO EXISTE ===
                           
                            DialogResult respuesta = MessageBox.Show(
                                $"El ejemplar con código {codigo} no existe.\n¿Quieres introducir otro?",
                                "No encontrado",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (respuesta == DialogResult.Yes)
                            {
                                intentarDeNuevo = true; // Vuelve al inicio del bucle
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código debe ser numérico.");
                        intentarDeNuevo = true;
                    }
                }
            } while (intentarDeNuevo);

            
        }
        private void ListadoDocumentos_Click(object sender, EventArgs e)
        {
            var o= _ln.ListadoDocumentos();

            frmListadoDocumentos frm = new frmListadoDocumentos(o,this._ln);
            frm.MdiParent = this;
            frm.Show();
            
        }
        private void RecorridoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lista= _ln.ListadoDocumentos();
            FrmRecorridoDocus frm = new FrmRecorridoDocus(lista);
            frm.MdiParent = this;
            frm.Show();
        }
        private void ListadoEjemplares_Click(object sender, EventArgs e)
        {
            var o = _ln.ListadoEjemplares();
            FrmListadoEjemplares frm = new FrmListadoEjemplares(o);
            frm.MdiParent = this;
            frm.Show();
        }
        private void BusquedaEjemplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitarDato frmCodigo = new frmSolicitarDato("Introduzca el código del Ejemplar:");
            frmCodigo.ShowDialog();
            if (frmCodigo.DialogResult == DialogResult.OK){
                String codigo = frmCodigo.ValorIntroducido;
                if (_ln.ExisteEjemplar(int.Parse(codigo)))
                {
                    frmDetalleEjemplar frm = new frmDetalleEjemplar(int.Parse(codigo), _ln);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existe un ejemplar con ese código");
                }
                
            }
        }
    }
}
