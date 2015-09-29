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

public partial class Comercial_Frm_Proformas : System.Web.UI.Page
{
    Genericas fungen = new Genericas();
    SimpleAES funcript = new SimpleAES();
    DatoSUNAT myInfoSunat = new DatoSUNAT();
    static string filtro; //filtro de busqueda
    static string clave = "", tabla_accion = ""; //activa la clave dependiendo del formulario
    static decimal xamort; //activa la clave dependiendo del formulario 
    DataTable TablaDetalle;
    DataTable TablaCronoPagos;
    DataTable TablaDetalleStk;
    private DataRow row;
    String AproStatus = "";
    
    /*Go to your Solution Explorer > right click on references and then 
     * click Manage NuGet Packages. Then search in tab "Online" for 
     * DocumentFormat.OpenXml and install it. After you can use DocumentFormat.OpenXml.*/

    protected void Page_Load(object sender, EventArgs e)
    {
        //Fecha - Hora del Servidor BD
        tb_cxc_fecha BE = new tb_cxc_fecha();
        tb_cxc_fechaBL BL = new tb_cxc_fechaBL();
        DataTable dt = new DataTable();
        BE.pedido = "1";
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        //String fecha = "";
        idiom.Value = "es";
        fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Substring(0, 10);
        fechdoc2.Text = dt.Rows[0]["fechdoc"].ToString().Substring(0, 10);
        fechentrega.Text = dt.Rows[0]["fechentrega"].ToString().Substring(0, 10);
        fechentrega2.Text = dt.Rows[0]["fechentrega"].ToString().Substring(0, 10);
        tfecha.Value = dt.Rows[0]["fechdoc"].ToString().Substring(0,10);
        
        if (!Page.IsPostBack)
        {
            NewArtic();
            if ((Session["ssModo"] != null))
            {
                Accion(Session["ssModo"].ToString());
                if (Session["ssModo"]=="EDI")
                {
                    LkBNew.CssClass = "label btn-warning";
                    //LkBEdit.CssClass = "label btn-success";
                }
                else
                {
                    LkBNew.CssClass = "label btn-success";
                    //LkBEdit.CssClass = "label btn-warning";
                }                
            }
            else
            {
                CargaInicial();
                LkBNew.CssClass = "label btn-success";
                //LkBEdit.CssClass = "label btn-warning";
            }
          
            get_data_cbo_filtro("CODIGO", "NOMBRE", "", "", "");
            get_data_cbo_filtro2("CODIGO", "NOMBRE", "", "", "");
        }     
    }

	void Accion(string modo) {
        if (modo.ToString() == "NEW")
        {
            CargaInicial();
        }
        else
        {
            Session["ssModo"] = modo.ToString();
            CargarComboTipVenta();
            CargarComboCondVenta();
            CargarComboMedioPago();
            CargarCombosCmbPlazo();
            ArmadoTablasDetalle();
            ArmarTablaCronoPagos();
            CargarDatosPedido();
        }
    
    }
    void CargaInicial() {
        //*** Uso de Boton Cerrar Popup
        Session["ssReport"] = "rrhh_personal_carnet";
        //btn_cerrar.Attributes.Add("onclick", "cancel('sender','e')");
        CargarCorrelativoDoc();
        Session["ssModo"] = "NEW";
        Session["bd_articid"] = "";
        Session["bd_tallaid"] = "";
        Session["bd_colorid"] = "";
        Session["TablaDetalle"] = "";
        Session["TablaCronoPagos"] = "";
        cmb_igv.Value = "S";
        CargarComboTipVenta();
        CargarComboCondVenta();
        CargarComboMedioPago();
        Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("03", false, "fondo_bloqueo", "_disabled");
        Lock_or_Unlock_Boton("G", false, "_disabled");
        Lock_or_Unlock_Boton("E", false, "_disabled");
        Lock_or_Unlock_Boton("I", false, "_disabled");
        Lock_or_Unlock_Boton("D", false, "_disabled");
        Lock_or_Unlock_Boton("C", false, "_disabled");
        ArmadoTablasDetalle();
        ArmarTablaCronoPagos();
        CargarCombosCmbPlazo();
        Vendedor();
        if (cmb_colorid.SelectedItem != null && cmb_tallaid.SelectedItem != null)
        {
            comboEvalua();
        }        
    }

    void bloqueoBotones(Boolean var)
    {
        //btn_Nuevo.Enabled = var;
        //btn_Editar.Enabled = var;
        //btn_grabar.Enabled = var;
        btn_Imprimir.Enabled = var;
    }

    private void CargarCorrelativoDoc()
    {
        tb_cxc_pedidocabBL BL = new tb_cxc_pedidocabBL();
        tb_cxc_pedidocab BE = new tb_cxc_pedidocab();
        DataTable dt = new DataTable();

        BE.moduloid = Session["ssModuloid"].ToString();
        BE.tipdoc = "PD";
        BE.local = Session["ssLocal"].ToString();
        BE.canalventaid = Session["ssCanalVentaId"].ToString();

        dt = BL.GetNewNumDoc(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txt_tipdoc.Text = dt.Rows[0]["tipodoc"].ToString();
            txt_serdoc.Text = dt.Rows[0]["serdoc"].ToString();
            txt_numdoc.Text = dt.Rows[0]["numero"].ToString();
            txt_proforma.Text = dt.Rows[0]["tipodoc"].ToString() + "-" + dt.Rows[0]["numero"].ToString();
            //txt_proforma.Text = dt.Rows[0]["tipodoc"].ToString() + "-" + dt.Rows[0]["serdoc"].ToString() + (Equivalencias.Right(dt.Rows[0]["numero"].ToString(), 4)).PadLeft(6, '0');

            txt_tipdoc2.Text = dt.Rows[0]["tipodoc"].ToString();
            txt_serdoc2.Text = dt.Rows[0]["serdoc"].ToString();
            txt_numdoc2.Text = dt.Rows[0]["numero"].ToString();
            txt_proforma2.Text = dt.Rows[0]["tipodoc"].ToString() + "-" + dt.Rows[0]["numero"].ToString();
            //txt_proforma2.Text = dt.Rows[0]["tipodoc"].ToString() + "-" + dt.Rows[0]["serdoc"].ToString() + (Equivalencias.Right(dt.Rows[0]["numero"].ToString(), 4)).PadLeft(6,'0');
        }
    }

    private void ArmadoTablasDetalle()
    {      
        TablaDetalle = new DataTable("detalle");
        TablaDetalle.Columns.Add("articid", typeof(String));
        TablaDetalle.Columns.Add("articidold", typeof(String));
        TablaDetalle.Columns.Add("marcaid", typeof(String));
        TablaDetalle.Columns.Add("marcaname", typeof(String));
        TablaDetalle.Columns.Add("articname", typeof(String));

        TablaDetalle.Columns.Add("colorid", typeof(String));
        TablaDetalle.Columns.Add("colorname", typeof(String));
        TablaDetalle.Columns.Add("tallaid", typeof(String));
        TablaDetalle.Columns.Add("talla", typeof(String));

        TablaDetalle.Columns.Add("cantidad", typeof(Decimal));
        TablaDetalle.Columns["cantidad"].DefaultValue = 0;
        TablaDetalle.Columns.Add("precbruto", typeof(Decimal));
        TablaDetalle.Columns["precbruto"].DefaultValue = 0;
        TablaDetalle.Columns.Add("impobruto", typeof(Decimal));
        TablaDetalle.Columns["impobruto"].DefaultValue = 0;
        TablaDetalle.Columns.Add("precneto", typeof(Decimal));
        TablaDetalle.Columns["precneto"].DefaultValue = 0;
        TablaDetalle.Columns.Add("imponeto", typeof(Decimal));
        TablaDetalle.Columns["imponeto"].DefaultValue = 0;
        TablaDetalle.Columns.Add("coltall", typeof(String));      
        Session["TablaDetalle"] = TablaDetalle;        
    }

    // VERIFICO COMO ESTOY INGRESANDO ( COMO QUE USUARIO ESTOY INGRESANDO )
    void ValIngreso()
    {
        String xusu = Session["ssUsuar"].ToString().Trim(); tb_cxc_vendorBL BL = new tb_cxc_vendorBL();
        tb_cxc_vendor BE = new tb_cxc_vendor();
        DataTable dt = new DataTable();
        BE.usuarweb = xusu;
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {            
            //txt_vendorname.Text = dt.Rows[0]["vendorname"].ToString();
            Response.Redirect("~/Comercial/Listados/Lst_PedidosPend.aspx");
        }
        else
        {   
            //txt_vendorname.Text = "VENDEDOR SIN PEDIDOS";
            Response.Redirect("");
        }
    }

    private void ArmarTablaCronoPagos()
    {
        TablaCronoPagos = new DataTable("Cronograma");
        TablaCronoPagos.Columns.Add("tipdoc", typeof(String));
        TablaCronoPagos.Columns.Add("serdoc", typeof(String));
        TablaCronoPagos.Columns.Add("numdoc", typeof(String));
        TablaCronoPagos.Columns.Add("mediopagoid", typeof(String));
        TablaCronoPagos.Columns.Add("item", typeof(String));
        TablaCronoPagos.Columns.Add("num_interno", typeof(String));
        TablaCronoPagos.Columns.Add("num_unico", typeof(String));
        TablaCronoPagos.Columns.Add("monto", typeof(Decimal));
        TablaCronoPagos.Columns.Add("fechven", typeof(DateTime));
        TablaCronoPagos.Columns.Add("usuar", typeof(String));

        Session["TablaCronoPagos"] = TablaCronoPagos;
    }

    private void CargarComboCondVenta()
    {
        tb_CondVentaBL BL = new tb_CondVentaBL();
        tb_CondVenta BE = new tb_CondVenta();
        DataTable dt = new DataTable();
        BE.visible = true;
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            cmb_condventaid.DataSource = dt;
            cmb_condventaid.DataValueField = "condventaid";
            cmb_condventaid.DataTextField = "condventaname";
            cmb_condventaid.DataBind();
        }
    }

    private void CargarComboMedioPago()
    {
        tb_co_tabla01_mediopagoWebBL BL = new tb_co_tabla01_mediopagoWebBL();
        tb_co_tabla01_mediopago BE = new tb_co_tabla01_mediopago();
        DataTable dt = new DataTable();
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            cmb_mediopagoid.DataSource = dt;
            cmb_mediopagoid.ValueField = "codigoid";
            cmb_mediopagoid.TextField = "descripcion";
            cmb_mediopagoid.DataBind();
        }    
    }

    private void CargarComboTipVenta()
    {
        tb_cxc_tipventaBL BL = new tb_cxc_tipventaBL();
        tb_cxc_tipventa BE = new tb_cxc_tipventa();
        DataTable dt = new DataTable();
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            cmb_tipventa.DataSource = dt;
            cmb_tipventa.DataValueField = "tipventaid";            
            cmb_tipventa.DataTextField = "tpventaname";
            //cmb_tipventa.SelectedIndexChanged += new EventHandler(cmb_tipventa_SelectedIndexChanged);
            cmb_tipventa.DataBind();
        }
        cmb_tipventa.SelectedIndex = -1;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        CargarImagen();
    }

    private void CargarImagen()
    {
        //ImagenSunat.ImageUrl = "http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image";
    }

    protected void btn_sgte_Click(object sender, EventArgs e)
    {
        try
        {
            //if (txtimgcaptcha.Text.Trim().Length == 0)
            //{
            //    txtimgcaptcha.Focus();
            //    return;
            //}
            //if (txt_ruc.Text.ToString().Trim().Length != 11)
            //{
            //    txt_ruc.Focus();
            //    return;
            //}

            //myInfoSunat.GetInfo(txt_ruc.Text.Trim(), txtimgcaptcha.Text.ToUpper());
            //// Rellenando Datos Devueltos
            //txt_ruc.Text = myInfoSunat.Ruc;
            //txt_ctactename.Text = myInfoSunat.RazonSocial;
            //direc_entrega.Text = myInfoSunat.Direccion;

            //ModalPanel1.Update();
            //ModalPopupExtender1.Hide();

            //lblDireccion.Text = myInfoSunat.Direccion;
            //rbactivo.Checked = myInfoSunat.Estado.Substring(0, 6) == "ACTIVO";
            //rbbaja.Checked = !rbactivo.Checked;
            //chkretencion.Checked = myInfoSunat.AgeRetencion;
            //txttelefono1.Text = ((myInfoSunat.Telefonos == "-</") ? string.Empty : myInfoSunat.Telefonos);
            //txtpaisid.Text = "9589";
            //txtpaisname.Text = "PERÚ";
            //txtCondicion.Text = myInfoSunat.Condicion;        
        }
        catch (Exception ex)
        {                        
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }

    protected void btn_popup_Click(object sender, EventArgs e)
    {
        try
        {
            //txt_titulo.Text = "Cargando Imagen";
            //ModalPanel1.Update();
            //ModalPopupExtender1.Show();
        }
        catch (Exception)
        {
            throw;
        } 
    }  

    public void ClientMessage(String ClientMessage)
    {
        //MensajeJQuery(ClientMessage);
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

    private void MensajeQuery2(String Mensaje)
    {
        //En esta ocasión agregaremos un literal que a su vez agregaremos un div que nos servira de Dialog
        //O si prefieren pueden crear el div directamente en el HTML
        Literal li = new Literal();
        StringBuilder sbMensaje = new StringBuilder();
        //Creamos el Div
        sbMensaje.Append("<div id='dialog' title='Mensaje Prueba'>");
        //Le indicamos el mensaje a mostrar
        sbMensaje.Append(Mensaje);
        //cerramos el div
        sbMensaje.Append("</div>");
        //Aperturamos la escritura de Javascript
        sbMensaje.Append("<script type='text/javascript'>");
        sbMensaje.Append("$(document).ready(function () {");
        //Destrimos cualquier rastro de dialogo abierto
        sbMensaje.Append("$('#dialog').dialog('destroy');");
        //le indicamos que muestre el dialogo en modo Modal
        sbMensaje.Append(" $('#dialog').dialog({ modal: true });");
        //Si quieres que muestre un boton para cerrar el mensaje seria esta linea que dejare en comentario
        //sbMensaje.Append(" $('#dialog').dialog({ modal: true, buttons: { 'Ok': function() { $(this).dialog('close'); } } });");
        sbMensaje.Append("});");
        sbMensaje.Append("</script>");
        //Agremamos el texto del stringbuilder al literal
        li.Text = sbMensaje.ToString();
        //Agregamos el literal a la pagina
        Page.Controls.Add(li);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            filtro = "PR";
            switch (filtro)
            {
                case "PS":
                    tb_cxc_vendorBL PSBL = new tb_cxc_vendorBL();
                    tb_cxc_vendor PSBE = new tb_cxc_vendor();
                    DataTable PSDT = new DataTable();
                    PSBE.ddnni = GridView1.SelectedRow.Cells[2].Text;
                    PSDT = PSBL.GetAll(Session["ssEmpresaID"].ToString(), PSBE).Tables[0];
                    txt_vendorid.Text = PSDT.Rows[0]["vendorid"].ToString();
                    txt_vendorname.Text = PSDT.Rows[0]["vendorname"].ToString();
                    break;
                case "PR":
                    String xctacte = GridView1.SelectedRow.Cells[1].Text;
                    ValidaCliente(xctacte);
                    break;
                case "PA":
                    txt_articidold.Text = GridView1.SelectedRow.Cells[1].Text;
                    MetodoCargarLineal("");
                    break;
            }
            //UpdatePanel2.Update();
            //ModalPopupExtender2.Hide();
            //data-dismiss="modal"            
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            filtro = "PA";
            switch (filtro)
            {
                case "PS":
                    tb_cxc_vendorBL PSBL = new tb_cxc_vendorBL();
                    tb_cxc_vendor PSBE = new tb_cxc_vendor();
                    DataTable PSDT = new DataTable();
                    PSBE.ddnni = GridView1.SelectedRow.Cells[2].Text;
                    PSDT = PSBL.GetAll(Session["ssEmpresaID"].ToString(), PSBE).Tables[0];
                    txt_vendorid.Text = PSDT.Rows[0]["vendorid"].ToString();
                    txt_vendorname.Text = PSDT.Rows[0]["vendorname"].ToString();
                    break;
                case "PR":
                    String xctacte = GridView2.SelectedRow.Cells[1].Text;
                    ValidaCliente(xctacte);
                    break;
                case "PA":
                    txt_articidold.Text = GridView2.SelectedRow.Cells[1].Text;
                    MetodoCargarLineal(txt_articidold.Text);
                    break;
            }    
                
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }

        GridView2.SelectedRowStyle.CssClass = "SeRoSty alert-success";
    }


    void ValidaCliente(String xctacte)
    {
        clienteWebBL BL = new clienteWebBL();
        tb_cliente BE = new tb_cliente();
        DataTable dt = new DataTable();
        BE.ctacte = xctacte;
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        txt_ctacte.Text = dt.Rows[0]["ctacte"].ToString();
        txt_ctactename.Text = dt.Rows[0]["ctactename"].ToString();
        txt_ruc.Text = dt.Rows[0]["nmruc"].ToString();
        direc_entrega.Text = dt.Rows[0]["direc"].ToString();
        replegal_name.Text = dt.Rows[0]["replegalname"].ToString();
        replegal_dni.Text = dt.Rows[0]["replegaldni"].ToString();               
        Session["xregpublico"] = dt.Rows[0]["regpublico"].ToString();
        Session["xpartelectro2"] = dt.Rows[0]["partelectro"].ToString();
        Session["xestcivil"] = dt.Rows[0]["estcivil"].ToString();
        Session["direcnume"] = dt.Rows[0]["direcnume"].ToString();
    }

    private void CargarComboArticuloColor(String xarticid)
    {
        // Cargamos el Combo de Colores de Acuerdo al Articulo
        tb_pt_articulocolorWebBL BL2 = new tb_pt_articulocolorWebBL();
        tb_pt_articulocolor BE2 = new tb_pt_articulocolor();
        DataTable dt2 = new DataTable();
        BE2.articid = xarticid.ToString();
        dt2 = BL2.GetAll(Session["ssEmpresaID"].ToString(), BE2).Tables[0];
        cmb_colorid.DataSource = dt2;
        cmb_colorid.DataValueField = "colorid";
        cmb_colorid.DataTextField = "colorname";
        cmb_colorid.DataBind();
    }

    private void CargarComboArticuloTallas(string xtallaid)
    {
        //Cargamos el Combo de Tallas ----> Que biene en forma Vertical
        tb_pt_tallaWebBL BL3 = new tb_pt_tallaWebBL();
        tb_pt_talla BE3 = new tb_pt_talla();
        DataTable dt3 = new DataTable();
        BE3.tallaid = xtallaid.ToString();
        BE3.articid = Session["bd_articid"].ToString();
        BE3.colorid=cmb_colorid.SelectedValue.ToString();
        dt3 = BL3.GetAll_vertical(Session["ssEmpresaID"].ToString(), BE3).Tables[0];
        cmb_tallaid.DataSource = dt3;
        cmb_tallaid.DataValueField = "tallacol";
        cmb_tallaid.DataTextField = "talla";
        cmb_tallaid.DataBind();
        
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {

        if (Int32.Parse(txtStkdisp.Text)>=Int32.Parse(spe_cantidad.Text))
        {
        
        // Validamos la Insercion de Detalle
        if (txt_articidold.Text.Length < 0)
        {
            ClientMessage("Ingrese Codigo de Articulo");
            return;
        }        
        
        // Tasa de Descuento
        Double dscto = Convert.ToDouble(txt_tasadescto.Text);

        #region Otro
        //if (TablaDetalle == null)
        //{
        //    if (griddetalle.Rows.Count > 0)
        //    {
        //        ArmadoTablasDetalle();
        //        foreach (GridViewRow fila in griddetalle.Rows)
        //        {                    
        //            row = TablaDetalle.NewRow();            
        //            row["articid"] = Convert.ToString(fila.Cells[0].Text);
        //            row["articidold"] = Convert.ToString(fila.Cells[1].Text);
        //            row["marcaid"] = Convert.ToString(fila.Cells[2].Text);
        //            row["marcaname"] = Convert.ToString(fila.Cells[3].Text);
        //            row["articname"] = Convert.ToString(fila.Cells[4].Text);
        //            row["colorid"] = Convert.ToString(fila.Cells[5].Text);
        //            row["colorname"] = Convert.ToString(fila.Cells[6].Text);
        //            row["tallaid"] = Convert.ToString(fila.Cells[7].Text);
        //            row["talla"] = Convert.ToString(fila.Cells[8].Text);
        //            Double cant = Convert.ToDouble(fila.Cells[9].Text);
        //            Double precbruto = Convert.ToDouble(fila.Cells[10].Text);
        //            row["cantidad"] = cant;
        //            row["precbruto"] = precbruto;
        //            row["impobruto"] = Math.Round((cant * precbruto), 2);
                    
        //            //CALCULAMOS EL PRECIO CON DESCUENTO
        //            Double precneto = Math.Round((precbruto * (1 - (dscto/100))), 2); 
        //            // AQUI LE TENEMOS QUE PASAR EL PARAMETRO DE TASA DE DESCUENTO
        //            row["precneto"] = precneto;
        //            row["imponeto"] = Math.Round((cant * precneto),2);
        //            TablaDetalle.Rows.Add(row);
        //        }               
        //    }
        //    else {
        //        ArmadoTablasDetalle();
        //   }
        //}
        #endregion


        TablaDetalle = (DataTable)Session["TablaDetalle"];
        row = TablaDetalle.NewRow();      
        row["articid"] = Session["bd_articid"].ToString();
        row["articidold"] = txt_articidold.Text.ToUpper();      
        row["marcaid"] = Session["bd_marcaid"].ToString();
        row["marcaname"] = txt_marcaname.Text;
        row["articname"] = txt_articname.Text;
        String colcc = cmb_colorid.SelectedValue.ToString();
        row["colorid"] = cmb_colorid.SelectedValue.ToString();
        row["colorname"] = cmb_colorid.SelectedItem.ToString();
        row["tallaid"] = Session["bd_tallaid"].ToString();        
        row["talla"] = cmb_tallaid.SelectedItem.ToString();        
        Int32 xcant = Convert.ToInt32(spe_cantidad.Text);
        Double xprecbruto = Convert.ToDouble(txt_precventa_cre_menor.Text);
        row["cantidad"] = xcant;        
        row["precbruto"] = xprecbruto;
        row["impobruto"] = Math.Round((xcant * xprecbruto), 2);
        //Calculamos el PRECIO CON DESCUENTO                  
        Double xprecneto = Math.Round((xprecbruto * (1 - dscto)), 2); 
        row["precneto"] = xprecneto;
        row["imponeto"] = Math.Round((xcant * xprecneto), 2);
        Session["coltall"] = Equivalencias.Right(cmb_tallaid.SelectedValue.ToString(),2);
        row["coltall"] = Session["coltall"].ToString();
        TablaDetalle.Rows.Add(row);

        griddetalle.DataSource = TablaDetalle;
        griddetalle.DataBind();        
        // LLamamos al Metodo de Calculo de Total de Vta
        Calculos();
        NewArtic();
        Calculos_CronogramaPagos();
        //Response.Redirect("~/Comercial/Frm_Proformas.aspx#lista");
        
        //Int32 cantidad = Convert.ToInt32(TablaDetalle.Compute("sum(cantidad)", string.Empty));
        //txtStkdisp.Text= (Convert.ToInt32(txtStkdisp.Text) - cantidad).ToString();
        
        //txtStkdisp.Text = "0";
        //CargarComboArticuloTallas();
        //validastock();

        comboEvalua();
        
        
        
            msgCant.Visible = false;
            msgCant.Text = "";
            spe_cantidad.CssClass = "form-control btn btn-default";
        }
        else
        {
            msgCant.Visible = true;
            msgCant.CssClass = "label label-danger";
            msgCant.Text = "La cantidad debe ser menor o igual al Stock dispoible";
            spe_cantidad.CssClass = "form-control btn alert-danger";
        }

        //cmb_colorid.SelectedIndex = -1;
        //cmb_tallaid.SelectedIndex = -1;
    }

    private void Calculos()
    {
        // Actualizaremos el Total de Vta del Precio  de Lista 
        Double TotPrecList = 0,TotVtaDescto=0;
               
        foreach (GridViewRow fila in griddetalle.Rows)
        {
            TotPrecList += Convert.ToDouble(fila.Cells[11].Text);
        }
        txt_impobruto.Text = TotPrecList.ToString("N2");

        
        // Primero Validaremos La Condicion de Venta
        CargamosTasaInteres();
       

        TablaDetalle = null;
        ArmadoTablasDetalle();

        Double xdscto = Convert.ToDouble(txt_tasadescto.Text);
        foreach (GridViewRow fila in griddetalle.Rows)
        {
            row = TablaDetalle.NewRow();
            row["articid"] = griddetalle.DataKeys[fila.RowIndex].Values[0].ToString();
            row["articidold"] = Convert.ToString(fila.Cells[1].Text);
            row["marcaid"] = Convert.ToString(fila.Cells[2].Text);
            row["marcaname"] = Convert.ToString(fila.Cells[3].Text);
            row["articname"] = Convert.ToString(fila.Cells[4].Text);
            row["colorid"] = griddetalle.DataKeys[fila.RowIndex].Values[1].ToString();
            row["colorname"] = Convert.ToString(fila.Cells[6].Text);
            row["tallaid"] = griddetalle.DataKeys[fila.RowIndex].Values[2].ToString();
            row["talla"] = Convert.ToString(fila.Cells[8].Text);
            Double cant = Convert.ToDouble(fila.Cells[9].Text);
            Double precbruto = Convert.ToDouble(fila.Cells[10].Text);
            row["cantidad"] = cant;
            row["precbruto"] = precbruto;
            row["impobruto"] = Math.Round((cant * precbruto), 2);

            //CALCULAMOS EL PRECIO CON DESCUENTO                  
            Double precneto = Math.Round((precbruto * (1 - (xdscto / 100))), 2); // Aqui le Tenemos que pasar el parametro de tasa de descuento
            row["precneto"] = precneto;
            row["imponeto"] = Math.Round((cant * precneto), 2);
            row["coltall"] = Convert.ToString(fila.Cells[14].Text);//griddetalle.DataKeys[fila.RowIndex].Values[15].ToString(); //Session["coltall"].ToString();
            TablaDetalle.Rows.Add(row);
        }

         

        griddetalle.DataSource = TablaDetalle;
        griddetalle.DataBind();

        // Volvemos a Cargar en la Session La Tabla
        Session["TablaDetalle"] = TablaDetalle;

        items.Text = TablaDetalle.Rows.Count.ToString();
        if (TablaDetalle.Rows.Count>0)
        {
            txt_imponeto.Text = Convert.ToDecimal(TablaDetalle.Compute("sum(imponeto)", string.Empty)).ToString("##,###,##0.00");
            imponeto2.Text = Convert.ToDecimal(TablaDetalle.Compute("sum(imponeto)", string.Empty)).ToString("##,###,##0.00");
        }
        else
        {
            txt_imponeto.Text="0.00";
            imponeto2.Text = "0.00";
            txt_tasadescto.Text = "0.00";
        }
        

      
    }

    private void CargamosTasaInteres()
    {
        String xcondventa = cmb_condventaid.SelectedValue.ToString();
        String xplazoday = cmb_plazoday.SelectedValue.ToString();


        #region Cargamos la Tasa de Interes
        // Primero Validaremos La Condicion de Venta
        // 01 = contado                
        if (xcondventa == "01")
        {
            if (Convert.ToDouble(txt_impobruto.Text) <= 9000)
            {
                txt_tasadescto.Text = "42.00";
            }
            else
            {
                txt_tasadescto.Text = "44.00";
            }
        }

        // 02 = credito
        if (xcondventa == "02")
        {
            if (xplazoday == "30")
            {
                if (Convert.ToDouble(txt_impobruto.Text) <= 9000)
                {
                    txt_tasadescto.Text = "40.00";
                }
                else
                {
                    txt_tasadescto.Text = "42.00";
                }
            }
            if (xplazoday == "60")
            {
                if (Convert.ToDouble(txt_impobruto.Text) <= 9000)
                {
                    txt_tasadescto.Text = "38.00";
                }
                else
                {
                    txt_tasadescto.Text = "40.00";
                }
            }
            if (xplazoday == "90")
            {
                if (Convert.ToDouble(txt_impobruto.Text) <= 9000)
                {
                    txt_tasadescto.Text = "0.00";
                }
                else
                {
                    txt_tasadescto.Text = "36.00";
                }
            }
        }

        #endregion
    }

     void NewArtic()
    {
        if (chk_Bloquear.Checked == false)
	    {
            btn_add.CssClass = "btn btn-default";
            btn_add.Enabled = false;            
            //txt_articidold.Text = "";
            //txt_marcaname.Text = "";
            //txt_articname.Text = "";
            //cmb_colorid.SelectedIndex = -1;
            //cmb_tallaid.SelectedIndex = -1;
            //txt_precventa_cre_menor.Text = "";
            spe_cantidad.Text = "1";

        }
        else
        {
            //cmb_colorid.SelectedIndex = -1;
            //cmb_tallaid.SelectedIndex = -1;            
            spe_cantidad.Text = "1";
            btn_add.CssClass = "btn btn-success";
            btn_add.Enabled = true;            
            txt_articidold.Focus();
        }
        
    }

    protected void btn_act01_Click(object sender, EventArgs e)
    {  
        Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("02", true, "", "");       
    }

    private void Lock_or_UnLock_Paneles(String xpnl, Boolean xvar, String xclas, String xval)
    {
        //if (xpnl == "01")
        //{
        //    pnl01.Enabled = xvar;
        //    pnl01.CssClass = xclas;
        //    if (pnl01.Enabled == xvar)
        //    {
        //        btn_busvendedor.ImageUrl = "~/images/btn_buscar" + xval + ".png";
        //        btn_buscaRazon.ImageUrl = "~/images/btn_buscar" + xval + ".png";
        //        //btn_BuscarProforma.ImageUrl = "~/images/btn_buscar" + xval + ".png";
        //        btn_act01.CssClass = "boton_next2" + xval + "";
        //    }
        //}

        //if (xpnl == "02")
        //{
        //    pnl02.Enabled = xvar;
        //    pnl02.CssClass = xclas;
        //    if (pnl02.Enabled == xvar)
        //    {
        //        btn_buscar.ImageUrl = "~/images/btn_buscar" + xval + ".png";
        //        btn_add.CssClass = "boton_add2" + xval + "";
        //        btn_act02.CssClass = "boton_next2" + xval + "";
        //    }
        //}

        //if (xpnl == "03")
        //{
        //    pnl03.Enabled = xvar;
        //    pnl03.CssClass = xclas;
        //    if (pnl03.Enabled == xvar)
        //    {
        //        btn_ok.CssClass = "boton_add2" + xval + "";
        //    }
        //}
    }

    private void Lock_or_Unlock_Boton(String xbtn,Boolean xvar, String xval)
    {
        //if (xbtn == "G") 
        //{
        //    btn_grabar.Enabled = xvar;
        //    btn_grabar.ImageUrl = "~/images/btn_grabar" + xval + ".png";
        //}
        //if (xbtn == "N")
        //{
        //    btn_Nuevo.Enabled = xvar;
        //    btn_Nuevo.ImageUrl = "~/images/btn_new" + xval + ".png";
        //}
        //if (xbtn == "E")
        //{
        //    btn_Editar.Enabled = xvar;
        //    btn_Editar.ImageUrl = "~/images/btn_edit" + xval + ".png";
        //}
        //if (xbtn == "I")
        //{
        //    btn_Imprimir.Enabled = xvar;
        //    btn_Imprimir.ImageUrl = "~/images/btn_imprimir" + xval + ".png";

        //    btn_Imprimir2.Enabled = xvar;
        //    btn_Imprimir2.ImageUrl = "~/images/btn_imprimir" + xval + ".png";
        //}
        //if (xbtn == "D")
        //{
        //    btn_Eliminar.Enabled = xvar;
        //    btn_Eliminar.ImageUrl = "~/images/btn_delete" + xval + ".png";
        //}
        //if (xbtn == "C")
        //{
        //    btn_Cancelar.Enabled = xvar;
        //    btn_Cancelar.ImageUrl = "~/images/btn_cancel" + xval + ".png";
        //}   
    }

    protected void griddetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        #region otro
        ArmadoTablasDetalle();
        Double xdscto = Convert.ToDouble(txt_tasadescto.Text);
        Double cant = 0;
        foreach (GridViewRow fila in griddetalle.Rows)
        {
            row = TablaDetalle.NewRow();
            row["articid"] = Convert.ToString(fila.Cells[0].Text);
            row["articidold"] = Convert.ToString(fila.Cells[1].Text);
            row["marcaid"] = Convert.ToString(fila.Cells[2].Text);
            row["marcaname"] = Convert.ToString(fila.Cells[3].Text);
            row["articname"] = Convert.ToString(fila.Cells[4].Text);
            row["colorid"] = Convert.ToString(fila.Cells[5].Text);
            row["colorname"] = Convert.ToString(fila.Cells[6].Text);
            String xtall = Convert.ToString(fila.Cells[8].Text);
            row["tallaid"] = Convert.ToString(fila.Cells[7].Text);
            row["talla"] = Convert.ToString(fila.Cells[8].Text);
            String xcol = Convert.ToString(fila.Cells[14].Text);  
            row["coltall"] = Convert.ToString(fila.Cells[14].Text);  

            cant = Convert.ToDouble(fila.Cells[9].Text);
            Double precbruto = Convert.ToDouble(fila.Cells[10].Text);
            row["cantidad"] = cant;
            row["precbruto"] = precbruto;
            row["impobruto"] = Math.Round((cant * precbruto), 2);            
            //Calculamos el PRECIO CON DESCUENTO                  
            Double precneto = Math.Round((precbruto * (1 - (xdscto / 100))), 2); // Aqui le Tenemos que pasar el parametro de tasa de descuento
            row["precneto"] = precneto;
            row["imponeto"] = Math.Round((cant * precneto), 2);

            if (txt_articidold.Text == fila.Cells[1].Text
                   && cmb_colorid.Text == fila.Cells[5].Text
                   //&& cmb_tallaid.SelectedItem.ToString() == fila.Cells[8].Text
                   )
            {
                txtStkdisp.Text = (Double.Parse(txtStkdisp.Text) + cant).ToString();         
            }

            TablaDetalle.Rows.Add(row);
        }   
        #endregion
        

        TablaDetalle = (DataTable)Session["TablaDetalle"]; 
        
        TablaDetalle.Rows[e.RowIndex].Delete();
        griddetalle.DataSource = TablaDetalle;
        griddetalle.DataBind();
        Calculos();
        Calculos_CronogramaPagos();
        txtStkdisp.Text = "0";//(Int32.Parse(txtStkdisp.Text) + Int32.Parse(row["cantidad"].ToString())).ToString();        
        
    }

    protected void btn_act02_Click(object sender, EventArgs e)
    {
        Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("03", true, "", "_disabled");      
        // Aca Agregamos un Metodo Para Saber Los Numeros de Docs
        MetodoNumDocs();        
    }

    void MetodoNumDocs()
    {
        if (cmb_plazoday.SelectedValue.ToString() == "30")
        {
            spe_numdocs.MinValue = 0;
            spe_numdocs.MaxValue = 1;
            spe_numdocs.Value = 1;
        }
        if (cmb_plazoday.SelectedValue.ToString() == "60")
        {
            spe_numdocs.MinValue = 1;
            spe_numdocs.MaxValue = 4;
        }
        if (cmb_plazoday.SelectedValue.ToString() == "90")
        {
            spe_numdocs.MinValue = 1;
            spe_numdocs.MaxValue = 6;
        }
        if (cmb_plazoday.SelectedValue.ToString() == "120")
        {
            spe_numdocs.MinValue = 1;
            spe_numdocs.MaxValue = 6;
        }
    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        Calculos_CronogramaPagos();
    }

    void Calculos_CronogramaPagos()
    {       
        if (griddetalle.Rows.Count>0)
	    {
            // Agregar las Filas Deacuerdo al Numero de Documento
            if (cmb_mediopagoid.SelectedIndex != -1)
            {
                if (spe_numdocs.Text.Length > 0)
                {
                    ArmarTablaCronoPagos();
                    Int16 ndocs = Convert.ToInt16(spe_numdocs.Text);
                    if (ndocs > 0)
                    {
                        Int16 nitem = 0;
                        Decimal xtot = (Convert.ToDecimal(txt_imponeto.Text) / ndocs);

                        // Aplicar Logica Para Colocar Las Fechas DeAcuerdo la Plazo de Dias --- Partiendo desde la Fecha de Entrega                
                        DateTime fecha = Convert.ToDateTime(fechentrega.Text);
                        fecha = fecha.AddDays(30);
                        Int32 num = 0, num2 = 0;


                        //************************************** Calculo Para Fechas Siguientes
                        DateTime fecha2 = DateTime.Today;
                        Int32 xtotfech2 = 0;
                        if (ndocs > 1)
                        {
                            Int32 xndias = Convert.ToInt32(cmb_plazoday.SelectedValue.ToString());
                            xtotfech2 = ((xndias - 30) / (ndocs - 1));
                            fecha2 = fecha.AddDays(xtotfech2);
                        }
                        //*********************************************************************

                        tb_co_tabla01_mediopagoWebBL BL = new tb_co_tabla01_mediopagoWebBL();
                        tb_co_tabla01_mediopago BE = new tb_co_tabla01_mediopago();
                        DataTable dt = new DataTable();
                        BE.codigoid = cmb_mediopagoid.Value.ToString();
                        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < ndocs; i++)
                            {
                                nitem++;
                                row = TablaCronoPagos.NewRow();
                                row["tipdoc"] = txt_tipdoc.Text;
                                row["serdoc"] = txt_serdoc.Text;
                                row["numdoc"] = txt_numdoc.Text;
                                row["mediopagoid"] = cmb_mediopagoid.Value.ToString();
                                row["item"] = Convert.ToString(nitem).PadLeft(2, '0');
                                row["num_interno"] = dt.Rows[0]["sigla"].ToString() + " - " + Convert.ToString(nitem).PadLeft(2, '0');
                                row["num_unico"] = "";
                                row["monto"] = Convert.ToString(xtot);
                                if (nitem == 1) { row["fechven"] = Convert.ToString(fecha); }
                                else
                                {
                                    if (num == 0) { row["fechven"] = Convert.ToString(fecha2); num++; }
                                    else
                                    {
                                        num2++;
                                        row["fechven"] = Convert.ToString(fecha2.AddDays(xtotfech2 * num2));
                                    }
                                }
                                row["usuar"] = VariablesPublicas.Usuar;
                                TablaCronoPagos.Rows.Add(row);
                            }

                            gridcronpagos.DataSource = TablaCronoPagos;
                            gridcronpagos.DataBind();

                            Session["TablaCronoPagos"] = TablaCronoPagos;
                            //btn_grabar.CssClass = "boton_grabar2";
                        }
                    }
                }
            }
        }
        else
        {
            gridcronpagos.DataSource = null;
        }
    }

    protected void gridcronpagos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowstate = e.Row.RowState.ToString();
        rowstate = rowstate.Trim();

        if ((rowstate == "Edit") || (rowstate == "Alternate, Edit"))
        {            
            TextBox txt3 = (TextBox)e.Row.FindControl("monto");
            txt3.Enabled = true;

            TextBox txt = (TextBox)e.Row.FindControl("fechven");
            txt.Enabled = true;
           
            e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#d6e9c6");
        }
    }

    protected void gridcronpagos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.gridcronpagos.EditIndex = -1;
        BindData();
    }

    protected void gridcronpagos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TablaCronoPagos = (DataTable)Session["TablaCronoPagos"];
        TablaCronoPagos.Rows[e.RowIndex].Delete();
        gridcronpagos.DataSource = TablaCronoPagos;
        gridcronpagos.DataBind();

        Int32 ndocs = (Convert.ToInt32(spe_numdocs.Text) - 1);
        spe_numdocs.Text = ndocs.ToString();

        Calculos_CronogramaPagos(); 
    }
    
    protected void gridcronpagos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.gridcronpagos.EditIndex = e.NewEditIndex;
        ((BoundField)gridcronpagos.Columns[0]).ReadOnly = true;
        ((BoundField)gridcronpagos.Columns[1]).ReadOnly = true;
        ((BoundField)gridcronpagos.Columns[2]).ReadOnly = true;
        BindData();
    }
    
    protected void gridcronpagos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Recuperar la tabla del objeto de sesión.
        TablaCronoPagos = (DataTable)Session["TablaCronoPagos"];

        ////Actualice los valores.
        GridViewRow row = gridcronpagos.Rows[e.RowIndex];
        Double xmonant = Convert.ToDouble(TablaCronoPagos.Rows[row.DataItemIndex]["monto"]);
        String xmondes = (row.FindControl("monto") as TextBox).Text;
        String xitem = TablaCronoPagos.Rows[row.DataItemIndex]["item"].ToString();
        Double xdif = 0;
        ////Hayamos la Diferencia Para agregarlo al item Ultimo
        xdif =(xmonant - Convert.ToDouble(xmondes));
        //if (xdif < 0)
        //    xdif = xdif * -1;
        TablaCronoPagos.Rows[row.DataItemIndex]["monto"] = (row.FindControl("monto") as TextBox).Text;
        TablaCronoPagos.Rows[row.DataItemIndex]["fechven"] = (row.FindControl("fechven") as TextBox).Text;

        Double xmonfin = Convert.ToDouble(TablaCronoPagos.Rows[TablaCronoPagos.Rows.Count -1]["monto"]);
        TablaCronoPagos.Rows[TablaCronoPagos.Rows.Count -1]["monto"] = xmonfin + xdif ;

        //Restablecer el índice de edición.
        gridcronpagos.EditIndex = -1;

        //Los datos se unen al control GridView.
        BindData();     
    }

    private void BindData()
    {
        gridcronpagos.DataSource = Session["TablaCronoPagos"];
        gridcronpagos.DataBind();
    }

    protected void cmb_condventaid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmb_condventaid.SelectedIndex != -1)
        {
            if (cmb_condventaid.SelectedValue.ToString() == "01")
            {
                cmb_plazoday.Enabled = false;
                cmb_plazoday.SelectedIndex = 0;
            }
            else { cmb_plazoday.Enabled = true; }                                
        }
    }

    //*************************************************** POPUP DE BUSCAR RAZON SOCIAL
    protected void btn_buscaRazon_Click(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            GridView1.Columns.Clear();
            filtro = "PR";
            txt_titulo.Text = "Listado de Clientes Registrados";
            bus_name.Text = "Buscar por: ";
            get_data_cbo_filtro("CODIGO", "NOMBRE", "", "", "");
            txt_filter.Text = "";
            if (txt_filter.Text.Trim().Length > 0)
            {
                data_gridRazonSocial();
            }         
        }
        catch (Exception)
        {
            throw;
        }      
    }

    private void data_gridRazonSocial()
    {
        clienteWebBL BL = new clienteWebBL();
        tb_cliente BE = new tb_cliente();
        DataTable dt = new DataTable();

        switch (cbo_filtro.SelectedValue)
        {
            case "01":
                BE.ctacte = txt_filter.Text.Trim().ToUpper();
                break;
            case "02":
                BE.ctactename = txt_filter.Text.Trim().ToUpper();
                break;
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            GridView1.Columns.Clear();
            GridView1.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            GridView1.Columns.Add(image);

            BoundField DDNNI;
            DDNNI = new BoundField();
            DDNNI.DataField = "ctacte";
            DDNNI.HeaderText = "CODIGO";
            DDNNI.ItemStyle.Width = 50;
            GridView1.Columns.Add(DDNNI);

            BoundField NOMBR;
            NOMBR = new BoundField();
            NOMBR.DataField = "ctactename";
            NOMBR.HeaderText = "NOMBRES";
            NOMBR.ItemStyle.Width = 250;
            GridView1.Columns.Add(NOMBR);

            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }


    //*************************************************** POPUP DE BUSCAR VENDEDORES
    protected void btn_busvendedor_Click(object sender, ImageClickEventArgs e)
    {
        //try
        //{
        //    GridView1.Visible = false;
        //    GridView1.Columns.Clear();
        //    filtro = "PS";
        //    txt_titulo.Text = "en Tabla Vendedor";
        //    bus_name.Text = "Buscar por: ";
        //    get_data_cbo_filtro("CODIGO", "DNI", "NOMBRE", "", "");
        //    txt_filter.Text = "";
        //    if (txt_filter.Text.Trim().Length > 0)
        //    {
        //        data_gridVendedor();
        //    }

        //    UpdatePanel2.Update();
        //    ModalPopupExtender2.Show();
        //}
        //catch (Exception ex)
        //{            
        //    throw ex;
        //}       
    }

    private void get_data_cbo_filtro(string param01, string param02, string param03, string param04, string param05)
    {
        try
        {
            cbo_filtro.Items.Clear();
            DataTable dttempo = new DataTable();
            dttempo = new DataTable();
            dttempo.Columns.Add("key", typeof(string));
            dttempo.Columns.Add("descrip", typeof(string));

            DataRow workRow;

            workRow = dttempo.NewRow();
            workRow["key"] = "00";
            workRow["descrip"] = "SELECT";
            dttempo.Rows.Add(workRow);

            //**01
            if (param01.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "01";
                workRow["descrip"] = param01.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**01
            if (param02.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "02";
                workRow["descrip"] = param02.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**03
            if (param03.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "03";
                workRow["descrip"] = param03.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**04
            if (param04.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "04";
                workRow["descrip"] = param04.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**05
            if (param05.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "05";
                workRow["descrip"] = param05.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }

            //Enlazamos el origen de datos al control DropDownList
            cbo_filtro.DataSource = dttempo;
            cbo_filtro.DataValueField = "key";
            cbo_filtro.DataTextField = "descrip";
            cbo_filtro.DataBind();
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }

    private void get_data_cbo_filtro2(string param01, string param02, string param03, string param04, string param05)
    {
        try
        {
            cbo_filtro2.Items.Clear();
            DataTable dttempo = new DataTable();
            dttempo = new DataTable();
            dttempo.Columns.Add("key", typeof(string));
            dttempo.Columns.Add("descrip", typeof(string));

            DataRow workRow;

            workRow = dttempo.NewRow();
            workRow["key"] = "00";
            workRow["descrip"] = "SELECT";
            dttempo.Rows.Add(workRow);

            //**01
            if (param01.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "01";
                workRow["descrip"] = param01.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**01
            if (param02.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "02";
                workRow["descrip"] = param02.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**03
            if (param03.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "03";
                workRow["descrip"] = param03.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**04
            if (param04.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "04";
                workRow["descrip"] = param04.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }
            //**05
            if (param05.Trim().Length > 0)
            {
                workRow = dttempo.NewRow();
                workRow["key"] = "05";
                workRow["descrip"] = param05.ToUpper().Trim();
                dttempo.Rows.Add(workRow);
            }

            //Enlazamos el origen de datos al control DropDownList
            cbo_filtro2.DataSource = dttempo;
            cbo_filtro2.DataValueField = "key";
            cbo_filtro2.DataTextField = "descrip";
            cbo_filtro2.DataBind();
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }

    private void data_gridVendedor()
    {
        //tb_cxc_vendorBL BL = new tb_cxc_vendorBL();
        //tb_cxc_vendor BE = new tb_cxc_vendor();

        //switch (cbo_filtro.SelectedValue)
        //{
        //    case "01":
        //        BE.vendorid = txt_filter.Text.Trim().ToUpper();
        //        break;
        //    case "02":
        //        BE.ddnni = txt_filter.Text.Trim().ToUpper();
        //        break;
        //    case "03":
        //        BE.vendorname = txt_filter.Text.Trim().ToUpper();
        //        break;
        //    default:
        //        //**
        //        break;
        //}
        //try
        //{
        //    //Eliminar Columnas Actuales(Opcional):
        //    GridView1.Columns.Clear();
        //    GridView1.Width = 550;
        //    //Objeto Columna:
        //    CommandField image;
        //    //Crear Columna:
        //    image = new CommandField();
        //    image.ButtonType = ButtonType.Image;
        //    image.SelectImageUrl = "~/Images/go-search.png";
        //    image.ShowSelectButton = true;
        //    image.ItemStyle.Width = 10;
        //    image.ItemStyle.Wrap = true;
        //    GridView1.Columns.Add(image);

        //    BoundField DDNNI;
        //    DDNNI = new BoundField();
        //    DDNNI.DataField = "vendorid";
        //    DDNNI.HeaderText = "CODIGO";
        //    DDNNI.ItemStyle.Width = 80;
        //    GridView1.Columns.Add(DDNNI);

        //    BoundField APPAT;
        //    APPAT = new BoundField();
        //    APPAT.DataField = "ddnni";
        //    APPAT.HeaderText = "DNI";
        //    APPAT.ItemStyle.Width = 80;
        //    GridView1.Columns.Add(APPAT);

        //    BoundField NOMBR;
        //    NOMBR = new BoundField();
        //    NOMBR.DataField = "vendorname";
        //    NOMBR.HeaderText = "NOMBRES";
        //    NOMBR.ItemStyle.Width = 250;
        //    GridView1.Columns.Add(NOMBR);

        //    GridView1.DataSource = BL.GetAll(Session["ssEmpresaID"].ToString(), BE);
        //    GridView1.DataBind();
        //    GridView1.Visible = true;
        //}
        //catch (Exception ex)
        //{
        //    ClientMessage(ex.Message);
        //}
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {       
      data_gridRazonSocial();             
    }

    protected void btnSearch2_Click(object sender, EventArgs e)
    {        
        data_gridArticulo();       
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       GridView1.PageIndex = e.NewPageIndex;       
       data_gridRazonSocial();               
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;       
        data_gridArticulo();       
    }

    protected void GridView_OnRowCreated(object sender, GridViewRowEventArgs e)
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

    protected void GridView2_OnRowCreated(object sender, GridViewRowEventArgs e)
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

    protected void EditarFilaSeleccionada(object sender, CommandEventArgs e)
    {
        var datosFila = e.CommandArgument.ToString().Split(',');

        //La pocisión va de acuerdo a como construiste el Command Argument en nuestro caso es:

        
        string articid = datosFila[0].ToString();
        string articidold = datosFila[1].ToString();
        string articulo = datosFila[2].ToString();
        string marca = datosFila[3].ToString();
        string preciolist = datosFila[4].ToString();
        string colorid = datosFila[5].ToString();
        string tallaid = datosFila[6].ToString();
        string cantidad = datosFila[7].ToString();
        //string campoColumnaN = datosFila[4].ToString();

        //Asignas cada variable con tu control de texto respectivamente

        txt_articidold.Text = articidold.ToString();
        txt_articname.Text = articulo.ToString();
        txt_marcaname.Text = marca.ToString();
        txt_precventa_cre_menor.Text = preciolist.ToString();
        CargarComboArticuloColor(articid.ToString());        
        txtStkdisp.Text = "";
        spe_cantidad.Text = cantidad.ToString();

        // y Listo!!! la información de la fila seleccionada ya está en tus controles
    }
   
            
    protected void cbo_filtro_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txt_filter.Text = "";
    }

    protected void cbo_filtro2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txt_filter.Text = "";
    }

    
    //*************************************************** POPUP DE BUSCAR ARTICULOS
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_articidold.Text.Length == 0)
            {
                //GridView1.Visible = false;
                //GridView1.Columns.Clear();
                //filtro = "PA";
                //txt_titulo.Text = " Articulos";
                //bus_name.Text = "Buscar por: ";
                //get_data_cbo_filtro("CODIGO", "NOMBRE", "", "", "");
                //txt_filter.Text = "";
                //if (txt_filter.Text.Trim().Length > 0)
                //{
                //    data_gridArticulo();
                //}

                //UpdatePanel2.Update();
                //ModalPopupExtender2.Show();
                
            }
            else { 
                MetodoCargarLineal(""); 
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void MetodoCargarLineal(String xcodigo)
    {
        //tb_pt_articuloWebBL BL = new tb_pt_articuloWebBL();
        //tb_pt_articulo BE = new tb_pt_articulo();

        tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL();
        tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        //tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL();
        //tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        DataTable dt = new DataTable();
        BE.articidold = xcodigo.Trim();
        BE.valorfind = txt_filter2.Text.ToUpper();
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];

        if (dt.Rows.Count > 0)
        {
            string old = dt.Rows[0]["articidold"].ToString();
            Session["bd_marcaid"] = dt.Rows[0]["marcaid"].ToString();
            txt_marcaname.Text = dt.Rows[0]["marcaname"].ToString();
            Session["bd_articid"] = dt.Rows[0]["articid"].ToString();
            txt_articname.Text = dt.Rows[0]["articname"].ToString();
            txt_precventa_cre_menor.Text = dt.Rows[0]["precventa_cre_menor"].ToString();
            Session["bd_tallaid"] = dt.Rows[0]["tallaid"].ToString();
            //Session["bd_coltall"] = dt.Rows[0]["coltall"].ToString();
            Session["bd_fecha"] = dt.Rows[0]["fecha"].ToString();
            HdFarticid.Value = dt.Rows[0]["articid"].ToString(); 
            // Metodos De Cargar Combos 
            CargarComboArticuloColor(dt.Rows[0]["articid"].ToString());
            CargarComboArticuloTallas(dt.Rows[0]["tallaid"].ToString());
            btn_add.Enabled = true;
            btn_add.CssClass = "btn btn-success";

            //HdFtalla.Value = cmb_tallaid.SelectedValue;
            //string talla = HdFtalla.Value.ToString().Substring(5, 2);
            string color = cmb_colorid.SelectedValue;
            cmb_colorid.SelectedIndex = -1;
            //stkDisponible(talla.ToString(),color.ToString());
        }
    }

   private void data_gridArticulo()
    {
        //tb_pt_articuloWebBL BL = new tb_pt_articuloWebBL();
        //tb_pt_articulo BE = new tb_pt_articulo();
        tb_me_stockdiariocabBL BL = new tb_me_stockdiariocabBL();
        tb_me_stockdiariocab BE = new tb_me_stockdiariocab();
        DataTable dt = new DataTable();

        //BE.articidold = txt_articidold.Text.ToUpper();
        //BE.top = true;
        BE.valorfind = txt_filter2.Text;
        switch (cbo_filtro2.SelectedValue)
        {
            case "01":
                BE.articidold = txt_filter2.Text.Trim().ToUpper();
                break;
            case "02":
                BE.articname = txt_filter2.Text.Trim().ToUpper();
                break;
            default:
                //**
                break;
        }
        try
        {
            //Eliminar Columnas Actuales(Opcional):
            GridView2.Columns.Clear();
            GridView2.Width = 535;
            //Objeto Columna:
            CommandField image;
            //Crear Columna:
            image = new CommandField();
            image.ButtonType = ButtonType.Image;
            image.SelectImageUrl = "~/Images/go-search.png";
            image.ShowSelectButton = true;
            image.ItemStyle.Width = 10;
            image.ItemStyle.Wrap = true;
            GridView2.Columns.Add(image);

            BoundField ARTICIDOLD;
            ARTICIDOLD = new BoundField();
            ARTICIDOLD.DataField = "articidold";
            ARTICIDOLD.HeaderText = "CODIGO_OLD";
            ARTICIDOLD.ItemStyle.Width = 70;
            GridView2.Columns.Add(ARTICIDOLD);

            BoundField ARTICNAME;
            ARTICNAME = new BoundField();
            ARTICNAME.DataField = "articname";
            ARTICNAME.HeaderText = "ARTICULO";
            ARTICNAME.ItemStyle.Width = 250;
            GridView2.Columns.Add(ARTICNAME);

            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            GridView2.DataSource = dt;
            GridView2.DataBind();
            GridView2.Visible = true;
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }

    protected void cmb_tipventa_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarCombosCmbPlazo();                        
    }

    void CargarCombosCmbPlazo()
    {
        if (cmb_tipventa.SelectedIndex != -1)
        {
            if (cmb_tipventa.SelectedValue.ToString() == "01")
            {
                cmb_plazoday.Items.Clear();
                cmb_plazoday.SelectedIndex = -1;
                cmb_plazoday.Items.Insert(0, new ListItem("0 Dias", "0"));
                cmb_plazoday.Items.Insert(1, new ListItem("30 Dias", "30"));
                cmb_plazoday.Items.Insert(2, new ListItem("60 Dias", "60"));
                cmb_plazoday.Items.Insert(3, new ListItem("90 Dias", "90"));
            }
            if (cmb_tipventa.SelectedValue.ToString() == "02")
            {
                cmb_plazoday.Items.Clear();
                cmb_plazoday.SelectedIndex = -1;
                cmb_plazoday.Items.Insert(0, new ListItem("120 Dias", "120"));
            }
            if (cmb_tipventa.SelectedValue.ToString() == "03")
            {
                cmb_plazoday.Items.Clear();
                cmb_plazoday.SelectedIndex = -1;
                cmb_plazoday.Items.Insert(0, new ListItem("0 Dias", "0"));
                cmb_plazoday.Items.Insert(1, new ListItem("30 Dias", "30"));
            }
        }            
    }

    protected void btn_BuscarProforma_Click(object sender, ImageClickEventArgs e)
    {
        tb_cxc_pedidocabBL BL = new tb_cxc_pedidocabBL();
        tb_cxc_pedidocab BE = new tb_cxc_pedidocab();
        DataTable dt = new DataTable();
        BE.tipdoc = txt_tipdoc.Text.ToUpper();
        BE.serdoc = txt_serdoc.Text.Trim();
        BE.numdoc = txt_numdoc.Text.PadLeft(10, '0');
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txt_numdoc.Text = dt.Rows[0]["numdoc"].ToString();
            txt_numdoc2.Text = dt.Rows[0]["numdoc"].ToString();
            cmb_tipventa.SelectedValue = dt.Rows[0]["tipventaid"].ToString();
            // cmb_tipventa.SelectedIndexChanged += new System.EventHandler(cmb_tipventa_SelectedIndexChanged); 
            // Para Cargar el Combo PlazoDay
            // cmb_tipventa.AutoPostBack = true;
            fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Substring(0,10);
            fechentrega.Text = dt.Rows[0]["fechentrega"].ToString().Substring(0,10);
            txt_vendorid.Text = dt.Rows[0]["vendorid"].ToString();
            txt_vendorname.Text = dt.Rows[0]["vendorname"].ToString();
            txt_ctacte.Text = dt.Rows[0]["ctacte"].ToString();
            ValidaCliente(txt_ctacte.Text);
            txt_ctactename.Text = dt.Rows[0]["ctactename"].ToString();
            txt_ruc.Text = dt.Rows[0]["nmruc"].ToString();
            replegal_dni.Text = dt.Rows[0]["replegal_dni"].ToString();
            replegal_name.Text = dt.Rows[0]["replegal_name"].ToString();
            direc_entrega.Text = dt.Rows[0]["direc_entrega"].ToString();
            cmb_condventaid.SelectedValue = dt.Rows[0]["condventaid"].ToString();
            cmb_plazoday.SelectedValue = dt.Rows[0]["plazoday"].ToString();
            Double impb = Convert.ToDouble(dt.Rows[0]["impobruto"].ToString());
            txt_impobruto.Text = impb.ToString("##,###,##0.00");
            // Rangoid
            Double tdsct = Convert.ToDouble(dt.Rows[0]["tasadescto"].ToString());
            txt_tasadescto.Text = tdsct.ToString("##,###,##0.00");
            Double impn = Convert.ToDouble(dt.Rows[0]["imponeto"].ToString());
            txt_imponeto.Text = impn.ToString("##,###,##0.00");
            imponeto2.Text = impn.ToString("##,###,##0.00");
            cmb_moneda.SelectedValue = dt.Rows[0]["moneda"].ToString();
            // Validar el IGV
            if (Convert.ToBoolean(dt.Rows[0]["incluye_igv"]))
            { 
                cmb_igv.Value = "S"; 
            }
            else 
            { 
                cmb_igv.Value = "N"; 
            }

            cmb_mediopagoid.Value = dt.Rows[0]["mediopagoid"].ToString();
            spe_numdocs.Text = dt.Rows[0]["numdocs"].ToString();
            if (dt.Rows[0]["aprob_status"].ToString() != "") 
            { 
               // aprob_status.SelectedValue = dt.Rows[0]["aprob_status"].ToString(); 
            }
            //aprob_obs.Text = dt.Rows[0]["aprob_obser"].ToString();
            //aprob_fech.Date = Convert.ToDateTime(dt.Rows[0]["aprob_fech"].ToString());


            //*************************************************** Ahora Vamos a Cargar los Detalles
            CargarDetalleProfor(txt_tipdoc.Text.ToUpper(), txt_serdoc.Text, txt_numdoc.Text.PadLeft(10, '0'));
            CargarDetalleCrono(txt_tipdoc.Text.ToUpper(), txt_serdoc.Text, txt_numdoc.Text.PadLeft(10, '0'));

            //Activar Los Botones Segun La Busqueda
            //Lock_or_Unlock_Boton("G", false, "_disabled");
            //Lock_or_Unlock_Boton("C", false, "_disabled");
            //Lock_or_Unlock_Boton("E", true, "");
            //Lock_or_Unlock_Boton("D", true, "");
            //Lock_or_Unlock_Boton("I", true, "");  
        }
    }

    private void CargarDatosPedido()
    {
        tb_cxc_pedidocabBL BL = new tb_cxc_pedidocabBL();
        tb_cxc_pedidocab BE = new tb_cxc_pedidocab();
        DataTable dt = new DataTable();

        txt_tipdoc.Text = Session["xtipdoc"].ToString();
        txt_serdoc.Text = Session["xserdoc"].ToString();
        txt_numdoc.Text = Session["xnumdoc"].ToString();
          
        BE.tipdoc = Session["xtipdoc"].ToString();
        BE.serdoc = Session["xserdoc"].ToString();
        BE.numdoc = Session["xnumdoc"].ToString();
		string numdoc = Session["xtipdoc"].ToString() +"-"+ Session["xnumdoc"].ToString();
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txt_proforma.Text = numdoc.ToString();//dt.Rows[0]["numdoc"].ToString();
            txt_proforma2.Text = numdoc.ToString();//dt.Rows[0]["numdoc"].ToString();
            cmb_tipventa.SelectedValue = dt.Rows[0]["tipventaid"].ToString();
            // cmb_tipventa.SelectedIndexChanged += new System.EventHandler(cmb_tipventa_SelectedIndexChanged); 
            // Para Cargar el Combo PlazoDay
            // cmb_tipventa.AutoPostBack = true;
            fechdoc.Text = dt.Rows[0]["fechdoc"].ToString().Substring(0,10);
            fechentrega.Text = dt.Rows[0]["fechentrega"].ToString().Substring(0,10);
            txt_vendorid.Text = dt.Rows[0]["vendorid"].ToString();
            txt_vendorname.Text = dt.Rows[0]["vendorname"].ToString();
            txt_ctacte.Text = dt.Rows[0]["ctacte"].ToString();
            ValidaCliente(txt_ctacte.Text);
            txt_ctactename.Text = dt.Rows[0]["ctactename"].ToString();
            txt_ruc.Text = dt.Rows[0]["nmruc"].ToString();
            replegal_dni.Text = dt.Rows[0]["replegal_dni"].ToString();
            replegal_name.Text = dt.Rows[0]["replegal_name"].ToString();
            direc_entrega.Text = dt.Rows[0]["direc_entrega"].ToString();
            cmb_condventaid.SelectedValue = dt.Rows[0]["condventaid"].ToString();
            cmb_plazoday.SelectedValue = dt.Rows[0]["plazoday"].ToString();
            Double impb = Convert.ToDouble(dt.Rows[0]["impobruto"].ToString());
            txt_impobruto.Text = impb.ToString("##,###,##0.00");
            // Rangoid
            Double tdsct = Convert.ToDouble(dt.Rows[0]["tasadescto"].ToString());
            txt_tasadescto.Text = tdsct.ToString("##,###,##0.00");
            Double impn = Convert.ToDouble(dt.Rows[0]["imponeto"].ToString());
            txt_imponeto.Text = impn.ToString("##,###,##0.00");
            imponeto2.Text = impn.ToString("##,###,##0.00");
            cmb_moneda.SelectedValue = dt.Rows[0]["moneda"].ToString();
            // Validar el IGV
            if (Convert.ToBoolean(dt.Rows[0]["incluye_igv"]))
            {
                cmb_igv.Value = "S";
            }
            else
            {
                cmb_igv.Value = "N";
            }

            cmb_mediopagoid.Value = dt.Rows[0]["mediopagoid"].ToString();
            spe_numdocs.Text = dt.Rows[0]["numdocs"].ToString();
            if (dt.Rows[0]["aprob_status"].ToString() != "")
            {
                // aprob_status.SelectedValue = dt.Rows[0]["aprob_status"].ToString(); 
            }
            //aprob_obs.Text = dt.Rows[0]["aprob_obser"].ToString();
            //aprob_fech.Date = Convert.ToDateTime(dt.Rows[0]["aprob_fech"].ToString());


            //*************************************************** Ahora Vamos a Cargar los Detalles
            CargarDetalleProfor(Session["xtipdoc"].ToString().ToUpper(), Session["xserdoc"].ToString(), Session["xnumdoc"].ToString().PadLeft(10, '0'));
            CargarDetalleCrono(Session["xtipdoc"].ToString().ToUpper(), Session["xserdoc"].ToString(), Session["xnumdoc"].ToString().PadLeft(10, '0'));

            //Activar Los Botones Segun La Busqueda
            //Lock_or_Unlock_Boton("G", false, "_disabled");
            //Lock_or_Unlock_Boton("C", false, "_disabled");
            //Lock_or_Unlock_Boton("E", true, "");
            //Lock_or_Unlock_Boton("D", true, "");
            //Lock_or_Unlock_Boton("I", true, "");
        }
    }


    private void CargarDetalleProfor(String xtip, String xser, String xnum)
    {
        tb_cxc_pedidodetBL BL = new tb_cxc_pedidodetBL();
        tb_cxc_pedidodet BE = new tb_cxc_pedidodet();
        BE.tipdoc = xtip.ToString();
        BE.serdoc = xser.ToString();
        BE.numdoc = xnum.ToString();
        TablaDetalle = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        griddetalle.DataSource = TablaDetalle;
        griddetalle.DataBind();
        Session["TablaDetalle"] = TablaDetalle;
    }

    private void CargarDetalleCrono(String xtip, String xser, String xnum)
    {
        tb_cxc_cronoPagosBL BL = new tb_cxc_cronoPagosBL();
        tb_cxc_cronoPagos BE = new tb_cxc_cronoPagos();
        BE.tipdoc = xtip.ToString();
        BE.serdoc = xser.ToString();
        BE.numdoc = xnum.ToString();
        TablaCronoPagos = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        gridcronpagos.DataSource = TablaCronoPagos;
        gridcronpagos.DataBind();
        Session["TablaCronoPagos"] = TablaCronoPagos;
    }

    private void LimpiarDocumento()
    {
        cmb_tipventa.SelectedIndex = -1;
        //fechdoc.Text = "";
        //fechentrega.Text = "";
        //txt_vendorid.Text = "";
        //txt_vendorname.Text = "";
        txt_ctacte.Text = "";
        txt_ctactename.Text = "";
        replegal_dni.Text = "";
        replegal_name.Text = "";
        txt_ruc.Text = "";
        direc_entrega.Text = "";
        cmb_condventaid.SelectedIndex=-1;
        cmb_plazoday.SelectedIndex=-1;
        txt_impobruto.Text="0.00";
        //rangoid
        txt_tasadescto.Text = "0";
        txt_imponeto.Text = "0.00";
        imponeto2.Text = "0.00";
        cmb_moneda.SelectedIndex=-1;
        cmb_igv.Value = "S";
        txt_obs.Text = "";

        //aprob_status.SelectedIndex=-1;
        //aprob_obs.Text = "";
        //aprob_fech.Text = "";

        //Limpia detalles
        btn_add.CssClass = "btn btn-default";
        btn_add.Enabled = false;
        txt_articidold.Text = "";
        txt_marcaname.Text = "";
        txt_articname.Text = "";
        //cmb_colorid.SelectedIndex = -1;
        //cmb_tallaid.SelectedIndex = -1;
        txt_precventa_cre_menor.Text = "";
        spe_cantidad.Text = "1";

        //Limpia Cronograma
        txt_proforma2.Text = "";
        imponeto2.Text = "";
        cmb_mediopagoid.SelectedIndex = -1;
        spe_numdocs.Text = "1";
       
        
        // Limpiamos el DatagridDetalle
        ArmadoTablasDetalle();
        griddetalle.DataSource = TablaDetalle;
        griddetalle.DataBind();

        ArmarTablaCronoPagos();
        gridcronpagos.DataSource = TablaCronoPagos;
        gridcronpagos.DataBind();
    }

    protected void btn_Nuevo_Click(object sender, ImageClickEventArgs e)
    {
        Session["ssModo"] = "NEW";
        CargarCorrelativoDoc();
        LimpiarDocumento();
        Lock_or_UnLock_Paneles("01", true, "", "");
        Lock_or_Unlock_Boton("N", false, "_disabled");
        Lock_or_Unlock_Boton("G", true, "");
        Lock_or_Unlock_Boton("C", true, "");
        Vendedor();
    }

    // PINTAMOS EL VENDEDOR DE DICHA
    void Vendedor()
    {
        tb_cxc_vendorBL BL = new tb_cxc_vendorBL();
        tb_cxc_vendor BE = new tb_cxc_vendor();
        DataTable dt = new DataTable();
        BE.usuarweb = Session["ssUsuar"].ToString().Trim();
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txt_vendorid.Text = dt.Rows[0]["vendorid"].ToString();
            txt_vendorname.Text = dt.Rows[0]["vendorname"].ToString();
        }
    }

    //protected void btn_grabar_Click(object sender, EventArgs e)
    void btn_grabar_Click()
    {
        if (Session["ssModo"].ToString() == "NEW")
        { 
            Insert(); 
        }

        if (Session["ssModo"].ToString() == "EDI")
        {
            Insert(); 
            //Update();
        }

        Response.Redirect("~/Comercial/Frm_PedidoResultado.aspx");       

    }

    private void Insert()
    {
        try
        {
            var BL = new tb_cxc_pedidocabBL();
            var BE = new tb_cxc_pedidocab();

            var Detalle = new tb_cxc_pedidocab.Item();
            var ListaItems = new List<tb_cxc_pedidocab.Item>();

            var Detalle2 = new tb_cxc_pedidocab.Crono();
            var ListaCrono = new List<tb_cxc_pedidocab.Crono>();

            #region Datos Cabecera
            BE.tipdoc = txt_tipdoc.Text;
            BE.serdoc = txt_serdoc.Text;
            BE.numdoc = txt_numdoc.Text;
            BE.canalventaid = Session["ssCanalVentaId"].ToString();
            BE.tipventaid = cmb_tipventa.SelectedValue.ToString();
            BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
            BE.fechentrega = Convert.ToDateTime(fechentrega.Text);
            BE.vendorid = txt_vendorid.Text;
            BE.ctacte = txt_ctacte.Text;
            BE.direcnume = "";
            BE.replegal_dni = replegal_dni.Text;
            BE.replegal_name = replegal_name.Text;
            BE.direc_entrega = direc_entrega.Text;
            BE.condventaid = cmb_condventaid.SelectedValue.ToString();
            BE.plazoday = Convert.ToInt32(cmb_plazoday.SelectedValue.ToString());
            BE.impobruto = Convert.ToDecimal(txt_impobruto.Text);
            BE.rangoid = "05";// *****************************************************************
            BE.tasadescto = Convert.ToDecimal(txt_tasadescto.Text);
            BE.imponeto = Convert.ToDecimal(txt_imponeto.Text);
            BE.moneda = cmb_moneda.SelectedValue.ToString();
            if (cmb_igv.Value.ToString() == "S")
            {
                BE.incluye_igv = true;
            }
            else
            {
                BE.incluye_igv = false;
            }
            BE.observacion = txt_obs.Text;
            BE.mediopagoid = cmb_mediopagoid.Value.ToString();
            BE.numdocs = Convert.ToInt32(spe_numdocs.Text);
            BE.aprob_status = AproStatus.ToString() ;//"11";
            //BE.aprob_obser = aprob_obs.Text;
            //if (aprob_fech.Text.Length > 0)
            //{ BE.aprob_fech = Convert.ToDateTime(aprob_fech.Text); }
            BE.usuar = Session["ssUsuar"].ToString().Trim();
            BE.local = Session["ssLocal"].ToString().Trim();
            BE.moduloid = Session["ssModuloId"].ToString().Trim();

            String xmod = Session["ssModo"].ToString();

            switch (Session["ssModo"].ToString())
            {
                case "NEW": BE.accion = "INS"; break;
                case "EDI": BE.accion = "ALT"; break;
                case "DEL": BE.accion = "DEL"; break;
            }
            #endregion

            #region Datos Detalle
            TablaDetalle = (DataTable)Session["TablaDetalle"];
            foreach (DataRow fila in TablaDetalle.Rows)
            {
                Detalle = new tb_cxc_pedidocab.Item();
                Detalle.tipdoc = txt_tipdoc.Text;
                Detalle.serdoc = txt_serdoc.Text;
                Detalle.numdoc = txt_numdoc.Text;

                Detalle.articid = fila["articid"].ToString();
                Detalle.articidold = fila["articidold"].ToString();
                Detalle.colorid = fila["colorid"].ToString();
                Detalle.tallaid = fila["tallaid"].ToString();
                Detalle.coltall = Equivalencias.Right(fila["coltall"].ToString(), 2);
                Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());
                Detalle.precbruto = Convert.ToDecimal(fila["precbruto"].ToString());
                Detalle.impobruto = Convert.ToDecimal(fila["impobruto"].ToString());
                Detalle.precneto = Convert.ToDecimal(fila["precneto"].ToString());
                Detalle.imponeto = Convert.ToDecimal(fila["imponeto"].ToString());
                Detalle.usuar = Session["ssUsuar"].ToString().Trim();
                Detalle.canalventaid = Session["ssCanalVentaId"].ToString();
                Detalle.local = Session["ssLocal"].ToString();

                if (Convert.ToDecimal(fila["imponeto"].ToString()) > 0)
                {
                    ListaItems.Add(Detalle);
                }
                else
                {
                    ClientMessage("DOCUMENTO DETALLE PROFORMA EN FORMATO INCORRECTO ...!!!");
                    return;
                }
            }
            BE.ListaItems = ListaItems;
            #endregion

            #region Datos Detalle CronoGramaPagos
            TablaCronoPagos = (DataTable)Session["TablaCronoPagos"];
            foreach (DataRow fila in TablaCronoPagos.Rows)
            {
                Detalle2 = new tb_cxc_pedidocab.Crono();
                Detalle2.tipdoc = txt_tipdoc.Text;
                Detalle2.serdoc = txt_serdoc.Text;
                Detalle2.numdoc = txt_numdoc.Text;
                Detalle2.mediopagoid = cmb_mediopagoid.Value.ToString();
                Detalle2.item = fila["item"].ToString();
                Detalle2.num_interno = fila["num_interno"].ToString();
                Detalle2.num_unico = fila["num_unico"].ToString();
                Detalle2.monto = Convert.ToDecimal(fila["monto"].ToString());
                String xfecha = Equivalencias.Left(fila["fechven"].ToString(), 10);
                Detalle2.fechven = Convert.ToDateTime(xfecha);
                Detalle2.usuar = Session["ssUsuar"].ToString().Trim();

                if (Convert.ToDecimal(fila["monto"].ToString()) > 0)
                {
                    ListaCrono.Add(Detalle2);
                }
                else
                {
                    ClientMessage("DOCUMENTO DETALLE CRONOGRAMA PAGOS EN FORMATO INCORRECTO ...!!!");
                    return;
                }
            }
            BE.ListaCrono = ListaCrono;
            #endregion

            #region Inserción de Datos en Tabla Stock diario
            var BLStk = new tb_me_stockdiariocabBL();
            var BEStk = new tb_me_stockdiariocab();
            //var BLStk = new tb_cxc_pedidocabBL();
            //var BEStk = new tb_cxc_pedidocab();


            //switch (Session["ssModo"].ToString())
            //{
            //    case "NEW": BE.accion = "INS"; break;
            //    case "EDIT": BE.accion = "ALT"; break;
            //    case "DEL": BE.accion = "DEL"; break;
            //}

            //BEStk.almacaccionid = "21";
            #endregion

            #region Inserción de Datos en Tabla Stock Diario Detalle
            decimal canti = 0;
            var DetalleStk = new tb_cxc_pedidocab.ItemsStkDeta();
            var ListaStkItems = new List<tb_cxc_pedidocab.ItemsStkDeta>();
            TablaDetalleStk = (DataTable)Session["TablaDetalle"];
            foreach (DataRow fila in TablaDetalleStk.Rows)
            {
                DetalleStk = new tb_cxc_pedidocab.ItemsStkDeta();
                DetalleStk.fecha = Convert.ToDateTime(DateTime.Today.ToString()); //Convert.ToDateTime(Session["bd_fecha"].ToString());
                DetalleStk.articid = fila["articid"].ToString();
                DetalleStk.colorid = fila["colorid"].ToString();
                DetalleStk.coltall = Equivalencias.Right(fila["coltall"].ToString(), 2);
                DetalleStk.almacaccionid = "21";
                DetalleStk.tipodoc = txt_tipdoc.Text;
                DetalleStk.serdoc = txt_serdoc.Text;
                DetalleStk.numdoc = txt_numdoc.Text;
                canti = Convert.ToDecimal(fila["cantidad"].ToString());
                DetalleStk.cantidad = canti;
                DetalleStk.ctacte = txt_ctacte.Text;
                DetalleStk.direcnume = Session["direcnume"].ToString();//direc_entrega.Text;
                DetalleStk.tipoperacionid = "10";
                DetalleStk.tiporef = txt_tipdoc.Text;
                DetalleStk.serref = txt_serdoc.Text;
                DetalleStk.numref = txt_numdoc.Text;
                DetalleStk.estado = 1;
                DetalleStk.atendido = 0;
                DetalleStk.vendorid = txt_vendorid.Text;
                DetalleStk.usuar = Session["ssUsuar"].ToString().Trim();
                DetalleStk.canalventaid = Session["ssCanalVentaId"].ToString();
                DetalleStk.local = Session["ssLocal"].ToString();
                DetalleStk.dominioid = Session["ssDominioid"].ToString();
                DetalleStk.moduloid = Session["ssModuloid"].ToString();

                if (TablaDetalle.Rows.Count > 0)
                {
                    ListaStkItems.Add(DetalleStk);
                }
                else
                {
                    ClientMessage("DOCUMENTO DETALLE INCORRECTO ...!!!");
                    return;
                }
            }
            BE.listaItemsStkDeta = ListaStkItems;
            #endregion

            //BLStk.InsertStk(Session["ssEmpresaID"].ToString(), BEStk);

            // PASAR A LLAMAR AL METODO DE INSERCION DE PEDIDO
            if (BL.Insert(Session["ssEmpresaID"].ToString(), BE))
            {
                ClientMessage("Registros Grabados Correctamente !!!");
                LimpiarDocumento();
                CargarCorrelativoDoc();

                //Lock_or_Unlock_Boton("N", true, "");
                //Lock_or_Unlock_Boton("C", false, "_disabled");
                //Lock_or_Unlock_Boton("G", false, "_disabled");
                //Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
                //Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");  
                //Lock_or_UnLock_Paneles("03", false, "fondo_bloqueo", "_disabled"); 

                btn_Imprimir.Enabled = true;
                btn_Imprimir.CssClass = "btn btn-primary";
                //btn_grabar.Enabled = false;
                //btn_grabar.CssClass = "btn btn-default";
            }
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }


    private void Update()
    {
        try
        {
            var BL = new tb_cxc_pedidocabBL();
            var BE = new tb_cxc_pedidocab();

            var Detalle = new tb_cxc_pedidocab.Item();
            var ListaItems = new List<tb_cxc_pedidocab.Item>();

            var Detalle2 = new tb_cxc_pedidocab.Crono();
            var ListaCrono = new List<tb_cxc_pedidocab.Crono>();

            #region Datos Cabecera
            BE.tipdoc = txt_tipdoc.Text;
            BE.serdoc = txt_serdoc.Text;
            BE.numdoc = txt_numdoc.Text;
           
            BE.canalventaid = Session["ssCanalVentaId"].ToString();
            BE.tipventaid = cmb_tipventa.SelectedValue.ToString();
            BE.fechdoc = Convert.ToDateTime(fechdoc.Text);
            BE.fechentrega = Convert.ToDateTime(fechentrega.Text);
            BE.vendorid = txt_vendorid.Text;
            BE.ctacte = txt_ctacte.Text;
            BE.replegal_dni = replegal_dni.Text;
            BE.replegal_name = replegal_name.Text;
            BE.direc_entrega = direc_entrega.Text;
            BE.condventaid = cmb_condventaid.SelectedValue.ToString();
            BE.plazoday = Convert.ToInt32(cmb_plazoday.SelectedValue.ToString());
            BE.impobruto = Convert.ToDecimal(txt_impobruto.Text);
            BE.rangoid = "05";// *****************************************************************
            BE.tasadescto = Convert.ToDecimal(txt_tasadescto.Text);
            BE.imponeto = Convert.ToDecimal(txt_imponeto.Text);
            BE.moneda = cmb_moneda.SelectedValue.ToString();
            if (cmb_igv.Value.ToString() == "S") 
            { 
                BE.incluye_igv = true; 
            }
            else 
            {
                BE.incluye_igv = false; 
            }
            BE.observacion = txt_obs.Text;
            BE.mediopagoid = cmb_mediopagoid.Value.ToString();
            BE.numdocs = Convert.ToInt32(spe_numdocs.Text);
            BE.aprob_status = "11";
            //BE.aprob_obser = aprob_obs.Text;
            //if (aprob_fech.Text.Length > 0)
            //{ BE.aprob_fech = Convert.ToDateTime(aprob_fech.Text); }
            BE.usuar = Session["ssUsuar"].ToString();
            #endregion

            #region Datos Detalle
            TablaDetalle = (DataTable)Session["TablaDetalle"];
            foreach (DataRow fila in TablaDetalle.Rows)
            {
                Detalle = new tb_cxc_pedidocab.Item();
                Detalle.tipdoc = txt_tipdoc.Text;
                Detalle.serdoc = txt_serdoc.Text;
                Detalle.numdoc = txt_numdoc.Text;
                Detalle.articid = fila["articid"].ToString();
                Detalle.articidold = fila["articidold"].ToString();
                Detalle.colorid = fila["colorid"].ToString();
                Detalle.tallaid = fila["tallaid"].ToString();
                Detalle.coltall = fila["talla"].ToString();
                Detalle.cantidad = Convert.ToDecimal(fila["cantidad"].ToString());
                Detalle.precbruto = Convert.ToDecimal(fila["precbruto"].ToString());
                Detalle.impobruto = Convert.ToDecimal(fila["impobruto"].ToString());
                Detalle.precneto = Convert.ToDecimal(fila["precneto"].ToString());
                Detalle.imponeto = Convert.ToDecimal(fila["imponeto"].ToString());
                Detalle.usuar = Session["ssUsuar"].ToString().Trim();
                Detalle.canalventaid = Session["ssCanalVentaId"].ToString();
                Detalle.local = Session["ssLocal"].ToString();

                if (Convert.ToDecimal(fila["imponeto"].ToString()) > 0)
                {
                    ListaItems.Add(Detalle);
                }
                else
                {
                    ClientMessage("DOCUMENTO DETALLE PROFORMA EN FORMATO INCORRECTO ...!!!");
                    return;
                }
            }
            BE.ListaItems = ListaItems;
            #endregion

            #region Datos Detalle CronoGramaPagos
            TablaCronoPagos = (DataTable)Session["TablaCronoPagos"];
            foreach (DataRow fila in TablaCronoPagos.Rows)
            {
                Detalle2 = new tb_cxc_pedidocab.Crono();
                Detalle2.tipdoc = txt_tipdoc.Text;
                Detalle2.serdoc = txt_serdoc.Text;
                Detalle2.numdoc = txt_numdoc.Text;
                Detalle2.mediopagoid = cmb_mediopagoid.Value.ToString();
                Detalle2.item = fila["item"].ToString();
                Detalle2.num_interno = fila["num_interno"].ToString();
                Detalle2.num_unico = fila["num_unico"].ToString();
                Detalle2.monto = Convert.ToDecimal(fila["monto"].ToString());
                String xfecha = Equivalencias.Left(fila["fechven"].ToString(), 10);
                Detalle2.fechven = Convert.ToDateTime(xfecha);
                Detalle2.usuar = Session["ssUsuar"].ToString().Trim();

                if (Convert.ToDecimal(fila["monto"].ToString()) > 0)
                {
                    ListaCrono.Add(Detalle2);
                }
                else
                {
                    ClientMessage("DOCUMENTO DETALLE CRONOGRAMA PAGOS EN FORMATO INCORRECTO ...!!!");
                    return;
                }
            }
            BE.ListaCrono = ListaCrono;
            #endregion

            // PASAR A LLAMAR AL METODO DE INSERCION DE PROFORMA
            if (BL.Update(Session["ssEmpresaID"].ToString(), BE))
            {
                //ClientMessage("Registros Modificados Correctamente !!!");
                MensajeQuery2("Registros Modificados Correctamente !!!");           

                LimpiarDocumento();
                CargarCorrelativoDoc();
                Lock_or_Unlock_Boton("N", true, "");
                Lock_or_Unlock_Boton("C", false, "_disabled");
                Lock_or_Unlock_Boton("G", false, "_disabled");
                Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
                Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");
                Lock_or_UnLock_Paneles("03", false, "fondo_bloqueo", "_disabled");

                btn_Imprimir.Enabled = true;
                btn_Imprimir.CssClass = "btn btn-primary";
                //btn_grabar.Enabled = false;
                //btn_grabar.CssClass = "btn btn-default";
            }
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }      
    }

    protected void btn_Editar_Click(object sender, ImageClickEventArgs e)
    {
        Session["ssModo"] = "EDI";
        Lock_or_UnLock_Paneles("01", true, "", "");        
        Lock_or_Unlock_Boton("G", true, "");
        Lock_or_Unlock_Boton("C", true, "");
        Lock_or_Unlock_Boton("E", false, "_disabled");
        Lock_or_Unlock_Boton("N", false, "_disabled");
        Lock_or_Unlock_Boton("D", false, "_disabled");
        Lock_or_Unlock_Boton("I", false, "_disabled");
    }

    protected void btn_Cancelar_Click(object sender, ImageClickEventArgs e)
    {
        Session["ssModo"] = "N";
        Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("03", false, "fondo_bloqueo", "_disabled");
        LimpiarDocumento();
        Lock_or_Unlock_Boton("N", true, "");
        Lock_or_Unlock_Boton("G", false, "_disabled");
        Lock_or_Unlock_Boton("C", false, "_disabled");        
        Lock_or_Unlock_Boton("D", false, "_disabled");
        Lock_or_Unlock_Boton("I", false, "_disabled");
    }

    //Metodos De Actualizacion Cuando Cambiamos - CondVenta y Plazo de Dias
    protected void cmb_plazoday_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmb_plazoday.SelectedIndex != -1)
        {
            if (Session["ssModo"].ToString() == "EDI")
            { 
                Calculos();
                MetodoNumDocs();
                Calculos_CronogramaPagos();
            }
        }
    }

    protected void cmb_mediopagoid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(cmb_mediopagoid.SelectedIndex != -1)
        {
            Calculos_CronogramaPagos();
        }
    }

    protected void spe_numdocs_NumberChanged(object sender, EventArgs e)
    {
        Calculos_CronogramaPagos();
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
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
        
    }
    
    protected void btn_Imprimir_Click(object sender, ImageClickEventArgs e)
    {
        // PROVAMOS EL REPORTE AHORA EN PDF            

        Session["xtipdoc"] = txt_tipdoc2.Text.ToUpper();
        Session["xserdoc"] = txt_serdoc2.Text;
        Session["xnumdoc"] = txt_numdoc2.Text;

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

        //btn_Imprimir_ClickExtracted();
        //reemplazarvaloresWORD();
        // Reporte de Tablas en Word 
        #region Temporal Bloqueado
        //Word.Application app = new Word.Application();
        //Word.Document doc = CreateTableWord(app, (DataTable)(Session["TablaCronoPagos"]));

        //if (((doc != null))) {
        //    var _with1 = doc;
        //    _with1.SaveAs(@"C:\ReporteWeb\Prueba_Tabla.docx");
        //    _with1.Close();
        //}

        //// Cerramos Word y liberamos los recursos asociados.
        ////
        //app.Quit();
        //app = null;
        #endregion     
    }

    #region Imprsion en Documento Word

    //private void impresionWord01()
    //{
    //    //Objeto del Tipo Word Application 
    //    Word.Application objWordApplication;
    //    //Objeto del Tipo Word Document 
    //    Word.Document objWordDocument;
    //    // Objeto para interactuar con el Interop 
    //    Object oMissing = System.Reflection.Missing.Value;
    //    //Creamos una instancia de una Aplicación Word. 
    //    objWordApplication = new Word.Application();
    //    //A la aplicación Word, le añadimos un documento. 
    //    objWordDocument = objWordApplication.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

    //    //Activamos el documento recien creado, de forma que podamos escribir en el 
    //    objWordDocument.Activate();

    //    //Empezamos a escribir
    //    objWordApplication.Selection.Font.Size = 24; //Tamaño de la Fuente 
    //    objWordApplication.Selection.Font.Bold = 1; // Negrita 
    //    objWordApplication.Selection.TypeText("“Mis Felicitaciones al Grupo de MSP Venezuela in Training”");

    //    //Hace visible la Aplicacion para que veas lo que se ha escrito 
    //    objWordApplication.Visible = true;
    //}
    #endregion

    #region Reemplazar Datos en Doc_Word
    //private void reemplazarvaloresWORD()
    //{
    //    //  create offer letter
    //    try
    //    {
    //        //  Just to kill WINWORD.EXE if it is running
    //        //killprocess("winword");
    //        //Declaramos Path
    //         string phat = Server.MapPath("~/Reportes/prueba.docx");
    //         string phat2 = Server.MapPath("~/Reportes/CONTRATO_PIEERS_EMP_hugo.docx");
    //        //  copy letter format to temp.doc
    //        File.Copy(phat, phat2, true);
    //        //  create missing object
    //        object missing = Missing.Value;
    //        //  create Word application object
    //        Word.Application wordApp = new Word.ApplicationClass();
    //        //  create Word document object
    //        Word.Document aDoc = null;
    //        //  create & define filename object with temp.doc
    //        object filename = phat2;
    //        //  if temp.doc available
    //        if (File.Exists((string)filename))
    //        {
    //            object readOnly = false;
    //            object isVisible = false;
    //            //  make visible Word application
    //            wordApp.Visible = false;
    //            //  open Word document named temp.doc
    //            aDoc = wordApp.Documents.Open(ref filename, ref missing,
    //                                          ref readOnly, ref missing, ref missing, ref missing,
    //                                          ref missing, ref missing, ref missing, ref missing,
    //                                          ref missing, ref isVisible, ref missing, ref missing,
    //                                          ref missing, ref missing);
    //            aDoc.Activate();
    //            //  Call FindAndReplace()function for each change
    //            this.FindAndReplace(wordApp, "<Date>", "20/03/2015");
    //            this.FindAndReplace(wordApp, "<Name>", "HUGO VILCHEZ");
    //            this.FindAndReplace(wordApp, "<Subject>", "PERSONA_01");
    //            //  save temp.doc after modified
    //            aDoc.Save();
    //            wordApp.Visible = true;
    //        }
    //        else { }
    //            //MessageBox.Show("File does not exist.","No File", MessageBoxButtons.OK,MessageBoxIcon.Information);
    //            //killprocess("winword");
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show("Error in process.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}
    //private void FindAndReplace(Word.Application wordApp,object findText, object replaceText)
    //{
    //    object matchCase = true;
    //    object matchWholeWord = true;
    //    object matchWildCards = false;
    //    object matchSoundsLike = false;
    //    object matchAllWordForms = false;
    //    object forward = true;
    //    object format = false;
    //    object matchKashida = false;
    //    object matchDiacritics = false;
    //    object matchAlefHamza = false;
    //    object matchControl = false;
    //    object read_only = false;
    //    object visible = true;
    //    object replace = 2;
    //    object wrap = 1;
    //    wordApp.Selection.Find.Execute(ref findText, ref matchCase,
    //        ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
    //        ref matchAllWordForms, ref forward, ref wrap, ref format,
    //        ref replaceText, ref replace, ref matchKashida,
    //                ref matchDiacritics,
    //        ref matchAlefHamza, ref matchControl);
    //}
    #endregion

    private void btn_Imprimir_ClickExtracted()
    {
        String xsiglaemisor = "VH/PIEERS";

        DataTable dt = new DataTable();
        dt.Columns.Add("[xnumdoc]", typeof(String));
        dt.Columns.Add("[xserdoc]", typeof(String));
        dt.Columns.Add("[xsiglaemisor]", typeof(String));
        dt.Columns.Add("[xempresaname]", typeof(String));
        dt.Columns.Add("[xnmruc]", typeof(String));
        dt.Columns.Add("[xgerentegeneral]", typeof(String));
        dt.Columns.Add("[xnrodni]", typeof(String));
        dt.Columns.Add("[ximpobruto]", typeof(String));
        dt.Columns.Add("[xtasadescto]", typeof(String));
        dt.Columns.Add("[ximponeto]", typeof(String));
        dt.Columns.Add("[xplazoday]", typeof(String));
        dt.Columns.Add("[xnumdocs]", typeof(String));
        dt.Columns.Add("[xmediopago]", typeof(String));
        dt.Columns.Add("[xndias]", typeof(String));
        dt.Columns.Add("[xvendorname]", typeof(String));
        dt.Columns.Add("[xctactename]", typeof(String));
        dt.Columns.Add("[xclinmruc]", typeof(String));
        dt.Columns.Add("[xdirec]", typeof(String));
        dt.Columns.Add("[xpartelectro]", typeof(String));
        dt.Columns.Add("[xreplegalname]", typeof(String));
        dt.Columns.Add("[xreplegaldni]", typeof(String));        
        dt.Columns.Add("[xfecha]", typeof(String));
        dt.Columns.Add("[xco]", typeof(String));
        dt.Columns.Add("[xcr]", typeof(String));
        dt.Columns.Add("[xnmone]", typeof(String));
        dt.Columns.Add("[xigv]", typeof(String));

        DataRow workRow;
        workRow = dt.NewRow();
        workRow["[xnumdoc]"] = Equivalencias.Right(txt_numdoc.Text,5);
        workRow["[xserdoc]"] = txt_serdoc.Text.ToUpper();
        workRow["[xsiglaemisor]"] = xsiglaemisor;
        workRow["[xempresaname]"] = Session["ssEmpresaName"].ToString();
        workRow["[xnmruc]"] = Session["ssEmpresaRuc"].ToString();
        workRow["[xgerentegeneral]"] = Session["ssGerenteGeneral"].ToString();
        workRow["[xnrodni]"] = Session["ssGerenteNrodni"].ToString();
        workRow["[ximpobruto]"] = txt_impobruto.Text;
        workRow["[xtasadescto]"] = Equivalencias.Left(txt_tasadescto.Text,2);
        workRow["[ximponeto]"] = txt_imponeto.Text;
        workRow["[xplazoday]"] = cmb_plazoday.SelectedValue.ToString();
        workRow["[xnumdocs]"] = spe_numdocs.Text;
        workRow["[xmediopago]"] = cmb_mediopagoid.Text.ToLower();
        workRow["[xndias]"] = "3";
        workRow["[xvendorname]"] = txt_vendorname.Text;
        workRow["[xctactename]"] = txt_ctactename.Text;
        workRow["[xclinmruc]"] = txt_ruc.Text;
        workRow["[xdirec]"] = direc_entrega.Text;
        workRow["[xpartelectro]"] = Session["ssPartElectro"].ToString();
        workRow["[xreplegalname]"] = "xxxxx";
        workRow["[xreplegaldni]"] = "xxxxx";        
        String xfech = DateTime.Today.ToLongDateString();
        string[] split = xfech.Split(new Char[] {','});        
        workRow["[xfecha]"] = "Lima," + split[1];

        if (cmb_condventaid.SelectedValue.ToString() == "01")
        {
            workRow["[xco]"] = "X";
            workRow["[xcr]"] = "";
        }
        else
        {
            workRow["[xco]"] = "";
            workRow["[xcr]"] = "X";
        }

        if (cmb_moneda.SelectedValue.ToString() == "S") 
        { 
            workRow["[xnmone]"] = "EN SOLES"; 
        } 
        else 
        {
            workRow["[xnmone]"] = "EN DOLARES";
        }
        if (cmb_igv.Value.ToString() == "S") 
        { workRow["[xigv]"] = "SI"; } 
        else { workRow["[xigv]"] = "NO"; }
        dt.Rows.Add(workRow);

        // ARMAR NOMBRE DE COMO SE VA A GUARDAR EL ARCHIVO DOC
        String name = "CONTRATO-" + Equivalencias.Right(txt_numdoc.Text, 5) + "-" + txt_serdoc.Text;
        //VariablesPublicas.REPORTE_WORD_WEB(dt,name);
        REPORTE_WORD_WEB(dt, name);
    }    

    // ****************************** METODO DE IMPRESION A WORD
    public void REPORTE_WORD_WEB(DataTable tmpdata, String xdoc)
    {
        int vmcolummnas = 0;
        int nfiladata = 0;
        int vmfilascamposreplace = 0;

        Word.Application oWord;
        Word.Document oDocument;
        Word.Selection loSelection;

        string cValueToreplace = "";
        bool lValue = false;
        string cValueTofind = "";

        try
        {
            DataTable workTable = new DataTable();
            string cDocument = "";
            bool zgenerafile = false;
            workTable.Columns.Add("nomcampo", Type.GetType("System.String"));
            for (vmcolummnas = 0; vmcolummnas <= tmpdata.Columns.Count - 1; vmcolummnas++)
            {
                if (Equivalencias.Left(tmpdata.Columns[vmcolummnas].ColumnName, 2) == "[x")
                {
                    workTable.Rows.Add(VariablesPublicas.INSERTINTOTABLE(workTable));
                    workTable.Rows[workTable.Rows.Count - 1]["nomcampo"] = tmpdata.Columns[vmcolummnas].ColumnName;
                }
            }

            for (nfiladata = 0; nfiladata <= tmpdata.Rows.Count - 1; nfiladata++)
            {
                //string pathHtmlTemplate = "/Reportes/CONTRATO_PIEERS_EMP2.docx"; //las barras son invertidas
                //StringBuilder emailHtml = new StringBuilder(File.ReadAllText(HttpContext.Current.Server.MapPath(pathHtmlTemplate)));

                string phat = Server.MapPath("~/Reportes/CONTRATO_PIEERS_EMP");
                //string phat = System.Web.HttpContext.Current.Server.MapPath("~/bapsoft/PIE/intranet2015/Reportes/CONTRATO_PIEERS_EMP");

                //Response.Write(phat);
                //lblmensaje.Text = phat;

                //String phat = @"C:\ReporteWeb\CONTRATO_PIEERS_EMP";

                cDocument = phat + ".docx";
                zgenerafile = true;
                if (zgenerafile)
                {
                    //Columnas
                    oWord = null;
                    oDocument = null;
                    loSelection = null;
                    oWord = new Word.Application();
                    oWord.Visible = false;

                    oDocument = oWord.Documents.Open(cDocument);
                    for (vmfilascamposreplace = 0; (vmfilascamposreplace <= (workTable.Rows.Count - 1)); vmfilascamposreplace++)
                    {
                        loSelection = oWord.Selection;
                        cValueTofind = workTable.Rows[vmfilascamposreplace]["nomcampo"].ToString().Trim().ToUpper();

                        cValueToreplace = (Strings.Space(1) + (tmpdata.Rows[nfiladata][cValueTofind] + Strings.Space(1)));
                        while ((1 == 1))
                        {
                            var _with1 = loSelection.Find;
                            _with1.Text = cValueTofind;
                            _with1.Replacement.Text = cValueToreplace;

                            _with1.Forward = true;
                            _with1.Wrap = Word.WdFindWrap.wdFindContinue;
                            var _with2 = loSelection;
                            lValue = _with2.Find.Execute();
                            if (lValue)
                            {
                                _with2.Text = cValueToreplace;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    Word.Documents documents = oWord.Documents;
                    Word.Document doc = documents.Add(cDocument);

                    // Número de columnas que tendrá la tabla.   
                    DataTable Tabla01 = new DataTable();
                    TablaCronoPagos = (DataTable)Session["TablaCronoPagos"];
                    Tabla01 = new DataTable("Tabla01");
                    Tabla01.Columns.Add("nletras", typeof(String));
                    Tabla01.Columns.Add("nmonto", typeof(String));
                    Tabla01.Columns.Add("nfecha", typeof(String));

                    foreach (DataRow fila in TablaCronoPagos.Rows)
                    {
                        DataRow workRow;
                        workRow = Tabla01.NewRow();
                        workRow["nletras"] = fila["num_interno"].ToString();
                        workRow["nmonto"] = fila["monto"].ToString();
                        workRow["nfecha"] = Equivalencias.Left(fila["fechven"].ToString(), 10);
                        Tabla01.Rows.Add(workRow);
                    }


                    #region Creacion de Primera Tabla en Word
                    Int32 colsNumbers = Tabla01.Columns.Count;
                    Int32 rowsNumbers = Tabla01.Rows.Count + 1;
                    // PONEMOS UN MARCADOR EN EL WORD PARA SABER EN QUE POSICION SE TIENE QUE IR LA TABLA
                    string bookmarkName1 = "TableCrono";
                    Word.Range range;
                    Object name1 = bookmarkName1;
                    range = doc.Bookmarks.get_Item(ref name1).Range;
                    Word.Table table = doc.Tables.Add(range, rowsNumbers, colsNumbers);

                    for (Int32 col = 1; col <= colsNumbers; col++)
                    {
                        Word.Cell cellc = table.Rows[1].Cells[col];
                        cellc.Shading.ForegroundPatternColor = Word.WdColor.wdColorGray20;
                        if (col == 1)
                        {
                            cellc.Range.Text = "DOC. DE PAGO";
                        }
                        if (col == 2)
                        {
                            cellc.Range.Text = "MONTO (SOLES)";
                        }
                        if (col == 3)
                        {
                            cellc.Range.Text = "FECHA VCTO.";
                        }
                    }

                    for (Int32 row = 2; row <= table.Rows.Count; row++)
                    {
                        Int32 c = 0;
                        foreach (Word.Cell cell in table.Rows[row].Cells)
                        {
                            cell.Range.Text = Tabla01.Rows[row - 2].ItemArray[c].ToString();
                            c += 1;
                        }
                    }
                    //table.Rows[1].Range.Font.Bold = 1;
                    table.Range.Font.Name = "Abadi MT Condensed Light";
                    table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth050pt;
                    table.Borders.InsideLineWidth = 0;
                    table.Borders.InsideColorIndex = Word.WdColorIndex.wdBlue;
                    table.Range.Font.Color = Word.WdColor.wdColorBlack;



                    table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
                    #endregion

                    // ****************************************************************************************
                    // Número de columnas que tendrá la tabla.   
                    DataTable Tabla02 = new DataTable();
                    TablaDetalle = (DataTable)Session["TablaDetalle"];
                    Tabla02 = new DataTable("Tabla02");
                    Tabla02.Columns.Add("CODIGO", typeof(String));
                    Tabla02.Columns.Add("MARCA", typeof(String));
                    Tabla02.Columns.Add("PRODUCTO", typeof(String));
                    Tabla02.Columns.Add("COLOR", typeof(String));
                    Tabla02.Columns.Add("TALLA", typeof(String));
                    Tabla02.Columns.Add("CANTIDAD", typeof(String));
                    Tabla02.Columns.Add("PREC.LST", typeof(String));
                    Tabla02.Columns.Add("VTA.LST", typeof(String));
                    Tabla02.Columns.Add("PREC.DCSTO", typeof(String));
                    Tabla02.Columns.Add("VENT.DCSTO", typeof(String));

                    foreach (DataRow fila in TablaDetalle.Rows)
                    {
                        DataRow workRow;
                        workRow = Tabla02.NewRow();
                        workRow["CODIGO"] = fila["articidold"].ToString();
                        workRow["MARCA"] = fila["marcaname"].ToString();
                        workRow["PRODUCTO"] = Equivalencias.Left(fila["articname"].ToString(), 30);
                        workRow["COLOR"] = fila["colorname"].ToString();
                        workRow["TALLA"] = fila["talla"].ToString();
                        workRow["CANTIDAD"] = fila["cantidad"].ToString();
                        workRow["PREC.LST"] = fila["precbruto"].ToString();
                        workRow["VTA.LST"] = fila["impobruto"].ToString();
                        workRow["PREC.DCSTO"] = fila["precneto"].ToString();
                        workRow["VENT.DCSTO"] = fila["imponeto"].ToString();
                        Tabla02.Rows.Add(workRow);
                    }


                    #region Creacion de Segunda Tabla en Word
                    Int32 colsNums = Tabla02.Columns.Count;
                    Int32 rowsNums = Tabla02.Rows.Count + 1;
                    // PONEMOS UN MARCADOR EN EL WORD PARA SABER EN QUE POSICION SE TIENE QUE IR LA TABLA
                    string bookmarkName = "TableDetalle";
                    Word.Range range2;
                    Object name = bookmarkName;
                    range2 = doc.Bookmarks.get_Item(ref name).Range;
                    Word.Table table2 = doc.Tables.Add(range2, rowsNums, colsNums);

                    for (Int32 col = 1; col <= colsNums; col++)
                    {
                        Word.Cell cell = table2.Rows[1].Cells[col];
                        cell.Range.Text = Tabla02.Columns[col - 1].ColumnName;
                        cell.Shading.ForegroundPatternColor = Word.WdColor.wdColorGray20;
                    }

                    for (Int32 row = 2; row <= table2.Rows.Count; row++)
                    {
                        Int32 c = 0;
                        foreach (Word.Cell cell in table2.Rows[row].Cells)
                        {
                            cell.Range.Text = Tabla02.Rows[row - 2].ItemArray[c].ToString();
                            c += 1;
                        }
                    }

                    //Damos Estilo a la Tabla
                    table2.Rows[1].Range.Font.Size = 10;
                    table2.Rows[1].Range.Font.Bold = 1;
                    table2.Range.Font.Color = Word.WdColor.wdColorBlack;
                    table2.Range.Font.Name = "Abadi MT Condensed Light";
                    //table2.Range.Columns.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth050pt;

                    table2.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table2.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth050pt;
                    table2.Borders.InsideLineWidth = 0;
                    table2.Borders.InsideColorIndex = Word.WdColorIndex.wdBlue;

                    //for (int i = 2; i <= table2.Rows.Count; i++)
                    //{
                    //    table2.Rows[i].Range.Font.Size = 8;                                         
                    //    table2.Rows[i].Range.Font.Name = "Abadi MT Condensed Light";
                    //}

                    table2.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
                    #endregion



                    // GUARDAR EN EL MISMO PROYECTO
                    string phat2 = Server.MapPath("~/Reportes/CONTRATO_NRO_.docx");
                    //string phat2 = System.Web.HttpContext.Current.Server.MapPath("~/bapsoft/PIE/intranet2015/Reportes/CONTRATO_NRO_.docx");
                    if (((doc != null)))
                    {
                        var _with1 = doc;
                        //_with1.SaveAs(@"C:\ReporteWeb\" + xdoc.ToString() + "" + ".docx");
                        _with1.SaveAs(phat2);
                        _with1.Close();
                    }
                    oWord.Quit();
                    oWord = null;


                    //HttpFileCollection files = Request.Files;
                    //foreach (string fileTagName in files)
                    //{
                    //    HttpPostedFile file = Request.Files[fileTagName];
                    //    if (file.ContentLength > 0)
                    //    {
                    //        // Due to the limit of the max for a int type, the largest file can be
                    //        // uploaded is 2147483647, which is very large anyway.

                    //        tb_cxc_proformafiles BE = new tb_cxc_proformafiles();
                    //        tb_cxc_proformafilesBL BL = new tb_cxc_proformafilesBL();

                    //        int size = file.ContentLength;
                    //        BE.size = file.ContentLength;
                    //        string nombre = file.FileName;
                    //        BE.name = file.FileName;
                    //        int position = nombre.LastIndexOf("\\");
                    //        nombre = nombre.Substring(position + 1);
                    //        BE.contenttype = file.ContentType;
                    //        byte[] fileData = new byte[size];
                    //        file.InputStream.Read(fileData, 0, size);

                    //        BL.Insert("02",BE,fileData);
                    //    }
                    //}


                    //impresionArchivo(xdoc);

                }
            }
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }
    }

    void impresionArchivo(String xdocs)
    {
        try
        {
            String path = @"C:\ReporteWeb\" + xdocs.ToString() + "" + ".docx";
            System.IO.FileInfo toDownload = new System.IO.FileInfo(path);

            if (toDownload.Exists)
            {
                Response.ClearContent();
                Response.ClearHeaders();

                Response.AddHeader("Content-Disposition", "attachment; filename=" + xdocs);
                Response.ContentType = "application/octet-stream";

                Response.WriteFile(path);
                Response.Flush();
                //Response.Close();
                Response.End();
               // HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception)
        {            
            throw;
        }        
    }

    // METODOS DE AYUDA PARA PODER GENERAR MI ARCHIVO WORD
    public Word.Document CreateTableWord(Word.Application app, DataTable dt)
    {

        // Finalidad: Crear una tabla en un documento de Word con los datos
        //            existentes en un objeto DataTable.
        // Entradas:
        //     app:     Word.Application. Referencia al objeto Application que 
        //                                se utilizará para crear el documento.
        //
        //     dt:      DataTable. Referencia al objeto DataTable que contiene
        //                         los datos.
        // Resultados:
        //     Word.Document: Referencia al documento Word creado. Si se
        //                    ha producido una excepción, la función 
        //                    devolverá el valor Nothing.
        //*******************************************************************

        // Si alguno de los parámetros no se encuentra
        // referenciado, abandonamos la función.
        //
        if (((app == null) || (dt == null)))
            return null;

        Word.Document doc = null;

        try
        {
            // Número de columnas que tendrá la tabla.
            //
            Int32 colsNumbers = dt.Columns.Count;

            // Número de filas que tendrá la tabla, que será una
            // fila más que las existentes en el objeto DataTable,
            // porque la primera fila la utilizaremos para escribir
            // el nombre de las columnas.
            // 
            Int32 rowsNumbers = dt.Rows.Count + 1;

            // Referenciamos el documento de Word, añadiendo un
            // nuevo documento a la colección Documents.
            //
            doc = app.Documents.Add();

            // Definimos el área del documento de Word, donde crearemos
            // la tabla. Al no existir todavía carácter alguno, tanto la
            // posición de los caracteres inicial y final será cero.
            //
            Word.Range range = doc.Range(0, 0);
            Word.Table table = doc.Tables.Add(range, rowsNumbers, colsNumbers);

            // Insertamos los encabezados de columna de la tabla, que
            // se corresponderán con los nombres de los campos.
            //
            for (Int32 col = 1; col <= colsNumbers; col++)
            {
                Word.Cell cell = table.Rows[1].Cells[col];
                cell.Range.Text = dt.Columns[col - 1].ColumnName;
            }

            // Insertamos las filas en la tabla, comenzando por la
            // fila número 2, ya que la primera fila está ocupada
            // por el nombre de las columnas.
            //
            for (Int32 row = 2; row <= table.Rows.Count; row++)
            {
                Int32 c = 0;
                foreach (Word.Cell cell in table.Rows[row].Cells)
                {
                    // Insertamos el valor de las celdas.
                    cell.Range.Text = dt.Rows[row - 2].ItemArray[c].ToString();
                    c += 1;
                }
            }

            // Formateamos la tabla para que se ajuste a su contenido.
            //
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);

            // Devolvemos la referencia al documento que se ha creado.
            //
            return doc;

        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);
            ClientMessage(ex.Message);
            if (((doc != null)))
            {
                // Indicamos que el documento ya ha sido guardado, 
                // y lo cerramos
                //
                doc.Saved = true;
                doc.Close();
            }
            return null;
        }
    }

    private void dd()
    {
        object objMiss = System.Reflection.Missing.Value;
        object objEndOfDocFlag = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
        //Start Word and create a new document.  
        Word._Application oWord;
        Word._Document doc;
        oWord = new Word.Application();
        oWord.Visible = true;
        doc = oWord.Documents.Add(ref objMiss, ref objMiss, ref objMiss, ref objMiss);

        //Insert a paragraph at the end of the document.  
        Word.Paragraph objPara2; //define paragraph object  
        object oRng = doc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of the page  
        objPara2 = doc.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document  
        objPara2.Range.Text = "Test Table Caption"; //add some text in paragraph  
        objPara2.Format.SpaceAfter = 10; //define some style  
        objPara2.Range.InsertParagraphAfter(); //insert paragraph  

        //Insert a 2 x 2 table, (table with 2 row and 2 column)  
        Word.Table Table; //create table object  
        Word.Range range = doc.Bookmarks.get_Item(ref objEndOfDocFlag).Range; //go to end of document  
        Table = doc.Tables.Add(range, 2, 2, ref objMiss, ref objMiss); //add table object in word document  
        Table.Range.ParagraphFormat.SpaceAfter = 6;
        int iRow, iCols;
        string strText;
        for (iRow = 1; iRow <= 2; iRow++)
            for (iCols = 1; iCols <= 2; iCols++)
            {
                strText = "row:" + iRow + "col:" + iCols;
                Table.Cell(iRow, iCols).Range.Text = strText; //add some text to cell  
            }
        Table.Rows[1].Range.Font.Bold = 1; //make first row of table BOLD  
        Table.Columns[1].Width = oWord.InchesToPoints(3); //increase first column width  

        //Add some text after table  
        range = doc.Bookmarks.get_Item(ref objEndOfDocFlag).Range;
        range.InsertParagraphAfter(); //put enter in document  
        range.InsertAfter("THIS IS THE SIMPLE WORD DEMO : THANKS YOU.");
        object szPath = "test.docx";
        doc.SaveAs(ref szPath);
    }

    private void ReplaceBookmarkText(Word.Document doc, string bookmarkName, string text)
    {
        if (doc.Bookmarks.Exists(bookmarkName))
        {
            Object name = bookmarkName;
            Microsoft.Office.Interop.Word.Range range = doc.Bookmarks.get_Item(ref name).Range;
            range.Text = text;
            object newRange = range;
            doc.Bookmarks.Add(bookmarkName, ref newRange);
        }
    }

    protected void btn_evaluacion_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Frm_evaluacion.aspx");
    }
    protected void btn_Imprimir2_Click(object sender, ImageClickEventArgs e)
    {
        Session["xtipdoc"] = txt_tipdoc2.Text.ToUpper();
        Session["xserdoc"] = txt_serdoc2.Text;
        Session["xnumdoc"] = txt_numdoc2.Text;

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
        reporte_pdf2(pagina);    
    }

    private void reporte_pdf2(string pagina)
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
            Response.Redirect("ErrorPage/Frm_PaginaError_405.aspx");
        }

    }

    protected void lbcancel_Click(object sender, EventArgs e)
    {

        Session["ssModo"] = "N";
        Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("03", false, "fondo_bloqueo", "_disabled");
        LimpiarDocumento();
        Lock_or_Unlock_Boton("N", true, "");
        Lock_or_Unlock_Boton("G", false, "_disabled");
        Lock_or_Unlock_Boton("C", false, "_disabled");
        Lock_or_Unlock_Boton("D", false, "_disabled");
        Lock_or_Unlock_Boton("I", false, "_disabled");
        
    }
    
    protected void btn_Cancelar3_Click(object sender, EventArgs e)
    {
        Session["ssModo"] = "N";
        Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("03", false, "fondo_bloqueo", "_disabled");
        LimpiarDocumento();
        Lock_or_Unlock_Boton("N", true, "");
        Lock_or_Unlock_Boton("G", false, "_disabled");
        Lock_or_Unlock_Boton("C", false, "_disabled");
        Lock_or_Unlock_Boton("D", false, "_disabled");
        Lock_or_Unlock_Boton("I", false, "_disabled");
    }

    protected void btn_Cancelar2_Click(object sender, EventArgs e)
    {
        Session["ssModo"] = "N";
        Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("02", false, "fondo_bloqueo", "_disabled");
        Lock_or_UnLock_Paneles("03", false, "fondo_bloqueo", "_disabled");
        LimpiarDocumento();
        Lock_or_Unlock_Boton("N", true, "");
        Lock_or_Unlock_Boton("G", false, "_disabled");
        Lock_or_Unlock_Boton("C", false, "_disabled");
        Lock_or_Unlock_Boton("D", false, "_disabled");
        Lock_or_Unlock_Boton("I", false, "_disabled");
    }

    protected void LkBSearch_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Comercial/Listados/Lst_PedidosPend.aspx");
        ValIngreso();
    }

    protected void LkBNew_Click(object sender, EventArgs e)
    {
        Session["ssModo"] = "NEW";
        Accion(Session["ssModo"].ToString());
        Response.Redirect("~/Comercial/Frm_Proformas.aspx");
    }

    protected void LkBEdit_Click(object sender, EventArgs e)
    {
        //Session["ssModo"] = "NEW";
        //Accion(Session["ssModo"].ToString());
        Response.Redirect("~/Comercial/Frm_Proformas.aspx");
    }

    protected void LKBSiguiente_Click(object sender, EventArgs e)
    {
            Response.Redirect("~/Comercial/Frm_Proformas.aspx#download");
    }

    protected void chk_Bloquear_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_Bloquear.Checked == false)
        {
            btn_add.CssClass = "btn btn-default";
            btn_add.Enabled = false;
            //txt_articidold.Text = "";
            //txt_marcaname.Text = "";
            //txt_articname.Text = "";
            //cmb_colorid.SelectedIndex = -1;
            //cmb_tallaid.SelectedIndex = -1;
            //txt_precventa_cre_menor.Text = "";
            spe_cantidad.Text = "1";

        }
        else
        {
            //cmb_colorid.SelectedIndex = -1;
            //cmb_tallaid.SelectedIndex = -1;
            spe_cantidad.Text = "1";
            btn_add.CssClass = "btn btn-success";
            btn_add.Enabled = true;
            txt_articidold.Focus();
        }
        //Response.Redirect("~/Comercial/Frm_Proformas.aspx#lista");
        //Response.Redirect("#lista");
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        data_gridArticulo();       
//        cargar_grillaProd(txt_articidold.Text);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "searchPopclick();", true);
    }

    protected void cmb_tallaid_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboEvalua();
        validastock();
    }

   void comboEvalua() {
       
       spe_cantidad.CssClass = "form-control btn btn-default";
       msgCant.Visible = false;
       HdFtalla.Value = cmb_tallaid.SelectedValue;
       string articid = Session["bd_articid"].ToString();      
       string color = cmb_colorid.SelectedValue;
       string talla = HdFtalla.Value.ToString().Substring(5, 2);
       stkDisponible(talla.ToString(), color.ToString());

       if (griddetalle.Rows.Count > 0)
       {
           Double cant = 0;
           foreach (GridViewRow rows in griddetalle.Rows)
           {
               if (txt_articidold.Text == rows.Cells[1].Text
                   && cmb_colorid.Text == rows.Cells[5].Text
                   && cmb_tallaid.SelectedItem.ToString() == rows.Cells[8].Text
                   )
               {
                   cant = cant + Double.Parse(rows.Cells[9].Text);

               }
           }
           txtStkdisp.Text = (Double.Parse(txtStkdisp.Text) - cant).ToString();

       }
       else
       {
           stkDisponible(talla.ToString(), color.ToString());
       }
       validastock();
     
    }
   
   public void stkDisponible(string talla, string color)
    {
        string disponible = "";

        DataTable Tablastkdisp;
        tb_me_stockdiariocabBL BL1 = new tb_me_stockdiariocabBL();
        tb_me_stockdiariocab BE1 = new tb_me_stockdiariocab();

        BE1.articid = HdFarticid.Value.ToString();
        BE1.coltall = Equivalencias.Right(cmb_tallaid.SelectedValue.ToString(),2); //talla.ToString();
        BE1.colorid = color.ToString();
        Tablastkdisp = BL1.GetAllStkDisp(Session["ssEmpresaID"].ToString(), BE1).Tables[0];

        if (Tablastkdisp.Rows.Count > 0)
        {
            disponible = Tablastkdisp.Rows[0]["stockdisp"].ToString().Trim();
        }
        else
        {
            disponible = "0";
        }

        txtStkdisp.Text = disponible.ToString();
        validastock();
    }

   void validastock() {
       //comboEvalua();


       if (Double.Parse(txtStkdisp.Text)>0)
	    {
            txtStkdisp.CssClass = "form-control btn btn-success";
            btn_add.Enabled=true;
            btn_add.CssClass = "btn btn-success";            
        }
       else
       {
           txtStkdisp.CssClass = "form-control btn btn-danger";
           btn_add.Enabled = false;
           btn_add.CssClass = "btn btn-default";
       }
       
   }


   protected void cmb_colorid_SelectedIndexChanged(object sender, EventArgs e)
   {
       CargarComboArticuloTallas(Session["bd_tallaid"].ToString());       
       comboEvalua();
   }
   //protected void LkBEdit_Click(object sender, EventArgs e)
   protected void LkBStaus11_Click(object sender, EventArgs e)
   {
       //ValIngreso();
       AproStatus = "11";
       btn_grabar_Click();

   }
   //protected void LkBDel_Click(object sender, EventArgs e)
   protected void LkBStaus12_Click(object sender, EventArgs e)
   {
       //ValIngreso();
       AproStatus = "12";
       btn_grabar_Click();
   }

  

   /////////////////////////////////////////////////////

   //protected void griddetalle_RowDataBound(object sender, GridViewRowEventArgs e)
   //{
   //    string rowstate = e.Row.RowState.ToString();
   //    rowstate = rowstate.Trim();

   //    if ((rowstate == "Edit") || (rowstate == "Alternate, Edit"))
   //    {
   //        TextBox txt3 = (TextBox)e.Row.FindControl("cantidad");
   //        txt3.Enabled = true;
   //        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#d6e9c6");
   //    }
   //}
    
   //protected void griddetalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
   //{
   //    this.griddetalle.EditIndex = -1;
   //    BindData1();
   //}

   //protected void griddetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
   //{
   //    TablaDetalleStk = (DataTable)Session["TablaDetalle"];
   //    TablaDetalleStk.Rows[e.RowIndex].Delete();
   //    griddetalle.DataSource = TablaDetalleStk;
   //    griddetalle.DataBind();

   //    Int32 ndocs = (Convert.ToInt32(spe_numdocs.Text) - 1);
   //    spe_numdocs.Text = ndocs.ToString();

   //    Calculos_CronogramaPagos();
   //}

   //protected void griddetalle_RowEditing(object sender, GridViewEditEventArgs e)
   //{
   //    this.griddetalle.EditIndex = e.NewEditIndex;
   //    ((BoundField)griddetalle.Columns[0]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[1]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[2]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[3]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[4]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[5]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[6]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[7]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[8]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[9]).ReadOnly = false;
   //    ((BoundField)griddetalle.Columns[10]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[11]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[12]).ReadOnly = true;
   //    ((BoundField)griddetalle.Columns[13]).ReadOnly = true;
       
   //    BindData1();
   //}

   //protected void griddetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
   //{
   //    //Recuperar la tabla del objeto de sesión.
   //    TablaDetalleStk = (DataTable)Session["TablaDetalle"];

   //    ////Actualice los valores.
   //    GridViewRow row = griddetalle.Rows[e.RowIndex];
   //    TablaDetalleStk.Rows[row.DataItemIndex]["cantidad"] = (row.FindControl("cantidad") as TextBox).Text;
   //    //Restablecer el índice de edición.
   //    gridcronpagos.EditIndex = -1;

   //    BindData1();
   //}

   //private void BindData1()
   //{
   //    griddetalle.DataSource = Session["TablaDetalle"];
   //    griddetalle.DataBind();
   //}




}