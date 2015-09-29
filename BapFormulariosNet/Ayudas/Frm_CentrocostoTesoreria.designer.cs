namespace BapFormulariosNet.Ayudas
{
    partial class Frm_CentrocostoTesoreria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CentrocostoTesoreria));
            this.lblanalitico = new System.Windows.Forms.Label();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.cencosid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosdivi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosanalitica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcuenta = new System.Windows.Forms.TextBox();
            this.chkclasecuenta = new System.Windows.Forms.CheckBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.chkcodigolike = new System.Windows.Forms.CheckBox();
            this.txtcodigolike = new System.Windows.Forms.TextBox();
            this.chkdescriplike = new System.Windows.Forms.CheckBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.rbactivo3 = new System.Windows.Forms.RadioButton();
            this.rbactivo2 = new System.Windows.Forms.RadioButton();
            this.rbactivo1 = new System.Windows.Forms.RadioButton();
            this.txtdescriplike = new System.Windows.Forms.TextBox();
            this.lblregseleccionado = new System.Windows.Forms.Label();
            this.txttotregistrosanaliticos = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblanalitico
            // 
            this.lblanalitico.AutoSize = true;
            this.lblanalitico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblanalitico.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblanalitico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanalitico.ForeColor = System.Drawing.Color.Black;
            this.lblanalitico.Location = new System.Drawing.Point(491, 401);
            this.lblanalitico.Name = "lblanalitico";
            this.lblanalitico.Size = new System.Drawing.Size(113, 13);
            this.lblanalitico.TabIndex = 11;
            this.lblanalitico.Text = "C.COSTO ANALITICO";
            this.lblanalitico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblanalitico.Visible = false;
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            this.dgProveedor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgProveedor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cencosid,
            this.cencosname,
            this.cencosdivi,
            this.cencosanalitica,
            this.status});
            this.dgProveedor.Location = new System.Drawing.Point(9, 104);
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
            this.dgProveedor.RowHeadersWidth = 26;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(598, 297);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellContentDoubleClick);
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_ColumnHeaderMouseClick);
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // cencosid
            // 
            this.cencosid.DataPropertyName = "cencosid";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosid.DefaultCellStyle = dataGridViewCellStyle1;
            this.cencosid.HeaderText = "Código";
            this.cencosid.Name = "cencosid";
            this.cencosid.ReadOnly = true;
            this.cencosid.Width = 80;
            // 
            // cencosname
            // 
            this.cencosname.DataPropertyName = "cencosname";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosname.DefaultCellStyle = dataGridViewCellStyle2;
            this.cencosname.HeaderText = "Descripción";
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Width = 400;
            // 
            // cencosdivi
            // 
            this.cencosdivi.DataPropertyName = "cencosdivi";
            this.cencosdivi.HeaderText = "Cuenta";
            this.cencosdivi.Name = "cencosdivi";
            this.cencosdivi.ReadOnly = true;
            this.cencosdivi.Width = 70;
            // 
            // cencosanalitica
            // 
            this.cencosanalitica.DataPropertyName = "cencosanalitica";
            this.cencosanalitica.HeaderText = "Analítica";
            this.cencosanalitica.Name = "cencosanalitica";
            this.cencosanalitica.ReadOnly = true;
            this.cencosanalitica.Visible = false;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.DefaultCellStyle = dataGridViewCellStyle3;
            this.status.HeaderText = "Estado";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            this.status.Width = 70;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtcuenta);
            this.GroupBox1.Controls.Add(this.chkclasecuenta);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.chkcodigolike);
            this.GroupBox1.Controls.Add(this.txtcodigolike);
            this.GroupBox1.Controls.Add(this.chkdescriplike);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Controls.Add(this.txtdescriplike);
            this.GroupBox1.Location = new System.Drawing.Point(9, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(599, 96);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // txtcuenta
            // 
            this.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcuenta.Location = new System.Drawing.Point(114, 67);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Size = new System.Drawing.Size(80, 20);
            this.txtcuenta.TabIndex = 5;
            // 
            // chkclasecuenta
            // 
            this.chkclasecuenta.AutoSize = true;
            this.chkclasecuenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkclasecuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkclasecuenta.Location = new System.Drawing.Point(19, 69);
            this.chkclasecuenta.Name = "chkclasecuenta";
            this.chkclasecuenta.Size = new System.Drawing.Size(89, 17);
            this.chkclasecuenta.TabIndex = 4;
            this.chkclasecuenta.Text = "Clase Cuenta";
            this.chkclasecuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkclasecuenta.UseVisualStyleBackColor = true;
            this.chkclasecuenta.CheckedChanged += new System.EventHandler(this.chkclasecuenta_CheckedChanged);
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(507, 56);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(84, 30);
            this.btnrefrescar.TabIndex = 6;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // chkcodigolike
            // 
            this.chkcodigolike.AutoSize = true;
            this.chkcodigolike.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcodigolike.Checked = true;
            this.chkcodigolike.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkcodigolike.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcodigolike.Location = new System.Drawing.Point(48, 25);
            this.chkcodigolike.Name = "chkcodigolike";
            this.chkcodigolike.Size = new System.Drawing.Size(60, 17);
            this.chkcodigolike.TabIndex = 0;
            this.chkcodigolike.Text = "Cuenta";
            this.chkcodigolike.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcodigolike.UseVisualStyleBackColor = true;
            this.chkcodigolike.CheckedChanged += new System.EventHandler(this.chkcodigolike_CheckedChanged);
            // 
            // txtcodigolike
            // 
            this.txtcodigolike.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigolike.Location = new System.Drawing.Point(114, 23);
            this.txtcodigolike.Name = "txtcodigolike";
            this.txtcodigolike.Size = new System.Drawing.Size(108, 20);
            this.txtcodigolike.TabIndex = 1;
            this.txtcodigolike.TextChanged += new System.EventHandler(this.txtcodigolike_TextChanged);
            // 
            // chkdescriplike
            // 
            this.chkdescriplike.AutoSize = true;
            this.chkdescriplike.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescriplike.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescriplike.Location = new System.Drawing.Point(26, 47);
            this.chkdescriplike.Name = "chkdescriplike";
            this.chkdescriplike.Size = new System.Drawing.Size(82, 17);
            this.chkdescriplike.TabIndex = 2;
            this.chkdescriplike.Text = "Descripción";
            this.chkdescriplike.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescriplike.UseVisualStyleBackColor = true;
            this.chkdescriplike.CheckedChanged += new System.EventHandler(this.chkdescriplike_CheckedChanged);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.rbactivo3);
            this.GroupBox4.Controls.Add(this.rbactivo2);
            this.GroupBox4.Controls.Add(this.rbactivo1);
            this.GroupBox4.Location = new System.Drawing.Point(381, 7);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(211, 34);
            this.GroupBox4.TabIndex = 4;
            this.GroupBox4.TabStop = false;
            // 
            // rbactivo3
            // 
            this.rbactivo3.AutoSize = true;
            this.rbactivo3.Location = new System.Drawing.Point(135, 11);
            this.rbactivo3.Name = "rbactivo3";
            this.rbactivo3.Size = new System.Drawing.Size(68, 17);
            this.rbactivo3.TabIndex = 2;
            this.rbactivo3.Text = "Inactivos";
            this.rbactivo3.UseVisualStyleBackColor = true;
            // 
            // rbactivo2
            // 
            this.rbactivo2.AutoSize = true;
            this.rbactivo2.Location = new System.Drawing.Point(69, 11);
            this.rbactivo2.Name = "rbactivo2";
            this.rbactivo2.Size = new System.Drawing.Size(60, 17);
            this.rbactivo2.TabIndex = 1;
            this.rbactivo2.Text = "Activos";
            this.rbactivo2.UseVisualStyleBackColor = true;
            // 
            // rbactivo1
            // 
            this.rbactivo1.AutoSize = true;
            this.rbactivo1.Checked = true;
            this.rbactivo1.Location = new System.Drawing.Point(8, 11);
            this.rbactivo1.Name = "rbactivo1";
            this.rbactivo1.Size = new System.Drawing.Size(55, 17);
            this.rbactivo1.TabIndex = 0;
            this.rbactivo1.TabStop = true;
            this.rbactivo1.Text = "Todos";
            this.rbactivo1.UseVisualStyleBackColor = true;
            // 
            // txtdescriplike
            // 
            this.txtdescriplike.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescriplike.Location = new System.Drawing.Point(114, 45);
            this.txtdescriplike.Name = "txtdescriplike";
            this.txtdescriplike.Size = new System.Drawing.Size(337, 20);
            this.txtdescriplike.TabIndex = 3;
            this.txtdescriplike.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescriplike_KeyDown);
            // 
            // lblregseleccionado
            // 
            this.lblregseleccionado.AutoSize = true;
            this.lblregseleccionado.BackColor = System.Drawing.Color.Red;
            this.lblregseleccionado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblregseleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblregseleccionado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblregseleccionado.Location = new System.Drawing.Point(12, 402);
            this.lblregseleccionado.Name = "lblregseleccionado";
            this.lblregseleccionado.Size = new System.Drawing.Size(150, 13);
            this.lblregseleccionado.TabIndex = 9;
            this.lblregseleccionado.Text = "REGISTROS ANULADOS";
            this.lblregseleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblregseleccionado.Visible = false;
            // 
            // txttotregistrosanaliticos
            // 
            this.txttotregistrosanaliticos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttotregistrosanaliticos.Location = new System.Drawing.Point(392, 418);
            this.txttotregistrosanaliticos.Name = "txttotregistrosanaliticos";
            this.txttotregistrosanaliticos.Size = new System.Drawing.Size(80, 20);
            this.txttotregistrosanaliticos.TabIndex = 14;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnCerrar);
            this.GroupBox3.Controls.Add(this.btnSeleccionar);
            this.GroupBox3.Location = new System.Drawing.Point(200, 400);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(187, 41);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cancelar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(5, 10);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // Frm_CentrocostoTesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 444);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.txttotregistrosanaliticos);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.lblregseleccionado);
            this.Controls.Add(this.lblanalitico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CentrocostoTesoreria";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centro de costoTesoreria";
            this.Activated += new System.EventHandler(this.Frm_CentrocostoTesoreria_Activated);
            this.Load += new System.EventHandler(this.Frm_CentrocostoTesoreria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_CentrocostoTesoreria_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblanalitico;
        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtcuenta;
        internal System.Windows.Forms.CheckBox chkclasecuenta;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.CheckBox chkcodigolike;
        internal System.Windows.Forms.TextBox txtcodigolike;
        internal System.Windows.Forms.CheckBox chkdescriplike;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton rbactivo3;
        internal System.Windows.Forms.RadioButton rbactivo2;
        internal System.Windows.Forms.RadioButton rbactivo1;
        internal System.Windows.Forms.TextBox txtdescriplike;
        internal System.Windows.Forms.Label lblregseleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosdivi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosanalitica;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        internal System.Windows.Forms.TextBox txttotregistrosanaliticos;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccionar;
    }
}