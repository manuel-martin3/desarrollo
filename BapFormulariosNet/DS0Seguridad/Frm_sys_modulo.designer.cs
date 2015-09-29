namespace BapFormulariosNet.DS0Seguridad
{
    partial class Frm_sys_modulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sys_modulo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.moduloshort = new System.Windows.Forms.TextBox();
            this.dominioname = new System.Windows.Forms.TextBox();
            this.dominioid = new System.Windows.Forms.TextBox();
            this.mensaje = new System.Windows.Forms.Label();
            this.moduloname = new System.Windows.Forms.TextBox();
            this.moduloid = new System.Windows.Forms.TextBox();
            this.gridmodulo = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gdominioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmoduloid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmoduloname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulocompuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdominioname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmoduloshort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpedaprob = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gpedtienda = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gafectacosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulodesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Botonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmodulo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.Botonera.Size = new System.Drawing.Size(609, 29);
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
            // moduloshort
            // 
            this.moduloshort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.moduloshort.Location = new System.Drawing.Point(521, 76);
            this.moduloshort.MaxLength = 2;
            this.moduloshort.Name = "moduloshort";
            this.moduloshort.Size = new System.Drawing.Size(48, 21);
            this.moduloshort.TabIndex = 6;
            // 
            // dominioname
            // 
            this.dominioname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dominioname.Location = new System.Drawing.Point(160, 30);
            this.dominioname.Name = "dominioname";
            this.dominioname.Size = new System.Drawing.Size(259, 21);
            this.dominioname.TabIndex = 3;
            // 
            // dominioid
            // 
            this.dominioid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dominioid.Location = new System.Drawing.Point(111, 30);
            this.dominioid.MaxLength = 2;
            this.dominioid.Name = "dominioid";
            this.dominioid.Size = new System.Drawing.Size(48, 21);
            this.dominioid.TabIndex = 2;
            this.dominioid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dominioid_KeyUp);
            // 
            // mensaje
            // 
            this.mensaje.AutoSize = true;
            this.mensaje.BackColor = System.Drawing.Color.Transparent;
            this.mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje.ForeColor = System.Drawing.Color.Transparent;
            this.mensaje.Location = new System.Drawing.Point(174, 56);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(41, 13);
            this.mensaje.TabIndex = 26;
            this.mensaje.Text = "label3";
            // 
            // moduloname
            // 
            this.moduloname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.moduloname.Location = new System.Drawing.Point(111, 75);
            this.moduloname.Name = "moduloname";
            this.moduloname.Size = new System.Drawing.Size(308, 21);
            this.moduloname.TabIndex = 5;
            // 
            // moduloid
            // 
            this.moduloid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.moduloid.Location = new System.Drawing.Point(111, 53);
            this.moduloid.MaxLength = 4;
            this.moduloid.Name = "moduloid";
            this.moduloid.Size = new System.Drawing.Size(48, 21);
            this.moduloid.TabIndex = 4;
            this.moduloid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.moduloid_KeyDown);
            this.moduloid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.moduloid_KeyUp);
            // 
            // gridmodulo
            // 
            this.gridmodulo.AllowUserToAddRows = false;
            this.gridmodulo.AllowUserToDeleteRows = false;
            this.gridmodulo.AllowUserToResizeColumns = false;
            this.gridmodulo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridmodulo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridmodulo.ColumnHeadersHeight = 20;
            this.gridmodulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gdominioid,
            this.gmoduloid,
            this.gmoduloname,
            this.modulocompuesto,
            this.gdominioname,
            this.gmoduloshort,
            this.gpedaprob,
            this.gpedtienda,
            this.gafectacosto,
            this.status,
            this.usuar,
            this.fecre,
            this.feact,
            this.modulodesc});
            this.gridmodulo.Location = new System.Drawing.Point(0, 139);
            this.gridmodulo.MultiSelect = false;
            this.gridmodulo.Name = "gridmodulo";
            this.gridmodulo.RowHeadersVisible = false;
            this.gridmodulo.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridmodulo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridmodulo.RowTemplate.Height = 20;
            this.gridmodulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridmodulo.Size = new System.Drawing.Size(609, 443);
            this.gridmodulo.TabIndex = 7;
            this.gridmodulo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmodulo_CellClick);
            this.gridmodulo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmodulo_CellEnter);
            this.gridmodulo.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmodulo_CellLeave);
            this.gridmodulo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridmodulo_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.moduloshort);
            this.panel1.Controls.Add(this.moduloname);
            this.panel1.Controls.Add(this.dominioname);
            this.panel1.Controls.Add(this.moduloid);
            this.panel1.Controls.Add(this.dominioid);
            this.panel1.Controls.Add(this.mensaje);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 103);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(439, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Abreviatura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Modulo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(48, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Dominio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(173, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(255, 24);
            this.label11.TabIndex = 31;
            this.label11.Text = "REGISTRO DE MODULOS";
            // 
            // gdominioid
            // 
            this.gdominioid.DataPropertyName = "dominioid";
            this.gdominioid.HeaderText = "Dominio";
            this.gdominioid.Name = "gdominioid";
            this.gdominioid.Visible = false;
            // 
            // gmoduloid
            // 
            this.gmoduloid.DataPropertyName = "moduloid";
            this.gmoduloid.HeaderText = "Código";
            this.gmoduloid.Name = "gmoduloid";
            this.gmoduloid.Width = 50;
            // 
            // gmoduloname
            // 
            this.gmoduloname.DataPropertyName = "moduloname";
            this.gmoduloname.HeaderText = "Módulo";
            this.gmoduloname.Name = "gmoduloname";
            this.gmoduloname.Width = 300;
            // 
            // modulocompuesto
            // 
            this.modulocompuesto.DataPropertyName = "modulocompuesto";
            this.modulocompuesto.HeaderText = "modulocompuesto";
            this.modulocompuesto.Name = "modulocompuesto";
            this.modulocompuesto.Visible = false;
            // 
            // gdominioname
            // 
            this.gdominioname.DataPropertyName = "dominioname";
            this.gdominioname.HeaderText = "Dominio";
            this.gdominioname.Name = "gdominioname";
            this.gdominioname.Width = 180;
            // 
            // gmoduloshort
            // 
            this.gmoduloshort.DataPropertyName = "moduloshort";
            this.gmoduloshort.HeaderText = "Sigla";
            this.gmoduloshort.Name = "gmoduloshort";
            this.gmoduloshort.Width = 50;
            // 
            // gpedaprob
            // 
            this.gpedaprob.DataPropertyName = "pedaprob";
            this.gpedaprob.HeaderText = "pedaprob";
            this.gpedaprob.Name = "gpedaprob";
            this.gpedaprob.Visible = false;
            // 
            // gpedtienda
            // 
            this.gpedtienda.DataPropertyName = "pedtienda";
            this.gpedtienda.HeaderText = "pedtienda";
            this.gpedtienda.Name = "gpedtienda";
            this.gpedtienda.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gpedtienda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gpedtienda.Visible = false;
            // 
            // gafectacosto
            // 
            this.gafectacosto.DataPropertyName = "afectacosto";
            this.gafectacosto.HeaderText = "afectacosto";
            this.gafectacosto.Name = "gafectacosto";
            this.gafectacosto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gafectacosto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gafectacosto.Visible = false;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.Visible = false;
            // 
            // usuar
            // 
            this.usuar.DataPropertyName = "usuar";
            this.usuar.HeaderText = "usuar";
            this.usuar.Name = "usuar";
            this.usuar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.usuar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usuar.Visible = false;
            // 
            // fecre
            // 
            this.fecre.DataPropertyName = "fecre";
            this.fecre.HeaderText = "fecre";
            this.fecre.Name = "fecre";
            this.fecre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fecre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fecre.Visible = false;
            // 
            // feact
            // 
            this.feact.DataPropertyName = "feact";
            this.feact.HeaderText = "feact";
            this.feact.Name = "feact";
            this.feact.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.feact.Visible = false;
            // 
            // modulodesc
            // 
            this.modulodesc.DataPropertyName = "modulodesc";
            this.modulodesc.HeaderText = "modulodesc";
            this.modulodesc.Name = "modulodesc";
            this.modulodesc.Visible = false;
            // 
            // Frm_sys_modulo
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(609, 585);
            this.Controls.Add(this.gridmodulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_sys_modulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Mantenimientos de Modulos";
            this.Activated += new System.EventHandler(this.Frm_sys_modulo_Activated);
            this.Load += new System.EventHandler(this.Frm_sys_modulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_sys_modulo_KeyDown);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmodulo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        internal System.Windows.Forms.DataGridView gridmodulo;
        internal System.Windows.Forms.TextBox moduloid;
        internal System.Windows.Forms.TextBox moduloname;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.Label mensaje;
        internal System.Windows.Forms.TextBox dominioname;
        internal System.Windows.Forms.TextBox dominioid;
        internal System.Windows.Forms.TextBox moduloshort;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdominioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmoduloid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmoduloname;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulocompuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdominioname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmoduloshort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gpedaprob;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gpedtienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn gafectacosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecre;
        private System.Windows.Forms.DataGridViewTextBoxColumn feact;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulodesc;

    }
}