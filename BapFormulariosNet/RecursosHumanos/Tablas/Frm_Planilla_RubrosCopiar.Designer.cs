namespace BapFormulariosNet.RecursosHumanos.Tablas
{
    partial class Frm_Planilla_RubrosCopiar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Planilla_RubrosCopiar));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btncopiar = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbtipoplanillaorigen = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmbtipoplanilladestino = new System.Windows.Forms.ComboBox();
            this.cmbtiporubro = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btncopiar);
            this.GroupBox2.Controls.Add(this.btnsalir);
            this.GroupBox2.Location = new System.Drawing.Point(58, 175);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(165, 55);
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            // 
            // btncopiar
            // 
            this.btncopiar.Image = global::BapFormulariosNet.Properties.Resources.copydoc32;
            this.btncopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncopiar.Location = new System.Drawing.Point(5, 10);
            this.btncopiar.Name = "btncopiar";
            this.btncopiar.Size = new System.Drawing.Size(76, 40);
            this.btncopiar.TabIndex = 0;
            this.btncopiar.Text = "Copiar";
            this.btncopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncopiar.UseVisualStyleBackColor = true;
            this.btncopiar.Click += new System.EventHandler(this.btncopiar_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Image = global::BapFormulariosNet.Properties.Resources.btn_salir;
            this.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsalir.Location = new System.Drawing.Point(85, 10);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(76, 40);
            this.btnsalir.TabIndex = 1;
            this.btnsalir.Text = "Cerrar";
            this.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cmbtipoplanillaorigen);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.cmbtipoplanilladestino);
            this.GroupBox1.Controls.Add(this.cmbtiporubro);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(10, 7);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(266, 169);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(18, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(98, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Tipo Planilla Origen";
            // 
            // cmbtipoplanillaorigen
            // 
            this.cmbtipoplanillaorigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoplanillaorigen.Enabled = false;
            this.cmbtipoplanillaorigen.FormattingEnabled = true;
            this.cmbtipoplanillaorigen.Location = new System.Drawing.Point(18, 32);
            this.cmbtipoplanillaorigen.Name = "cmbtipoplanillaorigen";
            this.cmbtipoplanillaorigen.Size = new System.Drawing.Size(226, 21);
            this.cmbtipoplanillaorigen.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(18, 121);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(102, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Tipo Rubro a Copiar";
            // 
            // cmbtipoplanilladestino
            // 
            this.cmbtipoplanilladestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipoplanilladestino.Enabled = false;
            this.cmbtipoplanilladestino.FormattingEnabled = true;
            this.cmbtipoplanilladestino.Location = new System.Drawing.Point(18, 80);
            this.cmbtipoplanilladestino.Name = "cmbtipoplanilladestino";
            this.cmbtipoplanilladestino.Size = new System.Drawing.Size(226, 21);
            this.cmbtipoplanilladestino.TabIndex = 3;
            // 
            // cmbtiporubro
            // 
            this.cmbtiporubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtiporubro.Enabled = false;
            this.cmbtiporubro.FormattingEnabled = true;
            this.cmbtiporubro.Location = new System.Drawing.Point(18, 137);
            this.cmbtiporubro.Name = "cmbtiporubro";
            this.cmbtiporubro.Size = new System.Drawing.Size(226, 21);
            this.cmbtiporubro.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(18, 64);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(103, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Tipo Planilla Destino";
            // 
            // Frm_Planilla_RubrosCopiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 236);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm_Planilla_RubrosCopiar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Rubros de Planilla";
            this.Activated += new System.EventHandler(this.Frm_Planilla_RubrosCopiar_Activated);
            this.Load += new System.EventHandler(this.Frm_Planilla_RubrosCopiar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Planilla_RubrosCopiar_KeyDown);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btncopiar;
        internal System.Windows.Forms.Button btnsalir;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbtipoplanillaorigen;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cmbtipoplanilladestino;
        internal System.Windows.Forms.ComboBox cmbtiporubro;
        internal System.Windows.Forms.Label Label2;
    }
}