namespace BapFormulariosNet.Generales
{
    partial class Frm_RecepcionGUIAS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RecepcionGUIAS));
            this.dgb_aceptacionguias = new System.Windows.Forms.DataGridView();
            this.fechdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._local_emitido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._local_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totpzas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ver = new System.Windows.Forms.DataGridViewButtonColumn();
            this._aceptar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._tipodoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._serdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._numdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ctacte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ctactename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._direcnume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._direcname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._direcdeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._nmruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_aceptacionguias)).BeginInit();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgb_aceptacionguias
            // 
            this.dgb_aceptacionguias.AllowUserToAddRows = false;
            this.dgb_aceptacionguias.AllowUserToDeleteRows = false;
            this.dgb_aceptacionguias.AllowUserToResizeColumns = false;
            this.dgb_aceptacionguias.AllowUserToResizeRows = false;
            this.dgb_aceptacionguias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgb_aceptacionguias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgb_aceptacionguias.ColumnHeadersHeight = 30;
            this.dgb_aceptacionguias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechdoc,
            this._local,
            this._local_emitido,
            this._local_name,
            this.doc,
            this.totpzas,
            this.btn_ver,
            this._aceptar,
            this._tipodoc,
            this._serdoc,
            this._numdoc,
            this._ctacte,
            this._ctactename,
            this._direcnume,
            this._direcname,
            this._direcdeta,
            this._nmruc});
            this.dgb_aceptacionguias.Location = new System.Drawing.Point(0, 29);
            this.dgb_aceptacionguias.MultiSelect = false;
            this.dgb_aceptacionguias.Name = "dgb_aceptacionguias";
            this.dgb_aceptacionguias.RowHeadersVisible = false;
            this.dgb_aceptacionguias.RowHeadersWidth = 10;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgb_aceptacionguias.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgb_aceptacionguias.RowTemplate.Height = 20;
            this.dgb_aceptacionguias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgb_aceptacionguias.Size = new System.Drawing.Size(680, 290);
            this.dgb_aceptacionguias.TabIndex = 73;
            this.dgb_aceptacionguias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_aceptacionguias_CellContentClick);
            this.dgb_aceptacionguias.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_aceptacionguias_CellEnter);
            this.dgb_aceptacionguias.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_aceptacionguias_CellLeave);
            this.dgb_aceptacionguias.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgb_aceptacionguias_EditingControlShowing);
            this.dgb_aceptacionguias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.griddetalleocompra_KeyPress);
            // 
            // fechdoc
            // 
            this.fechdoc.DataPropertyName = "fechdoc";
            this.fechdoc.HeaderText = "Fecha";
            this.fechdoc.Name = "fechdoc";
            this.fechdoc.Width = 80;
            // 
            // _local
            // 
            this._local.DataPropertyName = "local_destino";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._local.DefaultCellStyle = dataGridViewCellStyle2;
            this._local.HeaderText = "Local";
            this._local.Name = "_local";
            this._local.Visible = false;
            this._local.Width = 50;
            // 
            // _local_emitido
            // 
            this._local_emitido.DataPropertyName = "local_emitido";
            this._local_emitido.HeaderText = "Cod-Local";
            this._local_emitido.Name = "_local_emitido";
            this._local_emitido.Width = 60;
            // 
            // _local_name
            // 
            this._local_name.DataPropertyName = "localname";
            this._local_name.HeaderText = "Nom-Local";
            this._local_name.Name = "_local_name";
            this._local_name.Width = 150;
            // 
            // doc
            // 
            this.doc.DataPropertyName = "doc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.doc.DefaultCellStyle = dataGridViewCellStyle3;
            this.doc.HeaderText = "Documento";
            this.doc.Name = "doc";
            this.doc.Width = 150;
            // 
            // totpzas
            // 
            this.totpzas.DataPropertyName = "totpzas";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.totpzas.DefaultCellStyle = dataGridViewCellStyle4;
            this.totpzas.HeaderText = "Cantidad";
            this.totpzas.Name = "totpzas";
            this.totpzas.Width = 80;
            // 
            // btn_ver
            // 
            this.btn_ver.DataPropertyName = "ctacte";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.btn_ver.DefaultCellStyle = dataGridViewCellStyle5;
            this.btn_ver.HeaderText = "↓↓";
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btn_ver.Text = "Ver Guia";
            this.btn_ver.UseColumnTextForButtonValue = true;
            // 
            // _aceptar
            // 
            this._aceptar.DataPropertyName = "vista";
            this._aceptar.HeaderText = "Activar";
            this._aceptar.Name = "_aceptar";
            this._aceptar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._aceptar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._aceptar.Width = 50;
            // 
            // _tipodoc
            // 
            this._tipodoc.DataPropertyName = "tipodoc";
            this._tipodoc.HeaderText = "tipodoc";
            this._tipodoc.Name = "_tipodoc";
            this._tipodoc.Visible = false;
            // 
            // _serdoc
            // 
            this._serdoc.DataPropertyName = "serdoc";
            this._serdoc.HeaderText = "serdoc";
            this._serdoc.Name = "_serdoc";
            this._serdoc.Visible = false;
            // 
            // _numdoc
            // 
            this._numdoc.DataPropertyName = "numdoc";
            this._numdoc.HeaderText = "numdoc";
            this._numdoc.Name = "_numdoc";
            this._numdoc.Visible = false;
            // 
            // _ctacte
            // 
            this._ctacte.DataPropertyName = "ctacte";
            this._ctacte.HeaderText = "ctacte";
            this._ctacte.Name = "_ctacte";
            this._ctacte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._ctacte.Visible = false;
            // 
            // _ctactename
            // 
            this._ctactename.DataPropertyName = "ctactename";
            this._ctactename.HeaderText = "ctactename";
            this._ctactename.Name = "_ctactename";
            this._ctactename.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._ctactename.Visible = false;
            // 
            // _direcnume
            // 
            this._direcnume.DataPropertyName = "direcnume";
            this._direcnume.HeaderText = "direcnume";
            this._direcnume.Name = "_direcnume";
            this._direcnume.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._direcnume.Visible = false;
            // 
            // _direcname
            // 
            this._direcname.DataPropertyName = "direcname";
            this._direcname.HeaderText = "direcname";
            this._direcname.Name = "_direcname";
            this._direcname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._direcname.Visible = false;
            // 
            // _direcdeta
            // 
            this._direcdeta.DataPropertyName = "direcdeta";
            this._direcdeta.HeaderText = "direcdeta";
            this._direcdeta.Name = "_direcdeta";
            this._direcdeta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._direcdeta.Visible = false;
            // 
            // _nmruc
            // 
            this._nmruc.DataPropertyName = "nmruc";
            this._nmruc.HeaderText = "nmruc";
            this._nmruc.Name = "_nmruc";
            this._nmruc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._nmruc.Visible = false;
            // 
            // Botonera
            // 
            this.Botonera.BackColor = System.Drawing.Color.Teal;
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_imprimir,
            this.toolStripSeparator1,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(685, 29);
            this.Botonera.TabIndex = 34;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_nuevo.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(23, 26);
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.Image")));
            this.btn_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(26, 26);
            this.btn_imprimir.Text = "Imprimir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 26);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // Frm_RecepcionGUIAS
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 320);
            this.Controls.Add(this.dgb_aceptacionguias);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Name = "Frm_RecepcionGUIAS";
            this.Text = "ACEPTACION DE GUIAS";
            this.Load += new System.EventHandler(this.Frm_RecepcionGUIAS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgb_aceptacionguias)).EndInit();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        internal System.Windows.Forms.DataGridView dgb_aceptacionguias;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _local;
        private System.Windows.Forms.DataGridViewTextBoxColumn _local_emitido;
        private System.Windows.Forms.DataGridViewTextBoxColumn _local_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn totpzas;
        private System.Windows.Forms.DataGridViewButtonColumn btn_ver;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _aceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn _tipodoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _serdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _numdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ctacte;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ctactename;
        private System.Windows.Forms.DataGridViewTextBoxColumn _direcnume;
        private System.Windows.Forms.DataGridViewTextBoxColumn _direcname;
        private System.Windows.Forms.DataGridViewTextBoxColumn _direcdeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn _nmruc;
    }
}