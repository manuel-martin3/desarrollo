namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Horarios_HorariosAsignacionMasiva
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Horarios_HorariosAsignacionMasiva));
            this.dgColores = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.cbHorario = new System.Windows.Forms.ComboBox();
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.ChkHorario = new System.Windows.Forms.CheckBox();
            this.Chkcargo = new System.Windows.Forms.CheckBox();
            this.ChkCCosto = new System.Windows.Forms.CheckBox();
            this.ChkPlanilla = new System.Windows.Forms.CheckBox();
            this.cbCCosto = new System.Windows.Forms.ComboBox();
            this.cbplanilla = new System.Windows.Forms.ComboBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.rbasignacion = new System.Windows.Forms.RadioButton();
            this.rbprogramacion = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtpFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.cbHorarioDestino = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgColores)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgColores
            // 
            this.dgColores.AllowUserToAddRows = false;
            this.dgColores.AllowUserToDeleteRows = false;
            this.dgColores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgColores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgColores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgColores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column6,
            this.Column11,
            this.Column12,
            this.Column4,
            this.Column5});
            this.dgColores.Location = new System.Drawing.Point(9, 90);
            this.dgColores.Name = "dgColores";
            this.dgColores.RowHeadersWidth = 24;
            this.dgColores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgColores.Size = new System.Drawing.Size(855, 394);
            this.dgColores.TabIndex = 100;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "seleccionar";
            this.Column7.HeaderText = "Chk";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 40;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ficha";
            this.Column3.HeaderText = "Codigo";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 60;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "dficha";
            this.Column1.HeaderText = "Apellidos y Nombres";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "fec_ini";
            this.Column2.HeaderText = "Fecha Ingreso";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "tipo_horario";
            this.Column6.HeaderText = "P";
            this.Column6.Name = "Column6";
            this.Column6.Width = 25;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "cod_horario_semanal";
            this.Column11.HeaderText = "T";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 40;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "des_Horario";
            this.Column12.HeaderText = "Descripcion";
            this.Column12.MaxInputLength = 1;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "d_costo";
            this.Column4.HeaderText = "Centro de Costos";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column5.HeaderText = "Cargo";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 150;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.cbHorario);
            this.GroupBox2.Controls.Add(this.cbCargo);
            this.GroupBox2.Controls.Add(this.ChkHorario);
            this.GroupBox2.Controls.Add(this.Chkcargo);
            this.GroupBox2.Controls.Add(this.ChkCCosto);
            this.GroupBox2.Controls.Add(this.ChkPlanilla);
            this.GroupBox2.Controls.Add(this.cbCCosto);
            this.GroupBox2.Controls.Add(this.cbplanilla);
            this.GroupBox2.Location = new System.Drawing.Point(260, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(604, 83);
            this.GroupBox2.TabIndex = 103;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Datos del Trabajador";
            // 
            // cbHorario
            // 
            this.cbHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHorario.Enabled = false;
            this.cbHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHorario.FormattingEnabled = true;
            this.cbHorario.Location = new System.Drawing.Point(376, 49);
            this.cbHorario.Name = "cbHorario";
            this.cbHorario.Size = new System.Drawing.Size(221, 21);
            this.cbHorario.TabIndex = 79;
            this.cbHorario.SelectedIndexChanged += new System.EventHandler(this.cbHorario_SelectedIndexChanged);
            // 
            // cbCargo
            // 
            this.cbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo.Enabled = false;
            this.cbCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCargo.FormattingEnabled = true;
            this.cbCargo.Location = new System.Drawing.Point(376, 20);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(221, 21);
            this.cbCargo.TabIndex = 78;
            this.cbCargo.SelectedIndexChanged += new System.EventHandler(this.cbCargo_SelectedIndexChanged);
            // 
            // ChkHorario
            // 
            this.ChkHorario.AutoSize = true;
            this.ChkHorario.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkHorario.Location = new System.Drawing.Point(311, 51);
            this.ChkHorario.Name = "ChkHorario";
            this.ChkHorario.Size = new System.Drawing.Size(60, 17);
            this.ChkHorario.TabIndex = 76;
            this.ChkHorario.Text = "Horario";
            this.ChkHorario.UseVisualStyleBackColor = true;
            this.ChkHorario.CheckedChanged += new System.EventHandler(this.ChkHorario_CheckedChanged);
            // 
            // Chkcargo
            // 
            this.Chkcargo.AutoSize = true;
            this.Chkcargo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Chkcargo.Location = new System.Drawing.Point(317, 22);
            this.Chkcargo.Name = "Chkcargo";
            this.Chkcargo.Size = new System.Drawing.Size(54, 17);
            this.Chkcargo.TabIndex = 74;
            this.Chkcargo.Text = "Cargo";
            this.Chkcargo.UseVisualStyleBackColor = true;
            this.Chkcargo.CheckedChanged += new System.EventHandler(this.Chkcargo_CheckedChanged);
            // 
            // ChkCCosto
            // 
            this.ChkCCosto.AutoSize = true;
            this.ChkCCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkCCosto.Location = new System.Drawing.Point(7, 51);
            this.ChkCCosto.Name = "ChkCCosto";
            this.ChkCCosto.Size = new System.Drawing.Size(66, 17);
            this.ChkCCosto.TabIndex = 73;
            this.ChkCCosto.Text = "C. Costo";
            this.ChkCCosto.UseVisualStyleBackColor = true;
            this.ChkCCosto.CheckedChanged += new System.EventHandler(this.ChkCCosto_CheckedChanged);
            // 
            // ChkPlanilla
            // 
            this.ChkPlanilla.AutoSize = true;
            this.ChkPlanilla.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkPlanilla.Location = new System.Drawing.Point(14, 22);
            this.ChkPlanilla.Name = "ChkPlanilla";
            this.ChkPlanilla.Size = new System.Drawing.Size(59, 17);
            this.ChkPlanilla.TabIndex = 72;
            this.ChkPlanilla.Text = "Planilla";
            this.ChkPlanilla.UseVisualStyleBackColor = true;
            this.ChkPlanilla.CheckedChanged += new System.EventHandler(this.ChkPlanilla_CheckedChanged);
            // 
            // cbCCosto
            // 
            this.cbCCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCCosto.Enabled = false;
            this.cbCCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCCosto.FormattingEnabled = true;
            this.cbCCosto.Location = new System.Drawing.Point(79, 49);
            this.cbCCosto.Name = "cbCCosto";
            this.cbCCosto.Size = new System.Drawing.Size(221, 21);
            this.cbCCosto.TabIndex = 71;
            this.cbCCosto.SelectedIndexChanged += new System.EventHandler(this.cbCCosto_SelectedIndexChanged);
            // 
            // cbplanilla
            // 
            this.cbplanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbplanilla.Enabled = false;
            this.cbplanilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbplanilla.FormattingEnabled = true;
            this.cbplanilla.Location = new System.Drawing.Point(79, 20);
            this.cbplanilla.Name = "cbplanilla";
            this.cbplanilla.Size = new System.Drawing.Size(221, 21);
            this.cbplanilla.TabIndex = 54;
            this.cbplanilla.SelectedIndexChanged += new System.EventHandler(this.cbplanilla_SelectedIndexChanged);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.btnSalir);
            this.GroupBox5.Controls.Add(this.btnAsignar);
            this.GroupBox5.Controls.Add(this.Label3);
            this.GroupBox5.Controls.Add(this.btnDesmarcar);
            this.GroupBox5.Controls.Add(this.btnMarcar);
            this.GroupBox5.Controls.Add(this.GroupBox3);
            this.GroupBox5.Location = new System.Drawing.Point(10, 486);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(853, 57);
            this.GroupBox5.TabIndex = 101;
            this.GroupBox5.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::BapFormulariosNet.Properties.Resources.exit32;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(721, 11);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 41);
            this.btnSalir.TabIndex = 62;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Image = global::BapFormulariosNet.Properties.Resources.Save;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignar.Location = new System.Drawing.Point(587, 11);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(100, 41);
            this.btnAsignar.TabIndex = 61;
            this.btnAsignar.Text = "&Asignar";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(6, -1);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(109, 13);
            this.Label3.TabIndex = 60;
            this.Label3.Text = "Datos Adicionales";
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Image = global::BapFormulariosNet.Properties.Resources.undo_16;
            this.btnDesmarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesmarcar.Location = new System.Drawing.Point(446, 11);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(100, 41);
            this.btnDesmarcar.TabIndex = 59;
            this.btnDesmarcar.Text = "&Desmarcar";
            this.btnDesmarcar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesmarcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // btnMarcar
            // 
            this.btnMarcar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnMarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMarcar.Location = new System.Drawing.Point(299, 11);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(100, 41);
            this.btnMarcar.TabIndex = 10;
            this.btnMarcar.Text = "&Marcar";
            this.btnMarcar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMarcar.UseVisualStyleBackColor = true;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.rbasignacion);
            this.GroupBox3.Controls.Add(this.rbprogramacion);
            this.GroupBox3.Location = new System.Drawing.Point(14, 14);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(197, 34);
            this.GroupBox3.TabIndex = 102;
            this.GroupBox3.TabStop = false;
            // 
            // rbasignacion
            // 
            this.rbasignacion.AutoSize = true;
            this.rbasignacion.Checked = true;
            this.rbasignacion.Location = new System.Drawing.Point(9, 11);
            this.rbasignacion.Name = "rbasignacion";
            this.rbasignacion.Size = new System.Drawing.Size(77, 17);
            this.rbasignacion.TabIndex = 100;
            this.rbasignacion.TabStop = true;
            this.rbasignacion.Text = "Asignación";
            this.rbasignacion.UseVisualStyleBackColor = true;
            // 
            // rbprogramacion
            // 
            this.rbprogramacion.AutoSize = true;
            this.rbprogramacion.Location = new System.Drawing.Point(97, 11);
            this.rbprogramacion.Name = "rbprogramacion";
            this.rbprogramacion.Size = new System.Drawing.Size(90, 17);
            this.rbprogramacion.TabIndex = 101;
            this.rbprogramacion.Text = "Programación";
            this.rbprogramacion.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.dtpFechaEmision);
            this.GroupBox1.Controls.Add(this.cbHorarioDestino);
            this.GroupBox1.Location = new System.Drawing.Point(9, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(245, 83);
            this.GroupBox1.TabIndex = 102;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Horario a Asignar";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(20, 38);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(86, 13);
            this.Label4.TabIndex = 62;
            this.Label4.Text = "Horario Destino :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(21, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 61;
            this.Label1.Text = "Fecha Desde :";
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(129, 17);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(106, 20);
            this.dtpFechaEmision.TabIndex = 60;
            // 
            // cbHorarioDestino
            // 
            this.cbHorarioDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHorarioDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHorarioDestino.FormattingEnabled = true;
            this.cbHorarioDestino.Location = new System.Drawing.Point(10, 54);
            this.cbHorarioDestino.Name = "cbHorarioDestino";
            this.cbHorarioDestino.Size = new System.Drawing.Size(225, 21);
            this.cbHorarioDestino.TabIndex = 54;
            // 
            // Frm_Horarios_HorariosAsignacionMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 548);
            this.Controls.Add(this.dgColores);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_Horarios_HorariosAsignacionMasiva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación Masiva de Horarios";
            this.Load += new System.EventHandler(this.Frm_Horarios_HorariosAsignacionMasiva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgColores)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgColores;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ComboBox cbHorario;
        internal System.Windows.Forms.ComboBox cbCargo;
        internal System.Windows.Forms.CheckBox ChkHorario;
        internal System.Windows.Forms.CheckBox Chkcargo;
        internal System.Windows.Forms.CheckBox ChkCCosto;
        internal System.Windows.Forms.CheckBox ChkPlanilla;
        internal System.Windows.Forms.ComboBox cbCCosto;
        internal System.Windows.Forms.ComboBox cbplanilla;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.RadioButton rbasignacion;
        internal System.Windows.Forms.RadioButton rbprogramacion;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnAsignar;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnDesmarcar;
        internal System.Windows.Forms.Button btnMarcar;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtpFechaEmision;
        internal System.Windows.Forms.ComboBox cbHorarioDestino;
    }
}