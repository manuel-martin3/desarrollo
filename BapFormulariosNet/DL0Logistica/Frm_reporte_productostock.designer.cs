namespace BapFormulariosNet.DL0Logistica
{
    partial class Frm_reporte_productostock
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_productostock));
            this.fechadoc = new System.Windows.Forms.DateTimePicker();
            this.cbomodulo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.procedenciaid = new System.Windows.Forms.RadioListBox();
            this.productidold = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkTodos = new System.Windows.Forms.CheckBox();
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
            this.label16 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.CmMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdliquidacion = new System.Windows.Forms.SaveFileDialog();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.localdes = new System.Windows.Forms.ComboBox();
            this.Examinar3 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.glineaname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gproductid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gproductidold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gproductname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gstock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gunmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gtitulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gmarcaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gmarcaname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcoleccionid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcoleccionname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ggeneroid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ggeneroname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcostopromed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gimporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcompo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ggruponame = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gprocedenciaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fepialmac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.feuialmac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.feusprod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcostoultimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox3.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.CmMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fechadoc
            // 
            this.fechadoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechadoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechadoc.Location = new System.Drawing.Point(1016, 5);
            this.fechadoc.Name = "fechadoc";
            this.fechadoc.Size = new System.Drawing.Size(80, 20);
            this.fechadoc.TabIndex = 4;
            this.fechadoc.Value = new System.DateTime(2012, 12, 19, 0, 0, 0, 0);
            // 
            // cbomodulo
            // 
            this.cbomodulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomodulo.DropDownWidth = 250;
            this.cbomodulo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbomodulo.Location = new System.Drawing.Point(196, 8);
            this.cbomodulo.Name = "cbomodulo";
            this.cbomodulo.Size = new System.Drawing.Size(231, 21);
            this.cbomodulo.TabIndex = 92;
            this.cbomodulo.SelectedIndexChanged += new System.EventHandler(this.cbomodulo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(129, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Almacen:";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_busqueda.ForeColor = System.Drawing.Color.Black;
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(638, 84);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(95, 32);
            this.btn_busqueda.TabIndex = 70;
            this.btn_busqueda.Text = "&Consultar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.procedenciaid);
            this.groupBox3.Location = new System.Drawing.Point(838, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 75);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Procedencia";
            // 
            // procedenciaid
            // 
            this.procedenciaid.BackColor = System.Drawing.Color.Transparent;
            this.procedenciaid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.procedenciaid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.procedenciaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procedenciaid.FormattingEnabled = true;
            this.procedenciaid.ItemHeight = 16;
            this.procedenciaid.Location = new System.Drawing.Point(11, 17);
            this.procedenciaid.Name = "procedenciaid";
            this.procedenciaid.Size = new System.Drawing.Size(108, 48);
            this.procedenciaid.TabIndex = 62;
            // 
            // productidold
            // 
            this.productidold.Location = new System.Drawing.Point(747, 37);
            this.productidold.MaxLength = 4;
            this.productidold.Name = "productidold";
            this.productidold.Size = new System.Drawing.Size(60, 21);
            this.productidold.TabIndex = 33;
            this.productidold.Text = "ventas al exterior";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(632, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Codigo Asociado:";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.ForeColor = System.Drawing.Color.Yellow;
            this.chkTodos.Location = new System.Drawing.Point(638, 63);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(168, 17);
            this.chkTodos.TabIndex = 32;
            this.chkTodos.Text = "Incluir los que no tienen stock";
            this.chkTodos.UseVisualStyleBackColor = true;
            // 
            // colorname
            // 
            this.colorname.Location = new System.Drawing.Point(797, 12);
            this.colorname.Name = "colorname";
            this.colorname.Size = new System.Drawing.Size(172, 21);
            this.colorname.TabIndex = 21;
            this.colorname.Text = "ventas al exterior";
            // 
            // colorid
            // 
            this.colorid.Location = new System.Drawing.Point(748, 12);
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
            this.label4.Location = new System.Drawing.Point(693, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Color:";
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(282, 98);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(345, 21);
            this.productname.TabIndex = 17;
            this.productname.Text = "ventas al exterior";
            // 
            // productid
            // 
            this.productid.Location = new System.Drawing.Point(198, 98);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(83, 21);
            this.productid.TabIndex = 16;
            this.productid.Text = "ventas al exterior";
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // gruponame
            // 
            this.gruponame.Location = new System.Drawing.Point(246, 53);
            this.gruponame.Name = "gruponame";
            this.gruponame.Size = new System.Drawing.Size(381, 21);
            this.gruponame.TabIndex = 13;
            this.gruponame.Text = "ventas al exterior";
            // 
            // grupoid
            // 
            this.grupoid.Location = new System.Drawing.Point(197, 53);
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
            this.label6.Location = new System.Drawing.Point(120, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Proveedor:";
            // 
            // lineaname
            // 
            this.lineaname.Location = new System.Drawing.Point(246, 31);
            this.lineaname.Name = "lineaname";
            this.lineaname.Size = new System.Drawing.Size(381, 21);
            this.lineaname.TabIndex = 11;
            this.lineaname.Text = "ventas al exterior";
            // 
            // lineaid
            // 
            this.lineaid.Location = new System.Drawing.Point(197, 31);
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
            this.label3.Location = new System.Drawing.Point(145, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Línea:";
            // 
            // subgrupoid
            // 
            this.subgrupoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subgrupoid.Location = new System.Drawing.Point(198, 75);
            this.subgrupoid.MaxLength = 3;
            this.subgrupoid.Name = "subgrupoid";
            this.subgrupoid.Size = new System.Drawing.Size(47, 20);
            this.subgrupoid.TabIndex = 14;
            this.subgrupoid.Text = "ventas al exterior";
            this.subgrupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subgrupoid_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Producto:";
            // 
            // subgruponame
            // 
            this.subgruponame.Location = new System.Drawing.Point(246, 75);
            this.subgruponame.Name = "subgruponame";
            this.subgruponame.Size = new System.Drawing.Size(381, 21);
            this.subgruponame.TabIndex = 15;
            this.subgruponame.Text = "ventas al exterior";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Articulo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(969, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Fecha";
            // 
            // Botonera
            // 
            this.Botonera.CanOverflow = false;
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_cancelar,
            this.toolStripSeparator1,
            this.btn_imprimir,
            this.btn_excel,
            this.toolStripSeparator2,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(1112, 29);
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
            // btn_excel
            // 
            this.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_excel.Image = global::BapFormulariosNet.Properties.Resources.btn_excel20;
            this.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(26, 26);
            this.btn_excel.Text = "toolStripButton1";
            this.btn_excel.ToolTipText = "Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
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
            // CmMenuGrid
            // 
            this.CmMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarExcelToolStripMenuItem});
            this.CmMenuGrid.Name = "CmMenuGrid";
            this.CmMenuGrid.Size = new System.Drawing.Size(145, 26);
            // 
            // exportarExcelToolStripMenuItem
            // 
            this.exportarExcelToolStripMenuItem.Name = "exportarExcelToolStripMenuItem";
            this.exportarExcelToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exportarExcelToolStripMenuItem.Text = "Exportar Excel";
            this.exportarExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarExcelToolStripMenuItem_Click);
            // 
            // sfdliquidacion
            // 
            this.sfdliquidacion.Filter = "Archivos Excel | *.xls";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.localdes);
            this.panelControl1.Controls.Add(this.btn_busqueda);
            this.panelControl1.Controls.Add(this.cbomodulo);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.label9);
            this.panelControl1.Controls.Add(this.lineaname);
            this.panelControl1.Controls.Add(this.grupoid);
            this.panelControl1.Controls.Add(this.lineaid);
            this.panelControl1.Controls.Add(this.gruponame);
            this.panelControl1.Controls.Add(this.groupBox3);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.productid);
            this.panelControl1.Controls.Add(this.productidold);
            this.panelControl1.Controls.Add(this.subgrupoid);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.productname);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.chkTodos);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.subgruponame);
            this.panelControl1.Controls.Add(this.colorname);
            this.panelControl1.Controls.Add(this.colorid);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Location = new System.Drawing.Point(2, 32);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1109, 124);
            this.panelControl1.TabIndex = 94;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(432, 13);
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
            this.localdes.Location = new System.Drawing.Point(483, 8);
            this.localdes.Name = "localdes";
            this.localdes.Size = new System.Drawing.Size(144, 21);
            this.localdes.TabIndex = 94;
            // 
            // Examinar3
            // 
            this.Examinar3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Examinar3.ContextMenuStrip = this.CmMenuGrid;
            this.Examinar3.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.Examinar3.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.Examinar3.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.Examinar3.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.Examinar3.Location = new System.Drawing.Point(2, 158);
            this.Examinar3.MainView = this.gridView1;
            this.Examinar3.Name = "Examinar3";
            this.Examinar3.Size = new System.Drawing.Size(1108, 347);
            this.Examinar3.TabIndex = 95;
            this.Examinar3.UseEmbeddedNavigator = true;
            this.Examinar3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(223)))), ((int)(((byte)(217)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(138)))), ((int)(((byte)(131)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(66)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(144)))), ((int)(((byte)(136)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Maroon;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(252)))), ((int)(((byte)(244)))));
            this.gridView1.Appearance.Preview.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.glineaname,
            this.gproductid,
            this.gproductidold,
            this.gproductname,
            this.gcolorname,
            this.gstock,
            this.gunmed,
            this.gtitulo,
            this.gmarcaid,
            this.gmarcaname,
            this.gcoleccionid,
            this.gcoleccionname,
            this.ggeneroid,
            this.ggeneroname,
            this.gcostopromed,
            this.gcostoultimo,
            this.gimporte,
            this.gcompo,
            this.ggruponame,
            this.gprocedenciaid,
            this.fepialmac,
            this.feuialmac,
            this.feusprod});
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.Examinar3;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office2003;
            this.gridView1.PaintStyleName = "Web";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.glineaname, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ggruponame, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // glineaname
            // 
            this.glineaname.Caption = "Linea";
            this.glineaname.FieldName = "lineaname";
            this.glineaname.Name = "glineaname";
            this.glineaname.OptionsColumn.AllowEdit = false;
            this.glineaname.Visible = true;
            this.glineaname.VisibleIndex = 0;
            this.glineaname.Width = 70;
            // 
            // gproductid
            // 
            this.gproductid.Caption = "Código";
            this.gproductid.FieldName = "productid";
            this.gproductid.Name = "gproductid";
            this.gproductid.OptionsColumn.AllowEdit = false;
            this.gproductid.Visible = true;
            this.gproductid.VisibleIndex = 0;
            this.gproductid.Width = 70;
            // 
            // gproductidold
            // 
            this.gproductidold.Caption = "CódAnt";
            this.gproductidold.FieldName = "productidold";
            this.gproductidold.Name = "gproductidold";
            this.gproductidold.OptionsColumn.AllowEdit = false;
            this.gproductidold.Visible = true;
            this.gproductidold.VisibleIndex = 12;
            this.gproductidold.Width = 31;
            // 
            // gproductname
            // 
            this.gproductname.Caption = "Producto";
            this.gproductname.FieldName = "productname";
            this.gproductname.Name = "gproductname";
            this.gproductname.OptionsColumn.AllowEdit = false;
            this.gproductname.Visible = true;
            this.gproductname.VisibleIndex = 1;
            this.gproductname.Width = 207;
            // 
            // gcolorname
            // 
            this.gcolorname.Caption = "Color";
            this.gcolorname.FieldName = "colorname";
            this.gcolorname.Name = "gcolorname";
            this.gcolorname.OptionsColumn.AllowEdit = false;
            this.gcolorname.Visible = true;
            this.gcolorname.VisibleIndex = 2;
            this.gcolorname.Width = 52;
            // 
            // gstock
            // 
            this.gstock.Caption = "Stock";
            this.gstock.DisplayFormat.FormatString = "#.00;[#.00];.00";
            this.gstock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gstock.FieldName = "stock";
            this.gstock.Name = "gstock";
            this.gstock.OptionsColumn.AllowEdit = false;
            this.gstock.Visible = true;
            this.gstock.VisibleIndex = 3;
            this.gstock.Width = 55;
            // 
            // gunmed
            // 
            this.gunmed.Caption = "UnMed";
            this.gunmed.FieldName = "unmed";
            this.gunmed.Name = "gunmed";
            this.gunmed.OptionsColumn.AllowEdit = false;
            this.gunmed.Visible = true;
            this.gunmed.VisibleIndex = 4;
            this.gunmed.Width = 37;
            // 
            // gtitulo
            // 
            this.gtitulo.Caption = "Medida";
            this.gtitulo.FieldName = "titulo";
            this.gtitulo.Name = "gtitulo";
            this.gtitulo.OptionsColumn.AllowEdit = false;
            this.gtitulo.Visible = true;
            this.gtitulo.VisibleIndex = 7;
            // 
            // gmarcaid
            // 
            this.gmarcaid.Caption = "Cod.Marca";
            this.gmarcaid.FieldName = "marcaid";
            this.gmarcaid.Name = "gmarcaid";
            this.gmarcaid.OptionsColumn.AllowEdit = false;
            // 
            // gmarcaname
            // 
            this.gmarcaname.Caption = "Marca";
            this.gmarcaname.FieldName = "marcaname";
            this.gmarcaname.Name = "gmarcaname";
            this.gmarcaname.OptionsColumn.AllowEdit = false;
            this.gmarcaname.Visible = true;
            this.gmarcaname.VisibleIndex = 8;
            // 
            // gcoleccionid
            // 
            this.gcoleccionid.Caption = "Cod.Coleccion";
            this.gcoleccionid.FieldName = "colecconid";
            this.gcoleccionid.Name = "gcoleccionid";
            this.gcoleccionid.OptionsColumn.AllowEdit = false;
            // 
            // gcoleccionname
            // 
            this.gcoleccionname.Caption = "Coleccion";
            this.gcoleccionname.FieldName = "coleccionname";
            this.gcoleccionname.Name = "gcoleccionname";
            this.gcoleccionname.OptionsColumn.AllowEdit = false;
            this.gcoleccionname.Visible = true;
            this.gcoleccionname.VisibleIndex = 9;
            // 
            // ggeneroid
            // 
            this.ggeneroid.Caption = "Cod.Genero";
            this.ggeneroid.FieldName = "generoid";
            this.ggeneroid.Name = "ggeneroid";
            this.ggeneroid.OptionsColumn.AllowEdit = false;
            // 
            // ggeneroname
            // 
            this.ggeneroname.Caption = "Genero";
            this.ggeneroname.FieldName = "generoname";
            this.ggeneroname.Name = "ggeneroname";
            this.ggeneroname.OptionsColumn.AllowEdit = false;
            this.ggeneroname.Visible = true;
            this.ggeneroname.VisibleIndex = 10;
            // 
            // gcostopromed
            // 
            this.gcostopromed.Caption = "CostProm";
            this.gcostopromed.DisplayFormat.FormatString = "#.00;[#.00];.00";
            this.gcostopromed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcostopromed.FieldName = "costopromed";
            this.gcostopromed.Name = "gcostopromed";
            this.gcostopromed.OptionsColumn.AllowEdit = false;
            this.gcostopromed.Width = 47;
            // 
            // gimporte
            // 
            this.gimporte.Caption = "Importe";
            this.gimporte.DisplayFormat.FormatString = "#.00;[#.00];.00";
            this.gimporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gimporte.FieldName = "gimporte";
            this.gimporte.Name = "gimporte";
            this.gimporte.OptionsColumn.AllowEdit = false;
            this.gimporte.UnboundExpression = "[stock]*[costopromed]";
            this.gimporte.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gimporte.Visible = true;
            this.gimporte.VisibleIndex = 6;
            this.gimporte.Width = 59;
            // 
            // gcompo
            // 
            this.gcompo.Caption = "Composición";
            this.gcompo.FieldName = "compo";
            this.gcompo.Name = "gcompo";
            this.gcompo.OptionsColumn.AllowEdit = false;
            this.gcompo.Visible = true;
            this.gcompo.VisibleIndex = 11;
            this.gcompo.Width = 88;
            // 
            // ggruponame
            // 
            this.ggruponame.Caption = "Grupo";
            this.ggruponame.FieldName = "gruponame";
            this.ggruponame.Name = "ggruponame";
            this.ggruponame.OptionsColumn.AllowEdit = false;
            this.ggruponame.Visible = true;
            this.ggruponame.VisibleIndex = 9;
            this.ggruponame.Width = 34;
            // 
            // gprocedenciaid
            // 
            this.gprocedenciaid.Caption = "Procedencia";
            this.gprocedenciaid.FieldName = "procedenciaid";
            this.gprocedenciaid.Name = "gprocedenciaid";
            this.gprocedenciaid.OptionsColumn.AllowEdit = false;
            this.gprocedenciaid.Width = 20;
            // 
            // fepialmac
            // 
            this.fepialmac.Caption = "Primer_Ing_Almac";
            this.fepialmac.DisplayFormat.FormatString = "d";
            this.fepialmac.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fepialmac.FieldName = "fepialmac";
            this.fepialmac.Name = "fepialmac";
            this.fepialmac.OptionsColumn.AllowEdit = false;
            this.fepialmac.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.fepialmac.Visible = true;
            this.fepialmac.VisibleIndex = 13;
            // 
            // feuialmac
            // 
            this.feuialmac.Caption = "Ult_Ing_Almac";
            this.feuialmac.DisplayFormat.FormatString = "d";
            this.feuialmac.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.feuialmac.FieldName = "feuialmac";
            this.feuialmac.Name = "feuialmac";
            this.feuialmac.OptionsColumn.AllowEdit = false;
            this.feuialmac.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.feuialmac.Visible = true;
            this.feuialmac.VisibleIndex = 14;
            // 
            // feusprod
            // 
            this.feusprod.Caption = "Ult_Sal_Prod";
            this.feusprod.DisplayFormat.FormatString = "d";
            this.feusprod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.feusprod.FieldName = "feusprod";
            this.feusprod.Name = "feusprod";
            this.feusprod.OptionsColumn.AllowEdit = false;
            this.feusprod.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.feusprod.Visible = true;
            this.feusprod.VisibleIndex = 15;
            // 
            // gcostoultimo
            // 
            this.gcostoultimo.Caption = "CostUltm";
            this.gcostoultimo.DisplayFormat.FormatString = "#.00;[#.00];.00";
            this.gcostoultimo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcostoultimo.FieldName = "costoultimo";
            this.gcostoultimo.Name = "gcostoultimo";
            this.gcostoultimo.OptionsColumn.AllowEdit = false;
            this.gcostoultimo.Visible = true;
            this.gcostoultimo.VisibleIndex = 5;
            // 
            // Frm_reporte_productostock
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1112, 505);
            this.Controls.Add(this.Examinar3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.fechadoc);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_reporte_productostock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Consolidado de Productos";
            this.Load += new System.EventHandler(this.Frm_reporte_stockrollo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_reporte_stockrollo_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.CmMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.DateTimePicker fechadoc;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox subgruponame;
        internal System.Windows.Forms.TextBox subgrupoid;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox lineaid;
        internal System.Windows.Forms.TextBox lineaname;
        internal System.Windows.Forms.TextBox gruponame;
        internal System.Windows.Forms.TextBox grupoid;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox colorname;
        internal System.Windows.Forms.TextBox colorid;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_excel;
        internal System.Windows.Forms.TextBox productname;
        internal System.Windows.Forms.TextBox productid;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkTodos;
        internal System.Windows.Forms.TextBox productidold;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioListBox procedenciaid;
        private System.Windows.Forms.Button btn_busqueda;
        private System.Windows.Forms.ContextMenuStrip CmMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem exportarExcelToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdliquidacion;
        internal System.Windows.Forms.ComboBox cbomodulo;
        internal System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl Examinar3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn glineaname;
        private DevExpress.XtraGrid.Columns.GridColumn gproductid;
        private DevExpress.XtraGrid.Columns.GridColumn gproductidold;
        private DevExpress.XtraGrid.Columns.GridColumn gproductname;
        private DevExpress.XtraGrid.Columns.GridColumn gcolorname;
        private DevExpress.XtraGrid.Columns.GridColumn gstock;
        private DevExpress.XtraGrid.Columns.GridColumn gunmed;
        private DevExpress.XtraGrid.Columns.GridColumn gtitulo;
        private DevExpress.XtraGrid.Columns.GridColumn gmarcaid;
        private DevExpress.XtraGrid.Columns.GridColumn gmarcaname;
        private DevExpress.XtraGrid.Columns.GridColumn gcoleccionid;
        private DevExpress.XtraGrid.Columns.GridColumn gcoleccionname;
        private DevExpress.XtraGrid.Columns.GridColumn ggeneroid;
        private DevExpress.XtraGrid.Columns.GridColumn ggeneroname;
        private DevExpress.XtraGrid.Columns.GridColumn gcostopromed;
        private DevExpress.XtraGrid.Columns.GridColumn gimporte;
        private DevExpress.XtraGrid.Columns.GridColumn gcompo;
        private DevExpress.XtraGrid.Columns.GridColumn ggruponame;
        private DevExpress.XtraGrid.Columns.GridColumn gprocedenciaid;
        private DevExpress.XtraGrid.Columns.GridColumn fepialmac;
        private DevExpress.XtraGrid.Columns.GridColumn feuialmac;
        private DevExpress.XtraGrid.Columns.GridColumn feusprod;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        internal System.Windows.Forms.ComboBox localdes;
        private DevExpress.XtraGrid.Columns.GridColumn gcostoultimo;

    }
}