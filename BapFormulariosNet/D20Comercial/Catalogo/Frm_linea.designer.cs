namespace BapFormulariosNet.D20Comercial.Catalogo
{
    partial class Frm_linea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_linea));
            this.gridlinea = new System.Windows.Forms.DataGridView();
            this.glineaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glineaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gestructuraid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaalmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaconsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctavarexist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctacargaimput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._nostock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nostock = new DevExpress.XtraEditors.RadioGroup();
            this.estructuraid = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lineaid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lineaname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_primero = new System.Windows.Forms.ToolStripButton();
            this.btn_anterior = new System.Windows.Forms.ToolStripButton();
            this.btn_siguiente = new System.Windows.Forms.ToolStripButton();
            this.btn_ultimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_log = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_criterio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridlinea)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nostock.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridlinea
            // 
            this.gridlinea.AllowUserToAddRows = false;
            this.gridlinea.AllowUserToDeleteRows = false;
            this.gridlinea.AllowUserToResizeColumns = false;
            this.gridlinea.AllowUserToResizeRows = false;
            this.gridlinea.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridlinea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridlinea.ColumnHeadersHeight = 20;
            this.gridlinea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.glineaid,
            this.glineaname,
            this.gestructuraid,
            this.usuar,
            this.feact,
            this.fecre,
            this.ctaalmacen,
            this.ctaconsumo,
            this.ctavarexist,
            this.ctacargaimput,
            this.moduloid,
            this._nostock});
            this.gridlinea.Location = new System.Drawing.Point(4, 238);
            this.gridlinea.MultiSelect = false;
            this.gridlinea.Name = "gridlinea";
            this.gridlinea.RowHeadersVisible = false;
            this.gridlinea.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridlinea.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridlinea.RowTemplate.Height = 20;
            this.gridlinea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridlinea.Size = new System.Drawing.Size(422, 295);
            this.gridlinea.TabIndex = 19;
            this.gridlinea.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridlinea_CellClick);
            this.gridlinea.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridlinea_CellEnter);
            this.gridlinea.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridlinea_CellLeave);
            this.gridlinea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridlinea_KeyUp);
            // 
            // glineaid
            // 
            this.glineaid.DataPropertyName = "lineaid";
            this.glineaid.HeaderText = "Código";
            this.glineaid.Name = "glineaid";
            this.glineaid.Width = 50;
            // 
            // glineaname
            // 
            this.glineaname.DataPropertyName = "lineaname";
            this.glineaname.HeaderText = "Línea";
            this.glineaname.Name = "glineaname";
            this.glineaname.Width = 300;
            // 
            // gestructuraid
            // 
            this.gestructuraid.DataPropertyName = "estructuraid";
            this.gestructuraid.HeaderText = "estructura";
            this.gestructuraid.Name = "gestructuraid";
            this.gestructuraid.Visible = false;
            this.gestructuraid.Width = 70;
            // 
            // usuar
            // 
            this.usuar.DataPropertyName = "usuar";
            this.usuar.HeaderText = "usuar";
            this.usuar.Name = "usuar";
            this.usuar.Visible = false;
            // 
            // feact
            // 
            this.feact.DataPropertyName = "feact";
            this.feact.HeaderText = "feact";
            this.feact.Name = "feact";
            this.feact.Visible = false;
            // 
            // fecre
            // 
            this.fecre.DataPropertyName = "fecre";
            this.fecre.HeaderText = "fecre";
            this.fecre.Name = "fecre";
            this.fecre.Visible = false;
            // 
            // ctaalmacen
            // 
            this.ctaalmacen.DataPropertyName = "ctaalmacen";
            this.ctaalmacen.HeaderText = "ctaalmacen";
            this.ctaalmacen.Name = "ctaalmacen";
            this.ctaalmacen.Visible = false;
            // 
            // ctaconsumo
            // 
            this.ctaconsumo.DataPropertyName = "ctaconsumo";
            this.ctaconsumo.HeaderText = "ctaconsumo";
            this.ctaconsumo.Name = "ctaconsumo";
            this.ctaconsumo.Visible = false;
            // 
            // ctavarexist
            // 
            this.ctavarexist.DataPropertyName = "ctavarexist";
            this.ctavarexist.HeaderText = "ctavarexist";
            this.ctavarexist.Name = "ctavarexist";
            this.ctavarexist.Visible = false;
            // 
            // ctacargaimput
            // 
            this.ctacargaimput.DataPropertyName = "ctacargaimput";
            this.ctacargaimput.HeaderText = "ctacargaimput";
            this.ctacargaimput.Name = "ctacargaimput";
            this.ctacargaimput.Visible = false;
            // 
            // moduloid
            // 
            this.moduloid.DataPropertyName = "moduloid";
            this.moduloid.HeaderText = "Modulo";
            this.moduloid.Name = "moduloid";
            this.moduloid.Visible = false;
            // 
            // _nostock
            // 
            this._nostock.DataPropertyName = "nostock";
            this._nostock.HeaderText = "NoStock";
            this._nostock.Name = "_nostock";
            this._nostock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._nostock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._nostock.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nostock);
            this.groupBox1.Controls.Add(this.estructuraid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lineaid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lineaname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // nostock
            // 
            this.nostock.EditValue = true;
            this.nostock.Location = new System.Drawing.Point(91, 84);
            this.nostock.Name = "nostock";
            this.nostock.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Controla Stock"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "No Controla Stock")});
            this.nostock.Size = new System.Drawing.Size(243, 24);
            this.nostock.TabIndex = 15;
            // 
            // estructuraid
            // 
            this.estructuraid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estructuraid.FormattingEnabled = true;
            this.estructuraid.Location = new System.Drawing.Point(91, 60);
            this.estructuraid.Name = "estructuraid";
            this.estructuraid.Size = new System.Drawing.Size(225, 21);
            this.estructuraid.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Estructura:";
            // 
            // lineaid
            // 
            this.lineaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaid.Location = new System.Drawing.Point(91, 16);
            this.lineaid.MaxLength = 3;
            this.lineaid.Name = "lineaid";
            this.lineaid.Size = new System.Drawing.Size(48, 20);
            this.lineaid.TabIndex = 11;
            this.lineaid.Text = "ventas al exterior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Línea:";
            // 
            // lineaname
            // 
            this.lineaname.Location = new System.Drawing.Point(91, 37);
            this.lineaname.Name = "lineaname";
            this.lineaname.Size = new System.Drawing.Size(225, 20);
            this.lineaname.TabIndex = 12;
            this.lineaname.Text = "ventas al exterior";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Código:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::BapFormulariosNet.Properties.Resources.bannerblue2;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 58);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(170, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "LINEAS";
            // 
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_editar,
            this.btn_cancelar,
            this.btn_grabar,
            this.btn_eliminar,
            this.btn_imprimir,
            this.toolStripSeparator1,
            this.btn_primero,
            this.btn_anterior,
            this.btn_siguiente,
            this.btn_ultimo,
            this.toolStripSeparator2,
            this.btn_clave,
            this.btn_log,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(430, 29);
            this.Botonera.TabIndex = 1;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = global::BapFormulariosNet.Properties.Resources.go_new3;
            this.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_nuevo.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(23, 26);
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.ToolTipText = "Nuevo (Ctrl + N)";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_editar.Image = global::BapFormulariosNet.Properties.Resources.Edit;
            this.btn_editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(26, 26);
            this.btn_editar.Text = "Editar";
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_cancelar.Image = global::BapFormulariosNet.Properties.Resources.go_undo2;
            this.btn_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(24, 26);
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_grabar
            // 
            this.btn_grabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(26, 26);
            this.btn_grabar.Text = "Grabar";
            this.btn_grabar.ToolTipText = "Grabar (Ctrl + G)";
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(26, 26);
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_imprimir.Image = global::BapFormulariosNet.Properties.Resources.dev_printer;
            this.btn_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(26, 26);
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_primero
            // 
            this.btn_primero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_primero.Image = global::BapFormulariosNet.Properties.Resources.go_first_g;
            this.btn_primero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_primero.Name = "btn_primero";
            this.btn_primero.Size = new System.Drawing.Size(26, 26);
            this.btn_primero.Text = "Primero";
            this.btn_primero.Click += new System.EventHandler(this.btn_primero_Click);
            // 
            // btn_anterior
            // 
            this.btn_anterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_anterior.Image = global::BapFormulariosNet.Properties.Resources.go_previous_g;
            this.btn_anterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.Size = new System.Drawing.Size(26, 26);
            this.btn_anterior.Text = "Anterior";
            this.btn_anterior.Click += new System.EventHandler(this.btn_anterior_Click);
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_siguiente.Image = global::BapFormulariosNet.Properties.Resources.go_next_g;
            this.btn_siguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(26, 26);
            this.btn_siguiente.Text = "Siguiente";
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click);
            // 
            // btn_ultimo
            // 
            this.btn_ultimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ultimo.Image = global::BapFormulariosNet.Properties.Resources.go_last_g;
            this.btn_ultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ultimo.Name = "btn_ultimo";
            this.btn_ultimo.Size = new System.Drawing.Size(26, 26);
            this.btn_ultimo.Text = "Ultimo";
            this.btn_ultimo.Click += new System.EventHandler(this.btn_ultimo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_clave
            // 
            this.btn_clave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            this.btn_clave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clave.Name = "btn_clave";
            this.btn_clave.Size = new System.Drawing.Size(26, 26);
            this.btn_clave.Text = "toolStripButton1";
            this.btn_clave.ToolTipText = "Clave Administrador";
            this.btn_clave.Click += new System.EventHandler(this.btn_clave_Click);
            // 
            // btn_log
            // 
            this.btn_log.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_log.Image = ((System.Drawing.Image)(resources.GetObject("btn_log.Image")));
            this.btn_log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(26, 26);
            this.btn_log.Text = "toolStripButton16";
            this.btn_log.ToolTipText = "Auditoria";
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = global::BapFormulariosNet.Properties.Resources.go_out2;
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 26);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_busqueda);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_criterio);
            this.groupBox2.Location = new System.Drawing.Point(4, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 49);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(324, 12);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(79, 33);
            this.btn_busqueda.TabIndex = 18;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Descripción:";
            // 
            // txt_criterio
            // 
            this.txt_criterio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_criterio.Location = new System.Drawing.Point(75, 19);
            this.txt_criterio.MaxLength = 0;
            this.txt_criterio.Name = "txt_criterio";
            this.txt_criterio.Size = new System.Drawing.Size(242, 20);
            this.txt_criterio.TabIndex = 17;
            this.txt_criterio.TextChanged += new System.EventHandler(this.txt_criterio_TextChanged);
            this.txt_criterio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_criterio_KeyDown);
            // 
            // Frm_linea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(430, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gridlinea);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_linea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Lineas";
            this.Load += new System.EventHandler(this.Frm_linea_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_linea_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridlinea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nostock.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_editar;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_grabar;
        private System.Windows.Forms.ToolStripButton btn_eliminar;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_primero;
        private System.Windows.Forms.ToolStripButton btn_anterior;
        private System.Windows.Forms.ToolStripButton btn_siguiente;
        private System.Windows.Forms.ToolStripButton btn_ultimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_log;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox lineaname;
        internal System.Windows.Forms.DataGridView gridlinea;
        internal System.Windows.Forms.TextBox lineaid;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox estructuraid;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_busqueda;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_criterio;
        private DevExpress.XtraEditors.RadioGroup nostock;
        private System.Windows.Forms.DataGridViewTextBoxColumn glineaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn glineaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gestructuraid;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn feact;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaalmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaconsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctavarexist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctacargaimput;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _nostock;

    }
}