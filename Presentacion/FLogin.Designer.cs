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
            this.labelNombre.Location = new System.Drawing.Point(69, 58);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(94, 25);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(271, 58);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(132, 22);
            this.textBoxNombre.TabIndex = 1;
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseña.Location = new System.Drawing.Point(69, 167);
            this.labelContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(131, 25);
            this.labelContraseña.TabIndex = 2;
            this.labelContraseña.Text = "Contraseña:";
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(271, 166);
            this.textBoxContraseña.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.PasswordChar = '*';
            this.textBoxContraseña.Size = new System.Drawing.Size(132, 22);
            this.textBoxContraseña.TabIndex = 3;
            // 
            // radioButtonPersonalSala
            // 
            this.radioButtonPersonalSala.AutoSize = true;
            this.radioButtonPersonalSala.Location = new System.Drawing.Point(24, 34);
            this.radioButtonPersonalSala.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonPersonalSala.Name = "radioButtonPersonalSala";
            this.radioButtonPersonalSala.Size = new System.Drawing.Size(111, 20);
            this.radioButtonPersonalSala.TabIndex = 5;
            this.radioButtonPersonalSala.TabStop = true;
            this.radioButtonPersonalSala.Text = "Personal sala";
            this.radioButtonPersonalSala.UseVisualStyleBackColor = true;
            // 
            // radioButtonPersonalAdquisiciones
            // 
            this.radioButtonPersonalAdquisiciones.AutoSize = true;
            this.radioButtonPersonalAdquisiciones.Location = new System.Drawing.Point(24, 76);
            this.radioButtonPersonalAdquisiciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonPersonalAdquisiciones.Name = "radioButtonPersonalAdquisiciones";
            this.radioButtonPersonalAdquisiciones.Size = new System.Drawing.Size(169, 20);
            this.radioButtonPersonalAdquisiciones.TabIndex = 6;
            this.radioButtonPersonalAdquisiciones.TabStop = true;
            this.radioButtonPersonalAdquisiciones.Text = "Personal adquisiciones";
            this.radioButtonPersonalAdquisiciones.UseVisualStyleBackColor = true;
            // 
            // buttonEntrar
            // 
            this.buttonEntrar.Location = new System.Drawing.Point(304, 417);
            this.buttonEntrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEntrar.Name = "buttonEntrar";
            this.buttonEntrar.Size = new System.Drawing.Size(100, 28);
            this.buttonEntrar.TabIndex = 7;
            this.buttonEntrar.Text = "Entrar";
            this.buttonEntrar.UseVisualStyleBackColor = true;
            this.buttonEntrar.Click += new System.EventHandler(this.buttonEntrar_Click);
            // 
            // groupBoxTipoEmpleado
            // 
            this.groupBoxTipoEmpleado.Controls.Add(this.radioButtonPersonalSala);
            this.groupBoxTipoEmpleado.Controls.Add(this.radioButtonPersonalAdquisiciones);
            this.groupBoxTipoEmpleado.Location = new System.Drawing.Point(100, 238);
            this.groupBoxTipoEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTipoEmpleado.Name = "groupBoxTipoEmpleado";
            this.groupBoxTipoEmpleado.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTipoEmpleado.Size = new System.Drawing.Size(267, 123);
            this.groupBoxTipoEmpleado.TabIndex = 8;
            this.groupBoxTipoEmpleado.TabStop = false;
            this.groupBoxTipoEmpleado.Text = "Tipo empleado";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNI.Location = new System.Drawing.Point(69, 113);
            this.labelDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(55, 25);
            this.labelDNI.TabIndex = 9;
            this.labelDNI.Text = "DNI:";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(271, 113);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(132, 22);
            this.textBoxDNI.TabIndex = 10;
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 482);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.groupBoxTipoEmpleado);
            this.Controls.Add(this.buttonEntrar);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelNombre);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

