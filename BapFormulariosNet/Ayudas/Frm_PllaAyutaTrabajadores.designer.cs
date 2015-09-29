namespace BapFormulariosNet.Ayudas
{
    partial class Frm_PllaAyutaTrabajadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PllaAyutaTrabajadores));
            this.lbltotalregistros = new System.Windows.Forms.Label();
            this.lblanulado = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chktipoplanilla = new System.Windows.Forms.CheckBox();
            this.cmbtipoplanilla = new System.Windows.Forms.ComboBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtodos3 = new System.Windows.Forms.RadioButton();
            this.rbtodos2 = new System.Windows.Forms.RadioButton();
            this.rbtodos1 = new System.Windows.Forms.RadioButton();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.chknombre = new System.Windows.Forms.CheckBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.fichaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrelargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situtrabname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipopllaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltotalregistros
            // 
            this.lbltotalregistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltotalregistros.Location = new System.Drawing.Point(567, 478);
            this.lbltotalregistros.Name = "lbltotalregistros";
            this.lbltotalregistros.Size = new System.Drawing.Size(270, 23);
            this.lbltotalregistros.TabIndex = 9;
            // 
            // lblanulado
            // 
            this.lblanulado.AutoSize = true;
            this.lblanulado.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblanulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanulado.ForeColor = System.Drawing.Color.Red;
            this.lblanulado.Location = new System.Drawing.Point(12, 483);
            this.lblanulado.Name = "lblanulado";
            this.lblanulado.Size = new System.Drawing.Size(72, 13);
            this.lblanulado.TabIndex = 7;
            this.lblanulado.Text = "ANULADOS :";
            this.lblanulado.Visible = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccionar);
            this.GroupBox4.Location = new System.Drawing.Point(277, 470);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(188, 42);
            this.GroupBox4.TabIndex = 8;
            this.GroupBox4.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(96, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar  ";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(6, 11);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "&Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fichaid,
            this.nrodni,
            this.nombrelargo,
            this.situtrabname,
            this.activo,
            this.tipopllaname});
            this.dgProveedor.Location = new System.Drawing.Point(10, 82);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProveedor.RowHeadersWidth = 24;
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(830, 391);
            this.dgProveedor.TabIndex = 6;
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_ColumnHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chktipoplanilla);
            this.GroupBox1.Controls.Add(this.cmbtipoplanilla);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.chknombre);
            this.GroupBox1.Controls.Add(this.txtnombre);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Location = new System.Drawing.Point(10, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(830, 74);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            // 
            // chktipoplanilla
            // 
            this.chktipoplanilla.AutoSize = true;
            this.chktipoplanilla.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chktipoplanilla.Location = new System.Drawing.Point(334, 16);
            this.chktipoplanilla.Name = "chktipoplanilla";
            this.chktipoplanilla.Size = new System.Drawing.Size(83, 17);
            this.chktipoplanilla.TabIndex = 3;
            this.chktipoplanilla.TabStop = false;
            this.chktipoplanilla.Text = "Tipo Planilla";
            this.chktipoplanilla.UseVisualStyleBackColor = true;
            this.chktipoplanilla.CheckedChanged += new System.EventHandler(this.chktipoplanilla_CheckedChanged);
            // 
            // cmbtipoplanilla
            // 
            this.cmbtipoplanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoplanilla.Enabled = false;
            this.cmbtipoplanilla.FormattingEnabled = true;
            this.cmbtipoplanilla.Location = new System.Drawing.Point(330, 38);
            this.cmbtipoplanilla.Name = "cmbtipoplanilla";
            this.cmbtipoplanilla.Size = new System.Drawing.Size(226, 21);
            this.cmbtipoplanilla.TabIndex = 4;
            this.cmbtipoplanilla.SelectedIndexChanged += new System.EventHandler(this.cmbtipoplanilla_SelectedIndexChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.rbtodos3);
            this.GroupBox3.Controls.Add(this.rbtodos2);
            this.GroupBox3.Controls.Add(this.rbtodos1);
            this.GroupBox3.Location = new System.Drawing.Point(562, 7);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(257, 32);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            // 
            // rbtodos3
            // 
            this.rbtodos3.AutoSize = true;
            this.rbtodos3.Location = new System.Drawing.Point(181, 10);
            this.rbtodos3.Name = "rbtodos3";
            this.rbtodos3.Size = new System.Drawing.Size(68, 17);
            this.rbtodos3.TabIndex = 2;
            this.rbtodos3.Text = "Inactivos";
            this.rbtodos3.UseVisualStyleBackColor = true;
            this.rbtodos3.CheckedChanged += new System.EventHandler(this.rbtodos3_CheckedChanged);
            // 
            // rbtodos2
            // 
            this.rbtodos2.AutoSize = true;
            this.rbtodos2.Checked = true;
            this.rbtodos2.Location = new System.Drawing.Point(89, 10);
            this.rbtodos2.Name = "rbtodos2";
            this.rbtodos2.Size = new System.Drawing.Size(84, 17);
            this.rbtodos2.TabIndex = 1;
            this.rbtodos2.TabStop = true;
            this.rbtodos2.Text = "Solo Activos";
            this.rbtodos2.UseVisualStyleBackColor = true;
            this.rbtodos2.CheckedChanged += new System.EventHandler(this.rbtodos2_CheckedChanged);
            // 
            // rbtodos1
            // 
            this.rbtodos1.AutoSize = true;
            this.rbtodos1.Location = new System.Drawing.Point(7, 10);
            this.rbtodos1.Name = "rbtodos1";
            this.rbtodos1.Size = new System.Drawing.Size(74, 17);
            this.rbtodos1.TabIndex = 0;
            this.rbtodos1.Text = "Ver Todos";
            this.rbtodos1.UseVisualStyleBackColor = true;
            this.rbtodos1.CheckedChanged += new System.EventHandler(this.rbtodos1_CheckedChanged);
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(723, 42);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(82, 27);
            this.btnrefrescar.TabIndex = 5;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // chknombre
            // 
            this.chknombre.AutoSize = true;
            this.chknombre.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chknombre.Location = new System.Drawing.Point(12, 16);
            this.chknombre.Name = "chknombre";
            this.chknombre.Size = new System.Drawing.Size(159, 17);
            this.chknombre.TabIndex = 0;
            this.chknombre.Text = "Buscar Ocurrencia Nombres";
            this.chknombre.UseVisualStyleBackColor = true;
            this.chknombre.CheckedChanged += new System.EventHandler(this.chknombre_CheckedChanged);
            // 
            // txtnombre
            // 
            this.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombre.Location = new System.Drawing.Point(9, 38);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(300, 20);
            this.txtnombre.TabIndex = 1;
            this.txtnombre.TextChanged += new System.EventHandler(this.txtnombre_TextChanged);
            // 
            // fichaid
            // 
            this.fichaid.DataPropertyName = "fichaid";
            this.fichaid.HeaderText = "Código";
            this.fichaid.Name = "fichaid";
            this.fichaid.ReadOnly = true;
            // 
            // nrodni
            // 
            this.nrodni.DataPropertyName = "nrodni";
            this.nrodni.HeaderText = "Nº DNI";
            this.nrodni.Name = "nrodni";
            this.nrodni.ReadOnly = true;
            // 
            // nombrelargo
            // 
            this.nombrelargo.DataPropertyName = "nombrelargo";
            this.nombrelargo.HeaderText = "Apellidos y Nombres";
            this.nombrelargo.Name = "nombrelargo";
            this.nombrelargo.ReadOnly = true;
            this.nombrelargo.Width = 320;
            // 
            // situtrabname
            // 
            this.situtrabname.DataPropertyName = "situtrabname";
            this.situtrabname.HeaderText = "Estado";
            this.situtrabname.Name = "situtrabname";
            this.situtrabname.ReadOnly = true;
            this.situtrabname.Width = 80;
            // 
            // activo
            // 
            this.activo.DataPropertyName = "activo";
            this.activo.HeaderText = "activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            this.activo.Visible = false;
            // 
            // tipopllaname
            // 
            this.tipopllaname.DataPropertyName = "tipopllaname";
            this.tipopllaname.HeaderText = "Tipo Planilla";
            this.tipopllaname.Name = "tipopllaname";
            this.tipopllaname.ReadOnly = true;
            this.tipopllaname.Width = 180;
            // 
            // Frm_PllaAyutaTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 513);
            this.Controls.Add(this.lbltotalregistros);
            this.Controls.Add(this.lblanulado);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_PllaAyutaTrabajadores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Buscar Trabajadores >>";
            this.Activated += new System.EventHandler(this.Frm_PllaAyutaTrabajadores_Activated);
            this.Load += new System.EventHandler(this.Frm_PllaAyutaTrabajadores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_PllaAyutaTrabajadores_KeyDown);
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbltotalregistros;
        internal System.Windows.Forms.Label lblanulado;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccionar;
        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chktipoplanilla;
        internal System.Windows.Forms.ComboBox cmbtipoplanilla;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.RadioButton rbtodos3;
        internal System.Windows.Forms.RadioButton rbtodos2;
        internal System.Windows.Forms.RadioButton rbtodos1;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.CheckBox chknombre;
        internal System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fichaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodni;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrelargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn situtrabname;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopllaname;
    }
}