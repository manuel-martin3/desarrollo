namespace BapFormulariosNet.DL0Logistica
{
    partial class Frm_reporte_ordemitidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_ordemitidas));
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.CmMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdconsolidado = new System.Windows.Forms.SaveFileDialog();
            this.pnl_01 = new DevExpress.XtraEditors.PanelControl();
            this.gruponame = new System.Windows.Forms.TextBox();
            this.grupoid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboLocal = new System.Windows.Forms.ComboBox();
            this.cboModuloID = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.fechfin = new System.Windows.Forms.DateTimePicker();
            this.fechini = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Botonera.SuspendLayout();
            this.CmMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_01)).BeginInit();
            this.pnl_01.SuspendLayout();
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
            this.Botonera.Size = new System.Drawing.Size(492, 29);
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
            this.btn_excel.Text = "Exportar Excel";
            this.btn_excel.ToolTipText = "Exportar Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
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
            // CmMenuGrid
            // 
            this.CmMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarExcelToolStripMenuItem});
            this.CmMenuGrid.Name = "CmMenuGrid";
            this.CmMenuGrid.Size = new System.Drawing.Size(147, 26);
            // 
            // exportarExcelToolStripMenuItem
            // 
            this.exportarExcelToolStripMenuItem.Name = "exportarExcelToolStripMenuItem";
            this.exportarExcelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportarExcelToolStripMenuItem.Text = "Exportar Excel";
            // 
            // sfdconsolidado
            // 
            this.sfdconsolidado.Filter = "Archivos Excel | *.xls";
            // 
            // pnl_01
            // 
            this.pnl_01.Appearance.BackColor = System.Drawing.Color.Teal;
            this.pnl_01.Appearance.ForeColor = System.Drawing.Color.White;
            this.pnl_01.Appearance.Options.UseBackColor = true;
            this.pnl_01.Appearance.Options.UseForeColor = true;
            this.pnl_01.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnl_01.Controls.Add(this.gruponame);
            this.pnl_01.Controls.Add(this.grupoid);
            this.pnl_01.Controls.Add(this.label6);
            this.pnl_01.Controls.Add(this.label13);
            this.pnl_01.Controls.Add(this.cboLocal);
            this.pnl_01.Controls.Add(this.cboModuloID);
            this.pnl_01.Controls.Add(this.label14);
            this.pnl_01.Controls.Add(this.fechfin);
            this.pnl_01.Controls.Add(this.fechini);
            this.pnl_01.Controls.Add(this.label7);
            this.pnl_01.Controls.Add(this.label5);
            this.pnl_01.Controls.Add(this.label1);
            this.pnl_01.Location = new System.Drawing.Point(4, 32);
            this.pnl_01.Name = "pnl_01";
            this.pnl_01.Size = new System.Drawing.Size(488, 151);
            this.pnl_01.TabIndex = 84;
            // 
            // gruponame
            // 
            this.gruponame.Location = new System.Drawing.Point(133, 90);
            this.gruponame.Name = "gruponame";
            this.gruponame.Size = new System.Drawing.Size(274, 21);
            this.gruponame.TabIndex = 102;
            // 
            // grupoid
            // 
            this.grupoid.Location = new System.Drawing.Point(83, 90);
            this.grupoid.MaxLength = 4;
            this.grupoid.Name = "grupoid";
            this.grupoid.Size = new System.Drawing.Size(48, 21);
            this.grupoid.TabIndex = 101;
            this.grupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grupoid_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Proveedor:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(36, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Local :";
            // 
            // cboLocal
            // 
            this.cboLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboLocal.ForeColor = System.Drawing.Color.Black;
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.Location = new System.Drawing.Point(84, 67);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.Size = new System.Drawing.Size(222, 21);
            this.cboLocal.TabIndex = 39;
            // 
            // cboModuloID
            // 
            this.cboModuloID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModuloID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboModuloID.ForeColor = System.Drawing.Color.Black;
            this.cboModuloID.FormattingEnabled = true;
            this.cboModuloID.Location = new System.Drawing.Point(84, 43);
            this.cboModuloID.Name = "cboModuloID";
            this.cboModuloID.Size = new System.Drawing.Size(222, 21);
            this.cboModuloID.TabIndex = 37;
            this.cboModuloID.SelectedIndexChanged += new System.EventHandler(this.cboModuloID_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(27, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Módulo :";
            // 
            // fechfin
            // 
            this.fechfin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechfin.Location = new System.Drawing.Point(234, 117);
            this.fechfin.Name = "fechfin";
            this.fechfin.Size = new System.Drawing.Size(80, 20);
            this.fechfin.TabIndex = 33;
            // 
            // fechini
            // 
            this.fechini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechini.Location = new System.Drawing.Point(83, 117);
            this.fechini.Name = "fechini";
            this.fechini.Size = new System.Drawing.Size(80, 20);
            this.fechini.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Desde:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "LISTADO DE ORDENES DE COMPRAS EMITIDAS";
            // 
            // Frm_reporte_ordemitidas
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(492, 185);
            this.Controls.Add(this.pnl_01);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_ordemitidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Lista de Ordenes de Compras Emitidas";
            this.Load += new System.EventHandler(this.Frm_reporte_stockrollo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_reporte_stockrollo_KeyDown);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.CmMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnl_01)).EndInit();
            this.pnl_01.ResumeLayout(false);
            this.pnl_01.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_excel;
        private System.Windows.Forms.ContextMenuStrip CmMenuGrid;
        private System.Windows.Forms.SaveFileDialog sfdconsolidado;
        private System.Windows.Forms.ToolStripMenuItem exportarExcelToolStripMenuItem;
        private DevExpress.XtraEditors.PanelControl pnl_01;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker fechfin;
        internal System.Windows.Forms.DateTimePicker fechini;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboModuloID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboLocal;
        internal System.Windows.Forms.TextBox gruponame;
        internal System.Windows.Forms.TextBox grupoid;
        internal System.Windows.Forms.Label label6;

    }
}