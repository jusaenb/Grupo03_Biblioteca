using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Logica_Negocio;
using MD;

namespace Presentacion
{
    public partial class frmBusquedaUsuario : Form
    {
        private ILNPersonal _ln;

        // Constructor: Ya NO necesitamos pasarle el DNI, porque lo elegiremos dentro
        public frmBusquedaUsuario(ILNPersonal ln)
        {
            InitializeComponent();
            _ln = ln;
        }

        private void frmBusquedaUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener la lista de TODOS los usuarios para llenar el desplegable
                // Asegúrate de tener un método ListadoUsuarios() en tu LN
                List<Usuario> listaUsuarios = _ln.ListadoUsuarios();

                // Configurar el ComboBox
                cmbDni.DataSource = listaUsuarios;
                cmbDni.DisplayMember = "Dni"; // Mostramos el DNI
                cmbDni.ValueMember = "Dni";   // El valor interno también es el DNI

                // Dejamos el combo sin seleccionar nada al principio
                cmbDni.SelectedIndex = -1;
                txtNombre.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }

            // Ocultar panel de préstamos si es Adquisiciones (igual que antes)
            if (!(_ln is ILNPersonalSala))
            {
                lblPrestamos.Visible = false;
                lstPrestamos.Visible = false;
                this.Height = 200;
            }
        }

        // Este evento salta cuando el usuario elige un DNI de la lista
        private void cmbDni_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si no hay nada seleccionado, no hacemos nada
            if (cmbDni.SelectedIndex == -1) return;

            // Recuperamos el objeto Usuario seleccionado (el ComboBox lo guarda entero)
            Usuario usuarioSeleccionado = (Usuario)cmbDni.SelectedItem;

            // 1. Rellenar Nombre
            txtNombre.Text = usuarioSeleccionado.Nombre;

            // 2. Rellenar Préstamos (Solo si es Sala)
            if (_ln is ILNPersonalSala lnSala)
            {
                CargarPrestamos(lnSala, usuarioSeleccionado.Dni);
            }
        }

        private void CargarPrestamos(ILNPersonalSala lnSala, string dni)
        {
            lstPrestamos.Items.Clear();

            // Usamos LINQ para filtrar los préstamos activos de ESTE usuario concreto
            var prestamosActivos = lnSala.ListadoPrestamosActivos()
                                         .Where(p => p.Usuario.Dni == dni && p.Estado == "En Proceso")
                                         .ToList();

            if (prestamosActivos.Count > 0)
            {
                foreach (Prestamo p in prestamosActivos)
                {
                    string libros = string.Join(", ", p.Ejemplares.Select(ej => ej.CodigoEjemplar));
                    lstPrestamos.Items.Add($"{p.FechaPrestamo.ToShortDateString()} - {libros}");
                }
            }
            else
            {
                lstPrestamos.Items.Add("No tiene préstamos activos.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}