using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LN;
using Logica_Negocio;
using MD;

namespace Presentacion
{
    public partial class frmDetalleEjemplar : Form
    {
        private int _codigoEjemplar;
        private ILNPersonalAdquisiciones _ln;
        private bool borrar;

        // Constructor privado para el diseñador
        private frmDetalleEjemplar()
        {
            InitializeComponent();
        }

        // Constructor principal
        public frmDetalleEjemplar(int codigo, ILNPersonalAdquisiciones ln, bool borrar = false)
        {
            InitializeComponent();
            _codigoEjemplar = codigo;
            _ln = ln;
            this.borrar = borrar;
            Configurar();
        }
        private void Configurar()
        {
            Ejemplar ejemplar = _ln.ObtenerEjemplar(_codigoEjemplar);
            txtCodigo.Text = _codigoEjemplar.ToString();
            txtPersonal.Text = _ln.getNombre();
            txtPersonal.ReadOnly = true;
            txtCodigo.ReadOnly = true;
            if (ejemplar == null)
            {
               this.Text = "Alta de Ejemplar";
                var lista= _ln.ListadoDocumentos();
                
                cmbDocumentos.DataSource = lista;
                cmbDocumentos.DisplayMember = "Titulo";
                cmbDocumentos.ValueMember = "Isbn";
                cmbDocumentos.Format+= (s, e) =>
                {
                    Documento doc = (Documento)e.ListItem;
                    e.Value = doc.Isbn+" "+ doc.Titulo;
                 
                };
                btnAceptar.Click += (s, e) =>
                {
                    Documento d = (Documento)cmbDocumentos.SelectedItem;
                    try
                    {
                        _ln.DarAltaEjemplar(_codigoEjemplar, d.Isbn);
                        MessageBox.Show("Ejemplar dado de alta correctamente.");
                        this.DialogResult = DialogResult.OK;
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al dar de alta el ejemplar: {ex.Message}");
                    }
                };
            }
            else
            {
                Documento d = ejemplar.Documento;
                cmbDocumentos.DataSource = new List<Documento> { d };
                cmbDocumentos.Format += (s, e) =>
                {
                    Documento doc = (Documento)e.ListItem;
                    e.Value = doc.Isbn + " " + doc.Titulo;
                };
                RadioButton radio = new RadioButton();
                radio.Location = new System.Drawing.Point(33, 140);
                radio.Text = "Disponible";
                radio.Checked = ejemplar.Disponible; 
                radio.AutoCheck = false;
                this.Controls.Add(radio);
                if (borrar)
                {
                  
                   this.Text = "Baja de Ejemplar";
                   this.lblPersonal.Text = "Baja realizada por:";
                   this.btnAceptar.Text = "Dar de Baja";
                    this.btnAceptar.Click += (s, e) =>
                    {
                        if (radio.Checked)
                        {
                            try
                            {
                                _ln.DarBajaLogicaEjemplar(_codigoEjemplar);
                                MessageBox.Show("Ejemplar dado de baja correctamente.");
                                this.DialogResult = DialogResult.OK;
                                return;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al dar de baja el ejemplar: {ex.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede dar de baja un ejemplar que no está disponible (prestado).");
                        }
                        
                    };
                }
                else
                {
                    this.Text = "Detalle de Ejemplar";
                    this.lblPersonal.Text = "Búsqueda realizada por:";
                    this.btnAceptar.Text = "Aceptar";
                    this.btnAceptar.Click += (s, e) =>
                    {
                        this.DialogResult = DialogResult.OK;
                        return;
                    };

                }

            }

        }

        
    }
}