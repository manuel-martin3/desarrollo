namespace BapFormulariosNet.D60Tienda.Popup
{
    partial class Frm_barcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cod_productid = new System.Windows.Forms.TextBox();
            this.dgb_listaproductos = new System.Windows.Forms.DataGridView();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tot_items = new System.Windows.Forms.TextBox();
            this.tot_importe = new System.Windows.Forms.TextBox();
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            this.xtraUserControl2 = new DevExpress.XtraEditors.XtraUserControl();
            this.TooMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preclist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgb_listaproductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CodBar:";
            // 
            // cod_productid
            // 
            this.cod_productid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cod_productid.Location = new System.Drawing.Point(71, 8);
            this.cod_productid.MaxLength = 13;
            this.cod_productid.Name = "cod_productid";
            this.cod_productid.Size = new System.Drawing.Size(145, 20);
            this.cod_productid.TabIndex = 1;
            this.cod_productid.TextChanged += new System.EventHandler(this.cod_productid_TextChanged);
            // 
            // dgb_listaproductos
            // 
            this.dgb_listaproductos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgb_listaproductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgb_listaproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgb_listaproductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productid,
            this.productname,
            this.preclist});
            this.dgb_listaproductos.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgb_listaproductos.Location = new System.Drawing.Point(1, 34);
            this.dgb_listaproductos.Name = "dgb_listaproductos";
            this.dgb_listaproductos.RowHeadersVisible = false;
            this.dgb_listaproductos.Size = new System.Drawing.Size(410, 150);
            this.dgb_listaproductos.TabIndex = 0;
            this.dgb_listaproductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgb_listaproductos_CellEnter);
            // 
            // btn_del
            // 
            this.btn_del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del.Image = global::BapFormulariosNet.Properties.Resources.go_remove1;
            this.btn_del.Location = new System.Drawing.Point(414, 40);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(21, 21);
            this.btn_del.TabIndex = 93;
            this.TooMensaje.SetToolTip(this.btn_del, "Quitar Productos");
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add
            // 
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Image = global::BapFormulariosNet.Properties.Resources.btn_signup20;
            this.btn_add.Location = new System.Drawing.Point(412, 67);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(25, 21);
            this.btn_add.TabIndex = 92;
            this.TooMensaje.SetToolTip(this.btn_add, "Cargar Productos");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Total Items:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(218, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Total Importe:";
            // 
            // tot_items
            // 
            this.tot_items.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_items.Location = new System.Drawing.Point(81, 189);
            this.tot_items.Name = "tot_items";
            this.tot_items.Size = new System.Drawing.Size(51, 20);
            this.tot_items.TabIndex = 96;
            this.tot_items.Text = "0";
            this.tot_items.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tot_importe
            // 
            this.tot_importe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_importe.Location = new System.Drawing.Point(307, 189);
            this.tot_importe.Name = "tot_importe";
            this.tot_importe.Size = new System.Drawing.Size(93, 20);
            this.tot_importe.TabIndex = 97;
            this.tot_importe.Text = "0.00";
            this.tot_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Appearance.BackColor = System.Drawing.Color.Teal;
            this.xtraUserControl1.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.xtraUserControl1.Appearance.Options.UseBackColor = true;
            this.xtraUserControl1.Location = new System.Drawing.Point(1, 4);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(410, 27);
            this.xtraUserControl1.TabIndex = 107;
            // 
            // xtraUserControl2
            // 
            this.xtraUserControl2.Appearance.BackColor = System.Drawing.Color.Teal;
            this.xtraUserControl2.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.xtraUserControl2.Appearance.Options.UseBackColor = true;
            this.xtraUserControl2.Location = new System.Drawing.Point(2, 186);
            this.xtraUserControl2.Name = "xtraUserControl2";
            this.xtraUserControl2.Size = new System.Drawing.Size(409, 27);
            this.xtraUserControl2.TabIndex = 108;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "Codigo";
            this.productid.Name = "productid";
            this.productid.Width = 87;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.HeaderText = "Producto";
            this.productname.Name = "productname";
            this.productname.Width = 250;
            // 
            // preclist
            // 
            this.preclist.DataPropertyName = "precunit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.preclist.DefaultCellStyle = dataGridViewCellStyle2;
            this.preclist.HeaderText = "PrecList";
            this.preclist.Name = "preclist";
            this.preclist.Width = 60;
            // 
            // Frm_upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 216);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tot_importe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tot_items);
            this.Controls.Add(this.xtraUserControl2);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dgb_listaproductos);
            this.Controls.Add(this.cod_productid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xtraUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_barcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "»» Cargar Productos";
            this.Load += new System.EventHandler(this.Frm_barcode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_barcode_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgb_listaproductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cod_productid;
        private System.Windows.Forms.DataGridView dgb_listaproductos;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tot_items;
        private System.Windows.Forms.TextBox tot_importe;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl2;
        private System.Windows.Forms.ToolTip TooMensaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn preclist;
    }
}