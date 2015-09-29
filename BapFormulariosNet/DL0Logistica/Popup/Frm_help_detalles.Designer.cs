namespace BapFormulariosNet.DL0Logistica.Popup
{
    partial class Frm_help_detalles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_help_detalles));
            this.MDI_dgb_ayuda = new DevExpress.XtraGrid.GridControl();
            this.dgb_ayuda = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tipodoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.serdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechdoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctactename = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tipref = new DevExpress.XtraGrid.Columns.GridColumn();
            this.serref = new DevExpress.XtraGrid.Columns.GridColumn();
            this.numref = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechref = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glosa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.btn_Busqueda = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.MDI_dgb_ayuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_ayuda)).BeginInit();
            this.SuspendLayout();
            // 
            // MDI_dgb_ayuda
            // 
            this.MDI_dgb_ayuda.Location = new System.Drawing.Point(3, 38);
            this.MDI_dgb_ayuda.MainView = this.dgb_ayuda;
            this.MDI_dgb_ayuda.Name = "MDI_dgb_ayuda";
            this.MDI_dgb_ayuda.Size = new System.Drawing.Size(789, 262);
            this.MDI_dgb_ayuda.TabIndex = 0;
            this.MDI_dgb_ayuda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgb_ayuda});
            // 
            // dgb_ayuda
            // 
            this.dgb_ayuda.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_ayuda.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
            this.dgb_ayuda.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgb_ayuda.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_ayuda.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(223)))), ((int)(((byte)(217)))));
            this.dgb_ayuda.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_ayuda.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
            this.dgb_ayuda.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.dgb_ayuda.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_ayuda.Appearance.Empty.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_ayuda.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(138)))), ((int)(((byte)(131)))));
            this.dgb_ayuda.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_ayuda.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_ayuda.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgb_ayuda.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.dgb_ayuda.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.dgb_ayuda.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_ayuda.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_ayuda.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgb_ayuda.Appearance.FilterPanel.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.FilterPanel.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(66)))));
            this.dgb_ayuda.Appearance.FixedLine.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgb_ayuda.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.dgb_ayuda.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.dgb_ayuda.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.dgb_ayuda.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_ayuda.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_ayuda.Appearance.FooterPanel.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.dgb_ayuda.Appearance.FooterPanel.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_ayuda.Appearance.GroupButton.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.GroupButton.Options.UseBorderColor = true;
            this.dgb_ayuda.Appearance.GroupButton.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgb_ayuda.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgb_ayuda.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.dgb_ayuda.Appearance.GroupFooter.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.dgb_ayuda.Appearance.GroupFooter.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.dgb_ayuda.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.dgb_ayuda.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgb_ayuda.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_ayuda.Appearance.GroupPanel.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.GroupPanel.Options.UseFont = true;
            this.dgb_ayuda.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(144)))), ((int)(((byte)(136)))));
            this.dgb_ayuda.Appearance.GroupRow.ForeColor = System.Drawing.Color.Silver;
            this.dgb_ayuda.Appearance.GroupRow.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.GroupRow.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgb_ayuda.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_ayuda.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.dgb_ayuda.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgb_ayuda.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.dgb_ayuda.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_ayuda.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.HorzLine.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(252)))), ((int)(((byte)(244)))));
            this.dgb_ayuda.Appearance.Preview.BackColor2 = System.Drawing.Color.White;
            this.dgb_ayuda.Appearance.Preview.ForeColor = System.Drawing.Color.Navy;
            this.dgb_ayuda.Appearance.Preview.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.Preview.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgb_ayuda.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.dgb_ayuda.Appearance.Row.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.Row.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.dgb_ayuda.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_ayuda.Appearance.RowSeparator.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.dgb_ayuda.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_ayuda.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgb_ayuda.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dgb_ayuda.Appearance.TopNewRow.Options.UseBackColor = true;
            this.dgb_ayuda.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_ayuda.Appearance.VertLine.Options.UseBackColor = true;
            this.dgb_ayuda.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tipodoc,
            this.serdoc,
            this.numdoc,
            this.fechdoc,
            this.ctactename,
            this.tipref,
            this.serref,
            this.numref,
            this.fechref,
            this.glosa});
            this.dgb_ayuda.GridControl = this.MDI_dgb_ayuda;
            this.dgb_ayuda.Name = "dgb_ayuda";
            this.dgb_ayuda.OptionsView.ShowGroupPanel = false;
            this.dgb_ayuda.PaintStyleName = "Office2003";
            // 
            // tipodoc
            // 
            this.tipodoc.Caption = "TipDoc";
            this.tipodoc.FieldName = "tipodoc";
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.OptionsColumn.AllowEdit = false;
            this.tipodoc.Visible = true;
            this.tipodoc.VisibleIndex = 0;
            this.tipodoc.Width = 46;
            // 
            // serdoc
            // 
            this.serdoc.Caption = "SerDoc";
            this.serdoc.FieldName = "serdoc";
            this.serdoc.Name = "serdoc";
            this.serdoc.OptionsColumn.AllowEdit = false;
            this.serdoc.Visible = true;
            this.serdoc.VisibleIndex = 1;
            this.serdoc.Width = 52;
            // 
            // numdoc
            // 
            this.numdoc.Caption = "NumDoc";
            this.numdoc.FieldName = "numdoc";
            this.numdoc.Name = "numdoc";
            this.numdoc.OptionsColumn.AllowEdit = false;
            this.numdoc.Visible = true;
            this.numdoc.VisibleIndex = 2;
            this.numdoc.Width = 88;
            // 
            // fechdoc
            // 
            this.fechdoc.Caption = "FechDoc";
            this.fechdoc.FieldName = "fechdoc";
            this.fechdoc.Name = "fechdoc";
            this.fechdoc.OptionsColumn.AllowEdit = false;
            this.fechdoc.Visible = true;
            this.fechdoc.VisibleIndex = 3;
            this.fechdoc.Width = 71;
            // 
            // ctactename
            // 
            this.ctactename.Caption = "Proveedor";
            this.ctactename.FieldName = "ctactename";
            this.ctactename.Name = "ctactename";
            this.ctactename.OptionsColumn.AllowEdit = false;
            this.ctactename.Visible = true;
            this.ctactename.VisibleIndex = 4;
            this.ctactename.Width = 138;
            // 
            // tipref
            // 
            this.tipref.Caption = "tipref";
            this.tipref.FieldName = "tipref";
            this.tipref.Name = "tipref";
            this.tipref.OptionsColumn.AllowEdit = false;
            // 
            // serref
            // 
            this.serref.Caption = "serref";
            this.serref.FieldName = "serref";
            this.serref.Name = "serref";
            this.serref.OptionsColumn.AllowEdit = false;
            // 
            // numref
            // 
            this.numref.Caption = "NumOrden";
            this.numref.FieldName = "numref";
            this.numref.Name = "numref";
            this.numref.OptionsColumn.AllowEdit = false;
            this.numref.Visible = true;
            this.numref.VisibleIndex = 5;
            this.numref.Width = 74;
            // 
            // fechref
            // 
            this.fechref.Caption = "FechaOrden";
            this.fechref.FieldName = "fechref";
            this.fechref.Name = "fechref";
            this.fechref.OptionsColumn.AllowEdit = false;
            this.fechref.Visible = true;
            this.fechref.VisibleIndex = 6;
            this.fechref.Width = 91;
            // 
            // glosa
            // 
            this.glosa.Caption = "Obs.";
            this.glosa.FieldName = "glosa";
            this.glosa.Name = "glosa";
            this.glosa.OptionsColumn.AllowEdit = false;
            this.glosa.Visible = true;
            this.glosa.VisibleIndex = 7;
            this.glosa.Width = 212;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "» Proveedor:";
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Location = new System.Drawing.Point(81, 12);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(324, 20);
            this.txtbusqueda.TabIndex = 2;
            // 
            // btn_Busqueda
            // 
            this.btn_Busqueda.Image = ((System.Drawing.Image)(resources.GetObject("btn_Busqueda.Image")));
            this.btn_Busqueda.Location = new System.Drawing.Point(411, 9);
            this.btn_Busqueda.Name = "btn_Busqueda";
            this.btn_Busqueda.Size = new System.Drawing.Size(75, 23);
            this.btn_Busqueda.TabIndex = 3;
            this.btn_Busqueda.Text = "&Buscar";
            this.btn_Busqueda.ToolTip = "Buscar";
            this.btn_Busqueda.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btn_Busqueda.Click += new System.EventHandler(this.btn_Busqueda_Click);
            // 
            // Frm_help_detalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 303);
            this.Controls.Add(this.btn_Busqueda);
            this.Controls.Add(this.txtbusqueda);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.MDI_dgb_ayuda);
            this.Name = "Frm_help_detalles";
            this.Text = "»» Ayuda";
            ((System.ComponentModel.ISupportInitialize)(this.MDI_dgb_ayuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_ayuda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl MDI_dgb_ayuda;
        private DevExpress.XtraGrid.Views.Grid.GridView dgb_ayuda;
        private DevExpress.XtraGrid.Columns.GridColumn tipodoc;
        private DevExpress.XtraGrid.Columns.GridColumn serdoc;
        private DevExpress.XtraGrid.Columns.GridColumn numdoc;
        private DevExpress.XtraGrid.Columns.GridColumn fechdoc;
        private DevExpress.XtraGrid.Columns.GridColumn ctactename;
        private DevExpress.XtraGrid.Columns.GridColumn tipref;
        private DevExpress.XtraGrid.Columns.GridColumn serref;
        private DevExpress.XtraGrid.Columns.GridColumn numref;
        private DevExpress.XtraGrid.Columns.GridColumn fechref;
        private DevExpress.XtraGrid.Columns.GridColumn glosa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtbusqueda;
        private DevExpress.XtraEditors.SimpleButton btn_Busqueda;
    }
}