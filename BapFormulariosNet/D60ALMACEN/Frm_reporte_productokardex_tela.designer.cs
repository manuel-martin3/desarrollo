namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_reporte_productokardex_tela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_productokardex_tela));
            this.numdococ1 = new System.Windows.Forms.TextBox();
            this.numdococ = new System.Windows.Forms.TextBox();
            this.serref = new System.Windows.Forms.TextBox();
            this.direcdeta = new System.Windows.Forms.TextBox();
            this.direcname = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ctactename = new System.Windows.Forms.TextBox();
            this.ctacte = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.produbic = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.mottrasladointname = new System.Windows.Forms.TextBox();
            this.mottrasladointid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.almacaccionid = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fechdocfin = new System.Windows.Forms.DateTimePicker();
            this.fechdocini = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colorname = new System.Windows.Forms.TextBox();
            this.colorid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productname = new System.Windows.Forms.TextBox();
            this.productid = new System.Windows.Forms.TextBox();
            this.gruponame = new System.Windows.Forms.TextBox();
            this.grupoid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lineaname = new System.Windows.Forms.TextBox();
            this.lineaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subgrupoid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subgruponame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_buscar = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.Mensaje = new System.Windows.Forms.ToolTip(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.localdes = new System.Windows.Forms.ComboBox();
            this.cbo_moduloides = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numdococ1
            // 
            this.numdococ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numdococ1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numdococ1.Location = new System.Drawing.Point(144, 180);
            this.numdococ1.MaxLength = 4;
            this.numdococ1.Name = "numdococ1";
            this.numdococ1.Size = new System.Drawing.Size(38, 20);
            this.numdococ1.TabIndex = 91;
            this.numdococ1.Text = "2013";
            this.Mensaje.SetToolTip(this.numdococ1, "Ingrese Año ó 0000");
            this.numdococ1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numdococ1_KeyDown);
            // 
            // numdococ
            // 
            this.numdococ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numdococ.Location = new System.Drawing.Point(183, 180);
            this.numdococ.MaxLength = 6;
            this.numdococ.Name = "numdococ";
            this.numdococ.Size = new System.Drawing.Size(51, 20);
            this.numdococ.TabIndex = 90;
            this.numdococ.Text = "000001";
            this.numdococ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Mensaje.SetToolTip(this.numdococ, "Ingrese Numero O/C");
            this.numdococ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numdococ_KeyDown);
            // 
            // serref
            // 
            this.serref.Location = new System.Drawing.Point(106, 180);
            this.serref.MaxLength = 4;
            this.serref.Name = "serref";
            this.serref.Size = new System.Drawing.Size(37, 21);
            this.serref.TabIndex = 89;
            this.serref.Text = "0330";
            this.serref.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Mensaje.SetToolTip(this.serref, "Ingrese 0330 ó 0001");
            this.serref.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serref_KeyDown);
            // 
            // direcdeta
            // 
            this.direcdeta.Location = new System.Drawing.Point(224, 252);
            this.direcdeta.Name = "direcdeta";
            this.direcdeta.Size = new System.Drawing.Size(280, 21);
            this.direcdeta.TabIndex = 84;
            this.direcdeta.Text = "ventas al exterior";
            // 
            // direcname
            // 
            this.direcname.Location = new System.Drawing.Point(106, 252);
            this.direcname.MaxLength = 13;
            this.direcname.Name = "direcname";
            this.direcname.Size = new System.Drawing.Size(117, 21);
            this.direcname.TabIndex = 83;
            this.direcname.Text = "ventas al exterior";
            this.direcname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.direcname_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(33, 256);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 82;
            this.label14.Text = "Establec:";
            // 
            // ctactename
            // 
            this.ctactename.Location = new System.Drawing.Point(163, 229);
            this.ctactename.Name = "ctactename";
            this.ctactename.Size = new System.Drawing.Size(341, 21);
            this.ctactename.TabIndex = 80;
            this.ctactename.Text = "ventas al exterior";
            // 
            // ctacte
            // 
            this.ctacte.Location = new System.Drawing.Point(106, 229);
            this.ctacte.MaxLength = 13;
            this.ctacte.Name = "ctacte";
            this.ctacte.Size = new System.Drawing.Size(56, 21);
            this.ctacte.TabIndex = 79;
            this.ctacte.Text = "ventas al exterior";
            this.ctacte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctacte_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(43, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 81;
            this.label13.Text = "Cliente:";
            // 
            // produbic
            // 
            this.produbic.Location = new System.Drawing.Point(106, 276);
            this.produbic.MaxLength = 4;
            this.produbic.Name = "produbic";
            this.produbic.Size = new System.Drawing.Size(47, 21);
            this.produbic.TabIndex = 78;
            this.produbic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.produbic_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(25, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 77;
            this.label12.Text = "Ubicacion:";
            // 
            // mottrasladointname
            // 
            this.mottrasladointname.Location = new System.Drawing.Point(153, 202);
            this.mottrasladointname.Name = "mottrasladointname";
            this.mottrasladointname.Size = new System.Drawing.Size(211, 21);
            this.mottrasladointname.TabIndex = 25;
            this.mottrasladointname.Text = "ventas al exterior";
            // 
            // mottrasladointid
            // 
            this.mottrasladointid.Location = new System.Drawing.Point(106, 202);
            this.mottrasladointid.MaxLength = 2;
            this.mottrasladointid.Name = "mottrasladointid";
            this.mottrasladointid.Size = new System.Drawing.Size(48, 21);
            this.mottrasladointid.TabIndex = 24;
            this.mottrasladointid.Text = "ventas al exterior";
            this.mottrasladointid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mottrasladointid_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(44, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 76;
            this.label10.Text = "Motivo:";
            // 
            // almacaccionid
            // 
            this.almacaccionid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.almacaccionid.DropDownWidth = 250;
            this.almacaccionid.Location = new System.Drawing.Point(106, 33);
            this.almacaccionid.Name = "almacaccionid";
            this.almacaccionid.Size = new System.Drawing.Size(117, 21);
            this.almacaccionid.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Tipo Movi:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Ord Compra:";
            // 
            // fechdocfin
            // 
            this.fechdocfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocfin.Location = new System.Drawing.Point(285, 302);
            this.fechdocfin.Name = "fechdocfin";
            this.fechdocfin.Size = new System.Drawing.Size(80, 20);
            this.fechdocfin.TabIndex = 27;
            this.fechdocfin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fechdocfin_KeyDown);
            // 
            // fechdocini
            // 
            this.fechdocini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocini.Location = new System.Drawing.Point(106, 301);
            this.fechdocini.Name = "fechdocini";
            this.fechdocini.Size = new System.Drawing.Size(80, 20);
            this.fechdocini.TabIndex = 26;
            this.fechdocini.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fechdocini_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(235, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Desde:";
            // 
            // colorname
            // 
            this.colorname.Location = new System.Drawing.Point(155, 158);
            this.colorname.Name = "colorname";
            this.colorname.Size = new System.Drawing.Size(211, 21);
            this.colorname.TabIndex = 21;
            this.colorname.Text = "ventas al exterior";
            // 
            // colorid
            // 
            this.colorid.Location = new System.Drawing.Point(106, 158);
            this.colorid.Name = "colorid";
            this.colorid.Size = new System.Drawing.Size(48, 21);
            this.colorid.TabIndex = 18;
            this.colorid.Text = "ventas al exterior";
            this.colorid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colorid_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Color:";
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(190, 136);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(317, 21);
            this.productname.TabIndex = 17;
            this.productname.Text = "ventas al exterior";
            // 
            // productid
            // 
            this.productid.Location = new System.Drawing.Point(106, 136);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(83, 21);
            this.productid.TabIndex = 16;
            this.productid.Text = "ventas al exterior";
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // gruponame
            // 
            this.gruponame.Location = new System.Drawing.Point(155, 80);
            this.gruponame.Name = "gruponame";
            this.gruponame.Size = new System.Drawing.Size(355, 21);
            this.gruponame.TabIndex = 13;
            this.gruponame.Text = "ventas al exterior";
            // 
            // grupoid
            // 
            this.grupoid.Location = new System.Drawing.Point(106, 80);
            this.grupoid.MaxLength = 4;
            this.grupoid.Name = "grupoid";
            this.grupoid.Size = new System.Drawing.Size(48, 21);
            this.grupoid.TabIndex = 12;
            this.grupoid.Text = "ventas al exterior";
            this.grupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grupoid_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Grupo:";
            // 
            // lineaname
            // 
            this.lineaname.Location = new System.Drawing.Point(155, 58);
            this.lineaname.Name = "lineaname";
            this.lineaname.Size = new System.Drawing.Size(355, 21);
            this.lineaname.TabIndex = 11;
            this.lineaname.Text = "ventas al exterior";
            // 
            // lineaid
            // 
            this.lineaid.Location = new System.Drawing.Point(106, 58);
            this.lineaid.MaxLength = 3;
            this.lineaid.Name = "lineaid";
            this.lineaid.Size = new System.Drawing.Size(48, 21);
            this.lineaid.TabIndex = 10;
            this.lineaid.Text = "ventas al exterior";
            this.lineaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lineaid_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Línea :";
            // 
            // subgrupoid
            // 
            this.subgrupoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subgrupoid.Location = new System.Drawing.Point(106, 102);
            this.subgrupoid.MaxLength = 3;
            this.subgrupoid.Name = "subgrupoid";
            this.subgrupoid.Size = new System.Drawing.Size(48, 20);
            this.subgrupoid.TabIndex = 14;
            this.subgrupoid.Text = "ventas al exterior";
            this.subgrupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subgrupoid_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Producto:";
            // 
            // subgruponame
            // 
            this.subgruponame.Location = new System.Drawing.Point(155, 102);
            this.subgruponame.Name = "subgruponame";
            this.subgruponame.Size = new System.Drawing.Size(355, 21);
            this.subgruponame.TabIndex = 15;
            this.subgruponame.Text = "ventas al exterior";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Articulo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 50);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(143, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(276, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "KARDEX POR PRODUCTOS";
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
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_buscar
            // 
            this.btn_buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(26, 26);
            this.btn_buscar.Text = "toolStripButton15";
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
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_cancelar,
            this.toolStripSeparator1,
            this.btn_imprimir,
            this.btn_excel,
            this.toolStripSeparator2,
            this.btn_buscar,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(565, 29);
            this.Botonera.TabIndex = 1;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_excel
            // 
            this.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_excel.Image = global::BapFormulariosNet.Properties.Resources.btn_excel20;
            this.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(26, 26);
            this.btn_excel.Text = "toolStripButton1";
            this.btn_excel.ToolTipText = "Excel";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.localdes);
            this.panelControl1.Controls.Add(this.cbo_moduloides);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.numdococ1);
            this.panelControl1.Controls.Add(this.fechdocfin);
            this.panelControl1.Controls.Add(this.numdococ);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.serref);
            this.panelControl1.Controls.Add(this.subgruponame);
            this.panelControl1.Controls.Add(this.direcdeta);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.direcname);
            this.panelControl1.Controls.Add(this.subgrupoid);
            this.panelControl1.Controls.Add(this.label14);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.ctactename);
            this.panelControl1.Controls.Add(this.lineaid);
            this.panelControl1.Controls.Add(this.ctacte);
            this.panelControl1.Controls.Add(this.lineaname);
            this.panelControl1.Controls.Add(this.label13);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.produbic);
            this.panelControl1.Controls.Add(this.grupoid);
            this.panelControl1.Controls.Add(this.label12);
            this.panelControl1.Controls.Add(this.gruponame);
            this.panelControl1.Controls.Add(this.mottrasladointname);
            this.panelControl1.Controls.Add(this.productid);
            this.panelControl1.Controls.Add(this.mottrasladointid);
            this.panelControl1.Controls.Add(this.productname);
            this.panelControl1.Controls.Add(this.label10);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.almacaccionid);
            this.panelControl1.Controls.Add(this.colorid);
            this.panelControl1.Controls.Add(this.label9);
            this.panelControl1.Controls.Add(this.colorname);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.fechdocini);
            this.panelControl1.Location = new System.Drawing.Point(0, 67);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(563, 331);
            this.panelControl1.TabIndex = 9;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(346, 12);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 95;
            this.labelControl7.Text = "» LOCAL:";
            // 
            // localdes
            // 
            this.localdes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localdes.DropDownWidth = 170;
            this.localdes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localdes.FormattingEnabled = true;
            this.localdes.Location = new System.Drawing.Point(398, 9);
            this.localdes.Name = "localdes";
            this.localdes.Size = new System.Drawing.Size(144, 21);
            this.localdes.TabIndex = 94;
            // 
            // cbo_moduloides
            // 
            this.cbo_moduloides.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_moduloides.DropDownWidth = 250;
            this.cbo_moduloides.Location = new System.Drawing.Point(105, 9);
            this.cbo_moduloides.Name = "cbo_moduloides";
            this.cbo_moduloides.Size = new System.Drawing.Size(229, 21);
            this.cbo_moduloides.TabIndex = 93;
            this.cbo_moduloides.SelectedIndexChanged += new System.EventHandler(this.cbo_moduloides_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(27, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 92;
            this.labelControl2.Text = "» ALMACEN:";
            // 
            // Frm_reporte_productokardex_tela
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(565, 399);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Id_Perfil = "";
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_productokardex_tela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kardex por Producto";
            this.Activated += new System.EventHandler(this.Frm_reporte_stockrollo_Activated);
            this.Load += new System.EventHandler(this.Frm_reporte_stockrollo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_reporte_stockrollo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox subgruponame;
        internal System.Windows.Forms.TextBox subgrupoid;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox lineaid;
        internal System.Windows.Forms.TextBox lineaname;
        internal System.Windows.Forms.TextBox gruponame;
        internal System.Windows.Forms.TextBox grupoid;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox productid;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox colorname;
        internal System.Windows.Forms.TextBox colorid;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox productname;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_buscar;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_excel;
        internal System.Windows.Forms.DateTimePicker fechdocfin;
        internal System.Windows.Forms.DateTimePicker fechdocini;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox almacaccionid;
        internal System.Windows.Forms.TextBox mottrasladointname;
        internal System.Windows.Forms.TextBox mottrasladointid;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox produbic;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox direcdeta;
        internal System.Windows.Forms.TextBox direcname;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox ctactename;
        internal System.Windows.Forms.TextBox ctacte;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox numdococ1;
        internal System.Windows.Forms.TextBox numdococ;
        internal System.Windows.Forms.TextBox serref;
        private System.Windows.Forms.ToolTip Mensaje;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        internal System.Windows.Forms.ComboBox localdes;
        internal System.Windows.Forms.ComboBox cbo_moduloides;
        private DevExpress.XtraEditors.LabelControl labelControl2;

    }
}