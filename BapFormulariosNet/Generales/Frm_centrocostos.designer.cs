namespace BapFormulariosNet.GENERALES
{
    partial class Frm_centrocostos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_centrocostos));
            this.gbtncentrocosto = new System.Windows.Forms.ToolStrip();
            this.btnnew = new System.Windows.Forms.ToolStripButton();
            this.btnedit = new System.Windows.Forms.ToolStripButton();
            this.btnsave = new System.Windows.Forms.ToolStripButton();
            this.btnredo = new System.Windows.Forms.ToolStripButton();
            this.btndelete = new System.Windows.Forms.ToolStripButton();
            this.btnprint = new System.Windows.Forms.ToolStripButton();
            this.btnexit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btninicial = new System.Windows.Forms.ToolStripButton();
            this.btnanterior = new System.Windows.Forms.ToolStripButton();
            this.btnsiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnultimo = new System.Windows.Forms.ToolStripButton();
            this.gridcentrocostos = new System.Windows.Forms.DataGridView();
            this.cencosid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosdivi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosanalitica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkanalitica = new System.Windows.Forms.CheckBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rbanulado = new System.Windows.Forms.RadioButton();
            this.rbactivo = new System.Windows.Forms.RadioButton();
            this.txtclasecuenta = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbtncentrocosto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcentrocostos)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbtncentrocosto
            // 
            this.gbtncentrocosto.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.gbtncentrocosto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnnew,
            this.btnedit,
            this.btnsave,
            this.btnredo,
            this.btndelete,
            this.btnprint,
            this.btnexit,
            this.toolStripSeparator1,
            this.btninicial,
            this.btnanterior,
            this.btnsiguiente,
            this.btnultimo});
            this.gbtncentrocosto.Location = new System.Drawing.Point(0, 0);
            this.gbtncentrocosto.Name = "gbtncentrocosto";
            this.gbtncentrocosto.Size = new System.Drawing.Size(710, 31);
            this.gbtncentrocosto.TabIndex = 0;
            this.gbtncentrocosto.Text = "toolStrip1";
            // 
            // btnnew
            // 
            this.btnnew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnnew.Image = global::BapFormulariosNet.Properties.Resources.btn_nuevo20;
            this.btnnew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(28, 28);
            this.btnnew.Text = "Nuevo";
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnedit
            // 
            this.btnedit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnedit.Image = global::BapFormulariosNet.Properties.Resources.btn_editar20;
            this.btnedit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(28, 28);
            this.btnedit.Text = "Editar";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnsave
            // 
            this.btnsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnsave.Image = global::BapFormulariosNet.Properties.Resources.btn_imprimir;
            this.btnsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(28, 28);
            this.btnsave.Text = "Guardar";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnredo
            // 
            this.btnredo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnredo.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar20;
            this.btnredo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnredo.Name = "btnredo";
            this.btnredo.Size = new System.Drawing.Size(28, 28);
            this.btnredo.Text = "Deshacer";
            this.btnredo.Click += new System.EventHandler(this.btnredo_Click);
            // 
            // btndelete
            // 
            this.btndelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btndelete.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar20;
            this.btndelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(28, 28);
            this.btndelete.Text = "Anular";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnprint
            // 
            this.btnprint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnprint.Image = global::BapFormulariosNet.Properties.Resources.btn_imprimir20;
            this.btnprint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(28, 28);
            this.btnprint.Text = "Imprimir";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnexit
            // 
            this.btnexit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnexit.Image = global::BapFormulariosNet.Properties.Resources.btn_salir20;
            this.btnexit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(28, 28);
            this.btnexit.Text = "Salir";
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btninicial
            // 
            this.btninicial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btninicial.Image = global::BapFormulariosNet.Properties.Resources.btn_primero20;
            this.btninicial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btninicial.Name = "btninicial";
            this.btninicial.Size = new System.Drawing.Size(28, 28);
            this.btninicial.Text = "Primer registro";
            this.btninicial.Click += new System.EventHandler(this.btninicial_Click);
            // 
            // btnanterior
            // 
            this.btnanterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnanterior.Image = global::BapFormulariosNet.Properties.Resources.btn_anterior20;
            this.btnanterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnanterior.Name = "btnanterior";
            this.btnanterior.Size = new System.Drawing.Size(28, 28);
            this.btnanterior.Text = "Anterior registro";
            this.btnanterior.Click += new System.EventHandler(this.btnanterior_Click);
            // 
            // btnsiguiente
            // 
            this.btnsiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnsiguiente.Image = global::BapFormulariosNet.Properties.Resources.btn_siguiente20;
            this.btnsiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsiguiente.Name = "btnsiguiente";
            this.btnsiguiente.Size = new System.Drawing.Size(28, 28);
            this.btnsiguiente.Text = "Siguiente registro";
            this.btnsiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // btnultimo
            // 
            this.btnultimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnultimo.Image = global::BapFormulariosNet.Properties.Resources.btn_ultimo20;
            this.btnultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnultimo.Name = "btnultimo";
            this.btnultimo.Size = new System.Drawing.Size(28, 28);
            this.btnultimo.Text = "Ultimo registro";
            this.btnultimo.Click += new System.EventHandler(this.btnultimo_Click);
            // 
            // gridcentrocostos
            // 
            this.gridcentrocostos.AllowUserToAddRows = false;
            this.gridcentrocostos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridcentrocostos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridcentrocostos.ColumnHeadersHeight = 32;
            this.gridcentrocostos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cencosid,
            this.cencosname,
            this.cencosdivi,
            this.cencosanalitica,
            this.Status,
            this.usuar,
            this.fecre,
            this.feact});
            this.gridcentrocostos.Location = new System.Drawing.Point(9, 93);
            this.gridcentrocostos.MultiSelect = false;
            this.gridcentrocostos.Name = "gridcentrocostos";
            this.gridcentrocostos.ReadOnly = true;
            this.gridcentrocostos.RowHeadersWidth = 26;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridcentrocostos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridcentrocostos.ShowRowErrors = false;
            this.gridcentrocostos.Size = new System.Drawing.Size(692, 376);
            this.gridcentrocostos.TabIndex = 2;
            this.gridcentrocostos.SelectionChanged += new System.EventHandler(this.gridcentrocostos_SelectionChanged);
            this.gridcentrocostos.Paint += new System.Windows.Forms.PaintEventHandler(this.gridcentrocostos_Paint);
            // 
            // cencosid
            // 
            this.cencosid.DataPropertyName = "cencosid";
            this.cencosid.HeaderText = "Código";
            this.cencosid.Name = "cencosid";
            this.cencosid.ReadOnly = true;
            this.cencosid.Width = 80;
            // 
            // cencosname
            // 
            this.cencosname.DataPropertyName = "cencosname";
            this.cencosname.HeaderText = "Descripción";
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Width = 400;
            // 
            // cencosdivi
            // 
            this.cencosdivi.DataPropertyName = "cencosdivi";
            this.cencosdivi.HeaderText = "Cuenta";
            this.cencosdivi.Name = "cencosdivi";
            this.cencosdivi.ReadOnly = true;
            this.cencosdivi.Width = 80;
            // 
            // cencosanalitica
            // 
            this.cencosanalitica.DataPropertyName = "cencosanalitica";
            this.cencosanalitica.HeaderText = "Análisis";
            this.cencosanalitica.Name = "cencosanalitica";
            this.cencosanalitica.ReadOnly = true;
            this.cencosanalitica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cencosanalitica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cencosanalitica.Width = 80;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            this.Status.Width = 55;
            // 
            // usuar
            // 
            this.usuar.DataPropertyName = "usuar";
            this.usuar.HeaderText = "Usuario";
            this.usuar.Name = "usuar";
            this.usuar.ReadOnly = true;
            this.usuar.Visible = false;
            this.usuar.Width = 120;
            // 
            // fecre
            // 
            this.fecre.DataPropertyName = "fecre";
            this.fecre.HeaderText = "Fecha Creación";
            this.fecre.Name = "fecre";
            this.fecre.ReadOnly = true;
            this.fecre.Visible = false;
            this.fecre.Width = 92;
            // 
            // feact
            // 
            this.feact.DataPropertyName = "feact";
            this.feact.HeaderText = "Fecha Actualización";
            this.feact.Name = "feact";
            this.feact.ReadOnly = true;
            this.feact.Visible = false;
            this.feact.Width = 92;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkanalitica);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.txtclasecuenta);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtcodigo);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(9, 33);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(692, 55);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // chkanalitica
            // 
            this.chkanalitica.AutoSize = true;
            this.chkanalitica.ForeColor = System.Drawing.Color.Black;
            this.chkanalitica.Location = new System.Drawing.Point(460, 28);
            this.chkanalitica.Name = "chkanalitica";
            this.chkanalitica.Size = new System.Drawing.Size(68, 17);
            this.chkanalitica.TabIndex = 6;
            this.chkanalitica.Text = "Analítico";
            this.chkanalitica.UseVisualStyleBackColor = true;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rbanulado);
            this.GroupBox5.Controls.Add(this.rbactivo);
            this.GroupBox5.Location = new System.Drawing.Point(538, 12);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(147, 34);
            this.GroupBox5.TabIndex = 7;
            this.GroupBox5.TabStop = false;
            // 
            // rbanulado
            // 
            this.rbanulado.AutoSize = true;
            this.rbanulado.ForeColor = System.Drawing.Color.Red;
            this.rbanulado.Location = new System.Drawing.Point(74, 11);
            this.rbanulado.Name = "rbanulado";
            this.rbanulado.Size = new System.Drawing.Size(64, 17);
            this.rbanulado.TabIndex = 0;
            this.rbanulado.TabStop = true;
            this.rbanulado.Text = "Anulado";
            this.rbanulado.UseVisualStyleBackColor = true;
            this.rbanulado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbanulado_KeyDown);
            // 
            // rbactivo
            // 
            this.rbactivo.AutoSize = true;
            this.rbactivo.ForeColor = System.Drawing.Color.Black;
            this.rbactivo.Location = new System.Drawing.Point(11, 11);
            this.rbactivo.Name = "rbactivo";
            this.rbactivo.Size = new System.Drawing.Size(55, 17);
            this.rbactivo.TabIndex = 1;
            this.rbactivo.TabStop = true;
            this.rbactivo.Text = "Activo";
            this.rbactivo.UseVisualStyleBackColor = true;
            this.rbactivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbactivo_KeyDown);
            // 
            // txtclasecuenta
            // 
            this.txtclasecuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtclasecuenta.Location = new System.Drawing.Point(413, 26);
            this.txtclasecuenta.MaxLength = 2;
            this.txtclasecuenta.Name = "txtclasecuenta";
            this.txtclasecuenta.Size = new System.Drawing.Size(40, 20);
            this.txtclasecuenta.TabIndex = 5;
            this.txtclasecuenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtclasecuenta_KeyDown);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(410, 10);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(41, 13);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Cuenta";
            // 
            // txtcodigo
            // 
            this.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcodigo.Location = new System.Drawing.Point(9, 26);
            this.txtcodigo.MaxLength = 5;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(50, 20);
            this.txtcodigo.TabIndex = 3;
            this.txtcodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigo_KeyDown);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(13, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Código";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(61, 26);
            this.txtdescripcion.MaxLength = 50;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(350, 20);
            this.txtdescripcion.TabIndex = 4;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(128, 10);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(63, 13);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Descripción";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::BapFormulariosNet.Properties.Resources.bannerblue3;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 2);
            this.panel1.TabIndex = 3;
            // 
            // Frm_centrocostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 479);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridcentrocostos);
            this.Controls.Add(this.gbtncentrocosto);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_centrocostos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centro de Costos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_centrocostos_FormClosing);
            this.Load += new System.EventHandler(this.Frm_centrocostos_Load);
            this.gbtncentrocosto.ResumeLayout(false);
            this.gbtncentrocosto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcentrocostos)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip gbtncentrocosto;
        private System.Windows.Forms.ToolStripButton btnnew;
        private System.Windows.Forms.ToolStripButton btnedit;
        private System.Windows.Forms.ToolStripButton btnsave;
        private System.Windows.Forms.ToolStripButton btnredo;
        private System.Windows.Forms.ToolStripButton btndelete;
        private System.Windows.Forms.ToolStripButton btnprint;
        private System.Windows.Forms.ToolStripButton btnexit;
        internal System.Windows.Forms.DataGridView gridcentrocostos;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton rbanulado;
        internal System.Windows.Forms.RadioButton rbactivo;
        internal System.Windows.Forms.TextBox txtclasecuenta;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtcodigo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btninicial;
        private System.Windows.Forms.ToolStripButton btnanterior;
        private System.Windows.Forms.ToolStripButton btnsiguiente;
        private System.Windows.Forms.ToolStripButton btnultimo;
        private System.Windows.Forms.CheckBox chkanalitica;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosdivi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cencosanalitica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecre;
        private System.Windows.Forms.DataGridViewTextBoxColumn feact;
        private System.Windows.Forms.Panel panel1;
    }
}