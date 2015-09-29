namespace BapControles
{
    partial class List2List
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstDerecha = new System.Windows.Forms.ListBox();
            this.lstIzquierda = new System.Windows.Forms.ListBox();
            this.lblderecha = new System.Windows.Forms.Label();
            this.lblizquierda = new System.Windows.Forms.Label();
            this.cmdtodosIzquierda = new System.Windows.Forms.Button();
            this.cmdIzquierda = new System.Windows.Forms.Button();
            this.cmdtodosDerecha = new System.Windows.Forms.Button();
            this.cmdDerecha = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDerecha
            // 
            this.lstDerecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDerecha.FormattingEnabled = true;
            this.lstDerecha.Location = new System.Drawing.Point(238, 21);
            this.lstDerecha.Name = "lstDerecha";
            this.lstDerecha.Size = new System.Drawing.Size(158, 173);
            this.lstDerecha.TabIndex = 25;
            // 
            // lstIzquierda
            // 
            this.lstIzquierda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIzquierda.FormattingEnabled = true;
            this.lstIzquierda.Location = new System.Drawing.Point(4, 21);
            this.lstIzquierda.Name = "lstIzquierda";
            this.lstIzquierda.Size = new System.Drawing.Size(158, 173);
            this.lstIzquierda.TabIndex = 24;
            // 
            // lblderecha
            // 
            this.lblderecha.AutoSize = true;
            this.lblderecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblderecha.Location = new System.Drawing.Point(244, 5);
            this.lblderecha.Name = "lblderecha";
            this.lblderecha.Size = new System.Drawing.Size(152, 15);
            this.lblderecha.TabIndex = 23;
            this.lblderecha.Text = "Lineas Seleccionadas:";
            // 
            // lblizquierda
            // 
            this.lblizquierda.AutoSize = true;
            this.lblizquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblizquierda.Location = new System.Drawing.Point(11, 5);
            this.lblizquierda.Name = "lblizquierda";
            this.lblizquierda.Size = new System.Drawing.Size(134, 15);
            this.lblizquierda.TabIndex = 22;
            this.lblizquierda.Text = "Lineas Disponibles:";
            // 
            // cmdtodosIzquierda
            // 
            this.cmdtodosIzquierda.BackColor = System.Drawing.Color.Transparent;
            this.cmdtodosIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdtodosIzquierda.FlatAppearance.BorderSize = 0;
            this.cmdtodosIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdtodosIzquierda.Image = global::BapControles.Properties.Resources.go_first_g;
            this.cmdtodosIzquierda.Location = new System.Drawing.Point(183, 150);
            this.cmdtodosIzquierda.Name = "cmdtodosIzquierda";
            this.cmdtodosIzquierda.Size = new System.Drawing.Size(38, 38);
            this.cmdtodosIzquierda.TabIndex = 29;
            this.cmdtodosIzquierda.UseVisualStyleBackColor = false;
            this.cmdtodosIzquierda.Click += new System.EventHandler(this.cmdtodosIzquierda_Click);
            // 
            // cmdIzquierda
            // 
            this.cmdIzquierda.BackColor = System.Drawing.Color.Transparent;
            this.cmdIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdIzquierda.FlatAppearance.BorderSize = 0;
            this.cmdIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdIzquierda.Image = global::BapControles.Properties.Resources.go_previous_g;
            this.cmdIzquierda.Location = new System.Drawing.Point(188, 106);
            this.cmdIzquierda.Name = "cmdIzquierda";
            this.cmdIzquierda.Size = new System.Drawing.Size(28, 30);
            this.cmdIzquierda.TabIndex = 28;
            this.cmdIzquierda.UseVisualStyleBackColor = false;
            this.cmdIzquierda.Click += new System.EventHandler(this.cmdIzquierda_Click);
            // 
            // cmdtodosDerecha
            // 
            this.cmdtodosDerecha.BackColor = System.Drawing.Color.Transparent;
            this.cmdtodosDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdtodosDerecha.FlatAppearance.BorderSize = 0;
            this.cmdtodosDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdtodosDerecha.Image = global::BapControles.Properties.Resources.go_last_g;
            this.cmdtodosDerecha.Location = new System.Drawing.Point(183, 21);
            this.cmdtodosDerecha.Name = "cmdtodosDerecha";
            this.cmdtodosDerecha.Size = new System.Drawing.Size(38, 38);
            this.cmdtodosDerecha.TabIndex = 27;
            this.cmdtodosDerecha.UseVisualStyleBackColor = false;
            this.cmdtodosDerecha.Click += new System.EventHandler(this.cmdtodosDerecha_Click);
            // 
            // cmdDerecha
            // 
            this.cmdDerecha.BackColor = System.Drawing.Color.Transparent;
            this.cmdDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdDerecha.FlatAppearance.BorderSize = 0;
            this.cmdDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDerecha.Image = global::BapControles.Properties.Resources.go_next_g;
            this.cmdDerecha.Location = new System.Drawing.Point(188, 71);
            this.cmdDerecha.Name = "cmdDerecha";
            this.cmdDerecha.Size = new System.Drawing.Size(28, 30);
            this.cmdDerecha.TabIndex = 26;
            this.cmdDerecha.UseVisualStyleBackColor = false;
            this.cmdDerecha.Click += new System.EventHandler(this.cmdDerecha_Click);
            // 
            // List2List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdtodosIzquierda);
            this.Controls.Add(this.cmdIzquierda);
            this.Controls.Add(this.cmdtodosDerecha);
            this.Controls.Add(this.cmdDerecha);
            this.Controls.Add(this.lstDerecha);
            this.Controls.Add(this.lstIzquierda);
            this.Controls.Add(this.lblderecha);
            this.Controls.Add(this.lblizquierda);
            this.Name = "List2List";
            this.Size = new System.Drawing.Size(401, 201);
            this.Load += new System.EventHandler(this.List2List_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdtodosIzquierda;
        private System.Windows.Forms.Button cmdIzquierda;
        private System.Windows.Forms.Button cmdtodosDerecha;
        private System.Windows.Forms.Button cmdDerecha;
        private System.Windows.Forms.ListBox lstDerecha;
        private System.Windows.Forms.ListBox lstIzquierda;
        private System.Windows.Forms.Label lblderecha;
        private System.Windows.Forms.Label lblizquierda;
    }
}
