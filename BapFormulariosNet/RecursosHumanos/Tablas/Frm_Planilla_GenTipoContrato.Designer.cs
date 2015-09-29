namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Planilla_GenTipoContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Planilla_GenTipoContrato));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnnuevo = new System.Windows.Forms.ToolStripButton();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btneliminar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbformatocontrato = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbtipcontrato = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.tipocontratoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdttipocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocontratoname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dpdttipocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbar.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.AutoSize = false;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnnuevo,
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btneliminar,
            this.btnload,
            this.btncerrar,
            this.ToolStripSeparator1,
            this.btnLog});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(792, 31);
            this.toolbar.TabIndex = 6;
            this.toolbar.Text = "ToolStrip1";
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
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnLog
            // 
            this.btnLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLog.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.btnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(26, 28);
            this.btnLog.Text = "Log";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cmbformatocontrato);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.cmbtipcontrato);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtDescripcion);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(8, 29);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(776, 98);
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            // 
            // cmbformatocontrato
            // 
            this.cmbformatocontrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbformatocontrato.FormattingEnabled = true;
            this.cmbformatocontrato.Location = new System.Drawing.Point(108, 66);
            this.cmbformatocontrato.Name = "cmbformatocontrato";
            this.cmbformatocontrato.Size = new System.Drawing.Size(637, 21);
            this.cmbformatocontrato.TabIndex = 7;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(14, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(88, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Formato Contrato";
            // 
            // cmbtipcontrato
            // 
            this.cmbtipcontrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipcontrato.FormattingEnabled = true;
            this.cmbtipcontrato.Location = new System.Drawing.Point(108, 40);
            this.cmbtipcontrato.Name = "cmbtipcontrato";
            this.cmbtipcontrato.Size = new System.Drawing.Size(637, 21);
            this.cmbtipcontrato.TabIndex = 5;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(34, 44);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(68, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Rubro RTPS";
            // 
            // txtcodigo
            // 
            this.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigo.Location = new System.Drawing.Point(108, 15);
            this.txtcodigo.MaxLength = 2;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(60, 20);
            this.txtcodigo.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(62, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Código";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(246, 15);
            this.txtDescripcion.MaxLength = 80;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(499, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label4.Location = new System.Drawing.Point(177, 19);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Descripción";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Examinar);
            this.groupBox2.Location = new System.Drawing.Point(8, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 307);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 32;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipocontratoid,
            this.pdttipocontrato,
            this.tipocontratoname,
            this.dpdttipocontrato,
            this.formatocontrato});
            this.Examinar.Location = new System.Drawing.Point(9, 13);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Examinar.ShowRowErrors = false;
            this.Examinar.Size = new System.Drawing.Size(758, 285);
            this.Examinar.TabIndex = 8;
            this.Examinar.SelectionChanged += new System.EventHandler(this.Examinar_SelectionChanged);
            // 
            // tipocontratoid
            // 
            this.tipocontratoid.DataPropertyName = "tipocontratoid";
            this.tipocontratoid.HeaderText = "Código";
            this.tipocontratoid.Name = "tipocontratoid";
            this.tipocontratoid.ReadOnly = true;
            this.tipocontratoid.Width = 80;
            // 
            // pdttipocontrato
            // 
            this.pdttipocontrato.DataPropertyName = "pdttipocontrato";
            this.pdttipocontrato.HeaderText = "pdttipocontrato";
            this.pdttipocontrato.Name = "pdttipocontrato";
            this.pdttipocontrato.ReadOnly = true;
            this.pdttipocontrato.Visible = false;
            // 
            // tipocontratoname
            // 
            this.tipocontratoname.DataPropertyName = "tipocontratoname";
            this.tipocontratoname.HeaderText = "Descripción";
            this.tipocontratoname.Name = "tipocontratoname";
            this.tipocontratoname.ReadOnly = true;
            this.tipocontratoname.Width = 310;
            // 
            // dpdttipocontrato
            // 
            this.dpdttipocontrato.DataPropertyName = "dpdttipocontrato";
            this.dpdttipocontrato.HeaderText = "Rubro RTPS";
            this.dpdttipocontrato.Name = "dpdttipocontrato";
            this.dpdttipocontrato.ReadOnly = true;
            this.dpdttipocontrato.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dpdttipocontrato.Width = 320;
            // 
            // formatocontrato
            // 
            this.formatocontrato.DataPropertyName = "formatocontrato";
            this.formatocontrato.HeaderText = "formatocontrato";
            this.formatocontrato.Name = "formatocontrato";
            this.formatocontrato.ReadOnly = true;
            this.formatocontrato.Visible = false;
            // 
            // Frm_Planilla_GenTipoContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 437);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Planilla_GenTipoContrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planilla - Modalidades de Contrato";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Planilla_GenTipoContrato_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Planilla_GenTipoContrato_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Planilla_GenTipoContrato_KeyDown);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolbar;
        internal System.Windows.Forms.ToolStripButton btnnuevo;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btneliminar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox cmbformatocontrato;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbtipcontrato;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.DataGridView Examinar;
        private System.Windows.Forms.ToolStripButton btnLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocontratoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdttipocontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocontratoname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dpdttipocontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatocontrato;
    }
}