namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaPais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaPais));
            this.gridExaminar = new System.Windows.Forms.DataGridView();
            this.paisid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paisname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridExaminar)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridExaminar
            // 
            this.gridExaminar.AllowUserToAddRows = false;
            this.gridExaminar.AllowUserToDeleteRows = false;
            this.gridExaminar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridExaminar.ColumnHeadersHeight = 26;
            this.gridExaminar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paisid,
            this.paisname});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridExaminar.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridExaminar.Location = new System.Drawing.Point(5, 50);
            this.gridExaminar.MultiSelect = false;
            this.gridExaminar.Name = "gridExaminar";
            this.gridExaminar.ReadOnly = true;
            this.gridExaminar.RowHeadersWidth = 30;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridExaminar.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridExaminar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridExaminar.ShowRowErrors = false;
            this.gridExaminar.Size = new System.Drawing.Size(463, 314);
            this.gridExaminar.TabIndex = 1;
            this.gridExaminar.DoubleClick += new System.EventHandler(this.gridExaminar_DoubleClick);
            this.gridExaminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridExaminar_KeyDown);
            // 
            // paisid
            // 
            this.paisid.DataPropertyName = "paisid";
            this.paisid.HeaderText = "Código";
            this.paisid.Name = "paisid";
            this.paisid.ReadOnly = true;
            this.paisid.Width = 60;
            // 
            // paisname
            // 
            this.paisname.DataPropertyName = "paisname";
            this.paisname.HeaderText = "Pais";
            this.paisname.Name = "paisname";
            this.paisname.ReadOnly = true;
            this.paisname.Width = 350;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.cboFiltro);
            this.GroupBox2.Controls.Add(this.txtFilter);
            this.GroupBox2.Controls.Add(this.btnBuscar);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Location = new System.Drawing.Point(5, 1);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(463, 45);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            // 
            // cboFiltro
            // 
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Pais",
            "Código"});
            this.cboFiltro.Location = new System.Drawing.Point(70, 16);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(75, 21);
            this.cboFiltro.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilter.Location = new System.Drawing.Point(149, 16);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(217, 20);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(376, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(79, 24);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label22.Location = new System.Drawing.Point(5, 20);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(61, 13);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Buscar por:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.btnSeleccion);
            this.groupBox1.Location = new System.Drawing.Point(143, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 40);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(5, 10);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // Frm_AyudaPais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 399);
            this.Controls.Add(this.gridExaminar);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaPais";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaPais_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaPais_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaPais_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridExaminar)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridExaminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn paisid;
        private System.Windows.Forms.DataGridViewTextBoxColumn paisname;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ComboBox cboFiltro;
        internal System.Windows.Forms.TextBox txtFilter;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
    }
}