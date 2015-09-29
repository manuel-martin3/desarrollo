namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    partial class Frm_AfectacionesAFPs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AfectacionesAFPs));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.btnNuevaFila = new System.Windows.Forms.Button();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.spnperiodo = new System.Windows.Forms.NumericUpDown();
            this.cboTipoplanilla = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rubroid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afecto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolbar.SuspendLayout();
            this.GroupBox6.SuspendLayout();
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
            this.toolStripButton1,
            this.ToolStripSeparator1});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(482, 31);
            this.toolbar.TabIndex = 8;
            this.toolbar.Text = "ToolStrip1";
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 28);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 28);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
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
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(30, 30);
            this.btnload.Text = "Actualizar";
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(26, 28);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(26, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.btnEliminarFila);
            this.GroupBox6.Controls.Add(this.btnNuevaFila);
            this.GroupBox6.Location = new System.Drawing.Point(12, 399);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(191, 45);
            this.GroupBox6.TabIndex = 11;
            this.GroupBox6.TabStop = false;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFila.Image = global::BapFormulariosNet.Properties.Resources.btn_del20;
            this.btnEliminarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarFila.Location = new System.Drawing.Point(97, 10);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(86, 29);
            this.btnEliminarFila.TabIndex = 1;
            this.btnEliminarFila.Text = "&Borrar Fila";
            this.btnEliminarFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarFila.UseVisualStyleBackColor = true;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // btnNuevaFila
            // 
            this.btnNuevaFila.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaFila.Image = global::BapFormulariosNet.Properties.Resources.btn_add20;
            this.btnNuevaFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaFila.Location = new System.Drawing.Point(6, 10);
            this.btnNuevaFila.Name = "btnNuevaFila";
            this.btnNuevaFila.Size = new System.Drawing.Size(86, 29);
            this.btnNuevaFila.TabIndex = 0;
            this.btnNuevaFila.Text = "&Nueva Fila";
            this.btnNuevaFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaFila.UseVisualStyleBackColor = true;
            this.btnNuevaFila.Click += new System.EventHandler(this.btnNuevaFila_Click);
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 30;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rubroid,
            this.rubroname,
            this.afecto});
            this.Examinar.Location = new System.Drawing.Point(12, 124);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Examinar.ShowRowErrors = false;
            this.Examinar.Size = new System.Drawing.Size(458, 277);
            this.Examinar.TabIndex = 10;
            this.Examinar.SelectionChanged += new System.EventHandler(this.Examinar_SelectionChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.spnperiodo);
            this.GroupBox1.Controls.Add(this.cboTipoplanilla);
            this.GroupBox1.Controls.Add(this.cboMes);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(12, 29);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(457, 92);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(35, 19);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Periodo";
            // 
            // spnperiodo
            // 
            this.spnperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnperiodo.Location = new System.Drawing.Point(84, 12);
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
            this.spnperiodo.Size = new System.Drawing.Size(68, 26);
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
            // cboTipoplanilla
            // 
            this.cboTipoplanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoplanilla.Enabled = false;
            this.cboTipoplanilla.FormattingEnabled = true;
            this.cboTipoplanilla.Location = new System.Drawing.Point(84, 65);
            this.cboTipoplanilla.Name = "cboTipoplanilla";
            this.cboTipoplanilla.Size = new System.Drawing.Size(267, 21);
            this.cboTipoplanilla.TabIndex = 5;
            this.cboTipoplanilla.SelectedIndexChanged += new System.EventHandler(this.cboTipoplanilla_SelectedIndexChanged);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(84, 41);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(186, 21);
            this.cboMes.TabIndex = 3;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(14, 69);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Tipo Planilla";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(51, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(27, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Mes";
            // 
            // rubroid
            // 
            this.rubroid.DataPropertyName = "rubroid";
            this.rubroid.HeaderText = "rubroid";
            this.rubroid.Name = "rubroid";
            this.rubroid.ReadOnly = true;
            this.rubroid.Visible = false;
            // 
            // rubroname
            // 
            this.rubroname.DataPropertyName = "rubroname";
            this.rubroname.HeaderText = "Rubro";
            this.rubroname.Name = "rubroname";
            this.rubroname.ReadOnly = true;
            this.rubroname.Width = 330;
            // 
            // afecto
            // 
            this.afecto.DataPropertyName = "afecto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.afecto.DefaultCellStyle = dataGridViewCellStyle1;
            this.afecto.HeaderText = "Afecto";
            this.afecto.Name = "afecto";
            this.afecto.ReadOnly = true;
            this.afecto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.afecto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.afecto.Width = 75;
            // 
            // Frm_AfectacionesAFPs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 447);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_AfectacionesAFPs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Afectaciones de AFP";
            this.Activated += new System.EventHandler(this.Frm_AfectacionesAFPs_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AfectacionesAFPs_FormClosing);
            this.Load += new System.EventHandler(this.Frm_AfectacionesAFPs_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AfectacionesAFPs_KeyDown);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
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
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Button btnEliminarFila;
        internal System.Windows.Forms.Button btnNuevaFila;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown spnperiodo;
        internal System.Windows.Forms.ComboBox cboTipoplanilla;
        internal System.Windows.Forms.ComboBox cboMes;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn afecto;
    }
}