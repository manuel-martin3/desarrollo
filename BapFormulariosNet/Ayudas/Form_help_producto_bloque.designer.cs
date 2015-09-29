namespace BapFormulariosNet.Ayudas
{
    partial class Form_help_producto_bloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_help_producto_bloque));
            this.cbo_criterios = new System.Windows.Forms.ComboBox();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.gridgeneral = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSeleccion = new DevExpress.XtraEditors.SimpleButton();
            this.cmb_bloquehoja = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbuscar = new DevExpress.XtraEditors.SimpleButton();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloqueid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloquename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_criterios
            // 
            this.cbo_criterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_criterios.FormattingEnabled = true;
            this.cbo_criterios.Location = new System.Drawing.Point(247, 11);
            this.cbo_criterios.Name = "cbo_criterios";
            this.cbo_criterios.Size = new System.Drawing.Size(134, 21);
            this.cbo_criterios.TabIndex = 13;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_busqueda.Location = new System.Drawing.Point(386, 11);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(266, 20);
            this.txt_busqueda.TabIndex = 1;
            this.txt_busqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_busqueda_KeyDown);
            this.txt_busqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_busqueda_KeyUp);
            // 
            // gridgeneral
            // 
            this.gridgeneral.AllowUserToAddRows = false;
            this.gridgeneral.AllowUserToDeleteRows = false;
            this.gridgeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridgeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.productid,
            this.productname,
            this.cantidad,
            this.bloqueid,
            this.bloquename});
            this.gridgeneral.Location = new System.Drawing.Point(3, 48);
            this.gridgeneral.MultiSelect = false;
            this.gridgeneral.Name = "gridgeneral";
            this.gridgeneral.Size = new System.Drawing.Size(770, 306);
            this.gridgeneral.TabIndex = 42;
            this.gridgeneral.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridgeneral_RowHeaderMouseClick);
            this.gridgeneral.DoubleClick += new System.EventHandler(this.gridgeneral_DoubleClick);
            this.gridgeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridgeneral_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(172, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Buscar por:";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.panelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSeleccion);
            this.panelControl1.Controls.Add(this.cmb_bloquehoja);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.cbo_criterios);
            this.panelControl1.Controls.Add(this.txt_busqueda);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Location = new System.Drawing.Point(3, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(770, 43);
            this.panelControl1.TabIndex = 46;
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccion.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccion.Image")));
            this.btnSeleccion.Location = new System.Drawing.Point(657, 3);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(100, 38);
            this.btnSeleccion.TabIndex = 50;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // cmb_bloquehoja
            // 
            this.cmb_bloquehoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_bloquehoja.FormattingEnabled = true;
            this.cmb_bloquehoja.Location = new System.Drawing.Point(58, 11);
            this.cmb_bloquehoja.Name = "cmb_bloquehoja";
            this.cmb_bloquehoja.Size = new System.Drawing.Size(108, 21);
            this.cmb_bloquehoja.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Bloque:";
            // 
            // btnbuscar
            // 
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnbuscar.Image")));
            this.btnbuscar.Location = new System.Drawing.Point(803, 88);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(81, 38);
            this.btnbuscar.TabIndex = 49;
            this.btnbuscar.Text = "&Buscar";
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // chk
            // 
            this.chk.DataPropertyName = "chk";
            this.chk.HeaderText = "chk";
            this.chk.Name = "chk";
            this.chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chk.Width = 50;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "Codigo";
            this.productid.Name = "productid";
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.HeaderText = "Productos";
            this.productname.Name = "productname";
            this.productname.Width = 350;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.Width = 74;
            // 
            // bloqueid
            // 
            this.bloqueid.DataPropertyName = "bloqueid";
            this.bloqueid.HeaderText = "bloqueid";
            this.bloqueid.Name = "bloqueid";
            this.bloqueid.Visible = false;
            this.bloqueid.Width = 72;
            // 
            // bloquename
            // 
            this.bloquename.DataPropertyName = "bloquename";
            this.bloquename.HeaderText = "bloquename";
            this.bloquename.Name = "bloquename";
            this.bloquename.Visible = false;
            this.bloquename.Width = 90;
            // 
            // Form_help_producto_bloque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 357);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridgeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_help_producto_bloque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Frm_help_general_Activated);
            this.Load += new System.EventHandler(this.Frm_help_general_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_help_general_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbo_criterios;
        internal System.Windows.Forms.TextBox txt_busqueda;
        private System.Windows.Forms.DataGridView gridgeneral;
        internal System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSeleccion;
        private DevExpress.XtraEditors.SimpleButton btnbuscar;
        internal System.Windows.Forms.ComboBox cmb_bloquehoja;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloqueid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bloquename;
    }
}