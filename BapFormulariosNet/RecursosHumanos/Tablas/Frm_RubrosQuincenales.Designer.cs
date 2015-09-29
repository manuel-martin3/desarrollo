namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_RubrosQuincenales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RubrosQuincenales));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsGrabar = new System.Windows.Forms.ToolStripButton();
            this.tsCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.tsSeguridad = new System.Windows.Forms.ToolStripButton();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.btnNuevaFila = new System.Windows.Forms.Button();
            this.dgRubroQuincenal = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDesPlanilla = new System.Windows.Forms.Label();
            this.cboTipoPlanilla = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TIPO_PLANILLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD_RUBRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DES_RUBRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PORCENTAJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolStrip1.SuspendLayout();
            this.GB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRubroQuincenal)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEditar,
            this.tsEliminar,
            this.tsGrabar,
            this.tsCancelar,
            this.tsSalir,
            this.tsSeguridad});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(474, 31);
            this.ToolStrip1.TabIndex = 10;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tsEditar
            // 
            this.tsEditar.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(26, 28);
            this.tsEditar.ToolTipText = "Ctrl + U";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar;
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(26, 28);
            this.tsEliminar.ToolTipText = "Ctrl + E";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // tsGrabar
            // 
            this.tsGrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.tsGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGrabar.Name = "tsGrabar";
            this.tsGrabar.Size = new System.Drawing.Size(26, 28);
            this.tsGrabar.ToolTipText = "Ctrl + G";
            this.tsGrabar.Click += new System.EventHandler(this.tsGrabar_Click);
            // 
            // tsCancelar
            // 
            this.tsCancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.tsCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCancelar.Name = "tsCancelar";
            this.tsCancelar.Size = new System.Drawing.Size(26, 28);
            this.tsCancelar.ToolTipText = "Ctrl + Q";
            this.tsCancelar.Click += new System.EventHandler(this.tsCancelar_Click);
            // 
            // tsSalir
            // 
            this.tsSalir.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(26, 28);
            this.tsSalir.ToolTipText = "Ctrl + S";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // tsSeguridad
            // 
            this.tsSeguridad.Image = global::BapFormulariosNet.Properties.Resources.ojo32;
            this.tsSeguridad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSeguridad.Name = "tsSeguridad";
            this.tsSeguridad.Size = new System.Drawing.Size(26, 28);
            this.tsSeguridad.Click += new System.EventHandler(this.tsSeguridad_Click);
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.btnEliminarFila);
            this.GB1.Controls.Add(this.btnNuevaFila);
            this.GB1.Location = new System.Drawing.Point(12, 346);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(449, 45);
            this.GB1.TabIndex = 9;
            this.GB1.TabStop = false;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.Image = global::BapFormulariosNet.Properties.Resources.btn_del20;
            this.btnEliminarFila.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEliminarFila.Location = new System.Drawing.Point(105, 10);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(93, 30);
            this.btnEliminarFila.TabIndex = 1;
            this.btnEliminarFila.Text = "       &Borrar Fila";
            this.btnEliminarFila.UseVisualStyleBackColor = true;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // btnNuevaFila
            // 
            this.btnNuevaFila.Image = global::BapFormulariosNet.Properties.Resources.btn_add20;
            this.btnNuevaFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaFila.Location = new System.Drawing.Point(6, 10);
            this.btnNuevaFila.Name = "btnNuevaFila";
            this.btnNuevaFila.Size = new System.Drawing.Size(93, 30);
            this.btnNuevaFila.TabIndex = 0;
            this.btnNuevaFila.Text = "      &Nueva Fila";
            this.btnNuevaFila.UseVisualStyleBackColor = true;
            this.btnNuevaFila.Click += new System.EventHandler(this.btnNuevaFila_Click);
            // 
            // dgRubroQuincenal
            // 
            this.dgRubroQuincenal.AllowUserToAddRows = false;
            this.dgRubroQuincenal.AllowUserToDeleteRows = false;
            this.dgRubroQuincenal.AllowUserToResizeRows = false;
            this.dgRubroQuincenal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRubroQuincenal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRubroQuincenal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRubroQuincenal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIPO_PLANILLA,
            this.COD_RUBRO,
            this.DES_RUBRO,
            this.PORCENTAJE});
            this.dgRubroQuincenal.Location = new System.Drawing.Point(12, 91);
            this.dgRubroQuincenal.MultiSelect = false;
            this.dgRubroQuincenal.Name = "dgRubroQuincenal";
            this.dgRubroQuincenal.RowHeadersVisible = false;
            this.dgRubroQuincenal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgRubroQuincenal.Size = new System.Drawing.Size(451, 257);
            this.dgRubroQuincenal.TabIndex = 8;
            this.dgRubroQuincenal.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRubroQuincenal_CellEndEdit);
            this.dgRubroQuincenal.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgRubroQuincenal_DataError);
            this.dgRubroQuincenal.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgRubroQuincenal_EditingControlShowing);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblDesPlanilla);
            this.GroupBox1.Controls.Add(this.cboTipoPlanilla);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 33);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(451, 51);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            // 
            // lblDesPlanilla
            // 
            this.lblDesPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesPlanilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesPlanilla.Location = new System.Drawing.Point(389, 18);
            this.lblDesPlanilla.Name = "lblDesPlanilla";
            this.lblDesPlanilla.Size = new System.Drawing.Size(47, 21);
            this.lblDesPlanilla.TabIndex = 2;
            this.lblDesPlanilla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.DropDownWidth = 250;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(109, 18);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(274, 21);
            this.cboTipoPlanilla.TabIndex = 1;
            this.cboTipoPlanilla.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(6, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(103, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Tipo de Planilla :";
            // 
            // TIPO_PLANILLA
            // 
            this.TIPO_PLANILLA.DataPropertyName = "TIPO_PLANILLA";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TIPO_PLANILLA.DefaultCellStyle = dataGridViewCellStyle2;
            this.TIPO_PLANILLA.HeaderText = "TIPO_PLANILLA";
            this.TIPO_PLANILLA.Name = "TIPO_PLANILLA";
            this.TIPO_PLANILLA.Visible = false;
            // 
            // COD_RUBRO
            // 
            this.COD_RUBRO.DataPropertyName = "COD_RUBRO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.COD_RUBRO.DefaultCellStyle = dataGridViewCellStyle3;
            this.COD_RUBRO.HeaderText = "Cód.Rubro";
            this.COD_RUBRO.Name = "COD_RUBRO";
            this.COD_RUBRO.Width = 70;
            // 
            // DES_RUBRO
            // 
            this.DES_RUBRO.DataPropertyName = "DES_RUBRO";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.DES_RUBRO.DefaultCellStyle = dataGridViewCellStyle4;
            this.DES_RUBRO.HeaderText = "Descripción";
            this.DES_RUBRO.Name = "DES_RUBRO";
            this.DES_RUBRO.Width = 278;
            // 
            // PORCENTAJE
            // 
            this.PORCENTAJE.DataPropertyName = "PORCENTAJE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.PORCENTAJE.DefaultCellStyle = dataGridViewCellStyle5;
            this.PORCENTAJE.HeaderText = "Porcentaje";
            this.PORCENTAJE.Name = "PORCENTAJE";
            this.PORCENTAJE.Width = 80;
            // 
            // Frm_RubrosQuincenales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 394);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.dgRubroQuincenal);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GB1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_RubrosQuincenales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rubros Quincenales";
            this.Load += new System.EventHandler(this.Frm_RubrosQuincenales_Load);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.GB1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRubroQuincenal)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tsEditar;
        internal System.Windows.Forms.ToolStripButton tsEliminar;
        internal System.Windows.Forms.ToolStripButton tsGrabar;
        internal System.Windows.Forms.ToolStripButton tsCancelar;
        internal System.Windows.Forms.ToolStripButton tsSalir;
        internal System.Windows.Forms.ToolStripButton tsSeguridad;
        internal System.Windows.Forms.GroupBox GB1;
        internal System.Windows.Forms.Button btnEliminarFila;
        internal System.Windows.Forms.Button btnNuevaFila;
        internal System.Windows.Forms.DataGridView dgRubroQuincenal;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblDesPlanilla;
        internal System.Windows.Forms.ComboBox cboTipoPlanilla;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO_PLANILLA;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD_RUBRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DES_RUBRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PORCENTAJE;
    }
}