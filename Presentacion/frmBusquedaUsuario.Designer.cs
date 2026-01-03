namespace Presentacion
{
    partial class frmBusquedaUsuario
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
            this.lblDni = new System.Windows.Forms.Label();
            this.cmbDni = new System.Windows.Forms.ComboBox(); // Cambio importante: ComboBox
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrestamos = new System.Windows.Forms.Label();
            this.lstPrestamos = new System.Windows.Forms.ListBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(40, 40);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(35, 17);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            // 
            // cmbDni
            // 
            this.cmbDni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Para que solo puedan seleccionar
            this.cmbDni.FormattingEnabled = true;
            this.cmbDni.Location = new System.Drawing.Point(120, 37);
            this.cmbDni.Name = "cmbDni";
            this.cmbDni.Size = new System.Drawing.Size(200, 24);
            this.cmbDni.TabIndex = 1;
            this.cmbDni.SelectedIndexChanged += new System.EventHandler(this.cmbDni_SelectedIndexChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(40, 90);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 17);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 87);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true; // Solo lectura
            this.txtNombre.Size = new System.Drawing.Size(250, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // lblPrestamos
            // 
            this.lblPrestamos.AutoSize = true;
            this.lblPrestamos.Location = new System.Drawing.Point(40, 140);
            this.lblPrestamos.Name = "lblPrestamos";
            this.lblPrestamos.Size = new System.Drawing.Size(188, 17);
            this.lblPrestamos.TabIndex = 4;
            this.lblPrestamos.Text = "Estado / Préstamos activos:";
            // 
            // lstPrestamos
            // 
            this.lstPrestamos.FormattingEnabled = true;
            this.lstPrestamos.ItemHeight = 16;
            this.lstPrestamos.Location = new System.Drawing.Point(43, 170);
            this.lstPrestamos.Name = "lstPrestamos";
            this.lstPrestamos.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstPrestamos.Size = new System.Drawing.Size(327, 116);
            this.lstPrestamos.TabIndex = 5;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(150, 310);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmBusquedaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 360);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lstPrestamos);
            this.Controls.Add(this.lblPrestamos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.cmbDni);
            this.Controls.Add(this.lblDni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmBusquedaUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Búsqueda de usuario";
            this.Load += new System.EventHandler(this.frmBusquedaUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.ComboBox cmbDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrestamos;
        private System.Windows.Forms.ListBox lstPrestamos;
        private System.Windows.Forms.Button btnCerrar;
    }
}