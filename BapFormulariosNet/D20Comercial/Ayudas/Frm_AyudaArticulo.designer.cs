namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaArticulo));
            this.dgArticulo = new System.Windows.Forms.DataGridView();
            this.linea_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomb_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unid_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.cmbtipoalmacen = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.chktipoalmacen = new System.Windows.Forms.CheckBox();
            this.chkalmacen = new System.Windows.Forms.CheckBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cbAlmacen = new System.Windows.Forms.ComboBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulo)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgArticulo
            // 
            this.dgArticulo.AllowUserToAddRows = false;
            this.dgArticulo.AllowUserToDeleteRows = false;
            this.dgArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.linea_17,
            this.nomb_17,
            this.unid_17});
            this.dgArticulo.Location = new System.Drawing.Point(8, 90);
            this.dgArticulo.MultiSelect = false;
            this.dgArticulo.Name = "dgArticulo";
            this.dgArticulo.ReadOnly = true;
            this.dgArticulo.RowHeadersWidth = 34;
            this.dgArticulo.RowTemplate.Height = 20;
            this.dgArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgArticulo.Size = new System.Drawing.Size(629, 408);
            this.dgArticulo.TabIndex = 33;
            // 
            // linea_17
            // 
            this.linea_17.DataPropertyName = "linea_17";
            this.linea_17.HeaderText = "Código";
            this.linea_17.Name = "linea_17";
            this.linea_17.ReadOnly = true;
            this.linea_17.Width = 150;
            // 
            // nomb_17
            // 
            this.nomb_17.DataPropertyName = "nomb_17";
            this.nomb_17.HeaderText = "Descripción";
            this.nomb_17.Name = "nomb_17";
            this.nomb_17.ReadOnly = true;
            this.nomb_17.Width = 350;
            // 
            // unid_17
            // 
            this.unid_17.DataPropertyName = "unid_17";
            this.unid_17.HeaderText = "UMD";
            this.unid_17.Name = "unid_17";
            this.unid_17.ReadOnly = true;
            this.unid_17.Width = 70;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CheckBox2);
            this.GroupBox1.Controls.Add(this.CheckBox1);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.cmbtipoalmacen);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.chktipoalmacen);
            this.GroupBox1.Controls.Add(this.chkalmacen);
            this.GroupBox1.Controls.Add(this.txtBusqueda);
            this.GroupBox1.Controls.Add(this.lblAlmacen);
            this.GroupBox1.Controls.Add(this.cbAlmacen);
            this.GroupBox1.Location = new System.Drawing.Point(8, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(629, 85);
            this.GroupBox1.TabIndex = 32;
            this.GroupBox1.TabStop = false;
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CheckBox2.Location = new System.Drawing.Point(194, 38);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(197, 17);
            this.CheckBox2.TabIndex = 11;
            this.CheckBox2.Text = "Buscar Ocurrencias en Descripción :";
            this.CheckBox2.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.CheckBox1.Location = new System.Drawing.Point(6, 38);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(176, 17);
            this.CheckBox1.TabIndex = 10;
            this.CheckBox1.Text = "Buscar Ocurrencias en Código :";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // txtcodigo
            // 
            this.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigo.Location = new System.Drawing.Point(6, 58);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(160, 21);
            this.txtcodigo.TabIndex = 6;
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(537, 51);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(82, 27);
            this.btnrefrescar.TabIndex = 9;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            // 
            // cmbtipoalmacen
            // 
            this.cmbtipoalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoalmacen.FormattingEnabled = true;
            this.cmbtipoalmacen.Location = new System.Drawing.Point(440, 11);
            this.cmbtipoalmacen.Name = "cmbtipoalmacen";
            this.cmbtipoalmacen.Size = new System.Drawing.Size(179, 21);
            this.cmbtipoalmacen.TabIndex = 4;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(59, -74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(90, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Buscar por Item :";
            this.Label3.Visible = false;
            // 
            // chktipoalmacen
            // 
            this.chktipoalmacen.AutoSize = true;
            this.chktipoalmacen.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chktipoalmacen.Location = new System.Drawing.Point(387, 13);
            this.chktipoalmacen.Name = "chktipoalmacen";
            this.chktipoalmacen.Size = new System.Drawing.Size(46, 17);
            this.chktipoalmacen.TabIndex = 3;
            this.chktipoalmacen.Text = "Tipo";
            this.chktipoalmacen.UseVisualStyleBackColor = true;
            // 
            // chkalmacen
            // 
            this.chkalmacen.AutoSize = true;
            this.chkalmacen.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkalmacen.Location = new System.Drawing.Point(6, 15);
            this.chkalmacen.Name = "chkalmacen";
            this.chkalmacen.Size = new System.Drawing.Size(66, 17);
            this.chkalmacen.TabIndex = 0;
            this.chkalmacen.Text = "Almacén";
            this.chkalmacen.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.Location = new System.Drawing.Point(194, 58);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(335, 21);
            this.txtBusqueda.TabIndex = 8;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlmacen.Enabled = false;
            this.lblAlmacen.Location = new System.Drawing.Point(349, 13);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(32, 21);
            this.lblAlmacen.TabIndex = 2;
            // 
            // cbAlmacen
            // 
            this.cbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlmacen.FormattingEnabled = true;
            this.cbAlmacen.Location = new System.Drawing.Point(79, 13);
            this.cbAlmacen.Name = "cbAlmacen";
            this.cbAlmacen.Size = new System.Drawing.Size(257, 21);
            this.cbAlmacen.TabIndex = 1;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(229, 495);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 34;
            this.GroupBox4.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(5, 10);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            // 
            // Frm_AyudaArticulo
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 535);
            this.Controls.Add(this.dgArticulo);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaArticulo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda Artículos >>";
            this.Load += new System.EventHandler(this.Frm_AyudaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulo)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgArticulo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn linea_17;
        internal System.Windows.Forms.DataGridViewTextBoxColumn nomb_17;
        internal System.Windows.Forms.DataGridViewTextBoxColumn unid_17;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.ComboBox cmbtipoalmacen;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.CheckBox chktipoalmacen;
        internal System.Windows.Forms.CheckBox chkalmacen;
        internal System.Windows.Forms.TextBox txtBusqueda;
        internal System.Windows.Forms.Label lblAlmacen;
        internal System.Windows.Forms.ComboBox cbAlmacen;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
    }
}