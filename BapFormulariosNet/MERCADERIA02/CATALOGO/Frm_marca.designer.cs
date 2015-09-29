namespace BapFormulariosNet.MERCADERIA02.CATALOGO
{
    partial class Frm_marca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_marca));
            this.txt_criterio = new System.Windows.Forms.TextBox();
            this.gridmarca = new System.Windows.Forms.DataGridView();
            this.gmarcaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmarcaidold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmarcaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmarcadescort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gmarcapropia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtsigla = new System.Windows.Forms.TextBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkmarcapropia = new DevExpress.XtraEditors.CheckEdit();
            this.marcadescort = new System.Windows.Forms.TextBox();
            this.marcaidold = new System.Windows.Forms.TextBox();
            this.marcaid = new System.Windows.Forms.TextBox();
            this.marcaname = new System.Windows.Forms.TextBox();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.btn_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_primero = new System.Windows.Forms.ToolStripButton();
            this.btn_anterior = new System.Windows.Forms.ToolStripButton();
            this.btn_siguiente = new System.Windows.Forms.ToolStripButton();
            this.btn_ultimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_clave = new System.Windows.Forms.ToolStripButton();
            this.btn_log = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_busqueda = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridmarca)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkmarcapropia.Properties)).BeginInit();
            this.Botonera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_criterio
            // 
            this.txt_criterio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_criterio.Location = new System.Drawing.Point(94, 168);
            this.txt_criterio.MaxLength = 0;
            this.txt_criterio.Name = "txt_criterio";
            this.txt_criterio.Size = new System.Drawing.Size(248, 21);
            this.txt_criterio.TabIndex = 17;
            this.txt_criterio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_criterio_KeyDown);
            // 
            // gridmarca
            // 
            this.gridmarca.AllowUserToAddRows = false;
            this.gridmarca.AllowUserToDeleteRows = false;
            this.gridmarca.AllowUserToResizeColumns = false;
            this.gridmarca.AllowUserToResizeRows = false;
            this.gridmarca.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridmarca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridmarca.ColumnHeadersHeight = 20;
            this.gridmarca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gmarcaid,
            this.sigla,
            this.gmarcaidold,
            this.gmarcaname,
            this.gmarcadescort,
            this.usuar,
            this.fecre,
            this.feact,
            this.gmarcapropia});
            this.gridmarca.Location = new System.Drawing.Point(5, 198);
            this.gridmarca.MultiSelect = false;
            this.gridmarca.Name = "gridmarca";
            this.gridmarca.RowHeadersVisible = false;
            this.gridmarca.RowHeadersWidth = 10;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridmarca.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridmarca.RowTemplate.Height = 20;
            this.gridmarca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridmarca.Size = new System.Drawing.Size(419, 351);
            this.gridmarca.TabIndex = 19;
            this.gridmarca.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmarca_CellClick);
            this.gridmarca.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmarca_CellEnter);
            this.gridmarca.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridmarca_CellLeave);
            this.gridmarca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridmarca_KeyUp);
            // 
            // gmarcaid
            // 
            this.gmarcaid.DataPropertyName = "marcaid";
            this.gmarcaid.HeaderText = "Código";
            this.gmarcaid.Name = "gmarcaid";
            this.gmarcaid.Width = 60;
            // 
            // sigla
            // 
            this.sigla.DataPropertyName = "sigla";
            this.sigla.HeaderText = "Sigla";
            this.sigla.Name = "sigla";
            this.sigla.Width = 40;
            // 
            // gmarcaidold
            // 
            this.gmarcaidold.DataPropertyName = "marcaidold";
            this.gmarcaidold.HeaderText = "marcaidold";
            this.gmarcaidold.Name = "gmarcaidold";
            this.gmarcaidold.Visible = false;
            // 
            // gmarcaname
            // 
            this.gmarcaname.DataPropertyName = "marcaname";
            this.gmarcaname.HeaderText = "Marca";
            this.gmarcaname.Name = "gmarcaname";
            this.gmarcaname.Width = 200;
            // 
            // gmarcadescort
            // 
            this.gmarcadescort.DataPropertyName = "marcadescort";
            this.gmarcadescort.HeaderText = "Desc-Corta";
            this.gmarcadescort.Name = "gmarcadescort";
            this.gmarcadescort.Width = 90;
            // 
            // usuar
            // 
            this.usuar.DataPropertyName = "usuar";
            this.usuar.HeaderText = "usuar";
            this.usuar.Name = "usuar";
            this.usuar.Visible = false;
            // 
            // fecre
            // 
            this.fecre.DataPropertyName = "fecre";
            this.fecre.HeaderText = "fecre";
            this.fecre.Name = "fecre";
            this.fecre.Visible = false;
            // 
            // feact
            // 
            this.feact.DataPropertyName = "feact";
            this.feact.HeaderText = "feact";
            this.feact.Name = "feact";
            this.feact.Visible = false;
            // 
            // gmarcapropia
            // 
            this.gmarcapropia.DataPropertyName = "marcapropia";
            this.gmarcapropia.HeaderText = "marcapropia";
            this.gmarcapropia.Name = "gmarcapropia";
            this.gmarcapropia.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Controls.Add(this.txtsigla);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.chkmarcapropia);
            this.groupBox1.Controls.Add(this.marcadescort);
            this.groupBox1.Controls.Add(this.marcaidold);
            this.groupBox1.Controls.Add(this.marcaid);
            this.groupBox1.Controls.Add(this.marcaname);
            this.groupBox1.Location = new System.Drawing.Point(4, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 84);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(242, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(102, 13);
            this.labelControl7.TabIndex = 81;
            this.labelControl7.Text = "» Codigo Anterior:";
            // 
            // txtsigla
            // 
            this.txtsigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsigla.Location = new System.Drawing.Point(237, 59);
            this.txtsigla.MaxLength = 2;
            this.txtsigla.Name = "txtsigla";
            this.txtsigla.Size = new System.Drawing.Size(28, 21);
            this.txtsigla.TabIndex = 80;
            this.txtsigla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Location = new System.Drawing.Point(193, 64);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 79;
            this.labelControl6.Text = "» Sigla:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(8, 62);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 13);
            this.labelControl3.TabIndex = 78;
            this.labelControl3.Text = "» Des-Corta:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(8, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "» Marca:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(8, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 76;
            this.labelControl1.Text = "» Codigo:";
            // 
            // chkmarcapropia
            // 
            this.chkmarcapropia.Location = new System.Drawing.Point(273, 60);
            this.chkmarcapropia.Name = "chkmarcapropia";
            this.chkmarcapropia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkmarcapropia.Properties.Appearance.Options.UseFont = true;
            this.chkmarcapropia.Properties.Caption = "» Marca-Propia:";
            this.chkmarcapropia.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkmarcapropia.Size = new System.Drawing.Size(117, 19);
            this.chkmarcapropia.TabIndex = 75;
            // 
            // marcadescort
            // 
            this.marcadescort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.marcadescort.Location = new System.Drawing.Point(85, 59);
            this.marcadescort.MaxLength = 10;
            this.marcadescort.Name = "marcadescort";
            this.marcadescort.Size = new System.Drawing.Size(102, 21);
            this.marcadescort.TabIndex = 18;
            // 
            // marcaidold
            // 
            this.marcaidold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marcaidold.Location = new System.Drawing.Point(347, 13);
            this.marcaidold.MaxLength = 3;
            this.marcaidold.Name = "marcaidold";
            this.marcaidold.Size = new System.Drawing.Size(27, 20);
            this.marcaidold.TabIndex = 16;
            this.marcaidold.Text = "00";
            this.marcaidold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // marcaid
            // 
            this.marcaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marcaid.Location = new System.Drawing.Point(85, 16);
            this.marcaid.MaxLength = 2;
            this.marcaid.Name = "marcaid";
            this.marcaid.Size = new System.Drawing.Size(28, 20);
            this.marcaid.TabIndex = 11;
            this.marcaid.Text = "00";
            this.marcaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // marcaname
            // 
            this.marcaname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.marcaname.Location = new System.Drawing.Point(85, 37);
            this.marcaname.Name = "marcaname";
            this.marcaname.Size = new System.Drawing.Size(290, 21);
            this.marcaname.TabIndex = 12;
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
            this.btn_excel,
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
            this.Botonera.Size = new System.Drawing.Size(426, 29);
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
            // btn_excel
            // 
            this.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_excel.Image = global::BapFormulariosNet.Properties.Resources.btn_excel20;
            this.btn_excel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(24, 26);
            this.btn_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_excel.ToolTipText = "Exportar_Excel";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
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
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 15;
            this.lineShape1.X2 = 410;
            this.lineShape1.Y1 = 159;
            this.lineShape1.Y2 = 159;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(426, 552);
            this.shapeContainer1.TabIndex = 112;
            this.shapeContainer1.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(11, 142);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 113;
            this.labelControl4.Text = "» Busqueda:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(11, 171);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(79, 13);
            this.labelControl5.TabIndex = 114;
            this.labelControl5.Text = "» Descripción:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 57);
            this.panel1.TabIndex = 115;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(176, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Marca";
            // 
            // btn_busqueda
            // 
            this.btn_busqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_busqueda.Image = ((System.Drawing.Image)(resources.GetObject("btn_busqueda.Image")));
            this.btn_busqueda.Location = new System.Drawing.Point(348, 163);
            this.btn_busqueda.Name = "btn_busqueda";
            this.btn_busqueda.Size = new System.Drawing.Size(75, 33);
            this.btn_busqueda.TabIndex = 116;
            this.btn_busqueda.Text = "&Buscar";
            this.btn_busqueda.Click += new System.EventHandler(this.btn_busqueda_Click);
            // 
            // Frm_marca
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(426, 552);
            this.Controls.Add(this.btn_busqueda);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_criterio);
            this.Controls.Add(this.gridmarca);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_marca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Mantenimiento de Marcas ««";
            this.Load += new System.EventHandler(this.Frm_marcas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_marcas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridmarca)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkmarcapropia.Properties)).EndInit();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_primero;
        private System.Windows.Forms.ToolStripButton btn_anterior;
        private System.Windows.Forms.ToolStripButton btn_siguiente;
        private System.Windows.Forms.ToolStripButton btn_ultimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btn_log;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox marcaname;
        internal System.Windows.Forms.DataGridView gridmarca;
        internal System.Windows.Forms.TextBox txt_criterio;
        internal System.Windows.Forms.TextBox marcaid;
        private System.Windows.Forms.ToolStripButton btn_clave;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        internal System.Windows.Forms.TextBox marcaidold;
        internal System.Windows.Forms.TextBox marcadescort;
        private DevExpress.XtraEditors.CheckEdit chkmarcapropia;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.SimpleButton btn_busqueda;
        internal System.Windows.Forms.TextBox txtsigla;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmarcaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigla;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmarcaidold;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmarcaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmarcadescort;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecre;
        private System.Windows.Forms.DataGridViewTextBoxColumn feact;
        private System.Windows.Forms.DataGridViewTextBoxColumn gmarcapropia;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.ToolStripButton btn_excel;

    }
}