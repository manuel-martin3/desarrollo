namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_reporte_productoCencos
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
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.fechadoc = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboalmacen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboreporte = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cencosname = new System.Windows.Forms.TextBox();
            this.cencosid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.perddnni = new System.Windows.Forms.TextBox();
            this.pername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cmMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GridExport = new System.Windows.Forms.ToolStripMenuItem();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.item = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._cencosid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._cencosname = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.estacion = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.nombrelargo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.productid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.productidold = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.productname = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.num = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.unmed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.nrodni = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_printstock = new System.Windows.Forms.Button();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.Botonera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.cmMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_cancelar,
            this.btn_imprimir,
            this.toolStripSeparator1,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(504, 29);
            this.Botonera.TabIndex = 2;
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
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = global::BapFormulariosNet.Properties.Resources.go_out2;
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 26);
            this.btn_salir.Text = "Salir";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 56);
            this.panel1.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(132, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(248, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Productos x Centro Costo";
            // 
            // fechadoc
            // 
            this.fechadoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechadoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechadoc.Location = new System.Drawing.Point(403, 19);
            this.fechadoc.Name = "fechadoc";
            this.fechadoc.Size = new System.Drawing.Size(80, 20);
            this.fechadoc.TabIndex = 4;
            this.fechadoc.Value = new System.DateTime(2012, 12, 19, 0, 0, 0, 0);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(355, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Fecha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fechadoc);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cboalmacen);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboreporte);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cencosname);
            this.groupBox1.Controls.Add(this.cencosid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.perddnni);
            this.groupBox1.Controls.Add(this.pername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 118);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cboalmacen
            // 
            this.cboalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboalmacen.FormattingEnabled = true;
            this.cboalmacen.Location = new System.Drawing.Point(79, 42);
            this.cboalmacen.Name = "cboalmacen";
            this.cboalmacen.Size = new System.Drawing.Size(168, 21);
            this.cboalmacen.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Almacen:";
            // 
            // cboreporte
            // 
            this.cboreporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboreporte.FormattingEnabled = true;
            this.cboreporte.Location = new System.Drawing.Point(79, 19);
            this.cboreporte.Name = "cboreporte";
            this.cboreporte.Size = new System.Drawing.Size(270, 21);
            this.cboreporte.TabIndex = 21;
            this.cboreporte.SelectedIndexChanged += new System.EventHandler(this.cboreporte_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "Reporte :";
            // 
            // cencosname
            // 
            this.cencosname.Location = new System.Drawing.Point(121, 66);
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Size = new System.Drawing.Size(191, 21);
            this.cencosname.TabIndex = 13;
            // 
            // cencosid
            // 
            this.cencosid.Location = new System.Drawing.Point(79, 66);
            this.cencosid.MaxLength = 5;
            this.cencosid.Name = "cencosid";
            this.cencosid.Size = new System.Drawing.Size(39, 21);
            this.cencosid.TabIndex = 12;
            this.cencosid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cencosid_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Area :";
            // 
            // perddnni
            // 
            this.perddnni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perddnni.Location = new System.Drawing.Point(78, 88);
            this.perddnni.MaxLength = 8;
            this.perddnni.Name = "perddnni";
            this.perddnni.Size = new System.Drawing.Size(60, 20);
            this.perddnni.TabIndex = 17;
            this.perddnni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.perddnni_KeyDown);
            // 
            // pername
            // 
            this.pername.Location = new System.Drawing.Point(141, 89);
            this.pername.Name = "pername";
            this.pername.ReadOnly = true;
            this.pername.Size = new System.Drawing.Size(273, 21);
            this.pername.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Personal:";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.cmMenuGrid;
            this.gridControl1.Location = new System.Drawing.Point(5, 222);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(831, 277);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            // 
            // cmMenuGrid
            // 
            this.cmMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GridExport});
            this.cmMenuGrid.Name = "cmMenuGrid";
            this.cmMenuGrid.Size = new System.Drawing.Size(156, 26);
            // 
            // GridExport
            // 
            this.GridExport.Name = "GridExport";
            this.GridExport.Size = new System.Drawing.Size(155, 22);
            this.GridExport.Text = "Exportar a Excel";
            this.GridExport.Click += new System.EventHandler(this.GridExport_Click);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.item,
            this._cencosid,
            this._cencosname,
            this.estacion,
            this.nrodni,
            this.nombrelargo,
            this.productid,
            this.productname,
            this.productidold,
            this.num,
            this.unmed});
            this.advBandedGridView1.CustomizationFormBounds = new System.Drawing.Rectangle(720, 392, 216, 208);
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Producto x Centro de Costo";
            this.gridBand1.Columns.Add(this.item);
            this.gridBand1.Columns.Add(this._cencosid);
            this.gridBand1.Columns.Add(this._cencosname);
            this.gridBand1.Columns.Add(this.estacion);
            this.gridBand1.Columns.Add(this.nombrelargo);
            this.gridBand1.Columns.Add(this.productid);
            this.gridBand1.Columns.Add(this.productidold);
            this.gridBand1.Columns.Add(this.productname);
            this.gridBand1.Columns.Add(this.num);
            this.gridBand1.Columns.Add(this.unmed);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.RowCount = 2;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 2058;
            // 
            // item
            // 
            this.item.Caption = "Item";
            this.item.FieldName = "item";
            this.item.Name = "item";
            this.item.Visible = true;
            this.item.Width = 49;
            // 
            // _cencosid
            // 
            this._cencosid.Caption = "CentroCosto";
            this._cencosid.FieldName = "cencosid";
            this._cencosid.Name = "_cencosid";
            this._cencosid.Visible = true;
            this._cencosid.Width = 73;
            // 
            // _cencosname
            // 
            this._cencosname.Caption = "Area";
            this._cencosname.FieldName = "cencosname";
            this._cencosname.Name = "_cencosname";
            this._cencosname.Visible = true;
            this._cencosname.Width = 121;
            // 
            // estacion
            // 
            this.estacion.Caption = "Estacion";
            this.estacion.FieldName = "estacion";
            this.estacion.Name = "estacion";
            this.estacion.Visible = true;
            this.estacion.Width = 100;
            // 
            // nombrelargo
            // 
            this.nombrelargo.Caption = "Persona";
            this.nombrelargo.FieldName = "nombrelargo";
            this.nombrelargo.Name = "nombrelargo";
            this.nombrelargo.Visible = true;
            this.nombrelargo.Width = 208;
            // 
            // productid
            // 
            this.productid.Caption = "Codigo";
            this.productid.FieldName = "productid";
            this.productid.Name = "productid";
            this.productid.Visible = true;
            this.productid.Width = 99;
            // 
            // productidold
            // 
            this.productidold.Caption = "Codigo de Barra";
            this.productidold.FieldName = "productidold";
            this.productidold.Name = "productidold";
            this.productidold.Visible = true;
            this.productidold.Width = 99;
            // 
            // productname
            // 
            this.productname.Caption = "Producto";
            this.productname.FieldName = "productname";
            this.productname.Name = "productname";
            this.productname.Visible = true;
            this.productname.Width = 128;
            // 
            // num
            // 
            this.num.Caption = "Cantidad";
            this.num.FieldName = "num";
            this.num.Name = "num";
            this.num.Visible = true;
            this.num.Width = 99;
            // 
            // unmed
            // 
            this.unmed.Caption = "UnMed";
            this.unmed.FieldName = "unmed";
            this.unmed.Name = "unmed";
            this.unmed.Visible = true;
            this.unmed.Width = 1082;
            // 
            // nrodni
            // 
            this.nrodni.Caption = "DNI";
            this.nrodni.FieldName = "nrodni";
            this.nrodni.Name = "nrodni";
            this.nrodni.Visible = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(842, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_printstock
            // 
            this.btn_printstock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_printstock.Image = global::BapFormulariosNet.Properties.Resources.print_go;
            this.btn_printstock.Location = new System.Drawing.Point(838, 208);
            this.btn_printstock.Name = "btn_printstock";
            this.btn_printstock.Size = new System.Drawing.Size(35, 40);
            this.btn_printstock.TabIndex = 69;
            this.btn_printstock.UseVisualStyleBackColor = true;
            this.btn_printstock.Click += new System.EventHandler(this.btn_printstock_Click);
            // 
            // Frm_reporte_productoCencos
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 185);
            this.Controls.Add(this.btn_printstock);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_reporte_productoCencos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos x Centro de Costo";
            this.Load += new System.EventHandler(this.Frm_personal_cencos_Load);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.cmMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DateTimePicker fechadoc;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox cencosname;
        internal System.Windows.Forms.TextBox cencosid;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox perddnni;
        internal System.Windows.Forms.TextBox pername;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboreporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboalmacen;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_printstock;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn item;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _cencosid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _cencosname;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn estacion;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn nombrelargo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn productid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn productidold;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn productname;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn num;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn unmed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn nrodni;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.ContextMenuStrip cmMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem GridExport;
        private System.Windows.Forms.SaveFileDialog sfdFile;
    }
}