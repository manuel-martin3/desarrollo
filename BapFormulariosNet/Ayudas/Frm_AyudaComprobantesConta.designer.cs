namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaComprobantesConta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaComprobantesConta));
            this.dgComprobantesConta = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTipooperacion = new System.Windows.Forms.ComboBox();
            this.chktipooperacion = new System.Windows.Forms.CheckBox();
            this.chktipocomprobante = new System.Windows.Forms.CheckBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.Fecha2 = new System.Windows.Forms.DateTimePicker();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.Fecha1 = new System.Windows.Forms.DateTimePicker();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.cboSubdiario = new System.Windows.Forms.ComboBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.perianio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diarioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipooperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechregistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocomprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debesoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habersoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debedolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haberdolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgComprobantesConta)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgComprobantesConta
            // 
            this.dgComprobantesConta.AllowUserToAddRows = false;
            this.dgComprobantesConta.AllowUserToDeleteRows = false;
            this.dgComprobantesConta.AllowUserToResizeRows = false;
            this.dgComprobantesConta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgComprobantesConta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgComprobantesConta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgComprobantesConta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perianio,
            this.perimes,
            this.moduloid,
            this.local,
            this.diarioid,
            this.asiento,
            this.moneda,
            this.tipooperacion,
            this.fechregistro,
            this.tipocomprobante,
            this.debesoles,
            this.habersoles,
            this.debedolares,
            this.haberdolares,
            this.glosa,
            this.status});
            this.dgComprobantesConta.Location = new System.Drawing.Point(8, 77);
            this.dgComprobantesConta.MultiSelect = false;
            this.dgComprobantesConta.Name = "dgComprobantesConta";
            this.dgComprobantesConta.ReadOnly = true;
            this.dgComprobantesConta.RowHeadersVisible = false;
            this.dgComprobantesConta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgComprobantesConta.Size = new System.Drawing.Size(1009, 397);
            this.dgComprobantesConta.TabIndex = 4;
            this.dgComprobantesConta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgComprobantesConta_CellDoubleClick);
            this.dgComprobantesConta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgComprobantesConta_KeyDown);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cboTipooperacion);
            this.GroupBox1.Controls.Add(this.chktipooperacion);
            this.GroupBox1.Controls.Add(this.chktipocomprobante);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.Fecha2);
            this.GroupBox1.Controls.Add(this.chkFechas);
            this.GroupBox1.Controls.Add(this.Fecha1);
            this.GroupBox1.Controls.Add(this.lbCodigo);
            this.GroupBox1.Controls.Add(this.cboSubdiario);
            this.GroupBox1.Location = new System.Drawing.Point(16, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(995, 70);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // cboTipooperacion
            // 
            this.cboTipooperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipooperacion.FormattingEnabled = true;
            this.cboTipooperacion.Location = new System.Drawing.Point(420, 40);
            this.cboTipooperacion.Name = "cboTipooperacion";
            this.cboTipooperacion.Size = new System.Drawing.Size(203, 21);
            this.cboTipooperacion.TabIndex = 10;
            // 
            // chktipooperacion
            // 
            this.chktipooperacion.AutoSize = true;
            this.chktipooperacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktipooperacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chktipooperacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.chktipooperacion.Location = new System.Drawing.Point(317, 42);
            this.chktipooperacion.Name = "chktipooperacion";
            this.chktipooperacion.Size = new System.Drawing.Size(99, 17);
            this.chktipooperacion.TabIndex = 9;
            this.chktipooperacion.Text = "Tipo Operación";
            this.chktipooperacion.UseVisualStyleBackColor = true;
            this.chktipooperacion.CheckedChanged += new System.EventHandler(this.chktipooperacion_CheckedChanged);
            // 
            // chktipocomprobante
            // 
            this.chktipocomprobante.AutoSize = true;
            this.chktipocomprobante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktipocomprobante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chktipocomprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.chktipocomprobante.Location = new System.Drawing.Point(8, 16);
            this.chktipocomprobante.Name = "chktipocomprobante";
            this.chktipocomprobante.Size = new System.Drawing.Size(113, 17);
            this.chktipocomprobante.TabIndex = 8;
            this.chktipocomprobante.Text = "Tipo Comprobante";
            this.chktipocomprobante.UseVisualStyleBackColor = true;
            this.chktipocomprobante.CheckedChanged += new System.EventHandler(this.chktipocomprobante_CheckedChanged);
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(886, 30);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(90, 29);
            this.btnrefrescar.TabIndex = 7;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // Fecha2
            // 
            this.Fecha2.Checked = false;
            this.Fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha2.Location = new System.Drawing.Point(222, 40);
            this.Fecha2.Name = "Fecha2";
            this.Fecha2.Size = new System.Drawing.Size(89, 20);
            this.Fecha2.TabIndex = 6;
            // 
            // chkFechas
            // 
            this.chkFechas.AutoSize = true;
            this.chkFechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFechas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkFechas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.chkFechas.Location = new System.Drawing.Point(60, 42);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(61, 17);
            this.chkFechas.TabIndex = 4;
            this.chkFechas.Text = "Fechas";
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // Fecha1
            // 
            this.Fecha1.Checked = false;
            this.Fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha1.Location = new System.Drawing.Point(127, 40);
            this.Fecha1.Name = "Fecha1";
            this.Fecha1.Size = new System.Drawing.Size(89, 20);
            this.Fecha1.TabIndex = 5;
            // 
            // lbCodigo
            // 
            this.lbCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.Location = new System.Drawing.Point(539, 15);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(82, 18);
            this.lbCodigo.TabIndex = 3;
            this.lbCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSubdiario
            // 
            this.cboSubdiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubdiario.FormattingEnabled = true;
            this.cboSubdiario.Location = new System.Drawing.Point(127, 14);
            this.cboSubdiario.Name = "cboSubdiario";
            this.cboSubdiario.Size = new System.Drawing.Size(407, 21);
            this.cboSubdiario.TabIndex = 1;
            this.cboSubdiario.SelectedIndexChanged += new System.EventHandler(this.cboSubdiario_SelectedIndexChanged);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(393, 473);
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
            // perianio
            // 
            this.perianio.DataPropertyName = "perianio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.perianio.DefaultCellStyle = dataGridViewCellStyle2;
            this.perianio.HeaderText = "Perido";
            this.perianio.Name = "perianio";
            this.perianio.ReadOnly = true;
            this.perianio.Width = 40;
            // 
            // perimes
            // 
            this.perimes.DataPropertyName = "perimes";
            this.perimes.HeaderText = "Mes";
            this.perimes.Name = "perimes";
            this.perimes.ReadOnly = true;
            this.perimes.Width = 30;
            // 
            // moduloid
            // 
            this.moduloid.DataPropertyName = "moduloid";
            this.moduloid.HeaderText = "Módulo";
            this.moduloid.Name = "moduloid";
            this.moduloid.ReadOnly = true;
            this.moduloid.Visible = false;
            // 
            // local
            // 
            this.local.DataPropertyName = "local";
            this.local.HeaderText = "Local";
            this.local.Name = "local";
            this.local.ReadOnly = true;
            this.local.Width = 36;
            // 
            // diarioid
            // 
            this.diarioid.DataPropertyName = "diarioid";
            this.diarioid.HeaderText = "diario";
            this.diarioid.Name = "diarioid";
            this.diarioid.ReadOnly = true;
            this.diarioid.Width = 38;
            // 
            // asiento
            // 
            this.asiento.DataPropertyName = "asiento";
            this.asiento.HeaderText = "Asiento";
            this.asiento.Name = "asiento";
            this.asiento.ReadOnly = true;
            this.asiento.Width = 70;
            // 
            // moneda
            // 
            this.moneda.DataPropertyName = "moneda";
            this.moneda.HeaderText = "M";
            this.moneda.Name = "moneda";
            this.moneda.ReadOnly = true;
            this.moneda.Width = 24;
            // 
            // tipooperacion
            // 
            this.tipooperacion.DataPropertyName = "tipooperacion";
            this.tipooperacion.HeaderText = "T.Oper.";
            this.tipooperacion.Name = "tipooperacion";
            this.tipooperacion.ReadOnly = true;
            this.tipooperacion.Width = 40;
            // 
            // fechregistro
            // 
            this.fechregistro.DataPropertyName = "fechregistro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechregistro.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechregistro.HeaderText = "Fecha";
            this.fechregistro.Name = "fechregistro";
            this.fechregistro.ReadOnly = true;
            this.fechregistro.Width = 80;
            // 
            // tipocomprobante
            // 
            this.tipocomprobante.DataPropertyName = "tipocomprobante";
            this.tipocomprobante.HeaderText = "Tipo Comprob";
            this.tipocomprobante.Name = "tipocomprobante";
            this.tipocomprobante.ReadOnly = true;
            this.tipocomprobante.Width = 50;
            // 
            // debesoles
            // 
            this.debesoles.DataPropertyName = "debesoles";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.debesoles.DefaultCellStyle = dataGridViewCellStyle4;
            this.debesoles.HeaderText = "Debe S/.";
            this.debesoles.Name = "debesoles";
            this.debesoles.ReadOnly = true;
            this.debesoles.Width = 75;
            // 
            // habersoles
            // 
            this.habersoles.DataPropertyName = "habersoles";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.habersoles.DefaultCellStyle = dataGridViewCellStyle5;
            this.habersoles.HeaderText = "Haber S/.";
            this.habersoles.Name = "habersoles";
            this.habersoles.ReadOnly = true;
            this.habersoles.Width = 75;
            // 
            // debedolares
            // 
            this.debedolares.DataPropertyName = "debedolares";
            this.debedolares.HeaderText = "Debe US$";
            this.debedolares.Name = "debedolares";
            this.debedolares.ReadOnly = true;
            this.debedolares.Width = 75;
            // 
            // haberdolares
            // 
            this.haberdolares.DataPropertyName = "haberdolares";
            this.haberdolares.HeaderText = "Haber US$";
            this.haberdolares.Name = "haberdolares";
            this.haberdolares.ReadOnly = true;
            this.haberdolares.Width = 75;
            // 
            // glosa
            // 
            this.glosa.DataPropertyName = "glosa";
            this.glosa.HeaderText = "Glosa";
            this.glosa.Name = "glosa";
            this.glosa.ReadOnly = true;
            this.glosa.Width = 240;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Activo";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.Width = 40;
            // 
            // Frm_AyudaComprobantesConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 513);
            this.Controls.Add(this.dgComprobantesConta);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaComprobantesConta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Comprobantes >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaComprobantesConta_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaComprobantesConta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaComprobantesConta_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgComprobantesConta)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgComprobantesConta;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cboTipooperacion;
        internal System.Windows.Forms.CheckBox chktipooperacion;
        internal System.Windows.Forms.CheckBox chktipocomprobante;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.DateTimePicker Fecha2;
        internal System.Windows.Forms.CheckBox chkFechas;
        internal System.Windows.Forms.DateTimePicker Fecha1;
        internal System.Windows.Forms.Label lbCodigo;
        internal System.Windows.Forms.ComboBox cboSubdiario;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn perianio;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloid;
        private System.Windows.Forms.DataGridViewTextBoxColumn local;
        private System.Windows.Forms.DataGridViewTextBoxColumn diarioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipooperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechregistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocomprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn debesoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn habersoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn debedolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn haberdolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}