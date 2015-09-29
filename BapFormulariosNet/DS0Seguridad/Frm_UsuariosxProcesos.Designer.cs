namespace BapFormulariosNet.DS0Seguridad
{
    partial class Frm_UsuariosxProcesos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_UsuariosxProcesos));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cboProceso = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.btnReplicar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.btnNuevaFila = new System.Windows.Forms.Button();
            this.dgOrdenes = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLUMN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLUMN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLUMN3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ofdImagen = new System.Windows.Forms.OpenFileDialog();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GroupBox1.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnFiltrar);
            this.GroupBox1.Controls.Add(this.cboProceso);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(14, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(534, 48);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Image = global::BapFormulariosNet.Properties.Resources.filter;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(438, 8);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 38);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "&Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cboProceso
            // 
            this.cboProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProceso.DropDownWidth = 125;
            this.cboProceso.FormattingEnabled = true;
            this.cboProceso.Location = new System.Drawing.Point(94, 16);
            this.cboProceso.Name = "cboProceso";
            this.cboProceso.Size = new System.Drawing.Size(340, 21);
            this.cboProceso.TabIndex = 1;
            this.cboProceso.SelectedIndexChanged += new System.EventHandler(this.cboProceso_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(76, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Tipo Proceso :";
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.btnReplicar);
            this.GroupBox6.Controls.Add(this.btnCancelar);
            this.GroupBox6.Controls.Add(this.btnEditar);
            this.GroupBox6.Controls.Add(this.btnGuardar);
            this.GroupBox6.Controls.Add(this.btnEliminarFila);
            this.GroupBox6.Controls.Add(this.btnNuevaFila);
            this.GroupBox6.Location = new System.Drawing.Point(23, 367);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(513, 48);
            this.GroupBox6.TabIndex = 2;
            this.GroupBox6.TabStop = false;
            // 
            // btnReplicar
            // 
            this.btnReplicar.Image = global::BapFormulariosNet.Properties.Resources.btn_signup20;
            this.btnReplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplicar.Location = new System.Drawing.Point(426, 12);
            this.btnReplicar.Name = "btnReplicar";
            this.btnReplicar.Size = new System.Drawing.Size(80, 30);
            this.btnReplicar.TabIndex = 5;
            this.btnReplicar.Text = "&Replicar ";
            this.btnReplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReplicar.UseVisualStyleBackColor = true;
            this.btnReplicar.Click += new System.EventHandler(this.btnReplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BapFormulariosNet.Properties.Resources.btn_cancelar20;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(341, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar ";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::BapFormulariosNet.Properties.Resources.btn_editar20;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(257, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 30);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar    ";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar20;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(174, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 30);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar ";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.Image = global::BapFormulariosNet.Properties.Resources.btn_del20;
            this.btnEliminarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarFila.Location = new System.Drawing.Point(91, 12);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(80, 30);
            this.btnEliminarFila.TabIndex = 1;
            this.btnEliminarFila.Text = "&Borrar Fila";
            this.btnEliminarFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarFila.UseVisualStyleBackColor = true;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarFila_Click);
            // 
            // btnNuevaFila
            // 
            this.btnNuevaFila.Image = global::BapFormulariosNet.Properties.Resources.btn_nuevo20;
            this.btnNuevaFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaFila.Location = new System.Drawing.Point(7, 12);
            this.btnNuevaFila.Name = "btnNuevaFila";
            this.btnNuevaFila.Size = new System.Drawing.Size(80, 30);
            this.btnNuevaFila.TabIndex = 0;
            this.btnNuevaFila.Text = "&Nueva Fila";
            this.btnNuevaFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaFila.UseVisualStyleBackColor = true;
            this.btnNuevaFila.Click += new System.EventHandler(this.btnNuevaFila_Click);
            // 
            // dgOrdenes
            // 
            this.dgOrdenes.AllowUserToAddRows = false;
            this.dgOrdenes.AllowUserToDeleteRows = false;
            this.dgOrdenes.AllowUserToResizeRows = false;
            this.dgOrdenes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.COLUMN1,
            this.COLUMN2,
            this.COLUMN3,
            this.Column4,
            this.Column6,
            this.Column7});
            this.dgOrdenes.Location = new System.Drawing.Point(14, 66);
            this.dgOrdenes.MultiSelect = false;
            this.dgOrdenes.Name = "dgOrdenes";
            this.dgOrdenes.RowHeadersWidth = 24;
            this.dgOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgOrdenes.Size = new System.Drawing.Size(532, 300);
            this.dgOrdenes.TabIndex = 1;
            this.dgOrdenes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrdenes_CellEndEdit);
            this.dgOrdenes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgOrdenes_CellMouseClick);
            this.dgOrdenes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgOrdenes_EditingControlShowing);
            this.dgOrdenes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgOrdenes_KeyDown);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "TIPOPROCESO";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // COLUMN1
            // 
            this.COLUMN1.DataPropertyName = "ALMACEN";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.COLUMN1.DefaultCellStyle = dataGridViewCellStyle2;
            this.COLUMN1.HeaderText = "Cód.Usuario";
            this.COLUMN1.Name = "COLUMN1";
            this.COLUMN1.Width = 75;
            // 
            // COLUMN2
            // 
            this.COLUMN2.DataPropertyName = "NRO_ORDEN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.COLUMN2.DefaultCellStyle = dataGridViewCellStyle3;
            this.COLUMN2.HeaderText = "Usuario";
            this.COLUMN2.Name = "COLUMN2";
            this.COLUMN2.Width = 250;
            // 
            // COLUMN3
            // 
            this.COLUMN3.DataPropertyName = "RUC";
            this.COLUMN3.HeaderText = "Password";
            this.COLUMN3.Name = "COLUMN3";
            this.COLUMN3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.COLUMN3.Visible = false;
            this.COLUMN3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Column4.HeaderText = "Password";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "FIRMA";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Firma";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 80;
            // 
            // ofdImagen
            // 
            this.ofdImagen.FileName = "OpenFileDialog1";
            // 
            // Frm_UsuariosxProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 418);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.dgOrdenes);
            this.Controls.Add(this.GroupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_UsuariosxProcesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios por Proceso";
            this.Activated += new System.EventHandler(this.Frm_UsuariosxProcesos_Activated);
            this.Load += new System.EventHandler(this.Frm_UsuariosxProcesos_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnFiltrar;
        internal System.Windows.Forms.ComboBox cboProceso;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Button btnReplicar;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnEditar;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Button btnEliminarFila;
        internal System.Windows.Forms.Button btnNuevaFila;
        internal System.Windows.Forms.DataGridView dgOrdenes;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.DataGridViewTextBoxColumn COLUMN1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn COLUMN2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn COLUMN3;
        internal System.Windows.Forms.DataGridViewButtonColumn Column4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.DataGridViewButtonColumn Column7;
        internal System.Windows.Forms.OpenFileDialog ofdImagen;
        internal System.Windows.Forms.ToolTip ToolTip1;
    }
}