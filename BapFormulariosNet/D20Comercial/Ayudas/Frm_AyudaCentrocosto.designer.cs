namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaCentrocosto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaCentrocosto));
            this.txttotregistrosanaliticos = new System.Windows.Forms.TextBox();
            this.lblanalitico = new System.Windows.Forms.Label();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.cencosid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosdivi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosanalitica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sigla_a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcuenta = new System.Windows.Forms.TextBox();
            this.chkclasecuenta = new System.Windows.Forms.CheckBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.chkcodigolike = new System.Windows.Forms.CheckBox();
            this.txtcodigolike = new System.Windows.Forms.TextBox();
            this.chkdescriplike = new System.Windows.Forms.CheckBox();
            this.txtdescriplike = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.lblregseleccionado = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txttotregistrosanaliticos
            // 
            this.txttotregistrosanaliticos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttotregistrosanaliticos.Location = new System.Drawing.Point(446, 435);
            this.txttotregistrosanaliticos.Name = "txttotregistrosanaliticos";
            this.txttotregistrosanaliticos.Size = new System.Drawing.Size(60, 21);
            this.txttotregistrosanaliticos.TabIndex = 12;
            this.txttotregistrosanaliticos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblanalitico
            // 
            this.lblanalitico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblanalitico.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblanalitico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanalitico.ForeColor = System.Drawing.Color.Black;
            this.lblanalitico.Location = new System.Drawing.Point(471, 417);
            this.lblanalitico.Name = "lblanalitico";
            this.lblanalitico.Size = new System.Drawing.Size(193, 13);
            this.lblanalitico.TabIndex = 11;
            this.lblanalitico.Text = "C.COSTO ANALITICO";
            this.lblanalitico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblanalitico.Visible = false;
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            this.dgProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProveedor.ColumnHeadersHeight = 22;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cencosid,
            this.cencosname,
            this.cencosdivi,
            this.cencosanalitica,
            this.sigla_a,
            this.status});
            this.dgProveedor.Location = new System.Drawing.Point(7, 85);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            this.dgProveedor.RowHeadersWidth = 24;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(662, 338);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellContentDoubleClick);
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_ColumnHeaderMouseClick);
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.SelectionChanged += new System.EventHandler(this.dgProveedor_SelectionChanged);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // cencosid
            // 
            this.cencosid.DataPropertyName = "cencosid";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cencosid.HeaderText = "Código C.C.";
            this.cencosid.Name = "cencosid";
            this.cencosid.ReadOnly = true;
            this.cencosid.Width = 90;
            // 
            // cencosname
            // 
            this.cencosname.DataPropertyName = "cencosname";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosname.DefaultCellStyle = dataGridViewCellStyle3;
            this.cencosname.HeaderText = "Descripción";
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Width = 360;
            // 
            // cencosdivi
            // 
            this.cencosdivi.DataPropertyName = "cencosdivi";
            this.cencosdivi.HeaderText = "Cuenta";
            this.cencosdivi.Name = "cencosdivi";
            this.cencosdivi.ReadOnly = true;
            this.cencosdivi.Width = 60;
            // 
            // cencosanalitica
            // 
            this.cencosanalitica.DataPropertyName = "cencosanalitica";
            this.cencosanalitica.HeaderText = "imputable";
            this.cencosanalitica.Name = "cencosanalitica";
            this.cencosanalitica.ReadOnly = true;
            this.cencosanalitica.Visible = false;
            // 
            // sigla_a
            // 
            this.sigla_a.DataPropertyName = "sigla_a";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sigla_a.DefaultCellStyle = dataGridViewCellStyle4;
            this.sigla_a.HeaderText = "Siglas";
            this.sigla_a.Name = "sigla_a";
            this.sigla_a.ReadOnly = true;
            this.sigla_a.Width = 106;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.DefaultCellStyle = dataGridViewCellStyle5;
            this.status.HeaderText = "Estado";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            this.status.Width = 70;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtcuenta);
            this.GroupBox1.Controls.Add(this.chkclasecuenta);
            this.GroupBox1.Controls.Add(this.btnRefrescar);
            this.GroupBox1.Controls.Add(this.chkcodigolike);
            this.GroupBox1.Controls.Add(this.txtcodigolike);
            this.GroupBox1.Controls.Add(this.chkdescriplike);
            this.GroupBox1.Controls.Add(this.txtdescriplike);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Location = new System.Drawing.Point(7, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(662, 81);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = " Filtros ";
            // 
            // txtcuenta
            // 
            this.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcuenta.Location = new System.Drawing.Point(117, 54);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Size = new System.Drawing.Size(60, 21);
            this.txtcuenta.TabIndex = 5;
            // 
            // chkclasecuenta
            // 
            this.chkclasecuenta.AutoSize = true;
            this.chkclasecuenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkclasecuenta.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkclasecuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkclasecuenta.Location = new System.Drawing.Point(20, 56);
            this.chkclasecuenta.Name = "chkclasecuenta";
            this.chkclasecuenta.Size = new System.Drawing.Size(93, 17);
            this.chkclasecuenta.TabIndex = 4;
            this.chkclasecuenta.Text = "Cta. Contable";
            this.chkclasecuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkclasecuenta.UseVisualStyleBackColor = true;
            this.chkclasecuenta.CheckedChanged += new System.EventHandler(this.chkclasecuenta_CheckedChanged);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescar.Location = new System.Drawing.Point(572, 45);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(82, 30);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "&Refrescar";
            this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // chkcodigolike
            // 
            this.chkcodigolike.AutoSize = true;
            this.chkcodigolike.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcodigolike.Checked = true;
            this.chkcodigolike.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkcodigolike.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkcodigolike.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcodigolike.Location = new System.Drawing.Point(29, 14);
            this.chkcodigolike.Name = "chkcodigolike";
            this.chkcodigolike.Size = new System.Drawing.Size(84, 17);
            this.chkcodigolike.TabIndex = 0;
            this.chkcodigolike.Text = "Código C.C.";
            this.chkcodigolike.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcodigolike.UseVisualStyleBackColor = true;
            this.chkcodigolike.CheckedChanged += new System.EventHandler(this.chkcodigolike_CheckedChanged);
            // 
            // txtcodigolike
            // 
            this.txtcodigolike.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigolike.Location = new System.Drawing.Point(117, 12);
            this.txtcodigolike.Name = "txtcodigolike";
            this.txtcodigolike.Size = new System.Drawing.Size(70, 21);
            this.txtcodigolike.TabIndex = 1;
            this.txtcodigolike.TextChanged += new System.EventHandler(this.txtcodigolike_TextChanged);
            // 
            // chkdescriplike
            // 
            this.chkdescriplike.AutoSize = true;
            this.chkdescriplike.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescriplike.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkdescriplike.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescriplike.Location = new System.Drawing.Point(8, 35);
            this.chkdescriplike.Name = "chkdescriplike";
            this.chkdescriplike.Size = new System.Drawing.Size(105, 17);
            this.chkdescriplike.TabIndex = 2;
            this.chkdescriplike.Text = "Descripción C.C.";
            this.chkdescriplike.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescriplike.UseVisualStyleBackColor = true;
            this.chkdescriplike.CheckedChanged += new System.EventHandler(this.chkdescriplike_CheckedChanged);
            // 
            // txtdescriplike
            // 
            this.txtdescriplike.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescriplike.Location = new System.Drawing.Point(117, 33);
            this.txtdescriplike.Name = "txtdescriplike";
            this.txtdescriplike.Size = new System.Drawing.Size(337, 21);
            this.txtdescriplike.TabIndex = 3;
            this.txtdescriplike.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescriplike_KeyDown);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.rbInactivo);
            this.GroupBox4.Controls.Add(this.rbActivo);
            this.GroupBox4.Location = new System.Drawing.Point(513, 9);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(141, 32);
            this.GroupBox4.TabIndex = 4;
            this.GroupBox4.TabStop = false;
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.ForeColor = System.Drawing.Color.Red;
            this.rbInactivo.Location = new System.Drawing.Point(82, 11);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(46, 17);
            this.rbInactivo.TabIndex = 2;
            this.rbInactivo.Text = "Baja";
            this.rbInactivo.UseVisualStyleBackColor = true;
            this.rbInactivo.CheckedChanged += new System.EventHandler(this.rbInactivo_CheckedChanged);
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Checked = true;
            this.rbActivo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rbActivo.Location = new System.Drawing.Point(12, 11);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(55, 17);
            this.rbActivo.TabIndex = 1;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            this.rbActivo.CheckedChanged += new System.EventHandler(this.rbActivo_CheckedChanged);
            // 
            // lblregseleccionado
            // 
            this.lblregseleccionado.BackColor = System.Drawing.Color.Red;
            this.lblregseleccionado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblregseleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregseleccionado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblregseleccionado.Location = new System.Drawing.Point(10, 417);
            this.lblregseleccionado.Name = "lblregseleccionado";
            this.lblregseleccionado.Size = new System.Drawing.Size(193, 13);
            this.lblregseleccionado.TabIndex = 9;
            this.lblregseleccionado.Text = "REGISTROS ANULADOS";
            this.lblregseleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblregseleccionado.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCerrar);
            this.groupBox2.Controls.Add(this.btnSeleccion);
            this.groupBox2.Location = new System.Drawing.Point(245, 419);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 40);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar  ";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(5, 12);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // Frm_AyudaCentrocosto
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 462);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.txttotregistrosanaliticos);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.lblregseleccionado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblanalitico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaCentrocosto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda Centro de Costos >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaCentrocosto_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaCentrocosto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaCentrocosto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txttotregistrosanaliticos;
        internal System.Windows.Forms.Label lblanalitico;
        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtcuenta;
        internal System.Windows.Forms.CheckBox chkclasecuenta;
        internal System.Windows.Forms.Button btnRefrescar;
        internal System.Windows.Forms.CheckBox chkcodigolike;
        internal System.Windows.Forms.TextBox txtcodigolike;
        internal System.Windows.Forms.CheckBox chkdescriplike;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton rbInactivo;
        internal System.Windows.Forms.RadioButton rbActivo;
        internal System.Windows.Forms.TextBox txtdescriplike;
        internal System.Windows.Forms.Label lblregseleccionado;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosdivi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosanalitica;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigla_a;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}