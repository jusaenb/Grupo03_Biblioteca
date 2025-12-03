namespace Presentacion
{
    partial class frmAltaPrestamo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpUsuario = new System.Windows.Forms.GroupBox();
            this.txtDniUsuario = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.grpEjemplares = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lstEjemplares = new System.Windows.Forms.ListBox();
            this.txtCodigoEjemplar = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpUsuario.SuspendLayout();
            this.grpEjemplares.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUsuario
            // 
            this.grpUsuario.Controls.Add(this.txtDniUsuario);
            this.grpUsuario.Controls.Add(this.lblDni);
            this.grpUsuario.Location = new System.Drawing.Point(20, 20);
            this.grpUsuario.Name = "grpUsuario";
            this.grpUsuario.Size = new System.Drawing.Size(400, 80);
            this.grpUsuario.TabIndex = 0;
            this.grpUsuario.TabStop = false;
            this.grpUsuario.Text = "Datos del Usuario";
            // 
            // txtDniUsuario
            // 
            this.txtDniUsuario.Location = new System.Drawing.Point(100, 30);
            this.txtDniUsuario.Name = "txtDniUsuario";
            this.txtDniUsuario.Size = new System.Drawing.Size(200, 22);
            this.txtDniUsuario.TabIndex = 1;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(20, 33);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(33, 16);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            // 
            // grpEjemplares
            // 
            this.grpEjemplares.Controls.Add(this.btnAgregar);
            this.grpEjemplares.Controls.Add(this.lstEjemplares);
            this.grpEjemplares.Controls.Add(this.txtCodigoEjemplar);
            this.grpEjemplares.Controls.Add(this.lblCodigo);
            this.grpEjemplares.Location = new System.Drawing.Point(20, 120);
            this.grpEjemplares.Name = "grpEjemplares";
            this.grpEjemplares.Size = new System.Drawing.Size(400, 200);
            this.grpEjemplares.TabIndex = 1;
            this.grpEjemplares.TabStop = false;
            this.grpEjemplares.Text = "Selección de Ejemplares";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(280, 28);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 26);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Añadir";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lstEjemplares
            // 
            this.lstEjemplares.FormattingEnabled = true;
            this.lstEjemplares.ItemHeight = 16;
            this.lstEjemplares.Location = new System.Drawing.Point(23, 70);
            this.lstEjemplares.Name = "lstEjemplares";
            this.lstEjemplares.Size = new System.Drawing.Size(357, 116);
            this.lstEjemplares.TabIndex = 4;
            // 
            // txtCodigoEjemplar
            // 
            this.txtCodigoEjemplar.Location = new System.Drawing.Point(140, 30);
            this.txtCodigoEjemplar.Name = "txtCodigoEjemplar";
            this.txtCodigoEjemplar.Size = new System.Drawing.Size(120, 22);
            this.txtCodigoEjemplar.TabIndex = 2;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 33);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(108, 16);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código Ejemplar:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(210, 340);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 35);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Realizar Préstamo";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(320, 340);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmAltaPrestamo
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(444, 401);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grpEjemplares);
            this.Controls.Add(this.grpUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaPrestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Préstamo";
            this.grpUsuario.ResumeLayout(false);
            this.grpUsuario.PerformLayout();
            this.grpEjemplares.ResumeLayout(false);
            this.grpEjemplares.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUsuario;
        private System.Windows.Forms.TextBox txtDniUsuario;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.GroupBox grpEjemplares;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lstEjemplares;
        private System.Windows.Forms.TextBox txtCodigoEjemplar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}