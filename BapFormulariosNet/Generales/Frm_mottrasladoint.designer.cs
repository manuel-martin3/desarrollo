namespace BapFormulariosNet.Generales
{
    partial class Frm_mottrasladoint
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_mottrasladoint));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbo_buscar = new System.Windows.Forms.ComboBox();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.txt_criterio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridmottrasladoint = new System.Windows.Forms.DataGridView();
            this.gmoduloid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmoduloname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmottrasladointid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmottrasladointname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gesventa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gescompra = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gtipmov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcodigosunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tipmov1 = new System.Windows.Forms.RadioButton();
            this.tipmov2 = new System.Windows.Forms.RadioButton();
            this.escompra = new System.Windows.Forms.CheckBox();
            this.esventa = new System.Windows.Forms.CheckBox();
            this.codigosunat = new System.Windows.Forms.TextBox();
            this.moduloname = new System.Windows.Forms.TextBox();
            this.moduloid = new System.Windows.Forms.TextBox();
            this.mottrasladointid = new System.Windows.Forms.TextBox();
            this.mottrasladointname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
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
            this.btn_buscar = new System.Windows.Forms.ToolStripButton();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_log = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmottrasladoint)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cbo_buscar);
            this.groupBox3.Controls.Add(this.btn_busqueda);
            this.groupBox3.Controls.Add(this.txt_criterio);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(3, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 48);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar";
            // 
            // cbo_buscar
            // 
            this.cbo_buscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_buscar.Location = new System.Drawing.Point(33, 18);
            this.cbo_buscar.Name = "cbo_buscar";
            this.cbo_buscar.Size = new System.Drawing.Size(192, 21);
            this.cbo_buscar.TabIndex = 43;
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(507, 12);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(75, 30);
            this.btn_busqueda.TabIndex = 28;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // txt_criterio
            // 
            this.txt_criterio.Location = new System.Drawing.Point(227, 18);
            this.txt_criterio.MaxLength = 0;
            this.txt_criterio.Name = "txt_criterio";
            this.txt_criterio.Size = new System.Drawing.Size(279, 21);
            this.txt_criterio.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Por:";
            // 
            // gridmottrasladoint
            // 
            this.gridmottrasladoint.AllowUserToAddRows = false;
            this.gridmottrasladoint.AllowUserToDeleteRows = false;
            this.gridmottrasladoint.AllowUserToResizeColumns = false;
            this.gridmottrasladoint.AllowUserToResizeRows = false;
            this.gridmottrasladoint.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridmottrasladoint.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridmottrasladoint.ColumnHeadersHeight = 30;
            this.gridmottrasladoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gmoduloid,
            this.gmoduloname,
            this.gmottrasladointid,
            this.gmottrasladointname,
            this.gesventa,
            this.gescompra,
            this.gtipmov,
            this.gcodigosunat});
            this.gridmottrasladoint.Location = new System.Drawing.Point(0, 217);
            this.gridmottrasladoint.MultiSelect = false;
            this.gridmottrasladoint.Name = "gridmottrasladoint";
            this.gridmottrasladoint.RowHeadersVisible = false;
            this.gridmottrasladoint.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridmottrasladoint.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridmottrasladoint.RowTemplate.Height = 20;
            this.gridmottrasladoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridmottrasladoint.Size = new System.Drawing.Size(595, 355);
            this.gridmottrasladoint.TabIndex = 29;
            this.gridmottrasladoint.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmottrasladoint_CellClick);
            this.gridmottrasladoint.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmottrasladoint_CellEnter);
            this.gridmottrasladoint.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmottrasladoint_CellLeave);
            this.gridmottrasladoint.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridmottrasladoint_KeyUp);
            // 
            // gmoduloid
            // 
            this.gmoduloid.DataPropertyName = "moduloid";
            this.gmoduloid.HeaderText = "Modulo";
            this.gmoduloid.Name = "gmoduloid";
            this.gmoduloid.Width = 60;
            // 
            // gmoduloname
            // 
            this.gmoduloname.DataPropertyName = "moduloname";
            this.gmoduloname.HeaderText = "moduloname";
            this.gmoduloname.Name = "gmoduloname";
            this.gmoduloname.Visible = false;
            // 
            // gmottrasladointid
            // 
            this.gmottrasladointid.DataPropertyName = "mottrasladointid";
            this.gmottrasladointid.HeaderText = "Código";
            this.gmottrasladointid.Name = "gmottrasladointid";
            this.gmottrasladointid.Width = 60;
            // 
            // gmottrasladointname
            // 
            this.gmottrasladointname.DataPropertyName = "mottrasladointname";
            this.gmottrasladointname.HeaderText = "Descripción";
            this.gmottrasladointname.Name = "gmottrasladointname";
            this.gmottrasladointname.Width = 250;
            // 
            // gesventa
            // 
            this.gesventa.DataPropertyName = "esventa";
            this.gesventa.HeaderText = "Venta";
            this.gesventa.Name = "gesventa";
            this.gesventa.Width = 50;
            // 
            // gescompra
            // 
            this.gescompra.DataPropertyName = "escompra";
            this.gescompra.HeaderText = "Compra";
            this.gescompra.Name = "gescompra";
            this.gescompra.Width = 50;
            // 
            // gtipmov
            // 
            this.gtipmov.DataPropertyName = "tipmov";
            this.gtipmov.HeaderText = "MOV";
            this.gtipmov.Name = "gtipmov";
            this.gtipmov.Width = 50;
            // 
            // gcodigosunat
            // 
            this.gcodigosunat.DataPropertyName = "codigosunat";
            this.gcodigosunat.HeaderText = "Cod. Sunat";
            this.gcodigosunat.Name = "gcodigosunat";
            this.gcodigosunat.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tipmov1);
            this.groupBox2.Controls.Add(this.tipmov2);
            this.groupBox2.Location = new System.Drawing.Point(393, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 38);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tip Mov";
            // 
            // tipmov1
            // 
            this.tipmov1.AutoSize = true;
            this.tipmov1.Location = new System.Drawing.Point(17, 16);
            this.tipmov1.Name = "tipmov1";
            this.tipmov1.Size = new System.Drawing.Size(62, 17);
            this.tipmov1.TabIndex = 28;
            this.tipmov1.TabStop = true;
            this.tipmov1.Text = "Ingreso";
            this.tipmov1.UseVisualStyleBackColor = true;
            // 
            // tipmov2
            // 
            this.tipmov2.AutoSize = true;
            this.tipmov2.Location = new System.Drawing.Point(83, 16);
            this.tipmov2.Name = "tipmov2";
            this.tipmov2.Size = new System.Drawing.Size(53, 17);
            this.tipmov2.TabIndex = 29;
            this.tipmov2.TabStop = true;
            this.tipmov2.Text = "Salida";
            this.tipmov2.UseVisualStyleBackColor = true;
            // 
            // escompra
            // 
            this.escompra.AutoSize = true;
            this.escompra.BackColor = System.Drawing.Color.Transparent;
            this.escompra.Location = new System.Drawing.Point(397, 84);
            this.escompra.Name = "escompra";
            this.escompra.Size = new System.Drawing.Size(75, 17);
            this.escompra.TabIndex = 26;
            this.escompra.Text = "Es compra";
            this.escompra.UseVisualStyleBackColor = false;
            // 
            // esventa
            // 
            this.esventa.AutoSize = true;
            this.esventa.BackColor = System.Drawing.Color.Transparent;
            this.esventa.Location = new System.Drawing.Point(479, 84);
            this.esventa.Name = "esventa";
            this.esventa.Size = new System.Drawing.Size(68, 17);
            this.esventa.TabIndex = 25;
            this.esventa.Text = "Es venta";
            this.esventa.UseVisualStyleBackColor = false;
            // 
            // codigosunat
            // 
            this.codigosunat.Location = new System.Drawing.Point(102, 92);
            this.codigosunat.MaxLength = 2;
            this.codigosunat.Name = "codigosunat";
            this.codigosunat.Size = new System.Drawing.Size(86, 21);
            this.codigosunat.TabIndex = 24;
            // 
            // moduloname
            // 
            this.moduloname.Location = new System.Drawing.Point(149, 9);
            this.moduloname.Name = "moduloname";
            this.moduloname.Size = new System.Drawing.Size(211, 21);
            this.moduloname.TabIndex = 15;
            // 
            // moduloid
            // 
            this.moduloid.Location = new System.Drawing.Point(100, 9);
            this.moduloid.MaxLength = 4;
            this.moduloid.Name = "moduloid";
            this.moduloid.Size = new System.Drawing.Size(48, 21);
            this.moduloid.TabIndex = 14;
            this.moduloid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.moduloid_KeyDown);
            this.moduloid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.moduloid_KeyUp);
            // 
            // mottrasladointid
            // 
            this.mottrasladointid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mottrasladointid.Location = new System.Drawing.Point(102, 49);
            this.mottrasladointid.MaxLength = 2;
            this.mottrasladointid.Name = "mottrasladointid";
            this.mottrasladointid.Size = new System.Drawing.Size(86, 20);
            this.mottrasladointid.TabIndex = 20;
            // 
            // mottrasladointname
            // 
            this.mottrasladointname.Location = new System.Drawing.Point(102, 70);
            this.mottrasladointname.Name = "mottrasladointname";
            this.mottrasladointname.Size = new System.Drawing.Size(259, 21);
            this.mottrasladointname.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.moduloid);
            this.panel1.Controls.Add(this.moduloname);
            this.panel1.Controls.Add(this.codigosunat);
            this.panel1.Controls.Add(this.mottrasladointid);
            this.panel1.Controls.Add(this.mottrasladointname);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 125);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Cod Sunat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Motivo Interno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Código:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(47, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Modulo:";
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
            this.btn_buscar,
            this.btn_clave,
            this.btn_log,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(597, 29);
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
            // btn_buscar
            // 
            this.btn_buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(26, 26);
            this.btn_buscar.Text = "toolStripButton15";
            this.btn_buscar.ToolTipText = "Buscar";
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
            // btn_log
            // 
            this.btn_log.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_log.Image = ((System.Drawing.Image)(resources.GetObject("btn_log.Image")));
            this.btn_log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(26, 26);
            this.btn_log.Text = "toolStripButton16";
            this.btn_log.ToolTipText = "Auditoria";
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
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
            // Frm_mottrasladoint
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(597, 592);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gridmottrasladoint);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.escompra);
            this.Controls.Add(this.esventa);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_mottrasladoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Motivo de Traslado Interno";
            this.Activated += new System.EventHandler(this.Frm_mottrasladoint_Activated);
            this.Load += new System.EventHandler(this.Frm_mottrasladoint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_mottrasladoint_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmottrasladoint)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton btn_buscar;
        private System.Windows.Forms.ToolStripButton btn_log;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox mottrasladointname;
        internal System.Windows.Forms.DataGridView gridmottrasladoint;
        private System.Windows.Forms.Button btn_busqueda;
        internal System.Windows.Forms.TextBox txt_criterio;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox mottrasladointid;
        internal System.Windows.Forms.TextBox moduloid;
        internal System.Windows.Forms.TextBox moduloname;
        internal System.Windows.Forms.TextBox codigosunat;
        internal System.Windows.Forms.ComboBox cbo_buscar;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton tipmov1;
        private System.Windows.Forms.RadioButton tipmov2;
        private System.Windows.Forms.CheckBox escompra;
        private System.Windows.Forms.CheckBox esventa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmoduloid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmoduloname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmottrasladointid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmottrasladointname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gesventa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gescompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn gtipmov;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcodigosunat;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label8;

    }
}