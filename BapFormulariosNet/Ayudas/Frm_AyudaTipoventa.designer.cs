namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaTipoventa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaTipoventa));
            this.GridExaminar = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCadenaBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCriterioBusqueda = new System.Windows.Forms.ComboBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.tipoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiponame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuenta1id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuenta1name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridExaminar
            // 
            this.GridExaminar.AllowUserToAddRows = false;
            this.GridExaminar.AllowUserToDeleteRows = false;
            this.GridExaminar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridExaminar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridExaminar.ColumnHeadersHeight = 26;
            this.GridExaminar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoid,
            this.tiponame,
            this.cuenta1id,
            this.cuenta1name});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridExaminar.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridExaminar.Location = new System.Drawing.Point(5, 49);
            this.GridExaminar.MultiSelect = false;
            this.GridExaminar.Name = "GridExaminar";
            this.GridExaminar.ReadOnly = true;
            this.GridExaminar.RowHeadersWidth = 20;
            this.GridExaminar.RowTemplate.Height = 20;
            this.GridExaminar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GridExaminar.Size = new System.Drawing.Size(811, 362);
            this.GridExaminar.TabIndex = 1;
            this.GridExaminar.DoubleClick += new System.EventHandler(this.GridExaminar_DoubleClick);
            this.GridExaminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridExaminar_KeyDown);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnBuscar);
            this.GroupBox1.Controls.Add(this.txtCadenaBuscar);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cboCriterioBusqueda);
            this.GroupBox1.Location = new System.Drawing.Point(94, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(578, 46);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(459, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 31);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCadenaBuscar
            // 
            this.txtCadenaBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCadenaBuscar.Location = new System.Drawing.Point(235, 15);
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
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar Cta.";
            // 
            // cboCriterioBusqueda
            // 
            this.cboCriterioBusqueda.AccessibleDescription = "";
            this.cboCriterioBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterioBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCriterioBusqueda.FormattingEnabled = true;
            this.cboCriterioBusqueda.Items.AddRange(new object[] {
            "Código",
            "Descripción"});
            this.cboCriterioBusqueda.Location = new System.Drawing.Point(74, 15);
            this.cboCriterioBusqueda.Name = "cboCriterioBusqueda";
            this.cboCriterioBusqueda.Size = new System.Drawing.Size(155, 21);
            this.cboCriterioBusqueda.TabIndex = 1;
            this.cboCriterioBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCriterioBusqueda_KeyDown);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(278, 409);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 2;
            this.GroupBox4.TabStop = false;
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
            // tipoid
            // 
            this.tipoid.DataPropertyName = "tipoid";
            this.tipoid.HeaderText = "Código";
            this.tipoid.Name = "tipoid";
            this.tipoid.ReadOnly = true;
            this.tipoid.Width = 70;
            // 
            // tiponame
            // 
            this.tiponame.DataPropertyName = "tiponame";
            this.tiponame.HeaderText = "Concepto";
            this.tiponame.Name = "tiponame";
            this.tiponame.ReadOnly = true;
            this.tiponame.Width = 400;
            // 
            // cuenta1id
            // 
            this.cuenta1id.DataPropertyName = "cuenta1id";
            this.cuenta1id.HeaderText = "Cuenta";
            this.cuenta1id.Name = "cuenta1id";
            this.cuenta1id.ReadOnly = true;
            this.cuenta1id.Width = 70;
            // 
            // cuenta1name
            // 
            this.cuenta1name.DataPropertyName = "cuenta1name";
            this.cuenta1name.HeaderText = "Descripción";
            this.cuenta1name.Name = "cuenta1name";
            this.cuenta1name.ReadOnly = true;
            this.cuenta1name.Width = 350;
            // 
            // Frm_AyudaTipoventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.GridExaminar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaTipoventa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda Tipo de Ventas >>";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaTipocompra_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridExaminar)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView GridExaminar;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCadenaBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCriterioBusqueda;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiponame;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta1id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta1name;
    }
}