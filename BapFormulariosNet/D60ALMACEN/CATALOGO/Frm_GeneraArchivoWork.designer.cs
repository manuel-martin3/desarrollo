namespace BapFormulariosNet.D60ALMACEN.CATALOGO
{
    partial class Frm_GeneraArchivoWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GeneraArchivoWork));
            this.fechatoma = new System.Windows.Forms.DateTimePicker();
            this.periodo = new System.Windows.Forms.Label();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.fech_fin = new System.Windows.Forms.TextBox();
            this.fech_ini = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.list2List1 = new BapControles.List2List();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.lstgenerado = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_generar = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fechatoma
            // 
            this.fechatoma.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechatoma.Location = new System.Drawing.Point(393, 14);
            this.fechatoma.Name = "fechatoma";
            this.fechatoma.Size = new System.Drawing.Size(82, 21);
            this.fechatoma.TabIndex = 13;
            // 
            // periodo
            // 
            this.periodo.AutoSize = true;
            this.periodo.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodo.Location = new System.Drawing.Point(172, 483);
            this.periodo.Name = "periodo";
            this.periodo.Size = new System.Drawing.Size(65, 20);
            this.periodo.TabIndex = 9;
            this.periodo.Text = "PERIODO";
            // 
            // txtLocal
            // 
            this.txtLocal.Enabled = false;
            this.txtLocal.Location = new System.Drawing.Point(193, 451);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(203, 21);
            this.txtLocal.TabIndex = 8;
            // 
            // fech_fin
            // 
            this.fech_fin.Enabled = false;
            this.fech_fin.Location = new System.Drawing.Point(193, 424);
            this.fech_fin.Name = "fech_fin";
            this.fech_fin.Size = new System.Drawing.Size(203, 21);
            this.fech_fin.TabIndex = 7;
            // 
            // fech_ini
            // 
            this.fech_ini.Enabled = false;
            this.fech_ini.Location = new System.Drawing.Point(193, 397);
            this.fech_ini.Name = "fech_ini";
            this.fech_ini.Size = new System.Drawing.Size(203, 21);
            this.fech_ini.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Almacén:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fin del Proceso:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inicio del Proceso:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.fechatoma);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 50);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(74, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(309, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "INV :: GENERA ARCHIVO TRABAJO";
            // 
            // list2List1
            // 
            this.list2List1.Location = new System.Drawing.Point(33, 48);
            this.list2List1.Name = "list2List1";
            this.list2List1.Size = new System.Drawing.Size(401, 201);
            this.list2List1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.lstgenerado);
            this.panel2.Location = new System.Drawing.Point(62, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 102);
            this.panel2.TabIndex = 15;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImage = global::BapFormulariosNet.Properties.Resources.go_delete;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(351, 28);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(34, 34);
            this.btnNew.TabIndex = 16;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lstgenerado
            // 
            this.lstgenerado.FormattingEnabled = true;
            this.lstgenerado.Location = new System.Drawing.Point(2, 3);
            this.lstgenerado.Name = "lstgenerado";
            this.lstgenerado.Size = new System.Drawing.Size(341, 95);
            this.lstgenerado.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "GENERADO";
            // 
            // btn_generar
            // 
            this.btn_generar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_generar.Image = ((System.Drawing.Image)(resources.GetObject("btn_generar.Image")));
            this.btn_generar.Location = new System.Drawing.Point(193, 250);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(85, 33);
            this.btn_generar.TabIndex = 17;
            this.btn_generar.Text = "&Generar";
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // Frm_GeneraArchivoWork
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(479, 506);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.periodo);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.fech_fin);
            this.Controls.Add(this.fech_ini);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.list2List1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_GeneraArchivoWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*** Inv :: Genera Archivo de Trabajo ***";
            this.Load += new System.EventHandler(this.Frm_reorganiza_perimes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fech_ini;
        private System.Windows.Forms.TextBox fech_fin;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Label periodo;
        private System.Windows.Forms.DateTimePicker fechatoma;
        private BapControles.List2List list2List1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListBox lstgenerado;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btn_generar;        

    }
}