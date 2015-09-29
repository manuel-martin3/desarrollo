namespace BapFormulariosNet.D60ALMACEN.REPORTES
{
    partial class Frm_RequerimientoOC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RequerimientoOC));
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
            this.btn_primero = new System.Windows.Forms.ToolStripButton();
            this.btn_anterior = new System.Windows.Forms.ToolStripButton();
            this.btn_siguiente = new System.Windows.Forms.ToolStripButton();
            this.btn_ultimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_detanadir = new System.Windows.Forms.ToolStripButton();
            this.btn_deteliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.griddetalleocompra)).BeginInit();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
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
            this.griddetalleocompra.Location = new System.Drawing.Point(0, 30);
            this.griddetalleocompra.MultiSelect = false;
            this.griddetalleocompra.Name = "griddetalleocompra";
            this.griddetalleocompra.RowHeadersVisible = false;
            this.griddetalleocompra.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.griddetalleocompra.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.griddetalleocompra.RowTemplate.Height = 20;
            this.griddetalleocompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.griddetalleocompra.Size = new System.Drawing.Size(724, 280);
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
            this.btn_primero,
            this.btn_anterior,
            this.btn_siguiente,
            this.btn_ultimo,
            this.toolStripSeparator2,
            this.btn_detanadir,
            this.btn_deteliminar,
            this.toolStripSeparator3,
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
            // btn_primero
            // 
            this.btn_primero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_primero.Enabled = false;
            this.btn_primero.Image = ((System.Drawing.Image)(resources.GetObject("btn_primero.Image")));
            this.btn_primero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_primero.Name = "btn_primero";
            this.btn_primero.Size = new System.Drawing.Size(26, 26);
            this.btn_primero.Text = "Primero";
            // 
            // btn_anterior
            // 
            this.btn_anterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_anterior.Enabled = false;
            this.btn_anterior.Image = ((System.Drawing.Image)(resources.GetObject("btn_anterior.Image")));
            this.btn_anterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.Size = new System.Drawing.Size(26, 26);
            this.btn_anterior.Text = "Anterior";
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_siguiente.Enabled = false;
            this.btn_siguiente.Image = ((System.Drawing.Image)(resources.GetObject("btn_siguiente.Image")));
            this.btn_siguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(26, 26);
            this.btn_siguiente.Text = "Siguiente";
            // 
            // btn_ultimo
            // 
            this.btn_ultimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ultimo.Enabled = false;
            this.btn_ultimo.Image = ((System.Drawing.Image)(resources.GetObject("btn_ultimo.Image")));
            this.btn_ultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ultimo.Name = "btn_ultimo";
            this.btn_ultimo.Size = new System.Drawing.Size(26, 26);
            this.btn_ultimo.Text = "Ultimo";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
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
            this.btn_deteliminar.Image = global::BapFormulariosNet.Properties.Resources.go_remove1;
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
            // Frm_RequerimientoOC
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 314);
            this.Controls.Add(this.griddetalleocompra);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Name = "Frm_RequerimientoOC";
            this.Text = "»» Requerimiento";
            this.Activated += new System.EventHandler(this.Frm_Orden_compra_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Orden_compra_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Orden_compra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_RequerimientoOC_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.griddetalleocompra)).EndInit();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_primero;
        private System.Windows.Forms.ToolStripButton btn_anterior;
        private System.Windows.Forms.ToolStripButton btn_siguiente;
        private System.Windows.Forms.ToolStripButton btn_ultimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
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
    }
}