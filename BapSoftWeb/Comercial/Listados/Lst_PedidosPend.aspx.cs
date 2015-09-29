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

public partial class Comercial_Listados_Lst_ProformaAprob : System.Web.UI.Page
{
    SimpleAES funcript = new SimpleAES();
    DataTable TablaPendAprob;
    private DataRow row;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ValIngreso();           
            bloqueo("01", false);
            bloqueo("02", false);
            bloqueo("03", false);            
            cargarComboEstado();
            cargar_grilla();
            //cargar_grilla();
        }
    }

    // VERIFICO COMO ESTOY INGRESANDO ( COMO QUE USUARIO ESTOY INGRESANDO )
    void ValIngreso()
    {
        if (Equivalencias.Right(Session["ssPerfil"].ToString(), 4) != "0000")
        {
            String xusu = Session["ssUsuar"].ToString().Trim();
            tb_cxc_vendorBL BL = new tb_cxc_vendorBL();
            tb_cxc_vendor BE = new tb_cxc_vendor();
            DataTable dt = new DataTable();
            BE.usuarweb = xusu;
            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                chk_vendedor.Visible = false;
                txt_vendorid.Value = dt.Rows[0]["vendorid"].ToString();
                txt_vendorname.Text = dt.Rows[0]["vendorname"].ToString();
            }
            else
            {
                chk_cliente.Visible = false;
                chk_estado.Visible = false;
                chk_vendedor.Visible = false;
                txt_vendorid.Value = "NULO";
                txt_vendorname.Text = "VENDEDOR SIN PEDIDOS";
            }
        }
    }



    void cargar_grilla() {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();

        BE.ctacte = txt_ctacte.Value.ToString();

        if (Equivalencias.Right(Session["ssPerfil"].ToString(), 4) != "0000")        
            BE.vendorid = txt_vendorid.Value.ToString();
        
        if(chk_estado.Checked)
            BE.aprob_gerencial = cmbestado.SelectedValue.ToString();
        BE.filtro = "2";
        TablaPendAprob = BL.GetAll_PendAprob(Session["ssEmpresaID"].ToString(), BE).Tables[0];

        DataTable dtDatos = new DataTable();
        if (TablaPendAprob.Rows.Count > 0)
        {
            dtDatos.Columns.Add("nmruc");
            dtDatos.Columns.Add("ctactename");
            dtDatos.Columns.Add("serdoc");
            dtDatos.Columns.Add("numdoc");
            dtDatos.Columns.Add("fecre");
            dtDatos.Columns.Add("aprob_status");
            dtDatos.Columns.Add("estado");
            dtDatos.Columns.Add("aprob_obser");
            for (int i = 0; i < TablaPendAprob.Rows.Count; i++)
            {
                DataRow dtRow = dtDatos.NewRow();
                dtRow["nmruc"] = TablaPendAprob.Rows[i]["nmruc"].ToString();
                dtRow["ctactename"] = TablaPendAprob.Rows[i]["ctactename"].ToString();
                dtRow["serdoc"] = TablaPendAprob.Rows[i]["serdoc"].ToString();
                dtRow["numdoc"] = TablaPendAprob.Rows[i]["numdoc"].ToString();
                dtRow["fecre"] = TablaPendAprob.Rows[i]["fecre"].ToString();
                dtRow["aprob_status"] = TablaPendAprob.Rows[i]["aprob_status"].ToString();
                dtRow["estado"] = TablaPendAprob.Rows[i]["estado"].ToString();
                dtRow["aprob_obser"] = TablaPendAprob.Rows[i]["aprob_obser"].ToString();
                dtDatos.Rows.Add(dtRow);
            }
            GridView.DataSource = dtDatos;
            GridView.DataBind();
        }
        else {           
            GridView.DataSource = TablaPendAprob;
            GridView.DataBind();
        }
    }
    


    protected void LkBCancelDel_Click(object sender, EventArgs e)
    {

    }

    protected void LkBSearch_Click(object sender, EventArgs e)
    {
        //string val = LblIdSer.Text;
        string val = HdFIdSer.Value.ToString();

        Session["xtipdoc"] = val.ToString().Substring(0, 2);
        Session["xserdoc"] = val.ToString().Substring(3, 4);
        Session["xnumdoc"] = (val.ToString().Substring(8, 5)).PadLeft(10, '0');
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
        string pagina = "Rpt_Proforma.aspx";
        reporte_pdf(pagina); 

        /**/
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
            sbMensaje.Append("window.open('Reportes/"+ pagina.ToString() +"?data=" + cifrado + "', 'mywindow','location=0,status=0,scrollbars=0,resizable=1,menubar=0,toolbar=0')");
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

    protected void LkBCancelSer_Click(object sender, EventArgs e)
    {

    }
    
    protected void LkBCancelUpd_Click(object sender, EventArgs e)
    {

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

    protected void LkBCancelSta_Click(object sender, EventArgs e)
    {

    }
    protected void LkBStatus_Click(object sender, EventArgs e)
    {
        if (RBL1.SelectedValue == "0")
        {
            HdF1.Value = "0";
        }
        else if (RBL1.SelectedValue == "1")
        {
            HdF1.Value = "1";
        }
        else
        {
            HdF1.Value = "2";
        }

        //lanzarProgress(HdF1.Value.ToString(), HdF2.Value.ToString());
        UpdatePendAprob(HdF1.Value.ToString(), HdF2.Value.ToString());
        System.Threading.Thread.Sleep(2000);
        cargar_grilla();

    }

    public void lanzarProgress(string val1, string val2)
    {
        string estado = val1.ToString();
        string proforma = val2.ToString();
        
        string tipdoc = proforma.ToString().Substring(0,2);
        string serdoc = proforma.ToString().Substring(2,4);
        string numdoc = (proforma.ToString().Substring(6,4)).PadLeft(10, '0');        
        string obs = LblIdObs.Text;

        string rpta = "";
        try
        {
            tb_cxc_evalcredBL obj_prof = new tb_cxc_evalcredBL();
            //obj_prof.GetAll_PendAprob(proforma.ToString(), estado.ToString(), obs);
            //this.refreca();
        }
        catch (Exception ex)
        {
            //MessageBox.Show("codigo ya exixte");
            rpta = ex.Message;
        }
        
    }
    private void UpdatePendAprob(string val1, string val2)
    {
        try
        {
            var BL = new tb_cxc_evalcredBL();
            var BE = new tb_cxc_evalcred();
            string proforma = val2.ToString();

            string tipdoc = proforma.ToString().Substring(0, 2);
            string serdoc = proforma.ToString().Substring(2, 4);
            string numdoc = (proforma.ToString().Substring(6, 4)).PadLeft(10, '0');

            BE.tipdoc = tipdoc.ToString();
            BE.serdoc = serdoc.ToString();
            BE.numdoc = numdoc.ToString();           
            BE.status = val1.ToString();            
            BE.obs_gerencial = LblIdObs.Text;            
            //BE.usuar = Session["ssUsuar"].ToString().Trim();

            if (BL.UpdatePendAprob(Session["ssEmpresaID"].ToString(), BE))
            {
                ClientMessage("Registros Modificados Correctamente !!!");                
                //LimpiarDocumento();
            }
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }





    void bloqueo(String btn, Boolean var)
    {
        // Div Cliente
        if (btn.Equals("01"))
        {
            txt_ctactename.Enabled = var;
            //btn_buscaCliente.CssClass = css;
            btn_buscaCliente.Visible = var;
        }

        // Div Vendedor
        if (btn.Equals("02"))
        {
            txt_vendorname.Enabled = var;
            //btn_buscaVendor.CssClass = css;
            btn_buscaVendor.Visible = var;
        }

        // Div Estado
        if (btn.Equals("03"))
        {
            cmbestado.Enabled = var;
        }
    }

    void cargarComboEstado()
    {
        // CARGAMOS COMBOS PARA LA VISTA DE VENDEDORES
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.canalventaid = Session["ssCanalVentaId"].ToString();
        BE.filtro = "";
        dt = BL.GetAll_Estados(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        cmbestado.DataSource = dt;
        cmbestado.DataValueField = "aprob_status";
        cmbestado.DataTextField = "descripcion";
        cmbestado.DataBind();
    }

    protected void chk_cliente_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_cliente.Checked)
        {
            bloqueo("01", true);
        }
        else
        {
            bloqueo("01", false);
            txt_ctacte.Value = "";
            txt_ctactename.Text = "";
        }
    }

    protected void chk_vendedor_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_vendedor.Checked)
        {
            bloqueo("02", true);
        }
        else
        {
            bloqueo("02", false);
            txt_vendorid.Value = "";
            txt_vendorname.Text = "";
        }
    }

    protected void chk_estado_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_estado.Checked)
        {
            bloqueo("03", true);
        }
        else
        {
            bloqueo("03", false);
            cmbestado.Enabled = false;
            cmbestado.SelectedIndex = 0;
        }
    }


    // CLIENTES
    private void data_gridCliente()
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();

        switch (cmbcliente.SelectedValue)
        {
            case "01":
                BE.ctacte = txt_buscar.Text.Trim().ToUpper();
                break;
            case "02":
                BE.ctactename = txt_buscar.Text.Trim().ToUpper();
                break;
            //case "03":
            //    BE.nmruc = txt_buscar.Text.Trim().ToUpper();
            //    break;
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            dgb_cliente.Columns.Clear();
            dgb_cliente.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            dgb_cliente.Columns.Add(image);

            BoundField DDNNI;
            DDNNI = new BoundField();
            DDNNI.DataField = "ctacte";
            DDNNI.HeaderText = "CODIGO";
            DDNNI.ItemStyle.Width = 50;
            dgb_cliente.Columns.Add(DDNNI);

            BoundField NOMBR;
            NOMBR = new BoundField();
            NOMBR.DataField = "ctactename";
            NOMBR.HeaderText = "NOMBRES";
            NOMBR.ItemStyle.Width = 250;
            dgb_cliente.Columns.Add(NOMBR);
            BE.filtro = "1";
            BE.vendorid = txt_vendorid.Value.ToString();
            dt = BL.GetAll_Filtro(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_cliente.DataSource = dt;
                dgb_cliente.DataBind();
                dgb_cliente.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;// ClientMessage(ex.Message);
        }
    }

    protected void btn_buscar01_Click(object sender, EventArgs e)
    {
        data_gridCliente();
    }

    protected void dgb_cliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            String xctacte = dgb_cliente.SelectedRow.Cells[1].Text;
            ValidaCliente(xctacte);
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);            
        }
    }

    void ValidaCliente(String xctacte)
    {
        clienteWebBL BL = new clienteWebBL();
        tb_cliente BE = new tb_cliente();
        DataTable dt = new DataTable();
        BE.ctacte = xctacte;
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        //txt_ctacte.Text = dt.Rows[0]["ctacte"].ToString();
        txt_ctacte.Value = dt.Rows[0]["ctacte"].ToString();
        txt_ctactename.Text = dt.Rows[0]["ctactename"].ToString();
    }

    protected void dgb_cliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgb_cliente.PageIndex = e.NewPageIndex;
        data_gridCliente();
    }

    protected void dgb_cliente_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Alternate)
            {
                e.Row.Attributes.Add("onmouseover", "this.className='gridHover'");
                e.Row.Attributes.Add("onmouseout", "this.className=''");
            }
            else
            {
                e.Row.Attributes.Add("onmouseover", "this.className='gridHover'");
                e.Row.Attributes.Add("onmouseout", "this.className=''");
            }
        }
    }



    // VENDEDOR
    private void data_gridVendedor()
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        switch (cmbvendedor.SelectedValue)
        {
            case "01":
                BE.vendorid = txt_busqueda02.Text.Trim().ToUpper();
                break;
            case "02":
                BE.vendorname = txt_busqueda02.Text.Trim().ToUpper();
                break;
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            dgb_vendedor.Columns.Clear();
            dgb_vendedor.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            dgb_vendedor.Columns.Add(image);

            BoundField DDNNI;
            DDNNI = new BoundField();
            DDNNI.DataField = "vendorid";
            DDNNI.HeaderText = "CODIGO";
            DDNNI.ItemStyle.Width = 50;
            dgb_vendedor.Columns.Add(DDNNI);

            BoundField NOMBR;
            NOMBR = new BoundField();
            NOMBR.DataField = "vendorname";
            NOMBR.HeaderText = "VENDEDOR";
            NOMBR.ItemStyle.Width = 250;
            dgb_vendedor.Columns.Add(NOMBR);

            BE.filtro = "2";

            dt = BL.GetAll_Filtro(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgb_vendedor.DataSource = dt;
                dgb_vendedor.DataBind();
                dgb_vendedor.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;// ClientMessage(ex.Message);
        }
    }

    protected void btn_buscar02_Click(object sender, EventArgs e)
    {
        data_gridVendedor();
    }

    protected void dgb_vendedor_SelectedIndexChanged(object sender, EventArgs e)
    {
        String xvendorid = dgb_vendedor.SelectedRow.Cells[1].Text;
        String xvendorname = dgb_vendedor.SelectedRow.Cells[2].Text;
        txt_vendorid.Value = xvendorid;
        txt_vendorname.Text = xvendorname;
    }

    protected void dgb_vendedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgb_vendedor.PageIndex = e.NewPageIndex;
        data_gridVendedor();
    }


    void CargarPedido()
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.ctacte = txt_ctacte.Value.ToString();
        BE.vendorid = txt_vendorid.Value.ToString();
        BE.aprob_gerencial = cmbestado.SelectedValue.ToString();
        BE.filtro = "2";
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        GridView.DataSource = dt;
        GridView.DataBind();
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        //CargarPedido();
        cargar_grilla();
    }

    protected void LkBPrint_Click(object sender, EventArgs e)
    {
        //string val = LblIdSer.Text;
        string val = HdFNumdoc.Value.ToString();

        Session["xtipdoc"] = Equivalencias.Left(val.ToString().Trim(), 2);
        Session["xserdoc"] = HdFSerdoc.Value.ToString();
        Session["xnumdoc"] = Equivalencias.Right(val.ToString().Trim(), 10);
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
        string pagina = "Rpt_Pedido.aspx";
        reporte_pdf(pagina);
    }

    protected void LkBUpdate_Click(object sender, EventArgs e)
    {
        // PRIMERO VERIFICAMOS QUE LOS PEDIDOS SEAN PENDIENTE PARA PODER MODIFICARLOS
        String xstatu = HdFStatus.Value.ToString();
        if (xstatu.Equals("11")) // 11 = PENDIENTE/NUEVO/EN EDICION
        {
            string val = HdFUpdateItem.Value.ToString();           
            Session["xtipdoc"] = Equivalencias.Left(val.ToString().Trim(), 2);
            Session["xserdoc"] = HdFSerdoc.Value.ToString();
            Session["xnumdoc"] = Equivalencias.Right(val.ToString().Trim(), 10);

            Session["ssModo"] = "EDI";
            Response.Redirect("~/Comercial/Frm_Proformas.aspx#registro");
        }
    }

    protected void LkBCancelUpdate_Click(object sender, EventArgs e)
    {

    }

    protected void LkBDelete_Click(object sender, EventArgs e)
    {
        // Obtenemos el Doc A Cambiar de Estado
        String val = HdFDeleteItem.Value.ToString();
        // TAMBIEN ANULAR SOLO LOS PEDIDOS PENDIENTES    04 = ANULADO 
        String xstatu = HdFStatus.Value.ToString(); // TRAEMOS EL ESTADO 

        tb_cxc_pedidocabBL BL = new tb_cxc_pedidocabBL();
        tb_cxc_pedidocab BE = new tb_cxc_pedidocab();
        DataTable dt = new DataTable();

        BE.tipdoc = val.ToString().Substring(0, 2);
        BE.serdoc = HdFSerdoc.Value.ToString();
        BE.numdoc = Equivalencias.Right(val.ToString().Trim(), 10);
        BE.usuar = Session["ssUsuar"].ToString().Trim();

        if (xstatu.Equals("11")) // 11 = PENDIENTE/NUEVO/EN EDICION
        {
            if (BL.Update_Estado(Session["ssEmpresaID"].ToString(), BE))
            {
                cargar_grilla();
                Response.Redirect("~/Comercial/Listados/Lst_PedidosPend.aspx");
            }
        }        
    }



}