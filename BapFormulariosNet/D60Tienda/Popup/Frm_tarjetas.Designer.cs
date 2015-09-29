namespace BapFormulariosNet.D60Tienda.Popup
{
    partial class Frm_tarjetas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_tarjetas));
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.numaprovacion = new System.Windows.Forms.TextBox();
            this.dnititular = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nametitular = new System.Windows.Forms.TextBox();
            this.salgifcard = new System.Windows.Forms.TextBox();
            this.importtarj = new System.Windows.Forms.TextBox();
            this.glueTarjeta = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.imagelist1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btn_aceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.glueTarjeta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagelist1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 10;
            this.lineShape1.X2 = 341;
            this.lineShape1.Y1 = 59;
            this.lineShape1.Y2 = 59;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderWidth = 2;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 16;
            this.lineShape2.X2 = 345;
            this.lineShape2.Y1 = 142;
            this.lineShape2.Y2 = 142;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(41, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 13);
            this.label30.TabIndex = 57;
            this.label30.Text = "Tarjeta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(162, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Dni - Titular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(257, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Nº- Aprovaciòn";
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_limpiar.Image = global::BapFormulariosNet.Properties.Resources.btn_clean;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_limpiar.Location = new System.Drawing.Point(89, 163);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 25);
            this.btn_limpiar.TabIndex = 60;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // numaprovacion
            // 
            this.numaprovacion.Location = new System.Drawing.Point(255, 27);
            this.numaprovacion.Name = "numaprovacion";
            this.numaprovacion.Size = new System.Drawing.Size(95, 21);
            this.numaprovacion.TabIndex = 2;
            this.numaprovacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numaprovacion_KeyDown);
            // 
            // dnititular
            // 
            this.dnititular.Enabled = false;
            this.dnititular.Location = new System.Drawing.Point(150, 27);
            this.dnititular.Name = "dnititular";
            this.dnititular.Size = new System.Drawing.Size(92, 21);
            this.dnititular.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Importe de Tarjeta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(47, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Saldo de Gift Card:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(47, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Titular :";
            // 
            // nametitular
            // 
            this.nametitular.Enabled = false;
            this.nametitular.Location = new System.Drawing.Point(165, 66);
            this.nametitular.Name = "nametitular";
            this.nametitular.Size = new System.Drawing.Size(158, 21);
            this.nametitular.TabIndex = 68;
            // 
            // salgifcard
            // 
            this.salgifcard.Enabled = false;
            this.salgifcard.Location = new System.Drawing.Point(165, 88);
            this.salgifcard.Name = "salgifcard";
            this.salgifcard.Size = new System.Drawing.Size(88, 21);
            this.salgifcard.TabIndex = 3;
            this.salgifcard.Text = "0.00";
            this.salgifcard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // importtarj
            // 
            this.importtarj.Location = new System.Drawing.Point(165, 110);
            this.importtarj.Name = "importtarj";
            this.importtarj.Size = new System.Drawing.Size(88, 21);
            this.importtarj.TabIndex = 4;
            this.importtarj.Text = "0.00";
            this.importtarj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.importtarj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.importtarj_KeyDown);
            // 
            // glueTarjeta
            // 
            this.glueTarjeta.EditValue = "";
            this.glueTarjeta.Location = new System.Drawing.Point(5, 27);
            this.glueTarjeta.Name = "glueTarjeta";
            this.glueTarjeta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glueTarjeta.Properties.View = this.gridLookUpEdit1View;
            this.glueTarjeta.Size = new System.Drawing.Size(136, 20);
            this.glueTarjeta.TabIndex = 0;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridLookUpEdit1View_RowClick);
            // 
            // imagelist1
            // 
            this.imagelist1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imagelist1.ImageStream")));
            this.imagelist1.Images.SetKeyName(0, "go-dinn.jpg");
            this.imagelist1.Images.SetKeyName(1, "go-amex.jpg");
            this.imagelist1.Images.SetKeyName(2, "go-mastercard.jpg");
            this.imagelist1.Images.SetKeyName(3, "go-visa.jpg");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.importtarj);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.salgifcard);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nametitular);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numaprovacion);
            this.panel1.Controls.Add(this.glueTarjeta);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dnititular);
            this.panel1.Controls.Add(this.shapeContainer2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 155);
            this.panel1.TabIndex = 69;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer2.Size = new System.Drawing.Size(362, 155);
            this.shapeContainer2.TabIndex = 60;
            this.shapeContainer2.TabStop = false;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_aceptar.Image = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.Image")));
            this.btn_aceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(200, 162);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(72, 25);
            this.btn_aceptar.TabIndex = 116;
            this.btn_aceptar.Text = "&Aceptar";
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // Frm_tarjetas
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(218)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 190);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_limpiar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_tarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Tarjetas";
            this.Load += new System.EventHandler(this.Frm_tarjetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glueTarjeta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagelist1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.TextBox numaprovacion;
        private System.Windows.Forms.TextBox dnititular;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nametitular;
        private System.Windows.Forms.TextBox salgifcard;
        private System.Windows.Forms.TextBox importtarj;
        private DevExpress.XtraEditors.GridLookUpEdit glueTarjeta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.Utils.ImageCollection imagelist1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private DevExpress.XtraEditors.SimpleButton btn_aceptar;
    }
}