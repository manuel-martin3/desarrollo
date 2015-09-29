using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace BapFormulariosNet.D60ALMACEN.REPORTES
{
    public partial class Frm_reportes : Form
    {
        private DataTable DtReporte;
        public String dominioid { get; set; }
        public String moduloiddies { get; set; }
        public Int32 modcalculo { get; set; }
        public String productidold { get; set; }
        public String obs { get; set; }
        public String moduloid { get; set; }

        public String moduloname { get; set; }
        public String local { get; set; }


        public bool xdif { get; set; }

        public String localname { get; set; }
        public String formulario { get; set; }
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
        public Boolean dif { get; set; }
        public String numdoc { get; set; }
        public String lineaid { get; set; }
        public String grupoid { get; set; }
        public String subgrupoid { get; set; }
        public String subgruponame { get; set; }
        public String productid { get; set; }

        public String Produbic { get; set; }
        public String rollo { get; set; }
        public String almacaccionid { get; set; }
        public String colorid { get; set; }
        public String fechdocini { get; set; }
        public String fechdocfin { get; set; }
        public String Peranio { get; set; }
        public String fechdoc { get; set; }
        public String Mesdoini { get; set; }
        public String Mesdofin { get; set; }
        public String serop_ini { get; set; }
        public String serop_fin { get; set; }
        public String numop_ini { get; set; }
        public String numop_fin { get; set; }
        public String filtro { get; set; }
        public String productidini { get; set; }
        public String productidfin { get; set; }
        public String tip_op { get; set; }
        public String ser_op { get; set; }
        public String num_op { get; set; }
        public String cencosid { get; set; }

        public String perddnni { get; set; }

        public int operacion { get; set; }
        public String stockmayorquecero { get; set; }
        public Boolean accion { get; set; }
        public String   status { get; set; }

        public String ctactedirecc { get; set; }

        public String direcnume { get; set; }
        public String ctacte { get; set; }
        public String ctactename { get; set; }

        public ReportDocument Reporte { get; set; }

        public DataTable Table { get; set; }
        public String mottrasladointid { get; set; }
        public String procedenciaid { get; set; }
        public String productname { get; set; }
        public bool resumido { get; set; }

        public String Fechprint { get; set; }
        public String tipreporte { get; set; }


        public Frm_reportes()
        {
            InitializeComponent();
        }

        private void Frm_reportes_Activated(object sender, EventArgs e)
        {
        }

    private DataTable Movimiento(String convalor)
    {
        try
        {
            DtReporte = new DataTable("Movimientos");

            var BL = new tb_60movimientosBL();
            var BE = new tb_60movimientos();

            BE.moduloid = moduloid.Trim();
            BE.local = local.Trim();
            BE.tipodoc = tipdoc.Trim();
            BE.serdoc = serdoc.Trim();
            BE.numdoc = numdoc.Trim();
            BE.Convalor = convalor;

            DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            if (DtReporte != null)
            {
                return DtReporte;
            }
            else
            {
                return DtReporte;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

        private void active_Movimiento(String convalor)
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                if (moduloid.Trim() == "0320" && local.Trim() == "002")
                {
                    var reportemovimientos = new CR_movimiento();
                    reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "''";

                    reportemovimientos.SetDataSource(Movimiento(convalor));
                    crystalReportViewer1.ReportSource = reportemovimientos;
                    crystalReportViewer1.Show();
                }
                else
                {
                    var reportemovimientos = new CR_movimiento();
                    reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "''";

                    reportemovimientos.SetDataSource(Movimiento(convalor));
                    crystalReportViewer1.ReportSource = reportemovimientos;
                    crystalReportViewer1.Show();
                }

                if (moduloid.Trim() == "0320" && local.Trim() == "001")
                {
                    if (resumido)
                    {
                        var reportemovimientos = new CR_movimiento_rollos2();
                        reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                        reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                        reportemovimientos.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                        reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "'ROLLO'";

                        reportemovimientos.SetDataSource(Movimiento(convalor));
                        crystalReportViewer1.ReportSource = reportemovimientos;
                        crystalReportViewer1.Show();
                    }
                    else
                    {

                        var reportemovimientos = new CR_movimiento_rollos();
                        reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                        reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                        reportemovimientos.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                        reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "'ROLLO'";

                        reportemovimientos.SetDataSource(Movimiento(convalor));
                        crystalReportViewer1.ReportSource = reportemovimientos;
                        crystalReportViewer1.Show();
                    }
                }               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_Rollo2()
        {
            try
            {
                DtReporte = new DataTable("Movimientos");

                var BL = new tb_60movimientosBL();
                var BE = new tb_60movimientos();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.tipodoc = tipdoc.Trim();
                BE.serdoc = serdoc.Trim();
                BE.numdoc = numdoc.Trim();

                DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
                return DtReporte;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_Movimiento_Rollo2()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reportemovimientos = new CR_movimiento_rollos();

                reportemovimientos.PrintOptions.PrinterName = "EPSON FX-890 Ver 2.0";
                reportemovimientos.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                reportemovimientos.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)GetPaperSize("EPSON FX-890 Ver 2.0", "Credencial");

                reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                if (moduloid.Trim() == "0320")
                {
                    reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "'ROLLOS'";
                }
                else
                {
                    reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "''";
                }
                reportemovimientos.SetDataSource(Movimiento_Rollo2());
                reportemovimientos.Refresh();

                reportemovimientos.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = reportemovimientos;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Int32 GetPaperSize(String sPrinterName, String sPaperSizeName)
        {
            var docPrintDoc = new PrintDocument();
            docPrintDoc.PrinterSettings.PrinterName = sPrinterName;
            for (var i = 0; i < docPrintDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                var raw = docPrintDoc.PrinterSettings.PaperSizes[i].RawKind;
                if (docPrintDoc.PrinterSettings.PaperSizes[i].PaperName == sPaperSizeName)
                {
                    return raw;
                }
            }
            return 0;
        }

        private DataTable Movimiento_color()
        {
            try
            {
                DtReporte = new DataTable("color");

                var BL = new tb_60colorBL();
                var BE = new tb_60color();

                BE.moduloid = moduloid.Trim();

                DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        private void active_color()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reportecolor = new CR_color();

                var BL = new tb_60colorBL();
                var BE = new tb_60color();
                var dt = new DataTable();
                BE.moduloid = moduloid.ToString();
                dt = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                
                if (dt.Rows.Count > 0)
                {
                    reportecolor.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reportecolor.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reportecolor.SetDataSource(Movimiento_color());
                    crystalReportViewer1.ReportSource = reportecolor;
                    crystalReportViewer1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_linea()
        {
            try
            {
                DtReporte = new DataTable("Linea");

                var BL = new tb_60lineaBL();
                var BE = new tb_60linea();

                BE.moduloid = moduloid.Trim();

                DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void active_linea()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reportelinea = new CR_linea();

                var BL = new tb_60lineaBL();
                var BE = new tb_60linea();
                var dt = new DataTable();
                BE.moduloid = moduloid.ToString();
                dt = BL.GetAll(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    reportelinea.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reportelinea.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reportelinea.SetDataSource(Movimiento_linea());
                    crystalReportViewer1.ReportSource = reportelinea;
                    crystalReportViewer1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_grupo()
        {
            try
            {
                DtReporte = new DataTable("Grupo");

                var BL = new tb_60grupoBL();
                var BE = new tb_60grupo();

                BE.moduloid = moduloid.Trim();

                DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_grupo()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reportelinea = new CR_grupo();
                reportelinea.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reportelinea.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reportelinea.SetDataSource(Movimiento_grupo());
                crystalReportViewer1.ReportSource = reportelinea;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_subgrupo()
        {
            try
            {
                DtReporte = new DataTable("Subgrupo");

                var BL = new tb_60subgrupoBL();
                var BE = new tb_60subgrupo();

                BE.moduloid = moduloid.Trim();

                DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private void active_subgrupo()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reportesubgrupo = new CR_subgrupo();
                reportesubgrupo.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reportesubgrupo.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reportesubgrupo.SetDataSource(Movimiento_subgrupo());
                crystalReportViewer1.ReportSource = reportesubgrupo;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_producto()
        {
            try
            {
                DtReporte = new DataTable("Producto");

                var BL = new tb_60productosBL();
                var BE = new tb_60productos();

                BE.moduloid = moduloid.Trim();

                DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private void active_producto()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporteproducto = new CR_productos();
                reporteproducto.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteproducto.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteproducto.SetDataSource(Movimiento_producto());
                crystalReportViewer1.ReportSource = reporteproducto;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_rollostock()
        {
            try
            {
                DtReporte = new DataTable("Stockrollo");

                var BL = new tb_60productosBL();
                var BE = new tb_60productos();

                BE.moduloid = moduloid;
                BE.lineaid = lineaid;
                BE.grupoid = grupoid;
                BE.subgrupoid = subgrupoid;
                BE.productid = productid;
                BE.productidold = productidold;
                BE.productname = productname.ToString();
                BE.colorid = colorid;
                BE.rollo = rollo;

                BE.fechdocini = Convert.ToDateTime(fechdocini.Trim().Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Trim().Substring(0, 10));

                DtReporte = BL.GetAll_stockrollo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private void active_rollostock()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporteStockrollo = new CR_rollostock();

                reporteStockrollo.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteStockrollo.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteStockrollo.DataDefinition.FormulaFields["fechdoc"].Text = "'DE: " + fechdocini.Trim().Substring(0, 10) + "  AL:" + fechdocfin.Trim().Substring(0, 10) + "'";

                reporteStockrollo.SetDataSource(Movimiento_rollostock());
                crystalReportViewer1.ReportSource = reporteStockrollo;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_rollokardex()
        {
            try
            {
                DtReporte = new DataTable("Rollokardex");

                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();

                BE.moduloid = moduloid;
                BE.local = local;
                BE.lineaid = lineaid;
                BE.grupoid = grupoid;
                BE.subgrupoid = subgrupoid;
                BE.productid = productid;
                BE.colorid = colorid;
                BE.rollo = rollo;

                BE.fechdocini = Convert.ToDateTime(fechdocini.Trim().Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Trim().Substring(0, 10));

                if (almacaccionid.Trim().Length > 0)
                {
                    BE.almacaccionid = almacaccionid;
                }
                DtReporte = BL.GetAll_rollokardex(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_rollokardex()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporteRollokardex = new CR_rollokardex();
                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                reporteRollokardex.DataDefinition.FormulaFields["fechdoc"].Text = "'DE: " + fechdocini.Trim().Substring(0, 10) + "  AL:" + fechdocfin.Trim().Substring(0, 10) + "'";

                reporteRollokardex.SetDataSource(Movimiento_rollokardex());
                crystalReportViewer1.ReportSource = reporteRollokardex;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_productokardex_tela()
        {
            DtReporte = new DataTable("Productokardex_tela");
            try
            {
                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid;
                BE.grupoid = grupoid;
                BE.subgrupoid = subgrupoid;
                BE.productid = productid;
                BE.colorid = colorid;
                BE.rollo = rollo;
                BE.mottrasladointid = mottrasladointid;
                BE.Ubicacion = Produbic;
                BE.ctacte = ctacte;
                BE.direcnume = direcnume;
                BE.fechdocini = Convert.ToDateTime(fechdocini.Trim().Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Trim().Substring(0, 10));
                if (almacaccionid.Trim().Length > 0)
                {
                    BE.almacaccionid = almacaccionid;
                }
                DtReporte = BL.GetAll_productokardex_tela(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_productokardex_tela()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporteRollokardex = new CR_productokardex();
                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                reporteRollokardex.DataDefinition.FormulaFields["fechdoc"].Text = "'DE: " + fechdocini.Trim().Substring(0, 10) + "  AL:" + fechdocfin.Trim().Substring(0, 10) + "'";

                if (moduloid.Trim() == "0810")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'TIENDA : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'LOCAL : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }


                if (moduloid.Trim() == "0320")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "'ROLLO'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "''";
                }
                reporteRollokardex.SetDataSource(Movimiento_productokardex_tela());
                crystalReportViewer1.ReportSource = reporteRollokardex;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_productostock()
        {
            DtReporte = new DataTable("Productostock");
            try
            {
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid;
                BE.grupoid = grupoid;
                BE.subgrupoid = subgrupoid;
                BE.productid = productid;
                BE.colorid = colorid;
                BE.status = status;
                BE.productidold = productidold;
                BE.procedenciaid = procedenciaid;

                DtReporte = BL.GetAll_productostock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_productostock()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                if (moduloid.ToString() == "0500")
                {
                    var reporteRollokardex = new CR_productostock2();
                    reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["fechdoc"].Text = "'TIENDA : " + local + "  - " + localname + "'";
                    reporteRollokardex.SetDataSource(Movimiento_productostock());
                    crystalReportViewer1.ReportSource = reporteRollokardex;
                    crystalReportViewer1.Show();
                }
                else
                {
                    var reporteRollokardex = new CR_productostock();
                    reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["fechdoc"].Text = "'TIENDA : " + local + "  - " + localname + "'";
                    reporteRollokardex.SetDataSource(Movimiento_productostock());
                    crystalReportViewer1.ReportSource = reporteRollokardex;
                    crystalReportViewer1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Lista_tomainventario()
        {
            DtReporte = new DataTable("Productostock");
            try
            {
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid;
                BE.status = status;

                DtReporte = BL.GetAll_productostock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_tomainventario()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporteRollokardex = new CR_tomainventario();
                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                reporteRollokardex.SetDataSource(Lista_tomainventario());
                crystalReportViewer1.ReportSource = reporteRollokardex;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataTable Lista_inventariofisico()
        {
            DtReporte = new DataTable("Productostock");
            try
            {
                var BL = new tb_60local_stock_inventarioBL();
                var BE = new tb_60local_stock_inventario();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.tipodoc = tipdoc.Trim();
                BE.serdoc = serdoc.Trim();
                BE.numdoc = numdoc.Trim();

                DtReporte = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private void active_inventariadofisico()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }

                if (moduloid.ToString() == "0320".ToString())
                {
                    var reporteRollokardex = new CR_inventariado_rollos();
                    reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";
                    reporteRollokardex.SetDataSource(Lista_inventariofisico());
                    crystalReportViewer1.ReportSource = reporteRollokardex;
                    crystalReportViewer1.Show();
                }
                else
                {
                    var reporteRollokardex = new CR_inventariado();
                    reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                    reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";
                    reporteRollokardex.SetDataSource(Lista_inventariofisico());
                    crystalReportViewer1.ReportSource = reporteRollokardex;
                    crystalReportViewer1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataTable Lista_DiferenciaInv()
        {
            DtReporte = new DataTable("Productostock");
            try
            {
                var BL = new tb_60local_stock_inventarioBL();
                var BE = new tb_60local_stock_inventario();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid.Trim();
                BE.dif = dif;

                DtReporte = BL.GetReportDif(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_DifernciaInv()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporteRollokardex = new CR_diferencia_inv();

                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";

                reporteRollokardex.SetDataSource(Lista_DiferenciaInv());
                crystalReportViewer1.ReportSource = reporteRollokardex;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private DataTable Lista_DiferenciaInvRollos()
        {
            DtReporte = new DataTable("DifRollos");
            try
            {
                var BL = new tb_60local_stock_inventario_rolloBL();
                var BE = new tb_60local_stock_inventario_rollo();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid.Trim();
                BE.productid = productid.Trim();
                BE.rollo = rollo.Trim();
                BE.fechatoma = Convert.ToDateTime(fechdoc.Trim());
                BE.dif = dif;

                DtReporte = BL.GetAllDifRollos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_DifernciaInvRollos()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporteRollokardex = new CR_diferencia_inv_rollos();

                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";

                reporteRollokardex.SetDataSource(Lista_DiferenciaInvRollos());
                crystalReportViewer1.ReportSource = reporteRollokardex;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private DataTable Lista_UbigeoInvRollos()
        {
            DtReporte = new DataTable("UbigRollos");
            try
            {
                var BL = new tb_60local_stock_inventario_rolloBL();
                var BE = new tb_60local_stock_inventario_rollo();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.productid = productid.Trim();
                BE.fechatoma = Convert.ToDateTime(fechdoc.Trim());

                DtReporte = BL.GetAllUbigeoRollos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_UbigeoInvRollos()
        {
            try
            {
                var reporteRollo = new CR_ubigeo_inv_rollos();

                reporteRollo.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollo.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollo.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";

                reporteRollo.SetDataSource(Lista_UbigeoInvRollos());
                crystalReportViewer1.ReportSource = reporteRollo;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private DataTable Lista_UbigeoInvRollos_gen()
        {
            DtReporte = new DataTable("UbigRollos_gen");
            try
            {
                var BL = new tb_60local_stock_inventario_rolloBL();
                var BE = new tb_60local_stock_inventario_rollo();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.fechatoma = Convert.ToDateTime(fechdoc.Trim());

                DtReporte = BL.GetAllUbigeoRollos_gen(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_UbigeoInvRollos_gen()
        {
            try
            {
                var reporteRollo = new CR_ubigeo_inv_rollos_gen();

                reporteRollo.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollo.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollo.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";

                reporteRollo.SetDataSource(Lista_UbigeoInvRollos_gen());
                crystalReportViewer1.ReportSource = reporteRollo;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private DataTable Lista_DiferenciaInvRollos_gen()
        {
            DtReporte = new DataTable("DifRollos");
            try
            {
                var BL = new tb_60local_stock_inventario_rolloBL();
                var BE = new tb_60local_stock_inventario_rollo();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid.Trim();
                BE.productid = productid.Trim();
                BE.rollo = rollo.Trim();
                BE.fechatoma = Convert.ToDateTime(fechdoc.Trim());

                DtReporte = BL.GetAllDifRollos_gen(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_DifernciaInvRollos_gen()
        {
            try
            {
                var reporteRollokardex = new CR_diferencia_inv_rollos_gen();

                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";

                reporteRollokardex.SetDataSource(Lista_DiferenciaInvRollos_gen());
                crystalReportViewer1.ReportSource = reporteRollokardex;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void active_requerimiento()
        {
            try
            {
                var requerimiento = new CR_requerimiento();

                if (Table != null)
                {
                    requerimiento.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    requerimiento.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                    if (VariablesPublicas.EmpresaTipo != string.Empty)
                    {
                        requerimiento.DataDefinition.FormulaFields["almacen"].Text = "'" + VariablesPublicas.EmpresaTipo + "'";
                    }
                    else
                    {
                        requerimiento.DataDefinition.FormulaFields["almacen"].Text = string.Empty;
                    }

                    requerimiento.DataDefinition.FormulaFields["observacion"].Text = "'* " + "Cantidades Expresadas en unidad de Consumo *'";
                    requerimiento.SetDataSource(Table);
                    crystalReportViewer1.ReportSource = requerimiento;
                    crystalReportViewer1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_mov_ordprod()
        {
            DtReporte = new DataTable("Productostock");
            try
            {
                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();

                BE.fechdocini = Convert.ToDateTime(fechdocini.Trim().Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Trim().Substring(0, 10));
                if (serop_ini.Trim().Length > 0)
                {
                    BE.ser_opi = serop_ini.Trim().PadLeft(4, '0');
                }
                if (numop_ini.Trim().Length > 0)
                {
                    BE.num_opi = numop_ini.Trim().PadLeft(10, '0');
                }
                if (serop_fin.Trim().Length > 0)
                {
                    BE.ser_opf = serop_fin.Trim().PadLeft(4, '0');
                }
                if (numop_fin.Trim().Length > 0)
                {
                    BE.num_opf = numop_fin.Trim().PadLeft(10, '0');
                }
                if (almacaccionid.Trim().Length > 0)
                {
                    BE.almacaccionid = almacaccionid;
                }

                DtReporte = BL.GetAll_ConsumoxOP(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private void active_mov_ordprod()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }

                var reporteRollokardex = new CR_mov_ordprod();
                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["fechdoc"].Text = "'DE: " + fechdocini.Trim().Substring(0, 10) + "  AL:" + fechdocfin.Trim().Substring(0, 10) + "'";
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + moduloname + "'";

                if (moduloid.Trim() == "0320")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "'ROLLOS'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "'ITEMS'";
                }
                reporteRollokardex.SetDataSource(Movimiento_mov_ordprod());
                crystalReportViewer1.ReportSource = reporteRollokardex;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_mov_balancestock()
        {
            DtReporte = new DataTable("mov_balancestock");
            try
            {
                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();

                BE.moduloid = moduloid.ToString();
                BE.local = local.ToString();

                BE.perianio = Peranio.ToString();
                BE.perimesini = Mesdoini.ToString();
                BE.perimesfin = Mesdofin.ToString();
                BE.lineaid = lineaid.Trim();
                BE.grupoid = grupoid.Trim();
                BE.subgrupoid = subgrupoid.Trim();
                BE.productidini = productid.Trim();

                if (accion)
                {
                    BE.accion = "0";
                }
                else
                {
                    BE.accion = "1";
                }

                DtReporte = BL.GetAll_Balance(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void active_mov_balancestock()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }

                //var reporteCrystal;

                if (tipreporte == "13.1")
                {
                    Reporte = new CR_mov_balancestock_131();
                }
                else
                {
                    Reporte = new CR_mov_balancestock_121();
                }


                Reporte.DataDefinition.FormulaFields["empresaruc"].Text = "': " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                Reporte.DataDefinition.FormulaFields["empresaname"].Text = "': " + VariablesPublicas.EmpresaName.Trim() + "'";
                Reporte.DataDefinition.FormulaFields["empresaestable"].Text = "': " + localname + "'";
                Reporte.DataDefinition.FormulaFields["empresatipo"].Text = "': " + moduloname + "'";
                Reporte.DataDefinition.FormulaFields["empresaperiodo"].Text = "': " + Mesdoini + " " + Peranio + "'";
                if (VariablesPublicas.N_FinMes1 == string.Empty)
                {
                    Reporte.DataDefinition.FormulaFields["mesperifin"].Text = string.Empty;
                }
                else
                {
                    Reporte.DataDefinition.FormulaFields["mesperifin"].Text = "'-   " + Mesdofin + " " + Peranio + "'";
                }
                Reporte.DataDefinition.FormulaFields["fechaimpresion"].Text = "' " + Fechprint + "'";
                Reporte.SetDataSource(Movimiento_mov_balancestock());
                crystalReportViewer1.ReportSource = Reporte;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_mov_docsemitido()
        {
            DtReporte = new DataTable("Mov_docsemitido");
            try
            {
                var BL = new tb_60movimientosdetBL();
                var BE = new tb_60movimientosdet();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                if (tipdoc != null && tipdoc.Trim().Length > 0)
                {
                    BE.tipodoc = tipdoc.Trim();
                }
                BE.mottrasladointid = mottrasladointid.Trim();
                BE.ctacte = ctacte.Trim();
                BE.fechdocini = Convert.ToDateTime(fechdocini.Trim().Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Trim().Substring(0, 10));
                BE.modcalculo = modcalculo;
                BE.accion = almacaccionid.Trim();

                DtReporte = BL.GetAll_Docsemitidos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void active_mov_docsemitido()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var reporte_docsemitido = new CR_mov_docsemitidos();
                reporte_docsemitido.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporte_docsemitido.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporte_docsemitido.DataDefinition.FormulaFields["fechdoc"].Text = "'DE: " + fechdocini.Trim().Substring(0, 10) + "  AL:" + fechdocfin.Trim().Substring(0, 10) + "'";
                reporte_docsemitido.DataDefinition.FormulaFields["almacen"].Text = "'" + VariablesPublicas.EmpresaTipo + "'";
                if (moduloid.Trim() == "0320")
                {
                    reporte_docsemitido.DataDefinition.FormulaFields["varitems"].Text = "'ROLLOS'";
                    reporte_docsemitido.DataDefinition.FormulaFields["varcantidad"].Text = "'METRAJE'";
                    reporte_docsemitido.DataDefinition.FormulaFields["varitemst"].Text = "'TOTAL ROLLOS:'";
                    reporte_docsemitido.DataDefinition.FormulaFields["varcantidadt"].Text = "'TOTAL METRAJE:'";
                }
                else
                {
                    reporte_docsemitido.DataDefinition.FormulaFields["varitems"].Text = "'ITEMS'";
                    reporte_docsemitido.DataDefinition.FormulaFields["varcantidad"].Text = "'CANTIDAD'";
                    reporte_docsemitido.DataDefinition.FormulaFields["varitemst"].Text = "'TOTAL ITEMS:'";
                    reporte_docsemitido.DataDefinition.FormulaFields["varcantidadt"].Text = "'TOTAL CANTIDAD:'";
                }
                reporte_docsemitido.SetDataSource(Movimiento_mov_docsemitido());
                crystalReportViewer1.ReportSource = reporte_docsemitido;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_reportes_Load(object sender, EventArgs e)
        {
            switch (formulario)
            {
                case "Frm_color":
                    active_color();
                    break;
                case "Frm_linea":
                    active_linea();
                    break;
                case "Frm_grupo":
                    active_grupo();
                    break;
                case "Frm_subgrupo":
                    active_subgrupo();
                    break;
                case "Frm_producto":
                    active_producto();
                    break;
                case "Frm_movimiento":
                    active_Movimiento("S");
                    break;
                case "Frm_movimiento_rollos2":
                    active_Movimiento_Rollo2();
                    break;
                case "Frm_reporte_rollostock":
                    active_rollostock();
                    break;
                case "Frm_reporte_rollokardex":
                    active_rollokardex();
                    break;
                case "Frm_reporte_productokardex_tela":
                    active_productokardex_tela();
                    break;
                case "Frm_reporte_productostock":
                    active_productostock();
                    break;
                case "Frm_reporte_mov_ordprod":
                    active_mov_ordprod();
                    break;
                case "Frm_reporte_mov_balancestock":
                    active_mov_balancestock();
                    break;
                case "Frm_reporte_mov_docsemitido":
                    active_mov_docsemitido();
                    break;
                case "Frm_movimiento_noval":
                    active_Movimiento("N");
                    break;
                case "Frm_reporte_tomainventario":
                    active_tomainventario();
                    break;
                case "Frm_reporte_inventariado":
                    active_inventariadofisico();
                    break;
                case "Frm_reporte_diferenciaInv":
                    active_DifernciaInv();
                    break;
                case "Frm_reporte_diferenciaInvRollos":
                    active_DifernciaInvRollos();
                    break;
                case "Frm_reporte_diferenciaInvRollos_gen":
                    active_DifernciaInvRollos_gen();
                    break;
                case "Frm_reporte_UbigeoInvRollos":
                    active_UbigeoInvRollos();
                    break;
                case "Frm_reporte_UbigeoInvRollos_gen":
                    active_UbigeoInvRollos_gen();
                    break;
                case "Frm_requerimiento":
                    active_requerimiento();
                    break;
                case "Frm_producto_cencos":
                    active_productos_cencos();
                    break;
                case "Frm_movimiento_personal":
                    active_movimiento_personal();
                    break;
                case "Frm_reporte_consumo":
                    active_consumos();
                    break;
                case "Frm_reporte_StockEstacion":
                    active_stockEstacion();
                    break;
                default:
                    break;
            }
        }

        private void active_productos_cencos()
        {
            var Productos = new CR_productos_cencos();

            Productos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
            Productos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

            Productos.SetDataSource(productos_cencos());
            crystalReportViewer1.ReportSource = Productos;
            crystalReportViewer1.Show();
        }

        private void active_movimiento_personal()
        {
            var personal = new CR_movimiento_personal();

            personal.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
            personal.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

            personal.SetDataSource(productos_cencos());
            crystalReportViewer1.ReportSource = personal;
            crystalReportViewer1.Show();
        }

        private DataTable productos_cencos()
        {
            try
            {
                DtReporte = new DataTable("Personal_Cencos");
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();
                BE.operacion = operacion;
                BE.cencosid = cencosid.Trim();
                BE.perdni = perddnni.Trim();
                BE.moduloid = moduloid;

                DtReporte = BL.GetProductosCencos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void active_stockEstacion()
        {
            var StockEstacion = new CR_stock();

            if (Table != null)
            {
                StockEstacion.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                StockEstacion.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                StockEstacion.SetDataSource(Table);
                crystalReportViewer1.ReportSource = StockEstacion;
                crystalReportViewer1.Show();
            }
        }

        private void active_consumos()
        {
            var personal = new CR_consumos();

            personal.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
            personal.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

            personal.SetDataSource(consumos_productos());
            crystalReportViewer1.ReportSource = personal;
            crystalReportViewer1.Show();
        }

        private DataTable consumos_productos()
        {
            try
            {
                DtReporte = new DataTable();
                var BL = new tb_60local_stockBL();
                var BE = new tb_60local_stock();

                BE.moduloid = moduloid.ToString();
                BE.perimes = Mesdoini.ToString();
                BE.perianio = Peranio.ToString();
                BE.procedenciaid = procedenciaid.ToString();
                BE.filtro = "1";

                DtReporte = BL.ConsumosProd(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (DtReporte != null)
                {
                    return DtReporte;
                }
                else
                {
                    return DtReporte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Frm_reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
