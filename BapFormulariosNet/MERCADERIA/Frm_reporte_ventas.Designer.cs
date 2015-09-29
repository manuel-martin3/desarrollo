namespace BapFormulariosNet.MERCADERIA
{
    partial class Frm_reporte_ventas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_modulo = new System.Windows.Forms.ComboBox();
            this.cbo_local = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.fechdocfin = new System.Windows.Forms.DateTimePicker();
            this.fechdocini = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Examinar = new DevExpress.XtraGrid.GridControl();
            this.gv_examinar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.local = new DevExpress.XtraGrid.Columns.GridColumn();
            this.moduloid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.localname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.importe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.efectivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tarjeta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarAExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdruta = new System.Windows.Forms.SaveFileDialog();
            this.Examinar2 = new DevExpress.XtraGrid.GridControl();
            this.gv_examinar2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._localname = new DevExpress.XtraGrid.Columns.GridColumn();
            this._fechdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tipodoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.serdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numdoc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numdoc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this._cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this._importe = new DevExpress.XtraGrid.Columns.GridColumn();
            this._efectivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this._tarjeta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Examinar3 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this._localname_ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._fechdoc_ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._tipodoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._serdoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._numdoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.productname = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._cantidad_ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._importe_ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.comision = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.implista = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.utilista = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this._costo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.uticosto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ctactename = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.vendorname = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_examinar)).BeginInit();
            this.cmMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_examinar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modulo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Local:";
            this.label2.Visible = false;
            // 
            // cbo_modulo
            // 
            this.cbo_modulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_modulo.FormattingEnabled = true;
            this.cbo_modulo.Location = new System.Drawing.Point(80, 39);
            this.cbo_modulo.Name = "cbo_modulo";
            this.cbo_modulo.Size = new System.Drawing.Size(226, 21);
            this.cbo_modulo.TabIndex = 2;
            this.cbo_modulo.SelectedIndexChanged += new System.EventHandler(this.cbo_modulo_SelectedIndexChanged);
            // 
            // cbo_local
            // 
            this.cbo_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_local.FormattingEnabled = true;
            this.cbo_local.Location = new System.Drawing.Point(567, 39);
            this.cbo_local.Name = "cbo_local";
            this.cbo_local.Size = new System.Drawing.Size(169, 21);
            this.cbo_local.TabIndex = 3;
            this.cbo_local.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(-14, -23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1396, 56);
            this.panel1.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(586, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Detalle de Ventas";
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 12;
            this.lineShape1.X2 = 622;
            this.lineShape1.Y1 = 93;
            this.lineShape1.Y2 = 93;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1284, 578);
            this.shapeContainer1.TabIndex = 5;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderWidth = 2;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 7;
            this.lineShape3.X2 = 1355;
            this.lineShape3.Y1 = 380;
            this.lineShape3.Y2 = 380;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderWidth = 2;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 6;
            this.lineShape2.X2 = 963;
            this.lineShape2.Y1 = 225;
            this.lineShape2.Y2 = 224;
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(328, 59);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(95, 28);
            this.btn_busqueda.TabIndex = 69;
            this.btn_busqueda.Text = "&Consultar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // fechdocfin
            // 
            this.fechdocfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocfin.Location = new System.Drawing.Point(226, 68);
            this.fechdocfin.Name = "fechdocfin";
            this.fechdocfin.Size = new System.Drawing.Size(80, 20);
            this.fechdocfin.TabIndex = 71;
            // 
            // fechdocini
            // 
            this.fechdocini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocini.Location = new System.Drawing.Point(81, 67);
            this.fechdocini.Name = "fechdocini";
            this.fechdocini.Size = new System.Drawing.Size(80, 20);
            this.fechdocini.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 73;
            this.label7.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "Desde:";
            // 
            // Examinar
            // 
            this.Examinar.Location = new System.Drawing.Point(7, 99);
            this.Examinar.MainView = this.gv_examinar;
            this.Examinar.Name = "Examinar";
            this.Examinar.Size = new System.Drawing.Size(615, 116);
            this.Examinar.TabIndex = 74;
            this.Examinar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_examinar});
            this.Examinar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Examinar_KeyUp);
            this.Examinar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Examinar_MouseClick);
            // 
            // gv_examinar
            // 
            this.gv_examinar.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Silver;
            this.gv_examinar.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gv_examinar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.local,
            this.moduloid,
            this.localname,
            this.fechdoc,
            this.cantidad,
            this.importe,
            this.efectivo,
            this.tarjeta});
            this.gv_examinar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gv_examinar.GridControl = this.Examinar;
            this.gv_examinar.Name = "gv_examinar";
            this.gv_examinar.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_examinar.OptionsView.EnableAppearanceOddRow = true;
            this.gv_examinar.OptionsView.ShowGroupPanel = false;
            // 
            // local
            // 
            this.local.Caption = "Local";
            this.local.Name = "local";
            // 
            // moduloid
            // 
            this.moduloid.Caption = "Modulo";
            this.moduloid.Name = "moduloid";
            // 
            // localname
            // 
            this.localname.Caption = "Tienda";
            this.localname.FieldName = "localname";
            this.localname.Name = "localname";
            this.localname.OptionsColumn.AllowEdit = false;
            this.localname.Visible = true;
            this.localname.VisibleIndex = 0;
            this.localname.Width = 125;
            // 
            // fechdoc
            // 
            this.fechdoc.Caption = "Fecha";
            this.fechdoc.FieldName = "fechdoc";
            this.fechdoc.Name = "fechdoc";
            this.fechdoc.OptionsColumn.AllowEdit = false;
            this.fechdoc.Visible = true;
            this.fechdoc.VisibleIndex = 1;
            // 
            // cantidad
            // 
            this.cantidad.Caption = "Cantidad";
            this.cantidad.FieldName = "cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.OptionsColumn.AllowEdit = false;
            this.cantidad.Visible = true;
            this.cantidad.VisibleIndex = 2;
            this.cantidad.Width = 83;
            // 
            // importe
            // 
            this.importe.Caption = "Importe";
            this.importe.FieldName = "importe";
            this.importe.Name = "importe";
            this.importe.OptionsColumn.AllowEdit = false;
            this.importe.Visible = true;
            this.importe.VisibleIndex = 3;
            this.importe.Width = 69;
            // 
            // efectivo
            // 
            this.efectivo.Caption = "Efectivo";
            this.efectivo.FieldName = "efectivo";
            this.efectivo.Name = "efectivo";
            this.efectivo.OptionsColumn.AllowEdit = false;
            this.efectivo.Visible = true;
            this.efectivo.VisibleIndex = 5;
            this.efectivo.Width = 126;
            // 
            // tarjeta
            // 
            this.tarjeta.Caption = "Tarjeta";
            this.tarjeta.FieldName = "tarjeta";
            this.tarjeta.Name = "tarjeta";
            this.tarjeta.OptionsColumn.AllowEdit = false;
            this.tarjeta.Visible = true;
            this.tarjeta.VisibleIndex = 4;
            this.tarjeta.Width = 119;
            // 
            // cmMenuGrid
            // 
            this.cmMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarAExcelToolStripMenuItem});
            this.cmMenuGrid.Name = "cmMenuGrid";
            this.cmMenuGrid.Size = new System.Drawing.Size(154, 26);
            // 
            // exportarAExcelToolStripMenuItem
            // 
            this.exportarAExcelToolStripMenuItem.Name = "exportarAExcelToolStripMenuItem";
            this.exportarAExcelToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportarAExcelToolStripMenuItem.Text = "Exportar a Excel";
            this.exportarAExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarAExcelToolStripMenuItem_Click);
            // 
            // sfdruta
            // 
            this.sfdruta.Filter = "Archivos Excel | *.xls";
            // 
            // Examinar2
            // 
            this.Examinar2.Location = new System.Drawing.Point(6, 232);
            this.Examinar2.MainView = this.gv_examinar2;
            this.Examinar2.Name = "Examinar2";
            this.Examinar2.Size = new System.Drawing.Size(959, 142);
            this.Examinar2.TabIndex = 75;
            this.Examinar2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_examinar2});
            this.Examinar2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Examinar2_MouseClick);
            // 
            // gv_examinar2
            // 
            this.gv_examinar2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._localname,
            this._fechdoc,
            this.tipodoc,
            this.serdoc,
            this.numdoc1,
            this.numdoc2,
            this._cantidad,
            this._importe,
            this._efectivo,
            this._tarjeta});
            this.gv_examinar2.GridControl = this.Examinar2;
            this.gv_examinar2.Name = "gv_examinar2";
            this.gv_examinar2.OptionsView.ShowGroupPanel = false;
            // 
            // _localname
            // 
            this._localname.Caption = "Tienda";
            this._localname.FieldName = "localname";
            this._localname.Name = "_localname";
            this._localname.OptionsColumn.AllowEdit = false;
            this._localname.Visible = true;
            this._localname.VisibleIndex = 0;
            this._localname.Width = 90;
            // 
            // _fechdoc
            // 
            this._fechdoc.Caption = "Fecha";
            this._fechdoc.FieldName = "fechdoc";
            this._fechdoc.Name = "_fechdoc";
            this._fechdoc.OptionsColumn.AllowEdit = false;
            this._fechdoc.Visible = true;
            this._fechdoc.VisibleIndex = 1;
            // 
            // tipodoc
            // 
            this.tipodoc.Caption = "TipoDoc";
            this.tipodoc.FieldName = "tipodoc";
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.OptionsColumn.AllowEdit = false;
            this.tipodoc.Visible = true;
            this.tipodoc.VisibleIndex = 2;
            this.tipodoc.Width = 49;
            // 
            // serdoc
            // 
            this.serdoc.Caption = "Serie";
            this.serdoc.FieldName = "serdoc";
            this.serdoc.Name = "serdoc";
            this.serdoc.OptionsColumn.AllowEdit = false;
            this.serdoc.Visible = true;
            this.serdoc.VisibleIndex = 3;
            // 
            // numdoc1
            // 
            this.numdoc1.Caption = "Del Numero";
            this.numdoc1.FieldName = "numdoc1";
            this.numdoc1.Name = "numdoc1";
            this.numdoc1.OptionsColumn.AllowEdit = false;
            this.numdoc1.Visible = true;
            this.numdoc1.VisibleIndex = 4;
            // 
            // numdoc2
            // 
            this.numdoc2.Caption = "Al Numero";
            this.numdoc2.FieldName = "numdoc2";
            this.numdoc2.Name = "numdoc2";
            this.numdoc2.OptionsColumn.AllowEdit = false;
            this.numdoc2.Visible = true;
            this.numdoc2.VisibleIndex = 5;
            // 
            // _cantidad
            // 
            this._cantidad.Caption = "Cantidad";
            this._cantidad.FieldName = "cantidad";
            this._cantidad.Name = "_cantidad";
            this._cantidad.OptionsColumn.AllowEdit = false;
            this._cantidad.Visible = true;
            this._cantidad.VisibleIndex = 6;
            // 
            // _importe
            // 
            this._importe.Caption = "Importe";
            this._importe.FieldName = "importe";
            this._importe.Name = "_importe";
            this._importe.OptionsColumn.AllowEdit = false;
            this._importe.Visible = true;
            this._importe.VisibleIndex = 7;
            // 
            // _efectivo
            // 
            this._efectivo.Caption = "Efectivo";
            this._efectivo.FieldName = "efectivo";
            this._efectivo.Name = "_efectivo";
            this._efectivo.OptionsColumn.AllowEdit = false;
            this._efectivo.Visible = true;
            this._efectivo.VisibleIndex = 8;
            // 
            // _tarjeta
            // 
            this._tarjeta.Caption = "Tarjeta";
            this._tarjeta.FieldName = "tarjeta";
            this._tarjeta.Name = "_tarjeta";
            this._tarjeta.OptionsColumn.AllowEdit = false;
            this._tarjeta.Visible = true;
            this._tarjeta.VisibleIndex = 9;
            // 
            // Examinar3
            // 
            this.Examinar3.ContextMenuStrip = this.cmMenuGrid;
            this.Examinar3.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.Examinar3.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.Examinar3.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.Examinar3.Location = new System.Drawing.Point(5, 390);
            this.Examinar3.MainView = this.bandedGridView1;
            this.Examinar3.Name = "Examinar3";
            this.Examinar3.Size = new System.Drawing.Size(1355, 181);
            this.Examinar3.TabIndex = 76;
            this.Examinar3.UseEmbeddedNavigator = true;
            this.Examinar3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this._localname_,
            this._fechdoc_,
            this._tipodoc,
            this._serdoc,
            this._numdoc,
            this.productname,
            this._cantidad_,
            this._importe_,
            this.comision,
            this.implista,
            this.utilista,
            this._costo,
            this.uticosto,
            this.ctactename,
            this.vendorname});
            this.bandedGridView1.GridControl = this.Examinar3;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BorderColor = System.Drawing.Color.Blue;
            this.gridBand1.AppearanceHeader.Options.UseBorderColor = true;
            this.gridBand1.Caption = "Opciones Avanzadas";
            this.gridBand1.Columns.Add(this._localname_);
            this.gridBand1.Columns.Add(this._fechdoc_);
            this.gridBand1.Columns.Add(this._tipodoc);
            this.gridBand1.Columns.Add(this._serdoc);
            this.gridBand1.Columns.Add(this._numdoc);
            this.gridBand1.Columns.Add(this.productname);
            this.gridBand1.Columns.Add(this._cantidad_);
            this.gridBand1.Columns.Add(this._importe_);
            this.gridBand1.Columns.Add(this.comision);
            this.gridBand1.Columns.Add(this.implista);
            this.gridBand1.Columns.Add(this.utilista);
            this.gridBand1.Columns.Add(this._costo);
            this.gridBand1.Columns.Add(this.uticosto);
            this.gridBand1.Columns.Add(this.ctactename);
            this.gridBand1.Columns.Add(this.vendorname);
            this.gridBand1.Image = global::BapFormulariosNet.Properties.Resources.arrow_out;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 1337;
            // 
            // _localname_
            // 
            this._localname_.Caption = "Tienda";
            this._localname_.FieldName = "localname";
            this._localname_.Name = "_localname_";
            this._localname_.OptionsColumn.AllowEdit = false;
            // 
            // _fechdoc_
            // 
            this._fechdoc_.Caption = "Fecha";
            this._fechdoc_.FieldName = "fechdoc";
            this._fechdoc_.Name = "_fechdoc_";
            this._fechdoc_.OptionsColumn.AllowEdit = false;
            this._fechdoc_.Visible = true;
            this._fechdoc_.Width = 83;
            // 
            // _tipodoc
            // 
            this._tipodoc.Caption = "TipoDoc";
            this._tipodoc.FieldName = "tipodoc";
            this._tipodoc.Name = "_tipodoc";
            this._tipodoc.OptionsColumn.AllowEdit = false;
            this._tipodoc.Visible = true;
            this._tipodoc.Width = 55;
            // 
            // _serdoc
            // 
            this._serdoc.Caption = "Serie";
            this._serdoc.FieldName = "serdoc";
            this._serdoc.Name = "_serdoc";
            this._serdoc.OptionsColumn.AllowEdit = false;
            this._serdoc.Visible = true;
            this._serdoc.Width = 55;
            // 
            // _numdoc
            // 
            this._numdoc.Caption = "Del Numero";
            this._numdoc.FieldName = "numdoc";
            this._numdoc.Name = "_numdoc";
            this._numdoc.OptionsColumn.AllowEdit = false;
            this._numdoc.Visible = true;
            this._numdoc.Width = 83;
            // 
            // productname
            // 
            this.productname.Caption = "Producto";
            this.productname.FieldName = "productname";
            this.productname.Name = "productname";
            this.productname.OptionsColumn.AllowEdit = false;
            this.productname.Visible = true;
            this.productname.Width = 222;
            // 
            // _cantidad_
            // 
            this._cantidad_.Caption = "Cantidad";
            this._cantidad_.FieldName = "cantidad";
            this._cantidad_.Name = "_cantidad_";
            this._cantidad_.OptionsColumn.AllowEdit = false;
            this._cantidad_.Visible = true;
            this._cantidad_.Width = 83;
            // 
            // _importe_
            // 
            this._importe_.Caption = "Importe";
            this._importe_.FieldName = "importe";
            this._importe_.Name = "_importe_";
            this._importe_.OptionsColumn.AllowEdit = false;
            this._importe_.Visible = true;
            this._importe_.Width = 83;
            // 
            // comision
            // 
            this.comision.Caption = "Comision";
            this.comision.FieldName = "comision";
            this.comision.Name = "comision";
            this.comision.OptionsColumn.AllowEdit = false;
            this.comision.Visible = true;
            this.comision.Width = 83;
            // 
            // implista
            // 
            this.implista.Caption = "ImpLista";
            this.implista.FieldName = "implista";
            this.implista.Name = "implista";
            this.implista.OptionsColumn.AllowEdit = false;
            this.implista.Visible = true;
            this.implista.Width = 83;
            // 
            // utilista
            // 
            this.utilista.Caption = "UtiLista";
            this.utilista.FieldName = "utilista";
            this.utilista.Name = "utilista";
            this.utilista.OptionsColumn.AllowEdit = false;
            this.utilista.Visible = true;
            this.utilista.Width = 83;
            // 
            // _costo
            // 
            this._costo.Caption = "Costo";
            this._costo.FieldName = "costo";
            this._costo.Name = "_costo";
            this._costo.OptionsColumn.AllowEdit = false;
            this._costo.Visible = true;
            this._costo.Width = 83;
            // 
            // uticosto
            // 
            this.uticosto.Caption = "UtiCosto";
            this.uticosto.FieldName = "uticosto";
            this.uticosto.Name = "uticosto";
            this.uticosto.OptionsColumn.AllowEdit = false;
            this.uticosto.Visible = true;
            this.uticosto.Width = 83;
            // 
            // ctactename
            // 
            this.ctactename.Caption = "Cliente";
            this.ctactename.FieldName = "ctactename";
            this.ctactename.Name = "ctactename";
            this.ctactename.OptionsColumn.AllowEdit = false;
            this.ctactename.Visible = true;
            this.ctactename.Width = 167;
            // 
            // vendorname
            // 
            this.vendorname.Caption = "Vendedor";
            this.vendorname.FieldName = "vendorname";
            this.vendorname.Name = "vendorname";
            this.vendorname.Visible = true;
            this.vendorname.Width = 91;
            // 
            // Frm_reporte_ventas
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 578);
            this.Controls.Add(this.cbo_local);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Examinar3);
            this.Controls.Add(this.Examinar2);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.fechdocfin);
            this.Controls.Add(this.fechdocini);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_busqueda);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbo_modulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Name = "Frm_reporte_ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Ventas";
            this.Load += new System.EventHandler(this.Frm_reporte_ventas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_examinar)).EndInit();
            this.cmMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Examinar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_examinar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_modulo;
        private System.Windows.Forms.ComboBox cbo_local;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Button btn_busqueda;
        internal System.Windows.Forms.DateTimePicker fechdocfin;
        internal System.Windows.Forms.DateTimePicker fechdocini;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.GridControl Examinar;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_examinar;
        private System.Windows.Forms.ContextMenuStrip cmMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem exportarAExcelToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdruta;
        private DevExpress.XtraGrid.Columns.GridColumn tarjeta;
        private DevExpress.XtraGrid.Columns.GridColumn efectivo;
        private DevExpress.XtraGrid.Columns.GridColumn importe;
        private DevExpress.XtraGrid.Columns.GridColumn cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn fechdoc;
        private DevExpress.XtraGrid.Columns.GridColumn localname;
        private DevExpress.XtraGrid.GridControl Examinar2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_examinar2;
        private DevExpress.XtraGrid.Columns.GridColumn _cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn numdoc2;
        private DevExpress.XtraGrid.Columns.GridColumn numdoc1;
        private DevExpress.XtraGrid.Columns.GridColumn serdoc;
        private DevExpress.XtraGrid.Columns.GridColumn tipodoc;
        private DevExpress.XtraGrid.Columns.GridColumn _fechdoc;
        private DevExpress.XtraGrid.Columns.GridColumn _localname;
        private DevExpress.XtraGrid.Columns.GridColumn _tarjeta;
        private DevExpress.XtraGrid.Columns.GridColumn _efectivo;
        private DevExpress.XtraGrid.Columns.GridColumn _importe;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private DevExpress.XtraGrid.GridControl Examinar3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private DevExpress.XtraGrid.Columns.GridColumn local;
        private DevExpress.XtraGrid.Columns.GridColumn moduloid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _localname_;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _fechdoc_;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _tipodoc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _serdoc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _numdoc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn productname;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _cantidad_;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _importe_;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn comision;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn implista;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn utilista;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn _costo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn uticosto;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ctactename;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn vendorname;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}