namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaDirecciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaDirecciones));
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.ctacte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direcnume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direcdeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCtactename = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.txtCtacte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCadenaBuscar = new System.Windows.Forms.TextBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctacte,
            this.direcnume,
            this.direcdeta,
            this.telef});
            this.dgProveedor.Location = new System.Drawing.Point(6, 85);
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
            this.dgProveedor.RowHeadersWidth = 26;
            this.dgProveedor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProveedor.RowTemplate.Height = 20;
            this.dgProveedor.Size = new System.Drawing.Size(673, 350);
            this.dgProveedor.TabIndex = 4;
            this.dgProveedor.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProveedor_RowHeaderMouseClick);
            this.dgProveedor.DoubleClick += new System.EventHandler(this.dgProveedor_DoubleClick);
            this.dgProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProveedor_KeyDown);
            // 
            // ctacte
            // 
            this.ctacte.DataPropertyName = "ctacte";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctacte.DefaultCellStyle = dataGridViewCellStyle2;
            this.ctacte.HeaderText = "Código";
            this.ctacte.Name = "ctacte";
            this.ctacte.ReadOnly = true;
            this.ctacte.Width = 54;
            // 
            // direcnume
            // 
            this.direcnume.DataPropertyName = "direcnume";
            this.direcnume.HeaderText = "Anexo";
            this.direcnume.Name = "direcnume";
            this.direcnume.ReadOnly = true;
            this.direcnume.Width = 50;
            // 
            // direcdeta
            // 
            this.direcdeta.DataPropertyName = "direcdeta";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direcdeta.DefaultCellStyle = dataGridViewCellStyle3;
            this.direcdeta.HeaderText = "Descripción";
            this.direcdeta.Name = "direcdeta";
            this.direcdeta.ReadOnly = true;
            this.direcdeta.Width = 420;
            // 
            // telef
            // 
            this.telef.DataPropertyName = "telef";
            this.telef.HeaderText = "Teléfono";
            this.telef.Name = "telef";
            this.telef.ReadOnly = true;
            this.telef.Width = 90;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnCancelar);
            this.GroupBox3.Controls.Add(this.btnSeleccion);
            this.GroupBox3.Location = new System.Drawing.Point(247, 439);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(188, 43);
            this.GroupBox3.TabIndex = 5;
            this.GroupBox3.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(96, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 25);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar  ";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(6, 11);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtCtactename);
            this.GroupBox2.Controls.Add(this.txtRuc);
            this.GroupBox2.Controls.Add(this.txtCtacte);
            this.GroupBox2.Controls.Add(this.label2);
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Controls.Add(this.txtCadenaBuscar);
            this.GroupBox2.Controls.Add(this.btnbuscar);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Location = new System.Drawing.Point(6, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(665, 73);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            // 
            // txtCtactename
            // 
            this.txtCtactename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtactename.Enabled = false;
            this.txtCtactename.Location = new System.Drawing.Point(281, 15);
            this.txtCtactename.Name = "txtCtactename";
            this.txtCtactename.Size = new System.Drawing.Size(376, 20);
            this.txtCtactename.TabIndex = 8;
            // 
            // txtRuc
            // 
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Enabled = false;
            this.txtRuc.Location = new System.Drawing.Point(189, 15);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(90, 20);
            this.txtRuc.TabIndex = 7;
            // 
            // txtCtacte
            // 
            this.txtCtacte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtacte.Enabled = false;
            this.txtCtacte.Location = new System.Drawing.Point(56, 15);
            this.txtCtacte.MaxLength = 7;
            this.txtCtacte.Name = "txtCtacte";
            this.txtCtacte.Size = new System.Drawing.Size(60, 20);
            this.txtCtacte.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(122, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ruc - Cód. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Código :";
            // 
            // txtCadenaBuscar
            // 
            this.txtCadenaBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCadenaBuscar.Location = new System.Drawing.Point(107, 44);
            this.txtCadenaBuscar.Name = "txtCadenaBuscar";
            this.txtCadenaBuscar.Size = new System.Drawing.Size(380, 20);
            this.txtCadenaBuscar.TabIndex = 2;
            this.txtCadenaBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCadenaBuscar_KeyDown);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.Location = new System.Drawing.Point(583, 40);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(74, 26);
            this.btnbuscar.TabIndex = 3;
            this.btnbuscar.Text = "&Buscar";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label22.Location = new System.Drawing.Point(8, 48);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(94, 13);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Buscar Dirección :";
            // 
            // Frm_AyudaDirecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 487);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.GroupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_AyudaDirecciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anexos - Direcciones";
            this.Activated += new System.EventHandler(this.Frm_AyudaDirecciones_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaDirecciones_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaDirecciones_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgProveedor;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtCadenaBuscar;
        internal System.Windows.Forms.Button btnbuscar;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.TextBox txtCtactename;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.TextBox txtCtacte;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctacte;
        private System.Windows.Forms.DataGridViewTextBoxColumn direcnume;
        private System.Windows.Forms.DataGridViewTextBoxColumn direcdeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn telef;
    }
}