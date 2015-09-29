namespace BapFormulariosNet.D60Tienda.Administracion
{
    partial class Frm_cargos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_cargos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_busqueda = new DevExpress.XtraEditors.SimpleButton();
            this.dgb_cargos = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_act = new System.Windows.Forms.CheckBox();
            this.cmb_cateplan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtcargoid = new System.Windows.Forms.TextBox();
            this.txtcargoname = new System.Windows.Forms.TextBox();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_log = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.cargoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cateplanid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cateplanname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_cargos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_busqueda);
            this.groupBox2.Controls.Add(this.dgb_cargos);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtbusqueda);
            this.groupBox2.Location = new System.Drawing.Point(5, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 254);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "»» Busqueda";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_busqueda.Appearance.Options.UseFont = true;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Image = ((System.Drawing.Image)(resources.GetObject("btn_busqueda.Image")));
            this.btn_busqueda.Location = new System.Drawing.Point(357, 18);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(73, 22);
            this.btn_busqueda.TabIndex = 115;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // dgb_cargos
            // 
            this.dgb_cargos.AllowUserToAddRows = false;
            this.dgb_cargos.AllowUserToDeleteRows = false;
            this.dgb_cargos.AllowUserToResizeColumns = false;
            this.dgb_cargos.AllowUserToResizeRows = false;
            this.dgb_cargos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgb_cargos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgb_cargos.ColumnHeadersHeight = 20;
            this.dgb_cargos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cargoid,
            this.cargoname,
            this.cateplanid,
            this.cateplanname});
            this.dgb_cargos.Location = new System.Drawing.Point(10, 46);
            this.dgb_cargos.MultiSelect = false;
            this.dgb_cargos.Name = "dgb_cargos";
            this.dgb_cargos.RowHeadersVisible = false;
            this.dgb_cargos.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgb_cargos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgb_cargos.RowTemplate.Height = 20;
            this.dgb_cargos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgb_cargos.Size = new System.Drawing.Size(422, 202);
            this.dgb_cargos.TabIndex = 19;
            this.dgb_cargos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_cargos_CellClick);
            this.dgb_cargos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_cargos_CellEnter);
            this.dgb_cargos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_cargos_CellLeave);
            this.dgb_cargos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgb_cargos_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 114;
            this.label5.Text = "Descripción:";
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbusqueda.Location = new System.Drawing.Point(88, 19);
            this.txtbusqueda.MaxLength = 0;
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(261, 21);
            this.txtbusqueda.TabIndex = 17;
            this.txtbusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_criterio_KeyDown);
            this.txtbusqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbusqueda_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Teal;
            this.label11.Location = new System.Drawing.Point(176, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Cargos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_act);
            this.groupBox1.Controls.Add(this.cmb_cateplan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtcargoid);
            this.groupBox1.Controls.Add(this.txtcargoname);
            this.groupBox1.Location = new System.Drawing.Point(5, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 98);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "»» Datos";
            // 
            // chk_act
            // 
            this.chk_act.AutoSize = true;
            this.chk_act.Location = new System.Drawing.Point(235, 68);
            this.chk_act.Name = "chk_act";
            this.chk_act.Size = new System.Drawing.Size(15, 14);
            this.chk_act.TabIndex = 39;
            this.chk_act.UseVisualStyleBackColor = true;
            this.chk_act.CheckedChanged += new System.EventHandler(this.chk_act_CheckedChanged);
            // 
            // cmb_cateplan
            // 
            this.cmb_cateplan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cateplan.FormattingEnabled = true;
            this.cmb_cateplan.Location = new System.Drawing.Point(86, 64);
            this.cmb_cateplan.Name = "cmb_cateplan";
            this.cmb_cateplan.Size = new System.Drawing.Size(143, 21);
            this.cmb_cateplan.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cat.Planilla";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Cargo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(43, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Codigo";
            // 
            // txtcargoid
            // 
            this.txtcargoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcargoid.Location = new System.Drawing.Point(86, 19);
            this.txtcargoid.MaxLength = 3;
            this.txtcargoid.Name = "txtcargoid";
            this.txtcargoid.Size = new System.Drawing.Size(27, 20);
            this.txtcargoid.TabIndex = 11;
            this.txtcargoid.Text = "000";
            this.txtcargoid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtcargoname
            // 
            this.txtcargoname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcargoname.Location = new System.Drawing.Point(86, 40);
            this.txtcargoname.Name = "txtcargoname";
            this.txtcargoname.Size = new System.Drawing.Size(344, 21);
            this.txtcargoname.TabIndex = 12;
            // 
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_editar,
            this.btn_cancelar,
            this.btn_grabar,
            this.btn_eliminar,
            this.btn_imprimir,
            this.toolStripSeparator1,
            this.btn_clave,
            this.btn_log,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(460, 29);
            this.Botonera.TabIndex = 1;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = global::BapFormulariosNet.Properties.Resources.go_new3;
            this.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_nuevo.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(23, 26);
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.ToolTipText = "Nuevo (Ctrl + N)";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_editar.Image = global::BapFormulariosNet.Properties.Resources.Edit;
            this.btn_editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(26, 26);
            this.btn_editar.Text = "Editar";
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_cancelar.Image = global::BapFormulariosNet.Properties.Resources.go_undo2;
            this.btn_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(24, 26);
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_grabar
            // 
            this.btn_grabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(26, 26);
            this.btn_grabar.Text = "Grabar";
            this.btn_grabar.ToolTipText = "Grabar (Ctrl + G)";
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(26, 26);
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_imprimir.Image = global::BapFormulariosNet.Properties.Resources.dev_printer;
            this.btn_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(26, 26);
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_clave
            // 
            this.btn_clave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            this.btn_clave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clave.Name = "btn_clave";
            this.btn_clave.Size = new System.Drawing.Size(26, 26);
            this.btn_clave.Text = "toolStripButton1";
            this.btn_clave.ToolTipText = "Clave Administrador";
            this.btn_clave.Click += new System.EventHandler(this.btn_clave_Click);
            // 
            // btn_log
            // 
            this.btn_log.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_log.Image = ((System.Drawing.Image)(resources.GetObject("btn_log.Image")));
            this.btn_log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(26, 26);
            this.btn_log.Text = "toolStripButton16";
            this.btn_log.ToolTipText = "Auditoria";
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = global::BapFormulariosNet.Properties.Resources.go_out2;
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 26);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // cargoid
            // 
            this.cargoid.DataPropertyName = "cargoid";
            this.cargoid.HeaderText = "Codigo";
            this.cargoid.Name = "cargoid";
            this.cargoid.Width = 60;
            // 
            // cargoname
            // 
            this.cargoname.DataPropertyName = "cargoname";
            this.cargoname.HeaderText = "Cargo";
            this.cargoname.Name = "cargoname";
            this.cargoname.Width = 200;
            // 
            // cateplanid
            // 
            this.cateplanid.DataPropertyName = "cateplanid";
            dataGridViewCellStyle2.NullValue = null;
            this.cateplanid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cateplanid.HeaderText = "cateplanid";
            this.cateplanid.Name = "cateplanid";
            this.cateplanid.Visible = false;
            this.cateplanid.Width = 50;
            // 
            // cateplanname
            // 
            this.cateplanname.DataPropertyName = "cateplanname";
            this.cateplanname.HeaderText = "Cat.Planilla";
            this.cateplanname.Name = "cateplanname";
            // 
            // Frm_cargos
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(460, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_cargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Cargos";
            this.Load += new System.EventHandler(this.Frm_cargos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_cargos_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_cargos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_editar;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_grabar;
        private System.Windows.Forms.ToolStripButton btn_eliminar;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_log;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtcargoname;
        internal System.Windows.Forms.DataGridView dgb_cargos;
        internal System.Windows.Forms.TextBox txtcargoid;
        private System.Windows.Forms.ToolStripButton btn_clave;
        internal System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btn_busqueda;
        private System.Windows.Forms.ComboBox cmb_cateplan;
        private System.Windows.Forms.CheckBox chk_act;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cateplanid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cateplanname;

    }
}