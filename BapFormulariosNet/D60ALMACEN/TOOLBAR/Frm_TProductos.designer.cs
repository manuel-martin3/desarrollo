namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_TProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TProductos));
            this.prov = new System.Windows.Forms.TextBox();
            this.comp = new System.Windows.Forms.TextBox();
            this.titu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stock = new System.Windows.Forms.TextBox();
            this.productname = new System.Windows.Forms.TextBox();
            this.productid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.Botonera = new System.Windows.Forms.ToolStrip();
            this.btn_nuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_salir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Botonera.SuspendLayout();
            this.SuspendLayout();
            // 
            // prov
            // 
            this.prov.Location = new System.Drawing.Point(94, 87);
            this.prov.Name = "prov";
            this.prov.ReadOnly = true;
            this.prov.Size = new System.Drawing.Size(354, 21);
            this.prov.TabIndex = 44;
            this.prov.Text = "ventas al exterior";
            this.prov.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prov_KeyDown);
            this.prov.MouseDown += new System.Windows.Forms.MouseEventHandler(this.prov_MouseDown);
            // 
            // comp
            // 
            this.comp.Location = new System.Drawing.Point(94, 67);
            this.comp.Name = "comp";
            this.comp.ReadOnly = true;
            this.comp.Size = new System.Drawing.Size(263, 21);
            this.comp.TabIndex = 43;
            this.comp.Text = "ventas al exterior";
            this.comp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comp_KeyDown);
            this.comp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comp_MouseDown);
            // 
            // titu
            // 
            this.titu.Location = new System.Drawing.Point(94, 44);
            this.titu.Name = "titu";
            this.titu.ReadOnly = true;
            this.titu.Size = new System.Drawing.Size(191, 21);
            this.titu.TabIndex = 42;
            this.titu.Text = "ventas al exterior";
            this.titu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.titu_KeyDown);
            this.titu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titu_MouseDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(21, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Proveedor:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Composición:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Título / Onz:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.stock);
            this.groupBox1.Controls.Add(this.prov);
            this.groupBox1.Controls.Add(this.comp);
            this.groupBox1.Controls.Add(this.titu);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.productname);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.productid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 136);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Stock:";
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(94, 110);
            this.stock.MaxLength = 50000;
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            this.stock.Size = new System.Drawing.Size(83, 21);
            this.stock.TabIndex = 45;
            this.stock.Text = "ventas al exterior";
            this.stock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stock_KeyDown);
            this.stock.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stock_MouseDown);
            // 
            // productname
            // 
            this.productname.Location = new System.Drawing.Point(180, 18);
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            this.productname.Size = new System.Drawing.Size(317, 21);
            this.productname.TabIndex = 17;
            this.productname.Text = "ventas al exterior";
            this.productname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productname_KeyDown);
            this.productname.MouseDown += new System.Windows.Forms.MouseEventHandler(this.productname_MouseDown);
            // 
            // productid
            // 
            this.productid.Location = new System.Drawing.Point(94, 18);
            this.productid.MaxLength = 13;
            this.productid.Name = "productid";
            this.productid.Size = new System.Drawing.Size(83, 21);
            this.productid.TabIndex = 16;
            this.productid.Text = "ventas al exterior";
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            this.productid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.productid_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Producto:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 25);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(205, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "PRODUCTO";
            // 
            // Botonera
            // 
            this.Botonera.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Botonera.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.Botonera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_nuevo,
            this.toolStripSeparator1,
            this.btn_salir});
            this.Botonera.Location = new System.Drawing.Point(0, 0);
            this.Botonera.Name = "Botonera";
            this.Botonera.Size = new System.Drawing.Size(514, 27);
            this.Botonera.TabIndex = 1;
            this.Botonera.Text = "ToolStrip1";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_nuevo.Image = global::BapFormulariosNet.Properties.Resources.go_new3;
            this.btn_nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_nuevo.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(23, 24);
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btn_salir
            // 
            this.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_salir.Image = global::BapFormulariosNet.Properties.Resources.go_out2;
            this.btn_salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(24, 24);
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // Frm_TProductos
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(514, 196);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Botonera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_TProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR PRODUCTOS";
            this.Load += new System.EventHandler(this.Frm_TProductos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_TProductos_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Botonera.ResumeLayout(false);
            this.Botonera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripButton btn_nuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_salir;
        internal System.Windows.Forms.ToolStrip Botonera;
        internal System.Windows.Forms.TextBox productname;
        internal System.Windows.Forms.TextBox productid;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox prov;
        internal System.Windows.Forms.TextBox comp;
        internal System.Windows.Forms.TextBox titu;
        internal System.Windows.Forms.TextBox stock;
        internal System.Windows.Forms.Label label2;

    }
}