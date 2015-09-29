namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_RegimenPensionario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegimenPensionario));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfiltronombre = new System.Windows.Forms.TextBox();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.regipenid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regipenname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regipenabrv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdtregimen_18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afpnet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtsiglaafpnet = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtabreviatura = new System.Windows.Forms.TextBox();
            this.cmbrubrorpts = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
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
            this.TabControl1.Location = new System.Drawing.Point(8, 34);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(734, 415);
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
            this.TabPage1.Size = new System.Drawing.Size(726, 389);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Relación";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtfiltronombre);
            this.GroupBox2.Controls.Add(this.btnfiltro);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Location = new System.Drawing.Point(6, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(712, 61);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = " Filtros ";
            // 
            // txtfiltronombre
            // 
            this.txtfiltronombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfiltronombre.Location = new System.Drawing.Point(11, 31);
            this.txtfiltronombre.Name = "txtfiltronombre";
            this.txtfiltronombre.Size = new System.Drawing.Size(393, 20);
            this.txtfiltronombre.TabIndex = 1;
            // 
            // btnfiltro
            // 
            //this.btnfiltro.Image = global::BapFormulariosNet.Properties.Resources.filtrar16;
            this.btnfiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltro.Location = new System.Drawing.Point(637, 25);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(58, 26);
            this.btnfiltro.TabIndex = 6;
            this.btnfiltro.Text = "&Filtrar";
            this.btnfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfiltro.UseVisualStyleBackColor = true;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label22.Location = new System.Drawing.Point(8, 15);
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
            this.regipenid,
            this.regipenname,
            this.regipenabrv,
            this.pdtregimen_18,
            this.descripcion,
            this.status,
            this.afpnet});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Examinar.DefaultCellStyle = dataGridViewCellStyle2;
            this.Examinar.Location = new System.Drawing.Point(6, 71);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Examinar.RowHeadersWidth = 24;
            this.Examinar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.Size = new System.Drawing.Size(712, 309);
            this.Examinar.TabIndex = 1;
            this.Examinar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Examinar_CellContentDoubleClick);
            this.Examinar.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Examinar_CellMouseDoubleClick);
            this.Examinar.Paint += new System.Windows.Forms.PaintEventHandler(this.Examinar_Paint);
            // 
            // regipenid
            // 
            this.regipenid.DataPropertyName = "regipenid";
            this.regipenid.HeaderText = "Código";
            this.regipenid.Name = "regipenid";
            this.regipenid.ReadOnly = true;
            this.regipenid.Width = 66;
            // 
            // regipenname
            // 
            this.regipenname.DataPropertyName = "regipenname";
            this.regipenname.HeaderText = "Descripción";
            this.regipenname.Name = "regipenname";
            this.regipenname.ReadOnly = true;
            this.regipenname.Width = 260;
            // 
            // regipenabrv
            // 
            this.regipenabrv.DataPropertyName = "regipenabrv";
            this.regipenabrv.HeaderText = "regipenabrv";
            this.regipenabrv.Name = "regipenabrv";
            this.regipenabrv.ReadOnly = true;
            this.regipenabrv.Visible = false;
            // 
            // pdtregimen_18
            // 
            this.pdtregimen_18.DataPropertyName = "pdtregimen_18";
            this.pdtregimen_18.HeaderText = "pdtregimen_18";
            this.pdtregimen_18.Name = "pdtregimen_18";
            this.pdtregimen_18.ReadOnly = true;
            this.pdtregimen_18.Visible = false;
            this.pdtregimen_18.Width = 55;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Código RTPS";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 260;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "flag_18";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // afpnet
            // 
            this.afpnet.DataPropertyName = "afpnet";
            this.afpnet.HeaderText = "Sigla AFP NET";
            this.afpnet.Name = "afpnet";
            this.afpnet.ReadOnly = true;
            this.afpnet.Width = 80;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(726, 389);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Datos";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtsiglaafpnet);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtabreviatura);
            this.GroupBox1.Controls.Add(this.cmbrubrorpts);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Location = new System.Drawing.Point(20, 18);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(681, 346);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(56, 135);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(78, 13);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Sigla AFP NET";
            // 
            // txtsiglaafpnet
            // 
            this.txtsiglaafpnet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsiglaafpnet.Location = new System.Drawing.Point(143, 132);
            this.txtsiglaafpnet.Name = "txtsiglaafpnet";
            this.txtsiglaafpnet.Size = new System.Drawing.Size(112, 20);
            this.txtsiglaafpnet.TabIndex = 9;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(73, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Abreviatura";
            // 
            // txtabreviatura
            // 
            this.txtabreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtabreviatura.Location = new System.Drawing.Point(143, 79);
            this.txtabreviatura.Name = "txtabreviatura";
            this.txtabreviatura.Size = new System.Drawing.Size(112, 20);
            this.txtabreviatura.TabIndex = 5;
            // 
            // cmbrubrorpts
            // 
            this.cmbrubrorpts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbrubrorpts.FormattingEnabled = true;
            this.cmbrubrorpts.Location = new System.Drawing.Point(143, 105);
            this.cmbrubrorpts.Name = "cmbrubrorpts";
            this.cmbrubrorpts.Size = new System.Drawing.Size(404, 21);
            this.cmbrubrorpts.TabIndex = 7;
            this.cmbrubrorpts.Visible = false;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label9.Location = new System.Drawing.Point(66, 108);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(68, 13);
            this.Label9.TabIndex = 6;
            this.Label9.Text = "Rubro RPTS";
            this.Label9.Visible = false;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label10.Location = new System.Drawing.Point(71, 56);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(63, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(143, 53);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(404, 20);
            this.txtdescripcion.TabIndex = 3;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label8.Location = new System.Drawing.Point(94, 32);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Código";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(143, 27);
            this.txtcodigo.MaxLength = 2;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(36, 22);
            this.txtcodigo.TabIndex = 1;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
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
            this.barramain.Size = new System.Drawing.Size(747, 31);
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
            this.btnlog.ToolTipText = "Log - Seguridad";
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
            // Frm_RegimenPensionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 454);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.barramain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_RegimenPensionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla 11: Régimen Pensionario";
            this.Activated += new System.EventHandler(this.Frm_RegimenPensionario_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_RegimenPensionario_FormClosing);
            this.Load += new System.EventHandler(this.Frm_RegimenPensionario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_RegimenPensionario_KeyDown);
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

        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtfiltronombre;
        internal System.Windows.Forms.Button btnfiltro;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtsiglaafpnet;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtabreviatura;
        internal System.Windows.Forms.ComboBox cmbrubrorpts;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtcodigo;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn regipenid;
        private System.Windows.Forms.DataGridViewTextBoxColumn regipenname;
        private System.Windows.Forms.DataGridViewTextBoxColumn regipenabrv;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdtregimen_18;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn afpnet;
    }
}