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

public partial class Login01 : System.Web.UI.Page
{
    Genericas mifunc = new Genericas();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            foto.Attributes.Add("onError", "img_default()");
            get_cargarComboEmpresas();
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

    private void MensajeScript(String Mensaje)
    {
        //Declaramos un StringBuilder para almacenar el alert que queremos mostrar
        StringBuilder sbMensaje = new StringBuilder();
        //Aperturamos la escritura de Javascript
        sbMensaje.Append("<script type='text/javascript'>");
        //Le indicamos al alert que mensaje va mostrar
        sbMensaje.AppendFormat("alert('{0}');", Mensaje.ToString());
        //Cerramos el Script
        sbMensaje.Append("</script>");
        //Registramos el Script Escrito en el StringBuilder
        ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());
    }

    private void get_cargarComboEmpresas()
    {
        empresasWebBL empresaBL = new empresasWebBL();
        tb_empresa tb_empresa = new tb_empresa();
        DataTable dt = new DataTable();

        try
        {
            dt = empresaBL.GetAll(tb_empresa).Tables[0];
            cboEmpresalogueo.DataSource = dt;
            cboEmpresalogueo.DataValueField = "empresaid";
            cboEmpresalogueo.DataTextField = "empresaname";
            cboEmpresalogueo.DataBind();
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }

    private void abrir_perfiles()
    {        
        get_cargarComboDominio();
        fechsis.Text = DateTime.Now.ToString().Substring(0, 10);    
    }

    private void get_cargarComboDominio()
    {
        sys_dominioWebBL BL = new sys_dominioWebBL();
        tb_sys_dominio BE = new tb_sys_dominio();
        DataTable dt = new DataTable();

        try
        {
            dt = BL.GetAllDominioPorUsuario(Session["ssEmpresaID"].ToString(), Session["ssUsuar"].ToString().Trim()).Tables[0];
            cbo_dominio.DataSource = dt;
            cbo_dominio.DataValueField = "dominioid";
            cbo_dominio.DataTextField = "dominioname";
            cbo_dominio.DataBind();
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }

        get_cbo_modulo();
    }

    private void get_cbo_modulo()
    {
        sys_dominioWebBL BL = new sys_dominioWebBL();
        tb_sys_dominio BE = new tb_sys_dominio();
        DataTable dt = new DataTable();

        try
        {
            dt = BL.GetAllDominioModuloPorUsuario(Session["ssEmpresaID"].ToString(), Session["ssUsuar"].ToString().Trim(), cbo_dominio.SelectedValue).Tables[0];
            cbo_modulo.DataSource = dt;
            cbo_modulo.DataValueField = "moduloid";
            cbo_modulo.DataTextField = "moduloname";
            cbo_modulo.DataBind();

        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }

        get_dominio_modulo_local(cbo_dominio.SelectedValue, cbo_modulo.SelectedValue);
    }

    private void get_dominio_modulo_local(string dominioid, string moduloid)
    {
        usuariomodulolocalWebBL BL = new usuariomodulolocalWebBL();
        tb_usuariomodulolocal BE = new tb_usuariomodulolocal();
        DataTable dt = new DataTable();
        BE.usuar = Session["ssUsuar"].ToString();
        BE.dominioid = dominioid;
        BE.moduloid = moduloid;

        try
        {
            dt = BL.GetAll3(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            cbo_local.DataSource = dt;
            cbo_local.DataValueField = "local";
            cbo_local.DataTextField = "localname";
            cbo_local.DataBind();

            //get_constantesGen(cbo_dominio.SelectedValue, cbo_modulo.SelectedValue, cbo_local.SelectedValue);
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }

    private void get_cargafoto()
    {
        try
        {
            usuariosWebBL usuariosBL = new usuariosWebBL();
            tb_usuarios tb_usuarios = new tb_usuarios();
            DataTable dt = new DataTable();
            tb_usuarios.usuar = Session["ssUsuar"].ToString();
            dt = usuariosBL.GetAll(Session["ssEmpresaID"].ToString(), tb_usuarios).Tables[0];
            usuario.Text = dt.Rows[0]["nombr"].ToString().PadRight(20, ' ').Substring(0, 20);

            if (dt.Rows[0]["foto"].ToString().Length != 0)
            {
                foto.Visible = true;
                //foto.ImageUrl = "~/Photos/emp_usuario/" + dt.Rows[0]["foto"].ToString() + ".jpg";
                foto.ImageUrl = "~/Photos/usuarios_sys/" + dt.Rows[0]["foto2"].ToString();
            }
            else
            {
                foto.Visible = false;
                foto.ImageUrl = "";
            }
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }

    protected void cbo_dominio_SelectedIndexChanged(object sender, EventArgs e)
    {
        get_cbo_modulo();
    }

    protected void cbo_modulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        get_dominio_modulo_local(cbo_dominio.SelectedValue, cbo_modulo.SelectedValue);
    }

    protected void editBox_OK_Click(object sender, EventArgs e)
    {
        try
        {
            // fecha del sistema
            Session["ssfechsis"] = fechsis.Text.Trim();

            //Crea la session modulo
            Session["ssDominioid"] = cbo_dominio.SelectedValue.ToString();

            //Crea la session tipo de almacen
            Session["ssModuloid"] = cbo_modulo.SelectedValue.ToString();

            //crea la sesion local de tipo de lamacen 
            Session["ssLocal"] = cbo_local.SelectedValue.ToString();

            //crea la sesion Perfil del Usuario para presentar menu
            Session["ssPerfil"] = Session["ssDominioid"].ToString() + Session["ssModuloid"].ToString();
            //string data = Session["ssPerfil"].ToString();

            //redirecciona a panel principal
            Response.Redirect("index.aspx");

        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }

    protected void cboEmpresalogueo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtusuario.Text = "";
            txtusuario.Focus();

            empresasWebBL BL = new empresasWebBL();
            tb_empresa BE = new tb_empresa();

            DataTable dt2 = new DataTable();

            BE.empresaid = cboEmpresalogueo.SelectedValue;
            dt2 = BL.GetAll(BE).Tables[0];
            Session["ssEmpresaID"] = dt2.Rows[0]["empresaid"];
            Session["ssEmpresaName"] = dt2.Rows[0]["empresaname"];
            Session["ssEmpresaRuc"] = dt2.Rows[0]["empresaruc"];

            Session["ssGerenteGeneral"] = dt2.Rows[0]["gerentegeneral"];
            Session["ssGerenteNrodni"] = dt2.Rows[0]["nrodni"];
            Session["ssPartElectro"] = dt2.Rows[0]["partidaelectronica"];


            if (dt2.Rows[0]["foto"].ToString().Trim().Length != 0)
            {
                Session["ssLogo"] = dt2.Rows[0]["foto"];
            }
            else
            {
                Session["ssLogo"] = "nologoempresa.png";
            }
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }
    
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        usuariosWebBL usuariosBL = new usuariosWebBL();
        tb_usuarios tb_usuarios = new tb_usuarios();

        DataTable dt = new DataTable();
        String xClave = null;
        Boolean xadmin = false;
        tb_usuarios.usuar = txtusuario.Text.Trim().ToLower();

        try
        {
            dt = usuariosBL.GetAll(cboEmpresalogueo.SelectedValue, tb_usuarios).Tables[0];
            xClave = Convert.ToString(dt.Rows[0]["CLAVE"]);
            xadmin = Convert.ToBoolean(dt.Rows[0]["admin"]);

            txtpassword.Text = mifunc.GetMD5(txtpassword.Text.ToLower()).Substring(0, 10);
            if (txtpassword.Text.ToUpper() == xClave)
            {
                if (xadmin)
                {
                    cboEmpresalogueo_SelectedIndexChanged(sender, e);

                    Session["ssUsuar"] = Convert.ToString(dt.Rows[0]["usuar"]);
                    Session["ssDominoid"] = "00";
                    Session["ssModuloid"] = "00";
                    Session["ssPerfil"] = "000000";
                    Response.Redirect("main.aspx");
                    return;
                }
                else
                {
                    cboEmpresalogueo_SelectedIndexChanged(sender, e);
                    Session["ssUsuar"] = Convert.ToString(dt.Rows[0]["usuar"]);
                    ModalPopupExtender1.Show();
                    abrir_perfiles();
                    get_cargafoto();
                    return;
                }
            }
            else
            {
                //ClientMessage("Usuario o Clave Incorrecto?");
                MensajeScript("Usuario o Clave Incorrecto?");
            }
        }
        catch (Exception ex)
        {
            //ClientMessage(ex.Message);
            MensajeScript(ex.Message);
        }
    }

}