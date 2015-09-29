namespace BapFormulariosNet.MERCADERIA
{
    partial class Frm_reporte_productostock_old
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_productostock_old));
            this.fechadoc = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
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
            this.Examinar3 = new DevExpress.XtraGrid.GridControl();
            this.CmMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.glineaname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gproductid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gproductidold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gproductname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gstock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gunmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcostopromed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gimporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcompo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ggruponame = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gprocedenciaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sfdconsolidado = new System.Windows.Forms.SaveFileDialog();
            this.btn_busqueda = new DevExpress.XtraEditors.SimpleButton();
            this.pnl_01 = new DevExpress.XtraEditors.PanelControl();
            this.pnl_03 = new DevExpress.XtraEditors.PanelControl();
            this.pnl_02 = new DevExpress.XtraEditors.PanelControl();
            this.Botonera.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar3)).BeginInit();
            this.CmMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_01)).BeginInit();
            this.pnl_01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_03)).BeginInit();
            this.pnl_03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_02)).BeginInit();
            this.pnl_02.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechadoc
            // 
            this.fechadoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechadoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechadoc.Location = new System.Drawing.Point(803, 9);
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
            this.label16.Location = new System.Drawing.Point(751, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Fecha:";
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
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(895, 29);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.procedenciaid);
            this.groupBox3.Location = new System.Drawing.Point(222, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 75);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Procedencia";
            this.groupBox3.Visible = false;
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
            this.productidold.Location = new System.Drawing.Point(124, 31);
            this.productidold.MaxLength = 4;
            this.productidold.Name = "productidold";
            this.productidold.Size = new System.Drawing.Size(60, 21);
            this.productidold.TabIndex = 33;
            this.productidold.Text = "ventas al exterior";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Codigo Asociado:";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.BackColor = System.Drawing.Color.Transparent;
            this.chkTodos.Location = new System.Drawing.Point(12, 58);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(168, 17);
            this.chkTodos.TabIndex = 32;
            this.chkTodos.Text = "Incluir los que no tienen stock";
            this.chkTodos.UseVisualStyleBackColor = false;
            // 
            // colorname
            // 
            this.colorname.Location = new System.Drawing.Point(174, 6);
            this.colorname.Name = "colorname";
            this.colorname.Size = new System.Drawing.Size(172, 21);
            this.colorname.TabIndex = 21;
            this.colorname.Text = "ventas al exterior";
            // 
            // colorid
            // 
            this.colorid.Location = new System.Drawing.Point(125, 6);
            this.colorid.Name = "colorid";
            this.colorid.Size = new System.Drawing.Size(48, 21);
            this.colorid.TabIndex = 18;
            this.colorid.Text = "ventas al exterior";
            this.colorid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.colorid_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Color:";
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(161, 7);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(319, 21);
            this.productname.TabIndex = 17;
            this.productname.Text = "ventas al exterior";
            // 
            // productid
            // 
            this.productid.Location = new System.Drawing.Point(77, 7);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(83, 21);
            this.productid.TabIndex = 16;
            this.productid.Text = "ventas al exterior";
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // gruponame
            // 
            this.gruponame.Location = new System.Drawing.Point(125, 29);
            this.gruponame.Name = "gruponame";
            this.gruponame.Size = new System.Drawing.Size(355, 21);
            this.gruponame.TabIndex = 13;
            this.gruponame.Text = "ventas al exterior";
            // 
            // grupoid
            // 
            this.grupoid.Location = new System.Drawing.Point(76, 29);
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
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Marca:";
            // 
            // lineaname
            // 
            this.lineaname.Location = new System.Drawing.Point(125, 7);
            this.lineaname.Name = "lineaname";
            this.lineaname.Size = new System.Drawing.Size(355, 21);
            this.lineaname.TabIndex = 11;
            this.lineaname.Text = "ventas al exterior";
            // 
            // lineaid
            // 
            this.lineaid.Location = new System.Drawing.Point(76, 7);
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
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Línea:";
            // 
            // subgrupoid
            // 
            this.subgrupoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subgrupoid.Location = new System.Drawing.Point(76, 51);
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
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Producto:";
            // 
            // subgruponame
            // 
            this.subgruponame.Location = new System.Drawing.Point(125, 51);
            this.subgruponame.Name = "subgruponame";
            this.subgruponame.Size = new System.Drawing.Size(355, 21);
            this.subgruponame.TabIndex = 15;
            this.subgruponame.Text = "ventas al exterior";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Modelo:";
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
            this.Examinar3.Location = new System.Drawing.Point(3, 148);
            this.Examinar3.MainView = this.gridView1;
            this.Examinar3.Name = "Examinar3";
            this.Examinar3.Size = new System.Drawing.Size(888, 375);
            this.Examinar3.TabIndex = 78;
            this.Examinar3.UseEmbeddedNavigator = true;
            this.Examinar3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // CmMenuGrid
            // 
            this.CmMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarExcelToolStripMenuItem});
            this.CmMenuGrid.Name = "CmMenuGrid";
            this.CmMenuGrid.Size = new System.Drawing.Size(147, 26);
            // 
            // exportarExcelToolStripMenuItem
            // 
            this.exportarExcelToolStripMenuItem.Name = "exportarExcelToolStripMenuItem";
            this.exportarExcelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportarExcelToolStripMenuItem.Text = "Exportar Excel";
            this.exportarExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarExcelToolStripMenuItem_Click);
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
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
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
            this.gridView1.Appearance.GroupRow.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Maroon;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
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
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
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
            this.gcostopromed,
            this.gimporte,
            this.gcompo,
            this.ggruponame,
            this.gprocedenciaid});
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.Examinar3;
            this.gridView1.GroupCount = 2;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gimporte", this.gimporte, "{0:n2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "stock", this.gstock, "{0:n2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
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
            this.gproductid.Width = 93;
            // 
            // gproductidold
            // 
            this.gproductidold.Caption = "CódAnt";
            this.gproductidold.FieldName = "productidold";
            this.gproductidold.Name = "gproductidold";
            this.gproductidold.OptionsColumn.AllowEdit = false;
            this.gproductidold.Visible = true;
            this.gproductidold.VisibleIndex = 8;
            this.gproductidold.Width = 64;
            // 
            // gproductname
            // 
            this.gproductname.Caption = "Producto";
            this.gproductname.FieldName = "productname";
            this.gproductname.Name = "gproductname";
            this.gproductname.OptionsColumn.AllowEdit = false;
            this.gproductname.Visible = true;
            this.gproductname.VisibleIndex = 1;
            this.gproductname.Width = 269;
            // 
            // gcolorname
            // 
            this.gcolorname.Caption = "Color";
            this.gcolorname.FieldName = "colorname";
            this.gcolorname.Name = "gcolorname";
            this.gcolorname.OptionsColumn.AllowEdit = false;
            this.gcolorname.Visible = true;
            this.gcolorname.VisibleIndex = 2;
            this.gcolorname.Width = 67;
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
            this.gstock.Width = 62;
            // 
            // gunmed
            // 
            this.gunmed.Caption = "UnMed";
            this.gunmed.FieldName = "unmed";
            this.gunmed.Name = "gunmed";
            this.gunmed.OptionsColumn.AllowEdit = false;
            this.gunmed.Visible = true;
            this.gunmed.VisibleIndex = 4;
            this.gunmed.Width = 63;
            // 
            // gcostopromed
            // 
            this.gcostopromed.Caption = "CostProm";
            this.gcostopromed.DisplayFormat.FormatString = "#.00;[#.00];.00";
            this.gcostopromed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcostopromed.FieldName = "costopromed";
            this.gcostopromed.Name = "gcostopromed";
            this.gcostopromed.OptionsColumn.AllowEdit = false;
            this.gcostopromed.Visible = true;
            this.gcostopromed.VisibleIndex = 5;
            this.gcostopromed.Width = 79;
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
            this.gimporte.Width = 71;
            // 
            // gcompo
            // 
            this.gcompo.Caption = "Composición";
            this.gcompo.FieldName = "compo";
            this.gcompo.Name = "gcompo";
            this.gcompo.OptionsColumn.AllowEdit = false;
            this.gcompo.Visible = true;
            this.gcompo.VisibleIndex = 7;
            this.gcompo.Width = 97;
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
            // sfdconsolidado
            // 
            this.sfdconsolidado.Filter = "Archivos Excel | *.xls";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Image = ((System.Drawing.Image)(resources.GetObject("btn_busqueda.Image")));
            this.btn_busqueda.Location = new System.Drawing.Point(11, 79);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(95, 30);
            this.btn_busqueda.TabIndex = 83;
            this.btn_busqueda.Text = "&Consultar";
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // pnl_01
            // 
            this.pnl_01.Appearance.BackColor = System.Drawing.Color.Teal;
            this.pnl_01.Appearance.ForeColor = System.Drawing.Color.White;
            this.pnl_01.Appearance.Options.UseBackColor = true;
            this.pnl_01.Appearance.Options.UseForeColor = true;
            this.pnl_01.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnl_01.Controls.Add(this.subgruponame);
            this.pnl_01.Controls.Add(this.lineaid);
            this.pnl_01.Controls.Add(this.lineaname);
            this.pnl_01.Controls.Add(this.label3);
            this.pnl_01.Controls.Add(this.label6);
            this.pnl_01.Controls.Add(this.subgrupoid);
            this.pnl_01.Controls.Add(this.grupoid);
            this.pnl_01.Controls.Add(this.gruponame);
            this.pnl_01.Controls.Add(this.label2);
            this.pnl_01.Location = new System.Drawing.Point(4, 32);
            this.pnl_01.Name = "pnl_01";
            this.pnl_01.Size = new System.Drawing.Size(487, 78);
            this.pnl_01.TabIndex = 84;
            // 
            // pnl_03
            // 
            this.pnl_03.Appearance.BackColor = System.Drawing.Color.Teal;
            this.pnl_03.Appearance.ForeColor = System.Drawing.Color.White;
            this.pnl_03.Appearance.Options.UseBackColor = true;
            this.pnl_03.Appearance.Options.UseForeColor = true;
            this.pnl_03.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnl_03.Controls.Add(this.btn_busqueda);
            this.pnl_03.Controls.Add(this.productidold);
            this.pnl_03.Controls.Add(this.label4);
            this.pnl_03.Controls.Add(this.colorid);
            this.pnl_03.Controls.Add(this.colorname);
            this.pnl_03.Controls.Add(this.label8);
            this.pnl_03.Controls.Add(this.chkTodos);
            this.pnl_03.Controls.Add(this.groupBox3);
            this.pnl_03.Location = new System.Drawing.Point(491, 32);
            this.pnl_03.Name = "pnl_03";
            this.pnl_03.Size = new System.Drawing.Size(389, 113);
            this.pnl_03.TabIndex = 85;
            // 
            // pnl_02
            // 
            this.pnl_02.Appearance.BackColor = System.Drawing.Color.Teal;
            this.pnl_02.Appearance.ForeColor = System.Drawing.Color.White;
            this.pnl_02.Appearance.Options.UseBackColor = true;
            this.pnl_02.Appearance.Options.UseForeColor = true;
            this.pnl_02.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnl_02.Controls.Add(this.productname);
            this.pnl_02.Controls.Add(this.label1);
            this.pnl_02.Controls.Add(this.productid);
            this.pnl_02.Location = new System.Drawing.Point(4, 110);
            this.pnl_02.Name = "pnl_02";
            this.pnl_02.Size = new System.Drawing.Size(487, 35);
            this.pnl_02.TabIndex = 86;
            // 
            // Frm_reporte_productostock_old
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(895, 523);
            this.Controls.Add(this.pnl_02);
            this.Controls.Add(this.pnl_03);
            this.Controls.Add(this.pnl_01);
            this.Controls.Add(this.Examinar3);
            this.Controls.Add(this.fechadoc);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_productostock_old";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Consolidado de Productos";
            this.Activated += new System.EventHandler(this.Frm_reporte_stockrollo_Activated);
            this.Load += new System.EventHandler(this.Frm_reporte_stockrollo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_reporte_stockrollo_KeyDown);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Examinar3)).EndInit();
            this.CmMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_01)).EndInit();
            this.pnl_01.ResumeLayout(false);
            this.pnl_01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_03)).EndInit();
            this.pnl_03.ResumeLayout(false);
            this.pnl_03.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_02)).EndInit();
            this.pnl_02.ResumeLayout(false);
            this.pnl_02.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.DateTimePicker fechadoc;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_excel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioListBox procedenciaid;
        internal System.Windows.Forms.TextBox productidold;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkTodos;
        internal System.Windows.Forms.TextBox colorname;
        internal System.Windows.Forms.TextBox colorid;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox productname;
        internal System.Windows.Forms.TextBox productid;
        internal System.Windows.Forms.TextBox gruponame;
        internal System.Windows.Forms.TextBox grupoid;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox lineaname;
        internal System.Windows.Forms.TextBox lineaid;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox subgrupoid;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox subgruponame;
        internal System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl Examinar3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn glineaname;
        private DevExpress.XtraGrid.Columns.GridColumn gproductid;
        private DevExpress.XtraGrid.Columns.GridColumn gproductidold;
        private DevExpress.XtraGrid.Columns.GridColumn gproductname;
        private DevExpress.XtraGrid.Columns.GridColumn gcolorname;
        private DevExpress.XtraGrid.Columns.GridColumn gstock;
        private DevExpress.XtraGrid.Columns.GridColumn gunmed;
        private DevExpress.XtraGrid.Columns.GridColumn gcostopromed;
        private DevExpress.XtraGrid.Columns.GridColumn gimporte;
        private DevExpress.XtraGrid.Columns.GridColumn gcompo;
        private DevExpress.XtraGrid.Columns.GridColumn ggruponame;
        private DevExpress.XtraGrid.Columns.GridColumn gprocedenciaid;
        private System.Windows.Forms.ContextMenuStrip CmMenuGrid;
        private System.Windows.Forms.SaveFileDialog sfdconsolidado;
        private System.Windows.Forms.ToolStripMenuItem exportarExcelToolStripMenuItem;
        private DevExpress.XtraEditors.PanelControl pnl_01;
        private DevExpress.XtraEditors.PanelControl pnl_03;
        private DevExpress.XtraEditors.PanelControl pnl_02;
        private DevExpress.XtraEditors.SimpleButton btn_busqueda;

    }
}