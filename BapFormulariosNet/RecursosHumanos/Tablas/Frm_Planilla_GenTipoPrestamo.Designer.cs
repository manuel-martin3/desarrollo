namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Planilla_GenTipoPrestamo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Planilla_GenTipoPrestamo));
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfiltronombre = new System.Windows.Forms.TextBox();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkactivo = new System.Windows.Forms.CheckBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cprestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dprestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoprestamo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barramain.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.barramain.Size = new System.Drawing.Size(581, 31);
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
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(10, 34);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(562, 371);
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
            this.TabPage1.Size = new System.Drawing.Size(554, 345);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Relación";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtfiltronombre);
            this.GroupBox2.Controls.Add(this.btnfiltro);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Location = new System.Drawing.Point(8, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(537, 59);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = " Filtros ";
            // 
            // txtfiltronombre
            // 
            this.txtfiltronombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtfiltronombre.Location = new System.Drawing.Point(17, 30);
            this.txtfiltronombre.Name = "txtfiltronombre";
            this.txtfiltronombre.Size = new System.Drawing.Size(393, 20);
            this.txtfiltronombre.TabIndex = 1;
            // 
            // btnfiltro
            // 
            //this.btnfiltro.Image = global::BapFormulariosNet.Properties.Resources.filtrar16;
            this.btnfiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfiltro.Location = new System.Drawing.Point(456, 23);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(60, 29);
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
            this.Label22.Location = new System.Drawing.Point(17, 15);
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
            this.Examinar.ColumnHeadersHeight = 32;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cprestamo,
            this.dprestamo,
            this.estadoprestamo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Examinar.DefaultCellStyle = dataGridViewCellStyle2;
            this.Examinar.Location = new System.Drawing.Point(8, 66);
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
            this.Examinar.Size = new System.Drawing.Size(537, 270);
            this.Examinar.TabIndex = 1;
            this.Examinar.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Examinar_CellContentDoubleClick);
            this.Examinar.Paint += new System.Windows.Forms.PaintEventHandler(this.Examinar_Paint);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox1);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(554, 345);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Datos";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkactivo);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Location = new System.Drawing.Point(18, 21);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(514, 98);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // chkactivo
            // 
            this.chkactivo.AutoSize = true;
            this.chkactivo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkactivo.Location = new System.Drawing.Point(143, 71);
            this.chkactivo.Name = "chkactivo";
            this.chkactivo.Size = new System.Drawing.Size(56, 17);
            this.chkactivo.TabIndex = 4;
            this.chkactivo.TabStop = false;
            this.chkactivo.Text = "Activo";
            this.chkactivo.UseVisualStyleBackColor = true;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label10.Location = new System.Drawing.Point(71, 48);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(63, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(143, 45);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(347, 20);
            this.txtdescripcion.TabIndex = 3;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label8.Location = new System.Drawing.Point(94, 24);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Código";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(143, 19);
            this.txtcodigo.MaxLength = 2;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(36, 22);
            this.txtcodigo.TabIndex = 1;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // cprestamo
            // 
            this.cprestamo.DataPropertyName = "cprestamo";
            this.cprestamo.HeaderText = "Código";
            this.cprestamo.Name = "cprestamo";
            this.cprestamo.ReadOnly = true;
            this.cprestamo.Width = 70;
            // 
            // dprestamo
            // 
            this.dprestamo.DataPropertyName = "dprestamo";
            this.dprestamo.HeaderText = "Descripción";
            this.dprestamo.Name = "dprestamo";
            this.dprestamo.ReadOnly = true;
            this.dprestamo.Width = 360;
            // 
            // estadoprestamo
            // 
            this.estadoprestamo.DataPropertyName = "estadoprestamo";
            this.estadoprestamo.HeaderText = "Activo";
            this.estadoprestamo.Name = "estadoprestamo";
            this.estadoprestamo.ReadOnly = true;
            this.estadoprestamo.Width = 60;
            // 
            // Frm_Planilla_GenTipoPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 412);
            this.Controls.Add(this.barramain);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_Planilla_GenTipoPrestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipos de Préstamo";
            this.Activated += new System.EventHandler(this.Frm_Planilla_GenTipoPrestamo_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Planilla_GenTipoPrestamo_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Planilla_GenTipoPrestamo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Planilla_GenTipoPrestamo_KeyDown);
            this.barramain.ResumeLayout(false);
            this.barramain.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtfiltronombre;
        internal System.Windows.Forms.Button btnfiltro;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox chkactivo;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cprestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dprestamo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadoprestamo;
    }
}