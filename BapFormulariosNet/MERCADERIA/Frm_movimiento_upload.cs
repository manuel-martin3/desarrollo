using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.IO;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace BapFormulariosNet.MERCADERIA
{
    public partial class Frm_movimiento_upload : Form
    {
        public delegate void PasaProveedorDelegate(DataTable resultado01);
        public PasaProveedorDelegate PasarTabla;
        private Thread p1;
        private StreamReader sr = null;
        private String ssMode = "data";
        private Int16 filas = 0;
        public String titulo { get; set; }
        public String almacaccionid { get; set; }
        public String moduloid { get; set; }
        public String tipoperacionid { get; set; }
        public String moneda { get; set; }
        public String tcamb { get; set; }
        public String incprec { get; set; }
        public Decimal igv { get; set; }


        public DataTable detallemov;
        private DataRow row;
        private DataTable dataerror;

        public Frm_movimiento_upload()
        {
            InitializeComponent();
        }

        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' & e.KeyChar <= '9') & !(e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete && !(e.KeyChar == '.'))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.KeyChar) == (char)Keys.Tab)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("\t");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void datos_seleccionados()
        {
            if ((gridgeneral.CurrentRow != null))
            {
                if ((PasarTabla != null))
                {
                    PasarTabla(detallemov);
                }
                Close();
            }
        }

        private void cargaData2()
        {
            var xproductid = string.Empty;
            Decimal xcantidad = 0, xprecunit = 0;
            String input;
            Int16 i = 1;
            var xitems = 1;
            while ((input = sr.ReadLine()) != null)
            {
                var dt = new DataTable();
                var BL = new tb_cm_ordendecompradetBL();
                var BE = new tb_cm_ordendecompradet();

                var valores = input.Split(new char[] { '|' });

                if (!(valores.Length == 2))
                {
                    MessageBox.Show("::: NUMERO DE VALORES ERRONEO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                xproductid = valores[0].Substring(0, 13);
                xcantidad = Convert.ToDecimal(valores[1].ToString());

                BE.moduloid = moduloid.ToString();
                BE.productid = xproductid.ToString();
                BE.tipoperacionid = tipoperacionid.ToString();
                dt = BL.GetAll_Producto(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    xprecunit = Convert.ToDecimal(dt.Rows[0]["precunit"].ToString());

                    row = detallemov.NewRow();
                    row["items"] = (xitems).ToString().PadLeft(5, '0');
                    row["productid"] = dt.Rows[0]["productid"].ToString();
                    row["productname"] = dt.Rows[0]["productname"].ToString();

                    row["cantidad"] = xcantidad;
                    row["precunit"] = xprecunit;
                    row["importfac"] = xcantidad * xprecunit;

                    row["almacaccionid"] = almacaccionid.Trim();
                    detallemov.Rows.Add(row);

                    Thread.Sleep(1);
                    Int16 percent = i;
                    RefreshProgress(percent);
                    i++;
                    xitems++;
                }
            }
            sr.Close();
            Refresh_gridgeneral(detallemov);
            Refresh_controles();
        }



        private Int16 TotalLines(string filePath)
        {
            using (var r = new StreamReader(filePath))
            {
                Int16 i = 0;
                while (r.ReadLine() != null)
                {
                    i++;
                }
                return i;
            }
        }

        private void Stop()
        {
            if (p1 != null)
            {
                sr.Close();
                p1.Abort();
                p1 = null;
            }
        }

        public void RefreshProgress(Int16 value)
        {
            if (this == null)
            {
                return;
            }
            Invoke(new Action(() => contador.Text = value.ToString()));
        }

        public void Refresh_controles()
        {
            if (this == null)
            {
                return;
            }
            Invoke(new Action(() => preciorollo.Enabled = true));
            Invoke(new Action(() => btn_upload.Enabled = true));
            Invoke(new Action(() => btnSeleccion.Enabled = true));
            Invoke(new Action(() => btn_cerrar.Enabled = true));
            Invoke(new Action(() => btn_error.Enabled = true));
            if (dataerror.Rows.Count > 0)
            {
                Invoke(new Action(() => btn_error.Enabled = true));
            }
            else
            {
                Invoke(new Action(() => btn_error.Enabled = false));
            }
            Thread.Sleep(1500);
            Invoke(new Action(() => pl_contador.Visible = false));
        }

        public void Refresh_gridgeneral(DataTable value)
        {
            if (this == null)
            {
                return;
            }
            BeginInvoke(new Action(delegate
            {
                gridgeneral.DataSource = value;
            }));
            Invoke(new Action(() => gridgeneral.Columns["valor"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["importe"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["totimpto"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["importfac"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["almacaccionid"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["nserie"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["itemref"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["ubicacion"].Visible = false));

            BeginInvoke(new Action(delegate
            {
                gridgeneral.Refresh();
            }));
        }


        private void RefrescarControles(DataTable dt)
        {
            if (this == null)
            {
                return;
            }
            BeginInvoke(new Action(delegate
            {
                gridgeneral.DataSource = dt;
            }));
            gridgeneral.Columns["almacaccionid"].Visible = false;
            gridgeneral.Columns["unmed"].Visible = false;
            gridgeneral.Columns["valor"].Visible = false;
            gridgeneral.Columns["importe"].Visible = false;
            gridgeneral.Columns["importe"].Visible = false;
        }

        private void enabled_controles(Boolean enabled)
        {
            pl_contador.Visible = !enabled;
            btn_cancelar.Enabled = false;
            preciorollo.Enabled = enabled;
            btn_upload.Enabled = enabled;
            btnSeleccion.Enabled = enabled;
            btn_cerrar.Enabled = enabled;
            btn_error.Enabled = enabled;
        }

        private void Frm_movimiento_rollos_upload_Activated(object sender, EventArgs e)
        {
        }

        private void Frm_movimiento_rollos_upload_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;

            dataerror = new DataTable();
            dataerror.Columns.Add(new DataColumn("idrollo".ToString(), typeof(String)));
            dataerror.Columns.Add(new DataColumn("msgdataerror".ToString(), typeof(String)));

            pl_contador.Visible = false;

            cboTipodata.SelectedIndex = 0;
            GenerandoTabla();
        }

        private void Frm_movimiento_rollos_upload_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void Frm_movimiento_rollos_upload_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                var myStream = (Stream )null;
                var openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Title = "Subir Inventarios para Almacen";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            dataerror.Rows.Clear();
                            filas = TotalLines(openFileDialog1.FileName);
                            total.Text = filas.ToString();
                            sr = new System.IO.StreamReader(openFileDialog1.FileName);
                            enabled_controles(false);
                            if (cboTipodata.SelectedIndex == 0)
                            {
                                p1 = new Thread(new ThreadStart(cargaData2));
                            }
                            p1.Start();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            datos_seleccionados();
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Stop();
            Close();
        }
        private void btn_error_Click(object sender, EventArgs e)
        {
            if (ssMode == "data")
            {
                btn_error.Image = global::BapFormulariosNet.Properties.Resources.btn_check20;
                btn_error.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn_error.Location = new System.Drawing.Point(154, 12);
                btn_error.Name = "btn_error";
                btn_error.Size = new System.Drawing.Size(70, 30);
                btn_error.TabIndex = 2;
                btn_error.Text = "&Listado";
                btn_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                btn_error.UseVisualStyleBackColor = true;

                gridgeneral.DataSource = dataerror;
                ssMode = "error";
            }
            else
            {
                btn_error.Image = global::BapFormulariosNet.Properties.Resources.btn_info;
                btn_error.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn_error.Location = new System.Drawing.Point(154, 12);
                btn_error.Name = "btn_error";
                btn_error.Size = new System.Drawing.Size(70, 30);
                btn_error.TabIndex = 2;
                btn_error.Text = "&Errores";
                btn_error.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                btn_error.UseVisualStyleBackColor = true;

                gridgeneral.DataSource = detallemov;
                gridgeneral.Columns["productid"].Visible = false;
                gridgeneral.Columns["importe"].Visible = false;
                gridgeneral.Columns["totimpto"].Visible = false;
                gridgeneral.Columns["importfac"].Visible = false;
                gridgeneral.Columns["almacaccionid"].Visible = false;
                ssMode = "data";
            }
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            var CuadroDialogo = new OpenFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xlsx";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Seleccionar Archivo";

            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var excelApp = new Excel.Application();
                    var excelBook = excelApp.Workbooks.Open(CuadroDialogo.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    var excelWorksheet = (Excel._Worksheet)excelBook.Worksheets.get_Item(1);
                    excelApp.Visible = false;

                    var x = 2;
                    while (excelWorksheet.get_Range("A" + x).Value2 != null)
                    {
                        gridgeneral.Rows.Add(excelWorksheet.get_Range("A" + x).Value2.ToString().PadLeft(3, '0'),
                                                excelWorksheet.get_Range("B" + x).Value2.ToString().PadLeft(13, '0'),
                                                excelWorksheet.get_Range("C" + x).Value2.ToString(),
                                                excelWorksheet.get_Range("D" + x).Value2.ToString(),
                                                excelWorksheet.get_Range("E" + x).Value2.ToString(),
                                                excelWorksheet.get_Range("F" + x).Value2.ToString());
                        x++;
                    }

                    excelApp.Quit();

                    CargarTablaLista();
                }
                catch (Exception sms)
                {
                    MessageBox.Show(sms.Message);
                }
            }
        }

        private void CargarTablaLista()
        {
            foreach (DataGridViewRow row in gridgeneral.Rows)
            {
                var rowdt = detallemov.NewRow();
                rowdt["items"] = Convert.ToString(row.Cells["item"].Value);
                rowdt["productid"] = Convert.ToString(row.Cells["productid"].Value);
                rowdt["productname"] = Convert.ToString(row.Cells["productname"].Value);
                rowdt["cantidad"] = Convert.ToDecimal(row.Cells["cantidad"].Value);
                rowdt["precunit"] = Convert.ToDecimal(row.Cells["precunit"].Value);
                rowdt["unmed"] = Convert.ToString(row.Cells["unmed"].Value);
                detallemov.Rows.Add(rowdt);
            }
        }

        private void GenerandoTabla()
        {
            detallemov = new DataTable("detallemov");

            detallemov.Columns.Add("items", typeof(String));
            detallemov.Columns.Add("productid", typeof(String));
            detallemov.Columns.Add("productname", typeof(String));
            detallemov.Columns.Add("cantidad", typeof(Decimal));
            detallemov.Columns["cantidad"].DefaultValue = 0;
            detallemov.Columns.Add("valor", typeof(Decimal));
            detallemov.Columns["valor"].DefaultValue = 0;
            detallemov.Columns.Add("importe", typeof(Decimal));
            detallemov.Columns["importe"].DefaultValue = 0;
            detallemov.Columns.Add("precunit", typeof(Decimal));
            detallemov.Columns["precunit"].DefaultValue = 0;
            detallemov.Columns.Add("importfac", typeof(Decimal));
            detallemov.Columns["importfac"].DefaultValue = 0;
            detallemov.Columns.Add("totimpto", typeof(Decimal));
            detallemov.Columns["totimpto"].DefaultValue = 0;
            detallemov.Columns.Add("unmed", typeof(String));
            detallemov.Columns.Add("nserie", typeof(String));
            detallemov.Columns.Add("itemref", typeof(String));
            detallemov.Columns.Add("ubicacion", typeof(String));
            detallemov.Columns.Add("almacaccionid", typeof(String));
        }
    }
}
