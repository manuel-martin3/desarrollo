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
    DataTable TablaProd, TablaPedido, TablaTallas, dtDetalle;
    private DataRow row;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            ArmarTabla02();
            cargar_grillaProd("");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "searchPopclick();", true);
        }
    }


    private void ArmarTabla02()
    {
        dtDetalle = new DataTable();
        dtDetalle.Columns.Add("articidold");
        dtDetalle.Columns.Add("articname");
        dtDetalle.Columns.Add("colorid");
        dtDetalle.Columns.Add("colorname");

        dtDetalle.Columns.Add("ta01");
        dtDetalle.Columns.Add("ta02");
        dtDetalle.Columns.Add("ta03");
        dtDetalle.Columns.Add("ta04");
        dtDetalle.Columns.Add("ta05");
        dtDetalle.Columns.Add("ta06");
        dtDetalle.Columns.Add("ta07");
        dtDetalle.Columns.Add("ta08");
        dtDetalle.Columns.Add("ta09");
        dtDetalle.Columns.Add("ta10");
        dtDetalle.Columns.Add("ta11");
        dtDetalle.Columns.Add("ta12");

        dtDetalle.Columns.Add("sto01");
        dtDetalle.Columns.Add("sto02");
        dtDetalle.Columns.Add("sto03");
        dtDetalle.Columns.Add("sto04");
        dtDetalle.Columns.Add("sto05");
        dtDetalle.Columns.Add("sto06");
        dtDetalle.Columns.Add("sto07");
        dtDetalle.Columns.Add("sto08");
        dtDetalle.Columns.Add("sto09");
        dtDetalle.Columns.Add("sto10");
        dtDetalle.Columns.Add("sto11");
        dtDetalle.Columns.Add("sto12");

        Session["ssdtDetalle"] = dtDetalle;
    }

    protected void GridViewProd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "articidold")
        {
            int index;
            string valor;
            index = int.Parse(e.CommandArgument.ToString());
            valor = GridViewProd.DataKeys[index].Value.ToString();
            //lblErr.Text = valor.ToString();
        }
    }

    // Cambiaremos de Reporte a POPUP
    protected void btn_search_Click(object sender, EventArgs e)
    {
        // Aca Cargaremos el Reporte Detallado de los Pedidos
        // Obtenemos el HdFarticid = articid
        String xarticid = HdFarticid.Value.ToString();
                     
        string pagina = "Rpt_DetallePedido.aspx";
        reporte_pdf(pagina);
        
        //cargar_grillaProd("");
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "searchPopclick();", true);
    }

    private void reporte_pdf(string pagina)
    {
        try
        {
            string strURL = "";
            //string strCifrado = funcript.EncryptData(strURL);
            string cifrado = funcript.EncryptToString(strURL);
            //ClientMessage(cifrado);
            Literal li = new Literal();
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            /*sbMensaje.Append("window.open('ve_rpt_docs.aspx?data=" + cifrado + "', 'mywindow','location=0,status=0,scrollbars=0,resizable=0,menubar=0,channelmode=0,directories=0,fullscreen=0,titlebar=0,toolbar=0')");*/
            sbMensaje.Append("window.open('Reportes/" + pagina.ToString() + "?data=" + cifrado + "', 'mywindow','location=0,status=0,scrollbars=0,resizable=1,menubar=0,toolbar=0')");
            sbMensaje.Append("</script>");
            //Agremamos el texto del stringbuilder al literal
            li.Text = sbMensaje.ToString();

            //Agregamos el literal a la pagina
            Page.Controls.Add(li);
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
        }
    }

    void cargar_grillaProd(String valorfind)
    {
        tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL();
        tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        DataTable dt = new DataTable();

        //BE.valorfind = valorfind.ToString();
        BE.filtro = "1";
        TablaProd = BL.GetAll_Grid(Session["ssEmpresaID"].ToString(), BE).Tables[0];

        DataTable dtDatos = new DataTable();
        if (TablaProd.Rows.Count > 0)
        {
            dtDatos.Columns.Add("articid");
            dtDatos.Columns.Add("articidold");
            dtDatos.Columns.Add("articname");
            dtDatos.Columns.Add("stockdisp");             
            dtDatos.Columns.Add("pvt_cremenor");

            dtDatos.Columns.Add("prec_etiq");
            dtDatos.Columns.Add("prec_ofer");
            dtDatos.Columns.Add("estadoid");
            dtDatos.Columns.Add("estadoname");
          
            for (int i = 0; i < TablaProd.Rows.Count; i++)
            {
                DataRow dtRow = dtDatos.NewRow();
                dtRow["articid"] = TablaProd.Rows[i]["articid"].ToString();
                dtRow["articidold"] = TablaProd.Rows[i]["articidold"].ToString();
                dtRow["articname"] = TablaProd.Rows[i]["articname"].ToString();
                dtRow["stockdisp"] = TablaProd.Rows[i]["stockdisp"].ToString();
                dtRow["pvt_cremenor"] = TablaProd.Rows[i]["pvt_cremenor"].ToString();

                dtRow["prec_etiq"] = TablaProd.Rows[i]["prec_etiq"].ToString();
                dtRow["prec_ofer"] = TablaProd.Rows[i]["prec_ofer"].ToString();
                dtRow["estadoid"] = TablaProd.Rows[i]["estadoid"].ToString();
                dtRow["estadoname"] = TablaProd.Rows[i]["estadoname"].ToString();    

                dtDatos.Rows.Add(dtRow);
            }
            GridViewProd.DataSource = dtDatos;
            GridViewProd.DataBind();
        }
    }


    void Data_GridStockArtic()
    {
        tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL();
        tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        DataTable dt = new DataTable();
        BE.articidold = HdFarticid.Value.ToString();
        dt = BL.GetAll_StockProdDet(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        ArmarTabla02();        
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dtRow = dtDetalle.NewRow();
                dtRow["colorid"] = dt.Rows[i]["colorid"].ToString();
                dtRow["colorname"] = dt.Rows[i]["colorname"].ToString();
                dtRow["sto01"] = dt.Rows[i]["sto01"].ToString();
                dtRow["sto02"] = dt.Rows[i]["sto02"].ToString();
                dtRow["sto03"] = dt.Rows[i]["sto03"].ToString();
                dtRow["sto04"] = dt.Rows[i]["sto04"].ToString();
                dtRow["sto05"] = dt.Rows[i]["sto05"].ToString();
                dtRow["sto06"] = dt.Rows[i]["sto06"].ToString();
                dtRow["sto07"] = dt.Rows[i]["sto07"].ToString();
                dtRow["sto08"] = dt.Rows[i]["sto08"].ToString();
                dtRow["sto09"] = dt.Rows[i]["sto09"].ToString();
                dtRow["sto10"] = dt.Rows[i]["sto10"].ToString();
                dtRow["sto11"] = dt.Rows[i]["sto11"].ToString();
                dtRow["sto12"] = dt.Rows[i]["sto12"].ToString();
                dtDetalle.Rows.Add(dtRow);
            }
            dgb_stockdisponible.DataSource = dtDetalle;
            dgb_stockdisponible.DataBind();

            lblCod.Text = dt.Rows[0]["articidold"].ToString();
            lblNam.Text = dt.Rows[0]["articname"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[2].Text = dt.Rows[0]["ta01"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[3].Text = dt.Rows[0]["ta02"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[4].Text = dt.Rows[0]["ta03"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[5].Text = dt.Rows[0]["ta04"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[6].Text = dt.Rows[0]["ta05"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[7].Text = dt.Rows[0]["ta06"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[8].Text = dt.Rows[0]["ta07"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[9].Text = dt.Rows[0]["ta08"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[10].Text = dt.Rows[0]["ta09"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[11].Text = dt.Rows[0]["ta10"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[12].Text = dt.Rows[0]["ta11"].ToString();
            dgb_stockdisponible.HeaderRow.Cells[13].Text = dt.Rows[0]["ta12"].ToString();
        }
       // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "searchPopclick();", true);
    }

    protected void LkBSearch_Click(object sender, EventArgs e)
    {       
        Data_GridStockArtic();        
    }
   
    protected void dgb_stockdisponible_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgb_stockdisponible.PageIndex = e.NewPageIndex;
        Data_GridStockArtic();
    }


    protected void btnCerrar_Click(object sender, EventArgs e)
    {        
        //ArmarTabla02();
        dtDetalle = new DataTable();
        dgb_stockdisponible.DataSource = dtDetalle;
        dgb_stockdisponible.DataBind();

        lblCod.Text = "";
        lblNam.Text = "";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "searchPopclick();", true);
    }
    
}