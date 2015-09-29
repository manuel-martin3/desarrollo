namespace BapFormulariosNet.D70Produccion.Costos
{
    partial class Frm_rubrocosto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_rubrocosto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rubroid = new System.Windows.Forms.TextBox();
            this.MDI_dgb_rubrocosto = new DevExpress.XtraGrid.GridControl();
            this.dgb_rubrocosto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._rubroid = new DevExpress.XtraGrid.Columns.GridColumn();
            this._moduloid = new DevExpress.XtraGrid.Columns.GridColumn();
            this._moduloname = new DevExpress.XtraGrid.Columns.GridColumn();
            this._rubroname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboModuloID = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rubroname = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MDI_dgb_rubrocosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_rubrocosto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 43);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(169, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "RUBROS";
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
            this.btn_imprimir.Image = global::BapFormulariosNet.Properties.Resources.agt_print;
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
            this.btn_editar,
            this.btn_cancelar,
            this.btn_grabar,
            this.btn_eliminar,
            this.toolStripSeparator1,
            this.btn_imprimir,
            this.toolStripSeparator2,
            this.btn_clave,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(463, 29);
            this.Botonera.TabIndex = 1;
            this.Botonera.Text = "ToolStrip1";
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
            // btn_grabar
            // 
            this.btn_grabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_grabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar20;
            this.btn_grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(26, 26);
            this.btn_grabar.Text = "toolStripButton1";
            this.btn_grabar.ToolTipText = "Modificar";
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_eliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar20;
            this.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(26, 26);
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_clave
            // 
            this.btn_clave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            this.btn_clave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clave.Name = "btn_clave";
            this.btn_clave.Size = new System.Drawing.Size(26, 26);
            this.btn_clave.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(70, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "» Rubro :";
            // 
            // rubroid
            // 
            this.rubroid.Location = new System.Drawing.Point(136, 91);
            this.rubroid.Name = "rubroid";
            this.rubroid.Size = new System.Drawing.Size(25, 21);
            this.rubroid.TabIndex = 25;
            this.rubroid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MDI_dgb_rubrocosto
            // 
            this.MDI_dgb_rubrocosto.Location = new System.Drawing.Point(3, 118);
            this.MDI_dgb_rubrocosto.MainView = this.dgb_rubrocosto;
            this.MDI_dgb_rubrocosto.Name = "MDI_dgb_rubrocosto";
            this.MDI_dgb_rubrocosto.Size = new System.Drawing.Size(457, 200);
            this.MDI_dgb_rubrocosto.TabIndex = 32;
            this.MDI_dgb_rubrocosto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgb_rubrocosto});
            this.MDI_dgb_rubrocosto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MDI_dgb_constantes_KeyUp);
            // 
            // dgb_rubrocosto
            // 
            this.dgb_rubrocosto.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_rubrocosto.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
            this.dgb_rubrocosto.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgb_rubrocosto.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_rubrocosto.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(223)))), ((int)(((byte)(217)))));
            this.dgb_rubrocosto.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_rubrocosto.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
            this.dgb_rubrocosto.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.dgb_rubrocosto.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_rubrocosto.Appearance.Empty.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_rubrocosto.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(138)))), ((int)(((byte)(131)))));
            this.dgb_rubrocosto.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_rubrocosto.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_rubrocosto.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgb_rubrocosto.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.dgb_rubrocosto.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(48)))), ((int)(((byte)(41)))));
            this.dgb_rubrocosto.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_rubrocosto.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_rubrocosto.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.dgb_rubrocosto.Appearance.FilterPanel.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.FilterPanel.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(66)))));
            this.dgb_rubrocosto.Appearance.FixedLine.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgb_rubrocosto.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.dgb_rubrocosto.Appearance.FocusedCell.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.FocusedCell.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.dgb_rubrocosto.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.dgb_rubrocosto.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_rubrocosto.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_rubrocosto.Appearance.FooterPanel.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.dgb_rubrocosto.Appearance.FooterPanel.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.dgb_rubrocosto.Appearance.GroupButton.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.GroupButton.Options.UseBorderColor = true;
            this.dgb_rubrocosto.Appearance.GroupButton.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgb_rubrocosto.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(202)))), ((int)(((byte)(194)))));
            this.dgb_rubrocosto.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.dgb_rubrocosto.Appearance.GroupFooter.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.dgb_rubrocosto.Appearance.GroupFooter.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.dgb_rubrocosto.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.dgb_rubrocosto.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgb_rubrocosto.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.dgb_rubrocosto.Appearance.GroupPanel.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.GroupPanel.Options.UseFont = true;
            this.dgb_rubrocosto.Appearance.GroupPanel.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(144)))), ((int)(((byte)(136)))));
            this.dgb_rubrocosto.Appearance.GroupRow.ForeColor = System.Drawing.Color.Silver;
            this.dgb_rubrocosto.Appearance.GroupRow.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.GroupRow.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgb_rubrocosto.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.dgb_rubrocosto.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.dgb_rubrocosto.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgb_rubrocosto.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.dgb_rubrocosto.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dgb_rubrocosto.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.HorzLine.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(252)))), ((int)(((byte)(244)))));
            this.dgb_rubrocosto.Appearance.Preview.BackColor2 = System.Drawing.Color.White;
            this.dgb_rubrocosto.Appearance.Preview.ForeColor = System.Drawing.Color.Navy;
            this.dgb_rubrocosto.Appearance.Preview.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.Preview.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.dgb_rubrocosto.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.dgb_rubrocosto.Appearance.Row.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.Row.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.dgb_rubrocosto.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(212)))), ((int)(((byte)(204)))));
            this.dgb_rubrocosto.Appearance.RowSeparator.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.dgb_rubrocosto.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.dgb_rubrocosto.Appearance.SelectedRow.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.SelectedRow.Options.UseForeColor = true;
            this.dgb_rubrocosto.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dgb_rubrocosto.Appearance.TopNewRow.Options.UseBackColor = true;
            this.dgb_rubrocosto.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(192)))), ((int)(((byte)(184)))));
            this.dgb_rubrocosto.Appearance.VertLine.Options.UseBackColor = true;
            this.dgb_rubrocosto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._rubroid,
            this._moduloid,
            this._moduloname,
            this._rubroname});
            this.dgb_rubrocosto.GridControl = this.MDI_dgb_rubrocosto;
            this.dgb_rubrocosto.Name = "dgb_rubrocosto";
            this.dgb_rubrocosto.OptionsView.ShowGroupPanel = false;
            this.dgb_rubrocosto.PaintStyleName = "WindowsXP";
            this.dgb_rubrocosto.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.dgb_constantes_RowCellClick);
            // 
            // _rubroid
            // 
            this._rubroid.Caption = "Cod";
            this._rubroid.FieldName = "rubroid";
            this._rubroid.Name = "_rubroid";
            this._rubroid.OptionsColumn.AllowEdit = false;
            this._rubroid.Visible = true;
            this._rubroid.VisibleIndex = 0;
            this._rubroid.Width = 42;
            // 
            // _moduloid
            // 
            this._moduloid.Caption = "moduloid";
            this._moduloid.FieldName = "moduloid";
            this._moduloid.Name = "_moduloid";
            this._moduloid.OptionsColumn.AllowEdit = false;
            // 
            // _moduloname
            // 
            this._moduloname.Caption = "Modulo";
            this._moduloname.FieldName = "moduloname";
            this._moduloname.Name = "_moduloname";
            this._moduloname.OptionsColumn.AllowEdit = false;
            this._moduloname.Visible = true;
            this._moduloname.VisibleIndex = 1;
            this._moduloname.Width = 115;
            // 
            // _rubroname
            // 
            this._rubroname.Caption = "Rubro";
            this._rubroname.FieldName = "rubroname";
            this._rubroname.Name = "_rubroname";
            this._rubroname.OptionsColumn.AllowEdit = false;
            this._rubroname.Visible = true;
            this._rubroname.VisibleIndex = 2;
            this._rubroname.Width = 224;
            // 
            // cboModuloID
            // 
            this.cboModuloID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModuloID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboModuloID.ForeColor = System.Drawing.Color.Black;
            this.cboModuloID.FormattingEnabled = true;
            this.cboModuloID.Location = new System.Drawing.Point(137, 67);
            this.cboModuloID.Name = "cboModuloID";
            this.cboModuloID.Size = new System.Drawing.Size(222, 21);
            this.cboModuloID.TabIndex = 39;
            this.cboModuloID.SelectedIndexChanged += new System.EventHandler(this.cboModuloID_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(78, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Módulo :";
            // 
            // rubroname
            // 
            this.rubroname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.rubroname.Location = new System.Drawing.Point(162, 91);
            this.rubroname.Name = "rubroname";
            this.rubroname.Size = new System.Drawing.Size(232, 21);
            this.rubroname.TabIndex = 40;
            // 
            // Frm_rubrocosto
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(463, 320);
            this.Controls.Add(this.rubroname);
            this.Controls.Add(this.cboModuloID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.MDI_dgb_rubrocosto);
            this.Controls.Add(this.rubroid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_rubrocosto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Rubro de Costos";
            this.Load += new System.EventHandler(this.Frm_reporte_stockrollo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MDI_dgb_rubrocosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_rubrocosto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_grabar;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rubroid;
        private System.Windows.Forms.ToolStripButton btn_editar;
        private System.Windows.Forms.ToolStripButton btn_eliminar;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private DevExpress.XtraGrid.GridControl MDI_dgb_rubrocosto;
        private DevExpress.XtraGrid.Views.Grid.GridView dgb_rubrocosto;
        private DevExpress.XtraGrid.Columns.GridColumn _rubroid;
        private DevExpress.XtraGrid.Columns.GridColumn _moduloid;
        private DevExpress.XtraGrid.Columns.GridColumn _moduloname;
        private DevExpress.XtraGrid.Columns.GridColumn _rubroname;
        private System.Windows.Forms.ComboBox cboModuloID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox rubroname;

    }
}