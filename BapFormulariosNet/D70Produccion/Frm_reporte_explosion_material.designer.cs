namespace BapFormulariosNet.D70Produccion
{
    partial class Frm_reporte_explosion_material
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_explosion_material));
            this.serop_fin = new System.Windows.Forms.MaskedTextBox();
            this.serop_ini = new System.Windows.Forms.MaskedTextBox();
            this.almacaccionid = new System.Windows.Forms.ComboBox();
            this.fechdocfin = new System.Windows.Forms.DateTimePicker();
            this.fechdocini = new System.Windows.Forms.DateTimePicker();
            this.numop_fin = new System.Windows.Forms.TextBox();
            this.numop_ini = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.localdes = new System.Windows.Forms.ComboBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbo_moduloides = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serop_fin
            // 
            this.serop_fin.AsciiOnly = true;
            this.serop_fin.Location = new System.Drawing.Point(114, 85);
            this.serop_fin.Mask = "000L";
            this.serop_fin.Name = "serop_fin";
            this.serop_fin.Size = new System.Drawing.Size(38, 21);
            this.serop_fin.TabIndex = 75;
            this.serop_fin.Visible = false;
            this.serop_fin.TextChanged += new System.EventHandler(this.serop_fin_TextChanged);
            // 
            // serop_ini
            // 
            this.serop_ini.AsciiOnly = true;
            this.serop_ini.Location = new System.Drawing.Point(114, 62);
            this.serop_ini.Mask = "000L";
            this.serop_ini.Name = "serop_ini";
            this.serop_ini.Size = new System.Drawing.Size(38, 21);
            this.serop_ini.TabIndex = 74;
            this.serop_ini.TextChanged += new System.EventHandler(this.serop_ini_TextChanged);
            this.serop_ini.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serop_ini_KeyDown);
            // 
            // almacaccionid
            // 
            this.almacaccionid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.almacaccionid.DropDownWidth = 250;
            this.almacaccionid.Location = new System.Drawing.Point(114, 38);
            this.almacaccionid.Name = "almacaccionid";
            this.almacaccionid.Size = new System.Drawing.Size(117, 21);
            this.almacaccionid.TabIndex = 9;
            this.almacaccionid.Visible = false;
            // 
            // fechdocfin
            // 
            this.fechdocfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocfin.Location = new System.Drawing.Point(259, 114);
            this.fechdocfin.Name = "fechdocfin";
            this.fechdocfin.Size = new System.Drawing.Size(80, 20);
            this.fechdocfin.TabIndex = 27;
            this.fechdocfin.Visible = false;
            // 
            // fechdocini
            // 
            this.fechdocini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocini.Location = new System.Drawing.Point(114, 114);
            this.fechdocini.Name = "fechdocini";
            this.fechdocini.Size = new System.Drawing.Size(80, 20);
            this.fechdocini.TabIndex = 26;
            this.fechdocini.Visible = false;
            // 
            // numop_fin
            // 
            this.numop_fin.Location = new System.Drawing.Point(154, 85);
            this.numop_fin.MaxLength = 10;
            this.numop_fin.Name = "numop_fin";
            this.numop_fin.Size = new System.Drawing.Size(167, 21);
            this.numop_fin.TabIndex = 13;
            this.numop_fin.Visible = false;
            this.numop_fin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numop_fin_KeyDown);
            this.numop_fin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numop_fin_KeyPress);
            // 
            // numop_ini
            // 
            this.numop_ini.Location = new System.Drawing.Point(154, 62);
            this.numop_ini.MaxLength = 10;
            this.numop_ini.Name = "numop_ini";
            this.numop_ini.Size = new System.Drawing.Size(167, 21);
            this.numop_ini.TabIndex = 11;
            this.numop_ini.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numop_ini_KeyDown);
            this.numop_ini.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numop_ini_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 56);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(116, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(222, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "Explosión de Materiales";
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
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
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
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_cancelar,
            this.toolStripSeparator1,
            this.btn_imprimir,
            this.btn_excel,
            this.toolStripSeparator2,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(584, 29);
            this.Botonera.TabIndex = 1;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_excel
            // 
            this.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_excel.Image = global::BapFormulariosNet.Properties.Resources.btn_excel20;
            this.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(26, 26);
            this.btn_excel.Text = "toolStripButton1";
            this.btn_excel.ToolTipText = "Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(36, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "» TIPO MOV:";
            this.labelControl1.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.localdes);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cbo_moduloides);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.serop_fin);
            this.panelControl1.Controls.Add(this.fechdocfin);
            this.panelControl1.Controls.Add(this.serop_ini);
            this.panelControl1.Controls.Add(this.almacaccionid);
            this.panelControl1.Controls.Add(this.numop_ini);
            this.panelControl1.Controls.Add(this.numop_fin);
            this.panelControl1.Controls.Add(this.fechdocini);
            this.panelControl1.Location = new System.Drawing.Point(0, 69);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(581, 144);
            this.panelControl1.TabIndex = 10;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(356, 18);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 83;
            this.labelControl7.Text = "» LOCAL:";
            this.labelControl7.Visible = false;
            // 
            // localdes
            // 
            this.localdes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localdes.DropDownWidth = 170;
            this.localdes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localdes.FormattingEnabled = true;
            this.localdes.Location = new System.Drawing.Point(407, 15);
            this.localdes.Name = "localdes";
            this.localdes.Size = new System.Drawing.Size(144, 21);
            this.localdes.TabIndex = 82;
            this.localdes.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Location = new System.Drawing.Point(205, 118);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 13);
            this.labelControl6.TabIndex = 81;
            this.labelControl6.Text = "» HASTA:";
            this.labelControl6.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(56, 117);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 80;
            this.labelControl5.Text = "» DESDE:";
            this.labelControl5.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(27, 89);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(78, 13);
            this.labelControl4.TabIndex = 79;
            this.labelControl4.Text = "» OP - HASTA:";
            this.labelControl4.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(30, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 78;
            this.labelControl3.Text = "» OP - DESDE:";
            // 
            // cbo_moduloides
            // 
            this.cbo_moduloides.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_moduloides.DropDownWidth = 250;
            this.cbo_moduloides.Location = new System.Drawing.Point(114, 15);
            this.cbo_moduloides.Name = "cbo_moduloides";
            this.cbo_moduloides.Size = new System.Drawing.Size(229, 21);
            this.cbo_moduloides.TabIndex = 77;
            this.cbo_moduloides.Visible = false;
            this.cbo_moduloides.SelectedIndexChanged += new System.EventHandler(this.cbo_moduloides_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(39, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 76;
            this.labelControl2.Text = "» ALMACEN:";
            this.labelControl2.Visible = false;
            // 
            // Frm_reporte_explosion_material
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 217);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_explosion_material";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explosión de Materiales";
            this.Load += new System.EventHandler(this.Frm_reporte_mov_ordprod_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_reporte_explosion_material_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox numop_ini;
        internal System.Windows.Forms.TextBox numop_fin;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_excel;
        internal System.Windows.Forms.DateTimePicker fechdocfin;
        internal System.Windows.Forms.DateTimePicker fechdocini;
        internal System.Windows.Forms.ComboBox almacaccionid;
        private System.Windows.Forms.MaskedTextBox serop_fin;
        private System.Windows.Forms.MaskedTextBox serop_ini;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        internal System.Windows.Forms.ComboBox cbo_moduloides;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        internal System.Windows.Forms.ComboBox localdes;
        private DevExpress.XtraEditors.LabelControl labelControl7;

    }
}