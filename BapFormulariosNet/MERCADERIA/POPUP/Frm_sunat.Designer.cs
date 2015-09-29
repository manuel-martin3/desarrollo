namespace BapFormulariosNet.MERCADERIA.POPUP
{
    partial class Frm_sunat
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
            this.label30 = new System.Windows.Forms.Label();
            this.txtCapcha = new System.Windows.Forms.TextBox();
            this.pictureCapcha = new System.Windows.Forms.PictureBox();
            this.cmdReloadCapcha = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label2 = new System.Windows.Forms.Label();
            this.btnextraersunat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(148, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "»»»";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Location = new System.Drawing.Point(6, 26);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(163, 13);
            this.label30.TabIndex = 56;
            this.label30.Text = "Ingrese caracteres de la Imagen";
            // 
            // txtCapcha
            // 
            this.txtCapcha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCapcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapcha.Location = new System.Drawing.Point(12, 44);
            this.txtCapcha.MaxLength = 8;
            this.txtCapcha.Name = "txtCapcha";
            this.txtCapcha.Size = new System.Drawing.Size(130, 35);
            this.txtCapcha.TabIndex = 57;
            this.txtCapcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureCapcha
            // 
            this.pictureCapcha.Location = new System.Drawing.Point(12, 80);
            this.pictureCapcha.Name = "pictureCapcha";
            this.pictureCapcha.Size = new System.Drawing.Size(130, 40);
            this.pictureCapcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCapcha.TabIndex = 54;
            this.pictureCapcha.TabStop = false;
            // 
            // cmdReloadCapcha
            // 
            this.cmdReloadCapcha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdReloadCapcha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdReloadCapcha.Image = global::BapFormulariosNet.Properties.Resources.actualizar;
            this.cmdReloadCapcha.Location = new System.Drawing.Point(150, 84);
            this.cmdReloadCapcha.Name = "cmdReloadCapcha";
            this.cmdReloadCapcha.Size = new System.Drawing.Size(35, 30);
            this.cmdReloadCapcha.TabIndex = 55;
            this.cmdReloadCapcha.TabStop = false;
            this.cmdReloadCapcha.UseVisualStyleBackColor = false;
            this.cmdReloadCapcha.Click += new System.EventHandler(this.cmdReloadCapcha_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(344, 123);
            this.shapeContainer1.TabIndex = 94;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 2;
            this.lineShape1.X2 = 212;
            this.lineShape1.Y1 = 21;
            this.lineShape1.Y2 = 21;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(-3, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 10);
            this.label2.TabIndex = 97;
            // 
            // btnextraersunat
            // 
            this.btnextraersunat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnextraersunat.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnextraersunat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnextraersunat.Image = global::BapFormulariosNet.Properties.Resources.sunat1;
            this.btnextraersunat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnextraersunat.Location = new System.Drawing.Point(179, 44);
            this.btnextraersunat.Name = "btnextraersunat";
            this.btnextraersunat.Size = new System.Drawing.Size(162, 35);
            this.btnextraersunat.TabIndex = 101;
            this.btnextraersunat.ToolTip = "Extrae Datos";
            this.btnextraersunat.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnextraersunat.Click += new System.EventHandler(this.btnextraersunat_Click);
            // 
            // Frm_sunat
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 123);
            this.Controls.Add(this.btnextraersunat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtCapcha);
            this.Controls.Add(this.pictureCapcha);
            this.Controls.Add(this.cmdReloadCapcha);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_sunat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Consultar Sunat";
            this.Load += new System.EventHandler(this.Frm_reniec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCapcha;
        internal System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button cmdReloadCapcha;
        private System.Windows.Forms.PictureBox pictureCapcha;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnextraersunat;
    }
}