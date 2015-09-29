namespace BapFormulariosNet.Ayudas
{
    partial class Form_Edicion
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
            this.editproducto = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.editprod_cab = new System.Windows.Forms.TextBox();
            this.btn_clean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editproducto
            // 
            this.editproducto.Location = new System.Drawing.Point(8, 58);
            this.editproducto.Multiline = true;
            this.editproducto.Name = "editproducto";
            this.editproducto.Size = new System.Drawing.Size(306, 82);
            this.editproducto.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Image = global::BapFormulariosNet.Properties.Resources.btn_cancel;
            this.btn_cancel.Location = new System.Drawing.Point(361, 60);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(46, 30);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.Image = global::BapFormulariosNet.Properties.Resources.btn_save;
            this.btn_agregar.Location = new System.Drawing.Point(337, 106);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(46, 29);
            this.btn_agregar.TabIndex = 2;
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // editprod_cab
            // 
            this.editprod_cab.Enabled = false;
            this.editprod_cab.Location = new System.Drawing.Point(8, 13);
            this.editprod_cab.Name = "editprod_cab";
            this.editprod_cab.Size = new System.Drawing.Size(311, 20);
            this.editprod_cab.TabIndex = 3;
            // 
            // btn_clean
            // 
            this.btn_clean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clean.Image = global::BapFormulariosNet.Properties.Resources.btn_clean;
            this.btn_clean.Location = new System.Drawing.Point(316, 60);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(46, 29);
            this.btn_clean.TabIndex = 4;
            this.btn_clean.UseVisualStyleBackColor = true;
            this.btn_clean.Click += new System.EventHandler(this.btn_clean_Click);
            // 
            // Form_Edicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(409, 152);
            this.ControlBox = false;
            this.Controls.Add(this.btn_clean);
            this.Controls.Add(this.editprod_cab);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.editproducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Edicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.Form_Edicion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox editproducto;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.TextBox editprod_cab;
        private System.Windows.Forms.Button btn_clean;
    }
}