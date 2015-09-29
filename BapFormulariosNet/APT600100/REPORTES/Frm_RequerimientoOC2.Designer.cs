namespace BapFormulariosNet.APT600100.REPORTES
{
    partial class Frm_RequerimientoOC2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RequerimientoOC2));
            this.totmensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_generar = new System.Windows.Forms.Button();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._productid = new System.Windows.Forms.TextBox();
            this.subgruponame = new System.Windows.Forms.TextBox();
            this._item = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grupoid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lineaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subgrupoid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.griddetalleocompra = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unmedenvase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_detanadir = new System.Windows.Forms.ToolStripButton();
            this.btn_deteliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.txtobs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dgb_requerimiento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.go_item = new DevExpress.XtraGrid.Columns.GridColumn();
            this.go_productid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.go_productname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.go_stock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.go_unmedenvase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.go_cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.griddetalleocompra)).BeginInit();
            this.Botonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_requerimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_del
            // 
            this.btn_del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del.Image = global::BapFormulariosNet.Properties.Resources.go_remove1;
            this.btn_del.Location = new System.Drawing.Point(630, 49);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(21, 21);
            this.btn_del.TabIndex = 93;
            this.totmensaje.SetToolTip(this.btn_del, "Quitar un Producto");
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.Image = global::BapFormulariosNet.Properties.Resources.go_add1;
            this.btn_agregar.Location = new System.Drawing.Point(582, 49);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(21, 21);
            this.btn_agregar.TabIndex = 86;
            this.totmensaje.SetToolTip(this.btn_agregar, "Agregar Productos");
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_generar
            // 
            this.btn_generar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_generar.Image = global::BapFormulariosNet.Properties.Resources.go_update2;
            this.btn_generar.Location = new System.Drawing.Point(504, 48);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(22, 25);
            this.btn_generar.TabIndex = 85;
            this.totmensaje.SetToolTip(this.btn_generar, "Crear Producto");
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Location = new System.Drawing.Point(528, 8);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(57, 13);
            this.lblmensaje.TabIndex = 94;
            this.lblmensaje.Text = "lblmensaje";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(555, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "»»»";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Codigo:";
            // 
            // _productid
            // 
            this._productid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._productid.Location = new System.Drawing.Point(46, 58);
            this._productid.MaxLength = 13;
            this._productid.Name = "_productid";
            this._productid.Size = new System.Drawing.Size(105, 20);
            this._productid.TabIndex = 83;
            this._productid.Text = "ventas al exterior";
            // 
            // subgruponame
            // 
            this.subgruponame.Location = new System.Drawing.Point(155, 58);
            this.subgruponame.Name = "subgruponame";
            this.subgruponame.Size = new System.Drawing.Size(326, 21);
            this.subgruponame.TabIndex = 82;
            this.subgruponame.Text = "ventas al exterior";
            // 
            // _item
            // 
            this._item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._item.Location = new System.Drawing.Point(357, 36);
            this._item.Name = "_item";
            this._item.Size = new System.Drawing.Size(48, 20);
            this._item.TabIndex = 79;
            this._item.Text = "ventas al exterior";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(324, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Item:";
            // 
            // grupoid
            // 
            this.grupoid.Location = new System.Drawing.Point(155, 36);
            this.grupoid.Name = "grupoid";
            this.grupoid.Size = new System.Drawing.Size(48, 21);
            this.grupoid.TabIndex = 77;
            this.grupoid.Text = "ventas al exterior";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(112, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Grupo:";
            // 
            // lineaid
            // 
            this.lineaid.Location = new System.Drawing.Point(46, 36);
            this.lineaid.Name = "lineaid";
            this.lineaid.Size = new System.Drawing.Size(48, 21);
            this.lineaid.TabIndex = 75;
            this.lineaid.Text = "ventas al exterior";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Línea:";
            // 
            // subgrupoid
            // 
            this.subgrupoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subgrupoid.Location = new System.Drawing.Point(268, 36);
            this.subgrupoid.MaxLength = 3;
            this.subgrupoid.Name = "subgrupoid";
            this.subgrupoid.Size = new System.Drawing.Size(47, 20);
            this.subgrupoid.TabIndex = 78;
            this.subgrupoid.Text = "ventas al exterior";
            this.subgrupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subgrupoid_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(208, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "Subgrupo:";
            // 
            // griddetalleocompra
            // 
            this.griddetalleocompra.AllowUserToAddRows = false;
            this.griddetalleocompra.AllowUserToDeleteRows = false;
            this.griddetalleocompra.AllowUserToResizeColumns = false;
            this.griddetalleocompra.AllowUserToResizeRows = false;
            this.griddetalleocompra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.griddetalleocompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.griddetalleocompra.ColumnHeadersHeight = 20;
            this.griddetalleocompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.productid,
            this.productname,
            this.stock,
            this.unmedenvase,
            this.cantidad});
            this.griddetalleocompra.Location = new System.Drawing.Point(0, 81);
            this.griddetalleocompra.MultiSelect = false;
            this.griddetalleocompra.Name = "griddetalleocompra";
            this.griddetalleocompra.RowHeadersVisible = false;
            this.griddetalleocompra.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.griddetalleocompra.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.griddetalleocompra.RowTemplate.Height = 20;
            this.griddetalleocompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.griddetalleocompra.Size = new System.Drawing.Size(724, 154);
            this.griddetalleocompra.TabIndex = 73;
            this.griddetalleocompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetalleocompra_CellClick);
            this.griddetalleocompra.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetalleocompra_CellEndEdit);
            this.griddetalleocompra.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetalleocompra_CellEnter);
            this.griddetalleocompra.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetalleocompra_CellLeave);
            this.griddetalleocompra.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.griddetalleocompra_EditingControlShowing);
            this.griddetalleocompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.griddetalleocompra_KeyDown);
            this.griddetalleocompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.griddetalleocompra_KeyPress);
            // 
            // item
            // 
            this.item.DataPropertyName = "items";
            this.item.HeaderText = "Items";
            this.item.Name = "item";
            this.item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item.Width = 40;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "Codigo";
            this.productid.Name = "productid";
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.HeaderText = "Producto";
            this.productname.Name = "productname";
            this.productname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productname.Width = 280;
            // 
            // stock
            // 
            this.stock.DataPropertyName = "stock";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.stock.DefaultCellStyle = dataGridViewCellStyle2;
            this.stock.HeaderText = "Stock";
            this.stock.Name = "stock";
            this.stock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // unmedenvase
            // 
            this.unmedenvase.DataPropertyName = "unmedenvase";
            this.unmedenvase.HeaderText = "UnMed";
            this.unmedenvase.Name = "unmedenvase";
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
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
            this.btn_detanadir,
            this.btn_deteliminar,
            this.toolStripSeparator3,
            this.btn_clave,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(724, 29);
            this.Botonera.TabIndex = 34;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
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
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
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
            this.btn_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.Image")));
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
            // btn_detanadir
            // 
            this.btn_detanadir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_detanadir.Image = ((System.Drawing.Image)(resources.GetObject("btn_detanadir.Image")));
            this.btn_detanadir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_detanadir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_detanadir.Name = "btn_detanadir";
            this.btn_detanadir.Size = new System.Drawing.Size(24, 26);
            this.btn_detanadir.Text = "Añadir";
            this.btn_detanadir.Click += new System.EventHandler(this.btn_detanadir_Click);
            // 
            // btn_deteliminar
            // 
            this.btn_deteliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_deteliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_deteliminar.Image")));
            this.btn_deteliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_deteliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_deteliminar.Name = "btn_deteliminar";
            this.btn_deteliminar.Size = new System.Drawing.Size(24, 26);
            this.btn_deteliminar.Text = "Quitar";
            this.btn_deteliminar.Click += new System.EventHandler(this.btn_deteliminar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_clave
            // 
            this.btn_clave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            this.btn_clave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_clave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clave.Name = "btn_clave";
            this.btn_clave.Size = new System.Drawing.Size(24, 26);
            this.btn_clave.Text = "toolStripButton1";
            this.btn_clave.Click += new System.EventHandler(this.btn_clave_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 26);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txtobs
            // 
            this.txtobs.Location = new System.Drawing.Point(36, 245);
            this.txtobs.Multiline = true;
            this.txtobs.Name = "txtobs";
            this.txtobs.Size = new System.Drawing.Size(676, 19);
            this.txtobs.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Obs :";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 275);
            this.gridControl1.MainView = this.dgb_requerimiento;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(721, 196);
            this.gridControl1.TabIndex = 97;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgb_requerimiento});
            this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl1_KeyDown);
            // 
            // dgb_requerimiento
            // 
            this.dgb_requerimiento.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.dgb_requerimiento.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.dgb_requerimiento.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(190)))), ((int)(((byte)(243)))));
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.Empty.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.EvenRow.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.EvenRow.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.dgb_requerimiento.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.dgb_requerimiento.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.dgb_requerimiento.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.FilterPanel.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.FilterPanel.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.dgb_requerimiento.Appearance.FixedLine.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.dgb_requerimiento.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.dgb_requerimiento.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.dgb_requerimiento.Appearance.FooterPanel.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.FooterPanel.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.dgb_requerimiento.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.dgb_requerimiento.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.GroupButton.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.GroupButton.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.GroupButton.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.dgb_requerimiento.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.dgb_requerimiento.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.GroupFooter.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.GroupFooter.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.dgb_requerimiento.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.GroupPanel.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.dgb_requerimiento.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.dgb_requerimiento.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgb_requerimiento.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.GroupRow.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.GroupRow.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.GroupRow.Options.UseFont = true;
            this.dgb_requerimiento.Appearance.GroupRow.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.dgb_requerimiento.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.dgb_requerimiento.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.dgb_requerimiento.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.dgb_requerimiento.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.dgb_requerimiento.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.dgb_requerimiento.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.dgb_requerimiento.Appearance.HorzLine.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.OddRow.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.OddRow.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.dgb_requerimiento.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.dgb_requerimiento.Appearance.Preview.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.Preview.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.dgb_requerimiento.Appearance.Row.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.Row.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.RowSeparator.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.dgb_requerimiento.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_requerimiento.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgb_requerimiento.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgb_requerimiento.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.dgb_requerimiento.Appearance.VertLine.Options.UseBackColor = true;
            this.dgb_requerimiento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.go_item,
            this.go_productid,
            this.go_productname,
            this.go_stock,
            this.go_unmedenvase,
            this.go_cantidad});
            this.dgb_requerimiento.GridControl = this.gridControl1;
            this.dgb_requerimiento.Name = "dgb_requerimiento";
            this.dgb_requerimiento.OptionsView.EnableAppearanceEvenRow = true;
            this.dgb_requerimiento.OptionsView.EnableAppearanceOddRow = true;
            this.dgb_requerimiento.OptionsView.ShowGroupPanel = false;
            this.dgb_requerimiento.PaintStyleName = "Office2003";
            this.dgb_requerimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgb_requerimiento_KeyDown);
            // 
            // go_item
            // 
            this.go_item.Caption = "Items";
            this.go_item.FieldName = "item";
            this.go_item.Name = "go_item";
            this.go_item.OptionsColumn.AllowEdit = false;
            this.go_item.Visible = true;
            this.go_item.VisibleIndex = 0;
            this.go_item.Width = 40;
            // 
            // go_productid
            // 
            this.go_productid.Caption = "Codigo";
            this.go_productid.FieldName = "productid";
            this.go_productid.Name = "go_productid";
            this.go_productid.Visible = true;
            this.go_productid.VisibleIndex = 1;
            this.go_productid.Width = 92;
            // 
            // go_productname
            // 
            this.go_productname.Caption = "Producto";
            this.go_productname.FieldName = "productname";
            this.go_productname.Name = "go_productname";
            this.go_productname.OptionsColumn.AllowEdit = false;
            this.go_productname.Visible = true;
            this.go_productname.VisibleIndex = 2;
            this.go_productname.Width = 330;
            // 
            // go_stock
            // 
            this.go_stock.Caption = "Stock";
            this.go_stock.FieldName = "stock";
            this.go_stock.Name = "go_stock";
            this.go_stock.OptionsColumn.AllowEdit = false;
            this.go_stock.Visible = true;
            this.go_stock.VisibleIndex = 3;
            this.go_stock.Width = 93;
            // 
            // go_unmedenvase
            // 
            this.go_unmedenvase.Caption = "UndMed";
            this.go_unmedenvase.FieldName = "unmedenvase";
            this.go_unmedenvase.Name = "go_unmedenvase";
            this.go_unmedenvase.OptionsColumn.AllowEdit = false;
            this.go_unmedenvase.Visible = true;
            this.go_unmedenvase.VisibleIndex = 4;
            this.go_unmedenvase.Width = 47;
            // 
            // go_cantidad
            // 
            this.go_cantidad.Caption = "Cantidad";
            this.go_cantidad.FieldName = "cantidad";
            this.go_cantidad.Name = "go_cantidad";
            this.go_cantidad.Visible = true;
            this.go_cantidad.VisibleIndex = 5;
            this.go_cantidad.Width = 102;
            // 
            // Frm_RequerimientoOC2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 474);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtobs);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._productid);
            this.Controls.Add(this.subgruponame);
            this.Controls.Add(this._item);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grupoid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lineaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subgrupoid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.griddetalleocompra);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_RequerimientoOC2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REQUERIMIENTO";
            this.Activated += new System.EventHandler(this.Frm_Orden_compra_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Orden_compra_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Orden_compra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_RequerimientoOC_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.griddetalleocompra)).EndInit();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_requerimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_detanadir;
        private System.Windows.Forms.ToolStripButton btn_deteliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        internal System.Windows.Forms.DataGridView griddetalleocompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn unmedenvase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        internal System.Windows.Forms.TextBox _item;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox grupoid;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox lineaid;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox subgrupoid;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox subgruponame;
        internal System.Windows.Forms.TextBox _productid;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Button btn_agregar;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip totmensaje;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Label lblmensaje;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.TextBox txtobs;
        internal System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView dgb_requerimiento;
        private DevExpress.XtraGrid.Columns.GridColumn go_item;
        private DevExpress.XtraGrid.Columns.GridColumn go_productid;
        private DevExpress.XtraGrid.Columns.GridColumn go_productname;
        private DevExpress.XtraGrid.Columns.GridColumn go_stock;
        private DevExpress.XtraGrid.Columns.GridColumn go_unmedenvase;
        private DevExpress.XtraGrid.Columns.GridColumn go_cantidad;
    }
}