namespace BapFormulariosNet.Ayudas
{
    partial class Frm_AyudaConfiguracionPlla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaConfiguracionPlla));
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rbestado3 = new System.Windows.Forms.RadioButton();
            this.rbestado2 = new System.Windows.Forms.RadioButton();
            this.rbestado1 = new System.Windows.Forms.RadioButton();
            this.lblplanilla = new System.Windows.Forms.Label();
            this.dgrRubrosPago = new System.Windows.Forms.DataGridView();
            this.tipoplla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubroname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRubrosPago)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(14, 454);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(281, 16);
            this.Label2.TabIndex = 54;
            this.Label2.Text = "DOBLE CLICK ==> SELECCIONAR REGISTRO";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rbestado3);
            this.GroupBox5.Controls.Add(this.rbestado2);
            this.GroupBox5.Controls.Add(this.rbestado1);
            this.GroupBox5.Location = new System.Drawing.Point(10, 39);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(246, 39);
            this.GroupBox5.TabIndex = 53;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Visualizar";
            // 
            // rbestado3
            // 
            this.rbestado3.AutoSize = true;
            this.rbestado3.Location = new System.Drawing.Point(154, 14);
            this.rbestado3.Name = "rbestado3";
            this.rbestado3.Size = new System.Drawing.Size(69, 17);
            this.rbestado3.TabIndex = 2;
            this.rbestado3.Text = "Anulados";
            this.rbestado3.UseVisualStyleBackColor = true;
            this.rbestado3.CheckedChanged += new System.EventHandler(this.rbestado3_CheckedChanged);
            // 
            // rbestado2
            // 
            this.rbestado2.AutoSize = true;
            this.rbestado2.Checked = true;
            this.rbestado2.Location = new System.Drawing.Point(85, 14);
            this.rbestado2.Name = "rbestado2";
            this.rbestado2.Size = new System.Drawing.Size(60, 17);
            this.rbestado2.TabIndex = 1;
            this.rbestado2.TabStop = true;
            this.rbestado2.Text = "Activos";
            this.rbestado2.UseVisualStyleBackColor = true;
            this.rbestado2.CheckedChanged += new System.EventHandler(this.rbestado2_CheckedChanged);
            // 
            // rbestado1
            // 
            this.rbestado1.AutoSize = true;
            this.rbestado1.Location = new System.Drawing.Point(22, 14);
            this.rbestado1.Name = "rbestado1";
            this.rbestado1.Size = new System.Drawing.Size(55, 17);
            this.rbestado1.TabIndex = 0;
            this.rbestado1.Text = "Todos";
            this.rbestado1.UseVisualStyleBackColor = true;
            this.rbestado1.CheckedChanged += new System.EventHandler(this.rbestado1_CheckedChanged);
            // 
            // lblplanilla
            // 
            this.lblplanilla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblplanilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblplanilla.Location = new System.Drawing.Point(10, 9);
            this.lblplanilla.Name = "lblplanilla";
            this.lblplanilla.Size = new System.Drawing.Size(469, 25);
            this.lblplanilla.TabIndex = 52;
            this.lblplanilla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgrRubrosPago
            // 
            this.dgrRubrosPago.AllowUserToAddRows = false;
            this.dgrRubrosPago.AllowUserToDeleteRows = false;
            this.dgrRubrosPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrRubrosPago.ColumnHeadersHeight = 30;
            this.dgrRubrosPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoplla,
            this.rubroid,
            this.rubroname,
            this.status});
            this.dgrRubrosPago.Location = new System.Drawing.Point(10, 83);
            this.dgrRubrosPago.Name = "dgrRubrosPago";
            this.dgrRubrosPago.RowHeadersWidth = 24;
            this.dgrRubrosPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrRubrosPago.Size = new System.Drawing.Size(469, 365);
            this.dgrRubrosPago.TabIndex = 51;
            this.dgrRubrosPago.DoubleClick += new System.EventHandler(this.dgrRubrosPago_DoubleClick);
            this.dgrRubrosPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgrRubrosPago_KeyDown);
            // 
            // tipoplla
            // 
            this.tipoplla.DataPropertyName = "tipoplla";
            this.tipoplla.HeaderText = "T/P";
            this.tipoplla.Name = "tipoplla";
            this.tipoplla.Width = 40;
            // 
            // rubroid
            // 
            this.rubroid.DataPropertyName = "rubroid";
            this.rubroid.HeaderText = "Codigo";
            this.rubroid.Name = "rubroid";
            this.rubroid.Width = 55;
            // 
            // rubroname
            // 
            this.rubroname.DataPropertyName = "rubroname";
            this.rubroname.HeaderText = "Nombre";
            this.rubroname.Name = "rubroname";
            this.rubroname.Width = 264;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Estado";
            this.status.Name = "status";
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.status.Width = 62;
            // 
            // Frm_AyudaConfiguracionPlla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 474);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.lblplanilla);
            this.Controls.Add(this.dgrRubrosPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaConfiguracionPlla";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_AyudaConfiguracionPlla";
            this.Load += new System.EventHandler(this.Frm_AyudaConfiguracionPlla_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AyudaConfiguracionPlla_KeyDown);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRubrosPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton rbestado3;
        internal System.Windows.Forms.RadioButton rbestado2;
        internal System.Windows.Forms.RadioButton rbestado1;
        internal System.Windows.Forms.Label lblplanilla;
        internal System.Windows.Forms.DataGridView dgrRubrosPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoplla;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubroname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
    }
}