namespace BapFormulariosNet.Ayudas
{
    partial class Form_help_stockinventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_help_stockinventario));
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.cbo_criterios = new System.Windows.Forms.ComboBox();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.gridgeneral = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.go_check;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(676, 4);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(105, 40);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // cbo_criterios
            // 
            this.cbo_criterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_criterios.FormattingEnabled = true;
            this.cbo_criterios.Location = new System.Drawing.Point(93, 9);
            this.cbo_criterios.Name = "cbo_criterios";
            this.cbo_criterios.Size = new System.Drawing.Size(136, 21);
            this.cbo_criterios.TabIndex = 13;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_busqueda.Location = new System.Drawing.Point(233, 9);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(309, 20);
            this.txt_busqueda.TabIndex = 1;
            this.txt_busqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_busqueda_KeyPress);
            this.txt_busqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_busqueda_KeyUp);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.ForeColor = System.Drawing.Color.Black;
            this.btnbuscar.Image = global::BapFormulariosNet.Properties.Resources.go_search3;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.Location = new System.Drawing.Point(590, 4);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(81, 40);
            this.btnbuscar.TabIndex = 6;
            this.btnbuscar.Text = "&Buscar";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // gridgeneral
            // 
            this.gridgeneral.AllowUserToAddRows = false;
            this.gridgeneral.AllowUserToDeleteRows = false;
            this.gridgeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridgeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridgeneral.Location = new System.Drawing.Point(6, 50);
            this.gridgeneral.MultiSelect = false;
            this.gridgeneral.Name = "gridgeneral";
            this.gridgeneral.Size = new System.Drawing.Size(775, 270);
            this.gridgeneral.TabIndex = 42;
            this.gridgeneral.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridgeneral_RowHeaderMouseClick);
            this.gridgeneral.DoubleClick += new System.EventHandler(this.gridgeneral_DoubleClick);
            this.gridgeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridgeneral_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbo_criterios);
            this.panel1.Controls.Add(this.txt_busqueda);
            this.panel1.Location = new System.Drawing.Point(9, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 40);
            this.panel1.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(15, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Buscar por:";
            // 
            // Form_help_stockinventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(785, 325);
            this.Controls.Add(this.btnSeleccion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridgeneral);
            this.Controls.Add(this.btnbuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_help_stockinventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Frm_help_general_Activated);
            this.Load += new System.EventHandler(this.Frm_help_general_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_help_general_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.ComboBox cbo_criterios;
        internal System.Windows.Forms.TextBox txt_busqueda;
        internal System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.DataGridView gridgeneral;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label8;
    }
}