namespace BapFormulariosNet.DL0Logistica
{
    partial class Frm_reporte_ordcompra
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
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbomodulo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMesini = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMesfin = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grupoid = new System.Windows.Forms.TextBox();
            this.gruponame = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboReporte = new System.Windows.Forms.ComboBox();
            this.cboanio = new System.Windows.Forms.ComboBox();
            this.chkigv = new System.Windows.Forms.CheckBox();
            this.chkstatus = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cenestado = new System.Windows.Forms.RadioListBox();
            this.productname = new System.Windows.Forms.TextBox();
            this.productid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Botonera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.Botonera.Size = new System.Drawing.Size(518, 29);
            this.Botonera.TabIndex = 2;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 31);
            this.panel1.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(82, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(365, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "LISTADO DE  ORDENES DE PRODUCCIÓN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = " Año:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 91;
            this.label9.Text = "Almacen :";
            // 
            // cbomodulo
            // 
            this.cbomodulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomodulo.DropDownWidth = 250;
            this.cbomodulo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbomodulo.Location = new System.Drawing.Point(80, 16);
            this.cbomodulo.Name = "cbomodulo";
            this.cbomodulo.Size = new System.Drawing.Size(231, 21);
            this.cbomodulo.TabIndex = 88;
            this.cbomodulo.SelectedIndexChanged += new System.EventHandler(this.cbomodulo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = " Mes:";
            // 
            // cboMesini
            // 
            this.cboMesini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesini.FormattingEnabled = true;
            this.cboMesini.Location = new System.Drawing.Point(265, 62);
            this.cboMesini.Name = "cboMesini";
            this.cboMesini.Size = new System.Drawing.Size(100, 21);
            this.cboMesini.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(370, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = " Al:";
            // 
            // cboMesfin
            // 
            this.cboMesfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesfin.FormattingEnabled = true;
            this.cboMesfin.Location = new System.Drawing.Point(397, 62);
            this.cboMesfin.Name = "cboMesfin";
            this.cboMesfin.Size = new System.Drawing.Size(100, 21);
            this.cboMesfin.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Proveedor:";
            // 
            // grupoid
            // 
            this.grupoid.Location = new System.Drawing.Point(80, 85);
            this.grupoid.MaxLength = 4;
            this.grupoid.Name = "grupoid";
            this.grupoid.Size = new System.Drawing.Size(48, 21);
            this.grupoid.TabIndex = 98;
            this.grupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grupoid_KeyDown);
            // 
            // gruponame
            // 
            this.gruponame.Location = new System.Drawing.Point(130, 85);
            this.gruponame.Name = "gruponame";
            this.gruponame.Size = new System.Drawing.Size(250, 21);
            this.gruponame.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Reporte :";
            // 
            // cboReporte
            // 
            this.cboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReporte.DropDownWidth = 250;
            this.cboReporte.Location = new System.Drawing.Point(80, 39);
            this.cboReporte.Name = "cboReporte";
            this.cboReporte.Size = new System.Drawing.Size(337, 21);
            this.cboReporte.TabIndex = 101;
            this.cboReporte.SelectedIndexChanged += new System.EventHandler(this.cboReporte_SelectedIndexChanged);
            this.cboReporte.SelectedValueChanged += new System.EventHandler(this.cboReporte_SelectedValueChanged);
            // 
            // cboanio
            // 
            this.cboanio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboanio.DropDownWidth = 250;
            this.cboanio.Location = new System.Drawing.Point(80, 62);
            this.cboanio.Name = "cboanio";
            this.cboanio.Size = new System.Drawing.Size(142, 21);
            this.cboanio.TabIndex = 102;
            // 
            // chkigv
            // 
            this.chkigv.AutoSize = true;
            this.chkigv.Location = new System.Drawing.Point(80, 133);
            this.chkigv.Name = "chkigv";
            this.chkigv.Size = new System.Drawing.Size(78, 17);
            this.chkigv.TabIndex = 103;
            this.chkigv.Text = " Incluir IGV";
            this.chkigv.UseVisualStyleBackColor = true;
            // 
            // chkstatus
            // 
            this.chkstatus.AutoSize = true;
            this.chkstatus.Location = new System.Drawing.Point(166, 133);
            this.chkstatus.Name = "chkstatus";
            this.chkstatus.Size = new System.Drawing.Size(55, 17);
            this.chkstatus.TabIndex = 104;
            this.chkstatus.Text = "Todos";
            this.chkstatus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.productname);
            this.groupBox1.Controls.Add(this.productid);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cenestado);
            this.groupBox1.Controls.Add(this.chkstatus);
            this.groupBox1.Controls.Add(this.chkigv);
            this.groupBox1.Controls.Add(this.cboanio);
            this.groupBox1.Controls.Add(this.cboReporte);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.gruponame);
            this.groupBox1.Controls.Add(this.grupoid);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboMesfin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboMesini);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbomodulo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(5, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 157);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cenestado
            // 
            this.cenestado.BackColor = System.Drawing.Color.Transparent;
            this.cenestado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cenestado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cenestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cenestado.FormattingEnabled = true;
            this.cenestado.ItemHeight = 16;
            this.cenestado.Location = new System.Drawing.Point(267, 130);
            this.cenestado.Name = "cenestado";
            this.cenestado.Size = new System.Drawing.Size(108, 32);
            this.cenestado.TabIndex = 105;
            this.cenestado.Visible = false;
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(166, 106);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(317, 21);
            this.productname.TabIndex = 108;
            // 
            // productid
            // 
            this.productid.Location = new System.Drawing.Point(79, 106);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(83, 21);
            this.productid.TabIndex = 107;
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Producto:";
            // 
            // Frm_reporte_ordcompra
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 235);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_ordcompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Ordenes de Compra";
            this.Load += new System.EventHandler(this.Frm_reporte_ordcompra_Load);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripButton btn_excel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ComboBox cbomodulo;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMesini;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMesfin;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox grupoid;
        internal System.Windows.Forms.TextBox gruponame;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboReporte;
        internal System.Windows.Forms.ComboBox cboanio;
        private System.Windows.Forms.CheckBox chkigv;
        private System.Windows.Forms.CheckBox chkstatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioListBox cenestado;
        internal System.Windows.Forms.TextBox productname;
        internal System.Windows.Forms.TextBox productid;
        internal System.Windows.Forms.Label label5;
     
    }
}