namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaParteingresoalmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaParteingresoalmacen));
            this.lblregseleccionado = new System.Windows.Forms.Label();
            this.GridMovimientoAlmacen = new System.Windows.Forms.DataGridView();
            this.selecciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.femisiondoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dunialm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido_3a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_femisiondoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordencs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSerdoc = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.chkalmacen = new System.Windows.Forms.CheckBox();
            this.txtdalmacen = new System.Windows.Forms.TextBox();
            this.txtcodalmacen = new System.Windows.Forms.TextBox();
            this.txtdtipdoc = new System.Windows.Forms.TextBox();
            this.txtCtacte = new System.Windows.Forms.TextBox();
            this.txtTipdoc = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.optordenes = new System.Windows.Forms.RadioButton();
            this.optfechas = new System.Windows.Forms.RadioButton();
            this.txtNumdoc = new System.Windows.Forms.TextBox();
            this.lblnomprov = new System.Windows.Forms.TextBox();
            this.chkdetalle = new System.Windows.Forms.CheckBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.Fecha1 = new System.Windows.Forms.DateTimePicker();
            this.lblUser = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridMovimientoAlmacen)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblregseleccionado
            // 
            this.lblregseleccionado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblregseleccionado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblregseleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregseleccionado.Location = new System.Drawing.Point(749, 456);
            this.lblregseleccionado.Name = "lblregseleccionado";
            this.lblregseleccionado.Size = new System.Drawing.Size(224, 13);
            this.lblregseleccionado.TabIndex = 3;
            this.lblregseleccionado.Text = "REGISTROS SELECCIONADOS";
            this.lblregseleccionado.Visible = false;
            // 
            // GridMovimientoAlmacen
            // 
            this.GridMovimientoAlmacen.AllowUserToAddRows = false;
            this.GridMovimientoAlmacen.AllowUserToDeleteRows = false;
            this.GridMovimientoAlmacen.AllowUserToResizeRows = false;
            this.GridMovimientoAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridMovimientoAlmacen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridMovimientoAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMovimientoAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selecciona,
            this.femisiondoc,
            this.documento,
            this.productid,
            this.productname,
            this.dunialm,
            this.cantidad,
            this.pedido_3a,
            this.d_femisiondoc,
            this.num_op,
            this.ordencs});
            this.GridMovimientoAlmacen.Location = new System.Drawing.Point(6, 74);
            this.GridMovimientoAlmacen.Name = "GridMovimientoAlmacen";
            this.GridMovimientoAlmacen.RowHeadersVisible = false;
            this.GridMovimientoAlmacen.RowTemplate.Height = 20;
            this.GridMovimientoAlmacen.Size = new System.Drawing.Size(994, 369);
            this.GridMovimientoAlmacen.TabIndex = 1;
            this.GridMovimientoAlmacen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridMovimientoAlmacen_CellClick);
            this.GridMovimientoAlmacen.Paint += new System.Windows.Forms.PaintEventHandler(this.GridMovimientoAlmacen_Paint);
            this.GridMovimientoAlmacen.DoubleClick += new System.EventHandler(this.GridMovimientoAlmacen_DoubleClick);
            this.GridMovimientoAlmacen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridMovimientoAlmacen_KeyDown);
            // 
            // selecciona
            // 
            this.selecciona.DataPropertyName = "selecciona";
            this.selecciona.HeaderText = "Sel";
            this.selecciona.Name = "selecciona";
            this.selecciona.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selecciona.Width = 30;
            // 
            // femisiondoc
            // 
            this.femisiondoc.DataPropertyName = "femisiondoc";
            this.femisiondoc.HeaderText = "Fecha";
            this.femisiondoc.Name = "femisiondoc";
            this.femisiondoc.Width = 70;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "documento";
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            this.documento.Width = 120;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "Código Artículo";
            this.productid.Name = "productid";
            this.productid.Width = 140;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.HeaderText = "Descripción";
            this.productname.Name = "productname";
            this.productname.Width = 252;
            // 
            // dunialm
            // 
            this.dunialm.DataPropertyName = "dunialm";
            this.dunialm.HeaderText = "UMD";
            this.dunialm.Name = "dunialm";
            this.dunialm.Width = 44;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N5";
            dataGridViewCellStyle2.NullValue = null;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidad.HeaderText = "Cantidad Almacén";
            this.cantidad.Name = "cantidad";
            this.cantidad.Width = 82;
            // 
            // pedido_3a
            // 
            this.pedido_3a.DataPropertyName = "pedido_3a";
            this.pedido_3a.HeaderText = "Pedido";
            this.pedido_3a.Name = "pedido_3a";
            this.pedido_3a.Width = 76;
            // 
            // d_femisiondoc
            // 
            this.d_femisiondoc.DataPropertyName = "d_femisiondoc";
            this.d_femisiondoc.HeaderText = "d_femisiondoc";
            this.d_femisiondoc.Name = "d_femisiondoc";
            this.d_femisiondoc.Visible = false;
            // 
            // num_op
            // 
            this.num_op.DataPropertyName = "num_op";
            this.num_op.HeaderText = "OP";
            this.num_op.Name = "num_op";
            this.num_op.Width = 76;
            // 
            // ordencs
            // 
            this.ordencs.DataPropertyName = "ordencs";
            this.ordencs.HeaderText = "OS/OC";
            this.ordencs.Name = "ordencs";
            this.ordencs.Width = 80;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtSerdoc);
            this.GroupBox1.Controls.Add(this.txtRuc);
            this.GroupBox1.Controls.Add(this.chkalmacen);
            this.GroupBox1.Controls.Add(this.txtdalmacen);
            this.GroupBox1.Controls.Add(this.txtcodalmacen);
            this.GroupBox1.Controls.Add(this.txtdtipdoc);
            this.GroupBox1.Controls.Add(this.txtCtacte);
            this.GroupBox1.Controls.Add(this.txtTipdoc);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Controls.Add(this.txtNumdoc);
            this.GroupBox1.Controls.Add(this.lblnomprov);
            this.GroupBox1.Controls.Add(this.chkdetalle);
            this.GroupBox1.Controls.Add(this.btnRefrescar);
            this.GroupBox1.Controls.Add(this.fecha2);
            this.GroupBox1.Controls.Add(this.Fecha1);
            this.GroupBox1.Controls.Add(this.lblUser);
            this.GroupBox1.Location = new System.Drawing.Point(6, -2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(992, 73);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // txtSerdoc
            // 
            this.txtSerdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerdoc.Location = new System.Drawing.Point(554, 15);
            this.txtSerdoc.MaxLength = 4;
            this.txtSerdoc.Name = "txtSerdoc";
            this.txtSerdoc.Size = new System.Drawing.Size(34, 21);
            this.txtSerdoc.TabIndex = 5;
            // 
            // txtRuc
            // 
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Location = new System.Drawing.Point(134, 45);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(78, 21);
            this.txtRuc.TabIndex = 10;
            this.txtRuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRuc_KeyDown);
            // 
            // chkalmacen
            // 
            this.chkalmacen.AutoSize = true;
            this.chkalmacen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkalmacen.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkalmacen.Location = new System.Drawing.Point(521, 47);
            this.chkalmacen.Name = "chkalmacen";
            this.chkalmacen.Size = new System.Drawing.Size(66, 17);
            this.chkalmacen.TabIndex = 12;
            this.chkalmacen.Text = "Almacén";
            this.chkalmacen.UseVisualStyleBackColor = true;
            this.chkalmacen.CheckedChanged += new System.EventHandler(this.chkalmacen_CheckedChanged);
            // 
            // txtdalmacen
            // 
            this.txtdalmacen.Enabled = false;
            this.txtdalmacen.Location = new System.Drawing.Point(632, 45);
            this.txtdalmacen.Name = "txtdalmacen";
            this.txtdalmacen.Size = new System.Drawing.Size(249, 21);
            this.txtdalmacen.TabIndex = 14;
            // 
            // txtcodalmacen
            // 
            this.txtcodalmacen.Enabled = false;
            this.txtcodalmacen.Location = new System.Drawing.Point(593, 45);
            this.txtcodalmacen.MaxLength = 3;
            this.txtcodalmacen.Name = "txtcodalmacen";
            this.txtcodalmacen.Size = new System.Drawing.Size(36, 21);
            this.txtcodalmacen.TabIndex = 13;
            this.txtcodalmacen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodalmacen_KeyDown);
            // 
            // txtdtipdoc
            // 
            this.txtdtipdoc.Location = new System.Drawing.Point(662, 15);
            this.txtdtipdoc.Name = "txtdtipdoc";
            this.txtdtipdoc.Size = new System.Drawing.Size(219, 21);
            this.txtdtipdoc.TabIndex = 7;
            // 
            // txtCtacte
            // 
            this.txtCtacte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtacte.Location = new System.Drawing.Point(79, 45);
            this.txtCtacte.MaxLength = 7;
            this.txtCtacte.Name = "txtCtacte";
            this.txtCtacte.Size = new System.Drawing.Size(53, 21);
            this.txtCtacte.TabIndex = 9;
            // 
            // txtTipdoc
            // 
            this.txtTipdoc.Location = new System.Drawing.Point(528, 15);
            this.txtTipdoc.MaxLength = 2;
            this.txtTipdoc.Name = "txtTipdoc";
            this.txtTipdoc.Size = new System.Drawing.Size(24, 21);
            this.txtTipdoc.TabIndex = 4;
            this.txtTipdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTipdoc_KeyDown);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.optordenes);
            this.GroupBox4.Controls.Add(this.optfechas);
            this.GroupBox4.Location = new System.Drawing.Point(16, 9);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(246, 30);
            this.GroupBox4.TabIndex = 1;
            this.GroupBox4.TabStop = false;
            // 
            // optordenes
            // 
            this.optordenes.AutoSize = true;
            this.optordenes.Location = new System.Drawing.Point(77, 10);
            this.optordenes.Name = "optordenes";
            this.optordenes.Size = new System.Drawing.Size(149, 17);
            this.optordenes.TabIndex = 1;
            this.optordenes.Text = "Tipo / Número Documento";
            this.optordenes.UseVisualStyleBackColor = true;
            this.optordenes.CheckedChanged += new System.EventHandler(this.optordenes_CheckedChanged);
            // 
            // optfechas
            // 
            this.optfechas.AutoSize = true;
            this.optfechas.Checked = true;
            this.optfechas.Location = new System.Drawing.Point(9, 10);
            this.optfechas.Name = "optfechas";
            this.optfechas.Size = new System.Drawing.Size(59, 17);
            this.optfechas.TabIndex = 0;
            this.optfechas.TabStop = true;
            this.optfechas.Text = "Fechas";
            this.optfechas.UseVisualStyleBackColor = true;
            this.optfechas.CheckedChanged += new System.EventHandler(this.optfechas_CheckedChanged);
            // 
            // txtNumdoc
            // 
            this.txtNumdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumdoc.Location = new System.Drawing.Point(590, 15);
            this.txtNumdoc.MaxLength = 10;
            this.txtNumdoc.Name = "txtNumdoc";
            this.txtNumdoc.Size = new System.Drawing.Size(70, 21);
            this.txtNumdoc.TabIndex = 6;
            this.txtNumdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnumdoclike_KeyDown);
            // 
            // lblnomprov
            // 
            this.lblnomprov.Enabled = false;
            this.lblnomprov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnomprov.Location = new System.Drawing.Point(213, 45);
            this.lblnomprov.Name = "lblnomprov";
            this.lblnomprov.ReadOnly = true;
            this.lblnomprov.Size = new System.Drawing.Size(300, 20);
            this.lblnomprov.TabIndex = 11;
            // 
            // chkdetalle
            // 
            this.chkdetalle.AutoSize = true;
            this.chkdetalle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdetalle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkdetalle.Location = new System.Drawing.Point(5, 47);
            this.chkdetalle.Name = "chkdetalle";
            this.chkdetalle.Size = new System.Drawing.Size(70, 17);
            this.chkdetalle.TabIndex = 8;
            this.chkdetalle.Text = "Cód-RUC";
            this.chkdetalle.UseVisualStyleBackColor = true;
            this.chkdetalle.CheckedChanged += new System.EventHandler(this.chkdetalle_CheckedChanged);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescar.Location = new System.Drawing.Point(895, 37);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(82, 30);
            this.btnRefrescar.TabIndex = 15;
            this.btnRefrescar.Text = "&Refrescar";
            this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // fecha2
            // 
            this.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha2.Location = new System.Drawing.Point(416, 15);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(97, 21);
            this.fecha2.TabIndex = 3;
            // 
            // Fecha1
            // 
            this.Fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha1.Location = new System.Drawing.Point(288, 15);
            this.Fecha1.Name = "Fecha1";
            this.Fecha1.Size = new System.Drawing.Size(97, 21);
            this.Fecha1.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 13);
            this.lblUser.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCerrar);
            this.groupBox2.Controls.Add(this.btnSeleccion);
            this.groupBox2.Location = new System.Drawing.Point(410, 439);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 40);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar ";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(5, 11);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // Frm_AyudaParteingresoalmacen
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 482);
            this.Controls.Add(this.lblregseleccionado);
            this.Controls.Add(this.GridMovimientoAlmacen);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaParteingresoalmacen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Documentos de Almacén a Provisionar";
            this.Activated += new System.EventHandler(this.Frm_AyudaParteingresoalmacen_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaParteingresoalmacen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaParteingresoalmacen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridMovimientoAlmacen)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblregseleccionado;
        internal System.Windows.Forms.DataGridView GridMovimientoAlmacen;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkalmacen;
        internal System.Windows.Forms.TextBox txtdalmacen;
        internal System.Windows.Forms.TextBox txtcodalmacen;
        internal System.Windows.Forms.TextBox txtdtipdoc;
        internal System.Windows.Forms.TextBox txtCtacte;
        internal System.Windows.Forms.TextBox txtTipdoc;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton optordenes;
        internal System.Windows.Forms.RadioButton optfechas;
        internal System.Windows.Forms.TextBox txtNumdoc;
        internal System.Windows.Forms.TextBox lblnomprov;
        internal System.Windows.Forms.CheckBox chkdetalle;
        internal System.Windows.Forms.Button btnRefrescar;
        internal System.Windows.Forms.DateTimePicker fecha2;
        internal System.Windows.Forms.DateTimePicker Fecha1;
        internal System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.TextBox txtSerdoc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selecciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn femisiondoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dunialm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido_3a;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_femisiondoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_op;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordencs;
    }
}