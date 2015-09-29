namespace BapFormulariosNet.D70Produccion
{
    partial class Frm_status_produccion
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.Mdi_dgv_ordenproduccion = new DevExpress.XtraGrid.GridControl();
            this.dgv_ordenproduccion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.marcaname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ordenprod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechemi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.articid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.articname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lineaname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.generoname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.temporadaname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleccionname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.estadoname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Mdi_dgv_ordenproduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ordenproduccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mdi_dgv_ordenproduccion
            // 
            this.Mdi_dgv_ordenproduccion.Location = new System.Drawing.Point(5, 5);
            this.Mdi_dgv_ordenproduccion.MainView = this.dgv_ordenproduccion;
            this.Mdi_dgv_ordenproduccion.Name = "Mdi_dgv_ordenproduccion";
            this.Mdi_dgv_ordenproduccion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit5,
            this.repositoryItemCheckEdit5,
            this.repositoryItemTextEdit6,
            this.repositoryItemCheckEdit6});
            this.Mdi_dgv_ordenproduccion.Size = new System.Drawing.Size(1250, 383);
            this.Mdi_dgv_ordenproduccion.TabIndex = 400;
            this.Mdi_dgv_ordenproduccion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv_ordenproduccion});
            // 
            // dgv_ordenproduccion
            // 
            this.dgv_ordenproduccion.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgv_ordenproduccion.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
            this.dgv_ordenproduccion.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgv_ordenproduccion.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgv_ordenproduccion.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(223)))), ((int)(((byte)(217)))));
            this.dgv_ordenproduccion.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgv_ordenproduccion.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
            this.dgv_ordenproduccion.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.dgv_ordenproduccion.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgv_ordenproduccion.Appearance.Empty.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(138)))), ((int)(((byte)(131)))));
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.dgv_ordenproduccion.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.dgv_ordenproduccion.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgv_ordenproduccion.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.dgv_ordenproduccion.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgv_ordenproduccion.Appearance.FilterPanel.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.FilterPanel.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(66)))));
            this.dgv_ordenproduccion.Appearance.FixedLine.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgv_ordenproduccion.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.dgv_ordenproduccion.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.dgv_ordenproduccion.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.dgv_ordenproduccion.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgv_ordenproduccion.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.dgv_ordenproduccion.Appearance.FooterPanel.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.dgv_ordenproduccion.Appearance.FooterPanel.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.dgv_ordenproduccion.Appearance.GroupButton.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.GroupButton.Options.UseBorderColor = true;
            this.dgv_ordenproduccion.Appearance.GroupButton.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgv_ordenproduccion.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgv_ordenproduccion.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.dgv_ordenproduccion.Appearance.GroupFooter.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.dgv_ordenproduccion.Appearance.GroupFooter.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.dgv_ordenproduccion.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.dgv_ordenproduccion.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgv_ordenproduccion.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.dgv_ordenproduccion.Appearance.GroupPanel.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.GroupPanel.Options.UseFont = true;
            this.dgv_ordenproduccion.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(144)))), ((int)(((byte)(136)))));
            this.dgv_ordenproduccion.Appearance.GroupRow.ForeColor = System.Drawing.Color.Silver;
            this.dgv_ordenproduccion.Appearance.GroupRow.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.GroupRow.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgv_ordenproduccion.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.dgv_ordenproduccion.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.dgv_ordenproduccion.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgv_ordenproduccion.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.dgv_ordenproduccion.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgv_ordenproduccion.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.HorzLine.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(252)))), ((int)(((byte)(244)))));
            this.dgv_ordenproduccion.Appearance.Preview.BackColor2 = System.Drawing.Color.White;
            this.dgv_ordenproduccion.Appearance.Preview.ForeColor = System.Drawing.Color.Navy;
            this.dgv_ordenproduccion.Appearance.Preview.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.Preview.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgv_ordenproduccion.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.dgv_ordenproduccion.Appearance.Row.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.Row.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.dgv_ordenproduccion.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgv_ordenproduccion.Appearance.RowSeparator.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.dgv_ordenproduccion.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.dgv_ordenproduccion.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgv_ordenproduccion.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dgv_ordenproduccion.Appearance.TopNewRow.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgv_ordenproduccion.Appearance.VertLine.Options.UseBackColor = true;
            this.dgv_ordenproduccion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.marcaname,
            this.ordenprod,
            this.fechemi,
            this.articid,
            this.articname,
            this.lineaname,
            this.generoname,
            this.temporadaname,
            this.coleccionname,
            this.estadoname});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Teal;
            styleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "Len(Trim([conceptoid])) == 2";
            this.dgv_ordenproduccion.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.dgv_ordenproduccion.GridControl = this.Mdi_dgv_ordenproduccion;
            this.dgv_ordenproduccion.Name = "dgv_ordenproduccion";
            this.dgv_ordenproduccion.OptionsSelection.MultiSelect = true;
            this.dgv_ordenproduccion.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.dgv_ordenproduccion.OptionsView.ShowGroupPanel = false;
            this.dgv_ordenproduccion.PaintStyleName = "Web";
            // 
            // marcaname
            // 
            this.marcaname.Caption = "Marca";
            this.marcaname.FieldName = "marcaname";
            this.marcaname.Name = "marcaname";
            this.marcaname.OptionsColumn.AllowEdit = false;
            this.marcaname.Visible = true;
            this.marcaname.VisibleIndex = 0;
            this.marcaname.Width = 64;
            // 
            // ordenprod
            // 
            this.ordenprod.Caption = "OrdProd";
            this.ordenprod.FieldName = "ordenprod";
            this.ordenprod.Name = "ordenprod";
            this.ordenprod.OptionsColumn.AllowEdit = false;
            this.ordenprod.Visible = true;
            this.ordenprod.VisibleIndex = 1;
            this.ordenprod.Width = 67;
            // 
            // fechemi
            // 
            this.fechemi.Caption = "Fecha";
            this.fechemi.FieldName = "fechemi";
            this.fechemi.Name = "fechemi";
            this.fechemi.OptionsColumn.AllowEdit = false;
            this.fechemi.Visible = true;
            this.fechemi.VisibleIndex = 2;
            this.fechemi.Width = 72;
            // 
            // articid
            // 
            this.articid.Caption = "ArticID";
            this.articid.FieldName = "articidold";
            this.articid.Name = "articid";
            this.articid.OptionsColumn.AllowEdit = false;
            this.articid.Visible = true;
            this.articid.VisibleIndex = 3;
            this.articid.Width = 57;
            // 
            // articname
            // 
            this.articname.Caption = "Articulo";
            this.articname.FieldName = "articname";
            this.articname.Name = "articname";
            this.articname.OptionsColumn.AllowEdit = false;
            this.articname.Visible = true;
            this.articname.VisibleIndex = 4;
            this.articname.Width = 198;
            // 
            // lineaname
            // 
            this.lineaname.Caption = "Linea";
            this.lineaname.FieldName = "lineaname";
            this.lineaname.Name = "lineaname";
            this.lineaname.OptionsColumn.AllowEdit = false;
            this.lineaname.Visible = true;
            this.lineaname.VisibleIndex = 5;
            this.lineaname.Width = 87;
            // 
            // generoname
            // 
            this.generoname.Caption = "Genero";
            this.generoname.FieldName = "generoname";
            this.generoname.Name = "generoname";
            this.generoname.OptionsColumn.AllowEdit = false;
            this.generoname.Visible = true;
            this.generoname.VisibleIndex = 6;
            this.generoname.Width = 80;
            // 
            // temporadaname
            // 
            this.temporadaname.Caption = "Temporada";
            this.temporadaname.FieldName = "temporadaname";
            this.temporadaname.Name = "temporadaname";
            this.temporadaname.OptionsColumn.AllowEdit = false;
            this.temporadaname.Visible = true;
            this.temporadaname.VisibleIndex = 7;
            this.temporadaname.Width = 85;
            // 
            // coleccionname
            // 
            this.coleccionname.Caption = "Colección";
            this.coleccionname.FieldName = "coleccionname";
            this.coleccionname.Name = "coleccionname";
            this.coleccionname.OptionsColumn.AllowEdit = false;
            this.coleccionname.Visible = true;
            this.coleccionname.VisibleIndex = 8;
            this.coleccionname.Width = 70;
            // 
            // estadoname
            // 
            this.estadoname.Caption = "Estatus";
            this.estadoname.FieldName = "estadoname";
            this.estadoname.Name = "estadoname";
            this.estadoname.OptionsColumn.AllowEdit = false;
            this.estadoname.Visible = true;
            this.estadoname.VisibleIndex = 9;
            this.estadoname.Width = 74;
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.DisplayFormat.FormatString = "###,##0.0000";
            this.repositoryItemTextEdit5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit5.EditFormat.FormatString = "###,##0.0000";
            this.repositoryItemTextEdit5.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit5.Mask.EditMask = "###,##0.0000";
            this.repositoryItemTextEdit5.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Caption = "Check";
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            // 
            // repositoryItemTextEdit6
            // 
            this.repositoryItemTextEdit6.AutoHeight = false;
            this.repositoryItemTextEdit6.Name = "repositoryItemTextEdit6";
            this.repositoryItemTextEdit6.ReadOnly = true;
            // 
            // repositoryItemCheckEdit6
            // 
            this.repositoryItemCheckEdit6.AutoHeight = false;
            this.repositoryItemCheckEdit6.Caption = "Check";
            this.repositoryItemCheckEdit6.Name = "repositoryItemCheckEdit6";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1260, 33);
            this.panelControl1.TabIndex = 401;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Papyrus", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl4.LineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelControl4.Location = new System.Drawing.Point(522, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(226, 33);
            this.labelControl4.TabIndex = 439;
            this.labelControl4.Text = "Estado de Produccion";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.Mdi_dgv_ordenproduccion);
            this.panelControl2.Location = new System.Drawing.Point(2, 41);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1260, 388);
            this.panelControl2.TabIndex = 402;
            // 
            // Frm_status_produccion
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 431);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.DoubleBuffered = true;
            this.Name = "Frm_status_produccion";
            this.Text = "»» Frm_status_produccion";
            ((System.ComponentModel.ISupportInitialize)(this.Mdi_dgv_ordenproduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ordenproduccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl Mdi_dgv_ordenproduccion;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv_ordenproduccion;
        private DevExpress.XtraGrid.Columns.GridColumn marcaname;
        private DevExpress.XtraGrid.Columns.GridColumn ordenprod;
        private DevExpress.XtraGrid.Columns.GridColumn fechemi;
        private DevExpress.XtraGrid.Columns.GridColumn articid;
        private DevExpress.XtraGrid.Columns.GridColumn articname;
        private DevExpress.XtraGrid.Columns.GridColumn lineaname;
        private DevExpress.XtraGrid.Columns.GridColumn generoname;
        private DevExpress.XtraGrid.Columns.GridColumn temporadaname;
        private DevExpress.XtraGrid.Columns.GridColumn coleccionname;
        private DevExpress.XtraGrid.Columns.GridColumn estadoname;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}