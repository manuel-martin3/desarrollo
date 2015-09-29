namespace BapFormulariosNet.MERCADERIA.CATALOGO
{
    partial class Frm_tarjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_tarjeta));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_criterio = new System.Windows.Forms.TextBox();
            this.gridTarjeta = new System.Windows.Forms.DataGridView();
            this._tarjetaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tarjetaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tarjetalogo = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.go_foto = new System.Windows.Forms.PictureBox();
            this.tarjetaid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tarjetaname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btn_log = new System.Windows.Forms.ToolStripButton();
            this.btn_foto = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTarjeta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.go_foto)).BeginInit();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_busqueda);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_criterio);
            this.groupBox2.Location = new System.Drawing.Point(6, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 49);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.BackColor = System.Drawing.Color.Transparent;
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(324, 12);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(79, 33);
            this.btn_busqueda.TabIndex = 18;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = false;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Descripción:";
            // 
            // txt_criterio
            // 
            this.txt_criterio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_criterio.Location = new System.Drawing.Point(75, 19);
            this.txt_criterio.MaxLength = 0;
            this.txt_criterio.Name = "txt_criterio";
            this.txt_criterio.Size = new System.Drawing.Size(242, 21);
            this.txt_criterio.TabIndex = 17;
            this.txt_criterio.TextChanged += new System.EventHandler(this.txt_criterio_TextChanged);
            this.txt_criterio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_criterio_KeyDown);
            // 
            // gridTarjeta
            // 
            this.gridTarjeta.AllowUserToAddRows = false;
            this.gridTarjeta.AllowUserToDeleteRows = false;
            this.gridTarjeta.AllowUserToResizeColumns = false;
            this.gridTarjeta.AllowUserToResizeRows = false;
            this.gridTarjeta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridTarjeta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTarjeta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTarjeta.ColumnHeadersHeight = 20;
            this.gridTarjeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._tarjetaid,
            this._tarjetaname,
            this._tarjetalogo});
            this.gridTarjeta.Location = new System.Drawing.Point(6, 199);
            this.gridTarjeta.MultiSelect = false;
            this.gridTarjeta.Name = "gridTarjeta";
            this.gridTarjeta.RowHeadersVisible = false;
            this.gridTarjeta.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridTarjeta.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridTarjeta.RowTemplate.Height = 20;
            this.gridTarjeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridTarjeta.Size = new System.Drawing.Size(420, 214);
            this.gridTarjeta.TabIndex = 19;
            this.gridTarjeta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTarjeta_CellClick);
            this.gridTarjeta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTarjeta_CellContentClick);
            this.gridTarjeta.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTarjeta_CellEnter);
            this.gridTarjeta.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTarjeta_CellLeave);
            this.gridTarjeta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridTarjeta_KeyUp);
            // 
            // _tarjetaid
            // 
            this._tarjetaid.DataPropertyName = "tarjetaid";
            this._tarjetaid.Frozen = true;
            this._tarjetaid.HeaderText = "Cód";
            this._tarjetaid.Name = "_tarjetaid";
            this._tarjetaid.Width = 25;
            // 
            // _tarjetaname
            // 
            this._tarjetaname.DataPropertyName = "tarjetaname";
            this._tarjetaname.Frozen = true;
            this._tarjetaname.HeaderText = "Nombre";
            this._tarjetaname.Name = "_tarjetaname";
            this._tarjetaname.Width = 300;
            // 
            // _tarjetalogo
            // 
            this._tarjetalogo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._tarjetalogo.DataPropertyName = "tarjetalogo";
            this._tarjetalogo.Frozen = true;
            this._tarjetalogo.HeaderText = "Foto";
            this._tarjetalogo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this._tarjetalogo.MinimumWidth = 15;
            this._tarjetalogo.Name = "_tarjetalogo";
            this._tarjetalogo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._tarjetalogo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._tarjetalogo.Width = 54;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.go_foto);
            this.groupBox1.Controls.Add(this.tarjetaid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tarjetaname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 69);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // go_foto
            // 
            this.go_foto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.go_foto.ErrorImage = global::BapFormulariosNet.Properties.Resources.error;
            this.go_foto.InitialImage = global::BapFormulariosNet.Properties.Resources.error;
            this.go_foto.Location = new System.Drawing.Point(331, 11);
            this.go_foto.Name = "go_foto";
            this.go_foto.Size = new System.Drawing.Size(74, 46);
            this.go_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.go_foto.TabIndex = 64;
            this.go_foto.TabStop = false;
            // 
            // tarjetaid
            // 
            this.tarjetaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarjetaid.Location = new System.Drawing.Point(91, 16);
            this.tarjetaid.MaxLength = 3;
            this.tarjetaid.Name = "tarjetaid";
            this.tarjetaid.Size = new System.Drawing.Size(48, 20);
            this.tarjetaid.TabIndex = 11;
            this.tarjetaid.Text = "ventas al exterior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nom - Tarj:";
            // 
            // tarjetaname
            // 
            this.tarjetaname.Location = new System.Drawing.Point(91, 37);
            this.tarjetaname.Name = "tarjetaname";
            this.tarjetaname.Size = new System.Drawing.Size(225, 21);
            this.tarjetaname.TabIndex = 12;
            this.tarjetaname.Text = "ventas al exterior";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Código:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 34);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(163, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "TARJETAS";
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
            this.btn_log,
            this.btn_foto,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(432, 29);
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
            // btn_foto
            // 
            this.btn_foto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_foto.Image = global::BapFormulariosNet.Properties.Resources.Camera__3_;
            this.btn_foto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_foto.Name = "btn_foto";
            this.btn_foto.Size = new System.Drawing.Size(26, 26);
            this.btn_foto.Text = "toolStripButton1";
            this.btn_foto.ToolTipText = "Cargar Foto";
            this.btn_foto.Click += new System.EventHandler(this.btn_foto_Click);
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
            // Frm_tarjeta
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(432, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gridTarjeta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_tarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Tarjetas";
            this.Load += new System.EventHandler(this.Frm_Tarjeta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Tarjeta_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTarjeta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.go_foto)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btn_log;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox tarjetaname;
        internal System.Windows.Forms.DataGridView gridTarjeta;
        internal System.Windows.Forms.TextBox tarjetaid;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_busqueda;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txt_criterio;
        private System.Windows.Forms.PictureBox go_foto;
        private System.Windows.Forms.ToolStripButton btn_foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tarjetaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tarjetaname;
        private System.Windows.Forms.DataGridViewImageColumn _tarjetalogo;

    }
}