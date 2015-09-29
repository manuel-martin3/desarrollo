namespace BapFormulariosNet.DL0Logistica
{
    partial class Frm_attachedfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_attachedfile));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVer = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.btnnombrefile = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtnombrearchivo = new System.Windows.Forms.TextBox();
            this.dgvfileatached = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docglosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnnuevo = new System.Windows.Forms.ToolStripButton();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btneliminar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfileatached)).BeginInit();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btnVer);
            this.panel1.Controls.Add(this.Label4);
            this.panel1.Controls.Add(this.txtdescripcion);
            this.panel1.Controls.Add(this.btnnombrefile);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.txtcodigo);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(-5, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 51);
            this.panel1.TabIndex = 7;
            // 
            // btnVer
            // 
            this.btnVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer.Location = new System.Drawing.Point(694, 14);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(85, 30);
            this.btnVer.TabIndex = 7;
            this.btnVer.Text = "&Ver Contenido";
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(61, 4);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(61, 21);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(528, 20);
            this.txtdescripcion.TabIndex = 3;
            // 
            // btnnombrefile
            // 
            this.btnnombrefile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnombrefile.Image = global::BapFormulariosNet.Properties.Resources.go_attach;
            this.btnnombrefile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnombrefile.Location = new System.Drawing.Point(603, 14);
            this.btnnombrefile.Name = "btnnombrefile";
            this.btnnombrefile.Size = new System.Drawing.Size(85, 30);
            this.btnnombrefile.TabIndex = 6;
            this.btnnombrefile.Text = "&Archivo  ";
            this.btnnombrefile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnombrefile.UseVisualStyleBackColor = true;
            this.btnnombrefile.Click += new System.EventHandler(this.btnnombrefile_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(15, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Código";
            // 
            // txtcodigo
            // 
            this.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigo.Location = new System.Drawing.Point(15, 21);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(40, 20);
            this.txtcodigo.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Controls.Add(this.txtnombrearchivo);
            this.panel2.Location = new System.Drawing.Point(-4, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 31);
            this.panel2.TabIndex = 8;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(6, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(83, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Nombre Archivo";
            // 
            // txtnombrearchivo
            // 
            this.txtnombrearchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombrearchivo.Location = new System.Drawing.Point(95, 3);
            this.txtnombrearchivo.Name = "txtnombrearchivo";
            this.txtnombrearchivo.Size = new System.Drawing.Size(485, 20);
            this.txtnombrearchivo.TabIndex = 5;
            // 
            // dgvfileatached
            // 
            this.dgvfileatached.AllowUserToAddRows = false;
            this.dgvfileatached.AllowUserToDeleteRows = false;
            this.dgvfileatached.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvfileatached.ColumnHeadersHeight = 32;
            this.dgvfileatached.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.docglosa,
            this.documen,
            this.docname});
            this.dgvfileatached.Location = new System.Drawing.Point(0, 115);
            this.dgvfileatached.MultiSelect = false;
            this.dgvfileatached.Name = "dgvfileatached";
            this.dgvfileatached.ReadOnly = true;
            this.dgvfileatached.RowHeadersWidth = 24;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvfileatached.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvfileatached.ShowRowErrors = false;
            this.dgvfileatached.Size = new System.Drawing.Size(774, 315);
            this.dgvfileatached.TabIndex = 9;
            this.dgvfileatached.SelectionChanged += new System.EventHandler(this.dgvfileatached_SelectionChanged);
            // 
            // item
            // 
            this.item.DataPropertyName = "item";
            this.item.HeaderText = "Código";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 70;
            // 
            // docglosa
            // 
            this.docglosa.DataPropertyName = "docglosa";
            this.docglosa.HeaderText = "Descripción";
            this.docglosa.Name = "docglosa";
            this.docglosa.ReadOnly = true;
            this.docglosa.Width = 410;
            // 
            // documen
            // 
            this.documen.DataPropertyName = "documen";
            this.documen.HeaderText = "plantillaword";
            this.documen.Name = "documen";
            this.documen.ReadOnly = true;
            this.documen.Visible = false;
            // 
            // docname
            // 
            this.docname.DataPropertyName = "docname";
            this.docname.HeaderText = "Nombre Archivo";
            this.docname.Name = "docname";
            this.docname.ReadOnly = true;
            this.docname.Width = 250;
            // 
            // btnnuevo
            // 
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
            this.btnload.Image = global::BapFormulariosNet.Properties.Resources.go_update;
            this.btnload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(30, 30);
            this.btnload.Text = "Actualizar";
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.go_out2;
            this.btncerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(24, 28);
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(26, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(26, 28);
            this.toolStripButton2.Text = "toolStripButton2";
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
            this.btnLog,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(787, 31);
            this.toolbar.TabIndex = 4;
            this.toolbar.Text = "ToolStrip1";
            // 
            // Frm_attachedfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 442);
            this.Controls.Add(this.dgvfileatached);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolbar);
            this.Name = "Frm_attachedfile";
            this.Text = "Frm_attachedfile";
            this.Load += new System.EventHandler(this.Frm_attachedfile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfileatached)).EndInit();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnVer;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Button btnnombrefile;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtnombrearchivo;
        internal System.Windows.Forms.DataGridView dgvfileatached;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn docglosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn documen;
        private System.Windows.Forms.DataGridViewTextBoxColumn docname;
        internal System.Windows.Forms.ToolStripButton btnnuevo;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btneliminar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnLog;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        internal System.Windows.Forms.ToolStrip toolbar;
    }
}