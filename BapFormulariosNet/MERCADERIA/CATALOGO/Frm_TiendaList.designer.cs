namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    partial class Frm_TiendaList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TiendaList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridtienda = new System.Windows.Forms.DataGridView();
            this.g1tiendalist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g1tiendalistname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tiendalistname = new System.Windows.Forms.TextBox();
            this.tiendalist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.locid = new System.Windows.Forms.TextBox();
            this.localname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_primero = new System.Windows.Forms.ToolStripButton();
            this.btn_anterior = new System.Windows.Forms.ToolStripButton();
            this.btn_siguiente = new System.Windows.Forms.ToolStripButton();
            this.btn_ultimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.control = new System.Windows.Forms.TabControl();
            this.tab01 = new System.Windows.Forms.TabPage();
            this.tab02 = new System.Windows.Forms.TabPage();
            this.dgb_tiendaitem = new System.Windows.Forms.DataGridView();
            this.g2tiendalist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2tiendalistname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2localname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.tiendaname2 = new System.Windows.Forms.TextBox();
            this.tiendalist2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridtienda)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.control.SuspendLayout();
            this.tab01.SuspendLayout();
            this.tab02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_tiendaitem)).BeginInit();
            this.SuspendLayout();
            // 
            // gridtienda
            // 
            this.gridtienda.AllowUserToAddRows = false;
            this.gridtienda.AllowUserToDeleteRows = false;
            this.gridtienda.AllowUserToResizeColumns = false;
            this.gridtienda.AllowUserToResizeRows = false;
            this.gridtienda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridtienda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridtienda.ColumnHeadersHeight = 30;
            this.gridtienda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g1tiendalist,
            this.g1tiendalistname,
            this.usuar,
            this.feact});
            this.gridtienda.Location = new System.Drawing.Point(21, 95);
            this.gridtienda.MultiSelect = false;
            this.gridtienda.Name = "gridtienda";
            this.gridtienda.RowHeadersVisible = false;
            this.gridtienda.RowHeadersWidth = 10;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridtienda.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridtienda.RowTemplate.Height = 20;
            this.gridtienda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridtienda.Size = new System.Drawing.Size(419, 200);
            this.gridtienda.TabIndex = 19;
            this.gridtienda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridgrupo_CellClick);
            this.gridtienda.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridgrupo_CellEnter);
            this.gridtienda.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridgrupo_CellLeave);
            this.gridtienda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridgrupo_KeyUp);
            // 
            // g1tiendalist
            // 
            this.g1tiendalist.DataPropertyName = "tiendalist";
            this.g1tiendalist.HeaderText = "Id";
            this.g1tiendalist.Name = "g1tiendalist";
            this.g1tiendalist.Width = 20;
            // 
            // g1tiendalistname
            // 
            this.g1tiendalistname.DataPropertyName = "tiendalistname";
            this.g1tiendalistname.HeaderText = "Denominación";
            this.g1tiendalistname.Name = "g1tiendalistname";
            this.g1tiendalistname.Width = 150;
            // 
            // usuar
            // 
            this.usuar.DataPropertyName = "usuar";
            this.usuar.HeaderText = "usuar";
            this.usuar.Name = "usuar";
            this.usuar.Visible = false;
            // 
            // feact
            // 
            this.feact.DataPropertyName = "feact";
            this.feact.HeaderText = "feact";
            this.feact.Name = "feact";
            this.feact.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tiendalistname);
            this.groupBox1.Controls.Add(this.tiendalist);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(20, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 70);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // tiendalistname
            // 
            this.tiendalistname.Location = new System.Drawing.Point(64, 37);
            this.tiendalistname.Name = "tiendalistname";
            this.tiendalistname.Size = new System.Drawing.Size(218, 21);
            this.tiendalistname.TabIndex = 14;
            this.tiendalistname.Text = "ventas al exterior";
            // 
            // tiendalist
            // 
            this.tiendalist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiendalist.Location = new System.Drawing.Point(64, 16);
            this.tiendalist.MaxLength = 3;
            this.tiendalist.Name = "tiendalist";
            this.tiendalist.Size = new System.Drawing.Size(33, 20);
            this.tiendalist.TabIndex = 11;
            this.tiendalist.Text = "ventas al exterior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tienda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Código:";
            // 
            // locid
            // 
            this.locid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locid.Location = new System.Drawing.Point(64, 21);
            this.locid.MaxLength = 3;
            this.locid.Name = "locid";
            this.locid.Size = new System.Drawing.Size(33, 20);
            this.locid.TabIndex = 13;
            this.locid.Text = "ventas al exterior";
            this.locid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.locid_KeyDown);
            // 
            // localname
            // 
            this.localname.Location = new System.Drawing.Point(98, 21);
            this.localname.Name = "localname";
            this.localname.Size = new System.Drawing.Size(218, 21);
            this.localname.TabIndex = 12;
            this.localname.Text = "ventas al exterior";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 33);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(172, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Lista de Tiendas";
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
            this.btn_imprimir,
            this.toolStripSeparator1,
            this.btn_primero,
            this.btn_anterior,
            this.btn_siguiente,
            this.btn_ultimo,
            this.toolStripSeparator2,
            this.btn_clave,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(502, 29);
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
            // btn_clave
            // 
            this.btn_clave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_clave.Image = global::BapFormulariosNet.Properties.Resources.btn_Lock20;
            this.btn_clave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clave.Name = "btn_clave";
            this.btn_clave.Size = new System.Drawing.Size(26, 26);
            this.btn_clave.Text = "toolStripButton1";
            this.btn_clave.ToolTipText = "Clave Administrador";
            this.btn_clave.Click += new System.EventHandler(this.btn_clave_Click);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_new);
            this.groupBox3.Controls.Add(this.btn_add);
            this.groupBox3.Controls.Add(this.locid);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.localname);
            this.groupBox3.Location = new System.Drawing.Point(17, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 48);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Items:";
            // 
            // btn_new
            // 
            this.btn_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new.Image = global::BapFormulariosNet.Properties.Resources.go_new3;
            this.btn_new.Location = new System.Drawing.Point(332, 12);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(28, 30);
            this.btn_new.TabIndex = 106;
            this.toolTip1.SetToolTip(this.btn_new, "Nuevo");
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_add
            // 
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.Image = global::BapFormulariosNet.Properties.Resources.go_add;
            this.btn_add.Location = new System.Drawing.Point(366, 12);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(28, 30);
            this.btn_add.TabIndex = 105;
            this.toolTip1.SetToolTip(this.btn_add, "Agregar Local");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Local:";
            // 
            // control
            // 
            this.control.Controls.Add(this.tab01);
            this.control.Controls.Add(this.tab02);
            this.control.Location = new System.Drawing.Point(12, 77);
            this.control.Name = "control";
            this.control.SelectedIndex = 0;
            this.control.Size = new System.Drawing.Size(478, 365);
            this.control.TabIndex = 21;
            this.control.SelectedIndexChanged += new System.EventHandler(this.control_SelectedIndexChanged);
            // 
            // tab01
            // 
            this.tab01.Controls.Add(this.gridtienda);
            this.tab01.Controls.Add(this.groupBox1);
            this.tab01.Location = new System.Drawing.Point(4, 22);
            this.tab01.Name = "tab01";
            this.tab01.Padding = new System.Windows.Forms.Padding(3);
            this.tab01.Size = new System.Drawing.Size(470, 339);
            this.tab01.TabIndex = 0;
            this.tab01.Text = "Lista";
            this.tab01.UseVisualStyleBackColor = true;
            // 
            // tab02
            // 
            this.tab02.Controls.Add(this.dgb_tiendaitem);
            this.tab02.Controls.Add(this.label4);
            this.tab02.Controls.Add(this.groupBox3);
            this.tab02.Controls.Add(this.tiendaname2);
            this.tab02.Controls.Add(this.tiendalist2);
            this.tab02.Location = new System.Drawing.Point(4, 22);
            this.tab02.Name = "tab02";
            this.tab02.Padding = new System.Windows.Forms.Padding(3);
            this.tab02.Size = new System.Drawing.Size(470, 339);
            this.tab02.TabIndex = 1;
            this.tab02.Text = "Items";
            this.tab02.UseVisualStyleBackColor = true;
            // 
            // dgb_tiendaitem
            // 
            this.dgb_tiendaitem.AllowUserToAddRows = false;
            this.dgb_tiendaitem.AllowUserToDeleteRows = false;
            this.dgb_tiendaitem.AllowUserToResizeColumns = false;
            this.dgb_tiendaitem.AllowUserToResizeRows = false;
            this.dgb_tiendaitem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgb_tiendaitem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgb_tiendaitem.ColumnHeadersHeight = 30;
            this.dgb_tiendaitem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.g2tiendalist,
            this.g2tiendalistname,
            this.g2local,
            this.g2localname});
            this.dgb_tiendaitem.Location = new System.Drawing.Point(18, 97);
            this.dgb_tiendaitem.MultiSelect = false;
            this.dgb_tiendaitem.Name = "dgb_tiendaitem";
            this.dgb_tiendaitem.ReadOnly = true;
            this.dgb_tiendaitem.RowHeadersVisible = false;
            this.dgb_tiendaitem.RowHeadersWidth = 10;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgb_tiendaitem.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgb_tiendaitem.RowTemplate.Height = 20;
            this.dgb_tiendaitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgb_tiendaitem.Size = new System.Drawing.Size(419, 227);
            this.dgb_tiendaitem.TabIndex = 109;
            this.dgb_tiendaitem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_tiendaitem_CellClick);
            this.dgb_tiendaitem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_tiendaitem_CellContentClick);
            this.dgb_tiendaitem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgb_tiendaitem_KeyUp);
            // 
            // g2tiendalist
            // 
            this.g2tiendalist.DataPropertyName = "tiendalist";
            this.g2tiendalist.HeaderText = "Id";
            this.g2tiendalist.Name = "g2tiendalist";
            this.g2tiendalist.ReadOnly = true;
            this.g2tiendalist.Width = 20;
            // 
            // g2tiendalistname
            // 
            this.g2tiendalistname.DataPropertyName = "tiendalistname";
            this.g2tiendalistname.HeaderText = "Lista";
            this.g2tiendalistname.Name = "g2tiendalistname";
            this.g2tiendalistname.ReadOnly = true;
            this.g2tiendalistname.Width = 150;
            // 
            // g2local
            // 
            this.g2local.DataPropertyName = "local";
            this.g2local.HeaderText = "Local";
            this.g2local.Name = "g2local";
            this.g2local.ReadOnly = true;
            this.g2local.Width = 40;
            // 
            // g2localname
            // 
            this.g2localname.DataPropertyName = "localname";
            this.g2localname.HeaderText = "Establecimiento";
            this.g2localname.Name = "g2localname";
            this.g2localname.ReadOnly = true;
            this.g2localname.Width = 200;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "Tienda:";
            // 
            // tiendaname2
            // 
            this.tiendaname2.Location = new System.Drawing.Point(117, 11);
            this.tiendaname2.Name = "tiendaname2";
            this.tiendaname2.Size = new System.Drawing.Size(218, 21);
            this.tiendaname2.TabIndex = 107;
            this.tiendaname2.Text = "ventas al exterior";
            // 
            // tiendalist2
            // 
            this.tiendalist2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiendalist2.Location = new System.Drawing.Point(82, 11);
            this.tiendalist2.MaxLength = 3;
            this.tiendalist2.Name = "tiendalist2";
            this.tiendalist2.Size = new System.Drawing.Size(33, 20);
            this.tiendalist2.TabIndex = 14;
            this.tiendalist2.Text = "ventas al exterior";
            // 
            // Frm_TiendaList
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(502, 450);
            this.Controls.Add(this.control);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_TiendaList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Lista de Tiendas";
            this.Activated += new System.EventHandler(this.Frm_grupo_Activated);
            this.Load += new System.EventHandler(this.Frm_TiendaList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_TiendaList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridtienda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.control.ResumeLayout(false);
            this.tab01.ResumeLayout(false);
            this.tab02.ResumeLayout(false);
            this.tab02.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_tiendaitem)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_primero;
        private System.Windows.Forms.ToolStripButton btn_anterior;
        private System.Windows.Forms.ToolStripButton btn_siguiente;
        private System.Windows.Forms.ToolStripButton btn_ultimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox localname;
        internal System.Windows.Forms.DataGridView gridtienda;
        internal System.Windows.Forms.TextBox tiendalist;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btn_clave;
        internal System.Windows.Forms.TextBox locid;
        internal System.Windows.Forms.TextBox tiendalistname;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl control;
        private System.Windows.Forms.TabPage tab01;
        private System.Windows.Forms.TabPage tab02;
        internal System.Windows.Forms.DataGridView dgb_tiendaitem;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox tiendaname2;
        internal System.Windows.Forms.TextBox tiendalist2;
        private System.Windows.Forms.DataGridViewTextBoxColumn g1tiendalist;
        private System.Windows.Forms.DataGridViewTextBoxColumn g1tiendalistname;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn feact;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2tiendalist;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2tiendalistname;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2local;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2localname;

    }
}