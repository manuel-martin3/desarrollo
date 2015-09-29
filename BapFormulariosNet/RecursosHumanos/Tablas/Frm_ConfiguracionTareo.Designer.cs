namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_ConfiguracionTareo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ConfiguracionTareo));
            this.barramain = new System.Windows.Forms.ToolStrip();
            this.btnmod = new System.Windows.Forms.ToolStripButton();
            this.btngrabar = new System.Windows.Forms.ToolStripButton();
            this.btncancelar = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.dgIngresos = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBorraFila = new System.Windows.Forms.Button();
            this.btnNuevaFila = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboTipoRubro = new System.Windows.Forms.ComboBox();
            this.cbPlanilla = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CRUBRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DRUBRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PORRUBRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NESTADO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barramain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIngresos)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barramain
            // 
            this.barramain.AutoSize = false;
            this.barramain.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.barramain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmod,
            this.btngrabar,
            this.btncancelar,
            this.btnload,
            this.btncerrar});
            this.barramain.Location = new System.Drawing.Point(0, 0);
            this.barramain.Name = "barramain";
            this.barramain.Size = new System.Drawing.Size(611, 37);
            this.barramain.TabIndex = 18;
            this.barramain.Text = "ToolStrip2";
            // 
            // btnmod
            // 
            this.btnmod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmod.Image = global::BapFormulariosNet.Properties.Resources.btn_editar;
            this.btnmod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmod.Name = "btnmod";
            this.btnmod.Size = new System.Drawing.Size(26, 34);
            this.btnmod.Text = "Editar";
            this.btnmod.Click += new System.EventHandler(this.btnmod_Click);
            // 
            // btngrabar
            // 
            this.btngrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btngrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar;
            this.btngrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btngrabar.Name = "btngrabar";
            this.btngrabar.Size = new System.Drawing.Size(26, 34);
            this.btngrabar.Text = "Guardar";
            this.btngrabar.Click += new System.EventHandler(this.btngrabar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar;
            this.btncancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(26, 34);
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
            this.btncerrar.Size = new System.Drawing.Size(26, 34);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // dgIngresos
            // 
            this.dgIngresos.AllowUserToAddRows = false;
            this.dgIngresos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CRUBRO,
            this.DRUBRO,
            this.PORRUBRO,
            this.NESTADO});
            this.dgIngresos.Location = new System.Drawing.Point(11, 122);
            this.dgIngresos.MultiSelect = false;
            this.dgIngresos.Name = "dgIngresos";
            this.dgIngresos.ReadOnly = true;
            this.dgIngresos.RowHeadersWidth = 24;
            this.dgIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgIngresos.Size = new System.Drawing.Size(591, 277);
            this.dgIngresos.TabIndex = 17;
            this.dgIngresos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgIngresos_EditingControlShowing);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnBorraFila);
            this.GroupBox2.Controls.Add(this.btnNuevaFila);
            this.GroupBox2.Location = new System.Drawing.Point(11, 397);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(194, 44);
            this.GroupBox2.TabIndex = 16;
            this.GroupBox2.TabStop = false;
            // 
            // btnBorraFila
            // 
            this.btnBorraFila.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar20;
            this.btnBorraFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorraFila.Location = new System.Drawing.Point(102, 10);
            this.btnBorraFila.Name = "btnBorraFila";
            this.btnBorraFila.Size = new System.Drawing.Size(83, 29);
            this.btnBorraFila.TabIndex = 1;
            this.btnBorraFila.Text = "&Borra Fila";
            this.btnBorraFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorraFila.UseVisualStyleBackColor = true;
            this.btnBorraFila.Click += new System.EventHandler(this.btnBorraFila_Click);
            // 
            // btnNuevaFila
            // 
            this.btnNuevaFila.Image = global::BapFormulariosNet.Properties.Resources.btn_nuevo20;
            this.btnNuevaFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaFila.Location = new System.Drawing.Point(10, 10);
            this.btnNuevaFila.Name = "btnNuevaFila";
            this.btnNuevaFila.Size = new System.Drawing.Size(83, 29);
            this.btnNuevaFila.TabIndex = 0;
            this.btnNuevaFila.Text = "&Nueva Fila";
            this.btnNuevaFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaFila.UseVisualStyleBackColor = true;
            this.btnNuevaFila.Click += new System.EventHandler(this.btnNuevaFila_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.cboTipoRubro);
            this.GroupBox1.Controls.Add(this.cbPlanilla);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(11, 38);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(591, 80);
            this.GroupBox1.TabIndex = 15;
            this.GroupBox1.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(16, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(66, 13);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Tipo Rubro :";
            // 
            // cboTipoRubro
            // 
            this.cboTipoRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRubro.FormattingEnabled = true;
            this.cboTipoRubro.Location = new System.Drawing.Point(90, 47);
            this.cboTipoRubro.Name = "cboTipoRubro";
            this.cboTipoRubro.Size = new System.Drawing.Size(160, 21);
            this.cboTipoRubro.TabIndex = 4;
            this.cboTipoRubro.SelectedIndexChanged += new System.EventHandler(this.cboTipoRubro_SelectedIndexChanged);
            // 
            // cbPlanilla
            // 
            this.cbPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlanilla.FormattingEnabled = true;
            this.cbPlanilla.Location = new System.Drawing.Point(90, 14);
            this.cbPlanilla.Name = "cbPlanilla";
            this.cbPlanilla.Size = new System.Drawing.Size(359, 21);
            this.cbPlanilla.TabIndex = 3;
            this.cbPlanilla.SelectedIndexChanged += new System.EventHandler(this.cbPlanilla_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Tipo Planilla :";
            // 
            // CRUBRO
            // 
            this.CRUBRO.DataPropertyName = "crubro";
            this.CRUBRO.HeaderText = "Rubro";
            this.CRUBRO.Name = "CRUBRO";
            this.CRUBRO.ReadOnly = true;
            this.CRUBRO.Width = 64;
            // 
            // DRUBRO
            // 
            this.DRUBRO.DataPropertyName = "drubro";
            this.DRUBRO.HeaderText = "Descripcion";
            this.DRUBRO.Name = "DRUBRO";
            this.DRUBRO.ReadOnly = true;
            this.DRUBRO.Width = 340;
            // 
            // PORRUBRO
            // 
            this.PORRUBRO.DataPropertyName = "porrubro";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.PORRUBRO.DefaultCellStyle = dataGridViewCellStyle1;
            this.PORRUBRO.HeaderText = "Posición";
            this.PORRUBRO.Name = "PORRUBRO";
            this.PORRUBRO.ReadOnly = true;
            this.PORRUBRO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PORRUBRO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PORRUBRO.Width = 74;
            // 
            // NESTADO
            // 
            this.NESTADO.DataPropertyName = "nestado";
            this.NESTADO.HeaderText = "Estado";
            this.NESTADO.Name = "NESTADO";
            this.NESTADO.ReadOnly = true;
            this.NESTADO.Width = 60;
            // 
            // Frm_ConfiguracionTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 444);
            this.Controls.Add(this.barramain);
            this.Controls.Add(this.dgIngresos);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_ConfiguracionTareo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Tareo";
            this.Load += new System.EventHandler(this.Frm_ConfiguracionTareo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_ConfiguracionTareo_KeyDown);
            this.barramain.ResumeLayout(false);
            this.barramain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIngresos)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip barramain;
        internal System.Windows.Forms.ToolStripButton btnmod;
        internal System.Windows.Forms.ToolStripButton btngrabar;
        internal System.Windows.Forms.ToolStripButton btncancelar;
        internal System.Windows.Forms.ToolStripButton btnload;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.DataGridView dgIngresos;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnBorraFila;
        internal System.Windows.Forms.Button btnNuevaFila;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboTipoRubro;
        internal System.Windows.Forms.ComboBox cbPlanilla;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRUBRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DRUBRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PORRUBRO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NESTADO;
    }
}