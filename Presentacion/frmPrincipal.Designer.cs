namespace Presentacion
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.altaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorridoUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.altaDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.recorridoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEjemplares = new System.Windows.Forms.ToolStripMenuItem();
            this.altaEjemplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaEjemplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaEjemplarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoEjemplar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrestamos = new System.Windows.Forms.ToolStripMenuItem();
            this.altaPrestamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoPrestamo = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuDocumentos,
            this.menuEjemplares,
            this.menuPrestamos,
            this.menuConfiguracion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaUsuarioToolStripMenuItem,
            this.bajaUsuarioToolStripMenuItem,
            this.busquedaUsuarioToolStripMenuItem,
            this.listadoUsuariosToolStripMenuItem,
            this.recorridoUsuariosToolStripMenuItem});
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(79, 26);
            this.menuUsuarios.Text = "Usuarios";
            // 
            // altaUsuarioToolStripMenuItem
            // 
            this.altaUsuarioToolStripMenuItem.Name = "altaUsuarioToolStripMenuItem";
            this.altaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.altaUsuarioToolStripMenuItem.Text = "Alta";
            this.altaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.altaUsuarioToolStripMenuItem_Click);
            // 
            // bajaUsuarioToolStripMenuItem
            // 
            this.bajaUsuarioToolStripMenuItem.Name = "bajaUsuarioToolStripMenuItem";
            this.bajaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.bajaUsuarioToolStripMenuItem.Text = "Baja";
            this.bajaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.bajaUsuarioToolStripMenuItem_Click);
            // 
            // busquedaUsuarioToolStripMenuItem
            // 
            this.busquedaUsuarioToolStripMenuItem.Name = "busquedaUsuarioToolStripMenuItem";
            this.busquedaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.busquedaUsuarioToolStripMenuItem.Text = "Búsqueda";
            this.busquedaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.busquedaUsuarioToolStripMenuItem_Click);
            // 
            // listadoUsuariosToolStripMenuItem
            // 
            this.listadoUsuariosToolStripMenuItem.Name = "listadoUsuariosToolStripMenuItem";
            this.listadoUsuariosToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.listadoUsuariosToolStripMenuItem.Text = "Listado";
            this.listadoUsuariosToolStripMenuItem.Click += new System.EventHandler(this.listadoUsuariosToolStripMenuItem_Click);
            // 
            // recorridoUsuariosToolStripMenuItem
            // 
            this.recorridoUsuariosToolStripMenuItem.Name = "recorridoUsuariosToolStripMenuItem";
            this.recorridoUsuariosToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.recorridoUsuariosToolStripMenuItem.Text = "Recorrido";
            this.recorridoUsuariosToolStripMenuItem.Click += new System.EventHandler(this.recorridoUsuariosToolStripMenuItem_Click);
            // 
            // menuDocumentos
            // 
            this.menuDocumentos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaDocumentoToolStripMenuItem,
            this.bajaDocumentoToolStripMenuItem,
            this.busquedaDocumentoToolStripMenuItem,
            this.listadoDocumentos,
            this.recorridoToolStripMenuItem});
            this.menuDocumentos.Name = "menuDocumentos";
            this.menuDocumentos.Size = new System.Drawing.Size(107, 26);
            this.menuDocumentos.Text = "Documentos";
            // 
            // altaDocumentoToolStripMenuItem
            // 
            this.altaDocumentoToolStripMenuItem.Name = "altaDocumentoToolStripMenuItem";
            this.altaDocumentoToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.altaDocumentoToolStripMenuItem.Text = "Alta";
            // 
            // bajaDocumentoToolStripMenuItem
            // 
            this.bajaDocumentoToolStripMenuItem.Name = "bajaDocumentoToolStripMenuItem";
            this.bajaDocumentoToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.bajaDocumentoToolStripMenuItem.Text = "Baja";
            // 
            // busquedaDocumentoToolStripMenuItem
            // 
            this.busquedaDocumentoToolStripMenuItem.Name = "busquedaDocumentoToolStripMenuItem";
            this.busquedaDocumentoToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.busquedaDocumentoToolStripMenuItem.Text = "Búsqueda";
            // 
            // listadoDocumentos
            // 
            this.listadoDocumentos.Name = "listadoDocumentos";
            this.listadoDocumentos.Size = new System.Drawing.Size(157, 26);
            this.listadoDocumentos.Text = "Listado";
            // 
            // recorridoToolStripMenuItem
            // 
            this.recorridoToolStripMenuItem.Name = "recorridoToolStripMenuItem";
            this.recorridoToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.recorridoToolStripMenuItem.Text = "Recorrido";
            // 
            // menuEjemplares
            // 
            this.menuEjemplares.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaEjemplarToolStripMenuItem,
            this.bajaEjemplarToolStripMenuItem,
            this.busquedaEjemplarToolStripMenuItem,
            this.listadoEjemplar});
            this.menuEjemplares.Name = "menuEjemplares";
            this.menuEjemplares.Size = new System.Drawing.Size(96, 26);
            this.menuEjemplares.Text = "Ejemplares";
            // 
            // altaEjemplarToolStripMenuItem
            // 
            this.altaEjemplarToolStripMenuItem.Name = "altaEjemplarToolStripMenuItem";
            this.altaEjemplarToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.altaEjemplarToolStripMenuItem.Text = "Alta";
            // 
            // bajaEjemplarToolStripMenuItem
            // 
            this.bajaEjemplarToolStripMenuItem.Name = "bajaEjemplarToolStripMenuItem";
            this.bajaEjemplarToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.bajaEjemplarToolStripMenuItem.Text = "Baja";
            // 
            // busquedaEjemplarToolStripMenuItem
            // 
            this.busquedaEjemplarToolStripMenuItem.Name = "busquedaEjemplarToolStripMenuItem";
            this.busquedaEjemplarToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.busquedaEjemplarToolStripMenuItem.Text = "Búsqueda";
            // 
            // listadoEjemplar
            // 
            this.listadoEjemplar.Name = "listadoEjemplar";
            this.listadoEjemplar.Size = new System.Drawing.Size(157, 26);
            this.listadoEjemplar.Text = "Listado";
            // 
            // menuPrestamos
            // 
            this.menuPrestamos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaPrestamoToolStripMenuItem,
            this.devolucionToolStripMenuItem,
            this.listadoPrestamo,
            this.búsquedaToolStripMenuItem});
            this.menuPrestamos.Name = "menuPrestamos";
            this.menuPrestamos.Size = new System.Drawing.Size(91, 26);
            this.menuPrestamos.Text = "Préstamos";
            // 
            // altaPrestamoToolStripMenuItem
            // 
            this.altaPrestamoToolStripMenuItem.Name = "altaPrestamoToolStripMenuItem";
            this.altaPrestamoToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.altaPrestamoToolStripMenuItem.Text = "Alta";
            // 
            // devolucionToolStripMenuItem
            // 
            this.devolucionToolStripMenuItem.Name = "devolucionToolStripMenuItem";
            this.devolucionToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.devolucionToolStripMenuItem.Text = "Devolución";
            // 
            // listadoPrestamo
            // 
            this.listadoPrestamo.Name = "listadoPrestamo";
            this.listadoPrestamo.Size = new System.Drawing.Size(167, 26);
            this.listadoPrestamo.Text = "Listado";
            // 
            // búsquedaToolStripMenuItem
            // 
            this.búsquedaToolStripMenuItem.Name = "búsquedaToolStripMenuItem";
            this.búsquedaToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.búsquedaToolStripMenuItem.Text = "Búsqueda";
            // 
            // menuConfiguracion
            // 
            this.menuConfiguracion.Name = "menuConfiguracion";
            this.menuConfiguracion.Size = new System.Drawing.Size(116, 26);
            this.menuConfiguracion.Text = "Configuración";
            // 
            // frmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Gestión de Biblioteca";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuDocumentos;
        protected System.Windows.Forms.ToolStripMenuItem menuEjemplares;
        protected System.Windows.Forms.ToolStripMenuItem menuPrestamos; 
        protected System.Windows.Forms.ToolStripMenuItem menuConfiguracion;

        // USUARIOS (Eventos gestionados en el Padre)
        protected System.Windows.Forms.ToolStripMenuItem altaUsuarioToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bajaUsuarioToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem busquedaUsuarioToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem listadoUsuariosToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem recorridoUsuariosToolStripMenuItem;

        // DOCUMENTOS (Eventos gestionados en FPAdquisiciones)
        protected System.Windows.Forms.ToolStripMenuItem altaDocumentoToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bajaDocumentoToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem busquedaDocumentoToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem listadoDocumentos;

        // EJEMPLARES (Eventos gestionados en FPAdquisiciones)
        protected System.Windows.Forms.ToolStripMenuItem altaEjemplarToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bajaEjemplarToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem busquedaEjemplarToolStripMenuItem;

        // PRESTAMOS (Eventos gestionados en frmPersonalSala)
        protected System.Windows.Forms.ToolStripMenuItem altaPrestamoToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem devolucionToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem listadoEjemplar;
        protected System.Windows.Forms.ToolStripMenuItem listadoPrestamo;
        protected System.Windows.Forms.ToolStripMenuItem recorridoToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem búsquedaToolStripMenuItem;
    }
}