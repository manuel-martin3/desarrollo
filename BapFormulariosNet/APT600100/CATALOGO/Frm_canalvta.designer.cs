namespace BapFormulariosNet.APT600100.CATALOGO
{
    partial class Frm_canalvta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_canalvta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_busqueda = new DevExpress.XtraEditors.SimpleButton();
            this.dgb_canalvta = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkapto = new System.Windows.Forms.CheckBox();
            this.dtpdigitos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtcanalvtaid = new System.Windows.Forms.TextBox();
            this.txtcanalvtaname = new System.Windows.Forms.TextBox();
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
            this.canalventaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canalventaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digitos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_apt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_canalvta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpdigitos)).BeginInit();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_busqueda);
            this.groupBox2.Controls.Add(this.dgb_canalvta);
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
            // 
            // dgb_canalvta
            // 
            this.dgb_canalvta.AllowUserToAddRows = false;
            this.dgb_canalvta.AllowUserToDeleteRows = false;
            this.dgb_canalvta.AllowUserToResizeColumns = false;
            this.dgb_canalvta.AllowUserToResizeRows = false;
            this.dgb_canalvta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgb_canalvta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgb_canalvta.ColumnHeadersHeight = 20;
            this.dgb_canalvta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.canalventaid,
            this.canalventaname,
            this.digitos,
            this.chk_apt});
            this.dgb_canalvta.Location = new System.Drawing.Point(10, 46);
            this.dgb_canalvta.MultiSelect = false;
            this.dgb_canalvta.Name = "dgb_canalvta";
            this.dgb_canalvta.RowHeadersVisible = false;
            this.dgb_canalvta.RowHeadersWidth = 10;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgb_canalvta.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgb_canalvta.RowTemplate.Height = 20;
            this.dgb_canalvta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgb_canalvta.Size = new System.Drawing.Size(422, 202);
            this.dgb_canalvta.TabIndex = 19;
            this.dgb_canalvta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridestado_CellClick);
            this.dgb_canalvta.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridestado_CellEnter);
            this.dgb_canalvta.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridestado_CellLeave);
            this.dgb_canalvta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridestado_KeyUp);
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
            this.label11.Size = new System.Drawing.Size(123, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Canal Venta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkapto);
            this.groupBox1.Controls.Add(this.dtpdigitos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtcanalvtaid);
            this.groupBox1.Controls.Add(this.txtcanalvtaname);
            this.groupBox1.Location = new System.Drawing.Point(5, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 98);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "»» Datos";
            // 
            // chkapto
            // 
            this.chkapto.AutoSize = true;
            this.chkapto.Location = new System.Drawing.Point(261, 65);
            this.chkapto.Name = "chkapto";
            this.chkapto.Size = new System.Drawing.Size(49, 17);
            this.chkapto.TabIndex = 116;
            this.chkapto.Text = "Apto";
            this.chkapto.UseVisualStyleBackColor = true;
            // 
            // dtpdigitos
            // 
            this.dtpdigitos.Location = new System.Drawing.Point(87, 61);
            this.dtpdigitos.Name = "dtpdigitos";
            this.dtpdigitos.Size = new System.Drawing.Size(40, 21);
            this.dtpdigitos.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(43, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Digitos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Canal.Vta";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(42, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Codigo";
            // 
            // txtcanalvtaid
            // 
            this.txtcanalvtaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcanalvtaid.Location = new System.Drawing.Point(87, 17);
            this.txtcanalvtaid.MaxLength = 3;
            this.txtcanalvtaid.Name = "txtcanalvtaid";
            this.txtcanalvtaid.Size = new System.Drawing.Size(27, 20);
            this.txtcanalvtaid.TabIndex = 11;
            this.txtcanalvtaid.Text = "000";
            this.txtcanalvtaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtcanalvtaname
            // 
            this.txtcanalvtaname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcanalvtaname.Location = new System.Drawing.Point(87, 38);
            this.txtcanalvtaname.Name = "txtcanalvtaname";
            this.txtcanalvtaname.Size = new System.Drawing.Size(341, 21);
            this.txtcanalvtaname.TabIndex = 12;
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
            // canalventaid
            // 
            this.canalventaid.DataPropertyName = "canalventaid";
            this.canalventaid.HeaderText = "Codigo";
            this.canalventaid.Name = "canalventaid";
            this.canalventaid.Width = 60;
            // 
            // canalventaname
            // 
            this.canalventaname.DataPropertyName = "canalventaname";
            this.canalventaname.HeaderText = "Canal_Venta";
            this.canalventaname.Name = "canalventaname";
            this.canalventaname.Width = 150;
            // 
            // digitos
            // 
            this.digitos.DataPropertyName = "digitos";
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.digitos.DefaultCellStyle = dataGridViewCellStyle11;
            this.digitos.HeaderText = "Digitos";
            this.digitos.Name = "digitos";
            this.digitos.Width = 50;
            // 
            // chk_apt
            // 
            this.chk_apt.DataPropertyName = "chk_apt";
            this.chk_apt.HeaderText = "Apt";
            this.chk_apt.Name = "chk_apt";
            this.chk_apt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chk_apt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chk_apt.Width = 50;
            // 
            // Frm_canalvta
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
            this.Name = "Frm_canalvta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Canal de Venta";
            this.Load += new System.EventHandler(this.Frm_estado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_estado_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_canalvta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpdigitos)).EndInit();
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
        internal System.Windows.Forms.TextBox txtcanalvtaname;
        internal System.Windows.Forms.DataGridView dgb_canalvta;
        internal System.Windows.Forms.TextBox txtcanalvtaid;
        private System.Windows.Forms.ToolStripButton btn_clave;
        internal System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkapto;
        private System.Windows.Forms.NumericUpDown dtpdigitos;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btn_busqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn canalventaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn canalventaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn digitos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk_apt;

    }
}