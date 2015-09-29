namespace BapFormulariosNet.D20Comercial.Ayudas
{
    partial class Frm_AyudaBuscarregistrocompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AyudaBuscarregistrocompras));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cboTipdoc = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtCtactename = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.txtNumero);
            this.GroupBox1.Controls.Add(this.cboTipdoc);
            this.GroupBox1.Controls.Add(this.Label25);
            this.GroupBox1.Controls.Add(this.txtSerie);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtCtactename);
            this.GroupBox1.Controls.Add(this.txtRuc);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Location = new System.Drawing.Point(6, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(611, 75);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label17.Location = new System.Drawing.Point(4, 21);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(72, 13);
            this.Label17.TabIndex = 9;
            this.Label17.Text = "Comprobante";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(415, 17);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(80, 21);
            this.txtNumero.TabIndex = 14;
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            // 
            // cboTipdoc
            // 
            this.cboTipdoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipdoc.DropDownWidth = 380;
            this.cboTipdoc.FormattingEnabled = true;
            this.cboTipdoc.IntegralHeight = false;
            this.cboTipdoc.Location = new System.Drawing.Point(77, 17);
            this.cboTipdoc.Name = "cboTipdoc";
            this.cboTipdoc.Size = new System.Drawing.Size(204, 21);
            this.cboTipdoc.TabIndex = 10;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label25.Location = new System.Drawing.Point(369, 21);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(44, 13);
            this.Label25.TabIndex = 13;
            this.Label25.Text = "Número";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(321, 17);
            this.txtSerie.MaxLength = 4;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(43, 21);
            this.txtSerie.TabIndex = 12;
            this.txtSerie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerie_KeyDown);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(288, 21);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(31, 13);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Serie";
            // 
            // txtCtactename
            // 
            this.txtCtactename.Enabled = false;
            this.txtCtactename.Location = new System.Drawing.Point(167, 43);
            this.txtCtactename.Name = "txtCtactename";
            this.txtCtactename.Size = new System.Drawing.Size(436, 21);
            this.txtCtactename.TabIndex = 17;
            // 
            // txtRuc
            // 
            this.txtRuc.Enabled = false;
            this.txtRuc.Location = new System.Drawing.Point(77, 43);
            this.txtRuc.MaxLength = 11;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(88, 21);
            this.txtRuc.TabIndex = 16;
            this.txtRuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRuc_KeyDown);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(19, 47);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(55, 13);
            this.Label5.TabIndex = 15;
            this.Label5.Text = "Cód.-RUC";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btnCancelar);
            this.GroupBox4.Controls.Add(this.btnAceptar);
            this.GroupBox4.Location = new System.Drawing.Point(196, 82);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(181, 43);
            this.GroupBox4.TabIndex = 13;
            this.GroupBox4.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(97, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 25);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(7, 13);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(76, 25);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar ";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Frm_AyudaBuscarregistrocompras
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 130);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AyudaBuscarregistrocompras";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "<< Ayuda Buscar Registro o Comprobante del Registro de Compras >>";
            this.Activated += new System.EventHandler(this.Frm_AyudaBuscarregistrocompras_Activated);
            this.Load += new System.EventHandler(this.Frm_AyudaBuscarregistrocompras_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.TextBox txtNumero;
        internal System.Windows.Forms.ComboBox cboTipdoc;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.TextBox txtSerie;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtCtactename;
        internal System.Windows.Forms.TextBox txtRuc;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAceptar;
    }
}