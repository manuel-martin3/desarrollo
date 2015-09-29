namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaAfectoigvVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaAfectoigvVentas));
            this.dgAyuda = new System.Windows.Forms.DataGridView();
            this.destinoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinoname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAyuda)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAyuda
            // 
            this.dgAyuda.AllowUserToAddRows = false;
            this.dgAyuda.AllowUserToDeleteRows = false;
            this.dgAyuda.AllowUserToResizeRows = false;
            this.dgAyuda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgAyuda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.destinoid,
            this.destinoname});
            this.dgAyuda.Location = new System.Drawing.Point(7, 7);
            this.dgAyuda.MultiSelect = false;
            this.dgAyuda.Name = "dgAyuda";
            this.dgAyuda.ReadOnly = true;
            this.dgAyuda.RowHeadersWidth = 34;
            this.dgAyuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAyuda.Size = new System.Drawing.Size(484, 258);
            this.dgAyuda.TabIndex = 0;
            this.dgAyuda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAyuda_CellContentDoubleClick);
            this.dgAyuda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgAyuda_KeyDown);
            // 
            // destinoid
            // 
            this.destinoid.DataPropertyName = "destinoid";
            this.destinoid.HeaderText = "Código";
            this.destinoid.Name = "destinoid";
            this.destinoid.ReadOnly = true;
            this.destinoid.Width = 80;
            // 
            // destinoname
            // 
            this.destinoname.DataPropertyName = "destinoname";
            this.destinoname.HeaderText = "Descripción";
            this.destinoname.Name = "destinoname";
            this.destinoname.ReadOnly = true;
            this.destinoname.Width = 350;
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(406, 270);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(80, 28);
            this.btnrefrescar.TabIndex = 2;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(73, 263);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 40);
            this.GroupBox4.TabIndex = 1;
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
            // Frm_AyudaAfectoigvVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 305);
            this.Controls.Add(this.btnrefrescar);
            this.Controls.Add(this.dgAyuda);
            this.Controls.Add(this.GroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaAfectoigvVentas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<<Ayuda de Operaciones Gravadas y no Gravadas al IGV >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaAfectoigv_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaAfectoigv_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaAfectoigv_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgAyuda)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.DataGridView dgAyuda;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinoname;
    }
}