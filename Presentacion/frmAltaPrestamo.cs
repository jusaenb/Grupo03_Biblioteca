using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LN;
using Logica_Negocio;
using MD;

namespace Presentacion
{
    public partial class frmAltaPrestamo : Form
    {
        private ILNPersonalSala _ln;
        private List<int> _codigosEjemplaresSeleccionados;
        private int _posicionY = 20;

        public frmAltaPrestamo(ILNPersonalSala ln,int n)
        {
            InitializeComponent();
            _ln = ln;
            _codigosEjemplaresSeleccionados = new List<int>();

           Prestamo p2 = _ln.ListadoPrestamosActivos().FirstOrDefault(p=>p.Identi==n.ToString());
            if (p2 != null)
            {
                Iniciarformulario2(p2);
            }
            else
            {
                InicializarFormulario();
            }
               
        }

        private void InicializarFormulario()
        {
            // Poner fecha actual
            txtFecha.Text = DateTime.Now.ToShortDateString();

            // Cargar usuarios en el ComboBox
            try
            {
                cmbUsuarios.DataSource = _ln.ListadoUsuarios();
                cmbUsuarios.DisplayMember = "Nombre"; // Mostramos DNI según PDF
                cmbUsuarios.ValueMember = "Dni";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }
        private void Iniciarformulario2(Prestamo p)
        {
            txtID.Text = p.Identi;
            txtID.ReadOnly = true;
            txtFecha.Text = p.FechaPrestamo.ToString();
              cmbUsuarios.DataSource = new List<Usuario> { p.Usuario };
            cmbUsuarios.DisplayMember = "Dni";
            cmbUsuarios.ValueMember = "Dni";
            btnAnadirEjemplar.Click -= btnAnadirEjemplar_Click;
            btnAnadirEjemplar.Visible = false;

         

            foreach (Ejemplar e in p.Ejemplares)
            {
                Label l1 = new Label();
                l1.Text = "ID" + e.CodigoEjemplar.ToString();
                l1.AutoSize = true;
                l1.Location = new System.Drawing.Point(10, this._posicionY + 3);
                grpEjemplares.Controls.Add(l1);

                TextBox txt = new TextBox();
                txt.Text = e.Documento.Titulo;
                txt.ReadOnly = true;
                txt.Location = new System.Drawing.Point(60, _posicionY);
                txt.Width = 140;
                grpEjemplares.Controls.Add(txt);

                RadioButton radio = new RadioButton();
                radio.Text = "Prestado";
                radio.Checked = true;
                radio.AutoSize = true;
                radio.Location = new System.Drawing.Point(220, _posicionY);
                grpEjemplares.Controls.Add(radio);

                Label lblFechaDevolucion = new Label();
                lblFechaDevolucion.Text = "Devolución: " + p.CalcularFechaDevolucion(e).ToShortDateString();
                lblFechaDevolucion.AutoSize = true;
                lblFechaDevolucion.Location = new System.Drawing.Point(320, _posicionY);
                grpEjemplares.Controls.Add(lblFechaDevolucion);

                _posicionY += 30;
            }
             btnAceptar.Click-=btnAceptar_Click;
            btnAceptar.Click += (s, e) =>
            {
                this.Close();
            };
        }

        private void btnAnadirEjemplar_Click(object sender, EventArgs e)
        {
            frmEjemplaresDisponbiles frm = new frmEjemplaresDisponbiles(_ln,_codigosEjemplaresSeleccionados);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Ejemplar ej = frm.EjemplarSeleccionado;
                cmbUsuarios.Enabled = false; 
                if (ej != null)
                {
                    if (!_codigosEjemplaresSeleccionados.Contains(ej.CodigoEjemplar))
                    {
                        _codigosEjemplaresSeleccionados.Add(ej.CodigoEjemplar);

                        // 1. Label (ID)
                        Label lbl = new Label();
                        lbl.Text = $"ID {ej.CodigoEjemplar}:";
                        lbl.AutoSize = true;
                        lbl.Location = new System.Drawing.Point(6, _posicionY + 3); // Un poco más a la izquierda
                        grpEjemplares.Controls.Add(lbl);

                        // 2. TextBox (Título) -> HACERLO MÁS PEQUEÑO
                        TextBox txt = new TextBox();
                        txt.Text = ej.Documento.Titulo;
                        txt.ReadOnly = true;
                        // CAMBIO 1: Anchura reducida de 200 a 130 para que quepa el botón
                        txt.Width = 130;
                        // CAMBIO 2: Posición X=75 para pegarlo un poco más a la label
                        txt.Location = new System.Drawing.Point(50, _posicionY);
                        grpEjemplares.Controls.Add(txt);

                        
                        RadioButton rb = new RadioButton();
                        rb.Text = "Prestado"; // Texto corto para que quepa
                        rb.Checked = true;
                        rb.Enabled = false;
                        rb.AutoSize = true; // Importante para que se vea el texto entero
                                           
                        rb.Location = new System.Drawing.Point(192, _posicionY);
                        grpEjemplares.Controls.Add(rb);

                        // Bajamos el puntero
                        _posicionY += 30;
                    }
                    else
                    {
                        MessageBox.Show("Este ejemplar ya está en la lista.");
                    }
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            if (_codigosEjemplaresSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe añadir al menos un ejemplar.");
                return;
            }

            

            try
            {
                string dniUsuario = (string)cmbUsuarios.SelectedValue;

                // Llamada a la lógica
                _ln.DarAltaPrestamo(dniUsuario, _codigosEjemplaresSeleccionados,txtID.Text);

                MessageBox.Show("Préstamo realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}