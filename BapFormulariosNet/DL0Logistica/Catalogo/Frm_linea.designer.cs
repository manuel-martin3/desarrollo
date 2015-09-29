namespace BapFormulariosNet.DL0Logistica.Catalogo
{
    partial class Frm_linea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_linea));
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
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_log = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.moduloiddes = new System.Windows.Forms.ComboBox();
            this.estructuraid = new System.Windows.Forms.ComboBox();
            this.lineaid = new System.Windows.Forms.TextBox();
            this.lineaname = new System.Windows.Forms.TextBox();
            this.gridlinea = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_busqueda = new System.Windows.Forms.Button();
            this.txt_criterio = new System.Windows.Forms.TextBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.unmed = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.localdes = new System.Windows.Forms.ComboBox();
            this.glineaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glineaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gestructuraid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estructuraname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaalmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctaconsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctavarexist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctacargaimput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nostock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._unmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Botonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridlinea)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.btn_clave,
            this.btn_log,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(540, 29);
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
            // moduloiddes
            // 
            this.moduloiddes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moduloiddes.DropDownWidth = 200;
            this.moduloiddes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduloiddes.FormattingEnabled = true;
            this.moduloiddes.Location = new System.Drawing.Point(110, 13);
            this.moduloiddes.Name = "moduloiddes";
            this.moduloiddes.Size = new System.Drawing.Size(189, 21);
            this.moduloiddes.TabIndex = 16;
            this.moduloiddes.SelectedIndexChanged += new System.EventHandler(this.moduloiddes_SelectedIndexChanged);
            // 
            // estructuraid
            // 
            this.estructuraid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estructuraid.FormattingEnabled = true;
            this.estructuraid.Location = new System.Drawing.Point(110, 80);
            this.estructuraid.Name = "estructuraid";
            this.estructuraid.Size = new System.Drawing.Size(279, 21);
            this.estructuraid.TabIndex = 14;
            // 
            // lineaid
            // 
            this.lineaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaid.Location = new System.Drawing.Point(110, 36);
            this.lineaid.MaxLength = 3;
            this.lineaid.Name = "lineaid";
            this.lineaid.Size = new System.Drawing.Size(48, 20);
            this.lineaid.TabIndex = 11;
            this.lineaid.Text = "ventas al exterior";
            // 
            // lineaname
            // 
            this.lineaname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lineaname.Location = new System.Drawing.Point(110, 57);
            this.lineaname.Name = "lineaname";
            this.lineaname.Size = new System.Drawing.Size(232, 21);
            this.lineaname.TabIndex = 12;
            // 
            // gridlinea
            // 
            this.gridlinea.AllowUserToAddRows = false;
            this.gridlinea.AllowUserToDeleteRows = false;
            this.gridlinea.AllowUserToResizeColumns = false;
            this.gridlinea.AllowUserToResizeRows = false;
            this.gridlinea.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridlinea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridlinea.ColumnHeadersHeight = 20;
            this.gridlinea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.glineaid,
            this.glineaname,
            this.gestructuraid,
            this.estructuraname,
            this.usuar,
            this.feact,
            this.fecre,
            this.ctaalmacen,
            this.ctaconsumo,
            this.ctavarexist,
            this.ctacargaimput,
            this.moduloid,
            this.nostock,
            this._unmed});
            this.gridlinea.Location = new System.Drawing.Point(4, 234);
            this.gridlinea.MultiSelect = false;
            this.gridlinea.Name = "gridlinea";
            this.gridlinea.RowHeadersVisible = false;
            this.gridlinea.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridlinea.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridlinea.RowTemplate.Height = 20;
            this.gridlinea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridlinea.Size = new System.Drawing.Size(532, 304);
            this.gridlinea.TabIndex = 19;
            this.gridlinea.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridlinea_CellClick);
            this.gridlinea.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridlinea_CellEnter);
            this.gridlinea.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridlinea_CellLeave);
            this.gridlinea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridlinea_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 56);
            this.panel1.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(182, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "LINEAS (RUBRO)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Abadi MT Condensed Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 18);
            this.label6.TabIndex = 50;
            this.label6.Text = "Busqueda:";
            // 
            // lineShape2
            // 
            this.lineShape2.BorderWidth = 2;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 9;
            this.lineShape2.X2 = 532;
            this.lineShape2.Y1 = 197;
            this.lineShape2.Y2 = 197;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(540, 541);
            this.shapeContainer1.TabIndex = 51;
            this.shapeContainer1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Descripcion:";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btn_busqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_busqueda.Location = new System.Drawing.Point(381, 201);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(75, 31);
            this.btn_busqueda.TabIndex = 54;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_busqueda.UseVisualStyleBackColor = true;
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // txt_criterio
            // 
            this.txt_criterio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_criterio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_criterio.Location = new System.Drawing.Point(93, 207);
            this.txt_criterio.Name = "txt_criterio";
            this.txt_criterio.Size = new System.Drawing.Size(279, 21);
            this.txt_criterio.TabIndex = 53;
            this.txt_criterio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_criterio_KeyDown);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.unmed);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.localdes);
            this.panelControl1.Controls.Add(this.estructuraid);
            this.panelControl1.Controls.Add(this.lineaid);
            this.panelControl1.Controls.Add(this.moduloiddes);
            this.panelControl1.Controls.Add(this.lineaname);
            this.panelControl1.Location = new System.Drawing.Point(0, 62);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(539, 109);
            this.panelControl1.TabIndex = 56;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(311, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 13);
            this.labelControl5.TabIndex = 105;
            this.labelControl5.Text = "» UNMED:";
            // 
            // unmed
            // 
            this.unmed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unmed.DropDownWidth = 170;
            this.unmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unmed.FormattingEnabled = true;
            this.unmed.Location = new System.Drawing.Point(370, 34);
            this.unmed.Name = "unmed";
            this.unmed.Size = new System.Drawing.Size(146, 21);
            this.unmed.TabIndex = 104;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(16, 83);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(88, 13);
            this.labelControl4.TabIndex = 103;
            this.labelControl4.Text = "» ESTRUCTURA:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(58, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 102;
            this.labelControl3.Text = "» LINEA:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(46, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 101;
            this.labelControl2.Text = "» CODIGO:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(38, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 100;
            this.labelControl1.Text = "» ALMACEN:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(311, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 99;
            this.labelControl7.Text = "» LOCAL:";
            // 
            // localdes
            // 
            this.localdes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localdes.DropDownWidth = 170;
            this.localdes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localdes.FormattingEnabled = true;
            this.localdes.Location = new System.Drawing.Point(370, 11);
            this.localdes.Name = "localdes";
            this.localdes.Size = new System.Drawing.Size(146, 21);
            this.localdes.TabIndex = 98;
            // 
            // glineaid
            // 
            this.glineaid.DataPropertyName = "lineaid";
            this.glineaid.HeaderText = "Código";
            this.glineaid.Name = "glineaid";
            this.glineaid.Width = 60;
            // 
            // glineaname
            // 
            this.glineaname.DataPropertyName = "lineaname";
            this.glineaname.HeaderText = "Línea";
            this.glineaname.Name = "glineaname";
            this.glineaname.Width = 300;
            // 
            // gestructuraid
            // 
            this.gestructuraid.DataPropertyName = "estructuraid";
            this.gestructuraid.HeaderText = "estructuraid";
            this.gestructuraid.Name = "gestructuraid";
            this.gestructuraid.Visible = false;
            this.gestructuraid.Width = 70;
            // 
            // estructuraname
            // 
            this.estructuraname.DataPropertyName = "estructuraname";
            this.estructuraname.HeaderText = "Estructura";
            this.estructuraname.Name = "estructuraname";
            this.estructuraname.Width = 80;
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
            // fecre
            // 
            this.fecre.DataPropertyName = "fecre";
            this.fecre.HeaderText = "fecre";
            this.fecre.Name = "fecre";
            this.fecre.Visible = false;
            // 
            // ctaalmacen
            // 
            this.ctaalmacen.DataPropertyName = "ctaalmacen";
            this.ctaalmacen.HeaderText = "ctaalmacen";
            this.ctaalmacen.Name = "ctaalmacen";
            this.ctaalmacen.Visible = false;
            // 
            // ctaconsumo
            // 
            this.ctaconsumo.DataPropertyName = "ctaconsumo";
            this.ctaconsumo.HeaderText = "ctaconsumo";
            this.ctaconsumo.Name = "ctaconsumo";
            this.ctaconsumo.Visible = false;
            // 
            // ctavarexist
            // 
            this.ctavarexist.DataPropertyName = "ctavarexist";
            this.ctavarexist.HeaderText = "ctavarexist";
            this.ctavarexist.Name = "ctavarexist";
            this.ctavarexist.Visible = false;
            // 
            // ctacargaimput
            // 
            this.ctacargaimput.DataPropertyName = "ctacargaimput";
            this.ctacargaimput.HeaderText = "ctacargaimput";
            this.ctacargaimput.Name = "ctacargaimput";
            this.ctacargaimput.Visible = false;
            // 
            // moduloid
            // 
            this.moduloid.DataPropertyName = "moduloid";
            this.moduloid.HeaderText = "moduloid";
            this.moduloid.Name = "moduloid";
            this.moduloid.Visible = false;
            // 
            // nostock
            // 
            this.nostock.DataPropertyName = "nostock";
            this.nostock.HeaderText = "No-Stock";
            this.nostock.Name = "nostock";
            this.nostock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nostock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nostock.Width = 60;
            // 
            // _unmed
            // 
            this._unmed.DataPropertyName = "unmed";
            this._unmed.HeaderText = "UnMed";
            this._unmed.Name = "_unmed";
            this._unmed.Visible = false;
            // 
            // Frm_linea
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(540, 541);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_busqueda);
            this.Controls.Add(this.txt_criterio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gridlinea);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_linea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Lineas";
            this.Load += new System.EventHandler(this.Frm_linea_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_linea_KeyDown);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridlinea)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
        internal System.Windows.Forms.TextBox lineaname;
        internal System.Windows.Forms.DataGridView gridlinea;
        internal System.Windows.Forms.TextBox lineaid;
        private System.Windows.Forms.ComboBox estructuraid;
        private System.Windows.Forms.ToolStripButton btn_clave;
        internal System.Windows.Forms.ComboBox moduloiddes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_busqueda;
        internal System.Windows.Forms.TextBox txt_criterio;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        internal System.Windows.Forms.ComboBox localdes;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        internal System.Windows.Forms.ComboBox unmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn glineaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn glineaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gestructuraid;
        private System.Windows.Forms.DataGridViewTextBoxColumn estructuraname;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn feact;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaalmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctaconsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctavarexist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctacargaimput;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nostock;
        private System.Windows.Forms.DataGridViewTextBoxColumn _unmed;

    }
}