namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Planilla_PlantillaContratos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Planilla_PlantillaContratos));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnnombrefile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_tipoestado = new System.Windows.Forms.ComboBox();
            this.cmb_tipocontrato = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtnombrearchivo = new System.Windows.Forms.TextBox();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.plantillaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plantillaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plantillaword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plantilladoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocontratoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbar.SuspendLayout();
            this.GroupBox1.SuspendLayout();
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
            this.toolbar.TabIndex = 3;
            this.toolbar.Text = "ToolStrip1";
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnnuevo.Image = global::BapFormulariosNet.Properties.Resources.go_new3;
            this.btnnuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(23, 28);
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.Edit;
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
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.go_undo2;
            this.btncancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(24, 28);
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
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.BackgroundImage = global::BapFormulariosNet.Properties.Resources.bannerblue3;
            this.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupBox1.Controls.Add(this.panel1);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.btnVer);
            this.GroupBox1.Controls.Add(this.btnnombrefile);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.cmb_tipoestado);
            this.GroupBox1.Controls.Add(this.cmb_tipocontrato);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txtnombrearchivo);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(10, 32);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(773, 141);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Archivo";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BapFormulariosNet.Properties.Resources.btn_crearcarpeta;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(600, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 104);
            this.panel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(59, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estado:";
            // 
            // btnVer
            // 
            this.btnVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer.Location = new System.Drawing.Point(407, 85);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(85, 35);
            this.btnVer.TabIndex = 7;
            this.btnVer.Text = "&Ver Contenido";
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnnombrefile
            // 
            this.btnnombrefile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnombrefile.Image = global::BapFormulariosNet.Properties.Resources.go_attach;
            this.btnnombrefile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnombrefile.Location = new System.Drawing.Point(498, 85);
            this.btnnombrefile.Name = "btnnombrefile";
            this.btnnombrefile.Size = new System.Drawing.Size(85, 35);
            this.btnnombrefile.TabIndex = 6;
            this.btnnombrefile.Text = "&Archivo  ";
            this.btnnombrefile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnombrefile.UseVisualStyleBackColor = true;
            this.btnnombrefile.Click += new System.EventHandler(this.btnnombrefile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "TipoContrato:";
            // 
            // cmb_tipoestado
            // 
            this.cmb_tipoestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipoestado.FormattingEnabled = true;
            this.cmb_tipoestado.Location = new System.Drawing.Point(112, 108);
            this.cmb_tipoestado.Name = "cmb_tipoestado";
            this.cmb_tipoestado.Size = new System.Drawing.Size(154, 21);
            this.cmb_tipoestado.TabIndex = 7;
            // 
            // cmb_tipocontrato
            // 
            this.cmb_tipocontrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipocontrato.FormattingEnabled = true;
            this.cmb_tipocontrato.Location = new System.Drawing.Point(112, 85);
            this.cmb_tipocontrato.Name = "cmb_tipocontrato";
            this.cmb_tipocontrato.Size = new System.Drawing.Size(289, 21);
            this.cmb_tipocontrato.TabIndex = 6;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(9, 63);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(101, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Nombre Archivo:";
            // 
            // txtnombrearchivo
            // 
            this.txtnombrearchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombrearchivo.Location = new System.Drawing.Point(112, 59);
            this.txtnombrearchivo.Name = "txtnombrearchivo";
            this.txtnombrearchivo.Size = new System.Drawing.Size(471, 20);
            this.txtnombrearchivo.TabIndex = 5;
            // 
            // txtcodigo
            // 
            this.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigo.Location = new System.Drawing.Point(9, 37);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(40, 20);
            this.txtcodigo.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(9, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Código";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(55, 37);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(528, 20);
            this.txtdescripcion.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(55, 20);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(74, 13);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Descripción";
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 32;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.plantillaid,
            this.plantillaname,
            this.plantillaword,
            this.plantilladoc,
            this.tipocontratoid,
            this.tipoestado});
            this.Examinar.Location = new System.Drawing.Point(12, 179);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Examinar.ShowRowErrors = false;
            this.Examinar.Size = new System.Drawing.Size(774, 252);
            this.Examinar.TabIndex = 4;
            this.Examinar.SelectionChanged += new System.EventHandler(this.Examinar_SelectionChanged);
            // 
            // plantillaid
            // 
            this.plantillaid.DataPropertyName = "plantillaid";
            this.plantillaid.HeaderText = "Código";
            this.plantillaid.Name = "plantillaid";
            this.plantillaid.ReadOnly = true;
            this.plantillaid.Width = 70;
            // 
            // plantillaname
            // 
            this.plantillaname.DataPropertyName = "plantillaname";
            this.plantillaname.HeaderText = "Descripción";
            this.plantillaname.Name = "plantillaname";
            this.plantillaname.ReadOnly = true;
            this.plantillaname.Width = 410;
            // 
            // plantillaword
            // 
            this.plantillaword.DataPropertyName = "plantillaword";
            this.plantillaword.HeaderText = "plantillaword";
            this.plantillaword.Name = "plantillaword";
            this.plantillaword.ReadOnly = true;
            this.plantillaword.Visible = false;
            // 
            // plantilladoc
            // 
            this.plantilladoc.DataPropertyName = "plantilladoc";
            this.plantilladoc.HeaderText = "Nombre Archivo";
            this.plantilladoc.Name = "plantilladoc";
            this.plantilladoc.ReadOnly = true;
            this.plantilladoc.Width = 250;
            // 
            // tipocontratoid
            // 
            this.tipocontratoid.DataPropertyName = "tipocontratoid";
            this.tipocontratoid.HeaderText = "TipoContrato";
            this.tipocontratoid.Name = "tipocontratoid";
            this.tipocontratoid.ReadOnly = true;
            this.tipocontratoid.Visible = false;
            // 
            // tipoestado
            // 
            this.tipoestado.DataPropertyName = "tipoestado";
            this.tipoestado.HeaderText = "Estado";
            this.tipoestado.Name = "tipoestado";
            this.tipoestado.ReadOnly = true;
            this.tipoestado.Visible = false;
            // 
            // Frm_Planilla_PlantillaContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 443);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_Planilla_PlantillaContratos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Almacenar Documentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Planilla_PlantillaContratos_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Planilla_PlantillaContratos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Planilla_PlantillaContratos_KeyDown);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
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
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnVer;
        internal System.Windows.Forms.Button btnnombrefile;
        internal System.Windows.Forms.TextBox txtnombrearchivo;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ToolStripButton btnLog;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_tipoestado;
        private System.Windows.Forms.ComboBox cmb_tipocontrato;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn plantillaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn plantillaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn plantillaword;
        private System.Windows.Forms.DataGridViewTextBoxColumn plantilladoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocontratoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoestado;
    }
}