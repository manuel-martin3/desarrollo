namespace BapFormulariosNet.Ayudas
{
    partial class Form_user_admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_user_admin));
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_clave = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.txt_glosa = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(29, 37);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(144, 20);
            this.txt_usuario.TabIndex = 1;
            this.txt_usuario.Text = "marco antonio bendezu cusi";
            this.txt_usuario.UseSystemPasswordChar = true;
            this.txt_usuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_usuario_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(6, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(69, 17);
            this.label23.TabIndex = 22;
            this.label23.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Clave:";
            // 
            // txt_clave
            // 
            this.txt_clave.Location = new System.Drawing.Point(29, 83);
            this.txt_clave.Name = "txt_clave";
            this.txt_clave.Size = new System.Drawing.Size(144, 20);
            this.txt_clave.TabIndex = 2;
            this.txt_clave.Text = "marco antonio bendezu cusi";
            this.txt_clave.UseSystemPasswordChar = true;
            this.txt_clave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_clave_KeyDown);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.White;
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Image = global::BapFormulariosNet.Properties.Resources.go_Check_g;
            this.btn_login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_login.Location = new System.Drawing.Point(11, 111);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(69, 33);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "&Login";
            this.btn_login.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.White;
            this.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_cancelar.Image = global::BapFormulariosNet.Properties.Resources.undo_24;
            this.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancelar.Location = new System.Drawing.Point(90, 112);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(85, 32);
            this.btn_cancelar.TabIndex = 5;
            this.btn_cancelar.Text = "&Cancelar";
            this.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // txt_glosa
            // 
            this.txt_glosa.Location = new System.Drawing.Point(359, 210);
            this.txt_glosa.Multiline = true;
            this.txt_glosa.Name = "txt_glosa";
            this.txt_glosa.Size = new System.Drawing.Size(206, 46);
            this.txt_glosa.TabIndex = 4;
            this.txt_glosa.Text = "Xdhugo1436";
            this.txt_glosa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_glosa_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImage = global::BapFormulariosNet.Properties.Resources.img_seg;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_usuario);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Controls.Add(this.txt_clave);
            this.panel1.Location = new System.Drawing.Point(0, -13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 154);
            this.panel1.TabIndex = 25;
            // 
            // Form_user_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 138);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_glosa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_user_admin";
            this.Opacity = 0.95D;
            this.Text = "»» Administrar Permisos";
            this.Load += new System.EventHandler(this.Form_user_admin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_user_admin_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_usuario;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txt_clave;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_cancelar;
        internal System.Windows.Forms.TextBox txt_glosa;
        private System.Windows.Forms.Panel panel1;
    }
}