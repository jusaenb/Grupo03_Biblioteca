namespace Presentacion
{
    partial class frmListadoUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstDNI;
        private System.Windows.Forms.ListBox lstNombre;
        private System.Windows.Forms.Button btnOrdenDNI;
        private System.Windows.Forms.Button btnOrdenNombre;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblDniHeader;
        private System.Windows.Forms.Label lblNombreHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstDNI = new System.Windows.Forms.ListBox();
            this.lstNombre = new System.Windows.Forms.ListBox();
            this.btnOrdenDNI = new System.Windows.Forms.Button();
            this.btnOrdenNombre = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrdenDNI
            // 
            this.btnOrdenDNI.Location = new System.Drawing.Point(30, 20);
            this.btnOrdenDNI.Name = "btnOrdenDNI";
            this.btnOrdenDNI.Size = new System.Drawing.Size(150, 30);
            this.btnOrdenDNI.TabIndex = 0;
            this.btnOrdenDNI.Text = "Ordenar por DNI";
            this.btnOrdenDNI.UseVisualStyleBackColor = true;
            this.btnOrdenDNI.Click += new System.EventHandler(this.btnOrdenDNI_Click);
            // 
            // btnOrdenNombre
            // 
            this.btnOrdenNombre.Location = new System.Drawing.Point(200, 20);
            this.btnOrdenNombre.Name = "btnOrdenNombre";
            this.btnOrdenNombre.Size = new System.Drawing.Size(200, 30);
            this.btnOrdenNombre.TabIndex = 1;
            this.btnOrdenNombre.Text = "Ordenar por Nombre";
            this.btnOrdenNombre.UseVisualStyleBackColor = true;
            this.btnOrdenNombre.Click += new System.EventHandler(this.btnOrdenNombre_Click);
            // 
            // lstDNI
            // 
            this.lstDNI.FormattingEnabled = true;
            this.lstDNI.Location = new System.Drawing.Point(30, 60);
            this.lstDNI.Name = "lstDNI";
            this.lstDNI.Size = new System.Drawing.Size(150, 264);
            this.lstDNI.TabIndex = 2;
            // 
            // lstNombre
            // 
            this.lstNombre.FormattingEnabled = true;
            this.lstNombre.Location = new System.Drawing.Point(200, 60);
            this.lstNombre.Name = "lstNombre";
            this.lstNombre.Size = new System.Drawing.Size(200, 264);
            this.lstNombre.TabIndex = 3;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(165, 340);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 390);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lstNombre);
            this.Controls.Add(this.lstDNI);
            this.Controls.Add(this.btnOrdenNombre);
            this.Controls.Add(this.btnOrdenDNI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmListadoUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de usuarios";
            this.ResumeLayout(false);
        }
    }
}