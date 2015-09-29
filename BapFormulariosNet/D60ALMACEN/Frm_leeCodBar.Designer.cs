
namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_leeCodBar
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
            this.label1 = new System.Windows.Forms.Label();
            this.CODBAR = new System.Windows.Forms.TextBox();
            this.btnok = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btniniciar = new System.Windows.Forms.Button();
            this.btndetener = new System.Windows.Forms.Button();
            this.items = new System.Windows.Forms.TextBox();
            this.dgbcodbar = new System.Windows.Forms.DataGridView();
            this.Rollo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbpuerto = new System.Windows.Forms.ComboBox();
            this.cmbbaudios = new System.Windows.Forms.ComboBox();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgbcodbar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CodBar:";
            // 
            // CODBAR
            // 
            this.CODBAR.Location = new System.Drawing.Point(104, 24);
            this.CODBAR.Name = "CODBAR";
            this.CODBAR.Size = new System.Drawing.Size(121, 21);
            this.CODBAR.TabIndex = 1;
            this.CODBAR.TextChanged += new System.EventHandler(this.CODBAR_TextChanged);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(9, 8);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(9, 37);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Cancelar";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Puerto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Baudios:";
            // 
            // btniniciar
            // 
            this.btniniciar.Location = new System.Drawing.Point(9, 196);
            this.btniniciar.Name = "btniniciar";
            this.btniniciar.Size = new System.Drawing.Size(75, 23);
            this.btniniciar.TabIndex = 10;
            this.btniniciar.Text = "Iniciar";
            this.btniniciar.UseVisualStyleBackColor = true;
            this.btniniciar.Click += new System.EventHandler(this.btniniciar_Click);
            // 
            // btndetener
            // 
            this.btndetener.Location = new System.Drawing.Point(9, 225);
            this.btndetener.Name = "btndetener";
            this.btndetener.Size = new System.Drawing.Size(75, 23);
            this.btndetener.TabIndex = 11;
            this.btndetener.Text = "Detener";
            this.btndetener.UseVisualStyleBackColor = true;
            this.btndetener.Click += new System.EventHandler(this.btndetener_Click);
            // 
            // items
            // 
            this.items.Location = new System.Drawing.Point(172, 206);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(75, 21);
            this.items.TabIndex = 12;
            this.items.Text = "0";
            // 
            // dgbcodbar
            // 
            this.dgbcodbar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbcodbar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rollo,
            this.Medida});
            this.dgbcodbar.Location = new System.Drawing.Point(15, 48);
            this.dgbcodbar.Name = "dgbcodbar";
            this.dgbcodbar.Size = new System.Drawing.Size(245, 150);
            this.dgbcodbar.TabIndex = 13;
            // 
            // Rollo
            // 
            this.Rollo.HeaderText = "Rollo";
            this.Rollo.Name = "Rollo";
            // 
            // Medida
            // 
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Total Items:";
            // 
            // cmbpuerto
            // 
            this.cmbpuerto.FormattingEnabled = true;
            this.cmbpuerto.Items.AddRange(new object[] {
            "Com1",
            "Com2",
            "Com3",
            "Com4",
            "Com5",
            "Com6",
            "Com7",
            "Com8",
            "Com9",
            "Com10",
            "Com11",
            "Com12",
            "Com13",
            "Com14",
            "15 Com15",
            "16 Com16"});
            this.cmbpuerto.Location = new System.Drawing.Point(104, 229);
            this.cmbpuerto.Name = "cmbpuerto";
            this.cmbpuerto.Size = new System.Drawing.Size(121, 21);
            this.cmbpuerto.TabIndex = 15;
            // 
            // cmbbaudios
            // 
            this.cmbbaudios.FormattingEnabled = true;
            this.cmbbaudios.Items.AddRange(new object[] {
            "      110",
            "      300",
            "      600",
            "    1200",
            "    2400",
            "    9600",
            "  14400",
            "  19200",
            "  28800",
            "  38400",
            "  56000",
            "128000",
            "256000"});
            this.cmbbaudios.Location = new System.Drawing.Point(104, 258);
            this.cmbbaudios.Name = "cmbbaudios";
            this.cmbbaudios.Size = new System.Drawing.Size(121, 21);
            this.cmbbaudios.TabIndex = 16;
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(9, 92);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(75, 41);
            this.btnlimpiar.TabIndex = 21;
            this.btnlimpiar.Text = "Limpiar Lecturas";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(369, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(175, 173);
            this.listBox1.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BapFormulariosNet.Properties.Resources.bannerblue3;
            this.panel1.Controls.Add(this.btnok);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnlimpiar);
            this.panel1.Controls.Add(this.btniniciar);
            this.panel1.Controls.Add(this.btndetener);
            this.panel1.Location = new System.Drawing.Point(266, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 255);
            this.panel1.TabIndex = 23;
            // 
            // Frm_leeCodBar
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 285);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cmbbaudios);
            this.Controls.Add(this.cmbpuerto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgbcodbar);
            this.Controls.Add(this.items);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CODBAR);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Frm_leeCodBar";
            this.Text = "Codigo_Barras";
            this.Load += new System.EventHandler(this.Frm_leeCodBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgbcodbar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CODBAR;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btniniciar;
        private System.Windows.Forms.Button btndetener;
        private System.Windows.Forms.TextBox items;
        private System.Windows.Forms.DataGridView dgbcodbar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbpuerto;
        private System.Windows.Forms.ComboBox cmbbaudios;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rollo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.Panel panel1;
    }
}