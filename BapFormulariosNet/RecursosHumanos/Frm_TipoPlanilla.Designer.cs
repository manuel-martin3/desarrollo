namespace BapFormulariosNet.RecursosHumanos
{
    partial class Frm_TipoPlanilla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TipoPlanilla));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfiltronombre = new System.Windows.Forms.TextBox();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.tipoplla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tituloboleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipopllaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modoplla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasplla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipotrabpdtxx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tipopllaemple = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipotrabpdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gratificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtidconta = new System.Windows.Forms.TextBox();
            this.chkcts = new System.Windows.Forms.CheckBox();
            this.chkpdt = new System.Windows.Forms.CheckBox();
            this.chkgratificacion = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtdiasplanilla = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtdescriptrab = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txttituloboleta = new System.Windows.Forms.TextBox();
            this.cboRubrorpts = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.cboFormapago = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.chkactivo = new System.Windows.Forms.CheckBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.barramain = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnRetro = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrimero = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.btnSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnUltimo = new System.Windows.Forms.ToolStripButton();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblanulado = new System.Windows.Forms.Label();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdiasplanilla)).BeginInit();
            this.barramain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(11, 39);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(673, 432);
            this.TabControl1.TabIndex = 3;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            this.TabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.Examinar);
            this.TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(665, 406);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Examinar";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtfiltronombre);
            this.GroupBox2.Controls.Add(this.btnfiltro);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Location = new System.Drawing.Point(6, 5);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(651, 59);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            // 
            // txtfiltronombre
            // 
            this.txtfiltronombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfiltronombre.Location = new System.Drawing.Point(11, 26);
            this.txtfiltronombre.Name = "txtfiltronombre";
            this.txtfiltronombre.Size = new System.Drawing.Size(393, 20);
            this.txtfiltronombre.TabIndex = 1;
            // 
            // btnfiltro
            // 
            this.btnfiltro.Image = global::BapFormulariosNet.Properties.Resources.lupa24;
            this.btnfiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltro.Location = new System.Drawing.Point(565, 17);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(70, 34);
            this.btnfiltro.TabIndex = 6;
            this.btnfiltro.Text = "&Buscar";
            this.btnfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfiltro.UseVisualStyleBackColor = true;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label22.Location = new System.Drawing.Point(12, 10);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(63, 13);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Descripción";
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 25;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoplla,
            this.tituloboleta,
            this.tipopllaname,
            this.modoplla,
            this.formapago,
            this.diasplla,
            this.tipotrabpdtxx,
            this.status,
            this.tipopllaemple,
            this.tipotrabpdt,
            this.gratificacion,
            this.pdt,
            this.cts});
            this.Examinar.Location = new System.Drawing.Point(6, 69);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Examinar.RowHeadersWidth = 26;
            this.Examinar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.Size = new System.Drawing.Size(651, 328);
            this.Examinar.TabIndex = 1;
            this.Examinar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Examinar_CellContentDoubleClick);
            this.Examinar.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Examinar_CellMouseDoubleClick);
            this.Examinar.Paint += new System.Windows.Forms.PaintEventHandler(this.Examinar_Paint);
            // 
            // tipoplla
            // 
            this.tipoplla.DataPropertyName = "tipoplla";
            this.tipoplla.HeaderText = "Código";
            this.tipoplla.Name = "tipoplla";
            this.tipoplla.ReadOnly = true;
            this.tipoplla.Width = 60;
            // 
            // tituloboleta
            // 
            this.tituloboleta.DataPropertyName = "tituloboleta";
            this.tituloboleta.HeaderText = "titulo_boleta";
            this.tituloboleta.Name = "tituloboleta";
            this.tituloboleta.ReadOnly = true;
            this.tituloboleta.Visible = false;
            // 
            // tipopllaname
            // 
            this.tipopllaname.DataPropertyName = "tipopllaname";
            this.tipopllaname.HeaderText = "Descripción";
            this.tipopllaname.Name = "tipopllaname";
            this.tipopllaname.ReadOnly = true;
            this.tipopllaname.Width = 320;
            // 
            // modoplla
            // 
            this.modoplla.DataPropertyName = "modoplla";
            this.modoplla.HeaderText = "modoplla";
            this.modoplla.Name = "modoplla";
            this.modoplla.ReadOnly = true;
            this.modoplla.Visible = false;
            // 
            // formapago
            // 
            this.formapago.DataPropertyName = "formapago";
            this.formapago.HeaderText = "formapago";
            this.formapago.Name = "formapago";
            this.formapago.ReadOnly = true;
            this.formapago.Visible = false;
            // 
            // diasplla
            // 
            this.diasplla.DataPropertyName = "diasplla";
            this.diasplla.HeaderText = "diasplla";
            this.diasplla.Name = "diasplla";
            this.diasplla.ReadOnly = true;
            this.diasplla.Visible = false;
            // 
            // tipotrabpdtxx
            // 
            this.tipotrabpdtxx.DataPropertyName = "tipotrabpdtxx";
            this.tipotrabpdtxx.HeaderText = "tipotrabpdt";
            this.tipotrabpdtxx.Name = "tipotrabpdtxx";
            this.tipotrabpdtxx.ReadOnly = true;
            this.tipotrabpdtxx.Visible = false;
            this.tipotrabpdtxx.Width = 55;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Activo";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 48;
            // 
            // tipopllaemple
            // 
            this.tipopllaemple.DataPropertyName = "tipopllaemple";
            this.tipopllaemple.HeaderText = "tipopllaemple";
            this.tipopllaemple.Name = "tipopllaemple";
            this.tipopllaemple.ReadOnly = true;
            this.tipopllaemple.Visible = false;
            // 
            // tipotrabpdt
            // 
            this.tipotrabpdt.DataPropertyName = "tipotrabpdt";
            this.tipotrabpdt.HeaderText = "Código  RTPS";
            this.tipotrabpdt.Name = "tipotrabpdt";
            this.tipotrabpdt.ReadOnly = true;
            this.tipotrabpdt.Width = 176;
            // 
            // gratificacion
            // 
            this.gratificacion.DataPropertyName = "gratificacion";
            this.gratificacion.HeaderText = "gratificacion";
            this.gratificacion.Name = "gratificacion";
            this.gratificacion.ReadOnly = true;
            this.gratificacion.Visible = false;
            // 
            // pdt
            // 
            this.pdt.DataPropertyName = "pdt";
            this.pdt.HeaderText = "pdt";
            this.pdt.Name = "pdt";
            this.pdt.ReadOnly = true;
            this.pdt.Visible = false;
            // 
            // cts
            // 
            this.cts.DataPropertyName = "cts";
            this.cts.HeaderText = "cts";
            this.cts.Name = "cts";
            this.cts.ReadOnly = true;
            this.cts.Visible = false;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(665, 406);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Datos";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtidconta);
            this.GroupBox1.Controls.Add(this.chkcts);
            this.GroupBox1.Controls.Add(this.chkpdt);
            this.GroupBox1.Controls.Add(this.chkgratificacion);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtdiasplanilla);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtdescriptrab);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txttituloboleta);
            this.GroupBox1.Controls.Add(this.cboRubrorpts);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.cboFormapago);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.chkactivo);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.txtCodigo);
            this.GroupBox1.Location = new System.Drawing.Point(7, 26);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(651, 349);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(42, 256);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 18;
            this.Label5.Text = "ID.Contabilidad";
            // 
            // txtidconta
            // 
            this.txtidconta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidconta.Location = new System.Drawing.Point(128, 252);
            this.txtidconta.MaxLength = 1;
            this.txtidconta.Name = "txtidconta";
            this.txtidconta.Size = new System.Drawing.Size(36, 20);
            this.txtidconta.TabIndex = 19;
            this.txtidconta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidconta_KeyPress);
            // 
            // chkcts
            // 
            this.chkcts.AutoSize = true;
            this.chkcts.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkcts.Location = new System.Drawing.Point(288, 166);
            this.chkcts.Name = "chkcts";
            this.chkcts.Size = new System.Drawing.Size(47, 17);
            this.chkcts.TabIndex = 17;
            this.chkcts.TabStop = false;
            this.chkcts.Text = "CTS";
            this.chkcts.UseVisualStyleBackColor = true;
            // 
            // chkpdt
            // 
            this.chkpdt.AutoSize = true;
            this.chkpdt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkpdt.Location = new System.Drawing.Point(226, 166);
            this.chkpdt.Name = "chkpdt";
            this.chkpdt.Size = new System.Drawing.Size(48, 17);
            this.chkpdt.TabIndex = 16;
            this.chkpdt.TabStop = false;
            this.chkpdt.Text = "PDT";
            this.chkpdt.UseVisualStyleBackColor = true;
            // 
            // chkgratificacion
            // 
            this.chkgratificacion.AutoSize = true;
            this.chkgratificacion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkgratificacion.Location = new System.Drawing.Point(128, 166);
            this.chkgratificacion.Name = "chkgratificacion";
            this.chkgratificacion.Size = new System.Drawing.Size(85, 17);
            this.chkgratificacion.TabIndex = 15;
            this.chkgratificacion.TabStop = false;
            this.chkgratificacion.Text = "Gratificación";
            this.chkgratificacion.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label4.Location = new System.Drawing.Point(534, 54);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(66, 13);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Días Planilla";
            // 
            // txtdiasplanilla
            // 
            this.txtdiasplanilla.Location = new System.Drawing.Point(602, 50);
            this.txtdiasplanilla.Name = "txtdiasplanilla";
            this.txtdiasplanilla.Size = new System.Drawing.Size(43, 20);
            this.txtdiasplanilla.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(4, 137);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(117, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Descripción Trabajador";
            // 
            // txtdescriptrab
            // 
            this.txtdescriptrab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescriptrab.Location = new System.Drawing.Point(128, 133);
            this.txtdescriptrab.Name = "txtdescriptrab";
            this.txtdescriptrab.Size = new System.Drawing.Size(404, 20);
            this.txtdescriptrab.TabIndex = 11;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(53, 112);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Título Boleta";
            // 
            // txttituloboleta
            // 
            this.txttituloboleta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttituloboleta.Location = new System.Drawing.Point(128, 108);
            this.txttituloboleta.Name = "txttituloboleta";
            this.txttituloboleta.Size = new System.Drawing.Size(404, 20);
            this.txttituloboleta.TabIndex = 9;
            // 
            // cboRubrorpts
            // 
            this.cboRubrorpts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRubrorpts.FormattingEnabled = true;
            this.cboRubrorpts.Location = new System.Drawing.Point(128, 220);
            this.cboRubrorpts.Name = "cboRubrorpts";
            this.cboRubrorpts.Size = new System.Drawing.Size(518, 21);
            this.cboRubrorpts.TabIndex = 14;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label9.Location = new System.Drawing.Point(53, 224);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(68, 13);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "Rubro RPTS";
            // 
            // cboFormapago
            // 
            this.cboFormapago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormapago.FormattingEnabled = true;
            this.cboFormapago.Location = new System.Drawing.Point(128, 80);
            this.cboFormapago.Name = "cboFormapago";
            this.cboFormapago.Size = new System.Drawing.Size(214, 21);
            this.cboFormapago.TabIndex = 7;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(42, 84);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(79, 13);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Forma de Pago";
            // 
            // chkactivo
            // 
            this.chkactivo.AutoSize = true;
            this.chkactivo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkactivo.Location = new System.Drawing.Point(128, 189);
            this.chkactivo.Name = "chkactivo";
            this.chkactivo.Size = new System.Drawing.Size(56, 17);
            this.chkactivo.TabIndex = 12;
            this.chkactivo.TabStop = false;
            this.chkactivo.Text = "Activo";
            this.chkactivo.UseVisualStyleBackColor = true;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label10.Location = new System.Drawing.Point(58, 54);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(63, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(128, 50);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(404, 20);
            this.txtdescripcion.TabIndex = 3;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label8.Location = new System.Drawing.Point(81, 29);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(128, 24);
            this.txtCodigo.MaxLength = 1;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(36, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // barramain
            // 
            this.barramain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.barramain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnRetro,
            this.btnDelete,
            this.btnLoad,
            this.btnExit,
            this.toolStripSeparator1,
            this.btnLog,
            this.toolStripSeparator2,
            this.btnPrimero,
            this.btnAnterior,
            this.btnSiguiente,
            this.btnUltimo});
            this.barramain.Location = new System.Drawing.Point(0, 0);
            this.barramain.Name = "barramain";
            this.barramain.Size = new System.Drawing.Size(692, 33);
            this.barramain.TabIndex = 2;
            this.barramain.Text = "ToolStrip2";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::BapFormulariosNet.Properties.Resources.btn_nuevo;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(28, 30);
            this.btnNew.Text = "Nuevo";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(28, 30);
            this.btnEdit.Text = "Editar";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(28, 30);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRetro
            // 
            this.btnRetro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRetro.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.btnRetro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRetro.Name = "btnRetro";
            this.btnRetro.Size = new System.Drawing.Size(28, 30);
            this.btnRetro.Text = "Deshacer";
            this.btnRetro.Click += new System.EventHandler(this.btnRetro_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 30);
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.AutoSize = false;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoad.Image = global::BapFormulariosNet.Properties.Resources.btn_refresh;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(30, 30);
            this.btnLoad.Text = "Actualizar";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 30);
            this.btnExit.Text = "Salir";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // btnLog
            // 
            this.btnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(28, 30);
            this.btnLog.Text = "Log - Seguridad";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // btnPrimero
            // 
            this.btnPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrimero.Image = global::BapFormulariosNet.Properties.Resources.btnInicio;
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(28, 30);
            this.btnPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrimero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrimero.ToolTipText = "Primer Registro";
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnterior.Image = global::BapFormulariosNet.Properties.Resources.btnAnterior;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(28, 30);
            this.btnAnterior.Text = "ToolStripButton2";
            this.btnAnterior.ToolTipText = "Anterior Registro";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguiente.Image = global::BapFormulariosNet.Properties.Resources.btnSiguiente;
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(28, 30);
            this.btnSiguiente.Text = "ToolStripButton1";
            this.btnSiguiente.ToolTipText = "Siguiente Registro";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUltimo.Image = global::BapFormulariosNet.Properties.Resources.btnUltimo;
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(28, 30);
            this.btnUltimo.Text = "ToolStripButton3";
            this.btnUltimo.ToolTipText = "Ultimo Registro";
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // lblanulado
            // 
            this.lblanulado.AutoSize = true;
            this.lblanulado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblanulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanulado.ForeColor = System.Drawing.Color.White;
            this.lblanulado.Location = new System.Drawing.Point(219, 463);
            this.lblanulado.Name = "lblanulado";
            this.lblanulado.Size = new System.Drawing.Size(59, 13);
            this.lblanulado.TabIndex = 48;
            this.lblanulado.Text = "ANULADO";
            this.lblanulado.Visible = false;
            // 
            // Frm_TipoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 478);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.barramain);
            this.Controls.Add(this.lblanulado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_TipoPlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recursos Humanos - Tipo de Planilla";
            this.Activated += new System.EventHandler(this.Frm_TipoPlanilla_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_TipoPlanilla_FormClosing);
            this.Load += new System.EventHandler(this.Frm_TipoPlanilla_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_TipoPlanilla_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdiasplanilla)).EndInit();
            this.barramain.ResumeLayout(false);
            this.barramain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtfiltronombre;
        internal System.Windows.Forms.Button btnfiltro;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtidconta;
        internal System.Windows.Forms.CheckBox chkcts;
        internal System.Windows.Forms.CheckBox chkpdt;
        internal System.Windows.Forms.CheckBox chkgratificacion;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown txtdiasplanilla;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtdescriptrab;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txttituloboleta;
        internal System.Windows.Forms.ComboBox cboRubrorpts;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.ComboBox cboFormapago;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.CheckBox chkactivo;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.ToolStripButton btnNew;
        internal System.Windows.Forms.ToolStripButton btnEdit;
        internal System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.ToolStripButton btnRetro;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        internal System.Windows.Forms.ToolStripButton btnLoad;
        internal System.Windows.Forms.ToolStripButton btnExit;
        internal System.Windows.Forms.ToolStripButton btnLog;
        internal System.Windows.Forms.ToolStripButton btnPrimero;
        internal System.Windows.Forms.ToolStripButton btnAnterior;
        internal System.Windows.Forms.ToolStripButton btnSiguiente;
        internal System.Windows.Forms.ToolStripButton btnUltimo;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.Label lblanulado;
        internal System.Windows.Forms.ToolStrip barramain;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoplla;
        private System.Windows.Forms.DataGridViewTextBoxColumn tituloboleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopllaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn modoplla;
        private System.Windows.Forms.DataGridViewTextBoxColumn formapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasplla;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipotrabpdtxx;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopllaemple;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipotrabpdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn gratificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cts;
    }
}