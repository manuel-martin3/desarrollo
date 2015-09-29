namespace BapFormulariosNet.D60ALMACEN.PROCESOS
{
    partial class Frm_reorganizacion_total
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
            this.cboLocal = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboModuloid = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.fech_ini = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.fech_fin = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnReorganizar = new DevComponents.DotNetBar.ButtonX();
            this.chkDesdeHistorico = new System.Windows.Forms.CheckBox();
            this.cboPerianio = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.chkSelecAnio = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboLocal
            // 
            this.cboLocal.DisplayMember = "Text";
            this.cboLocal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.ItemHeight = 15;
            this.cboLocal.Location = new System.Drawing.Point(113, 49);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.Size = new System.Drawing.Size(164, 21);
            this.cboLocal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLocal.TabIndex = 17;
            this.cboLocal.SelectedIndexChanged += new System.EventHandler(this.cboLocal_SelectedIndexChanged);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(17, 49);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 16);
            this.labelX2.TabIndex = 16;
            this.labelX2.Text = "Local:";
            // 
            // cboModuloid
            // 
            this.cboModuloid.DisplayMember = "Text";
            this.cboModuloid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModuloid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModuloid.Enabled = false;
            this.cboModuloid.FormattingEnabled = true;
            this.cboModuloid.ItemHeight = 15;
            this.cboModuloid.Location = new System.Drawing.Point(113, 22);
            this.cboModuloid.Name = "cboModuloid";
            this.cboModuloid.Size = new System.Drawing.Size(164, 21);
            this.cboModuloid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboModuloid.TabIndex = 15;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(17, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(42, 16);
            this.labelX1.TabIndex = 14;
            this.labelX1.Text = "Módulo:";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(16, 104);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(92, 16);
            this.labelX5.TabIndex = 30;
            this.labelX5.Text = "Inicio del Proceso:";
            // 
            // fech_ini
            // 
            // 
            // 
            // 
            this.fech_ini.Border.Class = "TextBoxBorder";
            this.fech_ini.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fech_ini.ButtonCustom.Tooltip = "";
            this.fech_ini.ButtonCustom2.Tooltip = "";
            this.fech_ini.Enabled = false;
            this.fech_ini.Location = new System.Drawing.Point(113, 103);
            this.fech_ini.Name = "fech_ini";
            this.fech_ini.PreventEnterBeep = true;
            this.fech_ini.Size = new System.Drawing.Size(201, 21);
            this.fech_ini.TabIndex = 28;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(16, 131);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(80, 16);
            this.labelX3.TabIndex = 32;
            this.labelX3.Text = "Fin del Proceso:";
            // 
            // fech_fin
            // 
            // 
            // 
            // 
            this.fech_fin.Border.Class = "TextBoxBorder";
            this.fech_fin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fech_fin.ButtonCustom.Tooltip = "";
            this.fech_fin.ButtonCustom2.Tooltip = "";
            this.fech_fin.Enabled = false;
            this.fech_fin.Location = new System.Drawing.Point(113, 130);
            this.fech_fin.Name = "fech_fin";
            this.fech_fin.PreventEnterBeep = true;
            this.fech_fin.Size = new System.Drawing.Size(201, 21);
            this.fech_fin.TabIndex = 31;
            // 
            // btnReorganizar
            // 
            this.btnReorganizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReorganizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReorganizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReorganizar.Image = global::BapFormulariosNet.Properties.Resources.btn_Actualizar;
            this.btnReorganizar.Location = new System.Drawing.Point(125, 180);
            this.btnReorganizar.Name = "btnReorganizar";
            this.btnReorganizar.Size = new System.Drawing.Size(80, 26);
            this.btnReorganizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReorganizar.TabIndex = 97;
            this.btnReorganizar.Click += new System.EventHandler(this.btnReorganizar_Click);
            // 
            // chkDesdeHistorico
            // 
            this.chkDesdeHistorico.AutoSize = true;
            this.chkDesdeHistorico.Checked = true;
            this.chkDesdeHistorico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDesdeHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDesdeHistorico.Location = new System.Drawing.Point(113, 157);
            this.chkDesdeHistorico.Name = "chkDesdeHistorico";
            this.chkDesdeHistorico.Size = new System.Drawing.Size(116, 17);
            this.chkDesdeHistorico.TabIndex = 98;
            this.chkDesdeHistorico.Text = "Desde Histórico";
            this.chkDesdeHistorico.UseVisualStyleBackColor = true;
            // 
            // cboPerianio
            // 
            this.cboPerianio.DisplayMember = "Text";
            this.cboPerianio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPerianio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerianio.Enabled = false;
            this.cboPerianio.FormattingEnabled = true;
            this.cboPerianio.ItemHeight = 15;
            this.cboPerianio.Location = new System.Drawing.Point(113, 76);
            this.cboPerianio.Name = "cboPerianio";
            this.cboPerianio.Size = new System.Drawing.Size(143, 21);
            this.cboPerianio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPerianio.TabIndex = 100;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(17, 76);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(43, 16);
            this.labelX4.TabIndex = 99;
            this.labelX4.Text = "Período:";
            // 
            // chkSelecAnio
            // 
            this.chkSelecAnio.AutoSize = true;
            this.chkSelecAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelecAnio.Location = new System.Drawing.Point(262, 78);
            this.chkSelecAnio.Name = "chkSelecAnio";
            this.chkSelecAnio.Size = new System.Drawing.Size(15, 14);
            this.chkSelecAnio.TabIndex = 101;
            this.chkSelecAnio.UseVisualStyleBackColor = true;
            this.chkSelecAnio.CheckedChanged += new System.EventHandler(this.chkSelecAnio_CheckedChanged);
            // 
            // Frm_reorganizacion_total
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 218);
            this.Controls.Add(this.chkSelecAnio);
            this.Controls.Add(this.cboPerianio);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.chkDesdeHistorico);
            this.Controls.Add(this.btnReorganizar);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.fech_fin);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.fech_ini);
            this.Controls.Add(this.cboLocal);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cboModuloid);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_reorganizacion_total";
            this.Text = "»» Reorganiza Total ««";
            this.Load += new System.EventHandler(this.Frm_reorganizacion_total_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cboLocal;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboModuloid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX fech_ini;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX fech_fin;
        private DevComponents.DotNetBar.ButtonX btnReorganizar;
        private System.Windows.Forms.CheckBox chkDesdeHistorico;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPerianio;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.CheckBox chkSelecAnio;
    }
}