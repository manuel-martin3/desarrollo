namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_help_general
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_help_general));
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSeleccion = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_criterios = new System.Windows.Forms.ComboBox();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.Label22 = new System.Windows.Forms.Label();
            this.gridgeneral = new System.Windows.Forms.DataGridView();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox3.Controls.Add(this.btnExit);
            this.GroupBox3.Controls.Add(this.btnSeleccion);
            this.GroupBox3.Location = new System.Drawing.Point(284, 431);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(262, 47);
            this.GroupBox3.TabIndex = 39;
            this.GroupBox3.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(151, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "&Cerrar    ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSeleccion
            // 
            this.btnSeleccion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSeleccion.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccion.Location = new System.Drawing.Point(19, 14);
            this.btnSeleccion.Name = "btnSeleccion";
            this.btnSeleccion.Size = new System.Drawing.Size(90, 28);
            this.btnSeleccion.TabIndex = 0;
            this.btnSeleccion.Text = "&Seleccionar";
            this.btnSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccion.UseVisualStyleBackColor = true;
            this.btnSeleccion.Click += new System.EventHandler(this.btnSeleccion_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.cbo_criterios);
            this.GroupBox2.Controls.Add(this.txt_busqueda);
            this.GroupBox2.Controls.Add(this.btnbuscar);
            this.GroupBox2.Controls.Add(this.Label22);
            this.GroupBox2.Location = new System.Drawing.Point(6, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(775, 60);
            this.GroupBox2.TabIndex = 41;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Búsqueda";
            // 
            // cbo_criterios
            // 
            this.cbo_criterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_criterios.FormattingEnabled = true;
            this.cbo_criterios.Location = new System.Drawing.Point(88, 24);
            this.cbo_criterios.Name = "cbo_criterios";
            this.cbo_criterios.Size = new System.Drawing.Size(136, 21);
            this.cbo_criterios.TabIndex = 13;
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_busqueda.Location = new System.Drawing.Point(228, 25);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(309, 21);
            this.txt_busqueda.TabIndex = 1;
            this.txt_busqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_busqueda_KeyUp);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.ForeColor = System.Drawing.Color.Black;
            this.btnbuscar.Image = global::BapFormulariosNet.Properties.Resources.btn_search20;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.Location = new System.Drawing.Point(541, 20);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(81, 30);
            this.btnbuscar.TabIndex = 6;
            this.btnbuscar.Text = "&Buscar";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label22.Location = new System.Drawing.Point(8, 28);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(69, 15);
            this.Label22.TabIndex = 0;
            this.Label22.Text = "Buscar por:";
            // 
            // gridgeneral
            // 
            this.gridgeneral.AllowUserToAddRows = false;
            this.gridgeneral.AllowUserToDeleteRows = false;
            this.gridgeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridgeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridgeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridgeneral.Location = new System.Drawing.Point(6, 69);
            this.gridgeneral.MultiSelect = false;
            this.gridgeneral.Name = "gridgeneral";
            this.gridgeneral.ReadOnly = true;
            this.gridgeneral.RowTemplate.Height = 20;
            this.gridgeneral.Size = new System.Drawing.Size(775, 360);
            this.gridgeneral.TabIndex = 42;
            this.gridgeneral.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridgeneral_RowHeaderMouseClick);
            this.gridgeneral.DoubleClick += new System.EventHandler(this.gridgeneral_DoubleClick);
            this.gridgeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridgeneral_KeyDown);
            // 
            // Frm_help_general
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(790, 486);
            this.Controls.Add(this.gridgeneral);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_help_general";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Frm_help_general_Activated);
            this.Load += new System.EventHandler(this.Frm_help_general_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_help_general_KeyDown);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridgeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnSeleccion;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ComboBox cbo_criterios;
        internal System.Windows.Forms.TextBox txt_busqueda;
        internal System.Windows.Forms.Button btnbuscar;
        internal System.Windows.Forms.Label Label22;
        private System.Windows.Forms.DataGridView gridgeneral;
    }
}