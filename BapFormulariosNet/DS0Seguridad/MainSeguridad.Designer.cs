namespace BapFormulariosNet.DS0Seguridad
{
    partial class MainSeguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSeguridad));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.brStado = new System.Windows.Forms.StatusStrip();
            this.Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.separador = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSoporte = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEmail = new System.Windows.Forms.ToolStripStatusLabel();
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.brStado.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(870, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // brStado
            // 
            this.brStado.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.brStado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Usuario,
            this.lblUsuario,
            this.separador,
            this.lblSoporte,
            this.lblEmail});
            this.brStado.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.brStado.Location = new System.Drawing.Point(0, 485);
            this.brStado.Name = "brStado";
            this.brStado.Size = new System.Drawing.Size(870, 21);
            this.brStado.TabIndex = 5;
            this.brStado.Text = "statusStrip1";
            // 
            // Usuario
            // 
            this.Usuario.ForeColor = System.Drawing.Color.White;
            this.Usuario.Image = global::BapFormulariosNet.Properties.Resources.administrator;
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(63, 16);
            this.Usuario.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = false;
            this.lblUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblUsuario.ForeColor = System.Drawing.Color.Lime;
            this.lblUsuario.LinkColor = System.Drawing.Color.Red;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(190, 16);
            this.lblUsuario.Text = "Usuar";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // separador
            // 
            this.separador.AutoSize = false;
            this.separador.ForeColor = System.Drawing.Color.White;
            this.separador.Name = "separador";
            this.separador.Size = new System.Drawing.Size(81, 16);
            this.separador.Text = "         ¦¦¦¦¦         ";
            // 
            // lblSoporte
            // 
            this.lblSoporte.ForeColor = System.Drawing.Color.White;
            this.lblSoporte.Image = global::BapFormulariosNet.Properties.Resources.fond;
            this.lblSoporte.Name = "lblSoporte";
            this.lblSoporte.Size = new System.Drawing.Size(65, 16);
            this.lblSoporte.Text = "Soporte:";
            // 
            // lblEmail
            // 
            this.lblEmail.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.lblEmail.ForeColor = System.Drawing.Color.Lime;
            this.lblEmail.LinkColor = System.Drawing.Color.Red;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(230, 13);
            this.lblEmail.Text = "Mail: bapconta@hotmail.com - Cel: 992800845";
            // 
            // MainSeguridad
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 506);
            this.Controls.Add(this.brStado);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainSeguridad";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainSeguridad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainSeguridad_Load);
            this.brStado.ResumeLayout(false);
            this.brStado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.StatusStrip brStado;
        internal System.Windows.Forms.ToolStripStatusLabel Usuario;
        internal System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        internal System.Windows.Forms.ToolStripStatusLabel separador;
        private System.Windows.Forms.ToolStripStatusLabel lblSoporte;
        private System.Windows.Forms.ToolStripStatusLabel lblEmail;
        private DevExpress.XtraBars.FormAssistant formAssistant1;
    }
}