namespace BapFormulariosNet.D60Tienda.Administracion
{
    partial class Frm_asistquin_planilla
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chk_quincena = new DevExpress.XtraEditors.CheckEdit();
            this.cmb_quincena = new System.Windows.Forms.ComboBox();
            this.chk_mes = new DevExpress.XtraEditors.CheckEdit();
            this.chk_anio = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_perimes2 = new System.Windows.Forms.ComboBox();
            this.cmb_perianio = new System.Windows.Forms.ComboBox();
            this.MDI_dgb_planillacomision = new DevExpress.XtraGrid.GridControl();
            this.CmMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgb_planillacomision = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.perianio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perimes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quincena = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cateplanid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cateplanname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.local = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddnni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.localname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cargoid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cargoname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.diaslab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechini = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechcese = new DevExpress.XtraGrid.Columns.GridColumn();
            this.telefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remunebas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.porccomic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechasig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sexo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.conhijos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.observac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.usuar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fecre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.feact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comisiona = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sfdplanilla = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_quincena.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_mes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_anio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MDI_dgb_planillacomision)).BeginInit();
            this.CmMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_planillacomision)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.chk_quincena);
            this.panelControl1.Controls.Add(this.cmb_quincena);
            this.panelControl1.Controls.Add(this.chk_mes);
            this.panelControl1.Controls.Add(this.chk_anio);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cmb_perimes2);
            this.panelControl1.Controls.Add(this.cmb_perianio);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1326, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // chk_quincena
            // 
            this.chk_quincena.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_quincena.Location = new System.Drawing.Point(385, 37);
            this.chk_quincena.Name = "chk_quincena";
            this.chk_quincena.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.chk_quincena.Properties.Appearance.Options.UseFont = true;
            this.chk_quincena.Properties.Caption = "» Quincena :";
            this.chk_quincena.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chk_quincena.Size = new System.Drawing.Size(92, 20);
            this.chk_quincena.TabIndex = 171;
            this.chk_quincena.CheckedChanged += new System.EventHandler(this.chk_quincena_CheckedChanged);
            // 
            // cmb_quincena
            // 
            this.cmb_quincena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_quincena.FormattingEnabled = true;
            this.cmb_quincena.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmb_quincena.Location = new System.Drawing.Point(478, 36);
            this.cmb_quincena.Name = "cmb_quincena";
            this.cmb_quincena.Size = new System.Drawing.Size(43, 21);
            this.cmb_quincena.TabIndex = 170;
            this.cmb_quincena.SelectedIndexChanged += new System.EventHandler(this.cmb_quincena_SelectedIndexChanged);
            // 
            // chk_mes
            // 
            this.chk_mes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_mes.Location = new System.Drawing.Point(180, 37);
            this.chk_mes.Name = "chk_mes";
            this.chk_mes.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.chk_mes.Properties.Appearance.Options.UseFont = true;
            this.chk_mes.Properties.Caption = "» Mes :";
            this.chk_mes.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chk_mes.Size = new System.Drawing.Size(60, 20);
            this.chk_mes.TabIndex = 167;
            this.chk_mes.CheckedChanged += new System.EventHandler(this.chk_mes_CheckedChanged);
            // 
            // chk_anio
            // 
            this.chk_anio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_anio.Location = new System.Drawing.Point(44, 37);
            this.chk_anio.Name = "chk_anio";
            this.chk_anio.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.chk_anio.Properties.Appearance.Options.UseFont = true;
            this.chk_anio.Properties.Caption = "» Año :";
            this.chk_anio.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chk_anio.Size = new System.Drawing.Size(60, 20);
            this.chk_anio.TabIndex = 166;
            this.chk_anio.CheckedChanged += new System.EventHandler(this.chk_anio_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(512, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(502, 23);
            this.labelControl3.TabIndex = 165;
            this.labelControl3.Text = "»» PLANTILLA DE ASISTENCIAS DE VENDEDORES ««";
            // 
            // cmb_perimes2
            // 
            this.cmb_perimes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_perimes2.FormattingEnabled = true;
            this.cmb_perimes2.Location = new System.Drawing.Point(241, 36);
            this.cmb_perimes2.Name = "cmb_perimes2";
            this.cmb_perimes2.Size = new System.Drawing.Size(127, 21);
            this.cmb_perimes2.TabIndex = 151;
            this.cmb_perimes2.SelectedIndexChanged += new System.EventHandler(this.cmb_perimes2_SelectedIndexChanged);
            // 
            // cmb_perianio
            // 
            this.cmb_perianio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_perianio.FormattingEnabled = true;
            this.cmb_perianio.Location = new System.Drawing.Point(104, 36);
            this.cmb_perianio.Name = "cmb_perianio";
            this.cmb_perianio.Size = new System.Drawing.Size(52, 21);
            this.cmb_perianio.TabIndex = 149;
            this.cmb_perianio.SelectedIndexChanged += new System.EventHandler(this.cmb_perianio_SelectedIndexChanged);
            // 
            // MDI_dgb_planillacomision
            // 
            this.MDI_dgb_planillacomision.ContextMenuStrip = this.CmMenuGrid;
            this.MDI_dgb_planillacomision.Location = new System.Drawing.Point(0, 71);
            this.MDI_dgb_planillacomision.MainView = this.dgb_planillacomision;
            this.MDI_dgb_planillacomision.Name = "MDI_dgb_planillacomision";
            this.MDI_dgb_planillacomision.Size = new System.Drawing.Size(1326, 526);
            this.MDI_dgb_planillacomision.TabIndex = 1;
            this.MDI_dgb_planillacomision.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgb_planillacomision});
            // 
            // CmMenuGrid
            // 
            this.CmMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarExcelToolStripMenuItem});
            this.CmMenuGrid.Name = "CmMenuGrid";
            this.CmMenuGrid.Size = new System.Drawing.Size(145, 26);
            // 
            // exportarExcelToolStripMenuItem
            // 
            this.exportarExcelToolStripMenuItem.Name = "exportarExcelToolStripMenuItem";
            this.exportarExcelToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exportarExcelToolStripMenuItem.Text = "Exportar Excel";
            this.exportarExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarExcelToolStripMenuItem_Click);
            // 
            // dgb_planillacomision
            // 
            this.dgb_planillacomision.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_planillacomision.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
            this.dgb_planillacomision.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgb_planillacomision.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_planillacomision.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(223)))), ((int)(((byte)(217)))));
            this.dgb_planillacomision.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_planillacomision.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
            this.dgb_planillacomision.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.dgb_planillacomision.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_planillacomision.Appearance.Empty.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_planillacomision.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(138)))), ((int)(((byte)(131)))));
            this.dgb_planillacomision.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_planillacomision.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_planillacomision.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgb_planillacomision.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.dgb_planillacomision.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.dgb_planillacomision.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_planillacomision.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_planillacomision.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgb_planillacomision.Appearance.FilterPanel.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.FilterPanel.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(66)))));
            this.dgb_planillacomision.Appearance.FixedLine.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgb_planillacomision.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.dgb_planillacomision.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.dgb_planillacomision.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.dgb_planillacomision.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_planillacomision.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_planillacomision.Appearance.FooterPanel.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.dgb_planillacomision.Appearance.FooterPanel.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_planillacomision.Appearance.GroupButton.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.GroupButton.Options.UseBorderColor = true;
            this.dgb_planillacomision.Appearance.GroupButton.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgb_planillacomision.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgb_planillacomision.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.dgb_planillacomision.Appearance.GroupFooter.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.dgb_planillacomision.Appearance.GroupFooter.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.dgb_planillacomision.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.dgb_planillacomision.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgb_planillacomision.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_planillacomision.Appearance.GroupPanel.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.GroupPanel.Options.UseFont = true;
            this.dgb_planillacomision.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(144)))), ((int)(((byte)(136)))));
            this.dgb_planillacomision.Appearance.GroupRow.ForeColor = System.Drawing.Color.Silver;
            this.dgb_planillacomision.Appearance.GroupRow.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.GroupRow.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Teal;
            this.dgb_planillacomision.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgb_planillacomision.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_planillacomision.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.dgb_planillacomision.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgb_planillacomision.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.dgb_planillacomision.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_planillacomision.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.HorzLine.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(252)))), ((int)(((byte)(244)))));
            this.dgb_planillacomision.Appearance.Preview.BackColor2 = System.Drawing.Color.White;
            this.dgb_planillacomision.Appearance.Preview.ForeColor = System.Drawing.Color.Navy;
            this.dgb_planillacomision.Appearance.Preview.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.Preview.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgb_planillacomision.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.dgb_planillacomision.Appearance.Row.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.Row.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.dgb_planillacomision.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_planillacomision.Appearance.RowSeparator.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.dgb_planillacomision.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_planillacomision.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgb_planillacomision.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dgb_planillacomision.Appearance.TopNewRow.Options.UseBackColor = true;
            this.dgb_planillacomision.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_planillacomision.Appearance.VertLine.Options.UseBackColor = true;
            this.dgb_planillacomision.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.Teal;
            this.dgb_planillacomision.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dgb_planillacomision.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_planillacomision.AppearancePrint.FooterPanel.Options.UseBackColor = true;
            this.dgb_planillacomision.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.dgb_planillacomision.AppearancePrint.FooterPanel.Options.UseForeColor = true;
            this.dgb_planillacomision.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Teal;
            this.dgb_planillacomision.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dgb_planillacomision.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_planillacomision.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.dgb_planillacomision.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.dgb_planillacomision.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.dgb_planillacomision.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dgb_planillacomision.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.perianio,
            this.perimes,
            this.quincena,
            this.cateplanid,
            this.cateplanname,
            this.vendorid,
            this.local,
            this.ddnni,
            this.vendorname,
            this.localname,
            this.cargoid,
            this.cargoname,
            this.diaslab,
            this.fechini,
            this.fechcese,
            this.telefono,
            this.remunebas,
            this.porccomic,
            this.fechasig,
            this.sexo,
            this.conhijos,
            this.observac,
            this.status,
            this.usuar,
            this.fecre,
            this.feact,
            this.comisiona});
            this.dgb_planillacomision.GridControl = this.MDI_dgb_planillacomision;
            this.dgb_planillacomision.Name = "dgb_planillacomision";
            this.dgb_planillacomision.OptionsView.ShowGroupPanel = false;
            this.dgb_planillacomision.PaintStyleName = "Office2003";
            // 
            // perianio
            // 
            this.perianio.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.perianio.AppearanceHeader.Options.UseBackColor = true;
            this.perianio.Caption = "Año";
            this.perianio.FieldName = "perianio";
            this.perianio.Name = "perianio";
            this.perianio.OptionsColumn.AllowEdit = false;
            this.perianio.Visible = true;
            this.perianio.VisibleIndex = 0;
            this.perianio.Width = 35;
            // 
            // perimes
            // 
            this.perimes.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.perimes.AppearanceHeader.Options.UseBackColor = true;
            this.perimes.Caption = "Mes";
            this.perimes.FieldName = "perimes";
            this.perimes.Name = "perimes";
            this.perimes.OptionsColumn.AllowEdit = false;
            this.perimes.Visible = true;
            this.perimes.VisibleIndex = 1;
            this.perimes.Width = 52;
            // 
            // quincena
            // 
            this.quincena.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.quincena.AppearanceHeader.Options.UseBackColor = true;
            this.quincena.Caption = "Quincena";
            this.quincena.FieldName = "quincena";
            this.quincena.Name = "quincena";
            this.quincena.OptionsColumn.AllowEdit = false;
            this.quincena.Visible = true;
            this.quincena.VisibleIndex = 2;
            this.quincena.Width = 72;
            // 
            // cateplanid
            // 
            this.cateplanid.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.cateplanid.AppearanceHeader.Options.UseBackColor = true;
            this.cateplanid.Caption = "Cod.CatPlan";
            this.cateplanid.FieldName = "cateplanid";
            this.cateplanid.Name = "cateplanid";
            this.cateplanid.OptionsColumn.AllowEdit = false;
            this.cateplanid.Visible = true;
            this.cateplanid.VisibleIndex = 6;
            this.cateplanid.Width = 66;
            // 
            // cateplanname
            // 
            this.cateplanname.Caption = "Cat.Planilla";
            this.cateplanname.FieldName = "cateplanname";
            this.cateplanname.Name = "cateplanname";
            this.cateplanname.OptionsColumn.AllowEdit = false;
            this.cateplanname.Visible = true;
            this.cateplanname.VisibleIndex = 7;
            this.cateplanname.Width = 61;
            // 
            // vendorid
            // 
            this.vendorid.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.vendorid.AppearanceHeader.Options.UseBackColor = true;
            this.vendorid.Caption = "Cod.Ven";
            this.vendorid.FieldName = "vendorid";
            this.vendorid.Name = "vendorid";
            this.vendorid.OptionsColumn.AllowEdit = false;
            this.vendorid.Visible = true;
            this.vendorid.VisibleIndex = 3;
            this.vendorid.Width = 56;
            // 
            // local
            // 
            this.local.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.local.AppearanceHeader.Options.UseBackColor = true;
            this.local.Caption = "Cod.Loc";
            this.local.FieldName = "local";
            this.local.Name = "local";
            this.local.OptionsColumn.AllowEdit = false;
            this.local.Visible = true;
            this.local.VisibleIndex = 8;
            this.local.Width = 64;
            // 
            // ddnni
            // 
            this.ddnni.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.ddnni.AppearanceHeader.Options.UseBackColor = true;
            this.ddnni.Caption = "DNI";
            this.ddnni.FieldName = "ddnni";
            this.ddnni.Name = "ddnni";
            this.ddnni.OptionsColumn.AllowEdit = false;
            this.ddnni.Visible = true;
            this.ddnni.VisibleIndex = 4;
            this.ddnni.Width = 32;
            // 
            // vendorname
            // 
            this.vendorname.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.vendorname.AppearanceHeader.Options.UseBackColor = true;
            this.vendorname.Caption = "Vendedor";
            this.vendorname.FieldName = "vendorname";
            this.vendorname.Name = "vendorname";
            this.vendorname.OptionsColumn.AllowEdit = false;
            this.vendorname.Visible = true;
            this.vendorname.VisibleIndex = 5;
            this.vendorname.Width = 57;
            // 
            // localname
            // 
            this.localname.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.localname.AppearanceHeader.Options.UseBackColor = true;
            this.localname.Caption = "Local";
            this.localname.FieldName = "localname";
            this.localname.Name = "localname";
            this.localname.OptionsColumn.AllowEdit = false;
            this.localname.Visible = true;
            this.localname.VisibleIndex = 9;
            this.localname.Width = 46;
            // 
            // cargoid
            // 
            this.cargoid.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.cargoid.AppearanceHeader.Options.UseBackColor = true;
            this.cargoid.Caption = "Cod.Car";
            this.cargoid.FieldName = "cargoid";
            this.cargoid.Name = "cargoid";
            this.cargoid.OptionsColumn.AllowEdit = false;
            this.cargoid.Visible = true;
            this.cargoid.VisibleIndex = 10;
            this.cargoid.Width = 49;
            // 
            // cargoname
            // 
            this.cargoname.AppearanceHeader.BackColor = System.Drawing.Color.PaleGreen;
            this.cargoname.AppearanceHeader.Options.UseBackColor = true;
            this.cargoname.Caption = "Cargo";
            this.cargoname.FieldName = "cargoname";
            this.cargoname.Name = "cargoname";
            this.cargoname.OptionsColumn.AllowEdit = false;
            this.cargoname.Visible = true;
            this.cargoname.VisibleIndex = 11;
            this.cargoname.Width = 57;
            // 
            // diaslab
            // 
            this.diaslab.Caption = "Dias.Lab";
            this.diaslab.FieldName = "diaslab";
            this.diaslab.Name = "diaslab";
            this.diaslab.OptionsColumn.AllowEdit = false;
            this.diaslab.Visible = true;
            this.diaslab.VisibleIndex = 12;
            this.diaslab.Width = 54;
            // 
            // fechini
            // 
            this.fechini.Caption = "Fech.Ini";
            this.fechini.FieldName = "fechini";
            this.fechini.Name = "fechini";
            this.fechini.OptionsColumn.AllowEdit = false;
            this.fechini.Visible = true;
            this.fechini.VisibleIndex = 13;
            this.fechini.Width = 48;
            // 
            // fechcese
            // 
            this.fechcese.Caption = "Fech.Cese";
            this.fechcese.FieldName = "fechcese";
            this.fechcese.Name = "fechcese";
            this.fechcese.OptionsColumn.AllowEdit = false;
            this.fechcese.Visible = true;
            this.fechcese.VisibleIndex = 14;
            this.fechcese.Width = 48;
            // 
            // telefono
            // 
            this.telefono.Caption = "Telefono";
            this.telefono.FieldName = "telefono";
            this.telefono.Name = "telefono";
            this.telefono.OptionsColumn.AllowEdit = false;
            this.telefono.Visible = true;
            this.telefono.VisibleIndex = 15;
            this.telefono.Width = 48;
            // 
            // remunebas
            // 
            this.remunebas.Caption = "Remu.Bas";
            this.remunebas.FieldName = "remunebas";
            this.remunebas.Name = "remunebas";
            this.remunebas.OptionsColumn.AllowEdit = false;
            this.remunebas.Visible = true;
            this.remunebas.VisibleIndex = 16;
            this.remunebas.Width = 48;
            // 
            // porccomic
            // 
            this.porccomic.Caption = "Por.Comic";
            this.porccomic.FieldName = "porccomic";
            this.porccomic.Name = "porccomic";
            this.porccomic.OptionsColumn.AllowEdit = false;
            this.porccomic.Visible = true;
            this.porccomic.VisibleIndex = 17;
            this.porccomic.Width = 48;
            // 
            // fechasig
            // 
            this.fechasig.Caption = "Fech.Asig";
            this.fechasig.FieldName = "fechasig";
            this.fechasig.Name = "fechasig";
            this.fechasig.OptionsColumn.AllowEdit = false;
            this.fechasig.Visible = true;
            this.fechasig.VisibleIndex = 18;
            this.fechasig.Width = 48;
            // 
            // sexo
            // 
            this.sexo.Caption = "Sexo";
            this.sexo.FieldName = "sexo";
            this.sexo.Name = "sexo";
            this.sexo.OptionsColumn.AllowEdit = false;
            this.sexo.Visible = true;
            this.sexo.VisibleIndex = 19;
            this.sexo.Width = 48;
            // 
            // conhijos
            // 
            this.conhijos.Caption = "Con.Hijos";
            this.conhijos.FieldName = "conhijos";
            this.conhijos.Name = "conhijos";
            this.conhijos.OptionsColumn.AllowEdit = false;
            this.conhijos.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.conhijos.Visible = true;
            this.conhijos.VisibleIndex = 20;
            this.conhijos.Width = 48;
            // 
            // observac
            // 
            this.observac.Caption = "Obs.";
            this.observac.FieldName = "observac";
            this.observac.Name = "observac";
            this.observac.OptionsColumn.AllowEdit = false;
            this.observac.Visible = true;
            this.observac.VisibleIndex = 21;
            this.observac.Width = 48;
            // 
            // status
            // 
            this.status.Caption = "Status";
            this.status.FieldName = "status";
            this.status.Name = "status";
            this.status.OptionsColumn.AllowEdit = false;
            this.status.Visible = true;
            this.status.VisibleIndex = 22;
            this.status.Width = 48;
            // 
            // usuar
            // 
            this.usuar.Caption = "usuar";
            this.usuar.FieldName = "usuar";
            this.usuar.Name = "usuar";
            this.usuar.OptionsColumn.AllowEdit = false;
            // 
            // fecre
            // 
            this.fecre.Caption = "fecre";
            this.fecre.FieldName = "fecre";
            this.fecre.Name = "fecre";
            this.fecre.OptionsColumn.AllowEdit = false;
            // 
            // feact
            // 
            this.feact.Caption = "feact";
            this.feact.FieldName = "feact";
            this.feact.Name = "feact";
            this.feact.OptionsColumn.AllowEdit = false;
            // 
            // comisiona
            // 
            this.comisiona.Caption = "Comisiona";
            this.comisiona.FieldName = "comisiona";
            this.comisiona.Name = "comisiona";
            this.comisiona.OptionsColumn.AllowEdit = false;
            this.comisiona.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.comisiona.Visible = true;
            this.comisiona.VisibleIndex = 23;
            this.comisiona.Width = 128;
            // 
            // sfdplanilla
            // 
            this.sfdplanilla.Filter = "Archivos Excel | *.xls";
            // 
            // Frm_asistquin_planilla
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 560);
            this.Controls.Add(this.MDI_dgb_planillacomision);
            this.Controls.Add(this.panelControl1);
            this.DoubleBuffered = true;
            this.Name = "Frm_asistquin_planilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Plantilla de Asistencia de Vendedores";
            this.Load += new System.EventHandler(this.Frm_planilla_comision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_quincena.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_mes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_anio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MDI_dgb_planillacomision)).EndInit();
            this.CmMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgb_planillacomision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl MDI_dgb_planillacomision;
        private DevExpress.XtraGrid.Views.Grid.GridView dgb_planillacomision;
        private DevExpress.XtraGrid.Columns.GridColumn perianio;
        private DevExpress.XtraGrid.Columns.GridColumn perimes;
        private DevExpress.XtraGrid.Columns.GridColumn quincena;
        private DevExpress.XtraGrid.Columns.GridColumn vendorid;
        private DevExpress.XtraGrid.Columns.GridColumn vendorname;
        private DevExpress.XtraGrid.Columns.GridColumn local;
        private DevExpress.XtraGrid.Columns.GridColumn localname;
        private DevExpress.XtraGrid.Columns.GridColumn cargoid;
        private DevExpress.XtraGrid.Columns.GridColumn cargoname;
        private DevExpress.XtraGrid.Columns.GridColumn usuar;
        private System.Windows.Forms.ComboBox cmb_perianio;
        private System.Windows.Forms.ComboBox cmb_perimes2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chk_mes;
        private DevExpress.XtraEditors.CheckEdit chk_anio;
        private DevExpress.XtraGrid.Columns.GridColumn cateplanid;
        private System.Windows.Forms.ContextMenuStrip CmMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem exportarExcelToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdplanilla;
        private DevExpress.XtraGrid.Columns.GridColumn ddnni;
        private DevExpress.XtraGrid.Columns.GridColumn diaslab;
        private DevExpress.XtraEditors.CheckEdit chk_quincena;
        private System.Windows.Forms.ComboBox cmb_quincena;
        private DevExpress.XtraGrid.Columns.GridColumn cateplanname;
        private DevExpress.XtraGrid.Columns.GridColumn fechini;
        private DevExpress.XtraGrid.Columns.GridColumn fechcese;
        private DevExpress.XtraGrid.Columns.GridColumn telefono;
        private DevExpress.XtraGrid.Columns.GridColumn remunebas;
        private DevExpress.XtraGrid.Columns.GridColumn porccomic;
        private DevExpress.XtraGrid.Columns.GridColumn fechasig;
        private DevExpress.XtraGrid.Columns.GridColumn sexo;
        private DevExpress.XtraGrid.Columns.GridColumn conhijos;
        private DevExpress.XtraGrid.Columns.GridColumn observac;
        private DevExpress.XtraGrid.Columns.GridColumn status;
        private DevExpress.XtraGrid.Columns.GridColumn fecre;
        private DevExpress.XtraGrid.Columns.GridColumn feact;
        private DevExpress.XtraGrid.Columns.GridColumn comisiona;
    }
}