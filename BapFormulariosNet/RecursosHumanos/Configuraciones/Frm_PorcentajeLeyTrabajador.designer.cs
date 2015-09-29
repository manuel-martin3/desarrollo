namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    partial class Frm_PorcentajeLeyTrabajador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PorcentajeLeyTrabajador));
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.perianio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onpt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.essalude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senatie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sctre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.btbLog = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.spnperiodo = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.toolbar.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).BeginInit();
            this.SuspendLayout();
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 30;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perianio,
            this.perimes,
            this.mesname,
            this.onpt,
            this.essalude,
            this.senatie,
            this.sctre});
            this.Examinar.Location = new System.Drawing.Point(11, 75);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Examinar.ShowRowErrors = false;
            this.Examinar.Size = new System.Drawing.Size(455, 314);
            this.Examinar.TabIndex = 2;
            this.Examinar.SelectionChanged += new System.EventHandler(this.Examinar_SelectionChanged);
            // 
            // perianio
            // 
            this.perianio.DataPropertyName = "perianio";
            this.perianio.HeaderText = "Año";
            this.perianio.Name = "perianio";
            this.perianio.ReadOnly = true;
            this.perianio.Visible = false;
            // 
            // perimes
            // 
            this.perimes.DataPropertyName = "perimes";
            this.perimes.HeaderText = "Perimes";
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
            // onpt
            // 
            this.onpt.DataPropertyName = "onpt";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.onpt.DefaultCellStyle = dataGridViewCellStyle1;
            this.onpt.HeaderText = "% ONP";
            this.onpt.Name = "onpt";
            this.onpt.ReadOnly = true;
            this.onpt.Width = 75;
            // 
            // essalude
            // 
            this.essalude.DataPropertyName = "essalude";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.essalude.DefaultCellStyle = dataGridViewCellStyle2;
            this.essalude.HeaderText = "% ESSALUD";
            this.essalude.Name = "essalude";
            this.essalude.ReadOnly = true;
            this.essalude.Width = 75;
            // 
            // senatie
            // 
            this.senatie.DataPropertyName = "senatie";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.senatie.DefaultCellStyle = dataGridViewCellStyle3;
            this.senatie.HeaderText = "% SENATI";
            this.senatie.Name = "senatie";
            this.senatie.ReadOnly = true;
            this.senatie.Width = 85;
            // 
            // sctre
            // 
            this.sctre.DataPropertyName = "sctre";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.sctre.DefaultCellStyle = dataGridViewCellStyle4;
            this.sctre.HeaderText = "% SCTR";
            this.sctre.Name = "sctre";
            this.sctre.ReadOnly = true;
            this.sctre.Width = 75;
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
            this.btbLog,
            this.ToolStripSeparator1});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(478, 31);
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
            // btbLog
            // 
            this.btbLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btbLog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btbLog.Name = "btbLog";
            this.btbLog.Size = new System.Drawing.Size(26, 28);
            this.btbLog.Text = "Log";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.spnperiodo);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Location = new System.Drawing.Point(10, 28);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(457, 44);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // spnperiodo
            // 
            this.spnperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnperiodo.Location = new System.Drawing.Point(211, 12);
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
            this.spnperiodo.Size = new System.Drawing.Size(62, 26);
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
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(155, 19);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Periodo";
            // 
            // Frm_PorcentajeLeyTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 401);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_PorcentajeLeyTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Porcentaje Leyes - Trabajador / Empleador";
            this.Activated += new System.EventHandler(this.Frm_PorcentajeLeyTrabajador_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_PorcentajeLeyTrabajador_FormClosing);
            this.Load += new System.EventHandler(this.Frm_PorcentajeLeyTrabajador_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_PorcentajeLeyTrabajador_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.ToolStrip toolbar;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ToolStripButton btbLog;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.NumericUpDown spnperiodo;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn perianio;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesname;
        private System.Windows.Forms.DataGridViewTextBoxColumn onpt;
        private System.Windows.Forms.DataGridViewTextBoxColumn essalude;
        private System.Windows.Forms.DataGridViewTextBoxColumn senatie;
        private System.Windows.Forms.DataGridViewTextBoxColumn sctre;
    }
}