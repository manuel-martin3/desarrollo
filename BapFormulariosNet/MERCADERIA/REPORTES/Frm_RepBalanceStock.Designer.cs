namespace BapFormulariosNet.MERCADERIA.REPORTES
{
    partial class Frm_RepBalanceStock
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
            this.crwbalancestock = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crwbalancestock
            // 
            this.crwbalancestock.ActiveViewIndex = -1;
            this.crwbalancestock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crwbalancestock.Cursor = System.Windows.Forms.Cursors.Default;
            this.crwbalancestock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crwbalancestock.Location = new System.Drawing.Point(0, 0);
            this.crwbalancestock.Name = "crwbalancestock";
            this.crwbalancestock.Size = new System.Drawing.Size(696, 493);
            this.crwbalancestock.TabIndex = 0;
            this.crwbalancestock.Load += new System.EventHandler(this.crwbalancestock_Load);
            // 
            // Frm_RepBalanceStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 493);
            this.Controls.Add(this.crwbalancestock);
            this.Name = "Frm_RepBalanceStock";
            this.Text = "Frm_RepBalanceStock";
            this.Load += new System.EventHandler(this.Frm_RepBalanceStock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crwbalancestock;

    }
}