namespace BapFormulariosNet.MERCADERIA.PROCESOS
{
    partial class Frm_cierre_perimes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_cierre_perimes));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fech_ini = new System.Windows.Forms.TextBox();
            this.fech_fin = new System.Windows.Forms.TextBox();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.periodo = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_process = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Botonera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inicio del Proceso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fin del Proceso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Almacén:";
            // 
            // fech_ini
            // 
            this.fech_ini.Enabled = false;
            this.fech_ini.Location = new System.Drawing.Point(123, 70);
            this.fech_ini.Name = "fech_ini";
            this.fech_ini.Size = new System.Drawing.Size(245, 21);
            this.fech_ini.TabIndex = 6;
            // 
            // fech_fin
            // 
            this.fech_fin.Enabled = false;
            this.fech_fin.Location = new System.Drawing.Point(123, 97);
            this.fech_fin.Name = "fech_fin";
            this.fech_fin.Size = new System.Drawing.Size(245, 21);
            this.fech_fin.TabIndex = 7;
            // 
            // txtLocal
            // 
            this.txtLocal.Enabled = false;
            this.txtLocal.Location = new System.Drawing.Point(123, 124);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(245, 21);
            this.txtLocal.TabIndex = 8;
            // 
            // periodo
            // 
            this.periodo.AutoSize = true;
            this.periodo.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodo.Location = new System.Drawing.Point(101, 150);
            this.periodo.Name = "periodo";
            this.periodo.Size = new System.Drawing.Size(65, 20);
            this.periodo.TabIndex = 9;
            this.periodo.Text = "PERIODO";
            // 
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_process,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(380, 29);
            this.Botonera.TabIndex = 13;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_process
            // 
            this.btn_process.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_process.Image = global::BapFormulariosNet.Properties.Resources.go_check;
            this.btn_process.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(26, 26);
            this.btn_process.Text = "Accept";
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-2, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 32);
            this.panel1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "CIERRE MES";
            // 
            // Frm_cierre_perimes
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(380, 180);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.periodo);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.fech_fin);
            this.Controls.Add(this.fech_ini);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_cierre_perimes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*** Cierre Mes ***";
            this.Load += new System.EventHandler(this.Frm_reorganiza_perimes_Load);
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fech_ini;
        private System.Windows.Forms.TextBox fech_fin;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Label periodo;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_process;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;

    }
}