namespace BapFormulariosNet.Seguridadlog
{
    partial class Frm_SeleccionImagen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SeleccionImagen));
            this.Label1 = new System.Windows.Forms.Label();
            this.OFDFoto = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAjuntarFoto = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.PicturePrenda = new System.Windows.Forms.PictureBox();
            this.txtImagen = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePrenda)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Ruta de Imagen";
            // 
            // OFDFoto
            // 
            this.OFDFoto.FileName = "OpenFileDialog1";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnGrabar);
            this.GroupBox1.Controls.Add(this.btnAjuntarFoto);
            this.GroupBox1.Controls.Add(this.btnEliminar);
            this.GroupBox1.Location = new System.Drawing.Point(12, 275);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(324, 49);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            // 
            // btnAjuntarFoto
            // 
            this.btnAjuntarFoto.Image = global::BapFormulariosNet.Properties.Resources.btn_signup20;
            this.btnAjuntarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjuntarFoto.Location = new System.Drawing.Point(6, 11);
            this.btnAjuntarFoto.Name = "btnAjuntarFoto";
            this.btnAjuntarFoto.Size = new System.Drawing.Size(108, 32);
            this.btnAjuntarFoto.TabIndex = 0;
            this.btnAjuntarFoto.Text = "     Adjuntar Imagen";
            this.btnAjuntarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAjuntarFoto.UseVisualStyleBackColor = true;
            this.btnAjuntarFoto.Click += new System.EventHandler(this.btnAjuntarFoto_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::BapFormulariosNet.Properties.Resources.btn_del;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(117, 11);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(108, 32);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "     Elimina Imagen";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // PicturePrenda
            // 
            this.PicturePrenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicturePrenda.Location = new System.Drawing.Point(13, 53);
            this.PicturePrenda.Name = "PicturePrenda";
            this.PicturePrenda.Size = new System.Drawing.Size(323, 221);
            this.PicturePrenda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicturePrenda.TabIndex = 5;
            this.PicturePrenda.TabStop = false;
            // 
            // txtImagen
            // 
            this.txtImagen.Location = new System.Drawing.Point(13, 26);
            this.txtImagen.Name = "txtImagen";
            this.txtImagen.ReadOnly = true;
            this.txtImagen.Size = new System.Drawing.Size(323, 20);
            this.txtImagen.TabIndex = 1;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = global::BapFormulariosNet.Properties.Resources.btn_grabar20;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(228, 11);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(90, 32);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "&Grabar     ";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // Frm_SeleccionImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 332);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PicturePrenda);
            this.Controls.Add(this.txtImagen);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_SeleccionImagen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_SeleccionImagen";
            this.Load += new System.EventHandler(this.Frm_SeleccionImagen_Load);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicturePrenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.OpenFileDialog OFDFoto;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnAjuntarFoto;
        internal System.Windows.Forms.Button btnEliminar;
        internal System.Windows.Forms.PictureBox PicturePrenda;
        internal System.Windows.Forms.TextBox txtImagen;
        internal System.Windows.Forms.Button btnGrabar;
    }
}