namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaTipoDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaTipoDocumentos));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCriterioBusqueda = new System.Windows.Forms.ComboBox();
            this.btnrefrescar = new System.Windows.Forms.Button();
            this.dgAyuda = new System.Windows.Forms.DataGridView();
            this.codigoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAyuda)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txtBuscar);
            this.GroupBox2.Controls.Add(this.label2);
            this.GroupBox2.Controls.Add(this.cboCriterioBusqueda);
            this.GroupBox2.Controls.Add(this.btnrefrescar);
            this.GroupBox2.Location = new System.Drawing.Point(4, 1);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(477, 52);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(173, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(205, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(6, 23);
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
            "Código",
            "Descripción"});
            this.cboCriterioBusqueda.Location = new System.Drawing.Point(70, 19);
            this.cboCriterioBusqueda.Name = "cboCriterioBusqueda";
            this.cboCriterioBusqueda.Size = new System.Drawing.Size(100, 21);
            this.cboCriterioBusqueda.TabIndex = 1;
            // 
            // btnrefrescar
            // 
            this.btnrefrescar.Image = global::BapFormulariosNet.Properties.Resources.lupa18;
            this.btnrefrescar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefrescar.Location = new System.Drawing.Point(387, 16);
            this.btnrefrescar.Name = "btnrefrescar";
            this.btnrefrescar.Size = new System.Drawing.Size(82, 28);
            this.btnrefrescar.TabIndex = 3;
            this.btnrefrescar.Text = "&Refrescar";
            this.btnrefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefrescar.UseVisualStyleBackColor = true;
            this.btnrefrescar.Click += new System.EventHandler(this.btnrefrescar_Click);
            // 
            // dgAyuda
            // 
            this.dgAyuda.AllowUserToAddRows = false;
            this.dgAyuda.AllowUserToDeleteRows = false;
            this.dgAyuda.AllowUserToResizeRows = false;
            this.dgAyuda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgAyuda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoid,
            this.descripcion,
            this.Sigla});
            this.dgAyuda.Location = new System.Drawing.Point(6, 58);
            this.dgAyuda.MultiSelect = false;
            this.dgAyuda.Name = "dgAyuda";
            this.dgAyuda.ReadOnly = true;
            this.dgAyuda.RowHeadersVisible = false;
            this.dgAyuda.RowHeadersWidth = 20;
            this.dgAyuda.RowTemplate.Height = 20;
            this.dgAyuda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAyuda.Size = new System.Drawing.Size(474, 317);
            this.dgAyuda.TabIndex = 1;
            this.dgAyuda.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAyuda_CellContentDoubleClick);
            this.dgAyuda.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAyuda_CellDoubleClick);
            this.dgAyuda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgAyuda_KeyDown);
            // 
            // codigoid
            // 
            this.codigoid.DataPropertyName = "codigoid";
            this.codigoid.HeaderText = "Código";
            this.codigoid.Name = "codigoid";
            this.codigoid.ReadOnly = true;
            this.codigoid.Width = 70;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 280;
            // 
            // Sigla
            // 
            this.Sigla.DataPropertyName = "sigla";
            this.Sigla.HeaderText = "Sigla";
            this.Sigla.Name = "Sigla";
            this.Sigla.ReadOnly = true;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCerrar);
            this.GroupBox4.Controls.Add(this.btnSeleccion);
            this.GroupBox4.Location = new System.Drawing.Point(149, 373);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(187, 41);
            this.GroupBox4.TabIndex = 2;
            this.GroupBox4.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(95, 12);
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
            this.btnSeleccion.Location = new System.Drawing.Point(5, 12);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(86, 25);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // Frm_AyudaTipoDocumentos
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 418);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.dgAyuda);
            this.Controls.Add(this.GroupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaTipoDocumentos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda de Comprobantes >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaTipoDocumentos_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaTipoDocumentos_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaTipoDocumentos_KeyUp);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAyuda)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnrefrescar;
        internal System.Windows.Forms.DataGridView dgAyuda;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Button btnSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigla;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCriterioBusqueda;

    }
}