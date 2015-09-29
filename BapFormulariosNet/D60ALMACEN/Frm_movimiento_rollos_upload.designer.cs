namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_movimiento_rollos_upload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_movimiento_rollos_upload));
            this.btn_error = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.preciorollo = new System.Windows.Forms.TextBox();
            this.gridgeneral = new System.Windows.Forms.DataGridView();
            this.total = new System.Windows.Forms.Label();
            this.contador = new System.Windows.Forms.Label();
            this.lb_mensaje = new System.Windows.Forms.Label();
            this.pl_contador = new System.Windows.Forms.Panel();
            this.cboTipodata = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_importar = new System.Windows.Forms.Button();
            this.rollo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stocklibros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockfisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).BeginInit();
            this.pl_contador.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_error
            // 
            this.btn_error.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_error.Enabled = false;
            this.btn_error.Image = global::BapFormulariosNet.Properties.Resources.btn_info;
            this.btn_error.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_error.Location = new System.Drawing.Point(432, 10);
            this.btn_error.Name = "btn_error";
            this.btn_error.Size = new System.Drawing.Size(67, 30);
            this.btn_error.TabIndex = 2;
            this.btn_error.Text = "&Errores";
            this.btn_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_error.UseVisualStyleBackColor = true;
            this.btn_error.Click += new System.EventHandler(this.btn_error_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cerrar.Image = global::BapFormulariosNet.Properties.Resources.go_cancel;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(359, 10);
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
            this.btnSeleccion.Location = new System.Drawing.Point(284, 10);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(69, 30);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Cargar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.Enabled = false;
            this.btn_cancelar.Image = global::BapFormulariosNet.Properties.Resources.go_undo2;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(278, 8);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(81, 30);
            this.btn_cancelar.TabIndex = 44;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_upload.Image = global::BapFormulariosNet.Properties.Resources.btn_signdown;
            this.btn_upload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_upload.Location = new System.Drawing.Point(188, 8);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(84, 30);
            this.btn_upload.TabIndex = 3;
            this.btn_upload.Text = "&Descarga";
            this.btn_upload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // preciorollo
            // 
            this.preciorollo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.preciorollo.Location = new System.Drawing.Point(118, 12);
            this.preciorollo.Name = "preciorollo";
            this.preciorollo.Size = new System.Drawing.Size(64, 20);
            this.preciorollo.TabIndex = 2;
            // 
            // gridgeneral
            // 
            this.gridgeneral.AllowUserToAddRows = false;
            this.gridgeneral.AllowUserToDeleteRows = false;
            this.gridgeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridgeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridgeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridgeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rollo,
            this.productid,
            this.productname,
            this.stocklibros,
            this.stockfisico,
            this.diferencia});
            this.gridgeneral.Location = new System.Drawing.Point(0, 44);
            this.gridgeneral.MultiSelect = false;
            this.gridgeneral.Name = "gridgeneral";
            this.gridgeneral.ReadOnly = true;
            this.gridgeneral.Size = new System.Drawing.Size(746, 291);
            this.gridgeneral.TabIndex = 42;
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
            this.pl_contador.Location = new System.Drawing.Point(608, 3);
            this.pl_contador.Name = "pl_contador";
            this.pl_contador.Size = new System.Drawing.Size(137, 44);
            this.pl_contador.TabIndex = 43;
            // 
            // cboTipodata
            // 
            this.cboTipodata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipodata.FormattingEnabled = true;
            this.cboTipodata.Items.AddRange(new object[] {
            "01. CODBAR",
            "02. CODBAR, PRECUNIT"});
            this.cboTipodata.Location = new System.Drawing.Point(438, 12);
            this.cboTipodata.Name = "cboTipodata";
            this.cboTipodata.Size = new System.Drawing.Size(161, 21);
            this.cboTipodata.TabIndex = 44;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Controls.Add(this.pl_contador);
            this.panel2.Controls.Add(this.cboTipodata);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btn_upload);
            this.panel2.Controls.Add(this.preciorollo);
            this.panel2.Location = new System.Drawing.Point(-1, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 47);
            this.panel2.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(365, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Tipo Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio Rollo Lote:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.btn_importar);
            this.panel3.Controls.Add(this.btn_error);
            this.panel3.Controls.Add(this.btnSeleccion);
            this.panel3.Controls.Add(this.btn_cerrar);
            this.panel3.Location = new System.Drawing.Point(-1, 335);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(747, 48);
            this.panel3.TabIndex = 47;
            // 
            // btn_importar
            // 
            this.btn_importar.BackColor = System.Drawing.Color.White;
            this.btn_importar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_importar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_importar.Image = global::BapFormulariosNet.Properties.Resources.go_excel3;
            this.btn_importar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_importar.Location = new System.Drawing.Point(166, 8);
            this.btn_importar.Name = "btn_importar";
            this.btn_importar.Size = new System.Drawing.Size(112, 31);
            this.btn_importar.TabIndex = 22;
            this.btn_importar.Text = "&Importar Excel";
            this.btn_importar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_importar.UseVisualStyleBackColor = false;
            this.btn_importar.Visible = false;
            this.btn_importar.Click += new System.EventHandler(this.btn_importar_Click);
            // 
            // rollo
            // 
            this.rollo.DataPropertyName = "rollo";
            this.rollo.HeaderText = "Rollo";
            this.rollo.Name = "rollo";
            this.rollo.ReadOnly = true;
            this.rollo.Width = 56;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "Codigo";
            this.productid.Name = "productid";
            this.productid.ReadOnly = true;
            this.productid.Visible = false;
            this.productid.Width = 65;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.HeaderText = "Producto";
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            this.productname.Width = 75;
            // 
            // stocklibros
            // 
            this.stocklibros.DataPropertyName = "stocklibros";
            this.stocklibros.HeaderText = "StockLibros";
            this.stocklibros.Name = "stocklibros";
            this.stocklibros.ReadOnly = true;
            this.stocklibros.Width = 88;
            // 
            // stockfisico
            // 
            this.stockfisico.DataPropertyName = "stockfisico";
            this.stockfisico.HeaderText = "StockFisico";
            this.stockfisico.Name = "stockfisico";
            this.stockfisico.ReadOnly = true;
            this.stockfisico.Width = 87;
            // 
            // diferencia
            // 
            this.diferencia.DataPropertyName = "diferencia";
            this.diferencia.HeaderText = "Diferencia";
            this.diferencia.Name = "diferencia";
            this.diferencia.ReadOnly = true;
            this.diferencia.Width = 80;
            // 
            // Frm_movimiento_rollos_upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 382);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gridgeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_movimiento_rollos_upload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "... :: Upload :: ...";
            this.Activated += new System.EventHandler(this.Frm_movimiento_rollos_upload_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_movimiento_rollos_upload_FormClosing);
            this.Load += new System.EventHandler(this.Frm_movimiento_rollos_upload_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_movimiento_rollos_upload_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).EndInit();
            this.pl_contador.ResumeLayout(false);
            this.pl_contador.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridView gridgeneral;
        internal System.Windows.Forms.TextBox preciorollo;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_error;
        internal System.Windows.Forms.Label lb_mensaje;
        internal System.Windows.Forms.Label contador;
        internal System.Windows.Forms.Label total;
        private System.Windows.Forms.Panel pl_contador;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.ComboBox cboTipodata;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_importar;
        private System.Windows.Forms.DataGridViewTextBoxColumn rollo;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn stocklibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockfisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn diferencia;
    }
}