namespace BapFormulariosNet.D60ALMACEN.POPUP
{
    partial class Frm_CargaRollo
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
            this.rollodesde = new System.Windows.Forms.TextBox();
            this.rollohasta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkActivar = new DevExpress.XtraEditors.CheckEdit();
            this.precio = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Rollo Hasta:";
            // 
            // rollodesde
            // 
            this.rollodesde.Location = new System.Drawing.Point(92, 11);
            this.rollodesde.MaxLength = 10;
            this.rollodesde.Name = "rollodesde";
            this.rollodesde.Size = new System.Drawing.Size(100, 20);
            this.rollodesde.TabIndex = 50;
            this.rollodesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollodesde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rollodesde_KeyDown);
            // 
            // rollohasta
            // 
            this.rollohasta.Location = new System.Drawing.Point(92, 32);
            this.rollohasta.MaxLength = 10;
            this.rollohasta.Name = "rollohasta";
            this.rollohasta.Size = new System.Drawing.Size(100, 20);
            this.rollohasta.TabIndex = 51;
            this.rollohasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollohasta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rollohasta_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Rollo Desde:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.chkActivar);
            this.panel1.Controls.Add(this.precio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.rollodesde);
            this.panel1.Controls.Add(this.rollohasta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 63);
            this.panel1.TabIndex = 54;
            // 
            // chkActivar
            // 
            this.chkActivar.Location = new System.Drawing.Point(205, 7);
            this.chkActivar.Name = "chkActivar";
            this.chkActivar.Properties.Caption = "&Activar";
            this.chkActivar.Size = new System.Drawing.Size(75, 19);
            this.chkActivar.TabIndex = 58;
            this.chkActivar.CheckedChanged += new System.EventHandler(this.chkActivar_CheckedChanged);
            // 
            // precio
            // 
            this.precio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precio.Location = new System.Drawing.Point(249, 32);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(75, 20);
            this.precio.TabIndex = 56;
            this.precio.Text = "0.00";
            this.precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.precio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.precio_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(200, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 55;
            this.label20.Text = "Precio:";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregar.Image = global::BapFormulariosNet.Properties.Resources.go_Check_g;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(341, 17);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(49, 31);
            this.BtnAgregar.TabIndex = 54;
            this.BtnAgregar.Text = "&Ok";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // Frm_CargaRollo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 64);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_CargaRollo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Cargar Rollo ««";
            this.Load += new System.EventHandler(this.Frm_CargaRollo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox rollodesde;
        internal System.Windows.Forms.TextBox rollohasta;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAgregar;
        internal System.Windows.Forms.TextBox precio;
        internal System.Windows.Forms.Label label20;
        private DevExpress.XtraEditors.CheckEdit chkActivar;
    }
}