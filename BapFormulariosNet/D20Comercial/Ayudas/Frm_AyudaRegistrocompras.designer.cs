namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaRegistrocompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaRegistrocompras));
            this.LNLANULADOS = new System.Windows.Forms.Label();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.perimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diarioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechregistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctactename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipcamb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciocompra1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afecdetraccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nconstdetrac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTipdoc = new System.Windows.Forms.ComboBox();
            this.chkTipocompra = new System.Windows.Forms.CheckBox();
            this.cboTipocompra = new System.Windows.Forms.ComboBox();
            this.chkTipdoc = new System.Windows.Forms.CheckBox();
            this.chkOrigen = new System.Windows.Forms.CheckBox();
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.chkRegmes = new System.Windows.Forms.CheckBox();
            this.txtRegmes = new System.Windows.Forms.TextBox();
            this.fechaFin = new System.Windows.Forms.DateTimePicker();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.fechaIni = new System.Windows.Forms.DateTimePicker();
            this.chkRuc = new System.Windows.Forms.CheckBox();
            this.txtCtactename = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.chkGlosa = new System.Windows.Forms.CheckBox();
            this.txtGlosa = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // LNLANULADOS
            // 
            this.LNLANULADOS.AutoSize = true;
            this.LNLANULADOS.BackColor = System.Drawing.Color.Crimson;
            this.LNLANULADOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNLANULADOS.ForeColor = System.Drawing.Color.White;
            this.LNLANULADOS.Location = new System.Drawing.Point(14, 499);
            this.LNLANULADOS.Name = "LNLANULADOS";
            this.LNLANULADOS.Size = new System.Drawing.Size(64, 13);
            this.LNLANULADOS.TabIndex = 10;
            this.LNLANULADOS.Text = "ALMACEN :";
            this.LNLANULADOS.Visible = false;
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgProveedor.ColumnHeadersHeight = 24;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perimes,
            this.diarioid,
            this.asiento,
            this.fechregistro,
            this.tipodoc,
            this.serdoc,
            this.numdoc,
            this.fechdoc,
            this.nmruc,
            this.ctactename,
            this.tipcamb,
            this.moneda,
            this.preciocompra1,
            this.status,
            this.afecdetraccion,
            this.nconstdetrac,
            this.tipoid,
            this.glosa});
            this.dgProveedor.Location = new System.Drawing.Point(5, 106);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            this.dgProveedor.RowHeadersWidth = 20;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgProveedor.Size = new System.Drawing.Size(1023, 376);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_ColumnHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // perimes
            // 
            this.perimes.DataPropertyName = "perimes";
            this.perimes.HeaderText = "Mes";
            this.perimes.Name = "perimes";
            this.perimes.ReadOnly = true;
            this.perimes.Width = 34;
            // 
            // diarioid
            // 
            this.diarioid.DataPropertyName = "diarioid";
            this.diarioid.HeaderText = "Diario";
            this.diarioid.Name = "diarioid";
            this.diarioid.ReadOnly = true;
            this.diarioid.Visible = false;
            this.diarioid.Width = 60;
            // 
            // asiento
            // 
            this.asiento.DataPropertyName = "asiento";
            this.asiento.HeaderText = "Asiento";
            this.asiento.Name = "asiento";
            this.asiento.ReadOnly = true;
            this.asiento.Width = 62;
            // 
            // fechregistro
            // 
            this.fechregistro.DataPropertyName = "fechregistro";
            this.fechregistro.HeaderText = "F.Registro";
            this.fechregistro.Name = "fechregistro";
            this.fechregistro.ReadOnly = true;
            this.fechregistro.Width = 70;
            // 
            // tipodoc
            // 
            this.tipodoc.DataPropertyName = "tipodoc";
            this.tipodoc.HeaderText = "TD";
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.ReadOnly = true;
            this.tipodoc.Width = 28;
            // 
            // serdoc
            // 
            this.serdoc.DataPropertyName = "serdoc";
            this.serdoc.HeaderText = "Serie";
            this.serdoc.Name = "serdoc";
            this.serdoc.ReadOnly = true;
            this.serdoc.Width = 36;
            // 
            // numdoc
            // 
            this.numdoc.DataPropertyName = "numdoc";
            this.numdoc.HeaderText = "Número";
            this.numdoc.Name = "numdoc";
            this.numdoc.ReadOnly = true;
            this.numdoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numdoc.Width = 74;
            // 
            // fechdoc
            // 
            this.fechdoc.DataPropertyName = "fechdoc";
            this.fechdoc.HeaderText = "F.Emisión";
            this.fechdoc.Name = "fechdoc";
            this.fechdoc.ReadOnly = true;
            this.fechdoc.Width = 70;
            // 
            // nmruc
            // 
            this.nmruc.DataPropertyName = "nmruc";
            this.nmruc.HeaderText = "Cód.-RUC";
            this.nmruc.Name = "nmruc";
            this.nmruc.ReadOnly = true;
            this.nmruc.Width = 78;
            // 
            // ctactename
            // 
            this.ctactename.DataPropertyName = "ctactename";
            this.ctactename.HeaderText = "Razón Social";
            this.ctactename.Name = "ctactename";
            this.ctactename.ReadOnly = true;
            this.ctactename.Width = 250;
            // 
            // tipcamb
            // 
            this.tipcamb.DataPropertyName = "tipcamb";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            dataGridViewCellStyle1.NullValue = "0";
            this.tipcamb.DefaultCellStyle = dataGridViewCellStyle1;
            this.tipcamb.HeaderText = "T.Cambio";
            this.tipcamb.Name = "tipcamb";
            this.tipcamb.ReadOnly = true;
            this.tipcamb.Width = 60;
            // 
            // moneda
            // 
            this.moneda.DataPropertyName = "moneda";
            this.moneda.HeaderText = "M";
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            this.moneda.Width = 22;
            // 
            // preciocompra1
            // 
            this.preciocompra1.DataPropertyName = "preciocompra1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.preciocompra1.DefaultCellStyle = dataGridViewCellStyle2;
            this.preciocompra1.HeaderText = "Importe S/.";
            this.preciocompra1.Name = "preciocompra1";
            this.preciocompra1.ReadOnly = true;
            this.preciocompra1.Width = 75;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "ESTADO";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // afecdetraccion
            // 
            this.afecdetraccion.DataPropertyName = "afecdetraccion";
            this.afecdetraccion.HeaderText = "Detr.";
            this.afecdetraccion.Name = "afecdetraccion";
            this.afecdetraccion.ReadOnly = true;
            this.afecdetraccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.afecdetraccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.afecdetraccion.Width = 35;
            // 
            // nconstdetrac
            // 
            this.nconstdetrac.DataPropertyName = "nconstdetrac";
            this.nconstdetrac.HeaderText = "Nº Detracción";
            this.nconstdetrac.Name = "nconstdetrac";
            this.nconstdetrac.ReadOnly = true;
            // 
            // tipoid
            // 
            this.tipoid.DataPropertyName = "tipoid";
            this.tipoid.HeaderText = "Tipo Compra";
            this.tipoid.Name = "tipoid";
            this.tipoid.ReadOnly = true;
            this.tipoid.Width = 300;
            // 
            // glosa
            // 
            this.glosa.DataPropertyName = "glosa";
            this.glosa.HeaderText = "Glosa";
            this.glosa.Name = "glosa";
            this.glosa.ReadOnly = true;
            this.glosa.Width = 250;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cboTipdoc);
            this.GroupBox1.Controls.Add(this.chkTipocompra);
            this.GroupBox1.Controls.Add(this.cboTipocompra);
            this.GroupBox1.Controls.Add(this.chkTipdoc);
            this.GroupBox1.Controls.Add(this.chkOrigen);
            this.GroupBox1.Controls.Add(this.cboOrigen);
            this.GroupBox1.Controls.Add(this.chkRegmes);
            this.GroupBox1.Controls.Add(this.txtRegmes);
            this.GroupBox1.Controls.Add(this.fechaFin);
            this.GroupBox1.Controls.Add(this.chkFechas);
            this.GroupBox1.Controls.Add(this.fechaIni);
            this.GroupBox1.Controls.Add(this.chkRuc);
            this.GroupBox1.Controls.Add(this.txtCtactename);
            this.GroupBox1.Controls.Add(this.txtRuc);
            this.GroupBox1.Controls.Add(this.btnRefrescar);
            this.GroupBox1.Controls.Add(this.chkGlosa);
            this.GroupBox1.Controls.Add(this.txtGlosa);
            this.GroupBox1.Location = new System.Drawing.Point(5, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1023, 102);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // cboTipdoc
            // 
            this.cboTipdoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipdoc.DropDownWidth = 350;
            this.cboTipdoc.FormattingEnabled = true;
            this.cboTipdoc.Location = new System.Drawing.Point(401, 53);
            this.cboTipdoc.Name = "cboTipdoc";
            this.cboTipdoc.Size = new System.Drawing.Size(288, 21);
            this.cboTipdoc.TabIndex = 18;
            // 
            // chkTipocompra
            // 
            this.chkTipocompra.AutoSize = true;
            this.chkTipocompra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTipocompra.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkTipocompra.Location = new System.Drawing.Point(310, 12);
            this.chkTipocompra.Name = "chkTipocompra";
            this.chkTipocompra.Size = new System.Drawing.Size(86, 17);
            this.chkTipocompra.TabIndex = 3;
            this.chkTipocompra.Text = "Tipo Compra";
            this.chkTipocompra.UseVisualStyleBackColor = true;
            this.chkTipocompra.CheckedChanged += new System.EventHandler(this.chkTipocompra_CheckedChanged);
            // 
            // cboTipocompra
            // 
            this.cboTipocompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipocompra.DropDownWidth = 360;
            this.cboTipocompra.FormattingEnabled = true;
            this.cboTipocompra.Location = new System.Drawing.Point(401, 10);
            this.cboTipocompra.Name = "cboTipocompra";
            this.cboTipocompra.Size = new System.Drawing.Size(288, 21);
            this.cboTipocompra.TabIndex = 4;
            // 
            // chkTipdoc
            // 
            this.chkTipdoc.AutoSize = true;
            this.chkTipdoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTipdoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkTipdoc.Location = new System.Drawing.Point(283, 56);
            this.chkTipdoc.Name = "chkTipdoc";
            this.chkTipdoc.Size = new System.Drawing.Size(114, 17);
            this.chkTipdoc.TabIndex = 10;
            this.chkTipdoc.Text = "Tipo Comprobante";
            this.chkTipdoc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkTipdoc.UseVisualStyleBackColor = true;
            this.chkTipdoc.CheckedChanged += new System.EventHandler(this.chkTipdoc_CheckedChanged);
            // 
            // chkOrigen
            // 
            this.chkOrigen.AutoSize = true;
            this.chkOrigen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOrigen.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkOrigen.Location = new System.Drawing.Point(448, 78);
            this.chkOrigen.Name = "chkOrigen";
            this.chkOrigen.Size = new System.Drawing.Size(58, 17);
            this.chkOrigen.TabIndex = 15;
            this.chkOrigen.Text = "Origen";
            this.chkOrigen.UseVisualStyleBackColor = true;
            this.chkOrigen.CheckedChanged += new System.EventHandler(this.chkOrigen_CheckedChanged);
            // 
            // cboOrigen
            // 
            this.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Items.AddRange(new object[] {
            "01 Compra Interna",
            "02 Compra Externa"});
            this.cboOrigen.Location = new System.Drawing.Point(511, 76);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(178, 21);
            this.cboOrigen.TabIndex = 16;
            // 
            // chkRegmes
            // 
            this.chkRegmes.AutoSize = true;
            this.chkRegmes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRegmes.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkRegmes.Location = new System.Drawing.Point(65, 56);
            this.chkRegmes.Name = "chkRegmes";
            this.chkRegmes.Size = new System.Drawing.Size(45, 17);
            this.chkRegmes.TabIndex = 8;
            this.chkRegmes.Text = "Mes";
            this.chkRegmes.UseVisualStyleBackColor = true;
            this.chkRegmes.CheckedChanged += new System.EventHandler(this.chkRegmes_CheckedChanged);
            // 
            // txtRegmes
            // 
            this.txtRegmes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegmes.Location = new System.Drawing.Point(119, 54);
            this.txtRegmes.MaxLength = 2;
            this.txtRegmes.Name = "txtRegmes";
            this.txtRegmes.Size = new System.Drawing.Size(32, 21);
            this.txtRegmes.TabIndex = 9;
            // 
            // fechaFin
            // 
            this.fechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFin.Location = new System.Drawing.Point(215, 10);
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.Size = new System.Drawing.Size(86, 20);
            this.fechaFin.TabIndex = 2;
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFechas.Checked = true;
            this.chkFechas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkFechas.Location = new System.Drawing.Point(50, 12);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(60, 17);
            this.chkFechas.TabIndex = 0;
            this.chkFechas.Text = "Fechas";
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // fechaIni
            // 
            this.fechaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaIni.Location = new System.Drawing.Point(119, 10);
            this.fechaIni.Name = "fechaIni";
            this.fechaIni.Size = new System.Drawing.Size(86, 20);
            this.fechaIni.TabIndex = 1;
            // 
            // chkRuc
            // 
            this.chkRuc.AutoSize = true;
            this.chkRuc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRuc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkRuc.Location = new System.Drawing.Point(37, 34);
            this.chkRuc.Name = "chkRuc";
            this.chkRuc.Size = new System.Drawing.Size(73, 17);
            this.chkRuc.TabIndex = 5;
            this.chkRuc.Text = "Ruc - Cód";
            this.chkRuc.UseVisualStyleBackColor = true;
            this.chkRuc.CheckedChanged += new System.EventHandler(this.chkRuc_CheckedChanged);
            // 
            // txtCtactename
            // 
            this.txtCtactename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtactename.Location = new System.Drawing.Point(221, 32);
            this.txtCtactename.Name = "txtCtactename";
            this.txtCtactename.Size = new System.Drawing.Size(468, 21);
            this.txtCtactename.TabIndex = 7;
            // 
            // txtRuc
            // 
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Location = new System.Drawing.Point(119, 32);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(100, 21);
            this.txtRuc.TabIndex = 6;
            this.txtRuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRuc_KeyDown);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescar.Location = new System.Drawing.Point(909, 60);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(82, 30);
            this.btnRefrescar.TabIndex = 17;
            this.btnRefrescar.Text = "&Refrescar";
            this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // chkGlosa
            // 
            this.chkGlosa.AutoSize = true;
            this.chkGlosa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGlosa.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkGlosa.Location = new System.Drawing.Point(23, 78);
            this.chkGlosa.Name = "chkGlosa";
            this.chkGlosa.Size = new System.Drawing.Size(87, 17);
            this.chkGlosa.TabIndex = 13;
            this.chkGlosa.Text = "Buscar Glosa";
            this.chkGlosa.UseVisualStyleBackColor = true;
            this.chkGlosa.CheckedChanged += new System.EventHandler(this.chkGlosa_CheckedChanged);
            // 
            // txtGlosa
            // 
            this.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGlosa.Location = new System.Drawing.Point(119, 76);
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.Size = new System.Drawing.Size(320, 21);
            this.txtGlosa.TabIndex = 14;
            this.txtGlosa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGlosa_KeyDown);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(424, 477);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 2;
            this.GroupBox4.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 11);
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
            this.btnSeleccion.Location = new System.Drawing.Point(5, 11);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // Frm_AyudaRegistrocompras
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 520);
            this.Controls.Add(this.LNLANULADOS);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaRegistrocompras";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda Registro de Compras >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaRegistrocompras_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaRegistrocompras_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaRegistrocompras_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LNLANULADOS;
        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkTipocompra;
        internal System.Windows.Forms.ComboBox cboTipocompra;
        internal System.Windows.Forms.CheckBox chkTipdoc;
        internal System.Windows.Forms.CheckBox chkOrigen;
        internal System.Windows.Forms.ComboBox cboOrigen;
        internal System.Windows.Forms.CheckBox chkRegmes;
        internal System.Windows.Forms.TextBox txtRegmes;
        internal System.Windows.Forms.DateTimePicker fechaFin;
        internal System.Windows.Forms.CheckBox chkFechas;
        internal System.Windows.Forms.DateTimePicker fechaIni;
        internal System.Windows.Forms.CheckBox chkRuc;
        internal System.Windows.Forms.TextBox txtCtactename;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.Button btnRefrescar;
        internal System.Windows.Forms.CheckBox chkGlosa;
        internal System.Windows.Forms.TextBox txtGlosa;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.ComboBox cboTipdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn diarioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechregistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn serdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmruc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctactename;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipcamb;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciocompra1;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn afecdetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nconstdetrac;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosa;
    }
}