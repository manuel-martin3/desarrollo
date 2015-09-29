namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    partial class Frm_producto_est
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_producto_est));
            this.Mensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgbproductos = new System.Windows.Forms.DataGridView();
            this.peso = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_siguiente = new System.Windows.Forms.Button();
            this.cbo_estado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.productid = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.productname = new System.Windows.Forms.TextBox();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.pnl_codigo = new System.Windows.Forms.Panel();
            this.lblnombre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.item = new System.Windows.Forms.TextBox();
            this.cencosid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cencosname = new System.Windows.Forms.TextBox();
            this.estacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_fijar = new System.Windows.Forms.Button();
            this.unmedpeso = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fechadoc = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productidold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbproductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnl_codigo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.SystemColors.Control;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(489, 247);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(78, 30);
            this.btn_busqueda.TabIndex = 20;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.txt_busqueda);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 35);
            this.panel2.TabIndex = 61;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.Location = new System.Drawing.Point(100, 7);
            this.txt_busqueda.MaxLength = 0;
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(350, 21);
            this.txt_busqueda.TabIndex = 19;
            this.txt_busqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_busqueda_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion:";
            // 
            // dgbproductos
            // 
            this.dgbproductos.AllowUserToAddRows = false;
            this.dgbproductos.AllowUserToDeleteRows = false;
            this.dgbproductos.AllowUserToResizeColumns = false;
            this.dgbproductos.AllowUserToResizeRows = false;
            this.dgbproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbproductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.name,
            this.area,
            this.codigo2,
            this.productidold,
            this.status});
            this.dgbproductos.Location = new System.Drawing.Point(1, 281);
            this.dgbproductos.Name = "dgbproductos";
            this.dgbproductos.ReadOnly = true;
            this.dgbproductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgbproductos.Size = new System.Drawing.Size(626, 239);
            this.dgbproductos.TabIndex = 60;
            this.dgbproductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbproductos_CellClick);
            this.dgbproductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbproductos_CellEnter);
            this.dgbproductos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbproductos_CellLeave);
            this.dgbproductos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgbproductos_KeyUp);
            // 
            // peso
            // 
            this.peso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peso.Location = new System.Drawing.Point(366, 650);
            this.peso.Name = "peso";
            this.peso.Size = new System.Drawing.Size(124, 20);
            this.peso.TabIndex = 49;
            this.peso.Text = "ventas al exterior";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(299, 650);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(61, 13);
            this.label30.TabIndex = 59;
            this.label30.Text = "Med. Peso:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_siguiente);
            this.groupBox1.Controls.Add(this.cbo_estado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.pnl_codigo);
            this.groupBox1.Controls.Add(this.btn_fijar);
            this.groupBox1.Location = new System.Drawing.Point(4, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 175);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Codigo";
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_siguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_siguiente.Image = global::BapFormulariosNet.Properties.Resources.Forward;
            this.btn_siguiente.Location = new System.Drawing.Point(455, 67);
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(45, 26);
            this.btn_siguiente.TabIndex = 71;
            this.Mensaje.SetToolTip(this.btn_siguiente, "Click - Generar Guia ");
            this.btn_siguiente.UseVisualStyleBackColor = true;
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click);
            // 
            // cbo_estado
            // 
            this.cbo_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_estado.FormattingEnabled = true;
            this.cbo_estado.Location = new System.Drawing.Point(492, 40);
            this.cbo_estado.Name = "cbo_estado";
            this.cbo_estado.Size = new System.Drawing.Size(95, 21);
            this.cbo_estado.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(436, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Estado:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_agregar);
            this.panel3.Controls.Add(this.productid);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.productname);
            this.panel3.Controls.Add(this.shapeContainer2);
            this.panel3.Location = new System.Drawing.Point(13, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(604, 66);
            this.panel3.TabIndex = 68;
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.Transparent;
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.FlatAppearance.BorderSize = 0;
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Image = global::BapFormulariosNet.Properties.Resources.go_new1;
            this.btn_agregar.Location = new System.Drawing.Point(207, 11);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(31, 27);
            this.btn_agregar.TabIndex = 67;
            this.Mensaje.SetToolTip(this.btn_agregar, "Agregar Nuevo Producto");
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // productid
            // 
            this.productid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productid.Location = new System.Drawing.Point(77, 18);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(105, 20);
            this.productid.TabIndex = 24;
            this.productid.Text = "ventas al exterior";
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            this.productid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.productid_KeyUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Producto:";
            // 
            // productname
            // 
            this.productname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productname.Location = new System.Drawing.Point(77, 40);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(520, 20);
            this.productname.TabIndex = 25;
            this.productname.TextChanged += new System.EventHandler(this.productname_TextChanged);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer2.Size = new System.Drawing.Size(602, 64);
            this.shapeContainer2.TabIndex = 68;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 63;
            this.lineShape1.X2 = 63;
            this.lineShape1.Y1 = 19;
            this.lineShape1.Y2 = 55;
            // 
            // pnl_codigo
            // 
            this.pnl_codigo.Controls.Add(this.lblnombre);
            this.pnl_codigo.Controls.Add(this.label3);
            this.pnl_codigo.Controls.Add(this.item);
            this.pnl_codigo.Controls.Add(this.cencosid);
            this.pnl_codigo.Controls.Add(this.label4);
            this.pnl_codigo.Controls.Add(this.cencosname);
            this.pnl_codigo.Controls.Add(this.estacion);
            this.pnl_codigo.Controls.Add(this.label6);
            this.pnl_codigo.Location = new System.Drawing.Point(15, 19);
            this.pnl_codigo.Name = "pnl_codigo";
            this.pnl_codigo.Size = new System.Drawing.Size(340, 78);
            this.pnl_codigo.TabIndex = 66;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(127, 35);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(0, 13);
            this.lblnombre.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "CentroCosto:";
            // 
            // item
            // 
            this.item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item.Location = new System.Drawing.Point(78, 53);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(40, 20);
            this.item.TabIndex = 63;
            this.item.Text = "ventas al exterior";
            // 
            // cencosid
            // 
            this.cencosid.Location = new System.Drawing.Point(78, 9);
            this.cencosid.MaxLength = 5;
            this.cencosid.Name = "cencosid";
            this.cencosid.Size = new System.Drawing.Size(39, 21);
            this.cencosid.TabIndex = 17;
            this.cencosid.Text = "ventas al exterior";
            this.cencosid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cencosid_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Item:";
            // 
            // cencosname
            // 
            this.cencosname.Location = new System.Drawing.Point(120, 9);
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Size = new System.Drawing.Size(191, 21);
            this.cencosname.TabIndex = 18;
            this.cencosname.Text = "ventas al exterior";
            // 
            // estacion
            // 
            this.estacion.Location = new System.Drawing.Point(78, 30);
            this.estacion.MaxLength = 3;
            this.estacion.Name = "estacion";
            this.estacion.Size = new System.Drawing.Size(36, 21);
            this.estacion.TabIndex = 20;
            this.estacion.Text = "ventas al exterior";
            this.estacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.estacion_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Estacion-T:";
            // 
            // btn_fijar
            // 
            this.btn_fijar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fijar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_fijar.Image = global::BapFormulariosNet.Properties.Resources.go_check;
            this.btn_fijar.Location = new System.Drawing.Point(361, 19);
            this.btn_fijar.Name = "btn_fijar";
            this.btn_fijar.Size = new System.Drawing.Size(30, 26);
            this.btn_fijar.TabIndex = 65;
            this.btn_fijar.UseVisualStyleBackColor = true;
            this.btn_fijar.Click += new System.EventHandler(this.btn_fijar_Click);
            // 
            // unmedpeso
            // 
            this.unmedpeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unmedpeso.Location = new System.Drawing.Point(112, 650);
            this.unmedpeso.Name = "unmedpeso";
            this.unmedpeso.Size = new System.Drawing.Size(148, 20);
            this.unmedpeso.TabIndex = 48;
            this.unmedpeso.Text = "ventas al exterior";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.fechadoc);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 33);
            this.panel1.TabIndex = 2;
            // 
            // fechadoc
            // 
            this.fechadoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechadoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechadoc.Location = new System.Drawing.Point(544, 6);
            this.fechadoc.Name = "fechadoc";
            this.fechadoc.Size = new System.Drawing.Size(80, 20);
            this.fechadoc.TabIndex = 4;
            this.fechadoc.Value = new System.DateTime(2012, 12, 19, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(157, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(295, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "PRODUCTOS X ESTACIONES";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(497, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Fecha";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(28, 650);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(62, 13);
            this.label31.TabIndex = 57;
            this.label31.Text = "Unid. Peso:";
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
            this.btn_clave,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(629, 29);
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
            // codigo
            // 
            this.codigo.DataPropertyName = "productid";
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "productname";
            this.name.HeaderText = "Producto";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 300;
            // 
            // area
            // 
            this.area.DataPropertyName = "cencosname";
            this.area.HeaderText = "Area";
            this.area.Name = "area";
            this.area.ReadOnly = true;
            // 
            // codigo2
            // 
            this.codigo2.DataPropertyName = "estacion";
            this.codigo2.HeaderText = "Estacion";
            this.codigo2.Name = "codigo2";
            this.codigo2.ReadOnly = true;
            this.codigo2.Width = 75;
            // 
            // productidold
            // 
            this.productidold.DataPropertyName = "productidold";
            this.productidold.HeaderText = "CodigoOLD";
            this.productidold.Name = "productidold";
            this.productidold.ReadOnly = true;
            this.productidold.Visible = false;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // Frm_producto_est
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(629, 521);
            this.Controls.Add(this.btn_busqueda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgbproductos);
            this.Controls.Add(this.peso);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.unmedpeso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_producto_est";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Productos";
            this.Activated += new System.EventHandler(this.Frm_productos_est_Activated);
            this.Load += new System.EventHandler(this.Frm_productos_est_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_productos_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbproductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnl_codigo.ResumeLayout(false);
            this.pnl_codigo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.DateTimePicker fechadoc;
        internal System.Windows.Forms.TextBox productid;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox peso;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.TextBox unmedpeso;
        internal System.Windows.Forms.Label label31;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.TextBox productname;
        internal System.Windows.Forms.TextBox estacion;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox cencosname;
        internal System.Windows.Forms.TextBox cencosid;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgbproductos;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_busqueda;
        internal System.Windows.Forms.TextBox txt_busqueda;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        internal System.Windows.Forms.TextBox item;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_fijar;
        private System.Windows.Forms.Panel pnl_codigo;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.ToolTip Mensaje;
        private System.Windows.Forms.Panel panel3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_estado;
        private System.Windows.Forms.Button btn_siguiente;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidold;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;

    }
}