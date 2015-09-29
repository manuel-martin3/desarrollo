namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_reporte_pedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_pedidos));
            this.Mensaje = new System.Windows.Forms.ToolTip(this.components);
            this.productid = new System.Windows.Forms.TextBox();
            this.productname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgb_historial = new System.Windows.Forms.DataGridView();
            this._fechdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctactename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrelargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgb_stock = new System.Windows.Forms.DataGridView();
            this.fechdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tipodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._serdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._precunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._numfac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ctactename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.peso = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.unmedpeso = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.btn_print = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_historial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_stock)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productid
            // 
            this.productid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productid.Location = new System.Drawing.Point(81, 43);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(105, 20);
            this.productid.TabIndex = 66;
            this.productid.TextChanged += new System.EventHandler(this.productid_TextChanged);
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // productname
            // 
            this.productname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productname.Location = new System.Drawing.Point(189, 43);
            this.productname.Multiline = true;
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            this.productname.Size = new System.Drawing.Size(520, 21);
            this.productname.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 65;
            this.label2.Text = "Movimientos Fisicos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 64;
            this.label1.Text = "Historial de Habilitación";
            // 
            // dgb_historial
            // 
            this.dgb_historial.AllowUserToAddRows = false;
            this.dgb_historial.AllowUserToDeleteRows = false;
            this.dgb_historial.AllowUserToResizeColumns = false;
            this.dgb_historial.AllowUserToResizeRows = false;
            this.dgb_historial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb_historial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._fechdoc,
            this.tipodoc,
            this.serdoc,
            this.numdoc,
            this.cantidad,
            this.motivo,
            this.ctactename,
            this.cencosname,
            this.estacion,
            this.nombrelargo,
            this.glosa});
            this.dgb_historial.Location = new System.Drawing.Point(12, 348);
            this.dgb_historial.Name = "dgb_historial";
            this.dgb_historial.ReadOnly = true;
            this.dgb_historial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgb_historial.Size = new System.Drawing.Size(1089, 197);
            this.dgb_historial.TabIndex = 63;
            // 
            // _fechdoc
            // 
            this._fechdoc.DataPropertyName = "fechdoc";
            this._fechdoc.HeaderText = "Fecha";
            this._fechdoc.Name = "_fechdoc";
            this._fechdoc.ReadOnly = true;
            this._fechdoc.Width = 90;
            // 
            // tipodoc
            // 
            this.tipodoc.DataPropertyName = "tipodoc";
            this.tipodoc.HeaderText = "TipDoc";
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.ReadOnly = true;
            this.tipodoc.Width = 50;
            // 
            // serdoc
            // 
            this.serdoc.DataPropertyName = "serdoc";
            this.serdoc.HeaderText = "SerDoc";
            this.serdoc.Name = "serdoc";
            this.serdoc.ReadOnly = true;
            this.serdoc.Width = 50;
            // 
            // numdoc
            // 
            this.numdoc.DataPropertyName = "numdoc";
            this.numdoc.HeaderText = "NumDoc";
            this.numdoc.Name = "numdoc";
            this.numdoc.ReadOnly = true;
            this.numdoc.Width = 80;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 60;
            // 
            // motivo
            // 
            this.motivo.DataPropertyName = "motivo";
            this.motivo.HeaderText = "Motivo";
            this.motivo.Name = "motivo";
            this.motivo.ReadOnly = true;
            this.motivo.Width = 150;
            // 
            // ctactename
            // 
            this.ctactename.DataPropertyName = "ctactename";
            this.ctactename.HeaderText = "Cliente/Proveedor";
            this.ctactename.Name = "ctactename";
            this.ctactename.ReadOnly = true;
            this.ctactename.Visible = false;
            this.ctactename.Width = 200;
            // 
            // cencosname
            // 
            this.cencosname.DataPropertyName = "cencosname";
            this.cencosname.HeaderText = "CentroCosto";
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            // 
            // estacion
            // 
            this.estacion.DataPropertyName = "estacion";
            this.estacion.HeaderText = "Estacion";
            this.estacion.Name = "estacion";
            this.estacion.ReadOnly = true;
            this.estacion.Width = 60;
            // 
            // nombrelargo
            // 
            this.nombrelargo.DataPropertyName = "nombrelargo";
            this.nombrelargo.HeaderText = "Personal";
            this.nombrelargo.Name = "nombrelargo";
            this.nombrelargo.ReadOnly = true;
            this.nombrelargo.Width = 200;
            // 
            // glosa
            // 
            this.glosa.DataPropertyName = "glosa";
            this.glosa.HeaderText = "Glosa";
            this.glosa.Name = "glosa";
            this.glosa.ReadOnly = true;
            this.glosa.Width = 200;
            // 
            // dgb_stock
            // 
            this.dgb_stock.AllowUserToAddRows = false;
            this.dgb_stock.AllowUserToDeleteRows = false;
            this.dgb_stock.AllowUserToResizeColumns = false;
            this.dgb_stock.AllowUserToResizeRows = false;
            this.dgb_stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb_stock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechdoc,
            this._tipodoc,
            this._serdoc,
            this._numdoc,
            this._cantidad,
            this._motivo,
            this._precunit,
            this._numfac,
            this._ctactename});
            this.dgb_stock.Location = new System.Drawing.Point(12, 103);
            this.dgb_stock.Name = "dgb_stock";
            this.dgb_stock.ReadOnly = true;
            this.dgb_stock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgb_stock.Size = new System.Drawing.Size(955, 203);
            this.dgb_stock.TabIndex = 60;
            this.dgb_stock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_stock_CellClick);
            // 
            // fechdoc
            // 
            this.fechdoc.DataPropertyName = "fechdoc";
            this.fechdoc.HeaderText = "Fecha";
            this.fechdoc.Name = "fechdoc";
            this.fechdoc.ReadOnly = true;
            this.fechdoc.Width = 90;
            // 
            // _tipodoc
            // 
            this._tipodoc.DataPropertyName = "tipodoc";
            this._tipodoc.HeaderText = "TipDoc";
            this._tipodoc.Name = "_tipodoc";
            this._tipodoc.ReadOnly = true;
            this._tipodoc.Width = 50;
            // 
            // _serdoc
            // 
            this._serdoc.DataPropertyName = "serdoc";
            this._serdoc.HeaderText = "SerDoc";
            this._serdoc.Name = "_serdoc";
            this._serdoc.ReadOnly = true;
            this._serdoc.Width = 50;
            // 
            // _numdoc
            // 
            this._numdoc.DataPropertyName = "numdoc";
            this._numdoc.HeaderText = "NumDoc";
            this._numdoc.Name = "_numdoc";
            this._numdoc.ReadOnly = true;
            this._numdoc.Width = 80;
            // 
            // _cantidad
            // 
            this._cantidad.DataPropertyName = "cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this._cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this._cantidad.HeaderText = "Cantidad";
            this._cantidad.Name = "_cantidad";
            this._cantidad.ReadOnly = true;
            this._cantidad.Width = 60;
            // 
            // _motivo
            // 
            this._motivo.DataPropertyName = "motivo";
            this._motivo.HeaderText = "Motivo";
            this._motivo.Name = "_motivo";
            this._motivo.ReadOnly = true;
            this._motivo.Width = 150;
            // 
            // _precunit
            // 
            this._precunit.DataPropertyName = "precunit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this._precunit.DefaultCellStyle = dataGridViewCellStyle3;
            this._precunit.HeaderText = "PrecUnit";
            this._precunit.Name = "_precunit";
            this._precunit.ReadOnly = true;
            // 
            // _numfac
            // 
            this._numfac.DataPropertyName = "numfac";
            this._numfac.HeaderText = "Factura";
            this._numfac.Name = "_numfac";
            this._numfac.ReadOnly = true;
            this._numfac.Width = 80;
            // 
            // _ctactename
            // 
            this._ctactename.DataPropertyName = "ctactename";
            this._ctactename.HeaderText = "Cliente/Proveedor";
            this._ctactename.Name = "_ctactename";
            this._ctactename.ReadOnly = true;
            this._ctactename.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Producto:";
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
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, -23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 56);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(445, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "PEDIDOS";
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
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1106, 548);
            this.shapeContainer1.TabIndex = 62;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderWidth = 2;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 14;
            this.lineShape2.X2 = 1038;
            this.lineShape2.Y1 = 319;
            this.lineShape2.Y2 = 319;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 15;
            this.lineShape1.X2 = 954;
            this.lineShape1.Y1 = 80;
            this.lineShape1.Y2 = 80;
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(719, 37);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(95, 32);
            this.btn_busqueda.TabIndex = 68;
            this.btn_busqueda.Text = "&Consultar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // btn_print
            // 
            this.btn_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_print.Image")));
            this.btn_print.Location = new System.Drawing.Point(973, 271);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(37, 36);
            this.btn_print.TabIndex = 69;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // Frm_reporte_pedidos
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1106, 548);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_busqueda);
            this.Controls.Add(this.productid);
            this.Controls.Add(this.productname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgb_historial);
            this.Controls.Add(this.dgb_stock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.peso);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.unmedpeso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_pedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PEDIDOS";
            this.Load += new System.EventHandler(this.Frm_reporte_historialxestacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgb_historial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_stock)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox peso;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.TextBox unmedpeso;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgb_stock;
        private System.Windows.Forms.ToolTip Mensaje;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.DataGridView dgb_historial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox productid;
        private System.Windows.Forms.TextBox productname;
        private System.Windows.Forms.Button btn_busqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tipodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _serdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _precunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _numfac;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ctactename;
        private System.Windows.Forms.DataGridViewTextBoxColumn _fechdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn serdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctactename;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosname;
        private System.Windows.Forms.DataGridViewTextBoxColumn estacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrelargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosa;
        private DevExpress.XtraEditors.SimpleButton btn_print;

    }
}