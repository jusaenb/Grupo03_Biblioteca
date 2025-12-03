namespace Presentacion
{
    partial class FLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.radioButtonPersonalSala = new System.Windows.Forms.RadioButton();
            this.radioButtonPersonalAdquisiciones = new System.Windows.Forms.RadioButton();
            this.buttonEntrar = new System.Windows.Forms.Button();
            this.groupBoxTipoEmpleado = new System.Windows.Forms.GroupBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.groupBoxTipoEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(52, 47);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(76, 20);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(203, 47);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 1;
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseña.Location = new System.Drawing.Point(52, 136);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(107, 20);
            this.labelContraseña.TabIndex = 2;
            this.labelContraseña.Text = "Contraseña:";
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(203, 135);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(100, 20);
            this.textBoxContraseña.TabIndex = 3;
            // 
            // radioButtonPersonalSala
            // 
            this.radioButtonPersonalSala.AutoSize = true;
            this.radioButtonPersonalSala.Location = new System.Drawing.Point(18, 28);
            this.radioButtonPersonalSala.Name = "radioButtonPersonalSala";
            this.radioButtonPersonalSala.Size = new System.Drawing.Size(88, 17);
            this.radioButtonPersonalSala.TabIndex = 5;
            this.radioButtonPersonalSala.TabStop = true;
            this.radioButtonPersonalSala.Text = "Personal sala";
            this.radioButtonPersonalSala.UseVisualStyleBackColor = true;
            // 
            // radioButtonPersonalAdquisiciones
            // 
            this.radioButtonPersonalAdquisiciones.AutoSize = true;
            this.radioButtonPersonalAdquisiciones.Location = new System.Drawing.Point(18, 62);
            this.radioButtonPersonalAdquisiciones.Name = "radioButtonPersonalAdquisiciones";
            this.radioButtonPersonalAdquisiciones.Size = new System.Drawing.Size(133, 17);
            this.radioButtonPersonalAdquisiciones.TabIndex = 6;
            this.radioButtonPersonalAdquisiciones.TabStop = true;
            this.radioButtonPersonalAdquisiciones.Text = "Personal adquisiciones";
            this.radioButtonPersonalAdquisiciones.UseVisualStyleBackColor = true;
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Location = new System.Drawing.Point(228, 339);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(75, 23);
            this.buttonEntrar.TabIndex = 7;
            this.buttonEntrar.Text = "Entrar";
            this.buttonEntrar.UseVisualStyleBackColor = true;
            this.buttonEntrar.Click += new System.EventHandler(this.buttonEntrar_Click);
            // 
            // groupBoxTipoEmpleado
            // 
            this.groupBoxTipoEmpleado.Controls.Add(this.radioButtonPersonalSala);
            this.groupBoxTipoEmpleado.Controls.Add(this.radioButtonPersonalAdquisiciones);
            this.groupBoxTipoEmpleado.Location = new System.Drawing.Point(75, 193);
            this.groupBoxTipoEmpleado.Name = "groupBoxTipoEmpleado";
            this.groupBoxTipoEmpleado.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTipoEmpleado.TabIndex = 8;
            this.groupBoxTipoEmpleado.TabStop = false;
            this.groupBoxTipoEmpleado.Text = "Tipo empleado";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNI.Location = new System.Drawing.Point(52, 92);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(45, 20);
            this.labelDNI.TabIndex = 9;
            this.labelDNI.Text = "DNI:";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(203, 92);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(100, 20);
            this.textBoxDNI.TabIndex = 10;
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 392);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.groupBoxTipoEmpleado);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelNombre);
            this.Name = "FLogin";
            this.Text = "Loguearse";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FLogin_KeyDown);
            this.groupBoxTipoEmpleado.ResumeLayout(false);
            this.groupBoxTipoEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.RadioButton radioButtonPersonalSala;
        private System.Windows.Forms.RadioButton radioButtonPersonalAdquisiciones;
        private System.Windows.Forms.Button buttonEntrar;
        private System.Windows.Forms.GroupBox groupBoxTipoEmpleado;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxDNI;
    }
}

