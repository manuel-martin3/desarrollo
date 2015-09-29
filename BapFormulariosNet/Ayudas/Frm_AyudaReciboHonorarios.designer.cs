namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaReciboHonorarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaReciboHonorarios));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chknumdoc = new System.Windows.Forms.CheckBox();
            this.txtnumdoc = new System.Windows.Forms.TextBox();
            this.chkregmes = new System.Windows.Forms.CheckBox();
            this.txtregmes = new System.Windows.Forms.TextBox();
            this.fechafin = new System.Windows.Forms.DateTimePicker();
            this.chkfechas = new System.Windows.Forms.CheckBox();
            this.fechaini = new System.Windows.Forms.DateTimePicker();
            this.chkdetalle = new System.Windows.Forms.CheckBox();
            this.txtdcuentamayor = new System.Windows.Forms.TextBox();
            this.txtdetalle = new System.Windows.Forms.TextBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.chkglosa = new System.Windows.Forms.CheckBox();
            this.txtglosa = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.LNLANULADOS = new System.Windows.Forms.Label();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes_reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRO_REG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_EMISION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETALLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dmoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Glosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chknumdoc);
            this.GroupBox1.Controls.Add(this.txtnumdoc);
            this.GroupBox1.Controls.Add(this.chkregmes);
            this.GroupBox1.Controls.Add(this.txtregmes);
            this.GroupBox1.Controls.Add(this.fechafin);
            this.GroupBox1.Controls.Add(this.chkfechas);
            this.GroupBox1.Controls.Add(this.fechaini);
            this.GroupBox1.Controls.Add(this.chkdetalle);
            this.GroupBox1.Controls.Add(this.txtdcuentamayor);
            this.GroupBox1.Controls.Add(this.txtdetalle);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.chkglosa);
            this.GroupBox1.Controls.Add(this.txtglosa);
            this.GroupBox1.Location = new System.Drawing.Point(8, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1023, 106);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // chknumdoc
            // 
            this.chknumdoc.AutoSize = true;
            this.chknumdoc.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chknumdoc.Location = new System.Drawing.Point(173, 58);
            this.chknumdoc.Name = "chknumdoc";
            this.chknumdoc.Size = new System.Drawing.Size(121, 17);
            this.chknumdoc.TabIndex = 8;
            this.chknumdoc.Text = "Número Documento";
            this.chknumdoc.UseVisualStyleBackColor = true;
            this.chknumdoc.CheckedChanged += new System.EventHandler(this.chknumdoc_CheckedChanged);
            // 
            // txtnumdoc
            // 
            this.txtnumdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnumdoc.Location = new System.Drawing.Point(301, 56);
            this.txtnumdoc.MaxLength = 14;
            this.txtnumdoc.Name = "txtnumdoc";
            this.txtnumdoc.Size = new System.Drawing.Size(103, 20);
            this.txtnumdoc.TabIndex = 9;
            // 
            // chkregmes
            // 
            this.chkregmes.AutoSize = true;
            this.chkregmes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkregmes.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkregmes.Location = new System.Drawing.Point(67, 58);
            this.chkregmes.Name = "chkregmes";
            this.chkregmes.Size = new System.Drawing.Size(46, 17);
            this.chkregmes.TabIndex = 6;
            this.chkregmes.Text = "Mes";
            this.chkregmes.UseVisualStyleBackColor = true;
            this.chkregmes.CheckedChanged += new System.EventHandler(this.chkregmes_CheckedChanged);
            // 
            // txtregmes
            // 
            this.txtregmes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtregmes.Location = new System.Drawing.Point(127, 56);
            this.txtregmes.MaxLength = 2;
            this.txtregmes.Name = "txtregmes";
            this.txtregmes.Size = new System.Drawing.Size(30, 20);
            this.txtregmes.TabIndex = 7;
            // 
            // fechafin
            // 
            this.fechafin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechafin.Location = new System.Drawing.Point(223, 10);
            this.fechafin.Name = "fechafin";
            this.fechafin.Size = new System.Drawing.Size(83, 20);
            this.fechafin.TabIndex = 2;
            // 
            // chkfechas
            // 
            this.chkfechas.AutoSize = true;
            this.chkfechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkfechas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkfechas.Location = new System.Drawing.Point(52, 12);
            this.chkfechas.Name = "chkfechas";
            this.chkfechas.Size = new System.Drawing.Size(61, 17);
            this.chkfechas.TabIndex = 0;
            this.chkfechas.Text = "Fechas";
            this.chkfechas.UseVisualStyleBackColor = true;
            this.chkfechas.CheckedChanged += new System.EventHandler(this.chkfechas_CheckedChanged);
            // 
            // fechaini
            // 
            this.fechaini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaini.Location = new System.Drawing.Point(127, 10);
            this.fechaini.Name = "fechaini";
            this.fechaini.Size = new System.Drawing.Size(83, 20);
            this.fechaini.TabIndex = 1;
            // 
            // chkdetalle
            // 
            this.chkdetalle.AutoSize = true;
            this.chkdetalle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdetalle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkdetalle.Location = new System.Drawing.Point(36, 35);
            this.chkdetalle.Name = "chkdetalle";
            this.chkdetalle.Size = new System.Drawing.Size(77, 17);
            this.chkdetalle.TabIndex = 3;
            this.chkdetalle.Text = "RUC - Cód";
            this.chkdetalle.UseVisualStyleBackColor = true;
            this.chkdetalle.CheckedChanged += new System.EventHandler(this.chkdetalle_CheckedChanged);
            // 
            // txtdcuentamayor
            // 
            this.txtdcuentamayor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdcuentamayor.Location = new System.Drawing.Point(220, 33);
            this.txtdcuentamayor.Name = "txtdcuentamayor";
            this.txtdcuentamayor.Size = new System.Drawing.Size(344, 20);
            this.txtdcuentamayor.TabIndex = 5;
            // 
            // txtdetalle
            // 
            this.txtdetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdetalle.Location = new System.Drawing.Point(127, 33);
            this.txtdetalle.MaxLength = 11;
            this.txtdetalle.Name = "txtdetalle";
            this.txtdetalle.Size = new System.Drawing.Size(90, 20);
            this.txtdetalle.TabIndex = 4;
            this.txtdetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdetalle_KeyDown);
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa24;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(909, 60);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(86, 36);
            this.btnrefrescar.TabIndex = 12;
            this.btnrefrescar.Text = "Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // chkglosa
            // 
            this.chkglosa.AutoSize = true;
            this.chkglosa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkglosa.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkglosa.Location = new System.Drawing.Point(60, 81);
            this.chkglosa.Name = "chkglosa";
            this.chkglosa.Size = new System.Drawing.Size(53, 17);
            this.chkglosa.TabIndex = 10;
            this.chkglosa.Text = "Glosa";
            this.chkglosa.UseVisualStyleBackColor = true;
            this.chkglosa.CheckedChanged += new System.EventHandler(this.chkglosa_CheckedChanged);
            // 
            // txtglosa
            // 
            this.txtglosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtglosa.Location = new System.Drawing.Point(127, 79);
            this.txtglosa.Name = "txtglosa";
            this.txtglosa.Size = new System.Drawing.Size(436, 20);
            this.txtglosa.TabIndex = 11;
            this.txtglosa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtglosa_KeyDown);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(97, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 28);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Cancelar  ";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnSalir);
            this.GroupBox4.Controls.Add(this.btnSeleccionar);
            this.GroupBox4.Location = new System.Drawing.Point(404, 427);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(190, 43);
            this.GroupBox4.TabIndex = 2;
            this.GroupBox4.TabStop = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(5, 10);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(88, 28);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "&Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // LNLANULADOS
            // 
            this.LNLANULADOS.AutoSize = true;
            this.LNLANULADOS.BackColor = System.Drawing.Color.Crimson;
            this.LNLANULADOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNLANULADOS.ForeColor = System.Drawing.Color.White;
            this.LNLANULADOS.Location = new System.Drawing.Point(8, 433);
            this.LNLANULADOS.Name = "LNLANULADOS";
            this.LNLANULADOS.Size = new System.Drawing.Size(46, 13);
            this.LNLANULADOS.TabIndex = 3;
            this.LNLANULADOS.Text = "Recibos";
            this.LNLANULADOS.Visible = false;
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeColumns = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            this.dgProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgProveedor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.mes_reg,
            this.NRO_REG,
            this.registro,
            this.fecha,
            this.F_EMISION,
            this.documento,
            this.DETALLE,
            this.NOMBRE,
            this.dmoneda,
            this.Importe,
            this.Retencion,
            this.Neto,
            this.Glosa});
            this.dgProveedor.Location = new System.Drawing.Point(8, 114);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            this.dgProveedor.RowHeadersWidth = 18;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgProveedor.Size = new System.Drawing.Size(1023, 314);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_ColumnHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.Frozen = true;
            this.status.HeaderText = "ST";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.Width = 30;
            // 
            // mes_reg
            // 
            this.mes_reg.DataPropertyName = "mes_reg";
            this.mes_reg.Frozen = true;
            this.mes_reg.HeaderText = "mes_reg";
            this.mes_reg.Name = "mes_reg";
            this.mes_reg.ReadOnly = true;
            this.mes_reg.Visible = false;
            // 
            // NRO_REG
            // 
            this.NRO_REG.DataPropertyName = "NRO_REG";
            this.NRO_REG.Frozen = true;
            this.NRO_REG.HeaderText = "NRO_REG";
            this.NRO_REG.Name = "NRO_REG";
            this.NRO_REG.ReadOnly = true;
            this.NRO_REG.Visible = false;
            // 
            // registro
            // 
            this.registro.DataPropertyName = "registro";
            this.registro.Frozen = true;
            this.registro.HeaderText = "Registro";
            this.registro.Name = "registro";
            this.registro.ReadOnly = true;
            this.registro.Width = 140;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fecha";
            this.fecha.Frozen = true;
            this.fecha.HeaderText = "F.Registro";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 65;
            // 
            // F_EMISION
            // 
            this.F_EMISION.DataPropertyName = "F_EMISION";
            this.F_EMISION.Frozen = true;
            this.F_EMISION.HeaderText = "F.Emisión";
            this.F_EMISION.Name = "F_EMISION";
            this.F_EMISION.ReadOnly = true;
            this.F_EMISION.Width = 65;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "documento";
            this.documento.Frozen = true;
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            this.documento.Width = 140;
            // 
            // DETALLE
            // 
            this.DETALLE.DataPropertyName = "DETALLE";
            this.DETALLE.Frozen = true;
            this.DETALLE.HeaderText = "Detalle";
            this.DETALLE.Name = "DETALLE";
            this.DETALLE.ReadOnly = true;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE";
            this.NOMBRE.Frozen = true;
            this.NOMBRE.HeaderText = "Nombre / Razón Social";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 200;
            // 
            // dmoneda
            // 
            this.dmoneda.DataPropertyName = "dmoneda";
            this.dmoneda.Frozen = true;
            this.dmoneda.HeaderText = "MND";
            this.dmoneda.Name = "dmoneda";
            this.dmoneda.ReadOnly = true;
            this.dmoneda.Width = 35;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.Importe.DefaultCellStyle = dataGridViewCellStyle1;
            this.Importe.Frozen = true;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 75;
            // 
            // Retencion
            // 
            this.Retencion.DataPropertyName = "Retencion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Retencion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Retencion.Frozen = true;
            this.Retencion.HeaderText = "Retención";
            this.Retencion.Name = "Retencion";
            this.Retencion.ReadOnly = true;
            this.Retencion.Width = 75;
            // 
            // Neto
            // 
            this.Neto.DataPropertyName = "Neto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Neto.DefaultCellStyle = dataGridViewCellStyle3;
            this.Neto.Frozen = true;
            this.Neto.HeaderText = "Neto";
            this.Neto.Name = "Neto";
            this.Neto.ReadOnly = true;
            this.Neto.Width = 75;
            // 
            // Glosa
            // 
            this.Glosa.DataPropertyName = "glosa";
            this.Glosa.HeaderText = "Glosa";
            this.Glosa.Name = "Glosa";
            this.Glosa.ReadOnly = true;
            this.Glosa.Width = 350;
            // 
            // Frm_AyudaReciboHonorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 472);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.LNLANULADOS);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaReciboHonorarios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<<Ayuda - Recibo Honorarios>>";
            this.Activated += new System.EventHandler(this.Frm_AyudaReciboHonorarios_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaReciboHonorarios_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chknumdoc;
        internal System.Windows.Forms.TextBox txtnumdoc;
        internal System.Windows.Forms.CheckBox chkregmes;
        internal System.Windows.Forms.TextBox txtregmes;
        internal System.Windows.Forms.DateTimePicker fechafin;
        internal System.Windows.Forms.CheckBox chkfechas;
        internal System.Windows.Forms.DateTimePicker fechaini;
        internal System.Windows.Forms.CheckBox chkdetalle;
        internal System.Windows.Forms.TextBox txtdcuentamayor;
        internal System.Windows.Forms.TextBox txtdetalle;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.CheckBox chkglosa;
        internal System.Windows.Forms.TextBox txtglosa;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnSeleccionar;
        internal System.Windows.Forms.Label LNLANULADOS;
        internal System.Windows.Forms.DataGridView dgProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes_reg;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRO_REG;
        private System.Windows.Forms.DataGridViewTextBoxColumn registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_EMISION;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETALLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dmoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Glosa;
    }
}