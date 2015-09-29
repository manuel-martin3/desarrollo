namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_productos_upload
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_productos_upload));
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.total = new System.Windows.Forms.Label();
            this.contador = new System.Windows.Forms.Label();
            this.lb_mensaje = new System.Windows.Forms.Label();
            this.pl_contador = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cencosid = new System.Windows.Forms.TextBox();
            this.cencosname = new System.Windows.Forms.TextBox();
            this.estacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.griddetallemov = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cencosname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._productidold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rollo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importfac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totimpto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_contador.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddetallemov)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cerrar.Image = global::BapFormulariosNet.Properties.Resources.go_cancel;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(369, 5);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(67, 30);
            this.btn_cerrar.TabIndex = 1;
            this.btn_cerrar.Text = "&Cerrar";
            this.btn_cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.go_check;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(294, 5);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(69, 30);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Cargar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // total
            // 
            this.total.BackColor = System.Drawing.Color.Transparent;
            this.total.ForeColor = System.Drawing.Color.White;
            this.total.Location = new System.Drawing.Point(82, 13);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(50, 13);
            this.total.TabIndex = 5;
            this.total.Text = "0";
            this.total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contador
            // 
            this.contador.BackColor = System.Drawing.Color.Transparent;
            this.contador.ForeColor = System.Drawing.Color.White;
            this.contador.Location = new System.Drawing.Point(4, 13);
            this.contador.Name = "contador";
            this.contador.Size = new System.Drawing.Size(50, 13);
            this.contador.TabIndex = 6;
            this.contador.Text = "0";
            this.contador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_mensaje
            // 
            this.lb_mensaje.AutoSize = true;
            this.lb_mensaje.BackColor = System.Drawing.Color.Transparent;
            this.lb_mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mensaje.ForeColor = System.Drawing.Color.White;
            this.lb_mensaje.Location = new System.Drawing.Point(56, 13);
            this.lb_mensaje.Name = "lb_mensaje";
            this.lb_mensaje.Size = new System.Drawing.Size(24, 13);
            this.lb_mensaje.TabIndex = 7;
            this.lb_mensaje.Text = "DE";
            this.lb_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pl_contador
            // 
            this.pl_contador.Controls.Add(this.lb_mensaje);
            this.pl_contador.Controls.Add(this.total);
            this.pl_contador.Controls.Add(this.contador);
            this.pl_contador.Location = new System.Drawing.Point(657, 6);
            this.pl_contador.Name = "pl_contador";
            this.pl_contador.Size = new System.Drawing.Size(137, 44);
            this.pl_contador.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cencosid);
            this.panel2.Controls.Add(this.cencosname);
            this.panel2.Controls.Add(this.estacion);
            this.panel2.Controls.Add(this.pl_contador);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(-1, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 54);
            this.panel2.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(85, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Estacion:";
            // 
            // cencosid
            // 
            this.cencosid.Location = new System.Drawing.Point(150, 8);
            this.cencosid.MaxLength = 5;
            this.cencosid.Name = "cencosid";
            this.cencosid.Size = new System.Drawing.Size(39, 20);
            this.cencosid.TabIndex = 45;
            this.cencosid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cencosid_KeyDown);
            // 
            // cencosname
            // 
            this.cencosname.Location = new System.Drawing.Point(192, 8);
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Size = new System.Drawing.Size(240, 20);
            this.cencosname.TabIndex = 46;
            // 
            // estacion
            // 
            this.estacion.Location = new System.Drawing.Point(150, 29);
            this.estacion.MaxLength = 3;
            this.estacion.Name = "estacion";
            this.estacion.Size = new System.Drawing.Size(39, 20);
            this.estacion.TabIndex = 48;
            this.estacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.estacion_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(42, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Centro de Costo:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.btnSeleccion);
            this.panel3.Controls.Add(this.btn_cerrar);
            this.panel3.Location = new System.Drawing.Point(-1, 292);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 41);
            this.panel3.TabIndex = 47;
            // 
            // griddetallemov
            // 
            this.griddetallemov.AllowUserToAddRows = false;
            this.griddetallemov.AllowUserToDeleteRows = false;
            this.griddetallemov.AllowUserToResizeColumns = false;
            this.griddetallemov.AllowUserToResizeRows = false;
            this.griddetallemov.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.griddetallemov.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.griddetallemov.ColumnHeadersHeight = 18;
            this.griddetallemov.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.productid,
            this.productname,
            this._cencosname,
            this._productidold,
            this._estacion,
            this.rollo,
            this.unmed,
            this.Ubicacion,
            this.itemref,
            this.cantidad,
            this.precunit,
            this.valor,
            this.importe,
            this.importfac,
            this.totimpto});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.griddetallemov.DefaultCellStyle = dataGridViewCellStyle7;
            this.griddetallemov.Location = new System.Drawing.Point(0, 51);
            this.griddetallemov.MultiSelect = false;
            this.griddetallemov.Name = "griddetallemov";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.griddetallemov.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.griddetallemov.RowHeadersWidth = 10;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.NullValue = null;
            this.griddetallemov.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.griddetallemov.RowTemplate.DefaultCellStyle.Format = "N6";
            this.griddetallemov.RowTemplate.DefaultCellStyle.NullValue = null;
            this.griddetallemov.RowTemplate.Height = 20;
            this.griddetallemov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.griddetallemov.Size = new System.Drawing.Size(802, 239);
            this.griddetallemov.TabIndex = 72;
            // 
            // item
            // 
            this.item.DataPropertyName = "items";
            this.item.Frozen = true;
            this.item.HeaderText = "Items";
            this.item.Name = "item";
            this.item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item.Width = 40;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.Frozen = true;
            this.productid.HeaderText = "Codigo";
            this.productid.Name = "productid";
            this.productid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.Frozen = true;
            this.productname.HeaderText = "Producto";
            this.productname.Name = "productname";
            this.productname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productname.Width = 400;
            // 
            // _cencosname
            // 
            this._cencosname.DataPropertyName = "cencosname";
            this._cencosname.Frozen = true;
            this._cencosname.HeaderText = "C.Costo";
            this._cencosname.Name = "_cencosname";
            // 
            // _productidold
            // 
            this._productidold.DataPropertyName = "productidold";
            this._productidold.Frozen = true;
            this._productidold.HeaderText = "C.Barra";
            this._productidold.Name = "_productidold";
            this._productidold.Width = 90;
            // 
            // _estacion
            // 
            this._estacion.DataPropertyName = "estacion";
            this._estacion.Frozen = true;
            this._estacion.HeaderText = "Estacion";
            this._estacion.Name = "_estacion";
            this._estacion.Width = 60;
            // 
            // rollo
            // 
            this.rollo.DataPropertyName = "rollo";
            this.rollo.Frozen = true;
            this.rollo.HeaderText = "Rollo";
            this.rollo.MaxInputLength = 10;
            this.rollo.Name = "rollo";
            this.rollo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rollo.Visible = false;
            this.rollo.Width = 80;
            // 
            // unmed
            // 
            this.unmed.DataPropertyName = "unmed";
            this.unmed.HeaderText = "UnMed";
            this.unmed.Name = "unmed";
            this.unmed.Visible = false;
            this.unmed.Width = 48;
            // 
            // Ubicacion
            // 
            this.Ubicacion.DataPropertyName = "ubicacion";
            dataGridViewCellStyle2.NullValue = null;
            this.Ubicacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Ubicacion.HeaderText = "Ubicacion";
            this.Ubicacion.MaxInputLength = 4;
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ubicacion.Visible = false;
            // 
            // itemref
            // 
            this.itemref.DataPropertyName = "itemref";
            this.itemref.HeaderText = "itemref";
            this.itemref.Name = "itemref";
            this.itemref.Visible = false;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cantidad.Visible = false;
            this.cantidad.Width = 80;
            // 
            // precunit
            // 
            this.precunit.DataPropertyName = "precunit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = null;
            this.precunit.DefaultCellStyle = dataGridViewCellStyle4;
            this.precunit.HeaderText = "Precio";
            this.precunit.Name = "precunit";
            this.precunit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.precunit.Visible = false;
            this.precunit.Width = 90;
            // 
            // valor
            // 
            this.valor.DataPropertyName = "valor";
            this.valor.HeaderText = "valor";
            this.valor.Name = "valor";
            this.valor.Visible = false;
            // 
            // importe
            // 
            this.importe.DataPropertyName = "importe";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.importe.DefaultCellStyle = dataGridViewCellStyle5;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.importe.Visible = false;
            // 
            // importfac
            // 
            this.importfac.DataPropertyName = "importfac";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.importfac.DefaultCellStyle = dataGridViewCellStyle6;
            this.importfac.HeaderText = "ImportFact";
            this.importfac.Name = "importfac";
            this.importfac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.importfac.Visible = false;
            // 
            // totimpto
            // 
            this.totimpto.DataPropertyName = "totimpto";
            this.totimpto.HeaderText = "totimpto";
            this.totimpto.Name = "totimpto";
            this.totimpto.Visible = false;
            // 
            // Frm_productos_upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 332);
            this.Controls.Add(this.griddetallemov);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_productos_upload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "... :: Upload :: ...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_movimiento_rollos_upload_FormClosing);
            this.Load += new System.EventHandler(this.Frm_productos_upload_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_movimiento_rollos_upload_KeyDown);
            this.pl_contador.ResumeLayout(false);
            this.pl_contador.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.griddetallemov)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.Button btn_cerrar;
        internal System.Windows.Forms.Label lb_mensaje;
        internal System.Windows.Forms.Label contador;
        internal System.Windows.Forms.Label total;
        private System.Windows.Forms.Panel pl_contador;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox cencosid;
        internal System.Windows.Forms.TextBox cencosname;
        internal System.Windows.Forms.TextBox estacion;
        internal System.Windows.Forms.DataGridView griddetallemov;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cencosname;
        private System.Windows.Forms.DataGridViewTextBoxColumn _productidold;
        private System.Windows.Forms.DataGridViewTextBoxColumn _estacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn rollo;
        private System.Windows.Forms.DataGridViewTextBoxColumn unmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemref;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn importfac;
        private System.Windows.Forms.DataGridViewTextBoxColumn totimpto;
    }
}