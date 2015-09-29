namespace BapFormulariosNet.D60ALMACEN.PROCESOS
{
    partial class Frm_ajuste_codigo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ajuste_codigo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.btn_process = new System.Windows.Forms.ToolStripButton();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lineaname = new System.Windows.Forms.TextBox();
            this.lineaid = new System.Windows.Forms.TextBox();
            this.grupoid = new System.Windows.Forms.TextBox();
            this.subgrupoid = new System.Windows.Forms.TextBox();
            this.gruponame = new System.Windows.Forms.TextBox();
            this.productid = new System.Windows.Forms.TextBox();
            this.subgruponame = new System.Windows.Forms.TextBox();
            this.productname = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.grupoid2 = new System.Windows.Forms.TextBox();
            this.subgrupoid2 = new System.Windows.Forms.TextBox();
            this.gruponame2 = new System.Windows.Forms.TextBox();
            this.subgruponame2 = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.productid2 = new System.Windows.Forms.TextBox();
            this.productname2 = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 38);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(7, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "AJUSTE DE CODIGO";
            // 
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.btn_process,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(511, 29);
            this.Botonera.TabIndex = 13;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = global::BapFormulariosNet.Properties.Resources.go_new3;
            this.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(23, 26);
            this.btn_nuevo.Text = "toolStripButton1";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_process
            // 
            this.btn_process.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_process.Image = global::BapFormulariosNet.Properties.Resources.go_Check_g;
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
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 144);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Producto:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Linea:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Grupo:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 120);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(50, 13);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Subgrupo:";
            // 
            // lineaname
            // 
            this.lineaname.Location = new System.Drawing.Point(115, 73);
            this.lineaname.Name = "lineaname";
            this.lineaname.Size = new System.Drawing.Size(355, 21);
            this.lineaname.TabIndex = 22;
            this.lineaname.Text = "ventas al exterior";
            // 
            // lineaid
            // 
            this.lineaid.Location = new System.Drawing.Point(66, 73);
            this.lineaid.MaxLength = 3;
            this.lineaid.Name = "lineaid";
            this.lineaid.Size = new System.Drawing.Size(48, 21);
            this.lineaid.TabIndex = 21;
            this.lineaid.Text = "ventas al exterior";
            // 
            // grupoid
            // 
            this.grupoid.Location = new System.Drawing.Point(66, 95);
            this.grupoid.MaxLength = 4;
            this.grupoid.Name = "grupoid";
            this.grupoid.Size = new System.Drawing.Size(48, 21);
            this.grupoid.TabIndex = 23;
            this.grupoid.Text = "ventas al exterior";
            // 
            // subgrupoid
            // 
            this.subgrupoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subgrupoid.Location = new System.Drawing.Point(67, 117);
            this.subgrupoid.MaxLength = 3;
            this.subgrupoid.Name = "subgrupoid";
            this.subgrupoid.Size = new System.Drawing.Size(47, 20);
            this.subgrupoid.TabIndex = 25;
            this.subgrupoid.Text = "ventas al exterior";
            // 
            // gruponame
            // 
            this.gruponame.Location = new System.Drawing.Point(115, 95);
            this.gruponame.Name = "gruponame";
            this.gruponame.Size = new System.Drawing.Size(355, 21);
            this.gruponame.TabIndex = 24;
            this.gruponame.Text = "ventas al exterior";
            // 
            // productid
            // 
            this.productid.Location = new System.Drawing.Point(67, 140);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(83, 21);
            this.productid.TabIndex = 27;
            this.productid.Text = "ventas al exterior";
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // subgruponame
            // 
            this.subgruponame.Location = new System.Drawing.Point(115, 117);
            this.subgruponame.Name = "subgruponame";
            this.subgruponame.Size = new System.Drawing.Size(355, 21);
            this.subgruponame.TabIndex = 26;
            this.subgruponame.Text = "ventas al exterior";
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(151, 140);
            this.productname.Name = "productname";
            this.productname.Size = new System.Drawing.Size(319, 21);
            this.productname.TabIndex = 28;
            this.productname.Text = "ventas al exterior";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Location = new System.Drawing.Point(0, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 27);
            this.panel2.TabIndex = 29;
            // 
            // btn_add
            // 
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_add.Location = new System.Drawing.Point(474, 130);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(33, 31);
            this.btn_add.TabIndex = 30;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new System.Drawing.Point(476, 228);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(33, 31);
            this.simpleButton2.TabIndex = 31;
            // 
            // grupoid2
            // 
            this.grupoid2.Location = new System.Drawing.Point(66, 195);
            this.grupoid2.MaxLength = 4;
            this.grupoid2.Name = "grupoid2";
            this.grupoid2.Size = new System.Drawing.Size(48, 21);
            this.grupoid2.TabIndex = 34;
            this.grupoid2.Text = "ventas al exterior";
            // 
            // subgrupoid2
            // 
            this.subgrupoid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subgrupoid2.Location = new System.Drawing.Point(67, 217);
            this.subgrupoid2.MaxLength = 3;
            this.subgrupoid2.Name = "subgrupoid2";
            this.subgrupoid2.Size = new System.Drawing.Size(47, 20);
            this.subgrupoid2.TabIndex = 36;
            this.subgrupoid2.Text = "ventas al exterior";
            // 
            // gruponame2
            // 
            this.gruponame2.Location = new System.Drawing.Point(115, 195);
            this.gruponame2.Name = "gruponame2";
            this.gruponame2.Size = new System.Drawing.Size(355, 21);
            this.gruponame2.TabIndex = 35;
            this.gruponame2.Text = "ventas al exterior";
            // 
            // subgruponame2
            // 
            this.subgruponame2.Location = new System.Drawing.Point(115, 217);
            this.subgruponame2.Name = "subgruponame2";
            this.subgruponame2.Size = new System.Drawing.Size(355, 21);
            this.subgruponame2.TabIndex = 37;
            this.subgruponame2.Text = "ventas al exterior";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 220);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 13);
            this.labelControl5.TabIndex = 33;
            this.labelControl5.Text = "Subgrupo:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 197);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Grupo:";
            // 
            // productid2
            // 
            this.productid2.Location = new System.Drawing.Point(67, 238);
            this.productid2.MaxLength = 13;
            this.productid2.Name = "productid2";
            this.productid2.Size = new System.Drawing.Size(83, 21);
            this.productid2.TabIndex = 39;
            this.productid2.Text = "ventas al exterior";
            // 
            // productname2
            // 
            this.productname2.Location = new System.Drawing.Point(151, 238);
            this.productname2.Name = "productname2";
            this.productname2.Size = new System.Drawing.Size(319, 21);
            this.productname2.TabIndex = 40;
            this.productname2.Text = "ventas al exterior";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 242);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 13);
            this.labelControl7.TabIndex = 38;
            this.labelControl7.Text = "Producto:";
            // 
            // Frm_ajuste_codigo
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(511, 264);
            this.Controls.Add(this.productid2);
            this.Controls.Add(this.productname2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.grupoid2);
            this.Controls.Add(this.subgrupoid2);
            this.Controls.Add(this.gruponame2);
            this.Controls.Add(this.subgruponame2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lineaname);
            this.Controls.Add(this.lineaid);
            this.Controls.Add(this.grupoid);
            this.Controls.Add(this.subgrupoid);
            this.Controls.Add(this.gruponame);
            this.Controls.Add(this.productid);
            this.Controls.Add(this.subgruponame);
            this.Controls.Add(this.productname);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Botonera);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_ajuste_codigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "...::  Ajuste de Codigo ::...";
            this.Load += new System.EventHandler(this.Frm_ajuste_codigo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ToolStrip Botonera;
        private System.Windows.Forms.ToolStripButton btn_process;
        private System.Windows.Forms.ToolStripButton btn_salir;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        internal System.Windows.Forms.TextBox lineaname;
        internal System.Windows.Forms.TextBox lineaid;
        internal System.Windows.Forms.TextBox grupoid;
        internal System.Windows.Forms.TextBox subgrupoid;
        internal System.Windows.Forms.TextBox gruponame;
        internal System.Windows.Forms.TextBox productid;
        internal System.Windows.Forms.TextBox subgruponame;
        internal System.Windows.Forms.TextBox productname;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        internal System.Windows.Forms.TextBox grupoid2;
        internal System.Windows.Forms.TextBox subgrupoid2;
        internal System.Windows.Forms.TextBox gruponame2;
        internal System.Windows.Forms.TextBox subgruponame2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        internal System.Windows.Forms.TextBox productid2;
        internal System.Windows.Forms.TextBox productname2;
        private DevExpress.XtraEditors.LabelControl labelControl7;

    }
}