namespace BapFormulariosNet.Ayudas
{
    partial class Form_help_producto_precio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_help_producto_precio));
            this.gridgeneral = new System.Windows.Forms.DataGridView();
            this.cbo_criterios = new System.Windows.Forms.ComboBox();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.btnbuscar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridgeneral
            // 
            this.gridgeneral.AllowUserToAddRows = false;
            this.gridgeneral.AllowUserToDeleteRows = false;
            this.gridgeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridgeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridgeneral.Location = new System.Drawing.Point(2, 50);
            this.gridgeneral.MultiSelect = false;
            this.gridgeneral.Name = "gridgeneral";
            this.gridgeneral.Size = new System.Drawing.Size(697, 242);
            this.gridgeneral.TabIndex = 45;
            // 
            // cbo_criterios
            // 
            this.cbo_criterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_criterios.FormattingEnabled = true;
            this.cbo_criterios.Location = new System.Drawing.Point(89, 11);
            this.cbo_criterios.Name = "cbo_criterios";
            this.cbo_criterios.Size = new System.Drawing.Size(136, 21);
            this.cbo_criterios.TabIndex = 13;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_busqueda.Location = new System.Drawing.Point(231, 11);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(309, 21);
            this.txt_busqueda.TabIndex = 1;
            // 
            // btnbuscar
            // 
            this.btnbuscar.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnbuscar.Appearance.Options.UseFont = true;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnbuscar.Image")));
            this.btnbuscar.Location = new System.Drawing.Point(593, 6);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(96, 38);
            this.btnbuscar.TabIndex = 53;
            this.btnbuscar.Text = "&Buscar";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.cbo_criterios);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txt_busqueda);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(576, 43);
            this.panelControl1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Buscar por:";
            // 
            // Form_help_producto_precio
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 296);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridgeneral);
            this.DoubleBuffered = true;
            this.Name = "Form_help_producto_precio";
            this.Text = "**** Ayuda ****";
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridgeneral;
        internal System.Windows.Forms.ComboBox cbo_criterios;
        internal System.Windows.Forms.TextBox txt_busqueda;
        private DevExpress.XtraEditors.SimpleButton btnbuscar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        internal System.Windows.Forms.Label label1;
    }
}