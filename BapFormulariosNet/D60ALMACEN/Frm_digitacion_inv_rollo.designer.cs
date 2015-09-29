namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_digitacion_inv_rollo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_digitacion_inv_rollo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_search = new DevExpress.XtraEditors.SimpleButton();
            this.rollo_search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totpzas2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.totpzas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemsT = new System.Windows.Forms.TextBox();
            this.griddetallemov = new System.Windows.Forms.DataGridView();
            this.rollo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stocklibros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockfisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costopromlibros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costopromfisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numdoc = new System.Windows.Forms.TextBox();
            this.tipodoc = new System.Windows.Forms.ComboBox();
            this.serdoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.fechdoc = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimirNoval = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_primero = new System.Windows.Forms.ToolStripButton();
            this.btn_anterior = new System.Windows.Forms.ToolStripButton();
            this.btn_siguiente = new System.Windows.Forms.ToolStripButton();
            this.btn_ultimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_detanadir = new System.Windows.Forms.ToolStripButton();
            this.btn_deteliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_import = new System.Windows.Forms.ToolStripButton();
            this.btn_error = new System.Windows.Forms.ToolStripButton();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_log = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.label33 = new System.Windows.Forms.Label();
            this.glosa = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userinventario = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.ubic = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddetallemov)).BeginInit();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.rollo_search);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.totpzas2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.totpzas);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.itemsT);
            this.panel2.Location = new System.Drawing.Point(0, 472);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(687, 48);
            this.panel2.TabIndex = 73;
            // 
            // btn_search
            // 
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.Location = new System.Drawing.Point(150, 7);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(65, 23);
            this.btn_search.TabIndex = 79;
            this.btn_search.Text = "&Buscar";
            this.btn_search.ToolTip = "Buscar Rollo";
            this.btn_search.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // rollo_search
            // 
            this.rollo_search.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rollo_search.ForeColor = System.Drawing.Color.Firebrick;
            this.rollo_search.Location = new System.Drawing.Point(215, 8);
            this.rollo_search.Name = "rollo_search";
            this.rollo_search.Size = new System.Drawing.Size(76, 21);
            this.rollo_search.TabIndex = 78;
            this.rollo_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rollo_search_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(503, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Stock Fisico";
            // 
            // totpzas2
            // 
            this.totpzas2.Location = new System.Drawing.Point(503, 4);
            this.totpzas2.Name = "totpzas2";
            this.totpzas2.Size = new System.Drawing.Size(75, 21);
            this.totpzas2.TabIndex = 76;
            this.totpzas2.Text = "10,000";
            this.totpzas2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(400, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Stock Libros";
            // 
            // totpzas
            // 
            this.totpzas.Location = new System.Drawing.Point(400, 5);
            this.totpzas.Name = "totpzas";
            this.totpzas.Size = new System.Drawing.Size(75, 21);
            this.totpzas.TabIndex = 74;
            this.totpzas.Text = "10,000";
            this.totpzas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Rollos";
            // 
            // itemsT
            // 
            this.itemsT.Location = new System.Drawing.Point(4, 5);
            this.itemsT.Name = "itemsT";
            this.itemsT.Size = new System.Drawing.Size(51, 21);
            this.itemsT.TabIndex = 72;
            this.itemsT.Text = "999";
            this.itemsT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // griddetallemov
            // 
            this.griddetallemov.AllowUserToAddRows = false;
            this.griddetallemov.AllowUserToDeleteRows = false;
            this.griddetallemov.AllowUserToResizeColumns = false;
            this.griddetallemov.AllowUserToResizeRows = false;
            this.griddetallemov.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.griddetallemov.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.griddetallemov.ColumnHeadersHeight = 20;
            this.griddetallemov.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rollo,
            this.productname,
            this.stocklibros,
            this.stockfisico,
            this.diferencia,
            this.costopromlibros,
            this.costopromfisico,
            this.productid});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.griddetallemov.DefaultCellStyle = dataGridViewCellStyle3;
            this.griddetallemov.Location = new System.Drawing.Point(0, 198);
            this.griddetallemov.MultiSelect = false;
            this.griddetallemov.Name = "griddetallemov";
            this.griddetallemov.RowHeadersVisible = false;
            this.griddetallemov.RowHeadersWidth = 10;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.NullValue = null;
            this.griddetallemov.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.griddetallemov.RowTemplate.DefaultCellStyle.Format = "N6";
            this.griddetallemov.RowTemplate.DefaultCellStyle.NullValue = null;
            this.griddetallemov.RowTemplate.Height = 20;
            this.griddetallemov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.griddetallemov.Size = new System.Drawing.Size(687, 274);
            this.griddetallemov.TabIndex = 71;
            this.griddetallemov.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetallemov_CellEndEdit);
            this.griddetallemov.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetallemov_CellEnter);
            this.griddetallemov.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetallemov_CellLeave);
            this.griddetallemov.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.griddetallemov_CellValueChanged);
            this.griddetallemov.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.griddetallemov_EditingControlShowing);
            this.griddetallemov.KeyDown += new System.Windows.Forms.KeyEventHandler(this.griddetallemov_KeyDown);
            // 
            // rollo
            // 
            this.rollo.DataPropertyName = "rollo";
            this.rollo.Frozen = true;
            this.rollo.HeaderText = "Rollo";
            this.rollo.MaxInputLength = 10;
            this.rollo.Name = "rollo";
            this.rollo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rollo.Width = 80;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.Frozen = true;
            this.productname.HeaderText = "Producto";
            this.productname.Name = "productname";
            this.productname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.productname.Width = 300;
            // 
            // stocklibros
            // 
            this.stocklibros.DataPropertyName = "stocklibros";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.stocklibros.DefaultCellStyle = dataGridViewCellStyle2;
            this.stocklibros.Frozen = true;
            this.stocklibros.HeaderText = "Stock Lib";
            this.stocklibros.Name = "stocklibros";
            this.stocklibros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // stockfisico
            // 
            this.stockfisico.DataPropertyName = "stockfisico";
            this.stockfisico.Frozen = true;
            this.stockfisico.HeaderText = "Stock Fis";
            this.stockfisico.Name = "stockfisico";
            // 
            // diferencia
            // 
            this.diferencia.DataPropertyName = "diferencia";
            this.diferencia.Frozen = true;
            this.diferencia.HeaderText = "Diferencia";
            this.diferencia.Name = "diferencia";
            // 
            // costopromlibros
            // 
            this.costopromlibros.DataPropertyName = "costopromlibros";
            this.costopromlibros.Frozen = true;
            this.costopromlibros.HeaderText = "CosProm Lib";
            this.costopromlibros.Name = "costopromlibros";
            this.costopromlibros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.costopromlibros.Visible = false;
            // 
            // costopromfisico
            // 
            this.costopromfisico.DataPropertyName = "costopromfisico";
            this.costopromfisico.HeaderText = "CosProm Fis";
            this.costopromfisico.Name = "costopromfisico";
            this.costopromfisico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.costopromfisico.Visible = false;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "productid";
            this.productid.Name = "productid";
            this.productid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numdoc);
            this.panel1.Controls.Add(this.tipodoc);
            this.panel1.Controls.Add(this.serdoc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 48);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo Documento";
            // 
            // numdoc
            // 
            this.numdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numdoc.Location = new System.Drawing.Point(238, 20);
            this.numdoc.MaxLength = 10;
            this.numdoc.Name = "numdoc";
            this.numdoc.Size = new System.Drawing.Size(79, 20);
            this.numdoc.TabIndex = 15;
            this.numdoc.Text = "0000000001";
            this.numdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numdoc_KeyDown);
            this.numdoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numdoc_KeyPress);
            // 
            // tipodoc
            // 
            this.tipodoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipodoc.FormattingEnabled = true;
            this.tipodoc.Location = new System.Drawing.Point(6, 20);
            this.tipodoc.Name = "tipodoc";
            this.tipodoc.Size = new System.Drawing.Size(184, 21);
            this.tipodoc.TabIndex = 11;
            this.tipodoc.SelectedIndexChanged += new System.EventHandler(this.tipodoc_SelectedIndexChanged);
            // 
            // serdoc
            // 
            this.serdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serdoc.Location = new System.Drawing.Point(192, 20);
            this.serdoc.MaxLength = 5;
            this.serdoc.Name = "serdoc";
            this.serdoc.Size = new System.Drawing.Size(45, 20);
            this.serdoc.TabIndex = 12;
            this.serdoc.Text = "0001";
            this.serdoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(193, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Serie";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(249, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Número";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(367, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(261, 24);
            this.label11.TabIndex = 9;
            this.label11.Text = "INGRESO INVENTARIADO";
            // 
            // fechdoc
            // 
            this.fechdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechdoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdoc.Location = new System.Drawing.Point(554, 20);
            this.fechdoc.Name = "fechdoc";
            this.fechdoc.Size = new System.Drawing.Size(84, 20);
            this.fechdoc.TabIndex = 78;
            this.fechdoc.Value = new System.DateTime(2012, 12, 19, 0, 0, 0, 0);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(506, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 79;
            this.label16.Text = "Fecha:";
            // 
            // Botonera
            // 
            this.Botonera.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Botonera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_editar,
            this.btn_cancelar,
            this.btn_grabar,
            this.btn_eliminar,
            this.btnImprimirNoval,
            this.toolStripSeparator1,
            this.btn_primero,
            this.btn_anterior,
            this.btn_siguiente,
            this.btn_ultimo,
            this.toolStripSeparator2,
            this.btn_detanadir,
            this.btn_deteliminar,
            this.toolStripSeparator3,
            this.btn_import,
            this.btn_error,
            this.btn_clave,
            this.btn_log,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(689, 29);
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
            this.btn_nuevo.ToolTipText = "Nuevo (Ctrl + N)";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
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
            // btn_grabar
            // 
            this.btn_grabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(26, 26);
            this.btn_grabar.Text = "Grabar";
            this.btn_grabar.ToolTipText = "Grabar (Ctrl + G)";
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(26, 26);
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btnImprimirNoval
            // 
            this.btnImprimirNoval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImprimirNoval.Image = global::BapFormulariosNet.Properties.Resources.agt_print;
            this.btnImprimirNoval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirNoval.Name = "btnImprimirNoval";
            this.btnImprimirNoval.Size = new System.Drawing.Size(26, 26);
            this.btnImprimirNoval.ToolTipText = "Imprimir";
            this.btnImprimirNoval.Click += new System.EventHandler(this.btnImprimirNoval_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_primero
            // 
            this.btn_primero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_primero.Image = global::BapFormulariosNet.Properties.Resources.go_first_g;
            this.btn_primero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_primero.Name = "btn_primero";
            this.btn_primero.Size = new System.Drawing.Size(26, 26);
            this.btn_primero.Text = "Primero";
            this.btn_primero.Click += new System.EventHandler(this.btn_primero_Click);
            // 
            // btn_anterior
            // 
            this.btn_anterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_anterior.Image = global::BapFormulariosNet.Properties.Resources.go_previous_g;
            this.btn_anterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.Size = new System.Drawing.Size(26, 26);
            this.btn_anterior.Text = "Anterior";
            this.btn_anterior.Click += new System.EventHandler(this.btn_anterior_Click);
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_siguiente.Image = global::BapFormulariosNet.Properties.Resources.go_next_g;
            this.btn_siguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(26, 26);
            this.btn_siguiente.Text = "Siguiente";
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click);
            // 
            // btn_ultimo
            // 
            this.btn_ultimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ultimo.Image = global::BapFormulariosNet.Properties.Resources.go_last_g;
            this.btn_ultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ultimo.Name = "btn_ultimo";
            this.btn_ultimo.Size = new System.Drawing.Size(26, 26);
            this.btn_ultimo.Text = "Ultimo";
            this.btn_ultimo.Click += new System.EventHandler(this.btn_ultimo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_detanadir
            // 
            this.btn_detanadir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_detanadir.Image = global::BapFormulariosNet.Properties.Resources.go_add;
            this.btn_detanadir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_detanadir.Name = "btn_detanadir";
            this.btn_detanadir.Size = new System.Drawing.Size(26, 26);
            this.btn_detanadir.Text = "Añadir";
            this.btn_detanadir.Click += new System.EventHandler(this.btn_detanadir_Click);
            // 
            // btn_deteliminar
            // 
            this.btn_deteliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_deteliminar.Image = global::BapFormulariosNet.Properties.Resources.go_remove1;
            this.btn_deteliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_deteliminar.Name = "btn_deteliminar";
            this.btn_deteliminar.Size = new System.Drawing.Size(26, 26);
            this.btn_deteliminar.Text = "Quitar";
            this.btn_deteliminar.Click += new System.EventHandler(this.btn_deteliminar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_import
            // 
            this.btn_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_import.Image = global::BapFormulariosNet.Properties.Resources.btn_signup201;
            this.btn_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(26, 26);
            this.btn_import.Text = "Cargar Inventario";
            this.btn_import.ToolTipText = "Cargar Inventario";
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_error
            // 
            this.btn_error.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_error.Image = global::BapFormulariosNet.Properties.Resources.btn_info;
            this.btn_error.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_error.Name = "btn_error";
            this.btn_error.Size = new System.Drawing.Size(26, 26);
            this.btn_error.Text = "Mostrar Errores";
            this.btn_error.Click += new System.EventHandler(this.btn_error_Click);
            // 
            // btn_clave
            // 
            this.btn_clave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            this.btn_clave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clave.Name = "btn_clave";
            this.btn_clave.Size = new System.Drawing.Size(26, 26);
            this.btn_clave.Text = "Clave Administrador";
            this.btn_clave.Click += new System.EventHandler(this.btn_clave_Click);
            // 
            // btn_log
            // 
            this.btn_log.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_log.Image = ((System.Drawing.Image)(resources.GetObject("btn_log.Image")));
            this.btn_log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(26, 26);
            this.btn_log.Text = "Auditoria";
            this.btn_log.ToolTipText = "Auditoria";
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 26);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(7, 59);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(95, 13);
            this.label33.TabIndex = 74;
            this.label33.Text = "Observaciones:";
            // 
            // glosa
            // 
            this.glosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glosa.Location = new System.Drawing.Point(100, 44);
            this.glosa.Multiline = true;
            this.glosa.Name = "glosa";
            this.glosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.glosa.Size = new System.Drawing.Size(489, 49);
            this.glosa.TabIndex = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fechdoc);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.userinventario);
            this.groupBox1.Controls.Add(this.glosa);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.ubic);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Location = new System.Drawing.Point(3, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 98);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos:";
            // 
            // userinventario
            // 
            this.userinventario.Location = new System.Drawing.Point(279, 18);
            this.userinventario.MaxLength = 10;
            this.userinventario.Name = "userinventario";
            this.userinventario.Size = new System.Drawing.Size(221, 21);
            this.userinventario.TabIndex = 39;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(195, 22);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 13);
            this.label31.TabIndex = 38;
            this.label31.Text = "Responsable:";
            // 
            // ubic
            // 
            this.ubic.Location = new System.Drawing.Point(100, 18);
            this.ubic.MaxLength = 10;
            this.ubic.Name = "ubic";
            this.ubic.Size = new System.Drawing.Size(87, 21);
            this.ubic.TabIndex = 37;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(27, 22);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(75, 13);
            this.label30.TabIndex = 36;
            this.label30.Text = "Ubic/Ruma:";
            // 
            // Frm_digitacion_inv_rollo
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(689, 516);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.griddetallemov);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_digitacion_inv_rollo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< ... Inventariado ...>>";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_digitacion_inv_FormClosing);
            this.Load += new System.EventHandler(this.Frm_digitacion_inv_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_digitacion_inv_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddetallemov)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_editar;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_grabar;
        private System.Windows.Forms.ToolStripButton btn_eliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_primero;
        private System.Windows.Forms.ToolStripButton btn_anterior;
        private System.Windows.Forms.ToolStripButton btn_siguiente;
        private System.Windows.Forms.ToolStripButton btn_ultimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_detanadir;
        private System.Windows.Forms.ToolStripButton btn_deteliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_log;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox itemsT;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox totpzas;
        internal System.Windows.Forms.DataGridView griddetallemov;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.ToolStripButton btnImprimirNoval;
        internal System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox glosa;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox userinventario;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.TextBox ubic;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox numdoc;
        internal System.Windows.Forms.ComboBox tipodoc;
        internal System.Windows.Forms.TextBox serdoc;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DateTimePicker fechdoc;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox totpzas2;
        private System.Windows.Forms.ToolStripButton btn_import;
        private System.Windows.Forms.DataGridViewTextBoxColumn rollo;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn stocklibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockfisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn diferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn costopromlibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn costopromfisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.ToolStripButton btn_error;
        private DevExpress.XtraEditors.SimpleButton btn_search;
        private System.Windows.Forms.TextBox rollo_search;

    }
}