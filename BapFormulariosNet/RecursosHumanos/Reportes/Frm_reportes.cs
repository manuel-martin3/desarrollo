using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using CrystalDecisions.CrystalReports.Engine;

namespace BapFormulariosNet.RecursosHumanos.Reportes
{
    public partial class Frm_reportes : Form
    {
        public String dominioid { get; set; }
        public String moduloiddies { get; set; }
        public String ccencos { get; set; }
        public String ccargo { get; set; }
        public Int32 modcalculo { get; set; }
        public String productidold { get; set; }
        public String moduloid { get; set; }
        public String local { get; set; }
        public String formulario { get; set; }
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
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

        public ReportDocument Reporte { get; set; }

        public DataTable Table { get; set; }
        public String mottrasladointid { get; set; }

        public Frm_reportes()
        {
            InitializeComponent();
        }


        private DataTable Movimiento_linea()
        {
            try
            {
                var TablaLinea = new DataTable("Linea");

                var BL = new tb_60lineaBL();
                var BE = new tb_60linea();

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
        private void active_linea()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Reporte_Contratos()
        {
            try
            {
                var TablaGrupo = new DataTable("Contratos");
                var BE = new tb_plla_fichatrabajadorescontratos();

                BE.cencosid = cencosid.ToString();
                BE.cencosid = cencosid.ToString();

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


        private void active_contrato()
        {
            try
            {
                var path = string.Empty;
                var directorios = Application.StartupPath.Split('\\');
                if (directorios.Length > 0)
                {
                    path = directorios[0] + "\\" + directorios[1];
                }

                var reporteContrato = new Crpt_Contratos();
                reporteContrato.SetDataSource(Reporte_Contratos());
                crystalReportViewer1.ReportSource = reporteContrato;
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
                case "Frm_linea":
                    active_linea();
                    break;
                case "Frm_Contrato":
                    active_contrato();
                    break;
                default:
                    break;
            }
        }
    }
}
