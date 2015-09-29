namespace BapFormulariosNet.Ayudas
{
    partial class Form_help_ordenprod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_help_ordenprod));
            this.cbo_criterios = new System.Windows.Forms.ComboBox();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.gridgeneral = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSeleccion = new DevExpress.XtraEditors.SimpleButton();
            this.btnbuscar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ordenprod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articidold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generoname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_criterios
            // 
            this.cbo_criterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_criterios.FormattingEnabled = true;
            this.cbo_criterios.Location = new System.Drawing.Point(89, 11);
            this.cbo_criterios.Name = "cbo_criterios";
            this.cbo_criterios.Size = new System.Drawing.Size(134, 21);
            this.cbo_criterios.TabIndex = 13;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_busqueda.Location = new System.Drawing.Point(229, 11);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(423, 20);
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
            this.ordenprod,
            this.articid,
            this.articidold,
            this.articname,
            this.marcaid,
            this.marcaname,
            this.lineaid,
            this.lineaname,
            this.generoid,
            this.generoname});
            this.gridgeneral.Location = new System.Drawing.Point(3, 81);
            this.gridgeneral.MultiSelect = false;
            this.gridgeneral.Name = "gridgeneral";
            this.gridgeneral.Size = new System.Drawing.Size(770, 274);
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
            this.label8.Location = new System.Drawing.Point(14, 15);
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
            this.panelControl1.Controls.Add(this.cbo_criterios);
            this.panelControl1.Controls.Add(this.txt_busqueda);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Location = new System.Drawing.Point(3, 36);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(770, 43);
            this.panelControl1.TabIndex = 46;
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccion.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccion.Image")));
            this.btnSeleccion.Location = new System.Drawing.Point(657, 8);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(82, 25);
            this.btnSeleccion.TabIndex = 50;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.ToolTip = "Seleccionar";
            this.btnSeleccion.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
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
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Papyrus", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl4.LineColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelControl4.Location = new System.Drawing.Point(227, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(329, 33);
            this.labelControl4.TabIndex = 440;
            this.labelControl4.Text = "Listado de Orden de Producción";
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
            // ordenprod
            // 
            this.ordenprod.DataPropertyName = "ordenprod";
            this.ordenprod.HeaderText = "OrdenProd";
            this.ordenprod.Name = "ordenprod";
            // 
            // articid
            // 
            this.articid.DataPropertyName = "articid";
            this.articid.HeaderText = "articid";
            this.articid.Name = "articid";
            this.articid.Visible = false;
            // 
            // articidold
            // 
            this.articidold.DataPropertyName = "articidold";
            this.articidold.HeaderText = "ArticID";
            this.articidold.Name = "articidold";
            this.articidold.Width = 70;
            // 
            // articname
            // 
            this.articname.DataPropertyName = "articname";
            this.articname.HeaderText = "Articulo";
            this.articname.Name = "articname";
            this.articname.Width = 250;
            // 
            // marcaid
            // 
            this.marcaid.DataPropertyName = "marcaid";
            this.marcaid.HeaderText = "marcaid";
            this.marcaid.Name = "marcaid";
            this.marcaid.Visible = false;
            // 
            // marcaname
            // 
            this.marcaname.DataPropertyName = "marcaname";
            this.marcaname.HeaderText = "Marca";
            this.marcaname.Name = "marcaname";
            this.marcaname.Width = 80;
            // 
            // lineaid
            // 
            this.lineaid.DataPropertyName = "lineaid";
            this.lineaid.HeaderText = "lineaid";
            this.lineaid.Name = "lineaid";
            this.lineaid.Visible = false;
            // 
            // lineaname
            // 
            this.lineaname.DataPropertyName = "lineaname";
            this.lineaname.HeaderText = "Linea";
            this.lineaname.Name = "lineaname";
            this.lineaname.Width = 80;
            // 
            // generoid
            // 
            this.generoid.DataPropertyName = "generoid";
            this.generoid.HeaderText = "generoid";
            this.generoid.Name = "generoid";
            this.generoid.Visible = false;
            // 
            // generoname
            // 
            this.generoname.DataPropertyName = "generoname";
            this.generoname.HeaderText = "Genero";
            this.generoname.Name = "generoname";
            this.generoname.Width = 80;
            // 
            // Form_help_ordenprod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 357);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridgeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_help_ordenprod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Frm_help_general_Activated);
            this.Load += new System.EventHandler(this.Frm_help_general_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_help_general_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbo_criterios;
        internal System.Windows.Forms.TextBox txt_busqueda;
        private System.Windows.Forms.DataGridView gridgeneral;
        internal System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSeleccion;
        private DevExpress.XtraEditors.SimpleButton btnbuscar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenprod;
        private System.Windows.Forms.DataGridViewTextBoxColumn articid;
        private System.Windows.Forms.DataGridViewTextBoxColumn articidold;
        private System.Windows.Forms.DataGridViewTextBoxColumn articname;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn generoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn generoname;
    }
}