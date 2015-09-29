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


public partial class login : System.Web.UI.Page
{
    Genericas mifunc = new Genericas();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
             
        //}
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        usuariosWebBL usuariosBL = new usuariosWebBL();
        tb_usuarios tb_usuarios = new tb_usuarios();

        DataTable dt = new DataTable();
        String xClave = null;
        Boolean xadmin = false;
        tb_usuarios.usuar = txtusuario.Text.Trim().ToLower();

        //try
        //{

            dt = usuariosBL.GetAll("99", tb_usuarios).Tables[0];
            xClave = Convert.ToString(dt.Rows[0]["CLAVE"]);
            xadmin = Convert.ToBoolean(dt.Rows[0]["admin"]);

            txtpassword.Text = mifunc.GetMD5(txtpassword.Text.ToLower()).Substring(0, 10);
            if (txtpassword.Text.ToUpper() == xClave)
            {
                if (xadmin)
                {
                    //cboEmpresalogueo_SelectedIndexChanged(sender, e);
                    Session["ssUsuar"] = Convert.ToString(dt.Rows[0]["usuar"]);
                    Session["ssDominoid"] = "00";
                    Session["ssModuloid"] = "00";
                    Session["ssPerfil"] = "000000";
                    Response.Redirect("main.aspx");
                    return;
                }
                else
                {
                    Session["ssUsuar"] = Convert.ToString(dt.Rows[0]["usuar"]);
                    Datos_Empresa();
                    abrir_perfiles();
                    return;
                }
            }
            else
            {                
                MensajeScript("Usuario o Clave Incorrecto?");
            }

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    void Datos_Empresa()
    {
        empresasWebBL BL = new empresasWebBL();
        tb_empresa BE = new tb_empresa();
        DataTable dt2 = new DataTable();

        BE.empresaid = "99";
        dt2 = BL.GetAll(BE).Tables[0];
        Session["ssEmpresaID"] = dt2.Rows[0]["empresaid"];
        Session["ssEmpresaName"] = dt2.Rows[0]["empresaname"];
        Session["ssEmpresaRuc"] = dt2.Rows[0]["empresaruc"];

        Session["ssGerenteGeneral"] = dt2.Rows[0]["gerentegeneral"];
        Session["ssGerenteNrodni"] = dt2.Rows[0]["nrodni"];
        Session["ssPartElectro"] = dt2.Rows[0]["partidaelectronica"];
    }



    void abrir_perfiles()
    {
        //Crea la session modulo
        Session["ssDominioid"] = "60";
        //Crea la session tipo de almacen
        Session["ssModuloid"] = "0210";
        //crea la sesion local de tipo de lamacen 
        Session["ssLocal"] = "001";

        usuariosperfilBL BL = new usuariosperfilBL();
        tb_usuariosperfil BE = new tb_usuariosperfil();
        DataTable dt = new DataTable();
        BE.usuar = Session["ssUsuar"].ToString().Trim();
        dt = BL.GetAll("02", BE).Tables[0];

        //crea la sesion Perfil del Usuario para presentar menu
        Session["ssPerfil"] = dt.Rows[0]["idper"].ToString(); //Session["ssDominioid"].ToString() + Session["ssModuloid"].ToString();
        //string data = Session["ssPerfil"].ToString();
        Session["ssCanalVentaId"] = "102";
        //redirecciona a panel principal
        Response.Redirect("index.aspx",false);
    }




}