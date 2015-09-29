using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using bapFunciones;
using LayerBusinessEntities;
using LayerBusinessLogic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using AjaxControlToolkit;

public partial class index : System.Web.UI.Page
{
    //funcion generica
    Genericas fungen = new Genericas();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            //VALIDACION PRINCIPAL PARA TODO FORMULARIO
            Session_usuario();
            lblusuario.Text = Session["ssUsuar"].ToString();
            
            foto2.ImageUrl = "~/Photos/usuarios_sys/"+lblusuario.Text.Trim()+".jpg";

            /*Session["ssEmpresaID"] = "02";
            Session["ssUsuar"] = "gtarazona";
            Session["ssDominioid"] = "60";
            Session["ssModuloid"] = "0320";
            Session["ssPerfil"] = "600320000";*/

            try
            {
                //perfil de modulo
                sys_moduloWebBL moduloBL = new sys_moduloWebBL();
                tb_sys_modulo tb_modulo = new tb_sys_modulo();
                DataTable dtmoduloid = new DataTable();

                string dominioid = Convert.ToString(Session["ssDominioid"]);
                string moduloid = Convert.ToString(Session["ssModuloid"]);

                if (dominioid != "00")
                {
                    if (moduloid == "0000")
                    {
                        modulo_emp.Text = "NINGUNO";

                    }
                    else
                    {
                        dtmoduloid = moduloBL.GetOne(Session["ssEmpresaID"].ToString(), dominioid, moduloid).Tables[0];
                        modulo_emp.Text = fungen.RemoveAccentsWithRegEx(dtmoduloid.Rows[0]["moduloname"].ToString());
                    }
                }
                else
                {
                    modulo_emp.Text = "NINGUNO";
                }

                //perfil de usuario
                usuariosWebBL usuariosBL = new usuariosWebBL();
                tb_usuarios tb_usuarios = new tb_usuarios();
                DataTable dtMenuItems = new DataTable();
                DataTable dtMenuItems02 = new DataTable();
                string COD_USU = Convert.ToString(Session["ssUsuar"]);

                dtMenuItems = usuariosBL.GenerarMenuXperfil(Session["ssEmpresaID"].ToString(), COD_USU, Session["ssPerfil"].ToString()).Tables[0];
                dtMenuItems02 = usuariosBL.GenerarMenuXperfil_child(Session["ssEmpresaID"].ToString(), COD_USU, Session["ssPerfil"].ToString()).Tables[0];

                AccordionPane p;
                Panel pnlHeader;
                TreeView tree;
                TreeNode mnuMenuItem;
                Int32 i = 0;
                String xgrupo = "", xpadid = "";

                foreach (DataRow drMenuItem in dtMenuItems.Rows)
                {
                    i++;
                    p = new AccordionPane();
                    p.ID = "Pane" + i;

                    if (drMenuItem["posic"].ToString() == "0")
                    {
                        pnlHeader = new Panel();
                        HyperLink hlHeader = new HyperLink();
                        hlHeader.NavigateUrl = "#";
                        hlHeader.Text = drMenuItem["descr"].ToString();
                        pnlHeader.Controls.Add(hlHeader);
                        p.HeaderContainer.Controls.Add(pnlHeader);
                        xgrupo = drMenuItem["grupo"].ToString();
                        xpadid = drMenuItem["padid"].ToString();
                    }
                    else
                    {
                        xgrupo = "";
                    }

                    tree = new TreeView();
                    tree.ID = "tree" + i;
                    foreach (DataRow drMenuItem02 in dtMenuItems02.Rows)
                    {
                        string aaa = drMenuItem02["padid"].ToString();
                        string aa = drMenuItem02["grupo"].ToString();
                        if (drMenuItem02["grupo"].ToString() == xgrupo && drMenuItem02["padid"].ToString() == xpadid)
                        {
                            mnuMenuItem = new TreeNode();
                            mnuMenuItem.Value = drMenuItem02["menid"].ToString();
                            mnuMenuItem.Text = drMenuItem02["descr"].ToString();
                            mnuMenuItem.ImageUrl = drMenuItem02["Icono"].ToString();
                            mnuMenuItem.Target = "frameMain";

                            if (drMenuItem02["nivelacc"].ToString().Trim().Length == 0)
                            {
                                mnuMenuItem.NavigateUrl = drMenuItem02["pgurl"].ToString();
                            }
                            else
                            {
                                mnuMenuItem.NavigateUrl = drMenuItem02["pgurl"].ToString() + "?idnivel=" + drMenuItem02["nivelacc"].ToString();
                            }

                            tree.Nodes.Add(mnuMenuItem);
                            //TreeViewImageSet imagen = new TreeViewImageSet();
                            //imagen = TreeViewImageSet.XPFileExplorer;
                            //tree.ImageSet = imagen;
                            tree.RootNodeStyle.CssClass = "roottreview";
                            tree.RootNodeStyle.ImageUrl = "lib/img/folder.gif";
                            tree.ParentNodeStyle.CssClass = "roottreview";
                            tree.ParentNodeStyle.ImageUrl = "lib/img/folder.gif";
                            tree.NodeStyle.CssClass = "nodetreview";
                            tree.NodeStyle.ImageUrl = "lib/img/documento.gif";

                            //hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                            AddMenuItem2(ref mnuMenuItem, dtMenuItems02, xgrupo);
                        }
                    }
                    if (drMenuItem["posic"].ToString() == "0")
                    {
                        p.ContentContainer.Controls.Add(tree);
                        p.ContentCssClass = "accordioncontent";
                        accmenuperfil.Panes.Add(p);

                        accmenuperfil.Panes.Add(p);
                    }
                }
            }
            catch
            {
                //Response.Redirect("~/Login02.aspx");
            }
            try
            {
                get_TipoAlmac_local(Session["ssDominioid"].ToString(), Session["ssModuloid"].ToString());
            }
            catch
            {
                //Response.Redirect("~/Login01.aspx");
                Response.Redirect("~/Login.aspx",false);
            }
        }
    }

    #region Session
    private void Session_usuario()
    {
        if (Session["ssUsuar"] == null || Session["ssEmpresaID"] == null)
        {
            //Response.Redirect("~/login.aspx");
            //Session.Remove(nombre);
            //Session.Add(nombre, objeto);

            Literal li = new Literal();
            StringBuilder sbMensaje = new StringBuilder();

            sbMensaje.Append("<script type='text/javascript'>");
            //sbMensaje.Append("window.parent.location.href='../login01.aspx';");
            sbMensaje.Append("window.parent.location.href='../login.aspx';");
            sbMensaje.Append("</script>");

            li.Text = sbMensaje.ToString();
            Page.Controls.Add(li);

            //ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = '../login.aspx'; </script>");
        }
    }
    #endregion

    #region *** Creación de Sitemap
    #endregion

    private void get_TipoAlmac_local(string dominioid, string moduloid)
    {
        usuariomodulolocalWebBL BL = new usuariomodulolocalWebBL();
        tb_usuariomodulolocal BE = new tb_usuariomodulolocal();
        BE.usuar = Session["ssUsuar"].ToString();
        BE.dominioid = dominioid;
        BE.moduloid = moduloid;

        try
        {
            //cbo_local.DataSource = BL.GetAll3(Session["ssEmpresaID"].ToString(), BE);
            //cbo_local.DataValueField = "local";
            //cbo_local.DataTextField = "localname";
            //cbo_local.DataBind();

            ////**session local
            //cbo_local.SelectedValue = Session["ssLocal"].ToString();
        }
        catch (Exception ex)
        {
            // ClientMessage(ex.Message);
        }

    }

    private void AddMenuItem2(ref TreeNode mnuMenuItem, DataTable dtMenuItems, String xgrupo)
    {
        //recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
        //del menuitem dado pasado como parametro ByRef.
        foreach (DataRow drMenuItem in dtMenuItems.Rows)
        {
            if (drMenuItem["grupo"].ToString() == xgrupo)
            {
                if (drMenuItem["padid"].ToString().Equals(mnuMenuItem.Value) && !drMenuItem["menid"].Equals(drMenuItem["padid"]))
                {
                    TreeNode mnuNewMenuItem = new TreeNode();
                    mnuNewMenuItem.Value = drMenuItem["menid"].ToString();
                    mnuNewMenuItem.Text = drMenuItem["descr"].ToString();
                    mnuNewMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                    mnuNewMenuItem.Target = "frameMain";
                    if (drMenuItem["nivelacc"].ToString().Trim().Length == 0)
                    {
                        mnuNewMenuItem.NavigateUrl = drMenuItem["pgurl"].ToString();
                    }
                    else
                    {
                        mnuNewMenuItem.NavigateUrl = drMenuItem["pgurl"].ToString() + "?idnivel=" + drMenuItem["nivelacc"].ToString();
                    }

                    //Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                    mnuMenuItem.ChildNodes.Add(mnuNewMenuItem);

                    //llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                    AddMenuItem2(ref mnuNewMenuItem, dtMenuItems, xgrupo);
                    
                }
            }
        }
    }

    private void AddMenuItem(ref TreeNode mnuMenuItem, System.Data.DataTable dtMenuItems)
    {
        //recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
        //del menuitem dado pasado como parametro ByRef.
        foreach (System.Data.DataRow drMenuItem in dtMenuItems.Rows)
        {
            if (drMenuItem["padid"].ToString().Equals(mnuMenuItem.Value) && !drMenuItem["menid"].Equals(drMenuItem["padid"]))
            {
                TreeNode mnuNewMenuItem = new TreeNode();
                mnuNewMenuItem.Value = drMenuItem["menid"].ToString();
                mnuNewMenuItem.Text = drMenuItem["descr"].ToString();
                mnuNewMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                mnuNewMenuItem.Target = "frameMain";
                if (drMenuItem["pgurl"].ToString() != "main.aspx")
                {
                    mnuNewMenuItem.NavigateUrl = drMenuItem["pgurl"].ToString();
                }

                //Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                mnuMenuItem.ChildNodes.Add(mnuNewMenuItem);

                //llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItem(ref mnuNewMenuItem, dtMenuItems);          
            }
        }
    }


    protected void mnu_cerrartodo_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (mnu_cerrartodo.SelectedItem.Value == "Logout")
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            //Response.Redirect("~/login01.aspx");
            Response.Redirect("~/login.aspx");
        }
    }

}