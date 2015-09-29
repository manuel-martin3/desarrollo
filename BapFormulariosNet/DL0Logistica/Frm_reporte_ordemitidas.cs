using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace BapFormulariosNet.DL0Logistica
{
    public partial class Frm_reporte_ordemitidas : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String modulo = string.Empty;
        private String local = string.Empty;
        private String PERFILID = string.Empty;
        private String ssModo = "NEW";

        public Frm_reporte_ordemitidas()
        {
            InitializeComponent();
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                fechini.Enabled = var;
                fechfin.Enabled = var;
                cboModuloID.Enabled = var;
                cboLocal.Enabled = var;
                grupoid.Enabled = var;
                gruponame.Enabled = false;
                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_excel.Enabled = false;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_accion_cancelEdicion(int confirnar)
        {
            var sw_prosigue = true;
            if (confirnar == 1)
            {
                sw_prosigue = (MessageBox.Show("Desea cancelar ingreso de datos...?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);
            }
            else
            {
                sw_prosigue = true;
            }
            if (sw_prosigue)
            {
                limpiar_documento();
                form_bloqueado(false);
                btn_nuevo.Enabled = true;
                btn_salir.Enabled = true;

                ssModo = "NEW";
            }
        }

        private void ValidaGrupo()
        {
            if (grupoid.Text.Trim().Length > 0)
            {
                var BL = new tb_me_grupoBL();
                var BE = new tb_me_grupo();
                var dt = new DataTable();

                BE.moduloid = modulo;
                BE.grupoid = grupoid.Text.Trim().PadLeft(4, '0');

                dt = BL.GetAll(EmpresaID, BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grupoid.Text = dt.Rows[0]["grupoid"].ToString().Trim();
                    gruponame.Text = dt.Rows[0]["gruponame"].ToString().Trim();
                }
                else
                {
                    grupoid.Text = string.Empty;
                    gruponame.Text = string.Empty;
                }
            }
            else
            {
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
            }
        }

        private void solo_numero_enteros(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
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

        private void solo_numero_decimal(object control, KeyPressEventArgs e)
        {
            if (((e.KeyChar) >= '0' && e.KeyChar <= '9') && !(e.KeyChar == '.'))
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
                        if (e.KeyChar == '.')
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
        }

        public bool IsNumeric(String Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static KeyEventHandler CapturarTeclaGRID
        {
            get
            {
                KeyEventHandler keypress = new KeyEventHandler(LecturaTecla);
                return keypress;
            }
        }

        private static void LecturaTecla(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                VariablesPublicas.PulsaAyudaArticulos = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F2)
            {
                VariablesPublicas.PulsaTeclaF2 = true;
                SendKeys.Send("\t");
            }
            if (e.KeyCode == Keys.F3)
            {
                VariablesPublicas.PulsaTeclaF3 = true;
                SendKeys.Send("\t");
            }
        }

        private void limpiar_documento()
        {
            try
            {
                var xFechfin = DateTime.Today;
                var xFechini = new DateTime(xFechfin.Year, xFechfin.Month, 1);

                fechini.Text = xFechini.ToShortDateString();
                fechfin.Text = xFechfin.ToShortDateString();

                cboModuloID.SelectedIndex = -1;
                cboLocal.SelectedIndex = -1;
                grupoid.Text = string.Empty;
                gruponame.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevo()
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_imprimir.Enabled = true;
            btn_excel.Enabled = true;
            btn_cancelar.Enabled = true;

            ssModo = "NEW";
        }

        private void Frm_reporte_stockrollo_Load(object sender, EventArgs e)
        {
            if (Parent.Parent.Name == "MainLogistica")
            {
                modulo = ((DL0Logistica.MainLogistica)MdiParent).moduloid;
                local = ((DL0Logistica.MainLogistica)MdiParent).local;
                PERFILID = ((DL0Logistica.MainLogistica)MdiParent).perfil;
            }

            if (Parent.Parent.Name == "MainAlmacen")
            {
                modulo = ((D60ALMACEN.MainAlmacen)MdiParent).moduloid;
                local = ((D60ALMACEN.MainAlmacen)MdiParent).local;
                PERFILID = ((D60ALMACEN.MainAlmacen)MdiParent).perfil;
            }

            limpiar_documento();
            get_cbo_modulo();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;
        }

        private void Frm_reporte_stockrollo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (btn_nuevo.Enabled)
                {
                    nuevo();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btn_cancelar.Enabled)
                {
                    form_accion_cancelEdicion(1);
                }
                else
                {
                    btn_salir_Click(sender, e);
                }
            }
        }
        private void grupoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaClientes(string.Empty);
            }
        }

        private void AyudaClientes(String lpdescrlike)
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "Ayuda Cliente/Proveedor";
                frmayuda.sqlquery = "select ctacte, ctactename, nmruc, direc from tb_cliente";
                frmayuda.sqlinner = string.Empty;
                frmayuda.sqlwhere = "where";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "CLIENTE", "RUC", "CODIGO" };
                frmayuda.columbusqueda = "ctactename,nmruc,ctacte";
                frmayuda.returndatos = "0,2,1,3";

                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeGrupo;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RecibeGrupo(String resultado1, String resultado2, String resultado3, String resultado4, String resultado5)
        {
            if (resultado1.Trim().Length > 0)
            {
                grupoid.Text = resultado1.Trim();
                gruponame.Text = resultado3.Trim();
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            form_accion_cancelEdicion(1);
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboModuloID.SelectedIndex != -1)
                {
                    var miForma = new Reportes.Frm_reportes();
                    miForma.Text = "LISTADO DE ORDENES DE COMPRAS EMITIDAS";

                    miForma.moduloid = cboModuloID.SelectedValue.ToString();
                    miForma.moduloname = cboModuloID.Text.ToString();
                    if (cboLocal.SelectedIndex != -1)
                    {
                        miForma.local = cboLocal.SelectedValue.ToString();
                        miForma.localname = cboLocal.Text.ToString();
                    }
                    else
                    {
                        miForma.localname = string.Empty;
                    }
                    miForma.grupoid = grupoid.Text.Trim();
                    miForma.gruponame = gruponame.Text.Trim();
                    miForma.fechaini = Convert.ToDateTime(fechini.Text);
                    miForma.fechafin = Convert.ToDateTime(fechfin.Text);
                    miForma.formulario = "Frm_reporte_ordemitidas";
                    miForma.Show();
                }
                else
                {
                    MessageBox.Show("Seleccione un Modulo ...!!!", "Imformacion", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void get_cbo_modulo()
        {
            try
            {
                var BL = new sys_moduloBL();
                var BE = new tb_sys_modulo();
                BE.dominioid = "60".Trim();

                var dt = new DataTable();

                dt = BL.GetAll(EmpresaID, BE).Tables[0];

                cboModuloID.DataSource = dt;
                cboModuloID.ValueMember = "moduloid";
                cboModuloID.DisplayMember = "moduloname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cboModuloID.Items.Count > 0)
            {
                get_dominio_modulo_local("60", cboModuloID.SelectedValue.ToString());
            }
        }

        private void get_dominio_modulo_local(string dominioid, string moduloid)
        {
            var BL = new usuariomodulolocalBL();
            var BE = new tb_usuariomodulolocal();
            BE.usuar = VariablesPublicas.Usuar.Trim();
            var dt = new DataTable();
            BE.dominioid = dominioid;
            BE.moduloid = moduloid;

            try
            {
                dt = BL.GetAll3(VariablesPublicas.EmpresaID, BE).Tables[0];
                cboLocal.DataSource = dt;
                cboLocal.ValueMember = "local";
                cboLocal.DisplayMember = "localname";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void OpenFile(string fileName)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
            catch
            {
                MessageBox.Show("No se puede encontrar una aplicación en el sistema adecuado para abrir el archivo con datos exportados.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboModuloID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModuloID.SelectedIndex != -1)
            {
                get_dominio_modulo_local("60", cboModuloID.SelectedValue.ToString());
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            var BL = new tb_cm_ordendecompraBL();
            var BE = new tb_cm_ordendecompra();
            var TablaOrdencompra = new DataTable();

            if (cboModuloID.SelectedIndex != -1)
            {
                BE.moduloid = cboModuloID.SelectedValue.ToString();
            }
            if (cboLocal.SelectedIndex != -1)
            {
                BE.local = cboLocal.SelectedValue.ToString();
            }
            BE.ctacte = grupoid.Text;
            BE.fechaini = Convert.ToDateTime(fechini.Text);
            BE.fechafin = Convert.ToDateTime(fechfin.Text);

            TablaOrdencompra = BL.Report_OrdEmitidasGen(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

            if (TablaOrdencompra.Rows.Count > 0)
            {
                ExportarExcel(TablaOrdencompra);
            }
        }

        private void ExportarExcel(DataTable TablapromoDet)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                oXL = new Excel.Application();
                oXL.Visible = false;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;


                oSheet.get_Range("E2", "F2").Merge();
                oSheet.Cells[2, 5] = "RELACIÓN DE ORDENES DE COMPRA" + "\n" +
                                      "CORPORACIÓN WAMA S.A.C";
                oSheet.get_Range("E2", "F2").Font.Underline = true;
                oSheet.get_Range("E2", "F2").Font.Size = 14;
                oSheet.get_Range("E2", "F2").Font.Name = "Tahoma";
                oSheet.get_Range("E2", "F2").Font.Bold = true;
                oSheet.get_Range("E2", "F2").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;

                oSheet.get_Range("A3", "D3").Merge();
                oSheet.Cells[3, 1] = "DESDE: " + fechini.Text + " - HASTA: " + fechfin.Text;
                oSheet.get_Range("A3", "D3").Font.Bold = true;
                oSheet.get_Range("A3", "D3").Font.Name = "Tahoma";
                oSheet.get_Range("A3", "D3").Font.Size = 10;
                oSheet.get_Range("A3", "D3").Font.Color = Color.White;
                oSheet.get_Range("A3", "D3").Interior.ColorIndex = 1;


                oSheet.Cells[4, 1] = "F.EMISION";
                oSheet.Cells[4, 2] = "F.ENTREGA";
                oSheet.Cells[4, 3] = "N°- O/C";
                oSheet.Cells[4, 4] = "ALMACEN";
                oSheet.Cells[4, 5] = "PROVEEDOR";
                oSheet.Cells[4, 6] = "FORMA DE PAGO";
                oSheet.Cells[4, 7] = "CODIGO";
                oSheet.Cells[4, 8] = "PRODUCTO";
                oSheet.Cells[4, 9] = "UNMED";
                oSheet.Cells[4, 10] = "MONEDA";
                oSheet.Cells[4, 11] = "CANTIDAD";
                oSheet.Cells[4, 12] = "P.UNIT";
                oSheet.Cells[4, 13] = "VALOR";
                oSheet.Cells[4, 14] = "IGV";
                oSheet.Cells[4, 15] = "TOTAL";
                oSheet.Cells[4, 16] = "OBSERVACION";

                oSheet.get_Range("A4", "P4").Font.Bold = true;
                oSheet.get_Range("A4", "P4").Font.Color = Color.White;
                oSheet.get_Range("A4", "P4").Interior.ColorIndex = 14;
                oSheet.get_Range("A4", "P4").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                var IndiceFila = 5;
                oSheet.Range["A:B"].NumberFormat = "dd/mm/yyyy;@";
                oSheet.Range["K:O"].NumberFormat = "_ * #,##0.00_ ;_ * -#,##0.00_ ;_ * -??_ ;_ @_ ";

                foreach (DataRow row in TablapromoDet.Rows)
                {
                    oSheet.Cells[IndiceFila, 01].Value = row["fechdoc"];
                    oSheet.Cells[IndiceFila, 02].Value = row["fechentrega"];
                    oSheet.Cells[IndiceFila, 03].Value = "'" + row["numdoc"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 04].Value = "'" + row["moduloname"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 05].Value = "'" + row["ctactename"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 06].Value = "'" + row["condpagoname"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 07].Value = "'" + row["productid"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 08].Value = "'" + row["productname"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 09].Value = "'" + row["sigla"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 10].Value = "'" + row["moneda"].ToString().Trim();
                    oSheet.Cells[IndiceFila, 11].Value = row["cantidad"];
                    oSheet.Cells[IndiceFila, 12].Value = row["precunit"];
                    oSheet.Cells[IndiceFila, 13].Value = row["subt"];
                    oSheet.Cells[IndiceFila, 14].Value = row["igv"];
                    oSheet.Cells[IndiceFila, 15].Value = row["tot"];
                    oSheet.Cells[IndiceFila, 16].Value = "'" + row["glosa"].ToString().Trim();
                    IndiceFila++;
                }

                oRng = oSheet.get_Range("A4", "P4");
                oRng.EntireColumn.AutoFit();

                oSheet.Cells[5, 5].Select();
                oXL.ActiveWindow.FreezePanes = true;

                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception ex)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, ex.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, ex.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
}
