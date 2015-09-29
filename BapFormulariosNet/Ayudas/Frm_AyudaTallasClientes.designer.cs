namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaTallasClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaTallasClientes));
            this.dgAyuda = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDescrip = new System.Windows.Forms.CheckBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.tallaidcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tallaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAyuda)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAyuda
            // 
            this.dgAyuda.AllowUserToAddRows = false;
            this.dgAyuda.AllowUserToDeleteRows = false;
            this.dgAyuda.AllowUserToResizeRows = false;
            this.dgAyuda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tallaidcol,
            this.tallaname,
            this.talla});
            this.dgAyuda.Location = new System.Drawing.Point(12, 70);
            this.dgAyuda.MultiSelect = false;
            this.dgAyuda.Name = "dgAyuda";
            this.dgAyuda.ReadOnly = true;
            this.dgAyuda.RowHeadersVisible = false;
            this.dgAyuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAyuda.Size = new System.Drawing.Size(435, 304);
            this.dgAyuda.TabIndex = 17;
            this.dgAyuda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAyuda_CellContentDoubleClick);
            this.dgAyuda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAyuda_CellDoubleClick);
            this.dgAyuda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgAyuda_KeyDown);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.chkDescrip);
            this.GroupBox2.Controls.Add(this.txtDescrip);
            this.GroupBox2.Controls.Add(this.btnBuscar);
            this.GroupBox2.Location = new System.Drawing.Point(12, 8);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(411, 52);
            this.GroupBox2.TabIndex = 16;
            this.GroupBox2.TabStop = false;
            // 
            // chkDescrip
            // 
            this.chkDescrip.AutoSize = true;
            this.chkDescrip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDescrip.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkDescrip.Location = new System.Drawing.Point(8, 20);
            this.chkDescrip.Name = "chkDescrip";
            this.chkDescrip.Size = new System.Drawing.Size(82, 17);
            this.chkDescrip.TabIndex = 2;
            this.chkDescrip.Text = "Descripción";
            this.chkDescrip.UseVisualStyleBackColor = true;
            this.chkDescrip.CheckedChanged += new System.EventHandler(this.chkDescrip_CheckedChanged);
            // 
            // txtDescrip
            // 
            this.txtDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescrip.Location = new System.Drawing.Point(98, 18);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(184, 20);
            this.txtDescrip.TabIndex = 3;
            this.txtDescrip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescrip_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(311, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 28);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(148, 375);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 38;
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
            // tallaidcol
            // 
            this.tallaidcol.DataPropertyName = "tallaidcol";
            this.tallaidcol.HeaderText = "Código";
            this.tallaidcol.Name = "tallaidcol";
            this.tallaidcol.ReadOnly = true;
            this.tallaidcol.Width = 80;
            // 
            // tallaname
            // 
            this.tallaname.DataPropertyName = "tallaname";
            this.tallaname.HeaderText = "Descripción";
            this.tallaname.Name = "tallaname";
            this.tallaname.ReadOnly = true;
            this.tallaname.Width = 250;
            // 
            // talla
            // 
            this.talla.DataPropertyName = "talla";
            this.talla.HeaderText = "Talla";
            this.talla.Name = "talla";
            this.talla.ReadOnly = true;
            this.talla.Width = 80;
            // 
            // Frm_AyudaTallasClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 420);
            this.Controls.Add(this.dgAyuda);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaTallasClientes";
            this.ShowInTaskbar = false;
            this.Text = "Catálogo Tallas - Cliente";
            this.Activated += new System.EventHandler(this.Frm_AyudaTallasClientes_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaTallasClientes_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaTallasClientes_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgAyuda)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgAyuda;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.CheckBox chkDescrip;
        internal System.Windows.Forms.TextBox txtDescrip;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tallaidcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn tallaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn talla;
    }
}