namespace Presentacion
{
    partial class frmAltaPrestamo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.GroupBox grpEjemplares;
        private System.Windows.Forms.ListBox lstEjemplares;
        private System.Windows.Forms.Button btnAnadirEjemplar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.grpEjemplares = new System.Windows.Forms.GroupBox();
            this.lstEjemplares = new System.Windows.Forms.ListBox();
            this.btnAnadirEjemplar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpEjemplares.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(40, 30);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 16);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(100, 27);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(120, 22);
            this.txtID.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(40, 70);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(48, 16);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(100, 67);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(120, 22);
            this.txtFecha.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(40, 110);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(57, 16);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario:";
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(100, 107);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(200, 24);
            this.cmbUsuarios.TabIndex = 5;
            // 
            // grpEjemplares
            // 
            this.grpEjemplares.Controls.Add(this.lstEjemplares);
            this.grpEjemplares.Location = new System.Drawing.Point(320, 20);
            this.grpEjemplares.Name = "grpEjemplares";
            this.grpEjemplares.Size = new System.Drawing.Size(300, 200);
            this.grpEjemplares.TabIndex = 6;
            this.grpEjemplares.TabStop = false;
            this.grpEjemplares.Text = "Ejemplares añadidos";
            // 
            // lstEjemplares
            // 
            this.lstEjemplares.FormattingEnabled = true;
            this.lstEjemplares.ItemHeight = 16;
            this.lstEjemplares.Location = new System.Drawing.Point(15, 30);
            this.lstEjemplares.Name = "lstEjemplares";
            this.lstEjemplares.Size = new System.Drawing.Size(270, 148);
            this.lstEjemplares.TabIndex = 0;
            // 
            // btnAnadirEjemplar
            // 
            this.btnAnadirEjemplar.Location = new System.Drawing.Point(43, 160);
            this.btnAnadirEjemplar.Name = "btnAnadirEjemplar";
            this.btnAnadirEjemplar.Size = new System.Drawing.Size(150, 30);
            this.btnAnadirEjemplar.TabIndex = 7;
            this.btnAnadirEjemplar.Text = "Añadir ejemplar";
            this.btnAnadirEjemplar.UseVisualStyleBackColor = true;
            this.btnAnadirEjemplar.Click += new System.EventHandler(this.btnAnadirEjemplar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(220, 250);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 35);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(340, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmAltaPrestamo
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(650, 310);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnAnadirEjemplar);
            this.Controls.Add(this.grpEjemplares);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaPrestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta de un préstamo";
            this.grpEjemplares.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}