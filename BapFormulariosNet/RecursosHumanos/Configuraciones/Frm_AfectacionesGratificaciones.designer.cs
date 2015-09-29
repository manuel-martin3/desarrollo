namespace BapFormulariosNet.RecursosHumanos.Configuraciones
{
    partial class Frm_AfectacionesGratificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AfectacionesGratificaciones));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btneliminar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.btnNuevaFila = new System.Windows.Forms.Button();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.spnperiodo = new System.Windows.Forms.NumericUpDown();
            this.cmbtipoplanilla = new System.Windows.Forms.ComboBox();
            this.cboMesIni = new System.Windows.Forms.ComboBox();
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
            this.toolbar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btneliminar,
            this.btnload,
            this.btncerrar,
            this.btnLog,
            this.ToolStripSeparator1});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(474, 33);
            this.toolbar.TabIndex = 12;
            this.toolbar.Text = "ToolStrip1";
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnmod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 30);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 30);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(26, 30);
            this.btncancelar.Text = "Deshacer";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btneliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar;
            this.btneliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(26, 30);
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
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
            this.btncerrar.Size = new System.Drawing.Size(26, 30);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnLog
            // 
            this.btnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(26, 30);
            this.btnLog.Text = "Log";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.btnEliminarFila);
            this.GroupBox6.Controls.Add(this.btnNuevaFila);
            this.GroupBox6.Location = new System.Drawing.Point(11, 479);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(191, 45);
            this.GroupBox6.TabIndex = 15;
            this.GroupBox6.TabStop = false;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.Image = global::BapFormulariosNet.Properties.Resources.btn_del20;
            this.btnEliminarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarFila.Location = new System.Drawing.Point(97, 10);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(88, 29);
            this.btnEliminarFila.TabIndex = 1;
            this.btnEliminarFila.Text = "&Borrar Fila";
            this.btnEliminarFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarFila.UseVisualStyleBackColor = true;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // btnNuevaFila
            // 
            this.btnNuevaFila.Image = global::BapFormulariosNet.Properties.Resources.btn_add20;
            this.btnNuevaFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaFila.Location = new System.Drawing.Point(6, 10);
            this.btnNuevaFila.Name = "btnNuevaFila";
            this.btnNuevaFila.Size = new System.Drawing.Size(88, 29);
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
            this.Examinar.Location = new System.Drawing.Point(11, 130);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Examinar.ShowRowErrors = false;
            this.Examinar.Size = new System.Drawing.Size(452, 351);
            this.Examinar.TabIndex = 14;
            this.Examinar.SelectionChanged += new System.EventHandler(this.Examinar_SelectionChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.spnperiodo);
            this.GroupBox1.Controls.Add(this.cmbtipoplanilla);
            this.GroupBox1.Controls.Add(this.cboMesIni);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(11, 30);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(453, 97);
            this.GroupBox1.TabIndex = 13;
            this.GroupBox1.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(33, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Periodo";
            // 
            // spnperiodo
            // 
            this.spnperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnperiodo.Location = new System.Drawing.Point(83, 13);
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
            this.spnperiodo.Size = new System.Drawing.Size(67, 26);
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
            // cmbtipoplanilla
            // 
            this.cmbtipoplanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoplanilla.Enabled = false;
            this.cmbtipoplanilla.FormattingEnabled = true;
            this.cmbtipoplanilla.Location = new System.Drawing.Point(83, 68);
            this.cmbtipoplanilla.Name = "cmbtipoplanilla";
            this.cmbtipoplanilla.Size = new System.Drawing.Size(273, 21);
            this.cmbtipoplanilla.TabIndex = 5;
            this.cmbtipoplanilla.SelectedIndexChanged += new System.EventHandler(this.cmbtipoplanilla_SelectedIndexChanged);
            // 
            // cboMesIni
            // 
            this.cboMesIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesIni.FormattingEnabled = true;
            this.cboMesIni.Location = new System.Drawing.Point(83, 43);
            this.cboMesIni.Name = "cboMesIni";
            this.cboMesIni.Size = new System.Drawing.Size(208, 21);
            this.cboMesIni.TabIndex = 3;
            this.cboMesIni.SelectedIndexChanged += new System.EventHandler(this.cboMesIni_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(12, 72);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Tipo Planilla";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(49, 47);
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
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.afecto.DefaultCellStyle = dataGridViewCellStyle1;
            this.afecto.HeaderText = "afecto";
            this.afecto.Name = "afecto";
            this.afecto.ReadOnly = true;
            this.afecto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.afecto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.afecto.Width = 75;
            // 
            // Frm_AfectacionesGratificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 527);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_AfectacionesGratificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Afectaciones de Gratificaciones";
            this.Activated += new System.EventHandler(this.Frm_AfectacionesGratificaciones_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AfectacionesGratificaciones_FormClosing);
            this.Load += new System.EventHandler(this.Frm_AfectacionesGratificaciones_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AfectacionesGratificaciones_KeyDown);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolbar;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btneliminar;
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
        internal System.Windows.Forms.ComboBox cmbtipoplanilla;
        internal System.Windows.Forms.ComboBox cboMesIni;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ToolStripButton btnLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn afecto;
    }
}