namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Retenciones5ta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Retenciones5ta));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.spnperiodo = new System.Windows.Forms.NumericUpDown();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.btnNuevaFila = new System.Windows.Forms.Button();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.fichaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrelargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retmensual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salxretener = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).BeginInit();
            this.GroupBox6.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.spnperiodo);
            this.GroupBox1.Controls.Add(this.cbMes);
            this.GroupBox1.Controls.Add(this.btnCalcular);
            this.GroupBox1.Location = new System.Drawing.Point(12, 31);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(619, 49);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = " Proceso ";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(22, 22);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Periodo";
            // 
            // spnperiodo
            // 
            this.spnperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnperiodo.Location = new System.Drawing.Point(72, 15);
            this.spnperiodo.Maximum = new decimal(new int[] {
            2090,
            0,
            0,
            0});
            this.spnperiodo.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnperiodo.Name = "spnperiodo";
            this.spnperiodo.Size = new System.Drawing.Size(66, 26);
            this.spnperiodo.TabIndex = 9;
            this.spnperiodo.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnperiodo.ValueChanged += new System.EventHandler(this.spnperiodo_ValueChanged);
            this.spnperiodo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spnperiodo_KeyDown);
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.Enabled = false;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(172, 18);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(161, 21);
            this.cbMes.TabIndex = 0;
            // 
            // btnCalcular
            // 
            //this.btnCalcular.Image = global::BapFormulariosNet.Properties.Resources.suma16;
            this.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalcular.Location = new System.Drawing.Point(414, 14);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(142, 28);
            this.btnCalcular.TabIndex = 1;
            this.btnCalcular.Text = "&Calcular Renta de 5ta.";
            this.btnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.btnEliminarFila);
            this.GroupBox6.Controls.Add(this.btnNuevaFila);
            this.GroupBox6.Location = new System.Drawing.Point(12, 395);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(277, 49);
            this.GroupBox6.TabIndex = 10;
            this.GroupBox6.TabStop = false;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.Image = global::BapFormulariosNet.Properties.Resources.btn_del20;
            this.btnEliminarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarFila.Location = new System.Drawing.Point(144, 12);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(125, 30);
            this.btnEliminarFila.TabIndex = 1;
            this.btnEliminarFila.Text = "&Eliminar Trabajador";
            this.btnEliminarFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarFila.UseVisualStyleBackColor = true;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // btnNuevaFila
            // 
            this.btnNuevaFila.Image = global::BapFormulariosNet.Properties.Resources.btn_add20;
            this.btnNuevaFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaFila.Location = new System.Drawing.Point(8, 12);
            this.btnNuevaFila.Name = "btnNuevaFila";
            this.btnNuevaFila.Size = new System.Drawing.Size(125, 30);
            this.btnNuevaFila.TabIndex = 0;
            this.btnNuevaFila.Text = "&Agregar Trabajador";
            this.btnNuevaFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaFila.UseVisualStyleBackColor = true;
            this.btnNuevaFila.Click += new System.EventHandler(this.btnNuevaFila_Click);
            // 
            // toolbar
            // 
            this.toolbar.AutoSize = false;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btnload,
            this.btncerrar,
            this.ToolStripSeparator1});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(643, 31);
            this.toolbar.TabIndex = 6;
            this.toolbar.Text = "ToolStrip1";
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnmod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 28);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 28);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(26, 28);
            this.btncancelar.Text = "Deshacer";
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnload
            // 
            this.btnload.AutoSize = false;
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnload.Image = global::BapFormulariosNet.Properties.Resources.btn_refresh;
            this.btnload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(30, 30);
            this.btnload.Text = "Actualizar";
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(26, 28);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersHeight = 36;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fichaid,
            this.nombrelargo,
            this.retmensual,
            this.salxretener});
            this.Examinar.Location = new System.Drawing.Point(12, 86);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.ReadOnly = true;
            this.Examinar.RowHeadersWidth = 24;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Examinar.ShowRowErrors = false;
            this.Examinar.Size = new System.Drawing.Size(619, 310);
            this.Examinar.TabIndex = 9;
            this.Examinar.SelectionChanged += new System.EventHandler(this.Examinar_SelectionChanged);
            // 
            // fichaid
            // 
            this.fichaid.DataPropertyName = "fichaid";
            this.fichaid.HeaderText = "Ficha";
            this.fichaid.Name = "fichaid";
            this.fichaid.ReadOnly = true;
            // 
            // nombrelargo
            // 
            this.nombrelargo.DataPropertyName = "nombrelargo";
            this.nombrelargo.HeaderText = "Apellidos y Nombres";
            this.nombrelargo.Name = "nombrelargo";
            this.nombrelargo.ReadOnly = true;
            this.nombrelargo.Width = 300;
            // 
            // retmensual
            // 
            this.retmensual.DataPropertyName = "retmensual";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.retmensual.DefaultCellStyle = dataGridViewCellStyle1;
            this.retmensual.HeaderText = "Retención Mensual";
            this.retmensual.Name = "retmensual";
            this.retmensual.ReadOnly = true;
            this.retmensual.Width = 85;
            // 
            // salxretener
            // 
            this.salxretener.DataPropertyName = "salxretener";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.salxretener.DefaultCellStyle = dataGridViewCellStyle2;
            this.salxretener.HeaderText = "Saldo x Retener";
            this.salxretener.Name = "salxretener";
            this.salxretener.ReadOnly = true;
            this.salxretener.Width = 85;
            // 
            // Frm_Retenciones5ta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 449);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.GroupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_Retenciones5ta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retención de 5ta Categoría";
            this.Activated += new System.EventHandler(this.Frm_Retenciones5ta_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Retenciones5ta_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Retenciones5ta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Retenciones5ta_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).EndInit();
            this.GroupBox6.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown spnperiodo;
        internal System.Windows.Forms.ComboBox cbMes;
        internal System.Windows.Forms.Button btnCalcular;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Button btnEliminarFila;
        internal System.Windows.Forms.Button btnNuevaFila;
        internal System.Windows.Forms.ToolStrip toolbar;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.DataGridView Examinar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fichaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrelargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn retmensual;
        private System.Windows.Forms.DataGridViewTextBoxColumn salxretener;
    }
}