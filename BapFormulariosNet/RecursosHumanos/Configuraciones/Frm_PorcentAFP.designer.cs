namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    partial class Frm_PorcentAFP
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PorcentAFP));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.btnlog = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAfp = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.spnperiodo = new System.Windows.Forms.NumericUpDown();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.perimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comisionflujo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comisionmixta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comisionfija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaseguro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aporteobli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remmaxaseg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.AutoSize = false;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btnload,
            this.btncerrar,
            this.btnlog,
            this.ToolStripSeparator1});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(627, 31);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "ToolStrip1";
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnmod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 28);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 28);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(26, 28);
            this.btncancelar.Text = "Deshacer";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnload
            // 
            this.btnload.AutoSize = false;
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnload.Image = global::BapFormulariosNet.Properties.Resources.btn_refresh;
            this.btnload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(30, 30);
            this.btnload.Text = "Actualizar";
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(26, 28);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnlog
            // 
            this.btnlog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnlog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btnlog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(26, 28);
            this.btnlog.Text = "toolStripButton1";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 47;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perimes,
            this.mesname,
            this.comisionflujo,
            this.comisionmixta,
            this.comisionfija,
            this.primaseguro,
            this.aporteobli,
            this.remmaxaseg});
            this.Examinar.Location = new System.Drawing.Point(9, 85);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Examinar.ShowRowErrors = false;
            this.Examinar.Size = new System.Drawing.Size(609, 330);
            this.Examinar.TabIndex = 2;
            this.Examinar.SelectionChanged += new System.EventHandler(this.Examinar_SelectionChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cboAfp);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.spnperiodo);
            this.GroupBox1.Location = new System.Drawing.Point(9, 33);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(609, 48);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // cboAfp
            // 
            this.cboAfp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAfp.Enabled = false;
            this.cboAfp.FormattingEnabled = true;
            this.cboAfp.Location = new System.Drawing.Point(228, 17);
            this.cboAfp.Name = "cboAfp";
            this.cboAfp.Size = new System.Drawing.Size(251, 21);
            this.cboAfp.TabIndex = 3;
            this.cboAfp.SelectedIndexChanged += new System.EventHandler(this.cmbafp_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(186, 21);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "A.F.P.";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(41, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Periodo";
            // 
            // spnperiodo
            // 
            this.spnperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnperiodo.Location = new System.Drawing.Point(93, 14);
            this.spnperiodo.Maximum = new decimal(new int[] {
            2090,
            0,
            0,
            0});
            this.spnperiodo.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnperiodo.Name = "spnperiodo";
            this.spnperiodo.Size = new System.Drawing.Size(65, 26);
            this.spnperiodo.TabIndex = 1;
            this.spnperiodo.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnperiodo.ValueChanged += new System.EventHandler(this.spnperiodo_ValueChanged);
            this.spnperiodo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spnperiodo_KeyDown);
            this.spnperiodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spnperiodo_KeyPress);
            // 
            // perimes
            // 
            this.perimes.DataPropertyName = "perimes";
            this.perimes.HeaderText = "Mes";
            this.perimes.Name = "perimes";
            this.perimes.ReadOnly = true;
            this.perimes.Visible = false;
            // 
            // mesname
            // 
            this.mesname.DataPropertyName = "mesname";
            this.mesname.HeaderText = "Mes";
            this.mesname.Name = "mesname";
            this.mesname.ReadOnly = true;
            // 
            // comisionflujo
            // 
            this.comisionflujo.DataPropertyName = "comisionflujo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.comisionflujo.DefaultCellStyle = dataGridViewCellStyle1;
            this.comisionflujo.HeaderText = "Comisión Sobre Flujo Remuneración";
            this.comisionflujo.Name = "comisionflujo";
            this.comisionflujo.ReadOnly = true;
            this.comisionflujo.Width = 75;
            // 
            // comisionmixta
            // 
            this.comisionmixta.DataPropertyName = "comisionmixta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.comisionmixta.DefaultCellStyle = dataGridViewCellStyle2;
            this.comisionmixta.HeaderText = "Comisión Mixta Sobre Flujo";
            this.comisionmixta.Name = "comisionmixta";
            this.comisionmixta.ReadOnly = true;
            this.comisionmixta.Width = 75;
            // 
            // comisionfija
            // 
            this.comisionfija.DataPropertyName = "comisionfija";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.comisionfija.DefaultCellStyle = dataGridViewCellStyle3;
            this.comisionfija.HeaderText = "Comisión Mixta Sobre Saldo";
            this.comisionfija.Name = "comisionfija";
            this.comisionfija.ReadOnly = true;
            this.comisionfija.Width = 75;
            // 
            // primaseguro
            // 
            this.primaseguro.DataPropertyName = "primaseguro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.primaseguro.DefaultCellStyle = dataGridViewCellStyle4;
            this.primaseguro.HeaderText = "Prima de Seguros";
            this.primaseguro.Name = "primaseguro";
            this.primaseguro.ReadOnly = true;
            this.primaseguro.Width = 75;
            // 
            // aporteobli
            // 
            this.aporteobli.DataPropertyName = "aporteobli";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.aporteobli.DefaultCellStyle = dataGridViewCellStyle5;
            this.aporteobli.HeaderText = "% Aporte Obligatorio";
            this.aporteobli.Name = "aporteobli";
            this.aporteobli.ReadOnly = true;
            this.aporteobli.Width = 75;
            // 
            // remmaxaseg
            // 
            this.remmaxaseg.DataPropertyName = "remmaxaseg";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.remmaxaseg.DefaultCellStyle = dataGridViewCellStyle6;
            this.remmaxaseg.HeaderText = "Remuneración Máxima Asegurable";
            this.remmaxaseg.Name = "remmaxaseg";
            this.remmaxaseg.ReadOnly = true;
            this.remmaxaseg.Width = 90;
            // 
            // Frm_PorcentAFP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 424);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_PorcentAFP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Porcentajes A.F.P.";
            this.Activated += new System.EventHandler(this.Frm_PorcentAFP_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_PorcentAFP_FormClosing);
            this.Load += new System.EventHandler(this.Frm_PorcentAFP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_PorcentAFP_KeyDown);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolbar;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cboAfp;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown spnperiodo;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ToolStripButton btnlog;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesname;
        private System.Windows.Forms.DataGridViewTextBoxColumn comisionflujo;
        private System.Windows.Forms.DataGridViewTextBoxColumn comisionmixta;
        private System.Windows.Forms.DataGridViewTextBoxColumn comisionfija;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaseguro;
        private System.Windows.Forms.DataGridViewTextBoxColumn aporteobli;
        private System.Windows.Forms.DataGridViewTextBoxColumn remmaxaseg;
    }
}