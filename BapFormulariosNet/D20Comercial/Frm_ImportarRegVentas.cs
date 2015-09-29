using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using BapFormulariosNet.Ayudas;
using BapFormulariosNet.D20Comercial.Ayudas;
using DevExpress.XtraEditors;
using BapFormulariosNet.Seguridadlog;

//** excel
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Win32;

namespace BapFormulariosNet.D20Comercial
{
    public partial class Frm_ImportarRegVentas : PlantillaDC
    {
        DataTable Tabla = new DataTable();
        DataTable DetFacturacion = new DataTable();
        DataTable tmptabla = new DataTable();
        private string xdiario = "1401"; //Ventas Tiendas
        private string xmes = "";
        private string xPersona = "";
        bool sw_load = true;

        public Frm_ImportarRegVentas()
        {
            InitializeComponent();
        }

        private void Frm_ImportarRegVentas_Load(object sender, EventArgs e)
        {
            VariablesPublicas.PintaEncabezados(gridexcel);
            VariablesPublicas.PintaEncabezados(Examinar);
            btnGenAsiento.Enabled = false;
            btn_cargar.Enabled = false;
        }
        private void Frm_ImportarRegVentas_Activated(object sender, EventArgs e)
        {
            if (sw_load)
            {
                llenar_cboMes();
                spnperiodo.Text = VariablesPublicas.perianio;
                cboMes.SelectedValue = VariablesPublicas.PADL(DateTime.Now.Month.ToString(), 2, "0");
                sw_load = false;
            }
        }

        #region Meses
        private void llenar_cboMes()
        {
            try
            {
                cboMes.DataSource = NewMethodMes();
                cboMes.DisplayMember = "Value";
                cboMes.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BindingSource NewMethodMes()
        {
            tb_co_mesesBL BL = new tb_co_mesesBL();
            tb_co_meses BE = new tb_co_meses();

            BE.ntipo = 1;
            DataTable table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;
                dic.Add(cell[0].ToString(), cell[0].ToString() + " - " + cell[1].ToString());
                cell = null;
            }
            binding.DataSource = dic;
            return binding;
        }
        #endregion

        private void btn_importar_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream = null;

                System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Title = "Importar Datos";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Todos los archivos (*.xlsx)|*.xlsx|(*.xls)|*.xls";
                //openFileDialog1.Filter = "Excel Files|*.*";
                openFileDialog1.FilterIndex = 1;
                //openFileDialog1.Multiselect = false;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            txt_direccion.Text = openFileDialog1.FileName;

                            var excel = new Excel.Application();
                            Excel.Workbook librodetrabajo = excel.Workbooks.Open(txt_direccion.Text);
                            foreach (Excel.Worksheet hojas in librodetrabajo.Sheets)
                            {
                                lista.Items.Add(hojas.Name);
                            }
                            excel.Quit();
                        }
                    }
                }
                btn_cargar.Enabled = lista.Items.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error !!!", ex);
            }
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            //Carga1();
            Carga2();
            Sumar();
            btnGenAsiento.Enabled = Examinar.RowCount > 0 ? true : false;
        }

        private void Carga1()
        {
            try
            {
                OleDbConnection oConn = new OleDbConnection();
                OleDbCommand oCmd = new OleDbCommand();
                OleDbDataAdapter oDa = new OleDbDataAdapter();
                DataSet oDs = new DataSet();

                //oConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_direccion.Text + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
                oConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_direccion.Text + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                //oConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=miExcel.xls"; Extended Properties= Excel 8.0";
                
                oConn.Open();
                oCmd.CommandText = "Select * from [" + lista.SelectedItem + "$]";
                oCmd.Connection = oConn;
                oDa.SelectCommand = oCmd;

                oDa.Fill(oDs);

                Tabla = oDs.Tables[0];

                gridexcel.DataSource = Tabla;

                oConn.Close();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private void Carga2()
        {
            try
            {
                OleDbConnection oConn = new OleDbConnection();
                OleDbCommand oCmd = new OleDbCommand();
                OleDbDataAdapter oDa = new OleDbDataAdapter();
                DataSet oDs = new DataSet();

                oConn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txt_direccion.Text + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
                //oConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=miExcel.xls"; Extended Properties= Excel 8.0";

                oConn.Open();
                oCmd.CommandText = "Select * from [" + lista.SelectedItem + "$]";
                oCmd.Connection = oConn;
                oDa.SelectCommand = oCmd;

                oDa.Fill(oDs);

                DetFacturacion = oDs.Tables[0];

                Examinar.DataSource = DetFacturacion;

                oConn.Close();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void Sumar()
        {
            Decimal vBaseImpo = 0;
            Decimal vMIGV = 0;
            Decimal vTotal = 0;

            int n = 0;
            for (n = 0; n <= Examinar.Rows.Count - 1; n++)
            {
                vBaseImpo = vBaseImpo + Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value);
                vMIGV = vMIGV + Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value);
                vTotal = vTotal + Convert.ToDecimal(Examinar.Rows[n].Cells["total"].Value);

                xmes = Convert.ToDateTime(Examinar.Rows[n].Cells["fechdoc"].Value).Month.ToString().PadLeft(2, '0');
            }

            txtBaseImpo.Text = vBaseImpo.ToString("###,###,###.#0");
            txtMIGV.Text = vMIGV.ToString("###,###,###.#0");
            txtTotal.Text = vTotal.ToString("###,###,###.#0");
        }

        private string UbicarCtaCte(string nmruc, string ctactename, string docuidentid, string tpperson)
        {
            clienteBL BL = new clienteBL();
            tb_cliente BE = new tb_cliente();

            string ctacte = "";

            BE.nmruc = nmruc;
            BE.ctactename = ctactename;
            BE.docuidentid = docuidentid;
            BE.tpperson = tpperson;
            BE.usuar = VariablesPublicas.Usuar;

            try
            {
                ctacte = BL.BuscarCrear(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ctacte;
        }

        private Decimal TipoCambio(DateTime fechdoc)
        {
            tipocambioBL BL = new tipocambioBL();
            tb_tipocambio BE = new tb_tipocambio();

            DataTable tabletipocamb = new DataTable();
            //decimal tipocambio =0;

            try
            {
                tabletipocamb = BL.GetOne(VariablesPublicas.EmpresaID.ToString(), fechdoc).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (tabletipocamb.Rows.Count > 0)
            {
                return Convert.ToDecimal(tabletipocamb.Rows[0]["venta"]);
            }
            else
            {
                //XtraMessageBox.Show("Resgistre el Tipo de Cambio para la fecha " + fechdoc, "Mensaje delSistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return 0;
            }
            //tipocambio = Convert.ToDecimal(table.Rows[0]["venta"]);
        }

        private String UbicarRubroId(string cuentaid)
        {
            tb_co_rubroventasBL BL = new tb_co_rubroventasBL();
            tb_co_rubroventas BE = new tb_co_rubroventas();

            DataTable table = new DataTable();
            BE.cuentaid = cuentaid;
            try
            {
                table = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return table.Rows[0]["rubroid"].ToString();
        }

        private void btnGenAsiento_Click(object sender, EventArgs e)
        {
            if (PuedeEditarEliminar("EDITAR", VariablesPublicas.PADL(xmes, 2, "0")))
            {
                if (XtraMessageBox.Show("Desea Generar la Importación del Registro de Ventas...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ImportarVentas();
                }
            }
        }
        private bool PuedeEditarEliminar(string glosamensaje, string codmes)
        {
            bool zpuede = true;
            tb_co_cierremensualesBL BL = new tb_co_cierremensualesBL();
            tb_co_cierremensuales BE = new tb_co_cierremensuales();

            BE.periano = VariablesPublicas.perianio;
            BE.moduloid = VariablesPublicas.tipocierremensualVentas;
            BE.perimes = codmes;
            tmptabla = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if ((BL.Sql_Error.Length > 0))
            {
                zpuede = false;
                //Frm_Class.ShowError(BL.Sql_Error, this);
            }
            else
            {
                if (tmptabla.Rows.Count > 0)
                {
                    if (!(Convert.ToBoolean(tmptabla.Rows[0]["status"]) == false))
                    {
                        XtraMessageBox.Show("Mes Cerrado ...Imposible " + glosamensaje.Trim(), "BapSoft - Registro de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        zpuede = false;
                    }
                }
                else
                {
                    zpuede = false;
                }
            }
            return zpuede;
        }

        private void DeleteVentasImportadas()
        {
            tb_co_VentasBL BL = new tb_co_VentasBL();
            tb_co_Ventas BE = new tb_co_Ventas();
            BE.perianio = VariablesPublicas.perianio;
            BE.perimes = VariablesPublicas.PADL(xmes, 2, "0");
            BE.moduloid = VariablesDominio.VarVentas.Moduloid;
            BE.local = VariablesDominio.VarVentas.Local;
            BE.diarioid = xdiario; 
            try
            {
                BL.DELETE_ImportaExcel(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ImportarVentas()
        {
            seguridadlog();
            DeleteVentasImportadas();

            string message;
            string caption = "Mensaje del Sistema";
            string cuentax = "7010102";

            // Forzar a grabar si pulsa el boton sin finalizar edicion del grid
            if (Examinar.IsCurrentCellInEditMode)
            {
                Examinar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            int n = 0; //int xItem = 0; 
            int xMax = 0;
            Progreso.Maximum = Examinar.Rows.Count;
            Progreso.Value = 0;
            for (n = 0; n <= Examinar.Rows.Count - 1; n++)
            {
                //xItem = 1;
                xMax = 1;
                #region ** Númeracion **Ingreso Ventas Cabecera***
                // Variables de Cabecera
                tb_co_VentasBL BL = new tb_co_VentasBL();
                tb_co_Ventas BE = new tb_co_Ventas();

                // Variables para Detalle
                tb_co_Ventas.Item Detalle = new tb_co_Ventas.Item();
                List<tb_co_Ventas.Item> ListaItems = new List<tb_co_Ventas.Item>();

                //string activo = "0"; //Activo
                //string anulad = "9"; //Anulado
                string xMoneda = Examinar.Rows[n].Cells["moneda"].Value.ToString().Trim();

                //caso venta
                BE.perianio = VariablesPublicas.perianio.Trim();
                BE.perimes = VariablesPublicas.PADL(xmes, 2, "0");
                BE.moduloid = VariablesDominio.VarVentas.Moduloid;
                BE.local = VariablesDominio.VarVentas.Local;
                BE.diarioid = xdiario; //Registro de Ventas Tiendas
                BE.asiento = VariablesPublicas.PADL(Convert.ToString(n + 1), 6, "0");

                BE.origen = "01"; //Ventas Nacionales
                BE.status = Examinar.Rows[n].Cells["status"].Value.ToString().Trim();
                BE.tipdoc = VariablesPublicas.PADL(Examinar.Rows[n].Cells["tipdoc"].Value.ToString().Trim(), 2, "0");
                BE.serdoc = VariablesPublicas.PADL(Examinar.Rows[n].Cells["serdoc"].Value.ToString().Trim(), 4, "0");
                BE.numdoc = VariablesPublicas.PADL(Examinar.Rows[n].Cells["numdoc"].Value.ToString().Trim(), 10, "0");
                if (Examinar.Rows[n].Cells["nmruc"].Value.ToString().Trim().Length == VariablesPublicas.NmrucDigitos)
                {
                    if (Equivalencias.Left(Examinar.Rows[n].Cells["nmruc"].Value.ToString().Trim(), 1) == "1")
                    { xPersona = "01"; }
                    else
                    { xPersona = "02"; }
                }
                else
                { xPersona = "01"; }
                BE.tiperson = xPersona;
                BE.tipdid = Examinar.Rows[n].Cells["tipdid"].Value.ToString().Trim();
                BE.nmruc = Examinar.Rows[n].Cells["nmruc"].Value.ToString().Trim();
                BE.ctactename = Examinar.Rows[n].Cells["ctactename"].Value.ToString().Trim().ToUpper();
                BE.ctacte = UbicarCtaCte(BE.nmruc, BE.ctactename, BE.tipdid, BE.tiperson);
                BE.direc = "";
                BE.ubige = "";

                BE.fechdoc = Convert.ToDateTime(Examinar.Rows[n].Cells["fechdoc"].Value);
                BE.fechvcto = Convert.ToDateTime(Examinar.Rows[n].Cells["fechdoc"].Value);

                BE.condicionvta = "";

                if (TipoCambio(Convert.ToDateTime(Examinar.Rows[n].Cells["fechdoc"].Value)) > 0)
                {
                    BE.tipcamb = TipoCambio(Convert.ToDateTime(Examinar.Rows[n].Cells["fechdoc"].Value));
                }
                else
                {
                    int SwConfirmacion = 1;
                    bool sw_prosigue = true;
                    if (SwConfirmacion == 1)
                    {
                        sw_prosigue = (XtraMessageBox.Show(this, "Resgistre el Tipo de Cambio para la fecha " + BE.fechdoc + "\r" 
                                        + "Asiento: " + BE.perimes + BE.asiento + "  Comprobante: " + BE.tipdoc + " - " + BE.serdoc + "-" + BE.numdoc + "\r"
                                        + "Cliente: " + BE.nmruc + " - " + BE.ctactename + "\r"
                                        + "\r"
                                        + "Desea Cancelar la Importación del Registro de Ventas ?", "Mensaje del Sistema",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
                    }
                    else
                    {
                        sw_prosigue = true;
                    }
                    if (sw_prosigue)
                    {
                        return;
                    }
                }
                //BE.tipcamb = TipoCambio(Convert.ToDateTime(Examinar.Rows[n].Cells["fechdoc"].Value));
                
                BE.moneda = Examinar.Rows[n].Cells["moneda"].Value.ToString().Trim();
                BE.ordencompra = "";

                //Detracciones             
                BE.detraccionid = "";
                BE.porcdetraccion = 0;
                BE.nctadetraccion = "";
                BE.condicionpago = (Examinar.Rows[n].Cells["condicionpago"].Value == null ? "" : Examinar.Rows[n].Cells["condicionpago"].Value.ToString().Trim());

                //BE.glosa = (BE.status == "0" ? Examinar.Rows[n].Cells["glosa"].Value.ToString().Trim() : "ANULADO");
                //BE.glosa = (Examinar.Rows[n].Cells["glosa"].Value.ToString().Trim() == "ANULADO" & BE.status == "0" ? Examinar.Rows[n].Cells["glosa"].Value.ToString().Trim() : "ANULADO");
                BE.glosa = (BE.status == "0" ? "VENTAS" : "ANULADO");

                //if (Examinar.Rows[n].Cells["condicionpago"].Value == null)
                //{
                //    BE.tipoventa = (Examinar.Rows[n].Cells["moneda"].Value.ToString().Trim() == "1" ? "02" : "05");
                //    //02= Crédito en Soles  05=Crédito en Dólares
                //}
                //else 
                if (BE.condicionpago.ToString().Trim() == "001")
                {
                    BE.tipoventa = "49";
                    //49= Ventas al Contado Cta. 1010101
                }
                else //if (Examinar.Rows[n].Cells["condicionpago"].Value.ToString().Trim() == "002")
                {
                    BE.tipoventa = (Examinar.Rows[n].Cells["moneda"].Value.ToString().Trim() == "1" ? "02" : "05");
                    //02= Crédito en Soles  05=Crédito en Dólares
                }
                //BE.tipoventa = (Examinar.Rows[n].Cells["moneda"].Value.ToString().Trim() == "1" ? "02" : "05");

                //1. cuando hay bimp>0 y inafec>0
                if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                {
                    BE.afectoigvid = "3";
                }
                else if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                {
                    BE.afectoigvid = "2";
                }
                else if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                {
                    BE.afectoigvid = "1";
                }
                else if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                {
                    BE.afectoigvid = "1";
                }
                //BE.afectoigvid = Examinar.Rows[n].Cells["afectoigvid"].Value.ToString();

                //datos documento de referencia
                BE.tipref = (BE.tipdoc == "07" ? VariablesPublicas.PADL(Examinar.Rows[n].Cells["tipref"].Value.ToString().Trim(), 2, "0") : "");
                BE.serref = (BE.tipdoc == "07" ? VariablesPublicas.PADL(Examinar.Rows[n].Cells["serref"].Value.ToString().Trim(), 4, "0") : "");
                BE.numref = (BE.tipdoc == "07" ? VariablesPublicas.PADL(Examinar.Rows[n].Cells["numref"].Value.ToString().Trim(), 10, "0") : "");
                try { BE.fechref = Convert.ToDateTime(Examinar.Rows[n].Cells["fechref"].Value); }
                catch { BE.fechref = Convert.ToDateTime("01/01/1900"); }
                //Aduanas
                BE.aduanaid = "";
                BE.aniodua = "";
                BE.numdua = "";
                BE.valorfobdua = 0;
                BE.fechembdua = Convert.ToDateTime("01/01/1900");
                BE.fechreguldua = Convert.ToDateTime("01/01/1900");
                BE.tipoexportid = "";

                //BE.afectoigv = (Examinar.Rows[n].Cells["afectoigvid"].Value.ToString().Trim() == "1" ? true : false);
                BE.afectoigv = (BE.afectoigvid == "1" ? true : false);
                BE.incprec = false;
                BE.afectretencion = false;
                BE.terminovta = "";
                BE.dpais = "";
                BE.embarcador = "";
                BE.cartacredito = "";
                BE.viaembarque = "";
                BE.referencia = "";

                BE.bultos = "";
                BE.pesoneto = 0;
                BE.pesobruto = 0;

                switch (xMoneda)
                {
                    case "1":
                        BE.bruto1 = Math.Round(Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value)) + Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value)),2);
                        BE.dscto1 = 0;
                        BE.valorventa1 = Math.Round(Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value)) + Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value)),2);
                        BE.igv1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value));
                        BE.total1 = Math.Round(Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value)) + Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value)) + Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value)),2);
                        if (BE.tipcamb > 0)
                        {
                            BE.bruto2 = Math.Abs(Math.Round(BE.bruto1 / BE.tipcamb, 2)); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) + Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) / BE.tipcamb, 2));
                            BE.dscto2 = 0;
                            BE.valorventa2 = Math.Abs(Math.Round(BE.valorventa1 / BE.tipcamb, 2)); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) + Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) / BE.tipcamb, 2));
                            BE.igv2 = Math.Abs(Math.Round(BE.igv1 / BE.tipcamb, 2)); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value) / BE.tipcamb, 2));
                            BE.total2 = Math.Abs(Math.Round(BE.valorventa2 + BE.igv2, 2));

                            BE.valorventa2 = Math.Abs(Math.Round(BE.valorventa2, 2));
                            BE.igv2 = Math.Abs(Math.Round(BE.igv2, 2));
                            BE.total2 = Math.Abs(Math.Round(BE.total2, 2));
                        }
                        break;
                    case "2":
                        BE.bruto2 = Math.Round(Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value)) + Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value)),2);
                        BE.dscto2 = 0;
                        BE.valorventa2 = Math.Round(Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value)) + Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value)),2);
                        BE.igv2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value));
                        BE.total2 = Math.Abs(Math.Round(BE.valorventa2 + BE.igv2, 2));
                        if (BE.tipcamb > 0)
                        {
                            BE.bruto1 = Math.Abs(Math.Round(BE.bruto2 * BE.tipcamb, 2)); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) + Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) * BE.tipcamb, 2));
                            BE.dscto1 = 0;
                            BE.valorventa1 = Math.Abs(Math.Round(BE.bruto2 * BE.tipcamb, 2)); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) + Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) * BE.tipcamb, 2));
                            BE.igv1 = Math.Abs(Math.Round(BE.bruto2 * BE.tipcamb, 2)); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value) * BE.tipcamb, 2));
                            BE.total1 = Math.Abs(Math.Round(BE.valorventa1 + BE.igv1, 2));

                            BE.valorventa1 = Math.Abs(Math.Round(BE.valorventa1, 2));
                            BE.igv1 = Math.Abs(Math.Round(BE.igv1, 2));
                            BE.total1 = Math.Abs(Math.Round(BE.total1, 2));
                        }
                        break;
                }
                BE.valorventa1 = BE.valorventa1 + (BE.total1 - (BE.valorventa1 + BE.igv1)); // S/.
                BE.valorventa2 = BE.valorventa2 + (BE.total2 - (BE.valorventa2 + BE.igv2)); // US$

                BE.pdscto = 0;
                BE.pigv = Convert.ToDecimal(Examinar.Rows[n].Cells["pigv"].Value);
                BE.tienda = "";
                BE.ndias = 0;
                BE.vendedorid = (Examinar.Rows[n].Cells["vendedorid"].Value == null ? "" : Examinar.Rows[n].Cells["vendedorid"].Value.ToString().Trim());
                BE.porcvta = 0;
                BE.porcefect = 0;
                BE.vinculante = "I";
                BE.usuar = VariablesPublicas.Usuar.Trim();
                BE.maqreg = Examinar.Rows[n].Cells["maqreg"].Value.ToString().Trim();
                BE.numdocfinal = (Examinar.Rows[n].Cells["numdocfinal"].Value.ToString().Trim().Length > 0 ? VariablesPublicas.PADL(Examinar.Rows[n].Cells["numdocfinal"].Value.ToString().Trim(), 10, "0") : "");
                BE.estabsunat = Examinar.Rows[n].Cells["estabsunat"].Value.ToString().Trim();

                #endregion

                #region **** Ingreso Ventas Detalle***
                if ((Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value == null ? 0 : Examinar.Rows[n].Cells["inafecto"].Value) > 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value == null ? 0 : Examinar.Rows[n].Cells["baseimpo"].Value) > 0))
                {
                    xMax = 2;
                }

                for (int i = 0; i < xMax; i++)
                {
                    Detalle = new tb_co_Ventas.Item();

                    Detalle.perianio = VariablesPublicas.perianio;
                    Detalle.perimes = BE.perimes;
                    Detalle.moduloid = VariablesDominio.VarVentas.Moduloid;
                    Detalle.local = VariablesDominio.VarVentas.Local;
                    Detalle.diarioid = BE.diarioid;
                    Detalle.asiento = BE.asiento;

                    //datos documento cabecera importante [todos]
                    Detalle.tipdoc = BE.tipdoc;
                    Detalle.serdoc = BE.serdoc;
                    Detalle.numdoc = BE.numdoc;
                    Detalle.fechdoc = Convert.ToDateTime(BE.fechdoc);
                    Detalle.fechvcto = Convert.ToDateTime(BE.fechdoc);

                    //datos de cliente o proveedor
                    Detalle.nmruc = BE.nmruc;
                    Detalle.ctactename = BE.ctactename;
                    //accion del alamacen dependiendo del tipo de documento
                    Detalle.almacaccionid = "";

                    Detalle.status = BE.status;
                    //datos documento de referencia
                    Detalle.tipref = BE.tipref;
                    Detalle.serref = BE.serref;
                    Detalle.numref = BE.numref;
                    Detalle.fechref = Convert.ToDateTime(BE.fechref);

                    //datos calculados de detalle de movimiento obtenidos de memoria
                    Detalle.items = "";
                    //Detalle.asientoitems = item.ToString().PadLeft(5, '0');
                    Detalle.asientoitems = VariablesPublicas.PADL(Convert.ToString(i + 1), 5, "0");
                    //Detalle.asientoitems = VariablesPublicas.PADL(Convert.ToString(n + 1), 5, "0");

                    //1. cuando hay bimp>0 y inafec>0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                    {
                        if (i == 0)
                        {
                            Detalle.rubroid = UbicarRubroId(Examinar.Rows[n].Cells["cuentaid"].Value.ToString().Trim()); 
                        }
                        else
                        {
                            Detalle.rubroid = UbicarRubroId(cuentax); 
                        }
                    }

                    //2. cuando bimp=0 y inafec>0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                    {
                        if (i == 0)
                            Detalle.rubroid = UbicarRubroId(cuentax); 
                    }
                    //3. cuando bimp>0 y inafec=0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                    {
                        if (i == 0)
                            Detalle.rubroid = UbicarRubroId(Examinar.Rows[n].Cells["cuentaid"].Value.ToString().Trim()); 
                    }
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                    {
                        Detalle.rubroid = UbicarRubroId(Examinar.Rows[n].Cells["cuentaid"].Value.ToString().Trim()); 
                    }
                    //Detalle.rubroid = UbicarRubroId(Examinar.Rows[n].Cells["cuentaid"].Value.ToString().Trim()); 
                    //"1001"; //Ventas de Mercaderías Terceros - Mercado Nacional

                    Detalle.tippedido = "";
                    Detalle.serpedido = "";
                    Detalle.numpedido = "";
                    Detalle.tipOp = "";
                    Detalle.serOp = "";
                    Detalle.numOp = "";
                    Detalle.productid = "";
                    Detalle.productname = "";
                    Detalle.tallacolor = "";
                    Detalle.unidmedidaid = "";
                    Detalle.cantidad = 1;                  

                    switch (xMoneda)
                    {
                        case "1":
                            //1. cuando hay bimp>0 y inafec>0
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                                && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                            {
                                if (i == 0)
                                {
                                    Detalle.precunit1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                    Detalle.bruto1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                    Detalle.valorventa1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                }
                                else
                                {
                                    Detalle.precunit1 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                    Detalle.bruto1 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                    Detalle.valorventa1 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                }
                            }

                            //2. cuando bimp=0 y inafec>0
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                                && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                            {
                                if (i == 0)
                                    Detalle.precunit1 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                Detalle.bruto1 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                Detalle.valorventa1 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                            }
                            //3. cuando bimp>0 y inafec=0
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                                && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                            {
                                if (i == 0)
                                    Detalle.precunit1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.bruto1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.valorventa1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            }
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                            && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                            {
                                Detalle.precunit1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.bruto1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.valorventa1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            }
                            //Detalle.precunit1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            //Detalle.bruto1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            Detalle.dscto1 = 0;
                            //Detalle.valorventa1 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            Detalle.igv1 = (i == 0 ? Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value)) : 0);
                            Detalle.total1 = Math.Abs(Math.Round(Detalle.valorventa1 + Detalle.igv1, 2));
                            if ((BE.tipcamb > 0))
                            {
                                Detalle.precunit2 = Math.Abs(Math.Round(Detalle.precunit1 / BE.tipcamb, 2));
                                Detalle.bruto2 = Math.Abs(Math.Round(Detalle.bruto1 / BE.tipcamb, 2));
                                Detalle.dscto2 = 0;
                                Detalle.valorventa2 = Math.Abs(Math.Round(Detalle.valorventa1 / BE.tipcamb, 2));
                                Detalle.igv2 = (i == 0 ? Math.Abs(Math.Round(Detalle.igv1 / BE.tipcamb, 2)) : 0); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value) / BE.tipcamb, 2));
                                Detalle.total2 = Math.Abs(Math.Round(Detalle.valorventa2 + Detalle.igv2, 2));
                                Detalle.valorventa2 = Math.Abs(Math.Round(Detalle.valorventa2, 2));
                                Detalle.igv2 = (i == 0 ? Math.Abs(Math.Round(Detalle.igv2, 2)) : 0);
                                Detalle.total2 = Math.Abs(Math.Round(Detalle.total2, 2));
                            }
                            break;
                        case "2":
                            //1. cuando hay bimp>0 y inafec>0
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                                && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                            {
                                if (i == 0)
                                {
                                    Detalle.precunit2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                    Detalle.bruto2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                    Detalle.valorventa2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                }
                                else
                                {
                                    Detalle.precunit2 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                    Detalle.bruto2 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                    Detalle.valorventa2 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                }
                            }
                            //2. cuando bimp=0 y inafec>0
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                                && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                            {
                                if (i == 0)
                                    Detalle.precunit2 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                Detalle.bruto2 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                                Detalle.valorventa2 = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                            }
                            //3. cuando bimp>0 y inafec=0
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                                && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                            {
                                if (i == 0)
                                    Detalle.precunit2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.bruto2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.valorventa2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            }
                            if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                            && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                            {
                                Detalle.precunit2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.bruto2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                                Detalle.valorventa2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            }
                            //Detalle.precunit2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            //Detalle.bruto2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            Detalle.dscto2 = 0;
                            //Detalle.valorventa2 = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            Detalle.igv2 = (i == 0 ? Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value.ToString())) : 0);
                            Detalle.total2 = Math.Abs(Math.Round(Detalle.valorventa2 + Detalle.igv2, 2));
                            if ((BE.tipcamb > 0))
                            {
                                Detalle.precunit1 = Math.Abs(Math.Round(Detalle.precunit2 * BE.tipcamb, 2));
                                Detalle.bruto1 = Math.Abs(Math.Round(Detalle.bruto2 * BE.tipcamb, 2));
                                Detalle.dscto1 = 0;
                                Detalle.valorventa1 = Math.Abs(Math.Round(Detalle.valorventa2 * BE.tipcamb, 2));
                                Detalle.igv1 = (i == 0 ? Math.Abs(Math.Round(Detalle.igv2 * BE.tipcamb, 2)) : 0); //Math.Abs(Math.Round(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value) * BE.tipcamb, 2));
                                Detalle.total1 = Math.Abs(Math.Round(Detalle.valorventa1 + Detalle.igv1, 2));
                                Detalle.valorventa1 = Math.Abs(Math.Round(Detalle.valorventa1, 2));
                                Detalle.igv1 = (i == 0 ? Math.Abs(Math.Round(Detalle.igv1, 2)) : 0);
                                Detalle.total1 = Math.Abs(Math.Round(Detalle.total1, 2));
                            }
                            break;
                    }

                    Detalle.pdscto = 0;
                    Detalle.pigv = Convert.ToDecimal(Examinar.Rows[n].Cells["pigv"].Value);
                    Detalle.tipguia = "";
                    Detalle.serguia = "";
                    Detalle.numguia = "";

                    //1. cuando hay bimp>0 y inafec>0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                    {
                        if (i == 0)
                            Detalle.afectoigvid = "1";
                        else
                            Detalle.afectoigvid = "2";
                    }

                    //2. cuando bimp=0 y inafec>0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                    {
                        if (i == 0)
                            Detalle.afectoigvid = "2";
                        //else
                        //    Detalle.tipimptoid = "4";
                    }
                    //3. cuando bimp>0 y inafec=0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                    {
                        if (i == 0)
                            Detalle.afectoigvid = "1";
                        //else
                        //    Detalle.tipimptoid = "4";
                    }
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                    {
                        Detalle.afectoigvid = "1";
                    }
                    //Detalle.afectoigvid = Examinar.Rows[n].Cells["afectoigvid"].Value.ToString();
                    Detalle.incprec = false;
                    Detalle.vendedorid = (Examinar.Rows[n].Cells["vendedorid"].Value == null ? "" : Examinar.Rows[n].Cells["vendedorid"].Value.ToString().Trim());
                    Detalle.cencosid = (Examinar.Rows[n].Cells["cencosid"].Value == null ? "" : Examinar.Rows[n].Cells["cencosid"].Value.ToString().Trim());

                    //Detalle.glosa = (BE.status == "0" ? Examinar.Rows[n].Cells["glosa"].Value.ToString() : "ANULADO");
                    Detalle.glosa = (BE.status == "0" ? "VENTAS" : "ANULADO");
                    Detalle.moneda = Examinar.Rows[n].Cells["moneda"].Value.ToString().Trim();
                    Detalle.tcamb = BE.tipcamb;
                    Detalle.ordencs = "";
                    Detalle.comisionvta = 0;
                    Detalle.porcvta = 0;
                    Detalle.porcefect = 0;
                    Detalle.observ1 = "";
                    Detalle.observ2 = "";
                    Detalle.observ3 = "";
                    Detalle.observ4 = "";
                    Detalle.observ5 = (Examinar.Rows[n].Cells["condicionpago"].Value == null ? "" : Examinar.Rows[n].Cells["condicionpago"].Value.ToString().Trim());

                    //datos de origen
                    //1. cuando hay bimp>0 y inafec>0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                    {
                        if (i == 0)
                        {
                            Detalle.precunit = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            Detalle.bruto = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                            Detalle.valorventa = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                        }
                        else
                        {
                            Detalle.precunit = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                            Detalle.bruto = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                            Detalle.valorventa = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                        }
                    }

                    //2. cuando bimp=0 y inafec>0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) != 0))
                    {
                        if (i == 0)
                            Detalle.precunit = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                        Detalle.bruto = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                        Detalle.valorventa = Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value.ToString());
                    }
                    //3. cuando bimp>0 y inafec=0
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) != 0)
                        && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                    {
                        if (i == 0)
                            Detalle.precunit = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                        Detalle.bruto = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                        Detalle.valorventa = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                    }
                    if ((Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value) == 0)
                    && (Convert.ToDecimal(Examinar.Rows[n].Cells["inafecto"].Value) == 0))
                    {
                        Detalle.precunit = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                        Detalle.bruto = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                        Detalle.valorventa = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                    }
                    //Detalle.precunit = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                    //Detalle.bruto = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                    Detalle.dscto = 0;
                    //Detalle.valorventa = Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["baseimpo"].Value.ToString()));
                    Detalle.igvo = (i == 0 ? Math.Abs(Convert.ToDecimal(Examinar.Rows[n].Cells["migv"].Value.ToString())) : 0);
                    Detalle.total = Math.Abs(Math.Round(Detalle.valorventa + Detalle.igvo, 2));

                    Detalle.valorventa = Detalle.valorventa + (Detalle.total - (Detalle.valorventa + Detalle.igvo)); // Origen
                    Detalle.valorventa1 = Detalle.valorventa1 + (Detalle.total1 - (Detalle.valorventa1 + Detalle.igv1)); // S/.
                    Detalle.valorventa2 = Detalle.valorventa2 + (Detalle.total2 - (Detalle.valorventa2 + Detalle.igv2)); // US$

                    Detalle.usuar = VariablesPublicas.Usuar.Trim();

                    ListaItems.Add(Detalle);
                #endregion
                }

                BE.ListaItems = ListaItems;

                #region **Save BD
                try
                {
                    BL.Insert_ImportaExcel(VariablesPublicas.EmpresaID.ToString(), BE);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                Progreso.Value += 1;
                int percent = (int)(((double)Progreso.Value / (double)Progreso.Maximum) * 100);
                Progreso.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(Progreso.Width / 2 - 10, Progreso.Height / 2 - 7));
            }
            message = "Se Terminó de Generar la Importación de Ventas ...";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Muestra el cuadro de mensaje.
            result = XtraMessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        private void seguridadlog()
        {
            string xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + xdiario + "-" + VariablesPublicas.PADL(xmes, 2, "0");           
            try
            {
                tb_co_seguridadlogBL BL = new tb_co_seguridadlogBL();
                tb_co_seguridadlog BE = new tb_co_seguridadlog();

                BE.moduloid = Name;
                BE.clave = xclave;
                BE.cuser = VariablesPublicas.Usuar;
                BE.fecha = DateTime.Now;
                BE.pc = VariablesPublicas.userip;
                BE.accion = "I";
                BE.detalle = "Importar Registro de Ventas " + String.Format("{0:dddd, MMMM d, yyyy}", BE.fecha) + " - " + xmes + " " + VariablesPublicas.Meses(xmes);

                BL.Insert(VariablesPublicas.EmpresaID.ToString(), BE);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            //if (u_n_opsel == 0)
            //{
                FrmSeguridad oform = new FrmSeguridad();
                string xclave = VariablesPublicas.EmpresaID + "/" + VariablesPublicas.perianio + "/" + xdiario + "-" + cboMes.SelectedValue.ToString();
                oform._Nombre = Name;
                oform._ClaveForm = xclave;
                oform.Owner = this;
                oform.ShowDialog();
            //}
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            sys_formulariosBL BL = new sys_formulariosBL();
            tb_sys_formulario BE = new tb_sys_formulario();
            DataTable DataFunc = new DataTable();

            BE.dominioid = VariablesPublicas.Dominioid;
            BE.moduloid = VariablesDominio.VarVentas.Moduloid;
            BE.formname = this.Name;
            DataFunc = BL.GetAll(VariablesPublicas.EmpresaID, BE).Tables[0];

            if (DataFunc.Rows.Count > 0)
            {
                //Frm_webbrowser_single frm = new Frm_webbrowser_single();
                //frm.webBrowser1.DocumentText = DataFunc.Rows[0]["formfunc"].ToString().Trim();
                //frm.ShowDialog();
            }
        }      
    }
}
