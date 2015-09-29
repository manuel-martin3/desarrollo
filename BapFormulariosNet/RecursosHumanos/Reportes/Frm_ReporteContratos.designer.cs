namespace BapFormulariosNet.RecursosHumanos.Reportes
{
    partial class Frm_ReporteContratos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ReporteContratos));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btncerrar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_imprimir = new System.Windows.Forms.ToolStripButton();
            this.txtdcosto = new System.Windows.Forms.TextBox();
            this.txtccosto = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.txtdcargo = new System.Windows.Forms.TextBox();
            this.txtccargo = new System.Windows.Forms.TextBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.gpbox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolbar.SuspendLayout();
            this.gpbox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.AutoSize = false;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_imprimir,
            this.ToolStripSeparator1,
            this.btncerrar});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(578, 31);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "ToolStrip1";
            // 
            // btncerrar
            // 
            this.btncerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncerrar.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(26, 28);
            this.btncerrar.Text = "Salir";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_imprimir.Image = global::BapFormulariosNet.Properties.Resources.agt_print;
            this.btn_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(26, 28);
            this.btn_imprimir.Text = "toolStripButton1";
            this.btn_imprimir.ToolTipText = "Imprimir Contrato";
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // txtdcosto
            // 
            this.txtdcosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdcosto.Location = new System.Drawing.Point(120, 28);
            this.txtdcosto.Name = "txtdcosto";
            this.txtdcosto.Size = new System.Drawing.Size(408, 20);
            this.txtdcosto.TabIndex = 61;
            // 
            // txtccosto
            // 
            this.txtccosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtccosto.Location = new System.Drawing.Point(64, 28);
            this.txtccosto.MaxLength = 5;
            this.txtccosto.Name = "txtccosto";
            this.txtccosto.Size = new System.Drawing.Size(54, 20);
            this.txtccosto.TabIndex = 60;
            this.txtccosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtccosto_KeyDown);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.ForeColor = System.Drawing.Color.Black;
            this.Label27.Location = new System.Drawing.Point(18, 32);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(44, 13);
            this.Label27.TabIndex = 59;
            this.Label27.Text = "C.Costo";
            // 
            // txtdcargo
            // 
            this.txtdcargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdcargo.Location = new System.Drawing.Point(120, 51);
            this.txtdcargo.Name = "txtdcargo";
            this.txtdcargo.Size = new System.Drawing.Size(408, 20);
            this.txtdcargo.TabIndex = 64;
            // 
            // txtccargo
            // 
            this.txtccargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtccargo.Location = new System.Drawing.Point(64, 51);
            this.txtccargo.MaxLength = 3;
            this.txtccargo.Name = "txtccargo";
            this.txtccargo.Size = new System.Drawing.Size(54, 20);
            this.txtccargo.TabIndex = 63;
            this.txtccargo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtccargo_KeyDown);
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.ForeColor = System.Drawing.Color.Black;
            this.Label28.Location = new System.Drawing.Point(27, 55);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(35, 13);
            this.Label28.TabIndex = 62;
            this.Label28.Text = "Cargo";
            // 
            // gpbox
            // 
            this.gpbox.Controls.Add(this.Label27);
            this.gpbox.Controls.Add(this.txtdcargo);
            this.gpbox.Controls.Add(this.txtccosto);
            this.gpbox.Controls.Add(this.txtccargo);
            this.gpbox.Controls.Add(this.txtdcosto);
            this.gpbox.Controls.Add(this.Label28);
            this.gpbox.Location = new System.Drawing.Point(10, 95);
            this.gpbox.Name = "gpbox";
            this.gpbox.Size = new System.Drawing.Size(542, 122);
            this.gpbox.TabIndex = 65;
            this.gpbox.TabStop = false;
            this.gpbox.Text = "Datos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::BapFormulariosNet.Properties.Resources.bannerblue2;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(-15, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 56);
            this.panel1.TabIndex = 67;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(196, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(208, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Historial por Estacion";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 16);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            // 
            // Frm_ReporteContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 224);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpbox);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_ReporteContratos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte - Contratos de Personales";
            this.Load += new System.EventHandler(this.Frm_PorcentajeLeyTrabajador_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.gpbox.ResumeLayout(false);
            this.gpbox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolbar;
        internal System.Windows.Forms.ToolStripButton btncerrar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.ToolStripButton btn_imprimir;
        internal System.Windows.Forms.TextBox txtdcosto;
        internal System.Windows.Forms.TextBox txtccosto;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.TextBox txtdcargo;
        internal System.Windows.Forms.TextBox txtccargo;
        internal System.Windows.Forms.Label Label28;
        private System.Windows.Forms.GroupBox gpbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}