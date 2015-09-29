namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaCCostoPlla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaCCostoPlla));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.chkdescripcion = new System.Windows.Forms.CheckBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.cencosid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnrefrescar);
            this.GroupBox1.Controls.Add(this.chkdescripcion);
            this.GroupBox1.Controls.Add(this.txtdescripcion);
            this.GroupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.GroupBox1.Location = new System.Drawing.Point(11, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(565, 57);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = " Filtros ";
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.ForeColor = System.Drawing.SystemColors.ControlText;
            //this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.filtrar24;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(485, 14);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(66, 34);
            this.btnrefrescar.TabIndex = 3;
            this.btnrefrescar.Text = "Filtrar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // chkdescripcion
            // 
            this.chkdescripcion.AutoSize = true;
            this.chkdescripcion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkdescripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.Location = new System.Drawing.Point(6, 25);
            this.chkdescripcion.Name = "chkdescripcion";
            this.chkdescripcion.Size = new System.Drawing.Size(123, 17);
            this.chkdescripcion.TabIndex = 0;
            this.chkdescripcion.Text = "Ocurrencias Nombre";
            this.chkdescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdescripcion.UseVisualStyleBackColor = true;
            this.chkdescripcion.CheckedChanged += new System.EventHandler(this.chkdescripcion_CheckedChanged);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.Location = new System.Drawing.Point(135, 23);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(337, 20);
            this.txtdescripcion.TabIndex = 1;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnCerrar);
            this.GroupBox3.Controls.Add(this.btnSeleccionar);
            this.GroupBox3.Location = new System.Drawing.Point(208, 404);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(187, 41);
            this.GroupBox3.TabIndex = 8;
            this.GroupBox3.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 11);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(88, 25);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "&Cancelar   ";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(5, 11);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(88, 25);
            this.btnSeleccionar.TabIndex = 0;
            this.btnSeleccionar.Text = "&Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
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
            this.cencosid,
            this.cencosname});
            this.dgProveedor.Location = new System.Drawing.Point(11, 63);
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
            this.dgProveedor.Size = new System.Drawing.Size(566, 344);
            this.dgProveedor.TabIndex = 7;
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // cencosid
            // 
            this.cencosid.DataPropertyName = "cencosid";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosid.DefaultCellStyle = dataGridViewCellStyle2;
            this.cencosid.HeaderText = "Código";
            this.cencosid.Name = "cencosid";
            this.cencosid.ReadOnly = true;
            this.cencosid.Width = 70;
            // 
            // cencosname
            // 
            this.cencosname.DataPropertyName = "cencosname";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cencosname.DefaultCellStyle = dataGridViewCellStyle3;
            this.cencosname.HeaderText = "Descripción";
            this.cencosname.Name = "cencosname";
            this.cencosname.ReadOnly = true;
            this.cencosname.Width = 450;
            // 
            // Frm_AyudaCCostoPlla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 449);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaCCostoPlla";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centro de Costo";
            this.Activated += new System.EventHandler(this.Frm_AyudaCCostoPlla_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaCCostoPlla_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaCCostoPlla_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.CheckBox chkdescripcion;
        internal System.Windows.Forms.TextBox txtdescripcion;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccionar;
        internal System.Windows.Forms.DataGridView dgProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosname;
    }
}