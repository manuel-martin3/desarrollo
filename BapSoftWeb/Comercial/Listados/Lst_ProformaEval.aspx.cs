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

public partial class Comercial_Listados_Lst_ProformaEval : System.Web.UI.Page
{
    Genericas fungen = new Genericas();
    SimpleAES funcript = new SimpleAES();

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            //lblusu.Text = Session["ssUsuar"].ToString();
            CargarCombos("1", "", "");
            bloqueo("01", false);
            bloqueo("02", false);
            bloqueo("03", false);
            cargarComboEstado();
            CargarEvaluacion();
        }
    }

    void bloqueo(String btn,Boolean var)
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
        // CARGAMOS COMBOS PARA LA VISTA DE VENTAS HORISONTALES
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.canalventaid = Session["ssCanalVentaId"].ToString();
        BE.filtro = "2";
        dt = BL.GetAll_Estados(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        cmbestado.DataSource = dt;
        cmbestado.DataValueField = "aprob_status";
        cmbestado.DataTextField = "descripcion";
        cmbestado.DataBind();
    }

    void CargarCombos(String filtro,String xctacte,String xvendorid)
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.filtro = filtro;
        BE.ctacte = xctacte;
        BE.vendorid = xvendorid;
        if (filtro == "1")
        {
            dt = BL.GetAll_Filtro(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            //lstCliente.DataSource = dt;
            //lstCliente.DataValueField = "ctacte";
            //lstCliente.DataTextField = "ctactename";
            //lstCliente.DataBind();
        }
        if (filtro == "2")
        {
            dt = BL.GetAll_Filtro(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            //lstVendor.DataSource = dt;
            //lstVendor.DataValueField = "vendorid";
            //lstVendor.DataTextField = "vendorname";
            //lstVendor.DataBind();
        }
        if (filtro == "3")
        {
            dt = BL.GetAll_Filtro(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            //lstNumdoc.DataSource = dt;
            //lstNumdoc.DataValueField = "numdoc";
            //lstNumdoc.DataTextField = "proforma";
            //lstNumdoc.DataBind();
        }
    }

    void CargarEvaluacion()
    {     
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.ctacte = txt_ctacte.Value.ToString();        
        BE.vendorid = txt_vendorid.Value.ToString();
        if(chk_estado.Checked)
            BE.aprob_gerencial = cmbestado.SelectedValue.ToString();
        BE.filtro = "2";
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];        
        dgb_evalcred.DataSource = dt;
        dgb_evalcred.DataBind();       
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        CargarEvaluacion();
    }

    protected void dgb_evalcred_RowEditing(object sender, GridViewEditEventArgs e)
    {        
        // MANDA SESION PARA EDITAR
        String xtipdoc = dgb_evalcred.SelectedRow.Cells[2].Text;
        Session["ssModo"] = "EDI";
    }

    protected void dgb_evalcred_SelectedIndexChanged(object sender, EventArgs e)
    {
        String xtipdoc = dgb_evalcred.SelectedRow.Cells[2].Text;   
        string[] parts = xtipdoc.Split('-');
        String numdoc = parts[2].PadLeft(10, '0');

        Session["xtipdoc"] = parts[0];
        Session["xserdoc"] = parts[1];
        Session["xnumdoc"] = parts[2].PadLeft(10, '0');

        tb_cxc_cronoPagosBL BL = new tb_cxc_cronoPagosBL();
        tb_cxc_cronoPagos BE = new tb_cxc_cronoPagos();
        DataTable dt = new DataTable();
        BE.tipdoc = parts[0];
        BE.serdoc = parts[1];
        BE.numdoc = parts[2].PadLeft(10, '0');
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
            Session["Tabla01"] = dt;

        tb_cxc_pedidodetBL BL2 = new tb_cxc_pedidodetBL();
        tb_cxc_pedidodet BE2 = new tb_cxc_pedidodet();
        DataTable dt2 = new DataTable();
        BE2.tipdoc = parts[0];
        BE2.serdoc = parts[1];
        BE2.numdoc = parts[2].PadLeft(10, '0');
        dt2 = BL2.GetAll(Session["ssEmpresaID"].ToString(), BE2).Tables[0];
        if (dt2.Rows.Count > 0)
            Session["Tabla02"] = dt2;

        //reporte_pdf();                     
    }

    protected void LkBAceptar_Click(object sender, EventArgs e)
    {
        string val = Request["hfnumdoc"].ToString();
        string xtipdoc = Equivalencias.Left(val.ToString(), 2);
        string xserdoc = val.ToString().Substring(3, 4);
        string xnumdoc = (Equivalencias.Right(val.ToString(), 5)).PadLeft(10, '0');

        Session["xtipdoc"] = xtipdoc;
        Session["xserdoc"] = xserdoc;
        Session["xnumdoc"] = xnumdoc;

        tb_cxc_cronoPagosBL BL = new tb_cxc_cronoPagosBL();
        tb_cxc_cronoPagos BE = new tb_cxc_cronoPagos();
        DataTable dt = new DataTable();
        BE.tipdoc = xtipdoc;
        BE.serdoc = xserdoc;
        BE.numdoc = xnumdoc;
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
            Session["Tabla01"] = dt;

        tb_cxc_pedidodetBL BL2 = new tb_cxc_pedidodetBL();
        tb_cxc_pedidodet BE2 = new tb_cxc_pedidodet();
        DataTable dt2 = new DataTable();
        BE2.tipdoc = xtipdoc;
        BE2.serdoc = xserdoc;
        BE2.numdoc = xnumdoc;
        dt2 = BL2.GetAll(Session["ssEmpresaID"].ToString(), BE2).Tables[0];
        if (dt2.Rows.Count > 0)
            Session["Tabla02"] = dt2;
        //reporte_pdf();     
    }

    protected void LkBCancelar_Click(object sender, EventArgs e)
    {         
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.filtro = "1";       
        dt = BL.GetAll_Filtro(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        //GridView1.DataSource = dt;
        //GridView1.DataBind();                   
    }

    protected void LkBEditar_Click(object sender, EventArgs e)
    {
        // EDITAR LAS EVALUACIONES SOLO QUE SEAN NUEVOS
        String sttus = Request["hfstatus"].ToString();
        // 01 = NUEVO
        if (sttus == "11")
        {
            
            String val = Request["hfnumdoc2"].ToString();

            String xtipdoc = Equivalencias.Left(val.ToString(), 2);
            String xserdoc = HdFSerdoc.Value.ToString();
            String xnumdoc = Equivalencias.Right(val.ToString().Trim(),10);
            Session["xtipdoc"] = xtipdoc;
            Session["xserdoc"] = xserdoc;
            Session["xnumdoc"] = xnumdoc;
            Session["ssModo"] = "EDI";
            string xctacte = Request["hfctacte"].ToString();
            Session["ssCtacte"] = xctacte;
            Response.Redirect("../Frm_Evaluaciones.aspx");
        }
    }

    protected void LkBCancel_Click(object sender, EventArgs e)
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
            //ClientMessage(ex.Message);
        }
    }

    protected void LkBSearch_Click(object sender, EventArgs e)
    {
        string val = Request["HdFNumdoc"].ToString();
        string xtipdoc = Equivalencias.Left(val.ToString().Trim(), 2);
        string xserdoc = HdFSerdoc.Value.ToString();
        string xnumdoc = Equivalencias.Right(val.ToString().Trim(), 10);

        Session["xtipdoc"] = xtipdoc;
        Session["xserdoc"] = xserdoc;
        Session["xnumdoc"] = xnumdoc;

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

        /**/
    }

    protected void LkBCancelSer_Click(object sender, EventArgs e)
    {

    }
    
    protected void LkBUpdate_Click(object sender, EventArgs e)
    {
        //string val = LblIdUpd.Text;
        string val = Request["HdFIdUpd"].ToString();
        string xtipdoc = Equivalencias.Left(val.ToString(), 2);
        string xserdoc = HdFSerdoc.Value.ToString();
        string xnumdoc = Equivalencias.Right(val.ToString(), 10);

        Session["xtipdoc"] = xtipdoc;
        Session["xserdoc"] = xserdoc;
        Session["xnumdoc"] = xnumdoc;

        /*Llamada documento pdf*/      
        tb_cxc_cronoPagosBL BL = new tb_cxc_cronoPagosBL();
        tb_cxc_cronoPagos BE = new tb_cxc_cronoPagos();
        DataTable dt = new DataTable();
        BE.tipdoc = xtipdoc;
        BE.serdoc = xserdoc;
        BE.numdoc = xnumdoc;
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
            Session["Tabla01"] = dt;

        tb_cxc_pedidodetBL BL2 = new tb_cxc_pedidodetBL();
        tb_cxc_pedidodet BE2 = new tb_cxc_pedidodet();
        DataTable dt2 = new DataTable();
        BE2.tipdoc = xtipdoc;
        BE2.serdoc = xserdoc;
        BE2.numdoc = xnumdoc;
        dt2 = BL2.GetAll(Session["ssEmpresaID"].ToString(), BE2).Tables[0];
        if (dt2.Rows.Count > 0)
            Session["Tabla02"] = dt2;
        string pagina = "Rpt_EvalCrediticia.aspx";
        reporte_pdf(pagina);
    }

    protected void LkBCancelUpd_Click(object sender, EventArgs e)
    {

    }  
   
    protected void btn_busqueda02_Click(object sender, EventArgs e)
    {

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


    


}