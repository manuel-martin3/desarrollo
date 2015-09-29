namespace BapFormulariosNet.D60Tienda
{
    partial class Frm_AperturaCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AperturaCaja));
            this.monedan = new DevExpress.XtraEditors.TextEdit();
            this.monedae = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txttcambio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.loc_id = new DevExpress.XtraEditors.TextEdit();
            this.chkcerrado = new DevExpress.XtraEditors.CheckEdit();
            this.loc_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_aperturar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_modificar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_nuevo = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fecha = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.apertura1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.apertura2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cerrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.monedan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedae.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttcambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loc_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcerrado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loc_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // monedan
            // 
            this.monedan.Location = new System.Drawing.Point(121, 76);
            this.monedan.Name = "monedan";
            this.monedan.Size = new System.Drawing.Size(100, 20);
            this.monedan.TabIndex = 0;
            // 
            // monedae
            // 
            this.monedae.Location = new System.Drawing.Point(227, 76);
            this.monedae.Name = "monedae";
            this.monedae.Size = new System.Drawing.Size(100, 20);
            this.monedae.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(232, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Apertura (ME):";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(126, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Apertura (MN):";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txttcambio);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.loc_id);
            this.groupControl1.Controls.Add(this.chkcerrado);
            this.groupControl1.Controls.Add(this.loc_name);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btn_aperturar);
            this.groupControl1.Controls.Add(this.btn_modificar);
            this.groupControl1.Controls.Add(this.btn_nuevo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.fecha);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.monedae);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.monedan);
            this.groupControl1.Location = new System.Drawing.Point(12, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(413, 136);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Apartura de Caja";
            // 
            // txttcambio
            // 
            this.txttcambio.Location = new System.Drawing.Point(327, 29);
            this.txttcambio.Name = "txttcambio";
            this.txttcambio.Size = new System.Drawing.Size(81, 20);
            this.txttcambio.TabIndex = 28;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(251, 32);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(70, 13);
            this.labelControl6.TabIndex = 27;
            this.labelControl6.Text = "»» T-Cambio : ";
            // 
            // loc_id
            // 
            this.loc_id.Location = new System.Drawing.Point(67, 29);
            this.loc_id.Name = "loc_id";
            this.loc_id.Size = new System.Drawing.Size(37, 20);
            this.loc_id.TabIndex = 12;
            // 
            // chkcerrado
            // 
            this.chkcerrado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkcerrado.Location = new System.Drawing.Point(333, 76);
            this.chkcerrado.Name = "chkcerrado";
            this.chkcerrado.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkcerrado.Properties.Caption = "Cerrado";
            this.chkcerrado.Size = new System.Drawing.Size(63, 19);
            this.chkcerrado.TabIndex = 11;
            // 
            // loc_name
            // 
            this.loc_name.Location = new System.Drawing.Point(106, 29);
            this.loc_name.Name = "loc_name";
            this.loc_name.Size = new System.Drawing.Size(138, 20);
            this.loc_name.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "»» Local : ";
            // 
            // btn_aperturar
            // 
            this.btn_aperturar.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btn_aperturar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_aperturar.Appearance.BorderColor = System.Drawing.Color.White;
            this.btn_aperturar.Appearance.Options.UseBackColor = true;
            this.btn_aperturar.Appearance.Options.UseBorderColor = true;
            this.btn_aperturar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_aperturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_aperturar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aperturar.Image")));
            this.btn_aperturar.Location = new System.Drawing.Point(156, 103);
            this.btn_aperturar.Name = "btn_aperturar";
            this.btn_aperturar.Size = new System.Drawing.Size(88, 23);
            this.btn_aperturar.TabIndex = 8;
            this.btn_aperturar.Text = "Aperturar";
            this.btn_aperturar.Click += new System.EventHandler(this.btn_aperturar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btn_modificar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_modificar.Appearance.BorderColor = System.Drawing.Color.White;
            this.btn_modificar.Appearance.Options.UseBackColor = true;
            this.btn_modificar.Appearance.Options.UseBorderColor = true;
            this.btn_modificar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_modificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.Location = new System.Drawing.Point(274, 102);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(91, 23);
            this.btn_modificar.TabIndex = 7;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Appearance.BackColor = System.Drawing.Color.Teal;
            this.btn_nuevo.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_nuevo.Appearance.BorderColor = System.Drawing.Color.White;
            this.btn_nuevo.Appearance.Options.UseBackColor = true;
            this.btn_nuevo.Appearance.Options.UseBorderColor = true;
            this.btn_nuevo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btn_nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.Location = new System.Drawing.Point(67, 102);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(63, 23);
            this.btn_nuevo.TabIndex = 6;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "»» Fecha :";
            // 
            // fecha
            // 
            this.fecha.EditValue = null;
            this.fecha.Location = new System.Drawing.Point(12, 76);
            this.fecha.Name = "fecha";
            this.fecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fecha.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.fecha.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.fecha.Size = new System.Drawing.Size(100, 20);
            this.fecha.TabIndex = 4;
            this.fecha.DateTimeChanged += new System.EventHandler(this.fecha_DateTimeChanged);
            this.fecha.TextChanged += new System.EventHandler(this.fecha_TextChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 150);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(413, 211);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(223)))), ((int)(((byte)(217)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(138)))), ((int)(((byte)(131)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(66)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(144)))), ((int)(((byte)(136)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(252)))), ((int)(((byte)(244)))));
            this.gridView1.Appearance.Preview.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.Navy;
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._fecha,
            this.apertura1,
            this.apertura2,
            this.cerrado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Flat";
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // _fecha
            // 
            this._fecha.Caption = "Fecha";
            this._fecha.DisplayFormat.FormatString = "d";
            this._fecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this._fecha.FieldName = "fecha";
            this._fecha.Image = global::BapFormulariosNet.Properties.Resources.calendar_16x16;
            this._fecha.Name = "_fecha";
            this._fecha.OptionsColumn.AllowEdit = false;
            this._fecha.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this._fecha.Visible = true;
            this._fecha.VisibleIndex = 0;
            this._fecha.Width = 63;
            // 
            // apertura1
            // 
            this.apertura1.Caption = "Apertura (MN)";
            this.apertura1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.apertura1.FieldName = "apertura1";
            this.apertura1.Name = "apertura1";
            this.apertura1.OptionsColumn.AllowEdit = false;
            this.apertura1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.apertura1.Visible = true;
            this.apertura1.VisibleIndex = 1;
            this.apertura1.Width = 125;
            // 
            // apertura2
            // 
            this.apertura2.Caption = "Apertura (ME)";
            this.apertura2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.apertura2.FieldName = "apertura2";
            this.apertura2.Image = ((System.Drawing.Image)(resources.GetObject("apertura2.Image")));
            this.apertura2.Name = "apertura2";
            this.apertura2.OptionsColumn.AllowEdit = false;
            this.apertura2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.apertura2.Visible = true;
            this.apertura2.VisibleIndex = 2;
            this.apertura2.Width = 133;
            // 
            // cerrado
            // 
            this.cerrado.Caption = "Cerrado?";
            this.cerrado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.cerrado.FieldName = "cerrado";
            this.cerrado.Image = ((System.Drawing.Image)(resources.GetObject("cerrado.Image")));
            this.cerrado.Name = "cerrado";
            this.cerrado.OptionsColumn.AllowEdit = false;
            this.cerrado.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.cerrado.Visible = true;
            this.cerrado.VisibleIndex = 3;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(345, 57);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 29;
            this.labelControl5.Text = "Estado:";
            // 
            // Frm_AperturaCaja
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 373);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Frm_AperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_AperturaCaja";
            this.Load += new System.EventHandler(this.Frm_AperturaCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monedan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedae.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttcambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loc_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcerrado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loc_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit monedan;
        private DevExpress.XtraEditors.TextEdit monedae;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkcerrado;
        private DevExpress.XtraEditors.TextEdit loc_name;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_aperturar;
        private DevExpress.XtraEditors.SimpleButton btn_modificar;
        private DevExpress.XtraEditors.SimpleButton btn_nuevo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit fecha;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn _fecha;
        private DevExpress.XtraGrid.Columns.GridColumn apertura1;
        private DevExpress.XtraGrid.Columns.GridColumn apertura2;
        private DevExpress.XtraGrid.Columns.GridColumn cerrado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.TextEdit loc_id;
        private DevExpress.XtraEditors.TextEdit txttcambio;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}