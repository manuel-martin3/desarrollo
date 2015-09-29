namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    partial class Frm_persona_cencos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_persona_cencos));
            this.btn_fijar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtcencosname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.cenestado = new System.Windows.Forms.RadioListBox();
            this.DataPersonaCencos = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estacio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Persona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccfecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosnam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.estacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cencosname = new System.Windows.Forms.TextBox();
            this.cencosid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.perddnni = new System.Windows.Forms.TextBox();
            this.pername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataPersonaCencos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_fijar
            // 
            this.btn_fijar.BackgroundImage = global::BapFormulariosNet.Properties.Resources.parte;
            this.btn_fijar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_fijar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fijar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_fijar.Image = global::BapFormulariosNet.Properties.Resources.parte;
            this.btn_fijar.Location = new System.Drawing.Point(485, 83);
            this.btn_fijar.Name = "btn_fijar";
            this.btn_fijar.Size = new System.Drawing.Size(104, 101);
            this.btn_fijar.TabIndex = 109;
            this.btn_fijar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtcencosname);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtbuscar);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btn_busqueda);
            this.groupBox3.Controls.Add(this.cenestado);
            this.groupBox3.Location = new System.Drawing.Point(4, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 226);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Busqueda:";
            // 
            // txtcencosname
            // 
            this.txtcencosname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcencosname.Location = new System.Drawing.Point(6, 85);
            this.txtcencosname.Name = "txtcencosname";
            this.txtcencosname.Size = new System.Drawing.Size(175, 21);
            this.txtcencosname.TabIndex = 67;
            this.txtcencosname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcencosname_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Area:";
            // 
            // txtbuscar
            // 
            this.txtbuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(6, 39);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(177, 20);
            this.txtbuscar.TabIndex = 26;
            this.txtbuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbuscar_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tipo:";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(100, 185);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(81, 35);
            this.btn_busqueda.TabIndex = 64;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // cenestado
            // 
            this.cenestado.BackColor = System.Drawing.Color.Transparent;
            this.cenestado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cenestado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cenestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cenestado.FormattingEnabled = true;
            this.cenestado.ItemHeight = 16;
            this.cenestado.Location = new System.Drawing.Point(10, 138);
            this.cenestado.Name = "cenestado";
            this.cenestado.Size = new System.Drawing.Size(108, 32);
            this.cenestado.TabIndex = 61;
            // 
            // DataPersonaCencos
            // 
            this.DataPersonaCencos.AllowUserToAddRows = false;
            this.DataPersonaCencos.AllowUserToDeleteRows = false;
            this.DataPersonaCencos.AllowUserToResizeColumns = false;
            this.DataPersonaCencos.AllowUserToResizeRows = false;
            this.DataPersonaCencos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataPersonaCencos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataPersonaCencos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.cencosi,
            this.Estacio,
            this.dni,
            this.Persona,
            this.ccfecha,
            this.cencosnam,
            this.ccestado});
            this.DataPersonaCencos.Location = new System.Drawing.Point(204, 196);
            this.DataPersonaCencos.Name = "DataPersonaCencos";
            this.DataPersonaCencos.ReadOnly = true;
            this.DataPersonaCencos.RowHeadersVisible = false;
            this.DataPersonaCencos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataPersonaCencos.Size = new System.Drawing.Size(441, 228);
            this.DataPersonaCencos.TabIndex = 60;
            this.DataPersonaCencos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataPersonaCencos_CellClick);
            this.DataPersonaCencos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataPersonaCencos_CellEnter);
            this.DataPersonaCencos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataPersonaCencos_CellLeave);
            this.DataPersonaCencos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataPersonaCencos_KeyUp);
            // 
            // item
            // 
            this.item.DataPropertyName = "item";
            this.item.HeaderText = "Item";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Visible = false;
            // 
            // cencosi
            // 
            this.cencosi.DataPropertyName = "cencosid";
            this.cencosi.HeaderText = "CCosto";
            this.cencosi.Name = "cencosi";
            this.cencosi.ReadOnly = true;
            this.cencosi.Width = 50;
            // 
            // Estacio
            // 
            this.Estacio.DataPropertyName = "cencosestacion";
            this.Estacio.HeaderText = "Estacion";
            this.Estacio.Name = "Estacio";
            this.Estacio.ReadOnly = true;
            this.Estacio.Width = 30;
            // 
            // dni
            // 
            this.dni.DataPropertyName = "perdni";
            this.dni.HeaderText = "DNI";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Width = 65;
            // 
            // Persona
            // 
            this.Persona.DataPropertyName = "nombrelargo";
            this.Persona.HeaderText = "Persona";
            this.Persona.Name = "Persona";
            this.Persona.ReadOnly = true;
            this.Persona.Width = 180;
            // 
            // ccfecha
            // 
            this.ccfecha.DataPropertyName = "cencosfecha";
            this.ccfecha.HeaderText = "Fecha";
            this.ccfecha.Name = "ccfecha";
            this.ccfecha.ReadOnly = true;
            this.ccfecha.Width = 72;
            // 
            // cencosnam
            // 
            this.cencosnam.DataPropertyName = "cencosname";
            this.cencosnam.HeaderText = "CCname";
            this.cencosnam.Name = "cencosnam";
            this.cencosnam.ReadOnly = true;
            this.cencosnam.Visible = false;
            // 
            // ccestado
            // 
            this.ccestado.DataPropertyName = "cencosestado";
            this.ccestado.HeaderText = "CCestado";
            this.ccestado.Name = "ccestado";
            this.ccestado.ReadOnly = true;
            this.ccestado.Visible = false;
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
            this.groupBox1.Controls.Add(this.estacion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cencosname);
            this.groupBox1.Controls.Add(this.cencosid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.perddnni);
            this.groupBox1.Controls.Add(this.pername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 101);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Codigo";
            // 
            // estacion
            // 
            this.estacion.Location = new System.Drawing.Point(90, 39);
            this.estacion.MaxLength = 3;
            this.estacion.Name = "estacion";
            this.estacion.Size = new System.Drawing.Size(36, 21);
            this.estacion.TabIndex = 15;
            this.estacion.Text = "001";
            this.estacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.estacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.estacion_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Estacion-T:";
            // 
            // cencosname
            // 
            this.cencosname.Location = new System.Drawing.Point(127, 18);
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Size = new System.Drawing.Size(191, 21);
            this.cencosname.TabIndex = 13;
            this.cencosname.Text = "Sistemas";
            // 
            // cencosid
            // 
            this.cencosid.Location = new System.Drawing.Point(90, 18);
            this.cencosid.MaxLength = 5;
            this.cencosid.Name = "cencosid";
            this.cencosid.Size = new System.Drawing.Size(37, 21);
            this.cencosid.TabIndex = 12;
            this.cencosid.Text = "10003";
            this.cencosid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cencosid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cencosid_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "CentroCosto:";
            // 
            // perddnni
            // 
            this.perddnni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perddnni.Location = new System.Drawing.Point(90, 60);
            this.perddnni.MaxLength = 8;
            this.perddnni.Name = "perddnni";
            this.perddnni.Size = new System.Drawing.Size(60, 20);
            this.perddnni.TabIndex = 17;
            this.perddnni.Text = "71724167";
            this.perddnni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.perddnni_KeyDown);
            // 
            // pername
            // 
            this.pername.Location = new System.Drawing.Point(150, 60);
            this.pername.Name = "pername";
            this.pername.ReadOnly = true;
            this.pername.Size = new System.Drawing.Size(273, 21);
            this.pername.TabIndex = 18;
            this.pername.Text = "Vilchez Rosales Hugo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Personal:";
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
            this.panel1.Size = new System.Drawing.Size(648, 35);
            this.panel1.TabIndex = 2;
            // 
            // fechadoc
            // 
            this.fechadoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechadoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechadoc.Location = new System.Drawing.Point(532, 6);
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
            this.label11.Location = new System.Drawing.Point(194, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(219, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Personal Centro Costo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(482, 9);
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
            this.Botonera.Size = new System.Drawing.Size(648, 29);
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
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(648, 428);
            this.shapeContainer1.TabIndex = 65;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 198;
            this.lineShape1.X2 = 197;
            this.lineShape1.Y1 = 195;
            this.lineShape1.Y2 = 426;
            // 
            // Frm_persona_cencos
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(648, 428);
            this.Controls.Add(this.btn_fijar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DataPersonaCencos);
            this.Controls.Add(this.peso);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.unmedpeso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_persona_cencos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal - CCostos";
            this.Load += new System.EventHandler(this.Frm_productos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_productos_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataPersonaCencos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox pername;
        internal System.Windows.Forms.TextBox perddnni;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox cencosid;
        internal System.Windows.Forms.TextBox cencosname;
        internal System.Windows.Forms.TextBox estacion;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox peso;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.TextBox unmedpeso;
        internal System.Windows.Forms.Label label31;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.RadioListBox cenestado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_busqueda;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscar;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DataGridView DataPersonaCencos;
        private System.Windows.Forms.Button btn_fijar;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estacio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Persona;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccfecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosnam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccestado;
        private System.Windows.Forms.TextBox txtcencosname;
        internal System.Windows.Forms.Label label5;

    }
}