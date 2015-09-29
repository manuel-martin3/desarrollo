namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaCuentas));
            this.lblanalitica = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.GridExaminar = new System.Windows.Forms.DataGridView();
            this.cuentaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.escuentaanalitica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cuentamarredebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentamarrehaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCadenaBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCriterioBusqueda = new System.Windows.Forms.ComboBox();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblanalitica
            // 
            this.lblanalitica.AutoSize = true;
            this.lblanalitica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(163)))), ((int)(((byte)(210)))));
            this.lblanalitica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblanalitica.ForeColor = System.Drawing.Color.Black;
            this.lblanalitica.Location = new System.Drawing.Point(15, 428);
            this.lblanalitica.Name = "lblanalitica";
            this.lblanalitica.Size = new System.Drawing.Size(47, 13);
            this.lblanalitica.TabIndex = 3;
            this.lblanalitica.Text = "Cuenta :";
            this.lblanalitica.Visible = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(243, 407);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 2;
            this.GroupBox4.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar  ";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(5, 11);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // GridExaminar
            // 
            this.GridExaminar.AllowUserToAddRows = false;
            this.GridExaminar.AllowUserToDeleteRows = false;
            this.GridExaminar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridExaminar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridExaminar.ColumnHeadersHeight = 26;
            this.GridExaminar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuentaid,
            this.cuentaname,
            this.escuentaanalitica,
            this.cuentamarredebe,
            this.cuentamarrehaber});
            this.GridExaminar.Location = new System.Drawing.Point(6, 48);
            this.GridExaminar.MultiSelect = false;
            this.GridExaminar.Name = "GridExaminar";
            this.GridExaminar.ReadOnly = true;
            this.GridExaminar.RowHeadersVisible = false;
            this.GridExaminar.RowTemplate.Height = 20;
            this.GridExaminar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridExaminar.Size = new System.Drawing.Size(689, 362);
            this.GridExaminar.TabIndex = 1;
            this.GridExaminar.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridExaminar_ColumnHeaderMouseClick);
            this.GridExaminar.DoubleClick += new System.EventHandler(this.GridExaminar_DoubleClick);
            this.GridExaminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridExaminar_KeyDown);
            // 
            // cuentaid
            // 
            this.cuentaid.DataPropertyName = "cuentaid";
            this.cuentaid.HeaderText = "Cuenta";
            this.cuentaid.Name = "cuentaid";
            this.cuentaid.ReadOnly = true;
            this.cuentaid.Width = 80;
            // 
            // cuentaname
            // 
            this.cuentaname.DataPropertyName = "cuentaname";
            this.cuentaname.HeaderText = "Nomenclatura";
            this.cuentaname.Name = "cuentaname";
            this.cuentaname.ReadOnly = true;
            this.cuentaname.Width = 380;
            // 
            // escuentaanalitica
            // 
            this.escuentaanalitica.DataPropertyName = "escuentaanalitica";
            this.escuentaanalitica.HeaderText = "Análitica";
            this.escuentaanalitica.Name = "escuentaanalitica";
            this.escuentaanalitica.ReadOnly = true;
            this.escuentaanalitica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.escuentaanalitica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.escuentaanalitica.Width = 58;
            // 
            // cuentamarredebe
            // 
            this.cuentamarredebe.DataPropertyName = "cuentamarredebe";
            this.cuentamarredebe.HeaderText = "A-Debe";
            this.cuentamarredebe.Name = "cuentamarredebe";
            this.cuentamarredebe.ReadOnly = true;
            this.cuentamarredebe.Width = 75;
            // 
            // cuentamarrehaber
            // 
            this.cuentamarrehaber.DataPropertyName = "cuentamarrehaber";
            this.cuentamarrehaber.HeaderText = "A-Haber";
            this.cuentamarrehaber.Name = "cuentamarrehaber";
            this.cuentamarrehaber.ReadOnly = true;
            this.cuentamarrehaber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cuentamarrehaber.Width = 75;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnBuscar);
            this.GroupBox1.Controls.Add(this.txtCadenaBuscar);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cboCriterioBusqueda);
            this.GroupBox1.Location = new System.Drawing.Point(6, -1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(689, 46);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(481, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 28);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCadenaBuscar
            // 
            this.txtCadenaBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadenaBuscar.Location = new System.Drawing.Point(237, 17);
            this.txtCadenaBuscar.Name = "txtCadenaBuscar";
            this.txtCadenaBuscar.Size = new System.Drawing.Size(218, 20);
            this.txtCadenaBuscar.TabIndex = 2;
            this.txtCadenaBuscar.TextChanged += new System.EventHandler(this.txtCadenaBuscar_TextChanged);
            this.txtCadenaBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCadenaBuscar_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar por:";
            // 
            // cboCriterioBusqueda
            // 
            this.cboCriterioBusqueda.AccessibleDescription = "";
            this.cboCriterioBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterioBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCriterioBusqueda.FormattingEnabled = true;
            this.cboCriterioBusqueda.Items.AddRange(new object[] {
            "Cuenta",
            "Descripción"});
            this.cboCriterioBusqueda.Location = new System.Drawing.Point(76, 17);
            this.cboCriterioBusqueda.Name = "cboCriterioBusqueda";
            this.cboCriterioBusqueda.Size = new System.Drawing.Size(155, 21);
            this.cboCriterioBusqueda.TabIndex = 1;
            this.cboCriterioBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCriterioBusqueda_KeyDown);
            // 
            // Frm_AyudaCuentas
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.lblanalitica);
            this.Controls.Add(this.GridExaminar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaCuentas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda Plan Contable General Empresarial >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaCuentas_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaCuentas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaCuentas_KeyDown);
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblanalitica;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.DataGridView GridExaminar;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCadenaBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCriterioBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn escuentaanalitica;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentamarredebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentamarrehaber;
    }
}