namespace BapFormulariosNet.D20Comercial
{
    partial class Frm_SeleccionVariosClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SeleccionVariosClientes));
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.Examinar = new System.Windows.Forms.DataGridView();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomdetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoSoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldodolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCtactename = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox9.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.btnEliminar);
            this.GroupBox9.Location = new System.Drawing.Point(11, 326);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(86, 43);
            this.GroupBox9.TabIndex = 11;
            this.GroupBox9.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(6, 11);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(73, 25);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btnSalir);
            this.GroupBox3.Controls.Add(this.btnAceptar);
            this.GroupBox3.Location = new System.Drawing.Point(248, 326);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(188, 43);
            this.GroupBox3.TabIndex = 10;
            this.GroupBox3.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(96, 11);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 25);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Cancelar  ";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(5, 11);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 25);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Seleccionar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Examinar
            // 
            this.Examinar.AllowUserToAddRows = false;
            this.Examinar.AllowUserToDeleteRows = false;
            this.Examinar.AllowUserToResizeColumns = false;
            this.Examinar.AllowUserToResizeRows = false;
            this.Examinar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Examinar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.Examinar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Examinar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detalle,
            this.nomdetalle,
            this.SaldoSoles,
            this.Saldodolares});
            this.Examinar.Location = new System.Drawing.Point(9, 51);
            this.Examinar.MultiSelect = false;
            this.Examinar.Name = "Examinar";
            this.Examinar.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examinar.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Examinar.RowTemplate.Height = 20;
            this.Examinar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Examinar.Size = new System.Drawing.Size(587, 276);
            this.Examinar.TabIndex = 9;
            // 
            // detalle
            // 
            this.detalle.DataPropertyName = "detalle";
            this.detalle.Frozen = true;
            this.detalle.HeaderText = "Código";
            this.detalle.Name = "detalle";
            this.detalle.ReadOnly = true;
            this.detalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.detalle.Width = 86;
            // 
            // nomdetalle
            // 
            this.nomdetalle.DataPropertyName = "nomdetalle";
            this.nomdetalle.Frozen = true;
            this.nomdetalle.HeaderText = "Razón Social / Apellidos y Nombres";
            this.nomdetalle.Name = "nomdetalle";
            this.nomdetalle.Width = 300;
            // 
            // SaldoSoles
            // 
            this.SaldoSoles.DataPropertyName = "SaldoSoles";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.SaldoSoles.DefaultCellStyle = dataGridViewCellStyle1;
            this.SaldoSoles.Frozen = true;
            this.SaldoSoles.HeaderText = "Saldo S/.";
            this.SaldoSoles.Name = "SaldoSoles";
            this.SaldoSoles.Width = 85;
            // 
            // Saldodolares
            // 
            this.Saldodolares.DataPropertyName = "Saldodolares";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.Saldodolares.DefaultCellStyle = dataGridViewCellStyle2;
            this.Saldodolares.Frozen = true;
            this.Saldodolares.HeaderText = "Saldo US$.";
            this.Saldodolares.Name = "Saldodolares";
            this.Saldodolares.Width = 85;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCtactename);
            this.groupBox1.Controls.Add(this.txtRuc);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 42);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // txtCtactename
            // 
            this.txtCtactename.Enabled = false;
            this.txtCtactename.Location = new System.Drawing.Point(158, 14);
            this.txtCtactename.Name = "txtCtactename";
            this.txtCtactename.Size = new System.Drawing.Size(418, 21);
            this.txtCtactename.TabIndex = 11;
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(66, 14);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(90, 21);
            this.txtRuc.TabIndex = 10;
            this.txtRuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRuc_KeyDown);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Ruc-Cód";
            // 
            // Frm_SeleccionVariosClientes
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 371);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Examinar);
            this.Controls.Add(this.GroupBox9);
            this.Controls.Add(this.GroupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_SeleccionVariosClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Múltiples Clientes/Proveedores";
            this.Activated += new System.EventHandler(this.Frm_SeleccionVariosClientes_Activated);
            this.Load += new System.EventHandler(this.Frm_SeleccionVariosClientes_Load);
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Examinar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox9;
        internal System.Windows.Forms.Button btnEliminar;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.DataGridView Examinar;
        internal System.Windows.Forms.DataGridViewTextBoxColumn detalle;
        internal System.Windows.Forms.DataGridViewTextBoxColumn nomdetalle;
        internal System.Windows.Forms.DataGridViewTextBoxColumn SaldoSoles;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Saldodolares;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtCtactename;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.Label Label1;
    }
}