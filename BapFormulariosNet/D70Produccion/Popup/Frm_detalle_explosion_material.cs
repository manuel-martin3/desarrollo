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

using System.Data.SqlClient;
using LayerDataAccess;

namespace BapFormulariosNet.D70Produccion.Popup
{
    public partial class Frm_detalle_explosion_material : plantilla
    {
        public String xtipop { get; set; }
        public String xnumop { get; set; }
        public String xserop { get; set; }
        public String xarticid { get; set; }
        public String xarticidold { get; set; }
        public String xarticname { get; set; }

        private String xtallaid;

        public Frm_detalle_explosion_material()
        {
            InitializeComponent();
        }

        private void Frm_detalle_explosion_material_Load(object sender, EventArgs e)
        {
            limpiar_documento();
            form_bloqueado(false);
            CargamosDatos();
            ValidamosDatos();
            ValidamosDatosTalla();
            CargamosCabExplo();
            CargamosDetExplo();
        }

        private void limpiar_documento()
        {
            txt_articidold.Text = "";
            txt_articname.Text = "";
            txt_serop.Text = "";
            txt_numop.Text = "";
            txt_versrec.Text = "";
            xtallaid = "";
            txt_fechexplo.Text = DateTime.Today.ToShortDateString();
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                txt_articidold.Enabled = false;
                txt_articname.Enabled = false;
                txt_serop.Enabled = false;
                txt_numop.Enabled = false;
                txt_versrec.Enabled = false;
                txt_fechexplo.Enabled = false;

                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;
                btn_clave.Enabled = true;
                btn_log.Enabled = true;
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void CargamosDatos()
        {
          
            txt_articidold.Text = xarticidold;
            txt_articname.Text = xarticname;
            txt_serop.Text = xserop;
            txt_numop.Text = xnumop;

        }

        void ValidamosDatos()
        {
            DataTable dt = new DataTable();
            String Query = " SELECT [version] " +
                           " FROM [dbo].[tb_pp_recetacab]  " +
                           " WHERE articid = '" + xarticid.ToString() + "' ";
            dt = DatosSQL(Query);

            if (dt.Rows.Count > 0)
                txt_versrec.Text = dt.Rows[0]["version"].ToString();
            else
                txt_versrec.Text = "";

        }


        void ValidamosDatosTalla()
        {
            DataTable dt = new DataTable();
            String Query = " SELECT tallaid " +
                           " FROM tb_pt_articulo  " +
                           " WHERE articid = '" + xarticid.ToString() + "' ";
            dt = DatosSQL(Query);

            if (dt.Rows.Count > 0)
                xtallaid = dt.Rows[0]["tallaid"].ToString();
            else
                xtallaid = "";

        }


        private DataTable DatosSQL(String query)
        {
            var conex = new ConexionDA();
            var dt = new DataTable();

            using (var cnx = new SqlConnection(conex.empConexion(VariablesPublicas.EmpresaID)))
            {
                using (var cmd = new SqlCommand("gspHelpSQL", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sqlquery", SqlDbType.VarChar).Value = query;

                    try
                    {
                        cnx.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        void CargamosCabExplo()
        {
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            tb_pp_ordenprod BE = new tb_pp_ordenprod();
            DataTable dt = new DataTable();

            BE.tipop = "OP";
            BE.serop = txt_serop.Text;
            BE.numop = txt_numop.Text;
            BE.articid = xarticid.ToString();
            BE.tallaid = xtallaid.ToString();
            BE.idx = "CAB";

            dt = BL.GetAllDet_Explosion("02", BE).Tables[0];
            dgv_talla.DataSource = dt;
        }


        void CargamosDetExplo()
        {
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            tb_pp_ordenprod BE = new tb_pp_ordenprod();
            DataTable dt = new DataTable();

            BE.tipop = "OP";
            BE.serop = txt_serop.Text;
            BE.numop = txt_numop.Text;            
            BE.idx = "DET";

            dt = BL.GetAllDet_Explosion("02", BE).Tables[0];
            dgv_detalle.DataSource = dt;
        }


    }
}
