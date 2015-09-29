namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaRubrocompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaRubrocompra));
            this.GridExaminar = new System.Windows.Forms.DataGridView();
            this.rubroid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.chkDescripcion = new System.Windows.Forms.CheckBox();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.chkRubro = new System.Windows.Forms.CheckBox();
            this.chkCuenta = new System.Windows.Forms.CheckBox();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rbBaja = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.rbTitulo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridExaminar
            // 
            this.GridExaminar.AllowUserToAddRows = false;
            this.GridExaminar.AllowUserToDeleteRows = false;
            this.GridExaminar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridExaminar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridExaminar.ColumnHeadersHeight = 30;
            this.GridExaminar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rubroid,
            this.rubroname,
            this.cuentaid,
            this.cuentaname,
            this.Status});
            this.GridExaminar.Location = new System.Drawing.Point(6, 71);
            this.GridExaminar.MultiSelect = false;
            this.GridExaminar.Name = "GridExaminar";
            this.GridExaminar.ReadOnly = true;
            this.GridExaminar.RowHeadersVisible = false;
            this.GridExaminar.RowHeadersWidth = 34;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridExaminar.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GridExaminar.RowTemplate.Height = 20;
            this.GridExaminar.ShowRowErrors = false;
            this.GridExaminar.Size = new System.Drawing.Size(866, 379);
            this.GridExaminar.TabIndex = 1;
            this.GridExaminar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridExaminar_CellContentDoubleClick);
            this.GridExaminar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridExaminar_CellDoubleClick);
            this.GridExaminar.SelectionChanged += new System.EventHandler(this.GridExaminar_SelectionChanged);
            this.GridExaminar.Paint += new System.Windows.Forms.PaintEventHandler(this.GridExaminar_Paint);
            this.GridExaminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridExaminar_KeyDown);
            // 
            // rubroid
            // 
            this.rubroid.DataPropertyName = "rubroid";
            this.rubroid.HeaderText = "Rubro";
            this.rubroid.Name = "rubroid";
            this.rubroid.ReadOnly = true;
            this.rubroid.Width = 70;
            // 
            // rubroname
            // 
            this.rubroname.DataPropertyName = "rubroname";
            this.rubroname.HeaderText = "Descripción";
            this.rubroname.Name = "rubroname";
            this.rubroname.ReadOnly = true;
            this.rubroname.Width = 350;
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
            this.cuentaname.HeaderText = "Nomenclatura de la Cuenta";
            this.cuentaname.Name = "cuentaname";
            this.cuentaname.ReadOnly = true;
            this.cuentaname.Width = 350;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            this.Status.Width = 56;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtDescripcion);
            this.GroupBox2.Controls.Add(this.chkDescripcion);
            this.GroupBox2.Controls.Add(this.txtRubro);
            this.GroupBox2.Controls.Add(this.chkRubro);
            this.GroupBox2.Controls.Add(this.chkCuenta);
            this.GroupBox2.Controls.Add(this.txtCuenta);
            this.GroupBox2.Controls.Add(this.btnBuscar);
            this.GroupBox2.Location = new System.Drawing.Point(7, 2);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(865, 65);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Búsqueda";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(168, 38);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(319, 21);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // chkDescripcion
            // 
            this.chkDescripcion.AutoSize = true;
            this.chkDescripcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDescripcion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkDescripcion.Location = new System.Drawing.Point(62, 41);
            this.chkDescripcion.Name = "chkDescripcion";
            this.chkDescripcion.Size = new System.Drawing.Size(99, 17);
            this.chkDescripcion.TabIndex = 4;
            this.chkDescripcion.Text = "Por Descripción";
            this.chkDescripcion.UseVisualStyleBackColor = true;
            this.chkDescripcion.CheckedChanged += new System.EventHandler(this.chkDescripcion_CheckedChanged);
            // 
            // txtRubro
            // 
            this.txtRubro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRubro.Location = new System.Drawing.Point(417, 16);
            this.txtRubro.MaxLength = 4;
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(70, 21);
            this.txtRubro.TabIndex = 3;
            this.txtRubro.TextChanged += new System.EventHandler(this.txtRubro_TextChanged);
            // 
            // chkRubro
            // 
            this.chkRubro.AutoSize = true;
            this.chkRubro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRubro.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkRubro.Location = new System.Drawing.Point(333, 18);
            this.chkRubro.Name = "chkRubro";
            this.chkRubro.Size = new System.Drawing.Size(74, 17);
            this.chkRubro.TabIndex = 2;
            this.chkRubro.Text = "Por Rubro";
            this.chkRubro.UseVisualStyleBackColor = true;
            this.chkRubro.CheckedChanged += new System.EventHandler(this.chkRubro_CheckedChanged);
            // 
            // chkCuenta
            // 
            this.chkCuenta.AutoSize = true;
            this.chkCuenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCuenta.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkCuenta.Location = new System.Drawing.Point(81, 18);
            this.chkCuenta.Name = "chkCuenta";
            this.chkCuenta.Size = new System.Drawing.Size(80, 17);
            this.chkCuenta.TabIndex = 0;
            this.chkCuenta.Text = "Por Cuenta";
            this.chkCuenta.UseVisualStyleBackColor = true;
            this.chkCuenta.CheckedChanged += new System.EventHandler(this.chkCuenta_CheckedChanged);
            // 
            // txtCuenta
            // 
            this.txtCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCuenta.Location = new System.Drawing.Point(168, 16);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(70, 21);
            this.txtCuenta.TabIndex = 1;
            this.txtCuenta.TextChanged += new System.EventHandler(this.txtCuenta_TextChanged);
            // 
            // btnBuscar
            // 
            //this.btnBuscar.Image = global::BapFormulariosNet.Properties.Resources.btn_refresh24;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(604, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 32);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "&Refrescar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(344, 447);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 2;
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
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rbBaja);
            this.GroupBox5.Controls.Add(this.rbActivo);
            this.GroupBox5.Controls.Add(this.rbTitulo);
            this.GroupBox5.Location = new System.Drawing.Point(8, 452);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(213, 34);
            this.GroupBox5.TabIndex = 3;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Estado";
            // 
            // rbBaja
            // 
            this.rbBaja.AutoSize = true;
            this.rbBaja.ForeColor = System.Drawing.Color.Red;
            this.rbBaja.Location = new System.Drawing.Point(151, 12);
            this.rbBaja.Name = "rbBaja";
            this.rbBaja.Size = new System.Drawing.Size(46, 17);
            this.rbBaja.TabIndex = 2;
            this.rbBaja.TabStop = true;
            this.rbBaja.Text = "Baja";
            this.rbBaja.UseVisualStyleBackColor = true;
            this.rbBaja.CheckedChanged += new System.EventHandler(this.rbBaja_CheckedChanged);
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.ForeColor = System.Drawing.Color.Black;
            this.rbActivo.Location = new System.Drawing.Point(84, 12);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(55, 17);
            this.rbActivo.TabIndex = 1;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            this.rbActivo.CheckedChanged += new System.EventHandler(this.rbActivo_CheckedChanged);
            // 
            // rbTitulo
            // 
            this.rbTitulo.AutoSize = true;
            this.rbTitulo.Enabled = false;
            this.rbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTitulo.ForeColor = System.Drawing.Color.Black;
            this.rbTitulo.Location = new System.Drawing.Point(12, 12);
            this.rbTitulo.Name = "rbTitulo";
            this.rbTitulo.Size = new System.Drawing.Size(59, 17);
            this.rbTitulo.TabIndex = 0;
            this.rbTitulo.TabStop = true;
            this.rbTitulo.Text = "Título";
            this.rbTitulo.UseVisualStyleBackColor = true;
            this.rbTitulo.CheckedChanged += new System.EventHandler(this.rbTitulo_CheckedChanged);
            // 
            // Frm_AyudaRubrocompra
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 490);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GridExaminar);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaRubrocompra";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda Rubro de Compra >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaRubrocompra_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaRubrocompra_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaRubrocompra_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView GridExaminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtRubro;
        internal System.Windows.Forms.CheckBox chkRubro;
        internal System.Windows.Forms.CheckBox chkCuenta;
        internal System.Windows.Forms.TextBox txtCuenta;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton rbBaja;
        internal System.Windows.Forms.RadioButton rbActivo;
        internal System.Windows.Forms.RadioButton rbTitulo;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.CheckBox chkDescripcion;
    }
}