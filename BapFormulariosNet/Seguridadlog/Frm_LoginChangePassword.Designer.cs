namespace BapFormulariosNet.Seguridadlog
{
    partial class Frm_LoginChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LoginChangePassword));
            this.lblUserName = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.clave_nuevo2 = new System.Windows.Forms.TextBox();
            this.clave_nuevo = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.clave = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUserName.Location = new System.Drawing.Point(14, 26);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(291, 23);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(19, 6);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 16);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Usuario :";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.button1);
            this.GroupBox3.Controls.Add(this.btnCancel);
            this.GroupBox3.Controls.Add(this.btnAceptar);
            this.GroupBox3.Location = new System.Drawing.Point(14, 193);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(291, 47);
            this.GroupBox3.TabIndex = 7;
            this.GroupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(100, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(7, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 29);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.clave_nuevo2);
            this.GroupBox2.Controls.Add(this.clave_nuevo);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Location = new System.Drawing.Point(14, 104);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(291, 81);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            // 
            // clave_nuevo2
            // 
            this.clave_nuevo2.Location = new System.Drawing.Point(145, 45);
            this.clave_nuevo2.MaxLength = 10;
            this.clave_nuevo2.Name = "clave_nuevo2";
            this.clave_nuevo2.PasswordChar = '*';
            this.clave_nuevo2.Size = new System.Drawing.Size(100, 20);
            this.clave_nuevo2.TabIndex = 3;
            // 
            // clave_nuevo
            // 
            this.clave_nuevo.Location = new System.Drawing.Point(145, 13);
            this.clave_nuevo.MaxLength = 10;
            this.clave_nuevo.Name = "clave_nuevo";
            this.clave_nuevo.PasswordChar = '*';
            this.clave_nuevo.Size = new System.Drawing.Size(100, 20);
            this.clave_nuevo.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(22, 48);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(117, 13);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Confirmar Contraseña : ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(34, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(105, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Nueva Contraseña : ";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.clave);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(14, 56);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(291, 42);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            // 
            // clave
            // 
            this.clave.Location = new System.Drawing.Point(145, 13);
            this.clave.MaxLength = 10;
            this.clave.Name = "clave";
            this.clave.PasswordChar = '*';
            this.clave.Size = new System.Drawing.Size(100, 20);
            this.clave.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(32, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(107, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Ingrese contraseña  :";
            // 
            // Frm_LoginChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 250);
            this.ControlBox = false;
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_LoginChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_LoginChangePassword_FormClosing);
            this.Load += new System.EventHandler(this.Frm_LoginChangePassword_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.TextBox clave_nuevo2;
        private System.Windows.Forms.TextBox clave_nuevo;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox clave;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button button1;
    }
}