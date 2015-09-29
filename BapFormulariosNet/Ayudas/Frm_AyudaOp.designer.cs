namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaOp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaOp));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.chkPedido = new System.Windows.Forms.CheckBox();
            this.chkRuc = new System.Windows.Forms.CheckBox();
            this.txtCtactename = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.chkOp = new System.Windows.Forms.CheckBox();
            this.txtOp = new System.Windows.Forms.TextBox();
            this.Fechaini = new System.Windows.Forms.DateTimePicker();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.Fechafin = new System.Windows.Forms.DateTimePicker();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rbNumero = new System.Windows.Forms.RadioButton();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.GridExaminar = new System.Windows.Forms.DataGridView();
            this.COL_OP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PEDIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ESTILO_CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_FEMISION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_FENTREGA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_CANTSOL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_ESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COL_TIENE_REQ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtPedido);
            this.GroupBox1.Controls.Add(this.chkPedido);
            this.GroupBox1.Controls.Add(this.chkRuc);
            this.GroupBox1.Controls.Add(this.txtCtactename);
            this.GroupBox1.Controls.Add(this.txtRuc);
            this.GroupBox1.Controls.Add(this.chkOp);
            this.GroupBox1.Controls.Add(this.txtOp);
            this.GroupBox1.Controls.Add(this.Fechaini);
            this.GroupBox1.Controls.Add(this.btnRefrescar);
            this.GroupBox1.Controls.Add(this.Fechafin);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Location = new System.Drawing.Point(7, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(805, 96);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // txtPedido
            // 
            this.txtPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPedido.Location = new System.Drawing.Point(131, 69);
            this.txtPedido.MaxLength = 10;
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(90, 20);
            this.txtPedido.TabIndex = 7;
            // 
            // chkPedido
            // 
            this.chkPedido.AutoSize = true;
            this.chkPedido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPedido.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkPedido.Location = new System.Drawing.Point(62, 71);
            this.chkPedido.Name = "chkPedido";
            this.chkPedido.Size = new System.Drawing.Size(59, 17);
            this.chkPedido.TabIndex = 6;
            this.chkPedido.Text = "Pedido";
            this.chkPedido.UseVisualStyleBackColor = true;
            this.chkPedido.CheckedChanged += new System.EventHandler(this.chkPedido_CheckedChanged);
            // 
            // chkRuc
            // 
            this.chkRuc.AutoSize = true;
            this.chkRuc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRuc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkRuc.Location = new System.Drawing.Point(44, 47);
            this.chkRuc.Name = "chkRuc";
            this.chkRuc.Size = new System.Drawing.Size(77, 17);
            this.chkRuc.TabIndex = 3;
            this.chkRuc.Text = "Cód - RUC";
            this.chkRuc.UseVisualStyleBackColor = true;
            this.chkRuc.CheckedChanged += new System.EventHandler(this.chkRuc_CheckedChanged);
            // 
            // txtCtactename
            // 
            this.txtCtactename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtactename.Location = new System.Drawing.Point(226, 45);
            this.txtCtactename.MaxLength = 100;
            this.txtCtactename.Name = "txtCtactename";
            this.txtCtactename.Size = new System.Drawing.Size(350, 20);
            this.txtCtactename.TabIndex = 5;
            // 
            // txtRuc
            // 
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Location = new System.Drawing.Point(131, 45);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(90, 20);
            this.txtRuc.TabIndex = 4;
            this.txtRuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRuc_KeyDown);
            // 
            // chkOp
            // 
            this.chkOp.AutoSize = true;
            this.chkOp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkOp.Location = new System.Drawing.Point(228, 71);
            this.chkOp.Name = "chkOp";
            this.chkOp.Size = new System.Drawing.Size(112, 17);
            this.chkOp.TabIndex = 8;
            this.chkOp.Text = "Orden Producción";
            this.chkOp.UseVisualStyleBackColor = true;
            this.chkOp.CheckedChanged += new System.EventHandler(this.chkOp_CheckedChanged);
            // 
            // txtOp
            // 
            this.txtOp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOp.Location = new System.Drawing.Point(350, 69);
            this.txtOp.MaxLength = 10;
            this.txtOp.Name = "txtOp";
            this.txtOp.Size = new System.Drawing.Size(90, 20);
            this.txtOp.TabIndex = 9;
            // 
            // Fechaini
            // 
            this.Fechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fechaini.Location = new System.Drawing.Point(168, 17);
            this.Fechaini.Name = "Fechaini";
            this.Fechaini.Size = new System.Drawing.Size(90, 20);
            this.Fechaini.TabIndex = 1;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescar.Location = new System.Drawing.Point(678, 59);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 28);
            this.btnRefrescar.TabIndex = 10;
            this.btnRefrescar.Text = "Refrescar Datos";
            this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // Fechafin
            // 
            this.Fechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fechafin.Location = new System.Drawing.Point(266, 17);
            this.Fechafin.Name = "Fechafin";
            this.Fechafin.Size = new System.Drawing.Size(90, 20);
            this.Fechafin.TabIndex = 2;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rbNumero);
            this.GroupBox5.Controls.Add(this.rbFecha);
            this.GroupBox5.Location = new System.Drawing.Point(13, 8);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(148, 33);
            this.GroupBox5.TabIndex = 0;
            this.GroupBox5.TabStop = false;
            // 
            // rbNumero
            // 
            this.rbNumero.AutoSize = true;
            this.rbNumero.Checked = true;
            this.rbNumero.Location = new System.Drawing.Point(85, 11);
            this.rbNumero.Name = "rbNumero";
            this.rbNumero.Size = new System.Drawing.Size(55, 17);
            this.rbNumero.TabIndex = 1;
            this.rbNumero.TabStop = true;
            this.rbNumero.Text = "Todos";
            this.rbNumero.UseVisualStyleBackColor = true;
            this.rbNumero.CheckedChanged += new System.EventHandler(this.rbNumero_CheckedChanged);
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Location = new System.Drawing.Point(9, 11);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(60, 17);
            this.rbFecha.TabIndex = 0;
            this.rbFecha.Text = "Fechas";
            this.rbFecha.UseVisualStyleBackColor = true;
            this.rbFecha.CheckedChanged += new System.EventHandler(this.rbFecha_CheckedChanged);
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
            this.COL_OP,
            this.COL_CLIENTE,
            this.COL_PEDIDO,
            this.COL_ESTILO_CLIENTE,
            this.COL_FEMISION,
            this.COL_FENTREGA,
            this.COL_PRODUCTO,
            this.COL_CANTSOL,
            this.COL_ESTADO,
            this.COL_TIENE_REQ});
            this.GridExaminar.Location = new System.Drawing.Point(7, 100);
            this.GridExaminar.MultiSelect = false;
            this.GridExaminar.Name = "GridExaminar";
            this.GridExaminar.ReadOnly = true;
            this.GridExaminar.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridExaminar.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridExaminar.RowTemplate.Height = 20;
            this.GridExaminar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridExaminar.Size = new System.Drawing.Size(805, 320);
            this.GridExaminar.TabIndex = 3;
            this.GridExaminar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridExaminar_CellDoubleClick);
            this.GridExaminar.DoubleClick += new System.EventHandler(this.GridExaminar_DoubleClick);
            this.GridExaminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridExaminar_KeyDown);
            // 
            // COL_OP
            // 
            this.COL_OP.DataPropertyName = "PEDIDO";
            this.COL_OP.HeaderText = "OP";
            this.COL_OP.Name = "COL_OP";
            this.COL_OP.ReadOnly = true;
            this.COL_OP.Width = 80;
            // 
            // COL_CLIENTE
            // 
            this.COL_CLIENTE.DataPropertyName = "DCLIENTE";
            this.COL_CLIENTE.HeaderText = "Cliente";
            this.COL_CLIENTE.Name = "COL_CLIENTE";
            this.COL_CLIENTE.ReadOnly = true;
            this.COL_CLIENTE.Width = 190;
            // 
            // COL_PEDIDO
            // 
            this.COL_PEDIDO.DataPropertyName = "D_PEDIDO_FC";
            this.COL_PEDIDO.HeaderText = "Pedido";
            this.COL_PEDIDO.Name = "COL_PEDIDO";
            this.COL_PEDIDO.ReadOnly = true;
            this.COL_PEDIDO.Width = 80;
            // 
            // COL_ESTILO_CLIENTE
            // 
            this.COL_ESTILO_CLIENTE.DataPropertyName = "ESTILO_CLIENTE";
            this.COL_ESTILO_CLIENTE.HeaderText = "Estilo";
            this.COL_ESTILO_CLIENTE.Name = "COL_ESTILO_CLIENTE";
            this.COL_ESTILO_CLIENTE.ReadOnly = true;
            // 
            // COL_FEMISION
            // 
            this.COL_FEMISION.DataPropertyName = "F_EMISION";
            this.COL_FEMISION.HeaderText = "F.Emisión";
            this.COL_FEMISION.Name = "COL_FEMISION";
            this.COL_FEMISION.ReadOnly = true;
            this.COL_FEMISION.Width = 82;
            // 
            // COL_FENTREGA
            // 
            this.COL_FENTREGA.DataPropertyName = "D_FINPROD";
            this.COL_FENTREGA.HeaderText = "F.Entrega";
            this.COL_FENTREGA.Name = "COL_FENTREGA";
            this.COL_FENTREGA.ReadOnly = true;
            this.COL_FENTREGA.Width = 82;
            // 
            // COL_PRODUCTO
            // 
            this.COL_PRODUCTO.DataPropertyName = "DES_PRENDA";
            this.COL_PRODUCTO.HeaderText = "Producto";
            this.COL_PRODUCTO.Name = "COL_PRODUCTO";
            this.COL_PRODUCTO.ReadOnly = true;
            this.COL_PRODUCTO.Visible = false;
            this.COL_PRODUCTO.Width = 70;
            // 
            // COL_CANTSOL
            // 
            this.COL_CANTSOL.DataPropertyName = "CANT_SOL";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.COL_CANTSOL.DefaultCellStyle = dataGridViewCellStyle2;
            this.COL_CANTSOL.HeaderText = "Cant.Solicitada";
            this.COL_CANTSOL.Name = "COL_CANTSOL";
            this.COL_CANTSOL.ReadOnly = true;
            // 
            // COL_ESTADO
            // 
            this.COL_ESTADO.DataPropertyName = "ESTADO";
            this.COL_ESTADO.HeaderText = "E";
            this.COL_ESTADO.Name = "COL_ESTADO";
            this.COL_ESTADO.ReadOnly = true;
            this.COL_ESTADO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COL_ESTADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.COL_ESTADO.Width = 24;
            // 
            // COL_TIENE_REQ
            // 
            this.COL_TIENE_REQ.DataPropertyName = "TIENE_REQ";
            this.COL_TIENE_REQ.HeaderText = "REQ.";
            this.COL_TIENE_REQ.Name = "COL_TIENE_REQ";
            this.COL_TIENE_REQ.ReadOnly = true;
            this.COL_TIENE_REQ.Width = 38;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(316, 418);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 39;
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
            // Frm_AyudaOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 458);
            this.Controls.Add(this.GridExaminar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaOp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<<Ayuda - Orden de Producción>>";
            this.Activated += new System.EventHandler(this.Frm_AyudaOp_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaOp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaOp_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtPedido;
        internal System.Windows.Forms.CheckBox chkPedido;
        internal System.Windows.Forms.CheckBox chkRuc;
        internal System.Windows.Forms.TextBox txtCtactename;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.CheckBox chkOp;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton rbNumero;
        internal System.Windows.Forms.RadioButton rbFecha;
        internal System.Windows.Forms.TextBox txtOp;
        internal System.Windows.Forms.DateTimePicker Fechaini;
        internal System.Windows.Forms.Button btnRefrescar;
        internal System.Windows.Forms.DateTimePicker Fechafin;
        internal System.Windows.Forms.DataGridView GridExaminar;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_OP;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PEDIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_ESTILO_CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_FEMISION;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_FENTREGA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_CANTSOL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_ESTADO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn COL_TIENE_REQ;
    }
}