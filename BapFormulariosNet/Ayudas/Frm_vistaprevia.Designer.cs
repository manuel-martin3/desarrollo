namespace BapFormulariosNet.Ayudas
{
    partial class Frm_vistaprevia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_vistaprevia));
            this.btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.lst_detalle = new System.Windows.Forms.TextBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_print
            // 
            this.btn_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print.Image = global::BapFormulariosNet.Properties.Resources.zebra_gc420t;
            this.btn_print.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_print.Location = new System.Drawing.Point(183, 473);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(43, 37);
            this.btn_print.TabIndex = 1;
            this.btn_print.ToolTip = "Imprimir";
            this.btn_print.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.Location = new System.Drawing.Point(243, 473);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(41, 37);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.ToolTip = "Cancelar";
            this.btn_cancel.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lst_detalle
            // 
            this.lst_detalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_detalle.Location = new System.Drawing.Point(11, 13);
            this.lst_detalle.Multiline = true;
            this.lst_detalle.Name = "lst_detalle";
            this.lst_detalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lst_detalle.Size = new System.Drawing.Size(444, 458);
            this.lst_detalle.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Teal;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btn_cancel);
            this.panelControl2.Controls.Add(this.btn_print);
            this.panelControl2.Controls.Add(this.lst_detalle);
            this.panelControl2.Location = new System.Drawing.Point(-1, -1);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(467, 514);
            this.panelControl2.TabIndex = 5;
            // 
            // Frm_vistaprevia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 514);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_vistaprevia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_vistaprevia";
            this.Load += new System.EventHandler(this.Frm_vistaprevia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_print;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private System.Windows.Forms.TextBox lst_detalle;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}