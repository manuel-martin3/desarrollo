namespace BapFormulariosNet.DS0Seguridad
{
    partial class Frm_InfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_InfoForm));
            this.cmb_dominio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_formularios = new System.Windows.Forms.DataGridView();
            this.dominioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduloid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formfunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_modulo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnameform = new System.Windows.Forms.TextBox();
            this.fechdoc = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfunciones = new System.Windows.Forms.TextBox();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_editar = new System.Windows.Forms.ToolStripButton();
            this.btn_cancelar = new System.Windows.Forms.ToolStripButton();
            this.btn_grabar = new System.Windows.Forms.ToolStripButton();
            this.btn_eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_formularios)).BeginInit();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_dominio
            // 
            this.cmb_dominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dominio.FormattingEnabled = true;
            this.cmb_dominio.Location = new System.Drawing.Point(105, 35);
            this.cmb_dominio.Name = "cmb_dominio";
            this.cmb_dominio.Size = new System.Drawing.Size(183, 22);
            this.cmb_dominio.TabIndex = 108;
            this.cmb_dominio.SelectedIndexChanged += new System.EventHandler(this.cmb_dominio_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 109;
            this.label1.Text = "»» Dominio:";
            // 
            // dgv_formularios
            // 
            this.dgv_formularios.AllowUserToAddRows = false;
            this.dgv_formularios.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_formularios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_formularios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_formularios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_formularios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dominioid,
            this.moduloid,
            this.formname,
            this.formfunc,
            this.feact});
            this.dgv_formularios.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_formularios.Location = new System.Drawing.Point(0, 137);
            this.dgv_formularios.Name = "dgv_formularios";
            this.dgv_formularios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_formularios.RowHeadersVisible = false;
            this.dgv_formularios.ShowCellErrors = false;
            this.dgv_formularios.Size = new System.Drawing.Size(411, 295);
            this.dgv_formularios.TabIndex = 110;
            this.dgv_formularios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_formularios_CellClick);
            this.dgv_formularios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_formularios_CellDoubleClick);
            this.dgv_formularios.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_formularios_KeyUp);
            // 
            // dominioid
            // 
            this.dominioid.DataPropertyName = "dominioid";
            this.dominioid.HeaderText = "dominioid";
            this.dominioid.Name = "dominioid";
            this.dominioid.Visible = false;
            this.dominioid.Width = 50;
            // 
            // moduloid
            // 
            this.moduloid.DataPropertyName = "moduloid";
            this.moduloid.HeaderText = "moduloid";
            this.moduloid.Name = "moduloid";
            this.moduloid.Visible = false;
            // 
            // formname
            // 
            this.formname.DataPropertyName = "formname";
            this.formname.HeaderText = "Formulario";
            this.formname.Name = "formname";
            this.formname.Width = 200;
            // 
            // formfunc
            // 
            this.formfunc.DataPropertyName = "formfunc";
            this.formfunc.HeaderText = "Funciones";
            this.formfunc.Name = "formfunc";
            this.formfunc.Visible = false;
            // 
            // feact
            // 
            this.feact.DataPropertyName = "feact";
            this.feact.HeaderText = "FechaAct";
            this.feact.Name = "feact";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 112;
            this.label2.Text = "»» Modulo :";
            // 
            // cmb_modulo
            // 
            this.cmb_modulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_modulo.FormattingEnabled = true;
            this.cmb_modulo.Location = new System.Drawing.Point(105, 59);
            this.cmb_modulo.Name = "cmb_modulo";
            this.cmb_modulo.Size = new System.Drawing.Size(183, 22);
            this.cmb_modulo.TabIndex = 111;
            this.cmb_modulo.SelectedIndexChanged += new System.EventHandler(this.cmb_modulo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 113;
            this.label3.Text = "»» Formulario :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(417, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 114;
            this.label4.Text = "»» Funciones :";
            // 
            // txtnameform
            // 
            this.txtnameform.Location = new System.Drawing.Point(105, 83);
            this.txtnameform.Name = "txtnameform";
            this.txtnameform.Size = new System.Drawing.Size(306, 20);
            this.txtnameform.TabIndex = 116;
            // 
            // fechdoc
            // 
            this.fechdoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechdoc.Location = new System.Drawing.Point(105, 106);
            this.fechdoc.Name = "fechdoc";
            this.fechdoc.Size = new System.Drawing.Size(112, 20);
            this.fechdoc.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 117;
            this.label5.Text = "»» Fecha Act :";
            // 
            // txtfunciones
            // 
            this.txtfunciones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtfunciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfunciones.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfunciones.ForeColor = System.Drawing.Color.Black;
            this.txtfunciones.Location = new System.Drawing.Point(417, 51);
            this.txtfunciones.Multiline = true;
            this.txtfunciones.Name = "txtfunciones";
            this.txtfunciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtfunciones.Size = new System.Drawing.Size(778, 381);
            this.txtfunciones.TabIndex = 119;
            // 
            // Botonera
            // 
            this.Botonera.BackColor = System.Drawing.SystemColors.Control;
            this.Botonera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_editar,
            this.btn_cancelar,
            this.btn_grabar,
            this.btn_eliminar,
            this.toolStripSeparator5,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(1207, 29);
            this.Botonera.TabIndex = 120;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.BackColor = System.Drawing.Color.Transparent;
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.Image")));
            this.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(23, 26);
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.ToolTipText = "Nuevo (Ctrl + N)";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_editar.Image = global::BapFormulariosNet.Properties.Resources.Edit;
            this.btn_editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(26, 26);
            this.btn_editar.Text = "Editar";
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_cancelar.Image = global::BapFormulariosNet.Properties.Resources.go_undo;
            this.btn_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(24, 26);
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_grabar
            // 
            this.btn_grabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_grabar.Image = ((System.Drawing.Image)(resources.GetObject("btn_grabar.Image")));
            this.btn_grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(26, 26);
            this.btn_grabar.Text = "Grabar";
            this.btn_grabar.ToolTipText = "Grabar (Ctrl + G)";
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_eliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_eliminar20;
            this.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(26, 26);
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = global::BapFormulariosNet.Properties.Resources.go_out2;
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 26);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // Frm_InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 435);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.txtfunciones);
            this.Controls.Add(this.fechdoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtnameform);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_modulo);
            this.Controls.Add(this.dgv_formularios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_dominio);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_InfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Información de Formularios";
            this.Load += new System.EventHandler(this.Frm_InfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_formularios)).EndInit();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_dominio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_formularios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_modulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnameform;
        private System.Windows.Forms.DateTimePicker fechdoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfunciones;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripButton btn_editar;
        private System.Windows.Forms.ToolStripButton btn_cancelar;
        private System.Windows.Forms.ToolStripButton btn_grabar;
        private System.Windows.Forms.ToolStripButton btn_eliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dominioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduloid;
        private System.Windows.Forms.DataGridViewTextBoxColumn formname;
        private System.Windows.Forms.DataGridViewTextBoxColumn formfunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn feact;
    }
}