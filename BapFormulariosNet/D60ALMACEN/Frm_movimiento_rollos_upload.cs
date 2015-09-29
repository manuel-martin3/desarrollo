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

namespace BapFormulariosNet.D60ALMACEN
{
    public partial class Frm_movimiento_rollos_upload : Form
    {
        public delegate void PasaProveedorDelegate(DataTable resultado01);
        public PasaProveedorDelegate PasarTabla;
        private Thread p1;
        private StreamReader sr = null;
        private StreamReader sr2 = null;

        private String ssMode = "data";
        private Int16 filas = 0;
        public String titulo { get; set; }
        public String almacaccionid { get; set; }
        public String tipoperacionid { get; set; }
        public String moneda { get; set; }
        public String tcamb { get; set; }
        public String incprec { get; set; }
        public Decimal igv { get; set; }


        public DataTable detallemov;
        public DataTable Datrollos, Datrollos2;
        private DataRow row;
        private DataTable dataerror;
        private DataRow roweror;

        public Frm_movimiento_rollos_upload()
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



        private void cargaData1()
        {
            var xrollo = string.Empty;
            Decimal xcantidad = 0, xstocklibros = 0;
            String input2;
            Int16 i = 1;

            while ((input2 = sr2.ReadLine()) != null)
            {
                var valor = input2.Split(new char[] { ',' });

                if (!(valor.Length == 1))
                {
                    MessageBox.Show("::: NUMERO DE VALORES ERRONEO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (input2.Trim().Length == 15 || input2.Trim().Length == 16)
                {
                    xrollo = input2.Trim().ToUpper().Substring(0, 10);

                    if (Equivalencias.IsNumeric(input2.Trim().PadRight(16, '0').Substring(10, 6)))
                    {
                        if (input2.Trim().Length == 15)
                        {
                            xcantidad = Convert.ToDecimal(input2.Trim().Substring(10, 3) + "." + input2.Trim().Substring(13, 2));
                        }
                        else
                        {
                            xcantidad = Convert.ToDecimal(input2.Trim().Substring(10, 4) + "." + input2.Trim().Substring(14, 2));
                        }
                    }

                    var rowdt = Datrollos.NewRow();
                    rowdt["rollo"] = xrollo.ToString();
                    rowdt["cantidad"] = xcantidad.ToString();
                    Datrollos.Rows.Add(rowdt);
                }
                else
                {
                    roweror = dataerror.NewRow();
                    roweror["idrollo"] = input2;
                    roweror["msgdataerror"] = "Formato de Dato Incorrecto. !";
                    dataerror.Rows.Add(roweror);
                }
            }

            sr2.Close();

            var szColumns = new String[Datrollos.Columns.Count];
            for (var index = 0; index < Datrollos.Columns.Count; index++)
            {
                szColumns[index] = Datrollos.Columns[index].ColumnName;
            }
            Datrollos = Datrollos.DefaultView.ToTable(true, szColumns);

            var BL = new tb_ta_prodrolloBL();
            var BE = new tb_ta_prodrollo();
            var DT = new DataTable();
            foreach (DataRow fila in Datrollos.Rows)
            {
                BE.local = VariablesPublicas.Local.Trim();
                BE.rollo = fila["rollo"].ToString();
                var xstockfisico = Convert.ToDecimal(fila["cantidad"].ToString());

                DT = BL.GetAll_stock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DT.Rows.Count > 0)
                {
                    var rowdt = detallemov.NewRow();
                    rowdt["rollo"] = DT.Rows[0]["rollo"].ToString();
                    rowdt["productid"] = DT.Rows[0]["productid"].ToString();
                    rowdt["productname"] = DT.Rows[0]["productname"].ToString();
                    xstocklibros = Convert.ToDecimal(DT.Rows[0]["stocklibros"].ToString());
                    rowdt["stocklibros"] = Convert.ToDecimal(DT.Rows[0]["stocklibros"].ToString());
                    rowdt["stockfisico"] = xstockfisico;
                    rowdt["diferencia"] = Convert.ToDecimal(xstocklibros - xstockfisico);
                    detallemov.Rows.Add(rowdt);

                    Thread.Sleep(1);
                    Int16 percent = i;
                    RefreshProgress(percent);
                    i++;
                }
            }
            Refresh_gridgeneral(detallemov);
            Refresh_controles();
        }



        private void cargaData2()
        {
            var xprodrollo = string.Empty;
            Decimal xcantidad = 0, xpreciorollo = 0, xprecventa = 0, xcostoultimo = 0, xcostoprom = 0, txtvalor = 0, xprecunit = 0, xtotimp = 0;
            String input;
            Int16 i = 1;
            while ((input = sr.ReadLine()) != null)
            {
                var DT = new DataTable();
                var BL = new tb_ta_prodrolloBL();
                var BE = new tb_ta_prodrollo();

                var valores = input.Split(new char[] { ',' });

                if (!(valores.Length == 2))
                {
                    MessageBox.Show("::: NUMERO DE VALORES ERRONEO !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                xprodrollo = valores[0].Substring(0, 10);
                xprecunit = Convert.ToDecimal(valores[1].ToString());
                if (valores[0].Trim().Length == 15)
                {
                    xcantidad = Convert.ToDecimal(input.Trim().Substring(10, 3) + "." + input.Trim().Substring(13, 2));
                }
                else
                {
                    xcantidad = Convert.ToDecimal(input.Trim().Substring(10, 4) + "." + input.Trim().Substring(14, 2));
                }


                BE.local = VariablesPublicas.Local.Trim();
                BE.rollo = xprodrollo;
                DT = BL.GetAll_Localstock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DT.Rows.Count > 0)
                {
                    DT.Rows[0]["productid"].ToString();

                    if (Equivalencias.IsNumeric(valores[0].Trim().PadRight(16, '0').Substring(10, 6)))
                    {
                        if (almacaccionid.Trim().Substring(0, 1) == "2")
                        {
                            xpreciorollo = Convert.ToDecimal(DT.Rows[0]["precventa"]);
                            xprecventa = Convert.ToDecimal(DT.Rows[0]["precventa"].ToString().PadLeft(1, '0'));
                            xcostoprom = Convert.ToDecimal(DT.Rows[0]["costopromed"].ToString().Trim().PadLeft(1, '0'));
                        }
                        else
                        {
                            xpreciorollo = Convert.ToDecimal(DT.Rows[0]["costoultimo"]);
                            xcostoultimo = Convert.ToDecimal(DT.Rows[0]["costoultimo"].ToString().PadLeft(1, '0'));
                        }

                        if (preciorollo.Text.Trim().Length > 0 & Equivalencias.IsNumeric(preciorollo.Text.Trim()))
                        {
                            xpreciorollo = Convert.ToDecimal(preciorollo.Text);
                            if (moneda == "$")
                            {
                                txtvalor = xpreciorollo * Convert.ToDecimal(tcamb.Trim());
                            }
                            else
                            {
                                txtvalor = xpreciorollo;
                            }
                        }
                        else
                        {
                            txtvalor = xpreciorollo;
                        }

                        if (incprec == "S")
                        {
                            xtotimp = Math.Round((xcantidad * xprecunit) * (igv / (100 + igv)), 2);
                        }
                        else
                        {
                            xtotimp = Math.Round((xcantidad * xprecunit) * (igv / 100), 2);
                        }

                        if (tipoperacionid.Trim() == "02" && Convert.ToDecimal(DT.Rows[0]["rollovaloractual"].ToString().Trim().PadLeft(1, '0')) > 0)
                        {
                            xprecunit = Convert.ToDecimal(DT.Rows[0]["rollovaloractual"].ToString().Trim().PadLeft(1, '0'));
                            txtvalor = xprecunit * Convert.ToDecimal(tcamb.Trim());
                        }

                        var datosfila = detallemov.Select("[rollo]='" + xprodrollo + "'");
                        if (datosfila.Count() == 0)
                        {
                            row = detallemov.NewRow();
                            string xitems;

                            try
                            {
                                xitems = (string)detallemov.Compute("Max(items)", "true");
                            }
                            catch
                            {
                                xitems = "0";
                            }

                            row["itemref"] = string.Empty;
                            row["items"] = (Convert.ToInt16(xitems) + 1).ToString().PadLeft(5, '0');
                            row["productid"] = DT.Rows[0]["productid"].ToString();
                            row["productname"] = DT.Rows[0]["productname"].ToString();
                            row["rollo"] = xprodrollo;
                            row["stock"] = DT.Rows[0]["rollostock"];

                            row["precventa"] = xprecventa;
                            row["costoultimo"] = xcostoultimo;
                            row["costopromed"] = xcostoprom;

                            row["valor"] = txtvalor;
                            row["importe"] = xcantidad * txtvalor;
                            row["totimpto"] = xtotimp;

                            row["cantidad"] = xcantidad;
                            row["precunit"] = xprecunit;
                            row["importfac"] = xcantidad * xprecunit;

                            row["almacaccionid"] = almacaccionid.Trim();
                            detallemov.Rows.Add(row);
                        }
                        else
                        {
                            var xfila = 0;

                            xfila = detallemov.Rows.IndexOf(datosfila[0]);

                            detallemov.Rows[xfila]["productid"] = DT.Rows[0]["productid"].ToString();
                            detallemov.Rows[xfila]["productname"] = DT.Rows[0]["productname"].ToString();
                            detallemov.Rows[xfila]["rollo"] = xprodrollo;
                            detallemov.Rows[xfila]["stock"] = DT.Rows[0]["rollostock"].ToString().Trim().PadLeft(1, '0');

                            detallemov.Rows[xfila]["valor"] = txtvalor;
                            detallemov.Rows[xfila]["importe"] = xcantidad * txtvalor;
                            detallemov.Rows[xfila]["totimpto"] = xtotimp;

                            detallemov.Rows[xfila]["cantidad"] = xcantidad;
                            detallemov.Rows[xfila]["precunit"] = xprecunit;
                            detallemov.Rows[xfila]["importfac"] = xcantidad * xprecunit;

                            detallemov.Rows[xfila]["almacaccionid"] = almacaccionid.Trim().ToString();
                        }

                        Thread.Sleep(1);
                        Int16 percent = i;
                        RefreshProgress(percent);
                        i++;
                    }
                    else
                    {
                        roweror = dataerror.NewRow();
                        roweror["idrollo"] = input.Trim();
                        roweror["msgdataerror"] = "CANTIDAD en formato incorrecto !!!";
                        dataerror.Rows.Add(roweror);
                    }
                }
                else
                {
                    roweror = dataerror.NewRow();
                    roweror["idrollo"] = xprodrollo;
                    roweror["msgdataerror"] = "Codigo ROLLO no existe en tabla TA_PRODROLLO y/o TB_TA_PRODUCTOS. !";
                    dataerror.Rows.Add(roweror);
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
            Invoke(new Action(() => gridgeneral.Columns["rollo"].Visible = true));
            Invoke(new Action(() => gridgeneral.Columns["productid"].Visible = false));
            Invoke(new Action(() => gridgeneral.Columns["productname"].Visible = true));
            Invoke(new Action(() => gridgeneral.Columns["stocklibros"].Visible = true));
            Invoke(new Action(() => gridgeneral.Columns["stockfisico"].Visible = true));
            Invoke(new Action(() => gridgeneral.Columns["diferencia"].Visible = true));

            BeginInvoke(new Action(delegate
            {
                gridgeneral.Refresh();
            }));
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


            detallemov = new DataTable();
            detallemov.Columns.Add(new DataColumn("rollo".ToString(), typeof(String)));
            detallemov.Columns.Add(new DataColumn("productid".ToString(), typeof(String)));
            detallemov.Columns.Add(new DataColumn("productname".ToString(), typeof(String)));
            detallemov.Columns.Add(new DataColumn("stocklibros".ToString(), typeof(Decimal)));
            detallemov.Columns.Add(new DataColumn("stockfisico".ToString(), typeof(Decimal)));
            detallemov.Columns.Add(new DataColumn("diferencia".ToString(), typeof(Decimal)));


            Datrollos = new DataTable();
            Datrollos.Columns.Add(new DataColumn("rollo".ToString(), typeof(String)));
            Datrollos.Columns.Add(new DataColumn("cantidad".ToString(), typeof(Decimal)));

            Datrollos2 = new DataTable();
            Datrollos2.Columns.Add(new DataColumn("rollo".ToString(), typeof(String)));
            Datrollos2.Columns.Add(new DataColumn("cantidad".ToString(), typeof(Decimal)));
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
                openFileDialog1.Title = "Subir Rollos para almacen de telas";
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
                            sr2 = new System.IO.StreamReader(openFileDialog1.FileName);
                            enabled_controles(false);
                            if (cboTipodata.SelectedIndex == 0)
                            {
                                p1 = new Thread(new ThreadStart(cargaData1));
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
                gridgeneral.Columns["rollo"].Visible = false;
                gridgeneral.Columns["productname"].Visible = false;
                gridgeneral.Columns["stocklibros"].Visible = false;
                gridgeneral.Columns["stockfisico"].Visible = false;
                gridgeneral.Columns["diferencia"].Visible = false;
                gridgeneral.Columns["fechatoma"].Visible = false;
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
    }
}
