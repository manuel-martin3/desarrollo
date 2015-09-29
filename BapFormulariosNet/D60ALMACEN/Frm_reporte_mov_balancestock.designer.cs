namespace BapFormulariosNet.D60ALMACEN
{
    partial class Frm_reporte_mov_balancestock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_reporte_mov_balancestock));
            this.btnPrint121 = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint131 = new DevComponents.DotNetBar.ButtonX();
            this.chkimpresion = new System.Windows.Forms.CheckBox();
            this.dtmfecha = new System.Windows.Forms.DateTimePicker();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.productid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.subgruponame = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.subgrupoid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.gruponame = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.grupoid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lineaname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lineaid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboPerimesfin = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboPerimesini = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboPerianio = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.chkTodos = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboLocal = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cboModuloid = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnPrint121
            // 
            this.btnPrint121.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint121.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint121.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint121.Image = global::BapFormulariosNet.Properties.Resources.PDT1;
            this.btnPrint121.Location = new System.Drawing.Point(246, 243);
            this.btnPrint121.Name = "btnPrint121";
            this.btnPrint121.Size = new System.Drawing.Size(99, 41);
            this.btnPrint121.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrint121.TabIndex = 121;
            this.btnPrint121.Text = "Form 12.1";
            this.btnPrint121.Click += new System.EventHandler(this.btnPrint121_Click);
            // 
            // btnPrint131
            // 
            this.btnPrint131.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint131.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint131.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint131.Image = global::BapFormulariosNet.Properties.Resources.PDT1;
            this.btnPrint131.Location = new System.Drawing.Point(131, 243);
            this.btnPrint131.Name = "btnPrint131";
            this.btnPrint131.Size = new System.Drawing.Size(101, 41);
            this.btnPrint131.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrint131.TabIndex = 120;
            this.btnPrint131.Text = "Form 13.1";
            this.btnPrint131.Click += new System.EventHandler(this.btnPrint131_Click);
            // 
            // chkimpresion
            // 
            this.chkimpresion.AutoSize = true;
            this.chkimpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkimpresion.Location = new System.Drawing.Point(215, 201);
            this.chkimpresion.Name = "chkimpresion";
            this.chkimpresion.Size = new System.Drawing.Size(141, 17);
            this.chkimpresion.TabIndex = 119;
            this.chkimpresion.Text = "Fecha de Impresion:";
            this.chkimpresion.UseVisualStyleBackColor = true;
            // 
            // dtmfecha
            // 
            this.dtmfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmfecha.Location = new System.Drawing.Point(111, 197);
            this.dtmfecha.Name = "dtmfecha";
            this.dtmfecha.Size = new System.Drawing.Size(97, 21);
            this.dtmfecha.TabIndex = 118;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(16, 174);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(82, 16);
            this.labelX7.TabIndex = 117;
            this.labelX7.Text = "Artículo/Modelo:";
            // 
            // productid
            // 
            // 
            // 
            // 
            this.productid.Border.Class = "TextBoxBorder";
            this.productid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.productid.ButtonCustom.Tooltip = "";
            this.productid.ButtonCustom2.Tooltip = "";
            this.productid.Location = new System.Drawing.Point(111, 172);
            this.productid.Name = "productid";
            this.productid.PreventEnterBeep = true;
            this.productid.Size = new System.Drawing.Size(113, 21);
            this.productid.TabIndex = 116;
            this.productid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productid_KeyDown);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(15, 152);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(82, 16);
            this.labelX6.TabIndex = 115;
            this.labelX6.Text = "Artículo/Modelo:";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(15, 123);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(83, 16);
            this.labelX5.TabIndex = 114;
            this.labelX5.Text = "Marca/Provedor:";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(15, 98);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(32, 16);
            this.labelX4.TabIndex = 113;
            this.labelX4.Text = "Línea:";
            // 
            // subgruponame
            // 
            // 
            // 
            // 
            this.subgruponame.Border.Class = "TextBoxBorder";
            this.subgruponame.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subgruponame.ButtonCustom.Tooltip = "";
            this.subgruponame.ButtonCustom2.Tooltip = "";
            this.subgruponame.Enabled = false;
            this.subgruponame.Location = new System.Drawing.Point(158, 147);
            this.subgruponame.Name = "subgruponame";
            this.subgruponame.PreventEnterBeep = true;
            this.subgruponame.Size = new System.Drawing.Size(201, 21);
            this.subgruponame.TabIndex = 112;
            // 
            // subgrupoid
            // 
            // 
            // 
            // 
            this.subgrupoid.Border.Class = "TextBoxBorder";
            this.subgrupoid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.subgrupoid.ButtonCustom.Tooltip = "";
            this.subgrupoid.ButtonCustom2.Tooltip = "";
            this.subgrupoid.Location = new System.Drawing.Point(111, 148);
            this.subgrupoid.Name = "subgrupoid";
            this.subgrupoid.PreventEnterBeep = true;
            this.subgrupoid.Size = new System.Drawing.Size(41, 21);
            this.subgrupoid.TabIndex = 111;
            this.subgrupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subgrupoid_KeyDown);
            // 
            // gruponame
            // 
            // 
            // 
            // 
            this.gruponame.Border.Class = "TextBoxBorder";
            this.gruponame.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gruponame.ButtonCustom.Tooltip = "";
            this.gruponame.ButtonCustom2.Tooltip = "";
            this.gruponame.Enabled = false;
            this.gruponame.Location = new System.Drawing.Point(158, 120);
            this.gruponame.Name = "gruponame";
            this.gruponame.PreventEnterBeep = true;
            this.gruponame.Size = new System.Drawing.Size(201, 21);
            this.gruponame.TabIndex = 110;
            // 
            // grupoid
            // 
            // 
            // 
            // 
            this.grupoid.Border.Class = "TextBoxBorder";
            this.grupoid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grupoid.ButtonCustom.Tooltip = "";
            this.grupoid.ButtonCustom2.Tooltip = "";
            this.grupoid.Location = new System.Drawing.Point(111, 121);
            this.grupoid.Name = "grupoid";
            this.grupoid.PreventEnterBeep = true;
            this.grupoid.Size = new System.Drawing.Size(41, 21);
            this.grupoid.TabIndex = 109;
            this.grupoid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grupoid_KeyDown);
            // 
            // lineaname
            // 
            // 
            // 
            // 
            this.lineaname.Border.Class = "TextBoxBorder";
            this.lineaname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lineaname.ButtonCustom.Tooltip = "";
            this.lineaname.ButtonCustom2.Tooltip = "";
            this.lineaname.Enabled = false;
            this.lineaname.Location = new System.Drawing.Point(158, 93);
            this.lineaname.Name = "lineaname";
            this.lineaname.PreventEnterBeep = true;
            this.lineaname.Size = new System.Drawing.Size(201, 21);
            this.lineaname.TabIndex = 108;
            // 
            // lineaid
            // 
            // 
            // 
            // 
            this.lineaid.Border.Class = "TextBoxBorder";
            this.lineaid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lineaid.ButtonCustom.Tooltip = "";
            this.lineaid.ButtonCustom2.Tooltip = "";
            this.lineaid.Location = new System.Drawing.Point(111, 94);
            this.lineaid.Name = "lineaid";
            this.lineaid.PreventEnterBeep = true;
            this.lineaid.Size = new System.Drawing.Size(41, 21);
            this.lineaid.TabIndex = 107;
            this.lineaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lineaid_KeyDown);
            // 
            // cboPerimesfin
            // 
            this.cboPerimesfin.DisplayMember = "Text";
            this.cboPerimesfin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPerimesfin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerimesfin.FormattingEnabled = true;
            this.cboPerimesfin.ItemHeight = 15;
            this.cboPerimesfin.Location = new System.Drawing.Point(365, 66);
            this.cboPerimesfin.Name = "cboPerimesfin";
            this.cboPerimesfin.Size = new System.Drawing.Size(121, 21);
            this.cboPerimesfin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPerimesfin.TabIndex = 106;
            // 
            // cboPerimesini
            // 
            this.cboPerimesini.DisplayMember = "Text";
            this.cboPerimesini.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPerimesini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerimesini.FormattingEnabled = true;
            this.cboPerimesini.ItemHeight = 15;
            this.cboPerimesini.Location = new System.Drawing.Point(238, 66);
            this.cboPerimesini.Name = "cboPerimesini";
            this.cboPerimesini.Size = new System.Drawing.Size(121, 21);
            this.cboPerimesini.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPerimesini.TabIndex = 105;
            // 
            // cboPerianio
            // 
            this.cboPerianio.DisplayMember = "Text";
            this.cboPerianio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPerianio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerianio.FormattingEnabled = true;
            this.cboPerianio.ItemHeight = 15;
            this.cboPerianio.Location = new System.Drawing.Point(111, 66);
            this.cboPerianio.Name = "cboPerianio";
            this.cboPerianio.Size = new System.Drawing.Size(121, 21);
            this.cboPerianio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPerianio.TabIndex = 104;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(15, 66);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(43, 16);
            this.labelX3.TabIndex = 103;
            this.labelX3.Text = "Período:";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            // 
            // 
            // 
            this.chkTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkTodos.Location = new System.Drawing.Point(281, 39);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(52, 16);
            this.chkTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkTodos.TabIndex = 102;
            this.chkTodos.Text = "Todos";
            // 
            // cboLocal
            // 
            this.cboLocal.DisplayMember = "Text";
            this.cboLocal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.ItemHeight = 15;
            this.cboLocal.Location = new System.Drawing.Point(111, 39);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.Size = new System.Drawing.Size(164, 21);
            this.cboLocal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLocal.TabIndex = 101;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(15, 39);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 16);
            this.labelX2.TabIndex = 100;
            this.labelX2.Text = "Local:";
            // 
            // cboModuloid
            // 
            this.cboModuloid.DisplayMember = "Text";
            this.cboModuloid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboModuloid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModuloid.FormattingEnabled = true;
            this.cboModuloid.ItemHeight = 15;
            this.cboModuloid.Location = new System.Drawing.Point(111, 12);
            this.cboModuloid.Name = "cboModuloid";
            this.cboModuloid.Size = new System.Drawing.Size(164, 21);
            this.cboModuloid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboModuloid.TabIndex = 99;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(42, 16);
            this.labelX1.TabIndex = 98;
            this.labelX1.Text = "Módulo:";
            // 
            // Frm_reporte_mov_balancestock
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(492, 291);
            this.Controls.Add(this.btnPrint121);
            this.Controls.Add(this.btnPrint131);
            this.Controls.Add(this.chkimpresion);
            this.Controls.Add(this.dtmfecha);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.productid);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.subgruponame);
            this.Controls.Add(this.subgrupoid);
            this.Controls.Add(this.gruponame);
            this.Controls.Add(this.grupoid);
            this.Controls.Add(this.lineaname);
            this.Controls.Add(this.lineaid);
            this.Controls.Add(this.cboPerimesfin);
            this.Controls.Add(this.cboPerimesini);
            this.Controls.Add(this.cboPerianio);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.cboLocal);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cboModuloid);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_reporte_mov_balancestock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance del stock";
            this.Load += new System.EventHandler(this.Frm_reporte_stockrollo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnPrint121;
        private DevComponents.DotNetBar.ButtonX btnPrint131;
        private System.Windows.Forms.CheckBox chkimpresion;
        private System.Windows.Forms.DateTimePicker dtmfecha;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX productid;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX subgruponame;
        private DevComponents.DotNetBar.Controls.TextBoxX subgrupoid;
        private DevComponents.DotNetBar.Controls.TextBoxX gruponame;
        private DevComponents.DotNetBar.Controls.TextBoxX grupoid;
        private DevComponents.DotNetBar.Controls.TextBoxX lineaname;
        private DevComponents.DotNetBar.Controls.TextBoxX lineaid;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPerimesfin;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPerimesini;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPerianio;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkTodos;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboLocal;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboModuloid;
        private DevComponents.DotNetBar.LabelX labelX1;


    }
}