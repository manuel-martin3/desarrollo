namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    partial class Frm_Vendedor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Vendedor));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblvendorid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbogenero = new System.Windows.Forms.ComboBox();
            this.fIngreso = new System.Windows.Forms.DateTimePicker();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.fnacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtdcargo = new System.Windows.Forms.TextBox();
            this.txtccargo = new System.Windows.Forms.TextBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.txtdcosto = new System.Windows.Forms.TextBox();
            this.txtccosto = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtnombres = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfiltronombre = new System.Windows.Forms.TextBox();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.txtfiltronumdoc = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this._vendorid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ddnni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fnacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._fechasig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cargoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barramain = new System.Windows.Forms.ToolStrip();
            this.btnnuevo = new System.Windows.Forms.ToolStripButton();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btneliminar = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnlog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.barramain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(61, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "ID";
            // 
            // lblvendorid
            // 
            this.lblvendorid.AutoSize = true;
            this.lblvendorid.ForeColor = System.Drawing.Color.Blue;
            this.lblvendorid.Location = new System.Drawing.Point(88, 4);
            this.lblvendorid.Name = "lblvendorid";
            this.lblvendorid.Size = new System.Drawing.Size(49, 13);
            this.lblvendorid.TabIndex = 64;
            this.lblvendorid.Text = "vendorid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(257, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Genero";
            // 
            // cbogenero
            // 
            this.cbogenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbogenero.FormattingEnabled = true;
            this.cbogenero.Location = new System.Drawing.Point(306, 89);
            this.cbogenero.Name = "cbogenero";
            this.cbogenero.Size = new System.Drawing.Size(184, 21);
            this.cbogenero.TabIndex = 62;
            // 
            // fIngreso
            // 
            this.fIngreso.CustomFormat = "99/99/9999";
            this.fIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fIngreso.Location = new System.Drawing.Point(87, 133);
            this.fIngreso.Name = "fIngreso";
            this.fIngreso.ShowCheckBox = true;
            this.fIngreso.Size = new System.Drawing.Size(105, 20);
            this.fIngreso.TabIndex = 48;
            // 
            // txtDni
            // 
            this.txtDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDni.Location = new System.Drawing.Point(87, 21);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(84, 21);
            this.txtDni.TabIndex = 14;
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.Location = new System.Drawing.Point(42, 23);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(38, 13);
            this.Label7.TabIndex = 13;
            this.Label7.Text = "Nº-Dni";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.ForeColor = System.Drawing.Color.White;
            this.Label14.Location = new System.Drawing.Point(48, 135);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(31, 13);
            this.Label14.TabIndex = 47;
            this.Label14.Text = "F.Sig";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(13, 114);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(69, 13);
            this.Label3.TabIndex = 45;
            this.Label3.Text = "F.Nacimiento";
            // 
            // fnacimiento
            // 
            this.fnacimiento.CustomFormat = "99/99/9999";
            this.fnacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fnacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fnacimiento.Location = new System.Drawing.Point(87, 112);
            this.fnacimiento.Name = "fnacimiento";
            this.fnacimiento.Size = new System.Drawing.Size(107, 20);
            this.fnacimiento.TabIndex = 46;
            // 
            // txtdcargo
            // 
            this.txtdcargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdcargo.Location = new System.Drawing.Point(142, 179);
            this.txtdcargo.Name = "txtdcargo";
            this.txtdcargo.Size = new System.Drawing.Size(348, 21);
            this.txtdcargo.TabIndex = 61;
            // 
            // txtccargo
            // 
            this.txtccargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtccargo.Location = new System.Drawing.Point(86, 179);
            this.txtccargo.MaxLength = 3;
            this.txtccargo.Name = "txtccargo";
            this.txtccargo.Size = new System.Drawing.Size(54, 21);
            this.txtccargo.TabIndex = 60;
            this.txtccargo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtccargo_KeyDown);
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.ForeColor = System.Drawing.Color.White;
            this.Label28.Location = new System.Drawing.Point(47, 181);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(36, 13);
            this.Label28.TabIndex = 59;
            this.Label28.Text = "Cargo";
            // 
            // txtdcosto
            // 
            this.txtdcosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdcosto.Location = new System.Drawing.Point(142, 157);
            this.txtdcosto.Name = "txtdcosto";
            this.txtdcosto.Size = new System.Drawing.Size(348, 21);
            this.txtdcosto.TabIndex = 58;
            // 
            // txtccosto
            // 
            this.txtccosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtccosto.Location = new System.Drawing.Point(86, 157);
            this.txtccosto.MaxLength = 5;
            this.txtccosto.Name = "txtccosto";
            this.txtccosto.Size = new System.Drawing.Size(54, 21);
            this.txtccosto.TabIndex = 57;
            this.txtccosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtccosto_KeyDown);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.ForeColor = System.Drawing.Color.White;
            this.Label27.Location = new System.Drawing.Point(38, 159);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(46, 13);
            this.Label27.TabIndex = 56;
            this.Label27.Text = "C.Costo";
            // 
            // txttelefono
            // 
            this.txttelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttelefono.Location = new System.Drawing.Point(87, 90);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(166, 21);
            this.txttelefono.TabIndex = 40;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.ForeColor = System.Drawing.Color.White;
            this.Label16.Location = new System.Drawing.Point(30, 88);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(49, 13);
            this.Label16.TabIndex = 39;
            this.Label16.Text = "Teléfono";
            // 
            // txtdireccion
            // 
            this.txtdireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdireccion.Location = new System.Drawing.Point(87, 67);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(404, 21);
            this.txtdireccion.TabIndex = 20;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(30, 69);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(50, 13);
            this.Label5.TabIndex = 19;
            this.Label5.Text = "Dirección";
            // 
            // txtnombres
            // 
            this.txtnombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombres.Location = new System.Drawing.Point(87, 44);
            this.txtnombres.Name = "txtnombres";
            this.txtnombres.Size = new System.Drawing.Size(404, 21);
            this.txtnombres.TabIndex = 10;
            this.txtnombres.TextChanged += new System.EventHandler(this.txtnombres_TextChanged);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.ForeColor = System.Drawing.Color.White;
            this.Label12.Location = new System.Drawing.Point(33, 43);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(49, 13);
            this.Label12.TabIndex = 9;
            this.Label12.Text = "Nombres";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtfiltronombre);
            this.GroupBox2.Controls.Add(this.btnfiltro);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Controls.Add(this.txtfiltronumdoc);
            this.GroupBox2.Controls.Add(this.Label23);
            this.GroupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.GroupBox2.Location = new System.Drawing.Point(6, 248);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(614, 54);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Filtrar";
            // 
            // txtfiltronombre
            // 
            this.txtfiltronombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfiltronombre.Location = new System.Drawing.Point(109, 21);
            this.txtfiltronombre.Name = "txtfiltronombre";
            this.txtfiltronombre.Size = new System.Drawing.Size(231, 21);
            this.txtfiltronombre.TabIndex = 1;
            this.txtfiltronombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfiltronombre_KeyDown);
            // 
            // btnfiltro
            // 
            this.btnfiltro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnfiltro.Image = global::BapFormulariosNet.Properties.Resources.filter;
            this.btnfiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltro.Location = new System.Drawing.Point(536, 11);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(67, 33);
            this.btnfiltro.TabIndex = 13;
            this.btnfiltro.Text = "&Filtrar";
            this.btnfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfiltro.UseVisualStyleBackColor = true;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label22.Location = new System.Drawing.Point(7, 24);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(103, 13);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Apellidos y Nombres";
            // 
            // txtfiltronumdoc
            // 
            this.txtfiltronumdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfiltronumdoc.Location = new System.Drawing.Point(425, 21);
            this.txtfiltronumdoc.MaxLength = 11;
            this.txtfiltronumdoc.Name = "txtfiltronumdoc";
            this.txtfiltronumdoc.Size = new System.Drawing.Size(105, 21);
            this.txtfiltronumdoc.TabIndex = 3;
            this.txtfiltronumdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfiltronumdoc_KeyDown);
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label23.Location = new System.Drawing.Point(343, 24);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(76, 13);
            this.Label23.TabIndex = 2;
            this.Label23.Text = "Nº Documento";
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 20;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._vendorid,
            this._ddnni,
            this._vendorname,
            this.direcc,
            this._telefono,
            this._fnacimiento,
            this._fechasig,
            this._cargoid});
            this.Examinar.Location = new System.Drawing.Point(7, 305);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersVisible = false;
            this.Examinar.RowHeadersWidth = 26;
            this.Examinar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Examinar.Size = new System.Drawing.Size(613, 257);
            this.Examinar.TabIndex = 1;
            this.Examinar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Examinar_CellClick);
            this.Examinar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Examinar_CellEnter);
            this.Examinar.Paint += new System.Windows.Forms.PaintEventHandler(this.Examinar_Paint);
            this.Examinar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Examinar_KeyUp);
            // 
            // _vendorid
            // 
            this._vendorid.DataPropertyName = "vendorid";
            this._vendorid.HeaderText = "vendorid";
            this._vendorid.Name = "_vendorid";
            this._vendorid.ReadOnly = true;
            this._vendorid.Visible = false;
            // 
            // _ddnni
            // 
            this._ddnni.DataPropertyName = "ddnni";
            this._ddnni.HeaderText = "N°-DNI";
            this._ddnni.Name = "_ddnni";
            this._ddnni.ReadOnly = true;
            this._ddnni.Width = 80;
            // 
            // _vendorname
            // 
            this._vendorname.DataPropertyName = "vendorname";
            this._vendorname.HeaderText = "Apellidos y Nombres";
            this._vendorname.Name = "_vendorname";
            this._vendorname.ReadOnly = true;
            this._vendorname.Width = 250;
            // 
            // direcc
            // 
            this.direcc.DataPropertyName = "direcc";
            this.direcc.HeaderText = "Dirección";
            this.direcc.Name = "direcc";
            this.direcc.ReadOnly = true;
            this.direcc.Width = 250;
            // 
            // _telefono
            // 
            this._telefono.DataPropertyName = "telefono";
            this._telefono.HeaderText = "telef1";
            this._telefono.Name = "_telefono";
            this._telefono.ReadOnly = true;
            this._telefono.Visible = false;
            // 
            // _fnacimiento
            // 
            this._fnacimiento.DataPropertyName = "fnacimiento";
            this._fnacimiento.HeaderText = "fechnacimiento";
            this._fnacimiento.Name = "_fnacimiento";
            this._fnacimiento.ReadOnly = true;
            this._fnacimiento.Visible = false;
            // 
            // _fechasig
            // 
            this._fechasig.DataPropertyName = "fechasig";
            this._fechasig.HeaderText = "F.Ingreso";
            this._fechasig.Name = "_fechasig";
            this._fechasig.ReadOnly = true;
            this._fechasig.Visible = false;
            this._fechasig.Width = 65;
            // 
            // _cargoid
            // 
            this._cargoid.DataPropertyName = "cargoid";
            this._cargoid.HeaderText = "cargoid";
            this._cargoid.Name = "_cargoid";
            this._cargoid.ReadOnly = true;
            this._cargoid.Visible = false;
            // 
            // barramain
            // 
            this.barramain.AutoSize = false;
            this.barramain.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.barramain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnnuevo,
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btneliminar,
            this.btncerrar,
            this.toolStripSeparator1,
            this.btnlog,
            this.toolStripSeparator2});
            this.barramain.Location = new System.Drawing.Point(0, 0);
            this.barramain.Name = "barramain";
            this.barramain.Size = new System.Drawing.Size(623, 31);
            this.barramain.TabIndex = 0;
            this.barramain.Text = "ToolStrip2";
            // 
            // btnnuevo
            // 
            this.btnnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnnuevo.Image = global::BapFormulariosNet.Properties.Resources.go_new3;
            this.btnnuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(23, 28);
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.Edit;
            this.btnmod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 28);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 28);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.go_undo2;
            this.btncancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(24, 28);
            this.btncancelar.Text = "Deshacer";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btneliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar;
            this.btneliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(26, 28);
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(26, 28);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnlog
            // 
            this.btnlog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnlog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btnlog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(26, 28);
            this.btnlog.Text = "Log";
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtDni);
            this.panelControl1.Controls.Add(this.lblvendorid);
            this.panelControl1.Controls.Add(this.Label12);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtnombres);
            this.panelControl1.Controls.Add(this.cbogenero);
            this.panelControl1.Controls.Add(this.Label5);
            this.panelControl1.Controls.Add(this.fIngreso);
            this.panelControl1.Controls.Add(this.txtdireccion);
            this.panelControl1.Controls.Add(this.Label16);
            this.panelControl1.Controls.Add(this.Label7);
            this.panelControl1.Controls.Add(this.txttelefono);
            this.panelControl1.Controls.Add(this.Label14);
            this.panelControl1.Controls.Add(this.Label27);
            this.panelControl1.Controls.Add(this.Label3);
            this.panelControl1.Controls.Add(this.txtccosto);
            this.panelControl1.Controls.Add(this.fnacimiento);
            this.panelControl1.Controls.Add(this.txtdcosto);
            this.panelControl1.Controls.Add(this.txtdcargo);
            this.panelControl1.Controls.Add(this.Label28);
            this.panelControl1.Controls.Add(this.txtccargo);
            this.panelControl1.Location = new System.Drawing.Point(7, 37);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(613, 205);
            this.panelControl1.TabIndex = 2;
            // 
            // Frm_Vendedor
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 561);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.barramain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_Vendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Vendedores ®";
            this.Activated += new System.EventHandler(this.Frm_RegistroTrabajadores_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_RegistroTrabajadores_FormClosing);
            this.Load += new System.EventHandler(this.Frm_RegistroTrabajadores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_RegistroTrabajadores_KeyDown);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.barramain.ResumeLayout(false);
            this.barramain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.ToolStrip barramain;
        internal System.Windows.Forms.ToolStripButton btnnuevo;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btneliminar;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripButton btnlog;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtfiltronombre;
        internal System.Windows.Forms.Button btnfiltro;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.TextBox txtfiltronumdoc;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.TextBox txtdireccion;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtnombres;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.DateTimePicker fIngreso;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker fnacimiento;
        internal System.Windows.Forms.TextBox txtdcargo;
        internal System.Windows.Forms.TextBox txtccargo;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.TextBox txtdcosto;
        internal System.Windows.Forms.TextBox txtccosto;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.TextBox txttelefono;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cbogenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn _vendorid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ddnni;
        private System.Windows.Forms.DataGridViewTextBoxColumn _vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn direcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fnacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fechasig;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cargoid;
        private System.Windows.Forms.Label lblvendorid;
        internal System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}