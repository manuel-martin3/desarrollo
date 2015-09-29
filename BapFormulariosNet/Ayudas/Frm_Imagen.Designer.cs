namespace BapFormulariosNet.Ayudas
{
    partial class Frm_Imagen
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
            this.go_foto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.go_foto)).BeginInit();
            this.SuspendLayout();
            // 
            // go_foto
            // 
            this.go_foto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.go_foto.ErrorImage = global::BapFormulariosNet.Properties.Resources.error;
            this.go_foto.InitialImage = global::BapFormulariosNet.Properties.Resources.error;
            this.go_foto.Location = new System.Drawing.Point(2, 3);
            this.go_foto.Name = "go_foto";
            this.go_foto.Size = new System.Drawing.Size(268, 249);
            this.go_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.go_foto.TabIndex = 64;
            this.go_foto.TabStop = false;
            // 
            // Frm_Imagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 254);
            this.Controls.Add(this.go_foto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_Imagen";
            this.Text = "---- Imagen ----";
            this.Load += new System.EventHandler(this.Frm_Imagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.go_foto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox go_foto;

    }
}