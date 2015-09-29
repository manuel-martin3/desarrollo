namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaPedidoComercial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaPedidoComercial));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEstilo = new System.Windows.Forms.TextBox();
            this.chkEstilo = new System.Windows.Forms.CheckBox();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.chkVendedor = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Fechafin = new System.Windows.Forms.DateTimePicker();
            this.Fechaini = new System.Windows.Forms.DateTimePicker();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.GridExaminar = new System.Windows.Forms.DataGridView();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctactename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleprenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proforma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendedorid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brokerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtEstilo);
            this.GroupBox2.Controls.Add(this.chkEstilo);
            this.GroupBox2.Controls.Add(this.cboVendedor);
            this.GroupBox2.Controls.Add(this.chkVendedor);
            this.GroupBox2.Controls.Add(this.btnBuscar);
            this.GroupBox2.Controls.Add(this.Fechafin);
            this.GroupBox2.Controls.Add(this.Fechaini);
            this.GroupBox2.Controls.Add(this.chkFechas);
            this.GroupBox2.Location = new System.Drawing.Point(8, 2);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(876, 63);
            this.GroupBox2.TabIndex = 22;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = " Filtros ";
            // 
            // txtEstilo
            // 
            this.txtEstilo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstilo.Location = new System.Drawing.Point(422, 35);
            this.txtEstilo.Name = "txtEstilo";
            this.txtEstilo.Size = new System.Drawing.Size(124, 20);
            this.txtEstilo.TabIndex = 25;
            // 
            // chkEstilo
            // 
            this.chkEstilo.AutoSize = true;
            this.chkEstilo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEstilo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkEstilo.Location = new System.Drawing.Point(362, 37);
            this.chkEstilo.Name = "chkEstilo";
            this.chkEstilo.Size = new System.Drawing.Size(51, 17);
            this.chkEstilo.TabIndex = 26;
            this.chkEstilo.Text = "Estilo";
            this.chkEstilo.UseVisualStyleBackColor = true;
            this.chkEstilo.CheckedChanged += new System.EventHandler(this.chkEstilo_CheckedChanged);
            // 
            // cboVendedor
            // 
            this.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(102, 35);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(246, 21);
            this.cboVendedor.TabIndex = 20;
            // 
            // chkVendedor
            // 
            this.chkVendedor.AutoSize = true;
            this.chkVendedor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVendedor.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkVendedor.Location = new System.Drawing.Point(23, 37);
            this.chkVendedor.Name = "chkVendedor";
            this.chkVendedor.Size = new System.Drawing.Size(72, 17);
            this.chkVendedor.TabIndex = 19;
            this.chkVendedor.Text = "Vendedor";
            this.chkVendedor.UseVisualStyleBackColor = true;
            this.chkVendedor.CheckedChanged += new System.EventHandler(this.chkVendedor_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(754, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 28);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Fechafin
            // 
            this.Fechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fechafin.Location = new System.Drawing.Point(197, 12);
            this.Fechafin.Name = "Fechafin";
            this.Fechafin.Size = new System.Drawing.Size(89, 20);
            this.Fechafin.TabIndex = 17;
            // 
            // Fechaini
            // 
            this.Fechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fechaini.Location = new System.Drawing.Point(102, 12);
            this.Fechaini.Name = "Fechaini";
            this.Fechaini.Size = new System.Drawing.Size(89, 20);
            this.Fechaini.TabIndex = 15;
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFechas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkFechas.Location = new System.Drawing.Point(34, 14);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(61, 17);
            this.chkFechas.TabIndex = 16;
            this.chkFechas.Text = "Fechas";
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // GridExaminar
            // 
            this.GridExaminar.AllowUserToAddRows = false;
            this.GridExaminar.AllowUserToDeleteRows = false;
            this.GridExaminar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridExaminar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridExaminar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridExaminar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.asiento,
            this.fechemision,
            this.ctactename,
            this.estilo,
            this.detalleprenda,
            this.op,
            this.proforma,
            this.vendedorid,
            this.brokerid,
            this.marcaid});
            this.GridExaminar.Location = new System.Drawing.Point(8, 68);
            this.GridExaminar.MultiSelect = false;
            this.GridExaminar.Name = "GridExaminar";
            this.GridExaminar.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridExaminar.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridExaminar.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridExaminar.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridExaminar.RowTemplate.Height = 20;
            this.GridExaminar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridExaminar.Size = new System.Drawing.Size(876, 317);
            this.GridExaminar.TabIndex = 20;
            this.GridExaminar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridExaminar_CellDoubleClick);
            this.GridExaminar.DoubleClick += new System.EventHandler(this.GridExaminar_DoubleClick);
            this.GridExaminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridExaminar_KeyDown);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(354, 382);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 40;
            this.GroupBox4.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(5, 10);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // asiento
            // 
            this.asiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.asiento.DataPropertyName = "asiento";
            this.asiento.HeaderText = "Pedido";
            this.asiento.Name = "asiento";
            this.asiento.ReadOnly = true;
            this.asiento.Width = 80;
            // 
            // fechemision
            // 
            this.fechemision.DataPropertyName = "fechemision";
            this.fechemision.HeaderText = "F.Emisión";
            this.fechemision.Name = "fechemision";
            this.fechemision.ReadOnly = true;
            this.fechemision.Width = 80;
            // 
            // ctactename
            // 
            this.ctactename.DataPropertyName = "ctactename";
            this.ctactename.HeaderText = "Cliente";
            this.ctactename.Name = "ctactename";
            this.ctactename.ReadOnly = true;
            this.ctactename.Width = 200;
            // 
            // estilo
            // 
            this.estilo.DataPropertyName = "estilo";
            this.estilo.HeaderText = "Estilo";
            this.estilo.Name = "estilo";
            this.estilo.ReadOnly = true;
            // 
            // detalleprenda
            // 
            this.detalleprenda.DataPropertyName = "detalleprenda";
            this.detalleprenda.HeaderText = "Descripción";
            this.detalleprenda.Name = "detalleprenda";
            this.detalleprenda.ReadOnly = true;
            // 
            // op
            // 
            this.op.DataPropertyName = "op";
            this.op.HeaderText = "OP";
            this.op.Name = "op";
            this.op.ReadOnly = true;
            this.op.Width = 80;
            // 
            // proforma
            // 
            this.proforma.DataPropertyName = "proforma";
            this.proforma.HeaderText = "Proforma";
            this.proforma.Name = "proforma";
            this.proforma.ReadOnly = true;
            this.proforma.Width = 90;
            // 
            // vendedorid
            // 
            this.vendedorid.DataPropertyName = "vendedorid";
            this.vendedorid.HeaderText = "Vendedor";
            this.vendedorid.Name = "vendedorid";
            this.vendedorid.ReadOnly = true;
            // 
            // brokerid
            // 
            this.brokerid.DataPropertyName = "brokerid";
            this.brokerid.HeaderText = "Broker";
            this.brokerid.Name = "brokerid";
            this.brokerid.ReadOnly = true;
            // 
            // marcaid
            // 
            this.marcaid.DataPropertyName = "marcaid";
            this.marcaid.HeaderText = "Marca";
            this.marcaid.Name = "marcaid";
            this.marcaid.ReadOnly = true;
            // 
            // Frm_AyudaPedidoComercial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 422);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GridExaminar);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaPedidoComercial";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<<Ayuda - Pedidos Comercial>>";
            this.Activated += new System.EventHandler(this.Frm_AyudaPedidoComercial_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaPedidoComercial_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtEstilo;
        internal System.Windows.Forms.CheckBox chkEstilo;
        internal System.Windows.Forms.ComboBox cboVendedor;
        internal System.Windows.Forms.CheckBox chkVendedor;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.DateTimePicker Fechafin;
        internal System.Windows.Forms.DateTimePicker Fechaini;
        internal System.Windows.Forms.CheckBox chkFechas;
        internal System.Windows.Forms.DataGridView GridExaminar;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctactename;
        private System.Windows.Forms.DataGridViewTextBoxColumn estilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalleprenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn proforma;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendedorid;
        private System.Windows.Forms.DataGridViewTextBoxColumn brokerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaid;
    }
}