using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;



namespace BapFormulariosNet.D70Produccion.Reportes
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
        public String tipop { get; set; }
        public String serop { get; set; }
        public String numop { get; set; }
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

        private void active_reporte_explosion_material()
        {
            
        }

        //private DataTable reqproduccion(String tipop, String serop, String numop)
        private DataTable reqproduccion(String tipdoc, String serdoc, String numdoc)
        {
            try
            {
                DtReporte = new DataTable("Produccion");

                var BL = new tb_pp_requerimientoprodBL();
                var BE = new tb_pp_requerimientoprod();

                //BE.moduloid = moduloid.Trim();
                //BE.local = local.Trim();
                BE.tipreq = tipdoc.Trim();
                BE.serreq = serdoc.Trim();
                BE.numreq = numdoc.Trim();

                //BE.tipop = tipop.Trim();
                //BE.serop = serop.Trim();
                //BE.numop = numop.Trim();
                
                //BE.Convalor = convalor;

                DtReporte = BL.GetAll_RptProd(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
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

        private void active_reporte_req_produccion(String tipop, String serop, String numop)
        {
            try
            {

                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }

                var BL = new tb_pp_requerimientoprodBL();
                var BE = new tb_pp_requerimientoprod();
                var dt = new DataTable();               

                BE.tipreq = tipdoc.Trim();
                BE.serreq = serdoc.Trim();
                BE.numreq = numdoc.Trim();
                
                string 
                    talla,
                    ta01="",ta02="",ta03="",ta04="",
                    ta05="",ta06="",ta07="",ta08="",
                    ta09="",ta10="",ta11="",ta12="";

                dt = BL.GetOne_Tallaid(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];

                if (dt.Rows.Count > 0) {
                    talla = dt.Rows[0]["tallaid"].ToString();

                    switch (talla)
                    {                    
                        case "A1":
                             ta01="02";ta02="04";ta03="06";ta04="08";
                             ta05="10";ta06="12";ta07="14";ta08="16";
                             ta09="18";ta10="NN";ta11="NN";ta12="NN";
                            break;

                        case "B1":                        
                             ta01="26";ta02="28";ta03="30";ta04="32";
                             ta05="34";ta06="36";ta07="38";ta08="40";
                             ta09="42";ta10="42";ta11="44";ta12="48";
                            break;
                        case "B2":
                             ta01="16";ta02="26";ta03="28";ta04="30";
                             ta05="NN";ta06="NN";ta07="NN";ta08="NN";
                             ta09="NN";ta10="NN";ta11="NN";ta12="NN";
                            break;
                        case "B3":
                             ta01="38";ta02="40";ta03="44";ta04="46";
                             ta05="48";ta06="50";ta07="NN";ta08="NN";
                             ta09="NN";ta10="NN";ta11="NN";ta12="NN";                        
                            break;
                        case "C1": 
                             ta01="26";ta02="27";ta03="28";ta04="29";
                             ta05="30";ta06="31";ta07="32";ta08="33";
                             ta09="34";ta10="36";ta11="NN";ta12="NN";
                             break;

                        case "C2":                         
                             ta01="28";ta02="29";ta03="30";ta04="31";
                             ta05="32";ta06="33";ta07="34";ta08="35";
                             ta09="36";ta10="37";ta11="NN";ta12="NN";    
                            break;
                        case "C3": 
                             ta01="37";ta02="38";ta03="39";ta04="40";
                             ta05="41";ta06="42";ta07="43";ta08="44";
                             ta09="NN";ta10="NN";ta11="NN";ta12="NN";
                            break;
                        case "D1": 
                             ta01=" S";ta02=" M";ta03=" L";ta04="XL";
                             ta05="XS";ta06="2X";ta07="26";ta08="3X";
                             ta09="ST";ta10="NN";ta11="NN";ta12="NN";
                            break;
                        case "D2": 
                             ta01="XS";ta02=" S";ta03=" M";ta04=" L";
                             ta05="XL";ta06="2X";ta07="3X";ta08="4X";
                             ta09="5X";ta10="6X";ta11="NN";ta12="NN";
                            break;
                        case "E1": 
                             ta01="14";ta02=" ½";ta03="15";ta04=" ½";
                             ta05="16";ta06=" ½";ta07="17";ta08=" ½";
                             ta09="18";ta10=" ½";ta11="NN";ta12="NN";
                            break;
                        case "E2": 
                             ta01="15";ta02=" ½";ta03="16";ta04=" ½";
                             ta05="17";ta06=" ½";ta07="18";ta08=" ½";
                             ta09="19";ta10=" ½";ta11="NN";ta12="NN";
                            break;
                        case "F1": 
                             ta01="26";ta02="27";ta03="28";ta04="29";
                             ta05="30";ta06="31";ta07="32";ta08="33";
                             ta09="34";ta10="38";ta11="NN";ta12="NN";
                            break;
                        case "F2": 
                             ta01="25";ta02="26";ta03="27";ta04="28";
                             ta05="29";ta06="30";ta07="32";ta08="34";
                             ta09="NN";ta10="NN";ta11="NN";ta12="NN";
                            break;
                        case "G1": 
                             ta01="14";ta02="16";ta03=" S";ta04=" M";
                             ta05=" L";ta06="NN";ta07="NN";ta08="NN";
                             ta09="NN";ta10="NN";ta11="NN";ta12="NN";
                            break;
                        case "H1": 
                             ta01=" 1";ta02=" 2";ta03=" 3";ta04=" 4";
                             ta05=" 5";ta06=" 6";ta07=" 7";ta08=" 8";
                             ta09="10";ta10="12";ta11="NN";ta12="NN";
                            break;
                        case "H2": 
                             ta01="3M";ta02="6M";ta03="9M";ta04="12";
                             ta05="18";ta06="24";ta07="NN";ta08="NN";
                             ta09="NN";ta10="NN";ta11="NN";ta12="NN";
                            break;
                        case "H3": 
                             ta01=" 1";ta02=" 2";ta03=" 3";ta04=" 4";
                             ta05=" 5";ta06=" 6";ta07=" 7";ta08=" 8";
                             ta09=" 9";ta10="10";ta11="NN";ta12="NN";
                            break;
                        case "J1": 
                             ta01="16";ta02="28";ta03="30";ta04="32";
                             ta05="34";ta06="36";ta07="38";ta08="40";
                             ta09="42";ta10="44";ta11="NN";ta12="NN";
                            break;
                        case "K1": 
                             ta01="NN";ta02="SU";ta03="NN";ta04="NN";
                             ta05="NN";ta06="NN";ta07="NN";ta08="NN";
                             ta09="NN";ta10="NN";ta11="NN";ta12="NN";
                            break;
                        case "L1": 
                             ta01="38";ta02="1/2";ta03="39";ta04="1/2";
                             ta05="40";ta06="1/2";ta07="41";ta08="1/2";
                             ta09="42";ta10="1/2";ta11="00";ta12="00";
                            break;
                        case "L2":                         
                             ta01="35";ta02=" ½";ta03="36";ta04=" ½";
                             ta05="37";ta06=" ½";ta07="38";ta08=" ½";
                             ta09="39";ta10=" ½";ta11="NN";ta12="NN";
                            break;
                    }

                }
                

                if (moduloid.Trim() == "0320" && local.Trim() == "002")
                {
                    var reportemovimientos = new CR_Rpt_prod();
                    reportemovimientos.DataDefinition.FormulaFields["empresaname"].Text = "'EMPRESA: " + VariablesPublicas.EmpresaName.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["empresaruc"].Text = "'RUC: " + VariablesPublicas.EmpresaRuc.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["usuario"].Text = "'" + VariablesPublicas.Nombr.Trim() + "'";
                    reportemovimientos.DataDefinition.FormulaFields["ta01"].Text = ((ta01)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta02"].Text = ((ta02)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta03"].Text = ((ta03)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta04"].Text = ((ta04)).ToString();

                    reportemovimientos.DataDefinition.FormulaFields["ta05"].Text = ((ta05)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta06"].Text = ((ta06)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta07"].Text = ((ta07)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta08"].Text = ((ta08)).ToString();

                    reportemovimientos.DataDefinition.FormulaFields["ta09"].Text = ((ta09)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta10"].Text = ((ta10)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta11"].Text = ((ta11)).ToString();
                    reportemovimientos.DataDefinition.FormulaFields["ta12"].Text = ((ta12)).ToString();


                    //reportemovimientos.DataDefinition.FormulaFields["varitems"].Text = "''";

                    //reportemovimientos.SetDataSource(reqproduccion(tipop, serop, numop));
                    reportemovimientos.SetDataSource(reqproduccion(tipdoc, serdoc, numdoc));
                    crystalReportViewer1.ReportSource = reportemovimientos;
                    crystalReportViewer1.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        public void metodo(string parametro1, string parametro2, string parametro3)
        {
            // try
            //{
            //    var path = string.Empty;
            //    var directorios = Application.StartupPath.Split('\\');
            //    if (directorios.Length > 0)
            //    {
            //        path = directorios[0] + "\\" + directorios[1];
            //    }

            //    var BL = new tb_pp_requerimientoprodBL();
            //    var BE = new tb_pp_requerimientoprod();
            //    var dt = new DataTable();
            //    BE.tipop = tipop;
            //    BE.serop = serop;
            //    BE.numop = numop;

            //    dt = BL.GetAll_RptProd(VariablesPublicas.EmpresaID.ToString(), BE).Tables[0];
            //    if (dt.Rows.Count > 0)
            //    {
            //        ReportDocument crytalrep = new ReportDocument();

            //        crytalrep.Load(@"D:\desarrolloAlm\ErpBapSoftNet_almacen21092015\BapFormulariosNet\D70Produccion\Reportes\CR_req_produccion1.rpt");
            //        ParameterField pf1 = new ParameterField();
            //        ParameterField pf2 = new ParameterField();
            //        ParameterField pf3 = new ParameterField();

            //        ParameterFields ParaFis = new ParameterFields();
            //        ParameterDiscreteValue PDV1 = new ParameterDiscreteValue();
            //        ParameterDiscreteValue PDV2 = new ParameterDiscreteValue();
            //        ParameterDiscreteValue PDV3 = new ParameterDiscreteValue();

            //        pf1.ParameterFieldName = parametro1.ToString();
            //        PDV1.Value = "OP";
            //        pf1.CurrentValues.Add(PDV1);
            //        ParaFis.Add(pf1);
            //        crystalReportViewer1.ParameterFieldInfo = ParaFis; 


            //        pf2.ParameterFieldName = parametro2.ToString();
            //        PDV2.Value = Convert.ToString(BE.serop.ToString());
            //        pf2.CurrentValues.Add(PDV2);
            //        ParaFis.Add(pf2);
            //        crystalReportViewer1.ParameterFieldInfo = ParaFis;

            //        pf3.ParameterFieldName = parametro3.ToString();
            //        PDV3.Value = Convert.ToString(BE.numop.ToString());
            //        pf3.CurrentValues.Add(PDV3);
            //        ParaFis.Add(pf3);
            //        crystalReportViewer1.ParameterFieldInfo = ParaFis;
            //        crystalReportViewer1.ReportSource = crytalrep;
            //        crystalReportViewer1.Show();                    
            //        //crystalReportViewer1.Refresh();                    
            //    }

            //}
            // catch (Exception ex)
            // {
            //     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // }            
        }
                
        private void Frm_reportes_Load(object sender, EventArgs e)
        {
            switch (formulario)
            {
                case "Frm_reporte_explosion_material":
                    active_reporte_explosion_material();
                    break;
                case "Frm_reporte_req_produccion":
                    active_reporte_req_produccion(tipop, serop, numop);
                    break;

                default:
                    break;
            }
        }

        private void Frm_reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
