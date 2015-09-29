using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;

using bapFunciones;

namespace BapFormulariosNet.DL0Logistica.Reportes
{
    public partial class Frm_reportes : Form
    {
        public String dominioid { get; set; }
        public String moduloid { get; set; }
        public String moduloname { get; set; }
        public String localname { get; set; }
        public String local { get; set; }
        public String formulario { get; set; }
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public String lineaid { get; set; }
        public String moduloiddies { get; set; }
        public String localdes { get; set; }
        public String perianio { get; set; }

        public String tipreporte { get; set; }

        public String perimesini { get; set; }

        public String perimesfin { get; set; }
        public String grupoid { get; set; }
        public String gruponame { get; set; }
        public DateTime? fechafin { get; set; }
        public DateTime? fechaini { get; set; }
        public String pendiente { get; set; }
        public String igv { get; set; }
        public String productid { get; set; }
        public String num_desde { get; set; }
        public String num_hasta { get; set; }
        public String localdestino { get; set; }


        public Frm_reportes()
        {
            Load += Frm_reportes_Load;
            InitializeComponent();
        }

        private void Frm_reportes_Load(object sender, EventArgs e)
        {
            switch (formulario)
            {
                case "Frm_orden_pendiente":
                    Orden_pendiente();
                    break;
                case "Frm_orden_status":
                    status_compra();
                    break;
                case "Frm_ordencompra":
                    Frm_ordencompra();
                    break;
                case "Frm_ordencompra2":
                    Frm_ordencompra();
                    break;
                case "Frm_orden_listado":
                    listado_almacenes();
                    break;
                case "Frm_listar_almacen":
                    listar_almacen();
                    break;
                case "Frm_reporte_kardex":
                    reporte_Kardex();
                    break;
                case "Frm_reporte_ordemitidas":
                    reporte_OrdEmitidas();
                    break;
            }
        }


        private DataTable Ordencompra()
        {
            try
            {
                var TablaOrdencompra = new DataTable("Movimientos");

                var BL = new tb_cm_ordendecompraBL();
                var BE = new tb_cm_ordendecompra();

                BE.moduloid = moduloid.Trim();
                BE.local = local.Trim();
                BE.tipodoc = tipdoc.Trim();
                BE.serdoc = serdoc.Trim();
                BE.numdoc = numdoc.Trim();
                BE.localdes = localdes.ToString();

                if (formulario == "Frm_ordencompra2")
                {
                    TablaOrdencompra = BL.GetReport2(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }
                else
                {
                    TablaOrdencompra = BL.GetReport(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                }

                if (TablaOrdencompra.Rows.Count > 0)
                {
                    return TablaOrdencompra;
                }
                else
                {
                    return TablaOrdencompra;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        private void reporte_Kardex()
        {
            var Kardex = new CR_orden_kardex();
            Kardex.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
            Kardex.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

            Kardex.SetDataSource(Reporte_Kardex());
            crystalReportViewer1.ReportSource = Kardex;
            crystalReportViewer1.Show();
        }

        private DataTable Reporte_Kardex()
        {
            try
            {
                var TablaOrdencompra = new DataTable("Kardex O/C");

                var BL = new tb_cm_ordendecompraBL();
                var BE = new tb_cm_ordendecompra();

                BE.moduloid = moduloid.Trim();
                BE.num_desde = num_desde.Trim();
                BE.num_hasta = num_hasta.Trim();
                BE.grupoid = grupoid.Trim();
                BE.productid = productid.Trim();

                TablaOrdencompra = BL.GetKardex(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (TablaOrdencompra.Rows.Count > 0)
                {
                    return TablaOrdencompra;
                }
                else
                {
                    return TablaOrdencompra;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void reporte_OrdEmitidas()
        {
            if (gruponame.Length == 0)
            {
                gruponame = "<TODOS>";
            }
            if (localname.Length == 0)
            {
                localname = "<TODOS>";
            }

            var OrdEmitidas = new CR_orden_ordemitidas();
            OrdEmitidas.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
            OrdEmitidas.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";

            OrdEmitidas.DataDefinition.FormulaFields["periodo"].Text = "'DEL : " + Equivalencias.Left(fechaini.ToString(), 10) + "  AL : " + Equivalencias.Left(fechafin.ToString(), 10) + "'";
            OrdEmitidas.DataDefinition.FormulaFields["moduloparam"].Text = "'" + moduloname.ToString() + "'";
            if (localname.Length > 0)
            {
                OrdEmitidas.DataDefinition.FormulaFields["localparam"].Text = "'" + localname.ToString() + "'";
            }
            OrdEmitidas.DataDefinition.FormulaFields["ctacteparam"].Text = "'" + gruponame.ToString() + "'";

            OrdEmitidas.SetDataSource(Reporte_OrdEmitidas());
            crystalReportViewer1.ReportSource = OrdEmitidas;
            crystalReportViewer1.Show();
        }

        private DataTable Reporte_OrdEmitidas()
        {
            try
            {
                var TablaOrdencompra = new DataTable();

                var BL = new tb_cm_ordendecompraBL();
                var BE = new tb_cm_ordendecompra();

                BE.moduloid = moduloid.Trim();
                BE.local = local;
                BE.ctacte = grupoid.Trim();
                BE.fechaini = fechaini;
                BE.fechafin = fechafin;


                TablaOrdencompra = BL.Report_OrdEmitidas(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (TablaOrdencompra.Rows.Count > 0)
                {
                    return TablaOrdencompra;
                }
                else
                {
                    return TablaOrdencompra;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        private void Frm_ordencompra()
        {
            var reportemovimientos = new CR_ordencompra();
            reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA :  " + VariablesPublicas.EmpresaName.Trim() + "'";
            reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC :  " + VariablesPublicas.EmpresaRuc.Trim() + "'";
            reportemovimientos.DataDefinition.FormulaFields["empredireccion"].Text = "'DIRECCIÓN :  " + VariablesPublicas.EmpresaDirecc.Trim() + "'";

            reportemovimientos.DataDefinition.FormulaFields["localdireccion"].Text = "'" + localdestino.ToString() + "'";
            reportemovimientos.DataDefinition.FormulaFields["localtelefono"].Text = "'" + VariablesPublicas.telef.Trim() + "'";
            reportemovimientos.SetDataSource(Ordencompra());
            crystalReportViewer1.ReportSource = reportemovimientos;
            crystalReportViewer1.Show();
        }


        private void status_compra()
        {
            var status_compra = new CR_status_compra();

            status_compra.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
            status_compra.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
            status_compra.DataDefinition.FormulaFields["anio"].Text = "'" + perianio.Trim() + "'";
            status_compra.DataDefinition.FormulaFields["inicio"].Text = "'" + VariablesPublicas.N_PrimerMes1.Trim() + "'";
            status_compra.DataDefinition.FormulaFields["fin"].Text = "'" + VariablesPublicas.N_FinMes1.Trim() + "'";
            status_compra.SetDataSource(Orden_Pendiente());
            crystalReportViewer1.ReportSource = status_compra;
            crystalReportViewer1.Show();
        }


        private void Orden_pendiente()
        {
            try
            {
                var orden_pendiente = new CR_orden_pendiente();

                orden_pendiente.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                orden_pendiente.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                orden_pendiente.DataDefinition.FormulaFields["anio"].Text = "'" + perianio.Trim() + "'";
                orden_pendiente.DataDefinition.FormulaFields["inicio"].Text = "'" + VariablesPublicas.N_PrimerMes1.Trim() + "'";
                orden_pendiente.DataDefinition.FormulaFields["fin"].Text = "'" + VariablesPublicas.N_FinMes1.Trim() + "'";
                orden_pendiente.SetDataSource(Orden_Pendiente());
                crystalReportViewer1.ReportSource = orden_pendiente;

                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listado_almacenes()
        {
            var listadoAlmacen = new CR_listado_almacen();
            var ds_listado_almacen = new DataSet();
            var nombrealmacen = new List<String>();
            var BL = new tb_cm_ordendecompradetBL();
            var BE = new tb_cm_ordendecompradet();
            BE.moduloiddes = moduloiddies.Trim();
            BE.perianio = perianio.Trim();
            BE.perimesini = perimesini.Trim();
            BE.perimesfin = perimesfin.Trim();
            BE.grupoid = grupoid.Trim();
            BE.pendiente = string.Empty;
            BE.status = " ";
            BE.igv = igv;

            ds_listado_almacen = BL.GetAll_ordendeCompra(VariablesPublicas.EmpresaID.ToString(), BE);
            if (ds_listado_almacen != null)
            {
                listadoAlmacen.OpenSubreport("ALMACEN DE TELAS").SetDataSource(ds_listado_almacen.Tables[0]);
                listadoAlmacen.OpenSubreport("ALMACEN DE AVIOS").SetDataSource(ds_listado_almacen.Tables[1]);
                listadoAlmacen.OpenSubreport("ALMACEN DE ESTAMPADOS ").SetDataSource(ds_listado_almacen.Tables[2]);
                listadoAlmacen.OpenSubreport("ALMACEN DE BORDADO").SetDataSource(ds_listado_almacen.Tables[3]);
                listadoAlmacen.OpenSubreport("ALMACEN DE CORREAS").SetDataSource(ds_listado_almacen.Tables[4]);
                listadoAlmacen.OpenSubreport("ALMACEN DE INSUMOS QUIMICOS").SetDataSource(ds_listado_almacen.Tables[5]);
                listadoAlmacen.OpenSubreport("MAQ Y REP SISTEMAS").SetDataSource(ds_listado_almacen.Tables[6]);
                listadoAlmacen.OpenSubreport("MAQ Y REP ELECTRICOS").SetDataSource(ds_listado_almacen.Tables[7]);
                listadoAlmacen.OpenSubreport("MAQ Y REP COSTURA").SetDataSource(ds_listado_almacen.Tables[8]);
                listadoAlmacen.OpenSubreport("ALMACEN DE VARIOS").SetDataSource(ds_listado_almacen.Tables[9]);
                nombrealmacen.Add("ALMACEN DE TELAS");
                nombrealmacen.Add("ALMACEN DE AVIOS");
                nombrealmacen.Add("ALMACEN DE ESTAMPADOS ");
                nombrealmacen.Add("ALMACEN DE BORDADO");
                nombrealmacen.Add("ALMACEN DE CORREAS");
                nombrealmacen.Add("ALMACEN DE INSUMOS QUIMICOS");
                nombrealmacen.Add("MAQ Y REP SISTEMAS");
                nombrealmacen.Add("MAQ Y REP ELECTRICOS");
                nombrealmacen.Add("MAQ Y REP COSTURA");
                nombrealmacen.Add("ALMACEN DE VARIOS");

                foreach (String almacen in nombrealmacen)
                {
                    listadoAlmacen.OpenSubreport(almacen).DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    listadoAlmacen.OpenSubreport(almacen).DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    listadoAlmacen.OpenSubreport(almacen).DataDefinition.FormulaFields["anio"].Text = "'" + perianio.Trim() + "'";
                    listadoAlmacen.OpenSubreport(almacen).DataDefinition.FormulaFields["inicio"].Text = "'" + VariablesPublicas.N_PrimerMes1.Trim() + "'";
                    listadoAlmacen.OpenSubreport(almacen).DataDefinition.FormulaFields["fin"].Text = "'" + VariablesPublicas.N_FinMes1.Trim() + "'";
                    if (igv == "0")
                    {
                        listadoAlmacen.OpenSubreport(almacen).DataDefinition.FormulaFields["nameigv"].Text = "'No Incluye IGV'";
                    }
                    else
                    {
                        listadoAlmacen.OpenSubreport(almacen).DataDefinition.FormulaFields["nameigv"].Text = "'Incluye  IGV'";
                    }
                }

                crystalReportViewer1.ReportSource = listadoAlmacen;
                crystalReportViewer1.Show();
                formulario = "otro";
            }
            else
            {
                MessageBox.Show("Informacion no encontrada", "Mensaje del Sistema");
            }
        }

        private void listar_almacen()
        {
            try
            {
                var listar_almacen = new CR_orden_compra();

                listar_almacen.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                listar_almacen.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                listar_almacen.DataDefinition.FormulaFields["anio"].Text = "'" + perianio.Trim() + "'";
                listar_almacen.DataDefinition.FormulaFields["inicio"].Text = "'" + VariablesPublicas.N_PrimerMes1.Trim() + "'";
                listar_almacen.DataDefinition.FormulaFields["fin"].Text = "'" + VariablesPublicas.N_FinMes1.Trim() + "'";

                if (igv == "0")
                {
                    listar_almacen.DataDefinition.FormulaFields["nameigv"].Text = "'No Incluye IGV'";
                }
                else
                {
                    listar_almacen.DataDefinition.FormulaFields["nameigv"].Text = "'Incluye IGV'";
                }
                listar_almacen.SetDataSource(Orden_Pendiente());
                crystalReportViewer1.ReportSource = listar_almacen;
                crystalReportViewer1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataSet listado_almacen()
        {
            try
            {
                var ds_listado_almacen = new DataSet();
                var BL = new tb_cm_ordendecompradetBL();
                var BE = new tb_cm_ordendecompradet();
                var dt = new DataSet();
                BE.moduloiddes = moduloiddies.Trim();
                BE.perianio = perianio.Trim();
                BE.perimesini = perimesini.Trim();
                BE.perimesfin = perimesfin.Trim();
                BE.grupoid = grupoid.Trim();
                BE.pendiente = string.Empty;
                BE.status = " ";
                ds_listado_almacen = BL.GetAll_ordendeCompra(VariablesPublicas.EmpresaID.ToString(), BE);
                if (ds_listado_almacen != null)
                {
                    foreach (DataTable tabla in ds_listado_almacen.Tables)
                    {
                        var _tabla = new DataTable();

                        if (tabla == ds_listado_almacen.Tables[0])
                        {
                            _tabla = ds_listado_almacen.Tables[0].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[1])
                        {
                            _tabla = ds_listado_almacen.Tables[1].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[2])
                        {
                            _tabla = ds_listado_almacen.Tables[2].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[3])
                        {
                            _tabla = ds_listado_almacen.Tables[3].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[5])
                        {
                            _tabla = ds_listado_almacen.Tables[5].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[6])
                        {
                            _tabla = ds_listado_almacen.Tables[6].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[7])
                        {
                            _tabla = ds_listado_almacen.Tables[7].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[8])
                        {
                            _tabla = ds_listado_almacen.Tables[8].Copy();
                        }
                        if (tabla == ds_listado_almacen.Tables[9])
                        {
                            _tabla = ds_listado_almacen.Tables[9].Copy();
                        }
                        dt.Tables.Add(_tabla);
                    }
                }
                else
                {
                    return null;
                }

                return ds_listado_almacen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DataTable Orden_Pendiente()
        {
            try
            {
                var Ord_pendiente = new DataTable("Ord_pendiente");

                var BL = new tb_cm_ordendecompradetBL();
                var BE = new tb_cm_ordendecompradet();
                BE.moduloiddes = moduloiddies;
                BE.perianio = perianio;
                BE.perimesini = perimesini;
                BE.perimesfin = perimesfin;
                BE.grupoid = grupoid;
                BE.productid = productid;
                BE.pendiente =  pendiente;
                BE.igv = igv;
                Ord_pendiente = BL.GetAll_ordendeCompra(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
                if (Ord_pendiente.Rows.Count == 0)
                {
                    MessageBox.Show("No existe Información Procesada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return Ord_pendiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
