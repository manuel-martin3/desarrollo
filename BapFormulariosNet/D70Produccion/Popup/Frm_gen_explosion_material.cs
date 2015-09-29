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
    public partial class Frm_gen_explosion_materiales : plantilla
    {
        private String EmpresaID = VariablesPublicas.EmpresaID;
        private String dominio = "";
        private String modulo = "";
        private String local = "";

        private String XNIVEL = "";
        private String XGLOSA = "";
        private String PERFILID = "";
        private DataRow row;
        private Boolean procesado = false;
        private String ActCtacte = "";
        private String ssModo = "";   
        private DataTable TablaOrdenServ;
        private String xarticid = "";


        public Frm_gen_explosion_materiales()
        {
            InitializeComponent();
        }

        private void Frm_req_produccion_Load(object sender, EventArgs e)
        {
            //if (Parent.Parent.Name == "MainProduccion")
            //{
            //    dominio = ((D70Produccion.MainProduccion)MdiParent).dominioid;
            //    modulo = ((D70Produccion.MainProduccion)MdiParent).moduloid;
            //    local = ((D70Produccion.MainProduccion)MdiParent).local;
            //    PERFILID = ((D70Produccion.MainProduccion)MdiParent).perfil;
            //}

            //if (Parent.Parent.Name == "MainTienda")
            //{
            //    dominio = ((D60Tienda.MainTienda)MdiParent).dominioid;
            //    modulo = ((D60Tienda.MainTienda)MdiParent).moduloid;
            //    local = ((D60Tienda.MainTienda)MdiParent).local;
            //    PERFILID = ((D60Tienda.MainTienda)MdiParent).perfil;
            //}

            limpiar_documento();
            form_bloqueado(false);
            btn_nuevo.Enabled = true;
            btn_salir.Enabled = true;                     
            TmpTablaOrdenProd();
          
        }

        void TmpTablaOrdenProd()
        {
            TablaOrdenServ = new DataTable();
            TablaOrdenServ.Columns.Add("proceso", typeof(String));
            TablaOrdenServ.Columns.Add("ordenprod", typeof(String));
            TablaOrdenServ.Columns.Add("articid", typeof(String));
            TablaOrdenServ.Columns.Add("articidold", typeof(String));
            TablaOrdenServ.Columns.Add("articname", typeof(String));
            TablaOrdenServ.Columns.Add("colorid", typeof(String));
            TablaOrdenServ.Columns.Add("cantidad", typeof(Int32));
            TablaOrdenServ.Columns.Add("marca", typeof(String));
            TablaOrdenServ.Columns.Add("peso", typeof(Decimal));
            TablaOrdenServ.Columns.Add("precuni", typeof(Decimal));
            TablaOrdenServ.Columns.Add("precunipeso", typeof(Decimal));
            TablaOrdenServ.Columns.Add("importe", typeof(Decimal));
        }
      
        private void btn_salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btn_nuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            limpiar_documento();
            form_bloqueado(true);
            btn_nuevo.Enabled = false;
            btn_cancelar.Enabled = true;      
        }


        private void limpiar_documento()
        {
            try
            {
                txt_fechexplo.Text = DateTime.Today.ToShortDateString();
                txt_serop.Text = "";                
                txt_numop.Text = "";
                txt_articidold.Text = "";
                txt_articname.Text = "";
                txt_versrec.Text = "";
                txt_serop.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_bloqueado(Boolean var)
        {
            try
            {
                txt_serop.Enabled = var;
                txt_numop.Enabled = false;
                txt_articidold.Enabled = false;
                txt_articname.Enabled = false;
                txt_versrec.Enabled = false;
                txt_fechexplo.Enabled = false;
                btn_neo.Enabled = false;
               
                btn_nuevo.Enabled = false;
                btn_cancelar.Enabled = false;
                btn_imprimir.Enabled = false;             
                btn_salir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            form_accion_cancelEdicion(1);
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
                ssModo = "OTR";
            }
        }

        private void txt_serop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AyudaOrdProd();
            }
        }

        private void AyudaOrdProd()
        {
            try
            {
                var frmayuda = new Ayudas.Frm_help_general();

                frmayuda.tipoo = "sql";
                frmayuda.titulo = "AYUDA ORDEN DE PRODUCCION";
                frmayuda.sqlquery = "SELECT " +
                                           " serop,numop," +
                                           " cab.articid, " +
                                           " art.articidold,art.articname,art.marcaid,ma.marcaname, " +
                                           " art.lineaid,li.lineaname,art.generoid,ge.generoname " +
                                    "FROM tb_pp_ordenprodcab cab ";

                frmayuda.sqlinner =
                                    "LEFT JOIN tb_pt_articulo art ON cab.articid = art.articid " +
                                    "LEFT JOIN tb_pt_marca ma ON art.marcaid = ma.marcaid " +
                                    "LEFT JOIN tb_pt_linea li ON art.lineaid = li.lineaid " +
                                    "LEFT JOIN tb_pt_genero ge ON art.generoid = ge.generoid ";

                frmayuda.sqlwhere = "WHERE";
                frmayuda.sqland = string.Empty;
                frmayuda.criteriosbusqueda = new string[] { "SERIE", "LINEA", "MARCA" };
                frmayuda.columbusqueda = "serop + numop,li.lineaname,ma.marcaname";
                frmayuda.returndatos = "0,1,2,3,4";
                frmayuda.Owner = this;
                frmayuda.PasaProveedor = RecibeData;
                frmayuda.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecibeData(String x1, String x2, String x3, String x4, String x5)
        {
            txt_serop.Text = x1.ToString();
            txt_numop.Text = x2.ToString();
            xarticid = x3.ToString();
            txt_articidold.Text = x4.ToString();
            txt_articname.Text = x5.ToString();
            validaOrdenProd_version();
            btn_neo.Enabled = true;
        }


        void validaOrdenProd_version()
        { 
            /******************
             * Validamos Para Obtener la Version de una Receta
             * *************/

            DataTable dt = new DataTable();
            String Query = " SELECT [version] " +
                           " FROM [dbo].[tb_pp_recetacab] WHERE articid = '" + xarticid.ToString() + "' ";
            dt = DatosSQL(Query);                  
           
            if (dt.Rows.Count > 0)
                txt_versrec.Text = dt.Rows[0]["version"].ToString();
            else
                txt_versrec.Text = "";
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

        private void btn_neo_Click(object sender, EventArgs e)
        {
            tb_pp_ordenprodBL BL = new tb_pp_ordenprodBL();
            tb_pp_ordenprod BE = new tb_pp_ordenprod();
            DataTable dt = new DataTable();

            BE.tipop = "OP";
            BE.serop = txt_serop.Text;
            BE.numop = txt_numop.Text;
            BE.articid = xarticid.ToString();
            BE.version = txt_versrec.Text;          
            if (BL.Gen_Explosion(EmpresaID, BE))
            {
                MessageBox.Show("Explosion Generado Correctamente !!!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //luego Se Tiene que Refrescar el Grid
                Close();
            }                       
            
        }

    }
}
