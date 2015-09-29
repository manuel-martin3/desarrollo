namespace BapFormulariosNet.AYUDA
{
    partial class Frm_VerImagen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_VerImagen));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarimagen = new System.Windows.Forms.Button();
            this.btnQuitarimagen = new System.Windows.Forms.Button();
            this.MuestraImagen = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MuestraImagen)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnAgregarimagen);
            this.GroupBox1.Controls.Add(this.btnQuitarimagen);
            this.GroupBox1.Location = new System.Drawing.Point(12, 7);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(234, 51);
            this.GroupBox1.TabIndex = 8;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Operaciones Imágenes en Base de Datos";
            // 
            // btnAgregarimagen
            // 
            this.btnAgregarimagen.Location = new System.Drawing.Point(13, 19);
            this.btnAgregarimagen.Name = "btnAgregarimagen";
            this.btnAgregarimagen.Size = new System.Drawing.Size(94, 24);
            this.btnAgregarimagen.TabIndex = 0;
            this.btnAgregarimagen.Text = "&Agregar Imagen";
            this.btnAgregarimagen.UseVisualStyleBackColor = true;
            this.btnAgregarimagen.Click += new System.EventHandler(this.btnAgregarimagen_Click);
            // 
            // btnQuitarimagen
            // 
            this.btnQuitarimagen.Location = new System.Drawing.Point(116, 19);
            this.btnQuitarimagen.Name = "btnQuitarimagen";
            this.btnQuitarimagen.Size = new System.Drawing.Size(94, 24);
            this.btnQuitarimagen.TabIndex = 3;
            this.btnQuitarimagen.Text = "&Quitar Imagen";
            this.btnQuitarimagen.UseVisualStyleBackColor = true;
            this.btnQuitarimagen.Click += new System.EventHandler(this.btnQuitarimagen_Click);
            // 
            // MuestraImagen
            // 
            this.MuestraImagen.Location = new System.Drawing.Point(12, 64);
            this.MuestraImagen.Name = "MuestraImagen";
            this.MuestraImagen.Size = new System.Drawing.Size(461, 343);
            this.MuestraImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MuestraImagen.TabIndex = 5;
            this.MuestraImagen.TabStop = false;
            this.MuestraImagen.DoubleClick += new System.EventHandler(this.MuestraImagen_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Location = new System.Drawing.Point(295, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 51);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::BapFormulariosNet.Properties.Resources.Cancela16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(92, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 27);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::BapFormulariosNet.Properties.Resources.Acepta16;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(10, 15);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(76, 27);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Frm_VerImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 420);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.MuestraImagen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_VerImagen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_VerImagen";
            this.Load += new System.EventHandler(this.Frm_VerImagen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_VerImagen_KeyDown);
            this.Resize += new System.EventHandler(this.Frm_VerImagen_Resize);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MuestraImagen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnAgregarimagen;
        internal System.Windows.Forms.Button btnQuitarimagen;
        internal System.Windows.Forms.PictureBox MuestraImagen;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAceptar;
    }
}