namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaUsuarios));
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rblistatodos = new System.Windows.Forms.RadioButton();
            this.rblistaactivos = new System.Windows.Forms.RadioButton();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.chkdescripcion = new System.Windows.Forms.CheckBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.usuar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inicial_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            this.dgProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuar,
            this.nombr,
            this.login,
            this.inicial_6,
            this.clave});
            this.dgProveedor.Location = new System.Drawing.Point(10, 78);
            this.dgProveedor.MultiSelect = false;
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProveedor.RowHeadersWidth = 24;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(587, 338);
            this.dgProveedor.TabIndex = 1;
            this.dgProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellDoubleClick);
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.rblistatodos);
            this.GroupBox1.Controls.Add(this.rblistaactivos);
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.chkdescripcion);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.Location = new System.Drawing.Point(9, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(588, 67);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = " Filtros ";
            // 
            // rblistatodos
            // 
            this.rblistatodos.AutoSize = true;
            this.rblistatodos.Location = new System.Drawing.Point(522, 11);
            this.rblistatodos.Name = "rblistatodos";
            this.rblistatodos.Size = new System.Drawing.Size(55, 17);
            this.rblistatodos.TabIndex = 3;
            this.rblistatodos.Text = "Todos";
            this.rblistatodos.UseVisualStyleBackColor = true;
            this.rblistatodos.CheckedChanged += new System.EventHandler(this.rblistatodos_CheckedChanged);
            // 
            // rblistaactivos
            // 
            this.rblistaactivos.AutoSize = true;
            this.rblistaactivos.Checked = true;
            this.rblistaactivos.Location = new System.Drawing.Point(446, 11);
            this.rblistaactivos.Name = "rblistaactivos";
            this.rblistaactivos.Size = new System.Drawing.Size(60, 17);
            this.rblistaactivos.TabIndex = 2;
            this.rblistaactivos.TabStop = true;
            this.rblistaactivos.Text = "Activos";
            this.rblistaactivos.UseVisualStyleBackColor = true;
            this.rblistaactivos.CheckedChanged += new System.EventHandler(this.rblistaactivos_CheckedChanged);
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.btn_search20;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(481, 32);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(94, 29);
            this.btnrefrescar.TabIndex = 4;
            this.btnrefrescar.Text = "&Refrescar   ";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // chkdescripcion
            // 
            this.chkdescripcion.AutoSize = true;
            this.chkdescripcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.Location = new System.Drawing.Point(22, 20);
            this.chkdescripcion.Name = "chkdescripcion";
            this.chkdescripcion.Size = new System.Drawing.Size(128, 17);
            this.chkdescripcion.TabIndex = 0;
            this.chkdescripcion.Text = "Ocurrencias Nombres";
            this.chkdescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.UseVisualStyleBackColor = true;
            this.chkdescripcion.CheckedChanged += new System.EventHandler(this.chkdescripcion_CheckedChanged);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(25, 39);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(403, 20);
            this.txtdescripcion.TabIndex = 1;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnCancelar);
            this.GroupBox3.Controls.Add(this.btnSeleccionar);
            this.GroupBox3.Location = new System.Drawing.Point(201, 415);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(199, 41);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(104, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar  ";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(5, 11);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(90, 25);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "&Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // usuar
            // 
            this.usuar.DataPropertyName = "usuar";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuar.DefaultCellStyle = dataGridViewCellStyle2;
            this.usuar.HeaderText = "Usuario";
            this.usuar.Name = "usuar";
            this.usuar.ReadOnly = true;
            this.usuar.Width = 120;
            // 
            // nombr
            // 
            this.nombr.DataPropertyName = "nombr";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombr.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombr.HeaderText = "Nombres";
            this.nombr.Name = "nombr";
            this.nombr.ReadOnly = true;
            this.nombr.Width = 300;
            // 
            // login
            // 
            this.login.DataPropertyName = "login";
            this.login.HeaderText = "Login";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            this.login.Width = 120;
            // 
            // inicial_6
            // 
            this.inicial_6.DataPropertyName = "inicial_6";
            this.inicial_6.HeaderText = "inicial_6";
            this.inicial_6.Name = "inicial_6";
            this.inicial_6.ReadOnly = true;
            this.inicial_6.Visible = false;
            // 
            // clave
            // 
            this.clave.DataPropertyName = "clave";
            this.clave.HeaderText = "Clave";
            this.clave.Name = "clave";
            this.clave.ReadOnly = true;
            this.clave.Visible = false;
            // 
            // Frm_AyudaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 459);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaUsuarios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Activated += new System.EventHandler(this.Frm_AyudaUsuarios_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaUsuarios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaUsuarios_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.CheckBox chkdescripcion;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnSeleccionar;
        internal System.Windows.Forms.RadioButton rblistatodos;
        internal System.Windows.Forms.RadioButton rblistaactivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombr;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicial_6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
    }
}