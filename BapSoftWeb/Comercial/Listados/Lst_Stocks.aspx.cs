using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Text;
using System.IO;

using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxEditors;
using Word = Microsoft.Office.Interop.Word;

using Microsoft.VisualBasic;
using System.Reflection;

public partial class Comercial_Listados_LstStocks : System.Web.UI.Page
{
    SimpleAES funcript = new SimpleAES();
    DataTable TablaProd, TablaPedido, TablaTallas;
    private DataRow row;
    DataTable dtDatos;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ssEmpresaID"] = "02";                     
            Cargar_ListaProd("");
            AspxDgb_prod.ExpandAll();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "searchPopclick();", true);
        }
    }



    void ArmarTabla()
    {
        dtDatos = new DataTable("stock");
        dtDatos.Columns.Add("marcaid", typeof(String));
        dtDatos.Columns.Add("lineaid", typeof(String));
        dtDatos.Columns.Add("generoid", typeof(String));
        dtDatos.Columns.Add("fecha", typeof(DateTime));
        dtDatos.Columns.Add("articid", typeof(String));
        dtDatos.Columns.Add("colorid", typeof(String));
        dtDatos.Columns.Add("tallaid", typeof(String));
        dtDatos.Columns.Add("sto01", typeof(Int32));
        dtDatos.Columns.Add("sto02", typeof(Int32));
        dtDatos.Columns.Add("sto03", typeof(Int32));
        dtDatos.Columns.Add("sto04", typeof(Int32));
        dtDatos.Columns.Add("sto05", typeof(Int32));
        dtDatos.Columns.Add("sto06", typeof(Int32));
        dtDatos.Columns.Add("sto07", typeof(Int32));
        dtDatos.Columns.Add("sto08", typeof(Int32));
        dtDatos.Columns.Add("sto09", typeof(Int32));
        dtDatos.Columns.Add("sto10", typeof(Int32));
        dtDatos.Columns.Add("sto11", typeof(Int32));
        dtDatos.Columns.Add("sto12", typeof(Int32));
        dtDatos.Columns.Add("ta01", typeof(String));
        dtDatos.Columns.Add("ta02", typeof(String));
        dtDatos.Columns.Add("ta03", typeof(String));
        dtDatos.Columns.Add("ta04", typeof(String));
        dtDatos.Columns.Add("ta05", typeof(String));
        dtDatos.Columns.Add("ta06", typeof(String));
        dtDatos.Columns.Add("ta07", typeof(String));
        dtDatos.Columns.Add("ta08", typeof(String));
        dtDatos.Columns.Add("ta09", typeof(String));
        dtDatos.Columns.Add("ta10", typeof(String));
        dtDatos.Columns.Add("ta11", typeof(String));
        dtDatos.Columns.Add("ta12", typeof(String));      
    }

    void Cargar_ListaProd(String valorfind)
    {
        //tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL();
        //tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        //BE.marcaid = "";
        //BE.lineaid = "";
        //BE.generoid = "";
        //BE.articid = "";

        //TablaProd = BL.GetAllStkDisp(Session["ssEmpresaID"].ToString(), BE).Tables[0];


        //AspxDgb_prod.DataSource = TablaProd;
        //AspxDgb_prod.DataBind();
        //AspxDgb_prod.ExpandAll();


    }

    protected void gv_DetailRowExpandedChanged(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewDetailRowEventArgs e)
    {

    }


}