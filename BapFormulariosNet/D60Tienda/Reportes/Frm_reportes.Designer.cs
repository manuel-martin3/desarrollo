namespace BapFormulariosNet.D60Tienda.Reportes
{
    partial class Frm_reportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reportes));
            this.CrsRptMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrsRptMain
            // 
            this.CrsRptMain.ActiveViewIndex = -1;
            this.CrsRptMain.AutoScroll = true;
            this.CrsRptMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrsRptMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrsRptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrsRptMain.Location = new System.Drawing.Point(0, 0);
            this.CrsRptMain.Name = "CrsRptMain";
            this.CrsRptMain.Size = new System.Drawing.Size(984, 582);
            this.CrsRptMain.TabIndex = 0;
            this.CrsRptMain.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 582);
            this.Controls.Add(this.CrsRptMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_reportes";
            this.Text = "Frm_reportes";
            this.Activated += new System.EventHandler(this.Frm_reportes_Activated);
            this.Load += new System.EventHandler(this.Frm_reportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrsRptMain;

    }
}