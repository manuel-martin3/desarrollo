namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Planilla_GenFeriados_Copiar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Planilla_GenFeriados_Copiar));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.chkdel = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.spnperiodo = new System.Windows.Forms.NumericUpDown();
            this.spnperiodod = new System.Windows.Forms.NumericUpDown();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodod)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.spnperiodod);
            this.GroupBox1.Controls.Add(this.spnperiodo);
            this.GroupBox1.Controls.Add(this.btnSalir);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.chkdel);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.btnCopiar);
            this.GroupBox1.Location = new System.Drawing.Point(20, 14);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(411, 185);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(196, 131);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 42);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir  ";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(39, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Desde Periodo";
            // 
            // chkdel
            // 
            this.chkdel.AutoSize = true;
            this.chkdel.Checked = true;
            this.chkdel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkdel.Location = new System.Drawing.Point(127, 91);
            this.chkdel.Name = "chkdel";
            this.chkdel.Size = new System.Drawing.Size(260, 17);
            this.chkdel.TabIndex = 4;
            this.chkdel.Text = "Eliminar Previamente Registros en Nuevo Periodo";
            this.chkdel.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(39, 58);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(82, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Periodo Destino";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Image = global::BapFormulariosNet.Properties.Resources.copydoc32;
            this.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiar.Location = new System.Drawing.Point(104, 131);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(78, 42);
            this.btnCopiar.TabIndex = 5;
            this.btnCopiar.Text = "&Copiar";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // spnperiodo
            // 
            this.spnperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnperiodo.Location = new System.Drawing.Point(138, 18);
            this.spnperiodo.Maximum = new decimal(new int[] {
            2090,
            0,
            0,
            0});
            this.spnperiodo.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnperiodo.Name = "spnperiodo";
            this.spnperiodo.Size = new System.Drawing.Size(68, 26);
            this.spnperiodo.TabIndex = 7;
            this.spnperiodo.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // spnperiodod
            // 
            this.spnperiodod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnperiodod.Location = new System.Drawing.Point(138, 51);
            this.spnperiodod.Maximum = new decimal(new int[] {
            2090,
            0,
            0,
            0});
            this.spnperiodod.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spnperiodod.Name = "spnperiodod";
            this.spnperiodod.Size = new System.Drawing.Size(68, 26);
            this.spnperiodod.TabIndex = 8;
            this.spnperiodod.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // Frm_Planilla_GenFeriados_Copiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 217);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Planilla_GenFeriados_Copiar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Información - Feriados";
            this.Activated += new System.EventHandler(this.Frm_Planilla_GenFeriados_Copiar_Activated);
            this.Load += new System.EventHandler(this.Frm_Planilla_GenFeriados_Copiar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Planilla_GenFeriados_Copiar_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnperiodod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox chkdel;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnCopiar;
        internal System.Windows.Forms.NumericUpDown spnperiodod;
        internal System.Windows.Forms.NumericUpDown spnperiodo;
    }
}