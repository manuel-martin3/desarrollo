namespace BapFormulariosNet.D70Produccion.Popup
{
    partial class Frm_detalle_explosion_material
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
        /// 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_detalle_explosion_material));
            this.txt_serop = new System.Windows.Forms.TextBox();
            this.dgv_talla = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_detalle = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bloqcostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requerido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_numop = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_nuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btn_editar = new DevExpress.XtraBars.BarButtonItem();
            this.btn_cancelar = new DevExpress.XtraBars.BarButtonItem();
            this.btn_grabar = new DevExpress.XtraBars.BarButtonItem();
            this.btn_eliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btn_imprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btn_log = new DevExpress.XtraBars.BarButtonItem();
            this.btn_clave = new DevExpress.XtraBars.BarButtonItem();
            this.btn_salir = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_versrec = new System.Windows.Forms.TextBox();
            this.txt_articidold = new System.Windows.Forms.TextBox();
            this.txt_articname = new System.Windows.Forms.TextBox();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txt_fechexplo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_talla)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fechexplo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fechexplo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_serop
            // 
            this.txt_serop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_serop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_serop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_serop.Location = new System.Drawing.Point(74, 31);
            this.txt_serop.MaxLength = 10;
            this.txt_serop.Name = "txt_serop";
            this.txt_serop.Size = new System.Drawing.Size(38, 20);
            this.txt_serop.TabIndex = 502;
            this.txt_serop.Text = "140Q";
            // 
            // dgv_talla
            // 
            this.dgv_talla.AllowUserToAddRows = false;
            this.dgv_talla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv_talla.BackgroundColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_talla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_talla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_talla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_talla.EnableHeadersVisualStyles = false;
            this.dgv_talla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_talla.Location = new System.Drawing.Point(64, 20);
            this.dgv_talla.Name = "dgv_talla";
            this.dgv_talla.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_talla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_talla.RowHeadersVisible = false;
            this.dgv_talla.Size = new System.Drawing.Size(653, 53);
            this.dgv_talla.TabIndex = 490;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_detalle);
            this.groupBox1.Location = new System.Drawing.Point(5, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 155);
            this.groupBox1.TabIndex = 500;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle";
            // 
            // dgv_detalle
            // 
            this.dgv_detalle.AllowUserToAddRows = false;
            this.dgv_detalle.BackgroundColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_detalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bloqcostname,
            this.productid,
            this.productname,
            this.requerido,
            this.habilitado,
            this.pendiente});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_detalle.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_detalle.EnableHeadersVisualStyles = false;
            this.dgv_detalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_detalle.Location = new System.Drawing.Point(6, 15);
            this.dgv_detalle.Name = "dgv_detalle";
            this.dgv_detalle.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_detalle.RowHeadersVisible = false;
            this.dgv_detalle.Size = new System.Drawing.Size(763, 131);
            this.dgv_detalle.TabIndex = 490;
            // 
            // bloqcostname
            // 
            this.bloqcostname.DataPropertyName = "bloqcostname";
            this.bloqcostname.HeaderText = "Bloque";
            this.bloqcostname.Name = "bloqcostname";
            this.bloqcostname.ReadOnly = true;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "ProductId";
            this.productid.Name = "productid";
            this.productid.ReadOnly = true;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.FillWeight = 350F;
            this.productname.HeaderText = "Producto";
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            this.productname.Width = 250;
            // 
            // requerido
            // 
            this.requerido.DataPropertyName = "requerido";
            this.requerido.HeaderText = "Requerido";
            this.requerido.Name = "requerido";
            this.requerido.ReadOnly = true;
            // 
            // habilitado
            // 
            this.habilitado.DataPropertyName = "habilitado";
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            // 
            // pendiente
            // 
            this.pendiente.DataPropertyName = "pendiente";
            this.pendiente.HeaderText = "Pendiente";
            this.pendiente.Name = "pendiente";
            this.pendiente.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_talla);
            this.groupBox3.Location = new System.Drawing.Point(5, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(780, 93);
            this.groupBox3.TabIndex = 499;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tallas";
            // 
            // txt_numop
            // 
            this.txt_numop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_numop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_numop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numop.Location = new System.Drawing.Point(114, 31);
            this.txt_numop.MaxLength = 10;
            this.txt_numop.Name = "txt_numop";
            this.txt_numop.Size = new System.Drawing.Size(76, 20);
            this.txt_numop.TabIndex = 504;
            this.txt_numop.Text = "0000000002";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_nuevo,
            this.btn_editar,
            this.btn_cancelar,
            this.btn_grabar,
            this.btn_eliminar,
            this.btn_imprimir,
            this.btn_log,
            this.btn_clave,
            this.btn_salir});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(79, 143);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_nuevo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_editar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_cancelar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_grabar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_eliminar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_imprimir),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_log),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_clave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_salir)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Glyph")));
            this.btn_nuevo.Id = 0;
            this.btn_nuevo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.LargeGlyph")));
            this.btn_nuevo.Name = "btn_nuevo";
            // 
            // btn_editar
            // 
            this.btn_editar.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_editar.Glyph")));
            this.btn_editar.Id = 1;
            this.btn_editar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_editar.LargeGlyph")));
            this.btn_editar.Name = "btn_editar";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Glyph")));
            this.btn_cancelar.Id = 2;
            this.btn_cancelar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.LargeGlyph")));
            this.btn_cancelar.Name = "btn_cancelar";
            // 
            // btn_grabar
            // 
            this.btn_grabar.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Glyph")));
            this.btn_grabar.Id = 3;
            this.btn_grabar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_grabar.LargeGlyph")));
            this.btn_grabar.Name = "btn_grabar";
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Glyph")));
            this.btn_eliminar.Id = 4;
            this.btn_eliminar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.LargeGlyph")));
            this.btn_eliminar.Name = "btn_eliminar";
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.Glyph")));
            this.btn_imprimir.Id = 5;
            this.btn_imprimir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.LargeGlyph")));
            this.btn_imprimir.Name = "btn_imprimir";
            // 
            // btn_log
            // 
            this.btn_log.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_log.Glyph")));
            this.btn_log.Id = 6;
            this.btn_log.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_log.LargeGlyph")));
            this.btn_log.Name = "btn_log";
            // 
            // btn_clave
            // 
            this.btn_clave.Glyph = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            this.btn_clave.Id = 7;
            this.btn_clave.Name = "btn_clave";
            // 
            // btn_salir
            // 
            this.btn_salir.Glyph = ((System.Drawing.Image)(resources.GetObject("btn_salir.Glyph")));
            this.btn_salir.Id = 8;
            this.btn_salir.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btn_salir.LargeGlyph")));
            this.btn_salir.Name = "btn_salir";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(789, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 406);
            this.barDockControlBottom.Size = new System.Drawing.Size(789, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 378);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(789, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 378);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txt_numop);
            this.panelControl1.Controls.Add(this.txt_serop);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txt_versrec);
            this.panelControl1.Controls.Add(this.txt_articidold);
            this.panelControl1.Controls.Add(this.txt_articname);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl15);
            this.panelControl1.Controls.Add(this.txt_fechexplo);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Location = new System.Drawing.Point(5, 62);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(780, 86);
            this.panelControl1.TabIndex = 497;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(211, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 503;
            this.labelControl1.Text = "Versión:";
            // 
            // txt_versrec
            // 
            this.txt_versrec.BackColor = System.Drawing.Color.Yellow;
            this.txt_versrec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_versrec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_versrec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_versrec.Location = new System.Drawing.Point(251, 31);
            this.txt_versrec.MaxLength = 10;
            this.txt_versrec.Name = "txt_versrec";
            this.txt_versrec.Size = new System.Drawing.Size(39, 20);
            this.txt_versrec.TabIndex = 502;
            this.txt_versrec.Text = "1501";
            // 
            // txt_articidold
            // 
            this.txt_articidold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_articidold.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_articidold.Location = new System.Drawing.Point(74, 55);
            this.txt_articidold.MaxLength = 10;
            this.txt_articidold.Name = "txt_articidold";
            this.txt_articidold.Size = new System.Drawing.Size(48, 21);
            this.txt_articidold.TabIndex = 501;
            // 
            // txt_articname
            // 
            this.txt_articname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_articname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_articname.Location = new System.Drawing.Point(124, 55);
            this.txt_articname.MaxLength = 10;
            this.txt_articname.Name = "txt_articname";
            this.txt_articname.Size = new System.Drawing.Size(429, 21);
            this.txt_articname.TabIndex = 500;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(31, 58);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(40, 13);
            this.labelControl12.TabIndex = 499;
            this.labelControl12.Text = "Artículo:";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(373, 36);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(81, 13);
            this.labelControl15.TabIndex = 498;
            this.labelControl15.Text = "Fecha Explosión:";
            // 
            // txt_fechexplo
            // 
            this.txt_fechexplo.EditValue = null;
            this.txt_fechexplo.Location = new System.Drawing.Point(458, 32);
            this.txt_fechexplo.MenuManager = this.barManager1;
            this.txt_fechexplo.Name = "txt_fechexplo";
            this.txt_fechexplo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txt_fechexplo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_fechexplo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_fechexplo.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.txt_fechexplo.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.txt_fechexplo.Size = new System.Drawing.Size(95, 20);
            this.txt_fechexplo.TabIndex = 497;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(20, 33);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(51, 13);
            this.labelControl8.TabIndex = 482;
            this.labelControl8.Text = "Ord. Prod:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Papyrus", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl4.LineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelControl4.Location = new System.Drawing.Point(237, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(351, 33);
            this.labelControl4.TabIndex = 498;
            this.labelControl4.Text = "Detalle de Explosión de Materiales";
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(214, 135);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_nuevo, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // Frm_detalle_explosion_material
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 406);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "Frm_detalle_explosion_material";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_detalle_explosion_material";
            this.Load += new System.EventHandler(this.Frm_detalle_explosion_material_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_talla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fechexplo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fechexplo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_serop;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_talla;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_detalle;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.TextBox txt_numop;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btn_nuevo;
        private DevExpress.XtraBars.BarButtonItem btn_editar;
        private DevExpress.XtraBars.BarButtonItem btn_cancelar;
        private DevExpress.XtraBars.BarButtonItem btn_grabar;
        private DevExpress.XtraBars.BarButtonItem btn_eliminar;
        private DevExpress.XtraBars.BarButtonItem btn_imprimir;
        private DevExpress.XtraBars.BarButtonItem btn_log;
        private DevExpress.XtraBars.BarButtonItem btn_clave;
        private DevExpress.XtraBars.BarButtonItem btn_salir;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        internal System.Windows.Forms.TextBox txt_versrec;
        internal System.Windows.Forms.TextBox txt_articidold;
        internal System.Windows.Forms.TextBox txt_articname;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.DateEdit txt_fechexplo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraBars.Bar bar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloqcostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn requerido;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendiente;
    }
}