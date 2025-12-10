namespace Presentacion
{
    partial class frmDetalleDocumento
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
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblAutor = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.rbAudiolibro = new System.Windows.Forms.RadioButton();
            this.rbLibro = new System.Windows.Forms.RadioButton();
            this.grpAudio = new System.Windows.Forms.GroupBox();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.txtFormato = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpTipo.SuspendLayout();
            this.grpAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(22, 24);
            this.lblISBN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(35, 13);
            this.lblISBN.TabIndex = 0;
            this.lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(75, 22);
            this.txtISBN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.ReadOnly = true;
            this.txtISBN.Size = new System.Drawing.Size(114, 20);
            this.txtISBN.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(22, 57);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(38, 13);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(75, 54);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(264, 20);
            this.txtTitulo.TabIndex = 3;
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(22, 89);
            this.lblAutor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(35, 13);
            this.lblAutor.TabIndex = 4;
            this.lblAutor.Text = "Autor:";
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(75, 87);
            this.txtAutor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(264, 20);
            this.txtAutor.TabIndex = 5;
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Location = new System.Drawing.Point(22, 122);
            this.lblEditorial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(47, 13);
            this.lblEditorial.TabIndex = 6;
            this.lblEditorial.Text = "Editorial:";
            // 
            // txtEditorial
            // 
            this.txtEditorial.Location = new System.Drawing.Point(75, 119);
            this.txtEditorial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.Size = new System.Drawing.Size(151, 20);
            this.txtEditorial.TabIndex = 7;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(240, 122);
            this.lblAno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(29, 13);
            this.lblAno.TabIndex = 8;
            this.lblAno.Text = "Año:";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(270, 119);
            this.txtAno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(68, 20);
            this.txtAno.TabIndex = 9;
            // 
            // grpTipo
            // 
            this.grpTipo.Controls.Add(this.rbAudiolibro);
            this.grpTipo.Controls.Add(this.rbLibro);
            this.grpTipo.Location = new System.Drawing.Point(25, 154);
            this.grpTipo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpTipo.Size = new System.Drawing.Size(313, 49);
            this.grpTipo.TabIndex = 10;
            this.grpTipo.TabStop = false;
            this.grpTipo.Text = "Tipo de Documento";
            // 
            // rbAudiolibro
            // 
            this.rbAudiolibro.AutoSize = true;
            this.rbAudiolibro.Location = new System.Drawing.Point(112, 20);
            this.rbAudiolibro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbAudiolibro.Name = "rbAudiolibro";
            this.rbAudiolibro.Size = new System.Drawing.Size(71, 17);
            this.rbAudiolibro.TabIndex = 1;
            this.rbAudiolibro.Text = "Audiolibro";
            this.rbAudiolibro.UseVisualStyleBackColor = true;
            this.rbAudiolibro.CheckedChanged += new System.EventHandler(this.rbAudiolibro_CheckedChanged);
            // 
            // rbLibro
            // 
            this.rbLibro.AutoSize = true;
            this.rbLibro.Checked = true;
            this.rbLibro.Location = new System.Drawing.Point(22, 20);
            this.rbLibro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbLibro.Name = "rbLibro";
            this.rbLibro.Size = new System.Drawing.Size(48, 17);
            this.rbLibro.TabIndex = 0;
            this.rbLibro.TabStop = true;
            this.rbLibro.Text = "Libro";
            this.rbLibro.UseVisualStyleBackColor = true;
            // 
            // grpAudio
            // 
            this.grpAudio.Controls.Add(this.lblDuracion);
            this.grpAudio.Controls.Add(this.txtDuracion);
            this.grpAudio.Controls.Add(this.lblFormato);
            this.grpAudio.Controls.Add(this.txtFormato);
            this.grpAudio.Location = new System.Drawing.Point(25, 211);
            this.grpAudio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpAudio.Name = "grpAudio";
            this.grpAudio.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpAudio.Size = new System.Drawing.Size(313, 57);
            this.grpAudio.TabIndex = 11;
            this.grpAudio.TabStop = false;
            this.grpAudio.Text = "Datos Audiolibro";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(165, 24);
            this.lblDuracion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(53, 13);
            this.lblDuracion.TabIndex = 2;
            this.lblDuracion.Text = "Duración:";
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(218, 22);
            this.txtDuracion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(76, 20);
            this.txtDuracion.TabIndex = 3;
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(15, 24);
            this.lblFormato.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(48, 13);
            this.lblFormato.TabIndex = 0;
            this.lblFormato.Text = "Formato:";
            // 
            // txtFormato
            // 
            this.txtFormato.Location = new System.Drawing.Point(68, 22);
            this.txtFormato.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFormato.Name = "txtFormato";
            this.txtFormato.Size = new System.Drawing.Size(76, 20);
            this.txtFormato.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(180, 284);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 24);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(262, 284);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 24);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmDetalleDocumento
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(363, 326);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grpAudio);
            this.Controls.Add(this.grpTipo);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.txtEditorial);
            this.Controls.Add(this.lblEditorial);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblISBN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmDetalleDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta de Documento";
            this.grpTipo.ResumeLayout(false);
            this.grpTipo.PerformLayout();
            this.grpAudio.ResumeLayout(false);
            this.grpAudio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.GroupBox grpTipo;
        private System.Windows.Forms.RadioButton rbAudiolibro;
        private System.Windows.Forms.RadioButton rbLibro;
        private System.Windows.Forms.GroupBox grpAudio;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.TextBox txtFormato;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}