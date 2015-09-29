namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaCellAllCcostoPlla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaCellAllCcostoPlla));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbempresa = new System.Windows.Forms.ComboBox();
            this.chkempresa = new System.Windows.Forms.CheckBox();
            this.chkdescripcion = new System.Windows.Forms.CheckBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.txtpla = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.brnSeleccionar = new System.Windows.Forms.Button();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.empresaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosanalitica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cmbempresa);
            this.GroupBox1.Controls.Add(this.chkempresa);
            this.GroupBox1.Controls.Add(this.chkdescripcion);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.txtpla);
            this.GroupBox1.Location = new System.Drawing.Point(9, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(623, 78);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = " Filtros ";
            // 
            // cmbempresa
            // 
            this.cmbempresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbempresa.FormattingEnabled = true;
            this.cmbempresa.Location = new System.Drawing.Point(103, 20);
            this.cmbempresa.Name = "cmbempresa";
            this.cmbempresa.Size = new System.Drawing.Size(414, 21);
            this.cmbempresa.TabIndex = 1;
            this.cmbempresa.SelectedIndexChanged += new System.EventHandler(this.cmbempresa_SelectedIndexChanged);
            // 
            // chkempresa
            // 
            this.chkempresa.AutoSize = true;
            this.chkempresa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkempresa.Checked = true;
            this.chkempresa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkempresa.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkempresa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkempresa.Location = new System.Drawing.Point(26, 22);
            this.chkempresa.Name = "chkempresa";
            this.chkempresa.Size = new System.Drawing.Size(67, 17);
            this.chkempresa.TabIndex = 0;
            this.chkempresa.Text = "Empresa";
            this.chkempresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkempresa.UseVisualStyleBackColor = true;
            this.chkempresa.CheckedChanged += new System.EventHandler(this.chkempresa_CheckedChanged);
            // 
            // chkdescripcion
            // 
            this.chkdescripcion.AutoSize = true;
            this.chkdescripcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkdescripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.Location = new System.Drawing.Point(11, 48);
            this.chkdescripcion.Name = "chkdescripcion";
            this.chkdescripcion.Size = new System.Drawing.Size(82, 17);
            this.chkdescripcion.TabIndex = 2;
            this.chkdescripcion.Text = "Descripción";
            this.chkdescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.UseVisualStyleBackColor = true;
            this.chkdescripcion.CheckedChanged += new System.EventHandler(this.chkdescripcion_CheckedChanged);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(103, 46);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(414, 20);
            this.txtdescripcion.TabIndex = 3;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.btn_search20;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(528, 24);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(84, 36);
            this.btnrefrescar.TabIndex = 5;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // txtpla
            // 
            this.txtpla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpla.Location = new System.Drawing.Point(474, 46);
            this.txtpla.Name = "txtpla";
            this.txtpla.Size = new System.Drawing.Size(42, 20);
            this.txtpla.TabIndex = 4;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnSalir);
            this.GroupBox3.Controls.Add(this.brnSeleccionar);
            this.GroupBox3.Location = new System.Drawing.Point(228, 444);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(189, 41);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(96, 11);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 25);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Cancelar   ";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // brnSeleccionar
            // 
            this.brnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.brnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brnSeleccionar.Location = new System.Drawing.Point(5, 11);
            this.brnSeleccionar.Name = "brnSeleccionar";
            this.brnSeleccionar.Size = new System.Drawing.Size(88, 25);
            this.brnSeleccionar.TabIndex = 0;
            this.brnSeleccionar.Text = "&Seleccionar";
            this.brnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brnSeleccionar.UseVisualStyleBackColor = true;
            this.brnSeleccionar.Click += new System.EventHandler(this.brnSeleccionar_Click);
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            this.dgProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProveedor.ColumnHeadersHeight = 32;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seleccionar,
            this.empresaid,
            this.cencosid,
            this.cencosname,
            this.cencosanalitica});
            this.dgProveedor.Location = new System.Drawing.Point(9, 87);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProveedor.RowHeadersWidth = 24;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(623, 358);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // seleccionar
            // 
            this.seleccionar.DataPropertyName = "seleccionar";
            this.seleccionar.HeaderText = "Sel.";
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.ReadOnly = true;
            this.seleccionar.Width = 55;
            // 
            // empresaid
            // 
            this.empresaid.DataPropertyName = "empresaid";
            this.empresaid.HeaderText = "Empresa";
            this.empresaid.Name = "empresaid";
            this.empresaid.ReadOnly = true;
            this.empresaid.Visible = false;
            // 
            // cencosid
            // 
            this.cencosid.DataPropertyName = "cencosid";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cencosid.HeaderText = "C.Costo";
            this.cencosid.Name = "cencosid";
            this.cencosid.ReadOnly = true;
            this.cencosid.Width = 70;
            // 
            // cencosname
            // 
            this.cencosname.DataPropertyName = "cencosname";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosname.DefaultCellStyle = dataGridViewCellStyle3;
            this.cencosname.HeaderText = "Descripción";
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Width = 450;
            // 
            // cencosanalitica
            // 
            this.cencosanalitica.DataPropertyName = "cencosanalitica";
            this.cencosanalitica.HeaderText = "cencosanalitica";
            this.cencosanalitica.Name = "cencosanalitica";
            this.cencosanalitica.ReadOnly = true;
            this.cencosanalitica.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblRegistros.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblRegistros.Location = new System.Drawing.Point(12, 457);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(193, 13);
            this.lblRegistros.TabIndex = 10;
            this.lblRegistros.Text = "Registros";
            // 
            // Frm_AyudaCellAllCcostoPlla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 489);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_AyudaCellAllCcostoPlla";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Centro de Costo";
            this.Activated += new System.EventHandler(this.Frm_AyudaCellAllCcostoPlla_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaCellAllCcostoPlla_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaCellAllCcostoPlla_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtpla;
        internal System.Windows.Forms.ComboBox cmbempresa;
        internal System.Windows.Forms.CheckBox chkempresa;
        internal System.Windows.Forms.CheckBox chkdescripcion;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button brnSeleccionar;
        internal System.Windows.Forms.DataGridView dgProveedor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosanalitica;
        internal System.Windows.Forms.Label lblRegistros;
    }
}