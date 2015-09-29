namespace BapFormulariosNet.RecursosHumanos
{
    partial class Frm_NumeracionPlanilla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NumeracionPlanilla));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbfiltrotipoplanilla = new System.Windows.Forms.ComboBox();
            this.txtfiltronombre = new System.Windows.Forms.TextBox();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbtipoquincena = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.frangotrabfin = new System.Windows.Forms.DateTimePicker();
            this.frangotrabini = new System.Windows.Forms.DateTimePicker();
            this.frangolabfin = new System.Windows.Forms.DateTimePicker();
            this.frangolabini = new System.Windows.Forms.DateTimePicker();
            this.cmbmes = new System.Windows.Forms.ComboBox();
            this.txtsemana = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cmbmodalidad = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.cmbtipoplanilla = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.barramain = new System.Windows.Forms.ToolStrip();
            this.btnnuevo = new System.Windows.Forms.ToolStripButton();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btneliminar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.btnlog = new System.Windows.Forms.ToolStripButton();
            this.btnprimero = new System.Windows.Forms.ToolStripButton();
            this.btnanterior = new System.Windows.Forms.ToolStripButton();
            this.btnsiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnultimo = new System.Windows.Forms.ToolStripButton();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.perianio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoplla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nsemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechafin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipcamb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechpini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechpfin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoquincena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.barramain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(6, 34);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(720, 483);
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
            this.TabPage1.Size = new System.Drawing.Size(712, 457);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Relación";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.cmbfiltrotipoplanilla);
            this.GroupBox2.Controls.Add(this.txtfiltronombre);
            this.GroupBox2.Controls.Add(this.btnfiltro);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Location = new System.Drawing.Point(6, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(700, 59);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = " Filtros ";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(367, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Tipo Planilla";
            // 
            // cmbfiltrotipoplanilla
            // 
            this.cmbfiltrotipoplanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltrotipoplanilla.Enabled = false;
            this.cmbfiltrotipoplanilla.FormattingEnabled = true;
            this.cmbfiltrotipoplanilla.Location = new System.Drawing.Point(370, 29);
            this.cmbfiltrotipoplanilla.Name = "cmbfiltrotipoplanilla";
            this.cmbfiltrotipoplanilla.Size = new System.Drawing.Size(226, 21);
            this.cmbfiltrotipoplanilla.TabIndex = 3;
            this.cmbfiltrotipoplanilla.SelectedIndexChanged += new System.EventHandler(this.cmbfiltrotipoplanilla_SelectedIndexChanged);
            // 
            // txtfiltronombre
            // 
            this.txtfiltronombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfiltronombre.Location = new System.Drawing.Point(11, 29);
            this.txtfiltronombre.Name = "txtfiltronombre";
            this.txtfiltronombre.Size = new System.Drawing.Size(337, 20);
            this.txtfiltronombre.TabIndex = 1;
            // 
            // btnfiltro
            // 
            //this.btnfiltro.Image = global::BapFormulariosNet.Properties.Resources.filtrar16;
            this.btnfiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltro.Location = new System.Drawing.Point(628, 20);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(56, 28);
            this.btnfiltro.TabIndex = 4;
            this.btnfiltro.Text = "&Filtrar";
            this.btnfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfiltro.UseVisualStyleBackColor = true;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label22.Location = new System.Drawing.Point(8, 13);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(121, 13);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Ocurrencias descripción";
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Examinar.ColumnHeadersHeight = 34;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perianio,
            this.asiento,
            this.perimes,
            this.tipoplla,
            this.planit,
            this.glosa,
            this.nsemana,
            this.fechaini,
            this.fechafin,
            this.afect,
            this.tipcamb,
            this.semana,
            this.fechpini,
            this.fechpfin,
            this.formapago,
            this.tipoquincena});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Examinar.DefaultCellStyle = dataGridViewCellStyle4;
            this.Examinar.Location = new System.Drawing.Point(6, 66);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Examinar.RowHeadersWidth = 24;
            this.Examinar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.Size = new System.Drawing.Size(700, 385);
            this.Examinar.TabIndex = 1;
            this.Examinar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Examinar_CellContentDoubleClick);
            this.Examinar.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Examinar_CellMouseDoubleClick);
            this.Examinar.Paint += new System.Windows.Forms.PaintEventHandler(this.Examinar_Paint);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(665, 457);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Datos";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cmbtipoquincena);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.frangotrabfin);
            this.GroupBox1.Controls.Add(this.frangotrabini);
            this.GroupBox1.Controls.Add(this.frangolabfin);
            this.GroupBox1.Controls.Add(this.frangolabini);
            this.GroupBox1.Controls.Add(this.cmbmes);
            this.GroupBox1.Controls.Add(this.txtsemana);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.cmbmodalidad);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.cmbtipoplanilla);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Location = new System.Drawing.Point(18, 16);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(627, 419);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // cmbtipoquincena
            // 
            this.cmbtipoquincena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoquincena.FormattingEnabled = true;
            this.cmbtipoquincena.Location = new System.Drawing.Point(396, 80);
            this.cmbtipoquincena.Name = "cmbtipoquincena";
            this.cmbtipoquincena.Size = new System.Drawing.Size(214, 21);
            this.cmbtipoquincena.TabIndex = 7;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label9.Location = new System.Drawing.Point(341, 84);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(53, 13);
            this.Label9.TabIndex = 6;
            this.Label9.Text = "Quincena";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label7.Location = new System.Drawing.Point(63, 140);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(27, 13);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "Mes";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label6.Location = new System.Drawing.Point(202, 195);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(78, 13);
            this.Label6.TabIndex = 17;
            this.Label6.Text = "Rango Trabajo";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(13, 195);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(77, 13);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Rango Laboral";
            // 
            // frangotrabfin
            // 
            this.frangotrabfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.frangotrabfin.Location = new System.Drawing.Point(283, 219);
            this.frangotrabfin.Name = "frangotrabfin";
            this.frangotrabfin.ShowCheckBox = true;
            this.frangotrabfin.Size = new System.Drawing.Size(102, 20);
            this.frangotrabfin.TabIndex = 19;
            // 
            // frangotrabini
            // 
            this.frangotrabini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.frangotrabini.Location = new System.Drawing.Point(283, 191);
            this.frangotrabini.Name = "frangotrabini";
            this.frangotrabini.ShowCheckBox = true;
            this.frangotrabini.Size = new System.Drawing.Size(102, 20);
            this.frangotrabini.TabIndex = 18;
            // 
            // frangolabfin
            // 
            this.frangolabfin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.frangolabfin.Location = new System.Drawing.Point(100, 219);
            this.frangolabfin.Name = "frangolabfin";
            this.frangolabfin.Size = new System.Drawing.Size(92, 20);
            this.frangolabfin.TabIndex = 16;
            // 
            // frangolabini
            // 
            this.frangolabini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.frangolabini.Location = new System.Drawing.Point(100, 191);
            this.frangolabini.Name = "frangolabini";
            this.frangolabini.Size = new System.Drawing.Size(92, 20);
            this.frangolabini.TabIndex = 15;
            // 
            // cmbmes
            // 
            this.cmbmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmes.FormattingEnabled = true;
            this.cmbmes.Location = new System.Drawing.Point(100, 136);
            this.cmbmes.Name = "cmbmes";
            this.cmbmes.Size = new System.Drawing.Size(234, 21);
            this.cmbmes.TabIndex = 11;
            // 
            // txtsemana
            // 
            this.txtsemana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsemana.Location = new System.Drawing.Point(100, 164);
            this.txtsemana.Name = "txtsemana";
            this.txtsemana.Size = new System.Drawing.Size(71, 20);
            this.txtsemana.TabIndex = 13;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label4.Location = new System.Drawing.Point(44, 168);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Semana";
            // 
            // cmbmodalidad
            // 
            this.cmbmodalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmodalidad.FormattingEnabled = true;
            this.cmbmodalidad.Location = new System.Drawing.Point(100, 108);
            this.cmbmodalidad.Name = "cmbmodalidad";
            this.cmbmodalidad.Size = new System.Drawing.Size(234, 21);
            this.cmbmodalidad.TabIndex = 9;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(34, 112);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(56, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Modalidad";
            // 
            // txtcodigo
            // 
            this.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(100, 24);
            this.txtcodigo.MaxLength = 8;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(92, 22);
            this.txtcodigo.TabIndex = 1;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label10.Location = new System.Drawing.Point(27, 57);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(63, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(100, 53);
            this.txtdescripcion.MaxLength = 60;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(404, 20);
            this.txtdescripcion.TabIndex = 3;
            // 
            // cmbtipoplanilla
            // 
            this.cmbtipoplanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoplanilla.FormattingEnabled = true;
            this.cmbtipoplanilla.Location = new System.Drawing.Point(100, 80);
            this.cmbtipoplanilla.Name = "cmbtipoplanilla";
            this.cmbtipoplanilla.Size = new System.Drawing.Size(234, 21);
            this.cmbtipoplanilla.TabIndex = 5;
            this.cmbtipoplanilla.SelectedIndexChanged += new System.EventHandler(this.cmbtipoplanilla_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(26, 84);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Tipo Planilla";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label8.Location = new System.Drawing.Point(50, 29);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Código";
            // 
            // barramain
            // 
            this.barramain.AutoSize = false;
            this.barramain.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.barramain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnnuevo,
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btneliminar,
            this.btnload,
            this.btncerrar,
            this.btnlog,
            this.btnprimero,
            this.btnanterior,
            this.btnsiguiente,
            this.btnultimo});
            this.barramain.Location = new System.Drawing.Point(0, 0);
            this.barramain.Name = "barramain";
            this.barramain.Size = new System.Drawing.Size(729, 31);
            this.barramain.TabIndex = 2;
            this.barramain.Text = "ToolStrip2";
            // 
            // btnnuevo
            // 
            this.btnnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnnuevo.Image = global::BapFormulariosNet.Properties.Resources.btn_nuevo;
            this.btnnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(26, 28);
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnmod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 28);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 28);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(26, 28);
            this.btncancelar.Text = "Deshacer";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btneliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar;
            this.btneliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(26, 28);
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnload
            // 
            this.btnload.AutoSize = false;
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnload.Image = global::BapFormulariosNet.Properties.Resources.btn_refresh;
            this.btnload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(30, 30);
            this.btnload.Text = "Actualizar";
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(26, 28);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnlog
            // 
            this.btnlog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnlog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btnlog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(26, 28);
            this.btnlog.Text = "Log - Seguridad";
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // btnprimero
            // 
            this.btnprimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnprimero.Image = global::BapFormulariosNet.Properties.Resources.btnInicio;
            this.btnprimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnprimero.Name = "btnprimero";
            this.btnprimero.Size = new System.Drawing.Size(26, 28);
            this.btnprimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprimero.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnprimero.ToolTipText = "Primer Registro";
            this.btnprimero.Click += new System.EventHandler(this.btnprimero_Click);
            // 
            // btnanterior
            // 
            this.btnanterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnanterior.Image = global::BapFormulariosNet.Properties.Resources.btnAnterior;
            this.btnanterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnanterior.Name = "btnanterior";
            this.btnanterior.Size = new System.Drawing.Size(26, 28);
            this.btnanterior.Text = "ToolStripButton2";
            this.btnanterior.ToolTipText = "Anterior Registro";
            this.btnanterior.Click += new System.EventHandler(this.btnanterior_Click);
            // 
            // btnsiguiente
            // 
            this.btnsiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnsiguiente.Image = global::BapFormulariosNet.Properties.Resources.btnSiguiente;
            this.btnsiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsiguiente.Name = "btnsiguiente";
            this.btnsiguiente.Size = new System.Drawing.Size(26, 28);
            this.btnsiguiente.Text = "ToolStripButton1";
            this.btnsiguiente.ToolTipText = "Siguiente Registro";
            this.btnsiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // btnultimo
            // 
            this.btnultimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnultimo.Image = global::BapFormulariosNet.Properties.Resources.btnUltimo;
            this.btnultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnultimo.Name = "btnultimo";
            this.btnultimo.Size = new System.Drawing.Size(26, 28);
            this.btnultimo.Text = "ToolStripButton3";
            this.btnultimo.ToolTipText = "Ultimo Registro";
            this.btnultimo.Click += new System.EventHandler(this.btnultimo_Click);
            // 
            // perianio
            // 
            this.perianio.DataPropertyName = "perianio";
            this.perianio.HeaderText = "Año";
            this.perianio.Name = "perianio";
            this.perianio.ReadOnly = true;
            this.perianio.Visible = false;
            // 
            // asiento
            // 
            this.asiento.DataPropertyName = "asiento";
            this.asiento.HeaderText = "Código";
            this.asiento.Name = "asiento";
            this.asiento.ReadOnly = true;
            this.asiento.Width = 80;
            // 
            // perimes
            // 
            this.perimes.DataPropertyName = "perimes";
            this.perimes.HeaderText = "Mes";
            this.perimes.Name = "perimes";
            this.perimes.ReadOnly = true;
            this.perimes.Width = 45;
            // 
            // tipoplla
            // 
            this.tipoplla.DataPropertyName = "tipoplla";
            this.tipoplla.HeaderText = "tipoplla";
            this.tipoplla.Name = "tipoplla";
            this.tipoplla.ReadOnly = true;
            this.tipoplla.Visible = false;
            // 
            // planit
            // 
            this.planit.DataPropertyName = "planit";
            this.planit.HeaderText = "planit";
            this.planit.Name = "planit";
            this.planit.ReadOnly = true;
            this.planit.Visible = false;
            // 
            // glosa
            // 
            this.glosa.DataPropertyName = "glosa";
            this.glosa.HeaderText = "Descripción";
            this.glosa.Name = "glosa";
            this.glosa.ReadOnly = true;
            this.glosa.Width = 330;
            // 
            // nsemana
            // 
            this.nsemana.DataPropertyName = "nsemana";
            this.nsemana.HeaderText = "Semana";
            this.nsemana.Name = "nsemana";
            this.nsemana.ReadOnly = true;
            this.nsemana.Width = 60;
            // 
            // fechaini
            // 
            this.fechaini.DataPropertyName = "fechaini";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaini.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaini.HeaderText = "Fecha Inicial";
            this.fechaini.Name = "fechaini";
            this.fechaini.ReadOnly = true;
            this.fechaini.Width = 70;
            // 
            // fechafin
            // 
            this.fechafin.DataPropertyName = "fechafin";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechafin.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechafin.HeaderText = "Fecha Final";
            this.fechafin.Name = "fechafin";
            this.fechafin.ReadOnly = true;
            this.fechafin.Width = 70;
            // 
            // afect
            // 
            this.afect.DataPropertyName = "afect";
            this.afect.HeaderText = "afect";
            this.afect.Name = "afect";
            this.afect.ReadOnly = true;
            this.afect.Visible = false;
            // 
            // tipcamb
            // 
            this.tipcamb.DataPropertyName = "tipcamb";
            this.tipcamb.HeaderText = "tipcamb";
            this.tipcamb.Name = "tipcamb";
            this.tipcamb.ReadOnly = true;
            this.tipcamb.Visible = false;
            // 
            // semana
            // 
            this.semana.DataPropertyName = "semana";
            this.semana.HeaderText = "semana";
            this.semana.Name = "semana";
            this.semana.ReadOnly = true;
            this.semana.Visible = false;
            // 
            // fechpini
            // 
            this.fechpini.DataPropertyName = "fechpini";
            this.fechpini.HeaderText = "fechpini";
            this.fechpini.Name = "fechpini";
            this.fechpini.ReadOnly = true;
            this.fechpini.Visible = false;
            // 
            // fechpfin
            // 
            this.fechpfin.DataPropertyName = "fechpfin";
            this.fechpfin.HeaderText = "fechpfin";
            this.fechpfin.Name = "fechpfin";
            this.fechpfin.ReadOnly = true;
            this.fechpfin.Visible = false;
            // 
            // formapago
            // 
            this.formapago.DataPropertyName = "formapago";
            this.formapago.HeaderText = "formapago";
            this.formapago.Name = "formapago";
            this.formapago.ReadOnly = true;
            this.formapago.Visible = false;
            // 
            // tipoquincena
            // 
            this.tipoquincena.DataPropertyName = "tipoquincena";
            this.tipoquincena.HeaderText = "tipoquincena";
            this.tipoquincena.Name = "tipoquincena";
            this.tipoquincena.ReadOnly = true;
            this.tipoquincena.Visible = false;
            // 
            // Frm_NumeracionPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 520);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.barramain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_NumeracionPlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numeración de Planilla";
            this.Activated += new System.EventHandler(this.Frm_NumeracionPlanilla_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_NumeracionPlanilla_FormClosing);
            this.Load += new System.EventHandler(this.Frm_NumeracionPlanilla_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_NumeracionPlanilla_KeyDown);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.barramain.ResumeLayout(false);
            this.barramain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbfiltrotipoplanilla;
        internal System.Windows.Forms.TextBox txtfiltronombre;
        internal System.Windows.Forms.Button btnfiltro;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cmbtipoquincena;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DateTimePicker frangotrabfin;
        internal System.Windows.Forms.DateTimePicker frangotrabini;
        internal System.Windows.Forms.DateTimePicker frangolabfin;
        internal System.Windows.Forms.DateTimePicker frangolabini;
        internal System.Windows.Forms.ComboBox cmbmes;
        internal System.Windows.Forms.TextBox txtsemana;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cmbmodalidad;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.ComboBox cmbtipoplanilla;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ToolStrip barramain;
        internal System.Windows.Forms.ToolStripButton btnnuevo;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btneliminar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripButton btnlog;
        internal System.Windows.Forms.ToolStripButton btnprimero;
        internal System.Windows.Forms.ToolStripButton btnanterior;
        internal System.Windows.Forms.ToolStripButton btnsiguiente;
        internal System.Windows.Forms.ToolStripButton btnultimo;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn perianio;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoplla;
        private System.Windows.Forms.DataGridViewTextBoxColumn planit;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaini;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechafin;
        private System.Windows.Forms.DataGridViewTextBoxColumn afect;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipcamb;
        private System.Windows.Forms.DataGridViewTextBoxColumn semana;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechpini;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechpfin;
        private System.Windows.Forms.DataGridViewTextBoxColumn formapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoquincena;
    }
}