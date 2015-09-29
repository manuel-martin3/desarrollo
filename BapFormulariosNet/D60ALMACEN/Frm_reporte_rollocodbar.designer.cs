namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_reporte_rollocodbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_rollocodbar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_impcodbar = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.gridproductorollo = new System.Windows.Forms.DataGridView();
            this.grollo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gproductid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gproductname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grollolote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grollostockini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grollovalorini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grolloingre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grolloegres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grollostock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grollovaloractual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grollomedcompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grollofecompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grolloancho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grolloencog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gtipofallasid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdocuref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gstatu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.TextBox();
            this.rollohasta = new System.Windows.Forms.TextBox();
            this.rollodesde = new System.Windows.Forms.TextBox();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rollofecompra = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.tcamb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productid = new System.Windows.Forms.TextBox();
            this.Botonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridproductorollo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_editar,
            this.btn_cancelar,
            this.btn_impcodbar,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(771, 29);
            this.Botonera.TabIndex = 1;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(26, 26);
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_editar.Image = ((System.Drawing.Image)(resources.GetObject("btn_editar.Image")));
            this.btn_editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(26, 26);
            this.btn_editar.Text = "Editar";
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(26, 26);
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_impcodbar
            // 
            this.btn_impcodbar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_impcodbar.Image = global::BapFormulariosNet.Properties.Resources.btn_barcode;
            this.btn_impcodbar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_impcodbar.Name = "btn_impcodbar";
            this.btn_impcodbar.Size = new System.Drawing.Size(26, 26);
            this.btn_impcodbar.Text = "toolStripButton1";
            this.btn_impcodbar.ToolTipText = "Codigo de barras";
            this.btn_impcodbar.Click += new System.EventHandler(this.btn_impcodbar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(26, 26);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // gridproductorollo
            // 
            this.gridproductorollo.AllowUserToAddRows = false;
            this.gridproductorollo.AllowUserToDeleteRows = false;
            this.gridproductorollo.AllowUserToResizeColumns = false;
            this.gridproductorollo.AllowUserToResizeRows = false;
            this.gridproductorollo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridproductorollo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridproductorollo.ColumnHeadersHeight = 30;
            this.gridproductorollo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grollo,
            this.gproductid,
            this.gproductname,
            this.grollolote,
            this.grollostockini,
            this.grollovalorini,
            this.grolloingre,
            this.grolloegres,
            this.grollostock,
            this.grollovaloractual,
            this.grollomedcompra,
            this.grollofecompra,
            this.grolloancho,
            this.grolloencog,
            this.gtipofallasid,
            this.gdocuref,
            this.gstatu});
            this.gridproductorollo.Location = new System.Drawing.Point(4, 139);
            this.gridproductorollo.MultiSelect = false;
            this.gridproductorollo.Name = "gridproductorollo";
            this.gridproductorollo.RowHeadersVisible = false;
            this.gridproductorollo.RowHeadersWidth = 10;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridproductorollo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridproductorollo.RowTemplate.Height = 20;
            this.gridproductorollo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridproductorollo.Size = new System.Drawing.Size(761, 453);
            this.gridproductorollo.TabIndex = 47;
            this.gridproductorollo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridproductorollo_CellClick);
            this.gridproductorollo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridproductorollo_CellEnter);
            this.gridproductorollo.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridproductorollo_CellLeave);
            this.gridproductorollo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridproductorollo_KeyUp);
            // 
            // grollo
            // 
            this.grollo.DataPropertyName = "rollo";
            this.grollo.HeaderText = "rollo";
            this.grollo.Name = "grollo";
            this.grollo.Width = 95;
            // 
            // gproductid
            // 
            this.gproductid.DataPropertyName = "productid";
            this.gproductid.HeaderText = "productid";
            this.gproductid.Name = "gproductid";
            this.gproductid.Visible = false;
            // 
            // gproductname
            // 
            this.gproductname.DataPropertyName = "productname";
            this.gproductname.HeaderText = "Producto";
            this.gproductname.Name = "gproductname";
            this.gproductname.Width = 280;
            // 
            // grollolote
            // 
            this.grollolote.DataPropertyName = "rollolote";
            this.grollolote.HeaderText = "Lote";
            this.grollolote.Name = "grollolote";
            this.grollolote.Width = 80;
            // 
            // grollostockini
            // 
            this.grollostockini.DataPropertyName = "rollostockini";
            this.grollostockini.HeaderText = "rollostockini";
            this.grollostockini.Name = "grollostockini";
            this.grollostockini.Visible = false;
            // 
            // grollovalorini
            // 
            this.grollovalorini.DataPropertyName = "rollovalorini";
            this.grollovalorini.HeaderText = "rollovalorini";
            this.grollovalorini.Name = "grollovalorini";
            this.grollovalorini.Visible = false;
            // 
            // grolloingre
            // 
            this.grolloingre.DataPropertyName = "rolloingre";
            this.grolloingre.HeaderText = "rolloingre";
            this.grolloingre.Name = "grolloingre";
            this.grolloingre.Visible = false;
            // 
            // grolloegres
            // 
            this.grolloegres.DataPropertyName = "rolloegres";
            this.grolloegres.HeaderText = "rolloegres";
            this.grolloegres.Name = "grolloegres";
            this.grolloegres.Visible = false;
            // 
            // grollostock
            // 
            this.grollostock.DataPropertyName = "rollostock";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.grollostock.DefaultCellStyle = dataGridViewCellStyle2;
            this.grollostock.HeaderText = "Stock";
            this.grollostock.Name = "grollostock";
            this.grollostock.Width = 60;
            // 
            // grollovaloractual
            // 
            this.grollovaloractual.DataPropertyName = "rollovaloractual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.grollovaloractual.DefaultCellStyle = dataGridViewCellStyle3;
            this.grollovaloractual.HeaderText = "Valor";
            this.grollovaloractual.Name = "grollovaloractual";
            this.grollovaloractual.Width = 80;
            // 
            // grollomedcompra
            // 
            this.grollomedcompra.DataPropertyName = "rollomedcompra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.grollomedcompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.grollomedcompra.HeaderText = "M. Compra";
            this.grollomedcompra.Name = "grollomedcompra";
            this.grollomedcompra.Width = 83;
            // 
            // grollofecompra
            // 
            this.grollofecompra.DataPropertyName = "rollofecompra";
            this.grollofecompra.HeaderText = "Fecha";
            this.grollofecompra.Name = "grollofecompra";
            this.grollofecompra.Width = 80;
            // 
            // grolloancho
            // 
            this.grolloancho.DataPropertyName = "rolloancho";
            this.grolloancho.HeaderText = "rolloancho";
            this.grolloancho.Name = "grolloancho";
            this.grolloancho.Visible = false;
            // 
            // grolloencog
            // 
            this.grolloencog.DataPropertyName = "rolloencog";
            this.grolloencog.HeaderText = "rolloencog";
            this.grolloencog.Name = "grolloencog";
            this.grolloencog.Visible = false;
            // 
            // gtipofallasid
            // 
            this.gtipofallasid.DataPropertyName = "tipofallasid";
            this.gtipofallasid.HeaderText = "tipofallasid";
            this.gtipofallasid.Name = "gtipofallasid";
            this.gtipofallasid.Visible = false;
            // 
            // gdocuref
            // 
            this.gdocuref.DataPropertyName = "docuref";
            this.gdocuref.HeaderText = "docuref";
            this.gdocuref.Name = "gdocuref";
            this.gdocuref.Visible = false;
            // 
            // gstatu
            // 
            this.gstatu.DataPropertyName = "statu";
            this.gstatu.HeaderText = "statu";
            this.gstatu.Name = "gstatu";
            this.gstatu.Visible = false;
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(207, 86);
            this.productname.MaxLength = 0;
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(411, 21);
            this.productname.TabIndex = 43;
            // 
            // rollohasta
            // 
            this.rollohasta.Location = new System.Drawing.Point(290, 107);
            this.rollohasta.MaxLength = 10;
            this.rollohasta.Name = "rollohasta";
            this.rollohasta.Size = new System.Drawing.Size(100, 21);
            this.rollohasta.TabIndex = 45;
            this.rollohasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollohasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rollohasta_KeyPress);
            // 
            // rollodesde
            // 
            this.rollodesde.Location = new System.Drawing.Point(105, 107);
            this.rollodesde.MaxLength = 10;
            this.rollodesde.Name = "rollodesde";
            this.rollodesde.Size = new System.Drawing.Size(100, 21);
            this.rollodesde.TabIndex = 44;
            this.rollodesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollodesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rollodesde_KeyPress);
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.btn_search20;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(543, 107);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(75, 30);
            this.btn_busqueda.TabIndex = 46;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.rollofecompra);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tcamb);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 50);
            this.panel1.TabIndex = 2;
            // 
            // rollofecompra
            // 
            this.rollofecompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollofecompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.rollofecompra.Location = new System.Drawing.Point(7, 21);
            this.rollofecompra.Name = "rollofecompra";
            this.rollofecompra.Size = new System.Drawing.Size(90, 20);
            this.rollofecompra.TabIndex = 4;
            this.rollofecompra.Value = new System.DateTime(2012, 12, 19, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(213, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(383, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "IMPRESIÓN CODIGO BARRAS ROLLOS";
            // 
            // tcamb
            // 
            this.tcamb.Location = new System.Drawing.Point(709, 21);
            this.tcamb.Name = "tcamb";
            this.tcamb.Size = new System.Drawing.Size(56, 21);
            this.tcamb.TabIndex = 7;
            this.tcamb.Text = "3.420";
            this.tcamb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(705, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "T Cambio";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(8, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Fecha Compra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(214, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Rollo hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Rollo desde:";
            // 
            // productid
            // 
            this.productid.Location = new System.Drawing.Point(105, 86);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(100, 21);
            this.productid.TabIndex = 50;
            this.productid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // Frm_reporte_rollocodbar
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(771, 592);
            this.Controls.Add(this.productid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_busqueda);
            this.Controls.Add(this.productname);
            this.Controls.Add(this.rollohasta);
            this.Controls.Add(this.rollodesde);
            this.Controls.Add(this.gridproductorollo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_rollocodbar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Rollos";
            this.Activated += new System.EventHandler(this.Frm_movimiento_rollos_Activated);
            this.Load += new System.EventHandler(this.Frm_movimiento_rollos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_movimiento_rollos_KeyDown);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridproductorollo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_editar;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.TextBox tcamb;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.DateTimePicker rollofecompra;
        internal System.Windows.Forms.DataGridView gridproductorollo;
        private System.Windows.Forms.Button btn_busqueda;
        internal System.Windows.Forms.TextBox productname;
        internal System.Windows.Forms.TextBox rollohasta;
        internal System.Windows.Forms.TextBox rollodesde;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gproductid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gproductname;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollolote;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollostockini;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollovalorini;
        private System.Windows.Forms.DataGridViewTextBoxColumn grolloingre;
        private System.Windows.Forms.DataGridViewTextBoxColumn grolloegres;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollostock;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollovaloractual;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollomedcompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn grollofecompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn grolloancho;
        private System.Windows.Forms.DataGridViewTextBoxColumn grolloencog;
        private System.Windows.Forms.DataGridViewTextBoxColumn gtipofallasid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdocuref;
        private System.Windows.Forms.DataGridViewTextBoxColumn gstatu;
        private System.Windows.Forms.ToolStripButton btn_impcodbar;
        internal System.Windows.Forms.TextBox productid;

    }
}