namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaTipoSubdiario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaTipoSubdiario));
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.diarioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diarioname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contabilidad = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TESORERIA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cuentaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            this.dgProveedor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgProveedor.ColumnHeadersHeight = 24;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diarioid,
            this.sigla,
            this.diarioname,
            this.contabilidad,
            this.TESORERIA,
            this.cuentaid,
            this.cuentaname});
            this.dgProveedor.Location = new System.Drawing.Point(8, 59);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            this.dgProveedor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProveedor.RowHeadersWidth = 34;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(896, 335);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // diarioid
            // 
            this.diarioid.DataPropertyName = "diarioid";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diarioid.DefaultCellStyle = dataGridViewCellStyle1;
            this.diarioid.HeaderText = "Código";
            this.diarioid.Name = "diarioid";
            this.diarioid.ReadOnly = true;
            this.diarioid.Width = 60;
            // 
            // sigla
            // 
            this.sigla.DataPropertyName = "sigla";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sigla.DefaultCellStyle = dataGridViewCellStyle2;
            this.sigla.HeaderText = "Sigla";
            this.sigla.Name = "sigla";
            this.sigla.ReadOnly = true;
            this.sigla.Width = 50;
            // 
            // diarioname
            // 
            this.diarioname.DataPropertyName = "diarioname";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diarioname.DefaultCellStyle = dataGridViewCellStyle3;
            this.diarioname.HeaderText = "Descripción";
            this.diarioname.Name = "diarioname";
            this.diarioname.ReadOnly = true;
            this.diarioname.Width = 320;
            // 
            // contabilidad
            // 
            this.contabilidad.DataPropertyName = "contabilidad";
            this.contabilidad.FillWeight = 45F;
            this.contabilidad.HeaderText = "Contab.";
            this.contabilidad.Name = "contabilidad";
            this.contabilidad.ReadOnly = true;
            this.contabilidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.contabilidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.contabilidad.Width = 45;
            // 
            // TESORERIA
            // 
            this.TESORERIA.DataPropertyName = "tesoreria";
            this.TESORERIA.HeaderText = "Tesor.";
            this.TESORERIA.Name = "TESORERIA";
            this.TESORERIA.ReadOnly = true;
            this.TESORERIA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TESORERIA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TESORERIA.Width = 45;
            // 
            // cuentaid
            // 
            this.cuentaid.DataPropertyName = "cuentaid";
            this.cuentaid.HeaderText = "Cuenta";
            this.cuentaid.Name = "cuentaid";
            this.cuentaid.ReadOnly = true;
            this.cuentaid.Width = 70;
            // 
            // cuentaname
            // 
            this.cuentaname.DataPropertyName = "cuentaname";
            this.cuentaname.HeaderText = "Descripción Cuenta";
            this.cuentaname.Name = "cuentaname";
            this.cuentaname.ReadOnly = true;
            this.cuentaname.Width = 250;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cboFiltro);
            this.GroupBox1.Controls.Add(this.Label22);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Location = new System.Drawing.Point(7, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(648, 51);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Código",
            "Descripcción"});
            this.cboFiltro.Location = new System.Drawing.Point(73, 17);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(90, 21);
            this.cboFiltro.TabIndex = 1;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label22.Location = new System.Drawing.Point(8, 21);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(61, 13);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Buscar por:";
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(547, 13);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(90, 29);
            this.btnrefrescar.TabIndex = 3;
            this.btnrefrescar.Text = "Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(169, 17);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(337, 20);
            this.txtdescripcion.TabIndex = 2;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCerrar);
            this.groupBox2.Controls.Add(this.btnSeleccion);
            this.groupBox2.Location = new System.Drawing.Point(363, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 40);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
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
            // Frm_AyudaTipoSubdiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 434);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaTipoSubdiario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda - Sub Diarios >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaTipoSubdiario_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaTipoSubdiario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaTipoSubdiario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn diarioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigla;
        private System.Windows.Forms.DataGridViewTextBoxColumn diarioname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn contabilidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TESORERIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaname;
        internal System.Windows.Forms.ComboBox cboFiltro;
        internal System.Windows.Forms.Label Label22;
    }
}