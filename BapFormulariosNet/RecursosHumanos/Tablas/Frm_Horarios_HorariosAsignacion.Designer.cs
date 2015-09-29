namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Horarios_HorariosAsignacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Horarios_HorariosAsignacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.chkVerInactivos = new System.Windows.Forms.CheckBox();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.txtMBuscar = new System.Windows.Forms.MaskedTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsVigente = new System.Windows.Forms.ToolStripButton();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkVigente = new System.Windows.Forms.CheckBox();
            this.cboCodHorarioSemanal = new System.Windows.Forms.ComboBox();
            this.cboCodHorarioDiario = new System.Windows.Forms.ComboBox();
            this.lblSem = new System.Windows.Forms.Label();
            this.cboTHorario = new System.Windows.Forms.ComboBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.txtPlanilla = new System.Windows.Forms.TextBox();
            this.txtFIngreso = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.dgTurno = new System.Windows.Forms.DataGridView();
            this.FEC_INI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEC_FIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_HORARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_HORARIO_SEMANAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_HORARIO_DIARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_HORARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DES_HORATRIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIGENT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FEC_ASIGNACION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTrabajador = new System.Windows.Forms.DataGridView();
            this.FICHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIGENTE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DTRABAJADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_INGRESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO_PLANILLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCARGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAREA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cdResaltadoVigentes = new System.Windows.Forms.ColorDialog();
            this.GroupBox3.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrabajador)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnSalir);
            this.GroupBox3.Location = new System.Drawing.Point(356, 482);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(496, 50);
            this.GroupBox3.TabIndex = 76;
            this.GroupBox3.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::BapFormulariosNet.Properties.Resources.exit32;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(418, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(72, 36);
            this.btnSalir.TabIndex = 67;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // chkVerInactivos
            // 
            this.chkVerInactivos.AutoSize = true;
            this.chkVerInactivos.ForeColor = System.Drawing.Color.Red;
            this.chkVerInactivos.Location = new System.Drawing.Point(265, 489);
            this.chkVerInactivos.Name = "chkVerInactivos";
            this.chkVerInactivos.Size = new System.Drawing.Size(88, 17);
            this.chkVerInactivos.TabIndex = 73;
            this.chkVerInactivos.Text = "Ver Inactivos";
            this.chkVerInactivos.UseVisualStyleBackColor = true;
            this.chkVerInactivos.CheckedChanged += new System.EventHandler(this.chkVerInactivos_CheckedChanged);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.txtMBuscar);
            this.GroupBox6.Controls.Add(this.btnBuscar);
            this.GroupBox6.Location = new System.Drawing.Point(9, 482);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(250, 50);
            this.GroupBox6.TabIndex = 75;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Busqueda por Código:";
            // 
            // txtMBuscar
            // 
            this.txtMBuscar.Location = new System.Drawing.Point(9, 19);
            this.txtMBuscar.Mask = "99999";
            this.txtMBuscar.Name = "txtMBuscar";
            this.txtMBuscar.Size = new System.Drawing.Size(156, 20);
            this.txtMBuscar.TabIndex = 1;
            this.txtMBuscar.TextChanged += new System.EventHandler(this.txtMBuscar_TextChanged);
            this.txtMBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMBuscar_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::BapFormulariosNet.Properties.Resources.btn_search20;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(174, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(69, 31);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNuevo,
            this.tsEditar,
            this.tsEliminar,
            this.tsGrabar,
            this.tsCancelar,
            this.tsVigente,
            this.ToolStripLabel1});
            this.ToolStrip1.Location = new System.Drawing.Point(9, 2);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(565, 29);
            this.ToolStrip1.TabIndex = 74;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tsNuevo
            // 
            this.tsNuevo.Image = global::BapFormulariosNet.Properties.Resources.btn_nuevo;
            this.tsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNuevo.Name = "tsNuevo";
            this.tsNuevo.Size = new System.Drawing.Size(26, 26);
            this.tsNuevo.Click += new System.EventHandler(this.tsNuevo_Click);
            // 
            // tsEditar
            // 
            this.tsEditar.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(26, 26);
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar;
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(26, 26);
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // tsGrabar
            // 
            this.tsGrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.tsGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGrabar.Name = "tsGrabar";
            this.tsGrabar.Size = new System.Drawing.Size(26, 26);
            this.tsGrabar.Click += new System.EventHandler(this.tsGrabar_Click);
            // 
            // tsCancelar
            // 
            this.tsCancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.tsCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCancelar.Name = "tsCancelar";
            this.tsCancelar.Size = new System.Drawing.Size(26, 26);
            this.tsCancelar.Click += new System.EventHandler(this.tsCancelar_Click);
            // 
            // tsVigente
            // 
            this.tsVigente.BackColor = System.Drawing.Color.Silver;
            this.tsVigente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsVigente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsVigente.ForeColor = System.Drawing.Color.White;
            this.tsVigente.Image = ((System.Drawing.Image)(resources.GetObject("tsVigente.Image")));
            this.tsVigente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVigente.Name = "tsVigente";
            this.tsVigente.Size = new System.Drawing.Size(60, 26);
            this.tsVigente.Text = "Vigentes";
            this.tsVigente.Click += new System.EventHandler(this.tsVigente_Click);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(148, 26);
            this.ToolStripLabel1.Text = "                                              .";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.chkVigente);
            this.GroupBox2.Controls.Add(this.lblSem);
            this.GroupBox2.Controls.Add(this.cboTHorario);
            this.GroupBox2.Controls.Add(this.lblDia);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.dtpFechaFin);
            this.GroupBox2.Controls.Add(this.dtpFechaIni);
            this.GroupBox2.Controls.Add(this.cboCodHorarioSemanal);
            this.GroupBox2.Controls.Add(this.cboCodHorarioDiario);
            this.GroupBox2.Location = new System.Drawing.Point(356, 32);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(496, 127);
            this.GroupBox2.TabIndex = 72;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Datos del Turno:";
            // 
            // chkVigente
            // 
            this.chkVigente.AutoSize = true;
            this.chkVigente.Location = new System.Drawing.Point(415, 89);
            this.chkVigente.Name = "chkVigente";
            this.chkVigente.Size = new System.Drawing.Size(15, 14);
            this.chkVigente.TabIndex = 5;
            this.chkVigente.UseVisualStyleBackColor = true;
            // 
            // cboCodHorarioSemanal
            // 
            this.cboCodHorarioSemanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodHorarioSemanal.DropDownWidth = 300;
            this.cboCodHorarioSemanal.FormattingEnabled = true;
            this.cboCodHorarioSemanal.Location = new System.Drawing.Point(124, 86);
            this.cboCodHorarioSemanal.Name = "cboCodHorarioSemanal";
            this.cboCodHorarioSemanal.Size = new System.Drawing.Size(240, 21);
            this.cboCodHorarioSemanal.TabIndex = 4;
            // 
            // cboCodHorarioDiario
            // 
            this.cboCodHorarioDiario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodHorarioDiario.DropDownWidth = 300;
            this.cboCodHorarioDiario.FormattingEnabled = true;
            this.cboCodHorarioDiario.Location = new System.Drawing.Point(124, 86);
            this.cboCodHorarioDiario.Name = "cboCodHorarioDiario";
            this.cboCodHorarioDiario.Size = new System.Drawing.Size(240, 21);
            this.cboCodHorarioDiario.TabIndex = 4;
            // 
            // lblSem
            // 
            this.lblSem.AutoSize = true;
            this.lblSem.Location = new System.Drawing.Point(27, 90);
            this.lblSem.Name = "lblSem";
            this.lblSem.Size = new System.Drawing.Size(91, 13);
            this.lblSem.TabIndex = 2;
            this.lblSem.Text = "Horario Semanal :";
            // 
            // cboTHorario
            // 
            this.cboTHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTHorario.FormattingEnabled = true;
            this.cboTHorario.Location = new System.Drawing.Point(124, 62);
            this.cboTHorario.Name = "cboTHorario";
            this.cboTHorario.Size = new System.Drawing.Size(85, 21);
            this.cboTHorario.TabIndex = 3;
            this.cboTHorario.SelectedIndexChanged += new System.EventHandler(this.cboTHorario_SelectedIndexChanged);
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.Location = new System.Drawing.Point(40, 90);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(77, 13);
            this.lblDia.TabIndex = 2;
            this.lblDia.Text = "Horario Diario :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(32, 66);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(86, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Tipo de Horario :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(43, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(74, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Fecha Hasta :";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(431, 90);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(43, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Vigente";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(40, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Fecha Desde :";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(124, 39);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(85, 20);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(124, 16);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(85, 20);
            this.dtpFechaIni.TabIndex = 0;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkActivo);
            this.GroupBox1.Controls.Add(this.txtArea);
            this.GroupBox1.Controls.Add(this.txtCargo);
            this.GroupBox1.Controls.Add(this.txtPlanilla);
            this.GroupBox1.Controls.Add(this.txtFIngreso);
            this.GroupBox1.Controls.Add(this.txtNombres);
            this.GroupBox1.Controls.Add(this.txtCodigo);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Location = new System.Drawing.Point(9, 32);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(341, 127);
            this.GroupBox1.TabIndex = 71;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Datos del Trabajador:";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Enabled = false;
            this.chkActivo.Location = new System.Drawing.Point(309, 19);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(15, 14);
            this.chkActivo.TabIndex = 10;
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(75, 100);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(258, 20);
            this.txtArea.TabIndex = 9;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(75, 79);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.ReadOnly = true;
            this.txtCargo.Size = new System.Drawing.Size(258, 20);
            this.txtCargo.TabIndex = 8;
            // 
            // txtPlanilla
            // 
            this.txtPlanilla.Location = new System.Drawing.Point(253, 58);
            this.txtPlanilla.Name = "txtPlanilla";
            this.txtPlanilla.ReadOnly = true;
            this.txtPlanilla.Size = new System.Drawing.Size(80, 20);
            this.txtPlanilla.TabIndex = 7;
            this.txtPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFIngreso
            // 
            this.txtFIngreso.Location = new System.Drawing.Point(75, 58);
            this.txtFIngreso.Name = "txtFIngreso";
            this.txtFIngreso.ReadOnly = true;
            this.txtFIngreso.Size = new System.Drawing.Size(85, 20);
            this.txtFIngreso.TabIndex = 6;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(75, 37);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(258, 20);
            this.txtNombres.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(75, 16);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(85, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(199, 62);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Planilla :";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(257, 20);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(37, 13);
            this.Label9.TabIndex = 2;
            this.Label9.Text = "Activo";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(38, 103);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(35, 13);
            this.Label11.TabIndex = 2;
            this.Label11.Text = "Area :";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(31, 83);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(41, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Cargo :";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(8, 62);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(64, 13);
            this.Label8.TabIndex = 2;
            this.Label8.Text = "Fecha Ing. :";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(17, 41);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(55, 13);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Nombres :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(26, 20);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(46, 13);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Codigo :";
            // 
            // dgTurno
            // 
            this.dgTurno.AllowUserToAddRows = false;
            this.dgTurno.AllowUserToResizeRows = false;
            this.dgTurno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTurno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FEC_INI,
            this.FEC_FIN,
            this.COD_HORARIO,
            this.COD_HORARIO_SEMANAL,
            this.COD_HORARIO_DIARIO,
            this.TIPO_HORARIO,
            this.DES_HORATRIO,
            this.VIGENT,
            this.FEC_ASIGNACION});
            this.dgTurno.Location = new System.Drawing.Point(356, 163);
            this.dgTurno.MultiSelect = false;
            this.dgTurno.Name = "dgTurno";
            this.dgTurno.ReadOnly = true;
            this.dgTurno.RowHeadersVisible = false;
            this.dgTurno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTurno.Size = new System.Drawing.Size(496, 318);
            this.dgTurno.TabIndex = 70;
            // 
            // FEC_INI
            // 
            this.FEC_INI.DataPropertyName = "FEC_INI";
            this.FEC_INI.HeaderText = "F. Desde";
            this.FEC_INI.Name = "FEC_INI";
            this.FEC_INI.ReadOnly = true;
            this.FEC_INI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FEC_INI.Width = 73;
            // 
            // FEC_FIN
            // 
            this.FEC_FIN.DataPropertyName = "FEC_FIN";
            this.FEC_FIN.HeaderText = "F. Hasta";
            this.FEC_FIN.Name = "FEC_FIN";
            this.FEC_FIN.ReadOnly = true;
            this.FEC_FIN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FEC_FIN.Width = 73;
            // 
            // COD_HORARIO
            // 
            this.COD_HORARIO.DataPropertyName = "COD_HORARIO";
            this.COD_HORARIO.HeaderText = "Cód";
            this.COD_HORARIO.Name = "COD_HORARIO";
            this.COD_HORARIO.ReadOnly = true;
            this.COD_HORARIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COD_HORARIO.Width = 30;
            // 
            // COD_HORARIO_SEMANAL
            // 
            this.COD_HORARIO_SEMANAL.DataPropertyName = "COD_HORARIO_SEMANAL";
            this.COD_HORARIO_SEMANAL.HeaderText = "CodSema";
            this.COD_HORARIO_SEMANAL.Name = "COD_HORARIO_SEMANAL";
            this.COD_HORARIO_SEMANAL.ReadOnly = true;
            this.COD_HORARIO_SEMANAL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COD_HORARIO_SEMANAL.Visible = false;
            this.COD_HORARIO_SEMANAL.Width = 30;
            // 
            // COD_HORARIO_DIARIO
            // 
            this.COD_HORARIO_DIARIO.DataPropertyName = "COD_HORARIO_DIARIO";
            this.COD_HORARIO_DIARIO.HeaderText = "CodDiari";
            this.COD_HORARIO_DIARIO.Name = "COD_HORARIO_DIARIO";
            this.COD_HORARIO_DIARIO.ReadOnly = true;
            this.COD_HORARIO_DIARIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COD_HORARIO_DIARIO.Visible = false;
            // 
            // TIPO_HORARIO
            // 
            this.TIPO_HORARIO.DataPropertyName = "TIPO_HORARIO";
            this.TIPO_HORARIO.HeaderText = "T";
            this.TIPO_HORARIO.Name = "TIPO_HORARIO";
            this.TIPO_HORARIO.ReadOnly = true;
            this.TIPO_HORARIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TIPO_HORARIO.Width = 25;
            // 
            // DES_HORATRIO
            // 
            this.DES_HORATRIO.DataPropertyName = "DES_HORARIO";
            this.DES_HORATRIO.HeaderText = "Descripción";
            this.DES_HORATRIO.Name = "DES_HORATRIO";
            this.DES_HORATRIO.ReadOnly = true;
            this.DES_HORATRIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DES_HORATRIO.Width = 260;
            // 
            // VIGENT
            // 
            this.VIGENT.DataPropertyName = "VIGENTE";
            this.VIGENT.HeaderText = "V";
            this.VIGENT.Name = "VIGENT";
            this.VIGENT.ReadOnly = true;
            this.VIGENT.Width = 25;
            // 
            // FEC_ASIGNACION
            // 
            this.FEC_ASIGNACION.DataPropertyName = "FEC_ASIGNACION";
            this.FEC_ASIGNACION.HeaderText = "FEC_ASIGNACION";
            this.FEC_ASIGNACION.Name = "FEC_ASIGNACION";
            this.FEC_ASIGNACION.ReadOnly = true;
            this.FEC_ASIGNACION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FEC_ASIGNACION.Visible = false;
            // 
            // dgTrabajador
            // 
            this.dgTrabajador.AllowUserToAddRows = false;
            this.dgTrabajador.AllowUserToResizeRows = false;
            this.dgTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTrabajador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgTrabajador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTrabajador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FICHA,
            this.VIGENTE,
            this.DTRABAJADOR,
            this.F_INGRESO,
            this.TIPO_PLANILLA,
            this.DCARGO,
            this.DAREA});
            this.dgTrabajador.Location = new System.Drawing.Point(9, 163);
            this.dgTrabajador.MultiSelect = false;
            this.dgTrabajador.Name = "dgTrabajador";
            this.dgTrabajador.ReadOnly = true;
            this.dgTrabajador.RowHeadersVisible = false;
            this.dgTrabajador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTrabajador.Size = new System.Drawing.Size(341, 318);
            this.dgTrabajador.TabIndex = 69;
            // 
            // FICHA
            // 
            this.FICHA.DataPropertyName = "FICHA";
            this.FICHA.HeaderText = "Código";
            this.FICHA.Name = "FICHA";
            this.FICHA.ReadOnly = true;
            this.FICHA.Width = 50;
            // 
            // VIGENTE
            // 
            this.VIGENTE.DataPropertyName = "VIGENTE";
            this.VIGENTE.HeaderText = "VIGENTE";
            this.VIGENTE.Name = "VIGENTE";
            this.VIGENTE.ReadOnly = true;
            this.VIGENTE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VIGENTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VIGENTE.Visible = false;
            // 
            // DTRABAJADOR
            // 
            this.DTRABAJADOR.DataPropertyName = "DTRABAJADOR";
            this.DTRABAJADOR.HeaderText = "Descripción";
            this.DTRABAJADOR.Name = "DTRABAJADOR";
            this.DTRABAJADOR.ReadOnly = true;
            this.DTRABAJADOR.Width = 270;
            // 
            // F_INGRESO
            // 
            this.F_INGRESO.DataPropertyName = "F_INGRESO";
            this.F_INGRESO.HeaderText = "FIngreso";
            this.F_INGRESO.Name = "F_INGRESO";
            this.F_INGRESO.ReadOnly = true;
            this.F_INGRESO.Visible = false;
            // 
            // TIPO_PLANILLA
            // 
            this.TIPO_PLANILLA.DataPropertyName = "TIPO_PLANILLA";
            this.TIPO_PLANILLA.HeaderText = "Planilla";
            this.TIPO_PLANILLA.Name = "TIPO_PLANILLA";
            this.TIPO_PLANILLA.ReadOnly = true;
            this.TIPO_PLANILLA.Visible = false;
            // 
            // DCARGO
            // 
            this.DCARGO.DataPropertyName = "DCARGO";
            this.DCARGO.HeaderText = "Cargo";
            this.DCARGO.Name = "DCARGO";
            this.DCARGO.ReadOnly = true;
            this.DCARGO.Visible = false;
            // 
            // DAREA
            // 
            this.DAREA.DataPropertyName = "DAREA";
            this.DAREA.HeaderText = "Area";
            this.DAREA.Name = "DAREA";
            this.DAREA.ReadOnly = true;
            this.DAREA.Visible = false;
            // 
            // cdResaltadoVigentes
            // 
            this.cdResaltadoVigentes.Color = System.Drawing.Color.Silver;
            // 
            // Frm_Horarios_HorariosAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 537);
            this.Controls.Add(this.chkVerInactivos);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgTurno);
            this.Controls.Add(this.dgTrabajador);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Horarios_HorariosAsignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Horarios";
            this.Load += new System.EventHandler(this.Frm_Horarios_HorariosAsignacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Horarios_HorariosAsignacion_KeyDown);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrabajador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.CheckBox chkVerInactivos;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.MaskedTextBox txtMBuscar;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tsNuevo;
        internal System.Windows.Forms.ToolStripButton tsEditar;
        internal System.Windows.Forms.ToolStripButton tsEliminar;
        internal System.Windows.Forms.ToolStripButton tsGrabar;
        internal System.Windows.Forms.ToolStripButton tsCancelar;
        internal System.Windows.Forms.ToolStripButton tsVigente;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.CheckBox chkVigente;
        internal System.Windows.Forms.ComboBox cboCodHorarioSemanal;
        internal System.Windows.Forms.ComboBox cboCodHorarioDiario;
        internal System.Windows.Forms.Label lblSem;
        internal System.Windows.Forms.ComboBox cboTHorario;
        internal System.Windows.Forms.Label lblDia;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtpFechaFin;
        internal System.Windows.Forms.DateTimePicker dtpFechaIni;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkActivo;
        internal System.Windows.Forms.TextBox txtArea;
        internal System.Windows.Forms.TextBox txtCargo;
        internal System.Windows.Forms.TextBox txtPlanilla;
        internal System.Windows.Forms.TextBox txtFIngreso;
        internal System.Windows.Forms.TextBox txtNombres;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DataGridView dgTurno;
        internal System.Windows.Forms.DataGridViewTextBoxColumn FEC_INI;
        internal System.Windows.Forms.DataGridViewTextBoxColumn FEC_FIN;
        internal System.Windows.Forms.DataGridViewTextBoxColumn COD_HORARIO;
        internal System.Windows.Forms.DataGridViewTextBoxColumn COD_HORARIO_SEMANAL;
        internal System.Windows.Forms.DataGridViewTextBoxColumn COD_HORARIO_DIARIO;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TIPO_HORARIO;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DES_HORATRIO;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn VIGENT;
        internal System.Windows.Forms.DataGridViewTextBoxColumn FEC_ASIGNACION;
        internal System.Windows.Forms.DataGridView dgTrabajador;
        internal System.Windows.Forms.DataGridViewTextBoxColumn FICHA;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn VIGENTE;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DTRABAJADOR;
        internal System.Windows.Forms.DataGridViewTextBoxColumn F_INGRESO;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TIPO_PLANILLA;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DCARGO;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DAREA;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.ColorDialog cdResaltadoVigentes;
    }
}