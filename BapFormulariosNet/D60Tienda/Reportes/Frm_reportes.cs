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

namespace BapFormulariosNet.D60Tienda.Reportes
{
    public partial class Frm_reportes : Form
    {
        public String dominioid { get; set; }
        public String moduloiddies { get; set; }
        public String fechaini { get; set; }
        public String fechafin { get; set; }
        public String localname { get; set; }
        public String moduloname { get; set; }
        public Int32 modcalculo { get; set; }
        public String productidold { get; set; }
        public String moduloid { get; set; }
        public String local { get; set; }
        public String tipreporte { get; set; }
        public String formulario { get; set; }
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public String lineaid { get; set; }
        public String lineaname { get; set; }
        public String grupoid { get; set; }
        public String gruponame { get; set; }
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

        public String Mesdoini { get; set; }

        public String Mesdofin { get; set; }
        public String serop_ini { get; set; }
        public String serop_fin { get; set; }
        public String numop_ini { get; set; }
        public String numop_fin { get; set; }
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
        public String nmruc { get; set; }

        public ReportDocument Reporte { get; set; }

        public DataTable Table { get; set; }
        public String mottrasladointid { get; set; }

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
                var TablaComercialpedido = new DataTable("Movimientos");

                var BL = new tb_me_movimientosBL();
                var BE = new tb_me_movimientos();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.tipodoc = tipdoc.Trim();
                BE.serdoc = serdoc.Trim();
                BE.numdoc = numdoc.Trim();
                BE.Convalor = convalor;

                TablaComercialpedido = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaComercialpedido != null)
                {
                    return TablaComercialpedido;
                }
                else
                {
                    return null;
                }

                return TablaComercialpedido;
            }
            catch (Exception ex)
            {
                return null;
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
                if (moduloid.Trim() == "0320")
                {
                }
                else
                {
                    var reportemovimientos = new CR_movimiento();
                    reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "''";

                    reportemovimientos.SetDataSource(Movimiento(convalor));
                    CrsRptMain.ReportSource = reportemovimientos;
                    CrsRptMain.Show();
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
                var TablaComercialpedido = new DataTable("Movimientos");

                var BL = new tb_me_movimientosBL();
                var BE = new tb_me_movimientos();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.tipodoc = tipdoc.Trim();
                BE.serdoc = serdoc.Trim();
                BE.numdoc = numdoc.Trim();

                TablaComercialpedido = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaComercialpedido != null)
                {
                    return TablaComercialpedido;
                }
                else
                {
                    return null;
                }
                return TablaComercialpedido;
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
                var Tablacolor = new DataTable("color");

                var BL = new tb_me_colorBL();
                var BE = new tb_me_color();

                BE.moduloid = moduloid.Trim();

                Tablacolor = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (Tablacolor != null)
                {
                    return Tablacolor;
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
        private void active_color()
        {
            try
            {
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
                var TablaLinea = new DataTable("Linea");

                var BL = new tb_me_lineaBL();
                var BE = new tb_me_linea();

                BE.moduloid = moduloid.Trim();

                TablaLinea = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaLinea != null)
                {
                    return TablaLinea;
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

        private DataTable Movimiento_grupo()
        {
            try
            {
                var TablaGrupo = new DataTable("Grupo");

                var BL = new tb_me_grupoBL();
                var BE = new tb_me_grupo();

                BE.moduloid = moduloid.Trim();

                TablaGrupo = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaGrupo != null)
                {
                    return TablaGrupo;
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
        private void active_grupo()
        {
            try
            {
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
                var TablaSubgrupo = new DataTable("Subgrupo");

                var BL = new tb_me_subgrupoBL();
                var BE = new tb_me_subgrupo();

                BE.moduloid = moduloid.Trim();

                TablaSubgrupo = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaSubgrupo != null)
                {
                    return TablaSubgrupo;
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
        private void active_subgrupo()
        {
            try
            {
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
                var TablaProducto = new DataTable("Producto");

                var BL = new tb_me_productosBL();
                var BE = new tb_me_productos();

                BE.moduloid = moduloid.Trim();

                TablaProducto = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaProducto != null)
                {
                    return TablaProducto;
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
                CrsRptMain.ReportSource = reporteproducto;
                CrsRptMain.Show();
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
                var TablaRollostock = new DataTable("Stockrollo");
                var BE = new tb_me_productos();

                BE.moduloid = VariablesPublicas.Moduloid.Trim();
                BE.lineaid = lineaid;
                BE.grupoid = grupoid;
                BE.subgrupoid = subgrupoid;
                BE.productid = productid;
                BE.colorid = colorid;
                BE.rollo = rollo;

                BE.fechdocini = Convert.ToDateTime(fechdocini.Trim().Substring(0, 10));
                BE.fechdocfin = Convert.ToDateTime(fechdocfin.Trim().Substring(0, 10));

                if (TablaRollostock != null)
                {
                    return TablaRollostock;
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
        private void active_rollostock()
        {
            try
            {
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
                var TablaRollokardex = new DataTable("Rollokardex");

                var BL = new tb_me_movimientosdetBL();
                var BE = new tb_me_movimientosdet();

                BE.moduloid = VariablesPublicas.Moduloid.Trim();
                BE.local = VariablesPublicas.Local.Trim();
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
                TablaRollokardex = BL.GetAll_rollokardex(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaRollokardex != null)
                {
                    return TablaRollokardex;
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

        private void active_rollokardex()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_productokardex_tela()
        {
            var TablaProductokardex_tela = new DataTable("Productokardex_tela");
            try
            {
                var BL = new tb_me_movimientosdetBL();
                var BE = new tb_me_movimientosdet();

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
                TablaProductokardex_tela = BL.GetAll_productokardex(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaProductokardex_tela != null)
                {
                    return TablaProductokardex_tela;
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
        private void active_productokardex_tela()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_productostock(bool porlocal)
        {
            var TablaProductostock = new DataTable("Productostock");
            try
            {
                var BL = new tb_me_local_stockBL();
                var BE = new tb_me_local_stock();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid;
                BE.grupoid = grupoid;
                BE.subgrupoid = subgrupoid;
                BE.productid = productid;
                BE.colorid = colorid;
                BE.status = status;
                BE.productidold = productidold;
                if (porlocal)
                {
                    TablaProductostock = BL.GetAll_productostockxlocal(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                else
                {
                    TablaProductostock = BL.GetAll_productostock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                
                if (TablaProductostock != null)
                {
                    return TablaProductostock;
                }
                else
                {
                    return TablaProductostock;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                var reporteRollokardex = new CR_productostock();
                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                if (moduloid.Trim().ToString() == "0100" && moduloid.Trim().ToString() == "0500")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'TIENDA : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["name"].Text = "'LOCAL : " + local + "  - " + localname + "'";
                }
                reporteRollokardex.SetDataSource(Movimiento_productostock(false));
                CrsRptMain.ReportSource = reporteRollokardex;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void active_productostockxlocal()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }
                var rpt = new CR_productostockxlocal();
                rpt.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                rpt.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                if (moduloid.Trim().ToString() == "0100" && moduloid.Trim().ToString() == "0500")
                {
                    rpt.DataDefinition.FormulaFields["name"].Text = "'TIENDA : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }
                else
                {
                    rpt.DataDefinition.FormulaFields["name"].Text = "'LOCAL : " + local + "  - " + localname + "'";
                }
                rpt.SetDataSource(Movimiento_productostock(true));
                CrsRptMain.ReportSource = rpt;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Listado_ComprasxModelo()
        {
            var TablaListadoComprasxModelo = new DataTable("TablaListadoComprasxModelo");
            try
            {
                var BL = new tb_me_movimientosdetBL();
                var BE = new tb_me_movimientosdet();

                BE.moduloid = moduloid.Trim();
                BE.lineaid = lineaid;
                BE.grupoid = grupoid;
                BE.subgrupoid = subgrupoid;
                BE.fechdocini = Convert.ToDateTime(fechdocini);
                BE.fechdocfin = Convert.ToDateTime(fechdocfin);

                TablaListadoComprasxModelo = BL.ListadoComprasxModelo(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaListadoComprasxModelo != null)
                {
                    return TablaListadoComprasxModelo;
                }
                else
                {
                    return TablaListadoComprasxModelo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void active_listadoComprasxModelo()
        {
            try
            {
                if (lineaname.Length == 0)
                {
                    lineaname = "**TODOS**";
                }
                if (gruponame.Length == 0)
                {
                    gruponame = "**TODOS**";
                }
                if (subgruponame.Length == 0)
                {
                    subgruponame = "**TODOS**";
                }

                var ReportListado = new CR_listadoComprasxModelo();
                ReportListado.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                ReportListado.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                ReportListado.DataDefinition.FormulaFields["periodo"].Text = "'DEL : " + fechdocini.ToString() + "  AL : " + fechdocfin.ToString() + "'";
                ReportListado.DataDefinition.FormulaFields["lineaparam"].Text = "'" + lineaname.ToString() + "'";
                ReportListado.DataDefinition.FormulaFields["marcaparam"].Text = "'" + gruponame.ToString() + "'";
                ReportListado.DataDefinition.FormulaFields["modeloparam"].Text = "'" + subgruponame.ToString() + "'";

                ReportListado.SetDataSource(Listado_ComprasxModelo());
                CrsRptMain.ReportSource = ReportListado;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Lista_tomainventario()
        {
            var TablaProductostock = new DataTable("Productostock");
            try
            {
                var BL = new tb_me_local_stockBL();
                var BE = new tb_me_local_stock();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.lineaid = lineaid;
                BE.status = status;

                TablaProductostock = BL.GetAll_productostock(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaProductostock != null)
                {
                    return TablaProductostock;
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
                CrsRptMain.ReportSource = reporteRollokardex;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var reporteRollokardex = new CR_inventariado();

                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + VariablesPublicas.EmpresaTipo + "'";
                CrsRptMain.ReportSource = reporteRollokardex;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + VariablesPublicas.EmpresaTipo + "'";

                CrsRptMain.ReportSource = reporteRollokardex;
                CrsRptMain.Show();
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
                    CrsRptMain.ReportSource = requerimiento;
                    CrsRptMain.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_mov_ordprod()
        {
            var TablaMov_ordprod = new DataTable("Productostock");
            try
            {
                var BL = new tb_me_movimientosdetBL();
                var BE = new tb_me_movimientosdet();

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
                TablaMov_ordprod = BL.GetAll_ConsumoxOP(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaMov_ordprod != null)
                {
                    return TablaMov_ordprod;
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
                reporteRollokardex.DataDefinition.FormulaFields["almacen"].Text = "'" + VariablesPublicas.EmpresaTipo + "'";

                if (moduloid.Trim() == "0320")
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "'ROLLOS'";
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["varitems"].Text = "'ITEMS'";
                }
                reporteRollokardex.SetDataSource(Movimiento_mov_ordprod());
                CrsRptMain.ReportSource = reporteRollokardex;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_mov_balancestock()
        {
            var TablaMov_balancestock = new DataTable("mov_balancestock");
            try
            {
                var BL = new tb_me_movimientosdetBL();
                var BE = new tb_me_movimientosdet();

                BE.moduloid = VariablesPublicas.Moduloid.Trim();
                BE.local = VariablesPublicas.Local.Trim();
                BE.perianio = VariablesPublicas.perianio.Trim();
                BE.perimesini = VariablesPublicas.Perimesini.Trim();
                BE.perimesfin = VariablesPublicas.Perimesfin.Trim();
                BE.lineaid = lineaid.Trim();
                BE.grupoid = grupoid.Trim();
                BE.subgrupoid = subgrupoid.Trim();
                BE.productidini = productidini.Trim();
                BE.productidfin = productidfin.Trim();

                if (accion)
                {
                    BE.accion = "0";
                }
                else
                {
                    BE.accion = "1";
                }

                TablaMov_balancestock = BL.GetAll_Balance(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (TablaMov_balancestock != null)
                {
                    return TablaMov_balancestock;
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

                var reporteRollokardex = new CR_mov_balancestock();

                reporteRollokardex.DataDefinition.FormulaFields["empresaruc"].Text = "': " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaname"].Text = "': " + VariablesPublicas.EmpresaName.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaestable"].Text = "': " + VariablesPublicas.EmpresaEstablec.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresatipo"].Text = "': " + VariablesPublicas.EmpresaTipo.Trim() + "'";
                reporteRollokardex.DataDefinition.FormulaFields["empresaperiodo"].Text = "': " + VariablesPublicas.N_PrimerMes1.Trim() + " " + VariablesPublicas.perianio.Trim() + "'";
                if (VariablesPublicas.N_FinMes1 == string.Empty)
                {
                    reporteRollokardex.DataDefinition.FormulaFields["mesperifin"].Text = string.Empty;
                }
                else
                {
                    reporteRollokardex.DataDefinition.FormulaFields["mesperifin"].Text = "'-   " + VariablesPublicas.N_FinMes1.Trim() + " " + VariablesPublicas.perianio.Trim() + "'";
                }
                reporteRollokardex.DataDefinition.FormulaFields["fechaimpresion"].Text = "' " + VariablesPublicas.FechImpresion + "'";
                reporteRollokardex.SetDataSource(Movimiento_mov_balancestock());
                CrsRptMain.ReportSource = reporteRollokardex;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Movimiento_mov_docsemitido()
        {
            var TablaMov_docsemitido = new DataTable("Mov_docsemitido");
            try
            {
                var BL = new tb_me_movimientosdetBL();
                var BE = new tb_me_movimientosdet();

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

                TablaMov_docsemitido = BL.GetAll_Docsemitidos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaMov_docsemitido != null)
                {
                    return TablaMov_docsemitido;
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

                if (moduloid.Trim() == "0810")
                {
                    reporte_docsemitido.DataDefinition.FormulaFields["name"].Text = "'TIENDA : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }
                else
                {
                    reporte_docsemitido.DataDefinition.FormulaFields["name"].Text = "'LOCAL : " + VariablesPublicas.Local + "  - " + VariablesPublicas.nombrelocal + "'";
                }


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
                CrsRptMain.ReportSource = reporte_docsemitido;
                CrsRptMain.Show();
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
                case "Frm_reporte_productostockxlocal":
                    active_productostockxlocal();
                    break;
                case "Frm_reporte_Compras_Modelo":
                    active_listadoComprasxModelo();
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
                case "Frm_requerimiento":
                    active_requerimiento();
                    break;
                case "Frm_producto_cencos":
                    active_productos_cencos();
                    break;
                case "Frm_movimiento_personal":
                    active_movimiento_personal();
                    break;
                case "Frm_reporte_ventasEmitidas":
                    active_comprobantes_emitidas();
                    break;
                case "Frm_liquidacion_caja":
                    active_liquidacioncaja();
                    break;
                default:
                    break;
            }
        }

        private void active_liquidacioncaja()
        {
            try
            {
                var ReportListado = new CR_liquidacion_caja();
                ReportListado.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                ReportListado.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
 
                ReportListado.SetDataSource(liquidacioncaja());
                CrsRptMain.ReportSource = ReportListado;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable liquidacioncaja()
        {
            var dt = new DataTable();
            try
            {
                var BL = new tb_t1_cajaBL();
                var BE = new tb_t1_caja();

                BE.moduloid = moduloid.Trim();
                BE.local = local;
                BE.fecha = Convert.ToDateTime(fechafin);
                BE.filtro = "1";

                dt = BL.DetalleActual(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void active_comprobantes_emitidas()
        {
            try
            {
                if (localname.Length == 0)
                {
                    localname = "<TODOS>";
                }

                var ReportListado = new CR_listadoComprobantesEmitidos();
                ReportListado.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                ReportListado.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

                ReportListado.DataDefinition.FormulaFields["periodo"].Text = "'DEL : " + Equivalencias.Left(fechaini.ToString(), 10) + "  AL : " + Equivalencias.Left(fechafin.ToString(), 10) + "'";
                ReportListado.DataDefinition.FormulaFields["moduloparam"].Text = "'" + moduloname.ToString() + "'";
                if (localname.Length > 0)
                {
                    ReportListado.DataDefinition.FormulaFields["localparam"].Text = "'" + localname.ToString() + "'";
                }
                ReportListado.DataDefinition.FormulaFields["ctacteparam"].Text = "'" + ctactename.ToString() + "'";

                ReportListado.SetDataSource(Listado_ComprobantesEmitidos());
                CrsRptMain.ReportSource = ReportListado;
                CrsRptMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Listado_ComprobantesEmitidos()
        {
            var TablaListadoComprobantesEmitidos = new DataTable();
            try
            {
                var BL = new tb_me_movimientosdetBL();
                var BE = new tb_me_movimientos();

                BE.moduloid = moduloid.Trim();
                BE.local = local;
                BE.ctacte = ctacte;
                BE.nmruc = nmruc;
                BE.ctactename = ctactename;
                BE.fechdocini = Convert.ToDateTime(fechaini);
                BE.fechdocfin = Convert.ToDateTime(fechafin);

                TablaListadoComprobantesEmitidos = BL.ListadoComprobantesEmitidos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (TablaListadoComprobantesEmitidos != null)
                {
                    return TablaListadoComprobantesEmitidos;
                }
                else
                {
                    return TablaListadoComprobantesEmitidos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void active_productos_cencos()
        {
        }

        private void active_movimiento_personal()
        {
        }

        private DataTable productos_cencos()
        {
            try
            {
                var Tabla_productos_cencos = new DataTable("Personal_Cencos");
                var BL = new tb_co_persona_cencosBL();
                var BE = new tb_co_persona_cencosBE();
                BE.operacion = operacion;
                BE.cencosid = cencosid;
                BE.perdni = perddnni;
                BE.moduloid = moduloid;

                Tabla_productos_cencos = BL.GetProductosCencos(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (Tabla_productos_cencos != null)
                {
                    return Tabla_productos_cencos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
