namespace BapFormulariosNet.MERCADERIA
{
    partial class Frm_reporte_mov_docsemitido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_mov_docsemitido));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioListBox1 = new System.Windows.Forms.RadioListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mottrasladointname = new System.Windows.Forms.TextBox();
            this.mottrasladointid = new System.Windows.Forms.TextBox();
            this.serdoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tipodoc = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fechdocfin = new System.Windows.Forms.DateTimePicker();
            this.fechdocini = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctactename = new System.Windows.Forms.TextBox();
            this.ctacte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_buscar = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioListBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mottrasladointname);
            this.groupBox1.Controls.Add(this.mottrasladointid);
            this.groupBox1.Controls.Add(this.serdoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tipodoc);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.fechdocfin);
            this.groupBox1.Controls.Add(this.fechdocini);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ctactename);
            this.groupBox1.Controls.Add(this.ctacte);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 181);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // radioListBox1
            // 
            this.radioListBox1.BackColor = System.Drawing.Color.Transparent;
            this.radioListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.radioListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.radioListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioListBox1.FormattingEnabled = true;
            this.radioListBox1.ItemHeight = 16;
            this.radioListBox1.Location = new System.Drawing.Point(119, 104);
            this.radioListBox1.Name = "radioListBox1";
            this.radioListBox1.Size = new System.Drawing.Size(144, 32);
            this.radioListBox1.TabIndex = 9;
            this.radioListBox1.SelectedIndexChanged += new System.EventHandler(this.radioListBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Modo de Cálculo:";
            // 
            // mottrasladointname
            // 
            this.mottrasladointname.Location = new System.Drawing.Point(169, 54);
            this.mottrasladointname.MaxLength = 10;
            this.mottrasladointname.Name = "mottrasladointname";
            this.mottrasladointname.Size = new System.Drawing.Size(270, 21);
            this.mottrasladointname.TabIndex = 9;
            this.mottrasladointname.Text = "ventas al exterior";
            // 
            // mottrasladointid
            // 
            this.mottrasladointid.Location = new System.Drawing.Point(120, 54);
            this.mottrasladointid.MaxLength = 4;
            this.mottrasladointid.Name = "mottrasladointid";
            this.mottrasladointid.Size = new System.Drawing.Size(48, 21);
            this.mottrasladointid.TabIndex = 8;
            this.mottrasladointid.Text = "ventas al exterior";
            this.mottrasladointid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mottrasladointid_KeyDown);
            // 
            // serdoc
            // 
            this.serdoc.Location = new System.Drawing.Point(391, 19);
            this.serdoc.MaxLength = 4;
            this.serdoc.Name = "serdoc";
            this.serdoc.Size = new System.Drawing.Size(48, 21);
            this.serdoc.TabIndex = 7;
            this.serdoc.Text = "ventas al exterior";
            this.serdoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serdoc_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Serie Doc:";
            // 
            // tipodoc
            // 
            this.tipodoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipodoc.Location = new System.Drawing.Point(121, 19);
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.Size = new System.Drawing.Size(191, 21);
            this.tipodoc.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Tipo Doc:";
            // 
            // fechdocfin
            // 
            this.fechdocfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocfin.Location = new System.Drawing.Point(256, 144);
            this.fechdocfin.Name = "fechdocfin";
            this.fechdocfin.Size = new System.Drawing.Size(80, 20);
            this.fechdocfin.TabIndex = 13;
            // 
            // fechdocini
            // 
            this.fechdocini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdocini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdocini.Location = new System.Drawing.Point(88, 143);
            this.fechdocini.Name = "fechdocini";
            this.fechdocini.Size = new System.Drawing.Size(80, 20);
            this.fechdocini.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(206, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Desde:";
            // 
            // ctactename
            // 
            this.ctactename.Location = new System.Drawing.Point(169, 76);
            this.ctactename.MaxLength = 10;
            this.ctactename.Name = "ctactename";
            this.ctactename.Size = new System.Drawing.Size(270, 21);
            this.ctactename.TabIndex = 11;
            this.ctactename.Text = "ventas al exterior";
            // 
            // ctacte
            // 
            this.ctacte.Location = new System.Drawing.Point(120, 76);
            this.ctacte.MaxLength = 4;
            this.ctacte.Name = "ctacte";
            this.ctacte.Size = new System.Drawing.Size(48, 21);
            this.ctacte.TabIndex = 10;
            this.ctacte.Text = "ventas al exterior";
            this.ctacte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctacte_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Provee/Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Motivo interno:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 36);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(478, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "DOCUMENTOS EMITIDOS";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // btn_buscar
            // 
            this.btn_buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(26, 26);
            this.btn_buscar.Text = "toolStripButton15";
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
            this.btn_buscar,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(473, 29);
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
            // 
            // Frm_reporte_mov_docsemitido
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(473, 252);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_mov_docsemitido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos  emitidos";
            this.Load += new System.EventHandler(this.Frm_reporte_mov_docsemitido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_reporte_mov_docsemitido_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox ctactename;
        internal System.Windows.Forms.TextBox ctacte;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_buscar;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_excel;
        internal System.Windows.Forms.DateTimePicker fechdocfin;
        internal System.Windows.Forms.DateTimePicker fechdocini;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox tipodoc;
        internal System.Windows.Forms.TextBox serdoc;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox mottrasladointname;
        internal System.Windows.Forms.TextBox mottrasladointid;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioListBox radioListBox1;

    }
}