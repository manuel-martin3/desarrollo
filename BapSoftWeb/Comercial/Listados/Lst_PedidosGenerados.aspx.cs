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


public partial class Comercial_Listados_Lst_PedidosGenerados : System.Web.UI.Page
{
    SimpleAES funcript = new SimpleAES();
    DataTable TablaPendAprob;
    private DataRow row;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["ssEmpresaID"] = "02";
        if (!Page.IsPostBack)
        {
            cargar_grilla();
        } 
    }

    void cargar_grilla()
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        TablaPendAprob = BL.GetAll_PendAprob(Session["ssEmpresaID"].ToString(), BE).Tables[0];

        DataTable dtDatos = new DataTable();
        if (TablaPendAprob.Rows.Count > 0)
        {
            dtDatos.Columns.Add("numdoc");
            dtDatos.Columns.Add("ctactename");
            dtDatos.Columns.Add("canalventaname");
            dtDatos.Columns.Add("vendorname");
            dtDatos.Columns.Add("imponeto");
            dtDatos.Columns.Add("fecre");            
            string canalid = "";
            string canalname = "";
            for (int i = 0; i < TablaPendAprob.Rows.Count; i++)
            {
                DataRow dtRow = dtDatos.NewRow();
                dtRow["numdoc"] = TablaPendAprob.Rows[i]["numdoc"].ToString();
                dtRow["ctactename"] = TablaPendAprob.Rows[i]["ctactename"].ToString();
                canalname = TablaPendAprob.Rows[i]["canalventaid"].ToString();
                switch (canalid.ToString())
                {
                    case "01":
                        canalname = "NO PROMOCIONALES";
                        break;
                    case "02":
                        canalname = "CLIENTES ESPECIALES";
                        break;
                    case "03":
                        canalname = "MARCAS PROMOCIONALES";
                        break;
                    default:
                        canalname = "NO PROMOCIONALES";
                        break;
                }
                dtRow["canalventaname"] = canalname.ToString();
                dtRow["vendorname"] = TablaPendAprob.Rows[i]["vendorname"].ToString();
                dtRow["imponeto"] = TablaPendAprob.Rows[i]["imponeto"].ToString();                
                dtRow["fecre"] = TablaPendAprob.Rows[i]["fecre"].ToString().Substring(0,10);                

                dtDatos.Rows.Add(dtRow);
            }
            GridView.DataSource = dtDatos;
            GridView.DataBind();
        }
    }
       


    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "numdoc")
        {
            int index;
            string valor;
            index = int.Parse(e.CommandArgument.ToString());
            valor = GridView.DataKeys[index].Value.ToString();
            //   lblErr.Text = valor.ToString();
        }

    }
    protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }





    protected void LkBDelete_Click(object sender, EventArgs e)
    {
        
    }

    protected void LkBCancelDelete_Click(object sender, EventArgs e)
    {
        
    }

    protected void LkBSave_Click(object sender, EventArgs e)
    {
        
    }

    protected void LkBCancelSave_Click(object sender, EventArgs e)
    {
        
    }

    protected void LkBUpdate_Click(object sender, EventArgs e)
    {
        string val = HdFUpdateItem.Value.ToString();        
        Session["xtipdoc"] = val.ToString().Substring(0, 2);
        Session["xserdoc"] = val.ToString().Substring(2, 4);
        Session["xnumdoc"] = (val.ToString().Substring(6, 4)).PadLeft(10, '0');
        Session["ssModo"] = "EDI";
        Response.Redirect("~/Comercial/Frm_Proformas.aspx#registro");
    }

    protected void LkBCancelUpdate_Click(object sender, EventArgs e)
    {
        
    }

    protected void LkBPrint_Click(object sender, EventArgs e)
    {
        //string val = LblIdSer.Text;
        string val = HdFPrintItem.Value.ToString();
        Session["xtipdoc"] = val.ToString().Substring(0, 2);
        Session["xserdoc"] = val.ToString().Substring(3, 4);
        Session["xnumdoc"] = (val.ToString().Substring(8, 4)).PadLeft(10, '0');
        /*Llamada documento pdf*/
        tb_cxc_cronoPagosBL BL = new tb_cxc_cronoPagosBL();
        tb_cxc_cronoPagos BE = new tb_cxc_cronoPagos();
        DataTable dt = new DataTable();
        BE.tipdoc = Session["xtipdoc"].ToString();
        BE.serdoc = Session["xserdoc"].ToString();
        BE.numdoc = Session["xnumdoc"].ToString();
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
            Session["Tabla01"] = dt;

        tb_cxc_pedidodetBL BL2 = new tb_cxc_pedidodetBL();
        tb_cxc_pedidodet BE2 = new tb_cxc_pedidodet();
        DataTable dt2 = new DataTable();
        BE2.tipdoc = Session["xtipdoc"].ToString();
        BE2.serdoc = Session["xserdoc"].ToString();
        BE2.numdoc = Session["xnumdoc"].ToString();
        dt2 = BL2.GetAll(Session["ssEmpresaID"].ToString(), BE2).Tables[0];
        if (dt2.Rows.Count > 0)
            Session["Tabla02"] = dt2;
        //string pagina = "Rpt_Proforma.aspx";
        string pagina = "Rpt_Pedido.aspx";
        reporte_pdf(pagina);        
    }

    protected void LkBCancelPrint_Click(object sender, EventArgs e)
    {
        
    }


    protected void LkBSearch_Click(object sender, EventArgs e)
    {
        
    }

    protected void LkBCancelSer_Click(object sender, EventArgs e)
    {

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
            ClientMessage(ex.Message);
        }



    }

    public void ClientMessage(String ClientMessage)
    {
        MensajeJQuery(ClientMessage);
    }

    public void MensajeJQuery(String Message)
    {
        //*******************************************
        // MensajeJQuery 
        //*******************************************
        //En esta ocasión agregaremos un literal que a su vez agregaremos un div que nos servira de Dialog
        //O si prefieren pueden crear el div directamente en el HTML
        Literal li = new Literal();
        StringBuilder sbMensaje = new StringBuilder();
        //Creamos el Div
        sbMensaje.Append("<div id='dialog-message' title='Aviso'>");
        sbMensaje.Append("<div class='ui-widget'>");
        sbMensaje.Append("<div class='ui-state-error ui-corner-all'style='padding: 0 .7em;'>");
        sbMensaje.Append("<p><span class='ui-icon ui-icon-alert' style='float: left; margin-right: .3em;'></span>");
        //Le indicamos el mensaje a mostrar
        sbMensaje.Append(Message);
        //cerramos el div
        sbMensaje.Append("</p></div></div></div>");

        sbMensaje.Append("<script type='text/javascript'>");
        sbMensaje.Append("$(function() {");
        //Destruimos cualquier rastro de dialogo abierto
        sbMensaje.Append("$('#dialog-message').dialog('destroy');");
        //Si quieres que muestre un boton para cerrar el mensaje seria esta linea que dejare en comentario
        sbMensaje.Append("$('#dialog-message').dialog({ modal: true, buttons: { 'Ok': function() { $( this ).dialog('close'); } } });");
        sbMensaje.Append("});");
        sbMensaje.Append("</script>");
        //Agremamos el texto del stringbuilder al literal
        li.Text = sbMensaje.ToString();
        //Agregamos el literal a la pagina
        Page.Controls.Add(li);
    }

    protected void LkBNew_Click(object sender, EventArgs e)
    {
        Session["ssModo"] = "NEW";
        Response.Redirect("~/Comercial/Frm_Proformas.aspx#registro");        
    }
}