namespace BapFormulariosNet.RecursosHumanos
{
    partial class Frm_SeleccionaPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SeleccionaPlanilla));
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.grp = new System.Windows.Forms.GroupBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nsemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechafin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perianio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToOrderColumns = true;
            this.Examinar.AllowUserToResizeRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Examinar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.asiento,
            this.perimes,
            this.nsemana,
            this.glosa,
            this.fechaini,
            this.fechafin,
            this.perianio,
            this.ccia,
            this.Column8});
            this.Examinar.Location = new System.Drawing.Point(12, 60);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Examinar.Size = new System.Drawing.Size(837, 347);
            this.Examinar.TabIndex = 4;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnCancelar);
            this.GroupBox2.Controls.Add(this.btnSeleccionar);
            this.GroupBox2.Location = new System.Drawing.Point(328, 406);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(188, 44);
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(96, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 26);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar  ";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(6, 12);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(86, 26);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // grp
            // 
            this.grp.Controls.Add(this.txtPeriodo);
            this.grp.Controls.Add(this.cboTipo);
            this.grp.Controls.Add(this.Label1);
            this.grp.Location = new System.Drawing.Point(12, 6);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(837, 49);
            this.grp.TabIndex = 3;
            this.grp.TabStop = false;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Enabled = false;
            this.txtPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtPeriodo.Location = new System.Drawing.Point(489, 16);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(54, 20);
            this.txtPeriodo.TabIndex = 2;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Normal",
            "Horas Extras"});
            this.cboTipo.Location = new System.Drawing.Point(198, 16);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(185, 21);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.DropDownClosed += new System.EventHandler(this.cboTipo_DropDownClosed);
            this.cboTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipo_KeyPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(155, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(37, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Tipo : ";
            // 
            // asiento
            // 
            this.asiento.DataPropertyName = "asiento";
            this.asiento.HeaderText = "Planilla";
            this.asiento.Name = "asiento";
            this.asiento.ReadOnly = true;
            this.asiento.Width = 70;
            // 
            // perimes
            // 
            this.perimes.DataPropertyName = "perimes";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.perimes.DefaultCellStyle = dataGridViewCellStyle2;
            this.perimes.HeaderText = "Mes";
            this.perimes.Name = "perimes";
            this.perimes.ReadOnly = true;
            this.perimes.Width = 40;
            // 
            // nsemana
            // 
            this.nsemana.DataPropertyName = "nsemana";
            this.nsemana.HeaderText = "Semana";
            this.nsemana.Name = "nsemana";
            this.nsemana.ReadOnly = true;
            this.nsemana.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nsemana.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nsemana.Width = 60;
            // 
            // glosa
            // 
            this.glosa.DataPropertyName = "glosa";
            this.glosa.HeaderText = "Descripción";
            this.glosa.Name = "glosa";
            this.glosa.ReadOnly = true;
            this.glosa.Width = 400;
            // 
            // fechaini
            // 
            this.fechaini.DataPropertyName = "fechaini";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fechaini.DefaultCellStyle = dataGridViewCellStyle3;
            this.fechaini.HeaderText = "F.Inicio";
            this.fechaini.Name = "fechaini";
            this.fechaini.ReadOnly = true;
            this.fechaini.Width = 90;
            // 
            // fechafin
            // 
            this.fechafin.DataPropertyName = "fechafin";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.fechafin.DefaultCellStyle = dataGridViewCellStyle4;
            this.fechafin.HeaderText = "F.Termino";
            this.fechafin.Name = "fechafin";
            this.fechafin.ReadOnly = true;
            this.fechafin.Width = 90;
            // 
            // perianio
            // 
            this.perianio.DataPropertyName = "perianio";
            this.perianio.HeaderText = "Column7";
            this.perianio.Name = "perianio";
            this.perianio.ReadOnly = true;
            this.perianio.Visible = false;
            // 
            // ccia
            // 
            this.ccia.DataPropertyName = "ccia";
            this.ccia.HeaderText = "SEL";
            this.ccia.Name = "ccia";
            this.ccia.ReadOnly = true;
            this.ccia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ccia.Visible = false;
            this.ccia.Width = 35;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "SEL";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Width = 40;
            // 
            // Frm_SeleccionaPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 452);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_SeleccionaPlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Planilla";
            this.Load += new System.EventHandler(this.Frm_SeleccionaPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnSeleccionar;
        internal System.Windows.Forms.GroupBox grp;
        internal System.Windows.Forms.TextBox txtPeriodo;
        internal System.Windows.Forms.ComboBox cboTipo;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaini;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechafin;
        private System.Windows.Forms.DataGridViewTextBoxColumn perianio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ccia;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column8;
    }
}