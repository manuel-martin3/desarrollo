namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaUbigeo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaUbigeo));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.ubige = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label21);
            this.GroupBox1.Controls.Add(this.btnRefrescar);
            this.GroupBox1.Controls.Add(this.txtNombre);
            this.GroupBox1.Location = new System.Drawing.Point(9, 7);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(608, 53);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label21.Location = new System.Drawing.Point(23, 23);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(77, 13);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "Buscar Ubigeo";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnRefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescar.Location = new System.Drawing.Point(509, 15);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(82, 30);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "&Refrescar";
            this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(110, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(342, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.AllowUserToResizeRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Examinar.ColumnHeadersHeight = 28;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ubige,
            this.depar,
            this.provi,
            this.distr});
            this.Examinar.Location = new System.Drawing.Point(9, 66);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Examinar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Examinar.RowHeadersWidth = 36;
            this.Examinar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowTemplate.Height = 20;
            this.Examinar.Size = new System.Drawing.Size(608, 370);
            this.Examinar.TabIndex = 1;
            this.Examinar.DoubleClick += new System.EventHandler(this.Examinar_DoubleClick);
            this.Examinar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Examinar_KeyDown);
            // 
            // ubige
            // 
            this.ubige.DataPropertyName = "ubige";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubige.DefaultCellStyle = dataGridViewCellStyle2;
            this.ubige.HeaderText = "Ubigeo";
            this.ubige.Name = "ubige";
            this.ubige.ReadOnly = true;
            this.ubige.Width = 70;
            // 
            // depar
            // 
            this.depar.DataPropertyName = "depar";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depar.DefaultCellStyle = dataGridViewCellStyle3;
            this.depar.HeaderText = "Departamento";
            this.depar.Name = "depar";
            this.depar.ReadOnly = true;
            this.depar.Width = 160;
            // 
            // provi
            // 
            this.provi.DataPropertyName = "provi";
            this.provi.HeaderText = "Provincia";
            this.provi.Name = "provi";
            this.provi.ReadOnly = true;
            this.provi.Width = 160;
            // 
            // distr
            // 
            this.distr.DataPropertyName = "distr";
            this.distr.HeaderText = "Distrito";
            this.distr.Name = "distr";
            this.distr.ReadOnly = true;
            this.distr.Width = 160;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCerrar);
            this.groupBox2.Controls.Add(this.btnSeleccion);
            this.groupBox2.Location = new System.Drawing.Point(238, 436);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 40);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
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
            // Frm_AyudaUbigeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 478);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaUbigeo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ubicación Geografica";
            this.Activated += new System.EventHandler(this.Frm_AyudaUbigeo_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaUbigeo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaUbigeo_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnRefrescar;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.Label Label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubige;
        private System.Windows.Forms.DataGridViewTextBoxColumn depar;
        private System.Windows.Forms.DataGridViewTextBoxColumn provi;
        private System.Windows.Forms.DataGridViewTextBoxColumn distr;
    }
}