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

public partial class tb_rrhh_wf_rrhh_listaasistencia_all : System.Web.UI.Page
{
    Genericas fungen = new Genericas();
    SimpleAES funcript = new SimpleAES();
    static string filtro; //filtro de busqueda
    static string clave; //activa la clave dependiendo del formulario

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {           
            FECH1.Text = Equivalencias.Left(System.DateTime.Now.Date.ToString(), 10);
            FECH2.Text = Equivalencias.Left(System.DateTime.Now.Date.ToString(), 10);            
            CargarIDCC1();
            CargarIDCC2();
            GetList();
            Session["ssModo"] = "NEW";
        }
    }

    #region Mensajes
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

    #endregion

    #region *** metodos generales
    private void GetList()
    {
        rrhh_listaasistenciaBL BL = new rrhh_listaasistenciaBL();
        tb_rrhh_listadeasistencia BE = new tb_rrhh_listadeasistencia();

        BE.empresaid = Session["ssEmpresaID"].ToString();
        try
        {
            BE.FECH1 = Convert.ToDateTime(FECH1.Text);
            BE.FECH2 = Convert.ToDateTime(FECH2.Text);
        }
        catch (Exception ex)
        {
            FECH1.Text = Equivalencias.Left(System.DateTime.Now.Date.ToString(), 10);
            BE.FECH1 = Convert.ToDateTime(FECH1.Text);
        }

        try
        {
            BE.FECH2 = Convert.ToDateTime(FECH2.Text);
        }
        catch (Exception ex)
        {
            FECH2.Text = Equivalencias.Left(System.DateTime.Now.Date.ToString(), 10);
            BE.FECH2 = Convert.ToDateTime(FECH2.Text);
        }

        //.ANIO1 = Year(Convert.ToDateTime(FECH1.Text))
        //.MESS1 = Month(Convert.ToDateTime(FECH1.Text))
        //.DIAA1 = Day(Convert.ToDateTime(FECH1.Text))
        //.ANIO2 = Year(Convert.ToDateTime(FECH2.Text))
        //.MESS2 = Month(Convert.ToDateTime(FECH2.Text))
        //.DIAA2 = Day(Convert.ToDateTime(FECH2.Text))

        try
        {
            if (Equivalencias.IsNumeric(Equivalencias.Left(NOMBS.Text, 8).Trim()))
            {
                BE.DDNNI = Equivalencias.Left(NOMBS.Text, 8).Trim();
                BE.NOMBS = "";
            }
            else
            {
                BE.DDNNI = "";
                BE.NOMBS = NOMBS.Text.ToUpper().Trim();
            }

        }
        catch (Exception ex)
        {
            BE.DDNNI = "";
            BE.NOMBS = NOMBS.Text.ToUpper().Trim();
        }

        if (Equivalencias.Left(IDCC1.Text, 2).Trim() == "**")
        {
            BE.IDCC1 = "";
        }
        else
        {
            BE.IDCC1 = Equivalencias.Left(IDCC1.Text, 2).Trim();
        }

        if (Equivalencias.Left(IDCC2.Text, 3).Trim() == "***")
        {
            BE.IDCC2 = "";
        }
        else
        {
            BE.IDCC2 = Equivalencias.Left(IDCC2.Text, 3).Trim();
        }

            BE.flvis = false;

        try
        {
            GridView1.DataSource = BL.GetAll(Session["ssEmpresaID"].ToString(),BE);
            GridView1.DataBind();

            GridView2.DataSource = BL.GetAll(Session["ssEmpresaID"].ToString(), BE);
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }

    private void Update()
    {
        rrhh_listaasistenciaBL BL = new rrhh_listaasistenciaBL();
        tb_rrhh_listadeasistencia BE = new tb_rrhh_listadeasistencia();

        System.DateTime xfede = default(System.DateTime);
        System.DateTime xfeha = default(System.DateTime);
        System.DateTime xfech = default(System.DateTime);
        int dias = 0;
        int x = 0;

        xfede = Convert.ToDateTime(FECH1.Text);
        xfeha = Convert.ToDateTime(FECH2.Text);
        TimeSpan t3 = (xfeha - xfede);
        dias = Convert.ToInt32(t3.TotalDays);

        for (x = 0; x <= dias; x++)
        {
            xfech = xfede.AddDays(x);
            BE.FECHA = xfech;

            try
            {
                if (BL.Update2(Session["ssEmpresaID"].ToString(),BE))
                {
                    //mp.MostrarVentana("Actualizada fecha " & xfech.ToString, Page.ClientScript)
                }
            }
            catch (Exception ex)
            {
                ClientMessage(ex.Message);
            }
        }
        ClientMessage("Actualizacion terminada");
    }

    private void CargarIDCC1()
    {
        //rrhh_ccosto1BL BL = new rrhh_ccosto1BL();
        //tb_rrhh_ccosto1 BE = new tb_rrhh_ccosto1();
        //DataTable dt = new DataTable();
        //BE.IDCC1 = "";
        //BE.NBCC1 = "";

        //IDCC1.Items.Clear();
        //IDCC1.Items.Add("*** Todos ***");
        //try
        //{
        //    dt = BL.GetAll(Session["ssEmpresaID"].ToString(),BE).Tables[0];

        //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //    {
        //        IDCC1.Items.Add(dt.Rows[i]["IDCC1"] + "-" + dt.Rows[i]["NBCC1"]);
        //    }

        //}
        //catch (Exception ex)
        //{
        //    this.ClientMessage(ex.Message);
        //}

    }

    private void CargarIDCC2()
    {
        //rrhh_ccosto2BL BL = new rrhh_ccosto2BL();
        //tb_rrhh_ccosto2 BE = new tb_rrhh_ccosto2();
        //DataTable dt = new DataTable();
        //BE.IDCC1 = Equivalencias.Left(IDCC1.Text, 2).Trim();
        //BE.IDCC2 = "";
        //BE.NBCC2 = "";

        //IDCC2.Items.Clear();
        //IDCC2.Items.Add("*** Todos ***");
        //try
        //{
        //    dt = BL.GetAll(Session["ssEmpresaID"].ToString(),BE).Tables[0];

        //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //    {
        //        IDCC2.Items.Add(dt.Rows[i]["IDCC2"] + "-" + dt.Rows[i]["NBCC2"]);
        //    }

        //}
        //catch (Exception ex)
        //{
        //    this.ClientMessage(ex.Message);
        //}

    }
    #endregion

    #region *** metodos retorno de datos
    
    #endregion

    #region *** gridiview general
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
    #endregion

    #region *** datos popup
    #endregion

    #region *** metodos mantenimiento de Datos   

    #endregion

    #region *** objeto de mantenimiento (controles)     
    protected void btnListar_Click(object sender, EventArgs e)
    {
        GetList();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetList();
    }

    protected void IDCC1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarIDCC2();
    }

    protected void btnProcesar_Click(object sender, EventArgs e)
    {
        Update();
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {

         ReporteHorizontal();

        #region ---Anterior


        //rrhh_listaasistenciaBL BL = new rrhh_listaasistenciaBL();
        //tb_rrhh_listadeasistencia BE = new tb_rrhh_listadeasistencia();

        //BE.empresaid = Session["ssEmpresaID"].ToString();

        ////BE.filtro = "1";

        //BE.FECH1 = Convert.ToDateTime(FECH1.Text);
        //BE.FECH2 = Convert.ToDateTime(FECH2.Text);

        //try
        //{
        //    if (Equivalencias.IsNumeric(Equivalencias.Left(NOMBS.Text, 8).Trim()))
        //    {
        //        BE.DDNNI = Equivalencias.Left(NOMBS.Text, 8).Trim();
        //        BE.NOMBS = "";
        //    }
        //    else
        //    {
        //        BE.DDNNI = "";
        //        BE.NOMBS = NOMBS.Text.ToUpper().Trim();
        //    }

        //}
        //catch (Exception ex)
        //{
        //    BE.DDNNI = "";
        //    BE.NOMBS = NOMBS.Text.ToUpper().Trim();
        //}

        //if (Equivalencias.Left(IDCC1.Text, 2).Trim() == "**")
        //{
        //    BE.IDCC1 = "";
        //}
        //else
        //{
        //    BE.IDCC1 = Equivalencias.Left(IDCC1.Text, 2).Trim();
        //}

        //if (Equivalencias.Left(IDCC2.Text, 3).Trim() == "***")
        //{
        //    BE.IDCC2 = "";
        //}
        //else
        //{
        //    BE.IDCC2 = Equivalencias.Left(IDCC2.Text, 3).Trim();
        //}

        //BE.flvis = false;

        ////******** Exportando a Excel ***********

        //try
        //{
        //    DataTable dt = new DataTable();
        //    dt = BL.GetAll2(Session["ssEmpresaID"].ToString(), BE).Tables[0];            

        //    StringBuilder sb = new StringBuilder();
        //    StringWriter sw = new StringWriter(sb);
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    Page page = new Page();
        //    HtmlForm form = new HtmlForm();
            
        //    //Se Deshabilita la validación de eventos, sólo asp.net 2
        //    page.EnableEventValidation = false;

        //    //Se Realiza las inicializaciones de la instancia de la clase Page
        //    page.DesignerInitialize();       

        //    //*** GENERAR REPORTE
        //    htw.Write("<table width='1000' border='1' cellpadding='0' cellspacing='0' style='font:Tahoma; font-size:12px;'>");
        //    htw.Write("<tr>");
        //    htw.Write("<td width='79'>&nbsp;</td>");
        //    htw.Write("<td width='205'>&nbsp;</td>");
        //    htw.Write("<td colspan='6' rowspan='2' align='center' style='font-size:18px;'><strong>LISTADO DE ASISTENCIA</strong></td>");
        //    htw.Write("<td width='72'>&nbsp;</td>");
        //    htw.Write("<td width='76'>&nbsp;</td>");
        //    htw.Write("</tr>");
        //    htw.Write("<tr>");
        //    htw.Write("<td>&nbsp;</td>");
        //    htw.Write("<td>&nbsp;</td>");
        //    htw.Write("<td>&nbsp;</td>");
        //    htw.Write("<td>&nbsp;</td>");
        //    htw.Write("</tr>");

        //    htw.Write("<tr>");
        //    htw.Write("<td colspan='10'><strong>&nbsp;&nbsp;&nbsp;DEL :</strong>&nbsp;&nbsp;&nbsp;[" + FECH1.Text.ToString() + "]&nbsp;&nbsp;&nbsp;&nbsp; <strong>AL :</strong>&nbsp;&nbsp;&nbsp;[" + FECH2.Text.ToString() + "]</td>");
        //    htw.Write("</tr>");

        //    htw.Write("<tr>");
        //    htw.Write("<td colspan='10'>&nbsp;</td>");
        //    htw.Write("</tr>");

        //    htw.Write("<tr style='color: #FFFFFF; font-weight: bold; background-color:#006699;'>");
        //    htw.Write("<td width='150' align='center'>AREA</td>");
        //    htw.Write("<td width='200' align='center'>DNI</td>");
        //    htw.Write("<td width='250' align='center'>TRABAJADOR</td>");
        //    htw.Write("<td align='center'>LUNES</td>");
        //    htw.Write("<td align='center'>MARTES</td>");
        //    htw.Write("<td align='center'>MIERCOLES</td>");
        //    htw.Write("<td align='center'>JUEVES</td>");
        //    htw.Write("<td align='center'>VIERNES</td>");
        //    htw.Write("<td align='center'>SABADO</td>");
        //    htw.Write("<td align='center'>DOMINGO</td>");

        //    htw.Write("</tr>");

        //    foreach (DataRow dr in dt.Rows)
        //    {                
        //        htw.Write("<tr>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["NBCC2"].ToString().Trim() + "</td>");
        //        htw.Write("<td class='textmode'>" + dr["DDNNI"].ToString().Trim() + "</td>");
        //        htw.Write("<td class='textmode'>" + dr["NOMBS"].ToString().Trim() + "</td>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["LUN"].ToString().Trim() + "</td>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["MAR"].ToString().Trim() + "</td>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["MIE"].ToString().Trim() + "</td>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["JUE"].ToString().Trim() + "</td>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["VIE"].ToString().Trim() + "</td>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["SAB"].ToString().Trim() + "</td>");
        //        htw.Write("<td align='center' class='textmode'>" + dr["DOM"].ToString().Trim() + "</td>");
        //        htw.Write("</tr>");
        //    }

        //    htw.Write("</table>");
        //    htw.Write("<table><tr><td></td></tr></table>");

        //    page.RenderControl(htw);

        //   // string style = @"<style> .textmode { mso-number-format:\@; } .intmode { mso-number-format:'0'; } .decmode { mso-number-format:'\#\,\#\#0\.00'; }</style>";
        //    string style = @"<style> .textmode { mso-number-format:\@; } </script> ";
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.ContentType = "application/vnd.ms-excel";
        //    Response.AddHeader("Content-Disposition", "attachment;filename=ListaAsistencia.xls");
        //    Response.Charset = "UTF-8";
        //    Response.ContentEncoding = Encoding.Default;
        //    // Escribe estilo
        //    Response.Write(style);
        //    Response.Write(sb.ToString());
        //    Response.End();

        //    //HttpContext.Current.ApplicationInstance.CompleteRequest();

        //}
        //catch (Exception ex)
        //{
        //    this.ClientMessage(ex.Message);
        //}

        #endregion
    }

    // MODO HORIZONTAL

    private void ReporteHorizontal() 
    {
        rrhh_listaasistenciaBL BL = new rrhh_listaasistenciaBL();
        tb_rrhh_listadeasistencia BE = new tb_rrhh_listadeasistencia();

        BE.empresaid = Session["ssEmpresaID"].ToString();

        BE.filtro = "1";
        BE.FECH1 = Convert.ToDateTime(FECH1.Text);
        BE.FECH2 = Convert.ToDateTime(FECH2.Text);


        try
        {
            DataTable dt = new DataTable();

            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];  

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            page.EnableEventValidation = false;
            page.DesignerInitialize();

            htw.Write("<table>");
            htw.Write("<tr>");
            htw.Write("<td></td>");
            htw.Write("</tr>");
            htw.Write("</table>");

            htw.Write("<table border='1' style='font:Tahoma; font-size:12px;'>");
            htw.Write("<tr style='color: #FFFFFF; font-weight: bold; background-color:#006699;'>");
            htw.Write("<td colspan='2' rowspan='2' align='center'>&nbsp;</td>");
            htw.Write("<td colspan='5' rowspan='2' align='center' style='font-size:18px;'><strong>LISTADO DE ASISTENCIAS DIARIAS</strong></td>");
            htw.Write("<td colspan='3' rowspan='2' align='center'>&nbsp;</td>");
            htw.Write("</tr>");
            htw.Write("</table>");

            htw.Write("<table style='font:Tahoma; font-size:13px;'>");
            htw.Write("<tr>");
            htw.Write("<td></td>");
            htw.Write("</tr>");
            htw.Write("<tr>");
            htw.Write("<td colspan='10'><strong>&nbsp;&nbsp;&nbsp;DEL:</strong>&nbsp;&nbsp;&nbsp;[" + FECH1.Text.ToString() + "]&nbsp;&nbsp;&nbsp;&nbsp; <strong>AL:</strong>&nbsp;&nbsp;&nbsp;[" + FECH2.Text.ToString() + "]</td>");
            htw.Write("</tr>");
            htw.Write("<tr>");
            htw.Write("<td></td>");
            htw.Write("</tr>");

            htw.Write("</table>");

            foreach (DataRow dr in dt.Rows)
            {

                String t_id = Convert.ToString(dt.Rows[0]["IDCC2"].ToString());
                String t_nom = Convert.ToString(dt.Rows[0]["NBCC2"].ToString());

                if (Equivalencias.Left(IDCC1.Text, 2).Trim() == "**")
                {
                    BE.IDCC1 = "";
                }
                else
                {
                    BE.IDCC1 = Equivalencias.Left(IDCC1.Text, 2).Trim();
                }

                BE.IDCC2 = dr["IDCC2"].ToString();
                BE.filtro = "2";

                BE.FECH1 = Convert.ToDateTime(FECH1.Text);
                BE.FECH2 = Convert.ToDateTime(FECH2.Text);

                DataTable dt2 = new DataTable();
                dt2 = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];


                if (dt2.Rows.Count > 0)
                {

                    htw.Write("<table border='1'style='font:Tahoma; font-size:12px;'>");
                    htw.Write("<tr>");
                    htw.Write("<td colspan='10'><strong>&nbsp;&nbsp;&nbsp;AREA MATRIZ:</strong>&nbsp;&nbsp;&nbsp;[" + dr["NBCC2"].ToString() + "]</td>");
                    htw.Write("</tr>");

                    htw.Write("<tr style='color: #FFFFFF; font-weight: bold; background-color:#006699;'>");
                    htw.Write("<td width='200' align='center'>DNI</td>");
                    htw.Write("<td width='250'  align='center'>TRABAJADOR</td>");
                    htw.Write("<td width='150'  align='center'>DIA 01</td>");
                    htw.Write("<td width='150'  align='center'>DIA 02</td>");
                    htw.Write("<td width='150'  align='center'>DIA 03</td>");
                    htw.Write("<td width='150'  align='center'>DIA 04</td>");
                    htw.Write("<td width='150'  align='center'>DIA 05</td>");
                    htw.Write("<td width='150'  align='center'>DIA 06</td>");
                    htw.Write("<td width='150'  align='center'>DIA 07</td>");
                    htw.Write("<td width='150'  align='center'>DIA 08</td>");
                    htw.Write("<td width='150'  align='center'>DIA 09</td>");
                    htw.Write("<td width='150'  align='center'>DIA 10</td>");
                    htw.Write("<td width='150'  align='center'>DIA 11</td>");
                    htw.Write("<td width='150'  align='center'>DIA 12</td>");
                    htw.Write("<td width='150'  align='center'>DIA 13</td>");
                    htw.Write("<td width='150'  align='center'>DIA 14</td>");
                    htw.Write("<td width='150'  align='center'>DIA 15</td>");
                    htw.Write("<td width='150'  align='center'>DIA 16</td>");
                    htw.Write("<td width='150'  align='center'>DIA 17</td>");
                    htw.Write("<td width='150'  align='center'>DIA 18</td>");
                    htw.Write("<td width='150'  align='center'>DIA 19</td>");
                    htw.Write("<td width='150'  align='center'>DIA 20</td>");
                    htw.Write("<td width='150'  align='center'>DIA 21</td>");
                    htw.Write("<td width='150'  align='center'>DIA 22</td>");
                    htw.Write("<td width='150'  align='center'>DIA 23</td>");
                    htw.Write("<td width='150'  align='center'>DIA 24</td>");
                    htw.Write("<td width='150'  align='center'>DIA 25</td>");
                    htw.Write("<td width='150'  align='center'>DIA 26</td>");
                    htw.Write("<td width='150'  align='center'>DIA 27</td>");
                    htw.Write("<td width='150'  align='center'>DIA 28</td>");
                    htw.Write("<td width='150'  align='center'>DIA 29</td>");
                    htw.Write("<td width='150'  align='center'>DIA 30</td>");
                    htw.Write("<td width='150'  align='center'>DIA 31</td>");
                    htw.Write("</tr>");

                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        htw.Write("<tr>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["DDNNI"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["NOMBS"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D1"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D2"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D3"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D4"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D5"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D6"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D7"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D8"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D9"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D10"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D11"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D12"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D13"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D14"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D15"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D16"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D17"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D18"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D19"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D20"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D21"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D22"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D23"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D24"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D25"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D26"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D27"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D28"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D29"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D30"].ToString().Trim() + "</td>");
                        htw.Write("<td align='center' class='textmode'>" + dr2["D31"].ToString().Trim() + "</td>");
                        htw.Write("</tr>");
                    }

                    htw.Write("</table>");

                    htw.Write("<table>");
                    htw.Write("<tr>");
                    htw.Write("<td></td>");
                    htw.Write("</tr>");
                    htw.Write("<tr>");
                    htw.Write("<td></td>");
                    htw.Write("</tr>");
                    htw.Write("</table>");
                }
            }

            page.RenderControl(htw);

            string style = @"<style> .textmode { mso-number-format:\@; } .intmode { mso-number-format:'0'; } .decmode { mso-number-format:'\#\,\#\#0\.00'; }</style>";

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Lista_Asistencias.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            // Escribe estilo
            Response.Write(style);
            Response.Write(sb.ToString());
            Response.End();

            //HttpContext.Current.ApplicationInstance.CompleteRequest();  

        }
        catch (Exception ex)
        {
            this.ClientMessage(ex.Message);
        }


    }


    protected void btnExcel2_Click(object sender, EventArgs e)
    {
        rrhh_listaasistenciaBL BL = new rrhh_listaasistenciaBL();
        tb_rrhh_listadeasistencia BE = new tb_rrhh_listadeasistencia();

        try
        {
            BE.FECH1 = Convert.ToDateTime(FECH1.Text);
            BE.FECH2 = Convert.ToDateTime(FECH2.Text);
        }
        catch (Exception ex)
        {
            FECH1.Text = Equivalencias.Left(System.DateTime.Now.Date.ToString(), 10);
            BE.FECH1 = Convert.ToDateTime(FECH1.Text);
        }

        try
        {
            BE.FECH2 = Convert.ToDateTime(FECH2.Text);
        }
        catch (Exception ex)
        {
            FECH2.Text = Equivalencias.Left(System.DateTime.Now.Date.ToString(), 10);
            BE.FECH2 = Convert.ToDateTime(FECH2.Text);
        }

        try
        {
            if (Equivalencias.IsNumeric(Equivalencias.Left(NOMBS.Text, 8).Trim()))
            {
                BE.DDNNI = Equivalencias.Left(NOMBS.Text, 8).Trim();
                BE.NOMBS = "";
            }
            else
            {
                BE.DDNNI = "";
                BE.NOMBS = NOMBS.Text.ToUpper().Trim();
            }

        }
        catch (Exception ex)
        {
            BE.DDNNI = "";
            BE.NOMBS = NOMBS.Text.ToUpper().Trim();
        }

        if (Equivalencias.Left(IDCC1.Text, 2).Trim() == "**")
        {
            BE.IDCC1 = "";
        }
        else
        {
            BE.IDCC1 = Equivalencias.Left(IDCC1.Text, 2).Trim();
        }

        if (Equivalencias.Left(IDCC2.Text, 3).Trim() == "***")
        {
            BE.IDCC2 = "";
        }
        else
        {
            BE.IDCC2 = Equivalencias.Left(IDCC2.Text, 3).Trim();
        }

        BE.flvis = false;

        //******** Exportando a Excel ***********

        try
        {
            
            DataTable dt = new DataTable();
            dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
               
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();


            //Se Deshabilita la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            //Se Realiza las inicializaciones de la instancia de la clase Page
            page.DesignerInitialize();

            //*** GENERAR REPORTE
            htw.Write("<table width='10000' border='1' cellpadding='0' cellspacing='0' style='font:Tahoma; font-size:12px;'>");
            htw.Write("<tr>");
            htw.Write("<td width='79'>&nbsp;</td>");
            htw.Write("<td width='205'>&nbsp;</td>");
            htw.Write("<td colspan='6' rowspan='2' align='center' style='font-size:18px;'><strong>LISTADO DE ASISTENCIA</strong></td>");
            htw.Write("<td width='72'>&nbsp;</td>");
            htw.Write("<td width='76'>&nbsp;</td>");
            htw.Write("</tr>");
            htw.Write("<tr>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("</tr>");

            htw.Write("<tr>");
            htw.Write("<td colspan='10'><strong>&nbsp;&nbsp;&nbsp;DEL:</strong>&nbsp;&nbsp;&nbsp;[" + FECH1.Text.ToString() + "]&nbsp;&nbsp;&nbsp;&nbsp; <strong>AL:</strong>&nbsp;&nbsp;&nbsp;[" + FECH2.Text.ToString() + "]</td>");
            htw.Write("</tr>");

            htw.Write("<tr>");
            htw.Write("<td colspan='10'>&nbsp;</td>");
            htw.Write("</tr>");

            htw.Write("<tr style='color: #FFFFFF; font-weight: bold; background-color:#006699;'>");
            htw.Write("<td width='200' align='center'>FECHA</td>");
            htw.Write("<td width='150' align='center'>AREA</td>");
            htw.Write("<td width='200' align='center'>DNI</td>");
            htw.Write("<td width='250' align='center'>TRABAJADOR</td>");
            htw.Write("<td width='100' align='center'>DIA</td>");
            htw.Write("<td width='150' align='center'>MARCA</td>");
            htw.Write("<td width='150' align='center'>MIN/TRA</td>");
            htw.Write("<td width='150' align='center'>GLOSA</td>");
            htw.Write("<td width='150' align='center'>RANGO</td>");

            htw.Write("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                htw.Write("<tr>");
                htw.Write("<td align='center'>" + dr["FECHA"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["NBCC2"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["DDNNI"].ToString().Trim() + "</td>");
                htw.Write("<td class='textmode'>" + dr["NOMBS"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["NBDIA"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["MARCA"].ToString().Trim() + "</td>");
                htw.Write("<td align='center'>" + dr["HorasTrabajadas"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["GLOSA"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["RANGO"].ToString().Trim() + "</td>");
                htw.Write("</tr>");
            }

            htw.Write("</table>");
            htw.Write("<table><tr><td></td></tr></table>");

            page.RenderControl(htw);

            string style = @"<style> .textmode { mso-number-format:\@; } .intmode { mso-number-format:'0'; } .decmode { mso-number-format:'\#\,\#\#0\.00'; }</style>";

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=ListaAsistencia.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            // Escribe estilo
            Response.Write(style);
            Response.Write(sb.ToString());
            Response.End();

            //HttpContext.Current.ApplicationInstance.CompleteRequest();
           
        }
        catch (Exception ex)
        {
            this.ClientMessage(ex.Message);
        }

    }

    protected void Btn_Exportar_XLS_Click(object sender, EventArgs e)
    {
        // - Exporta Gridview a Excel, crea planilla completa aunque el Gridview tenga páginas
        if (GridView1.Rows.Count > 0 && GridView1.Visible == true)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            string filename = "Listado.xls";

            GridView1.EnableViewState = false;
            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            GridView1.DataBind();
            GridView1.HeaderStyle.Reset();

            // Recorre todas las filas
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                // Aplica estilo a cada celda, diferencia por el numero de columna si debe aplicar formato
                // texto o numero
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (j == 3 || j == 6)
                    {
                        row.Cells[j].Attributes.Add("class", "num1");  // formato numero
                    }
                    else
                    {
                        row.Cells[j].Attributes.Add("class", "textmode");  // formato texto
                    }
                }
            }

            // Define estilo para formato texto y numérico

            string style = @"";
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(GridView1);
            page.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            // Escribe estilo
            Response.Write(style);
            // Agrega título en primera celda
            string Titulo = " LISTADO DE ASISTENCIA ";
            HttpContext.Current.Response.Write(Titulo);
            Response.Write(sb.ToString());
            Response.End();
        }
    }
    #endregion

    protected void btnExcel3_Click(object sender, EventArgs e)
    {


        #region

        rrhh_listaasistenciaBL BL = new rrhh_listaasistenciaBL();
        tb_rrhh_listadeasistencia BE = new tb_rrhh_listadeasistencia();

        BE.empresaid = Session["ssEmpresaID"].ToString();

        //BE.filtro = "1";

        BE.FECH1 = Convert.ToDateTime(FECH1.Text);
        BE.FECH2 = Convert.ToDateTime(FECH2.Text);

        try
        {
            if (Equivalencias.IsNumeric(Equivalencias.Left(NOMBS.Text, 8).Trim()))
            {
                BE.DDNNI = Equivalencias.Left(NOMBS.Text, 8).Trim();
                BE.NOMBS = "";
            }
            else
            {
                BE.DDNNI = "";
                BE.NOMBS = NOMBS.Text.ToUpper().Trim();
            }

        }
        catch (Exception ex)
        {
            BE.DDNNI = "";
            BE.NOMBS = NOMBS.Text.ToUpper().Trim();
        }

        if (Equivalencias.Left(IDCC1.Text, 2).Trim() == "**")
        {
            BE.IDCC1 = "";
        }
        else
        {
            BE.IDCC1 = Equivalencias.Left(IDCC1.Text, 2).Trim();
        }

        if (Equivalencias.Left(IDCC2.Text, 3).Trim() == "***")
        {
            BE.IDCC2 = "";
        }
        else
        {
            BE.IDCC2 = Equivalencias.Left(IDCC2.Text, 3).Trim();
        }

        BE.flvis = false;

        //******** Exportando a Excel ***********

        try
        {
            DataTable dt = new DataTable();
            dt = BL.GetAll2(Session["ssEmpresaID"].ToString(), BE).Tables[0];

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            //HtmlForm form = new HtmlForm();

            //Se Deshabilita la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            //Se Realiza las inicializaciones de la instancia de la clase Page
            page.DesignerInitialize();

            //*** GENERAR REPORTE
            htw.Write("<table width='1000' border='1' cellpadding='0' cellspacing='0' style='font:Tahoma; font-size:12px;'>");
            htw.Write("<tr>");
            htw.Write("<td width='79'>&nbsp;</td>");
            htw.Write("<td width='205'>&nbsp;</td>");
            htw.Write("<td colspan='6' rowspan='2' align='center' style='font-size:18px;'><strong>LISTADO DE ASISTENCIA</strong></td>");
            htw.Write("<td width='72'>&nbsp;</td>");
            htw.Write("<td width='76'>&nbsp;</td>");
            htw.Write("</tr>");
            htw.Write("<tr>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("<td>&nbsp;</td>");
            htw.Write("</tr>");

            htw.Write("<tr>");
            htw.Write("<td colspan='10'><strong>&nbsp;&nbsp;&nbsp;DEL :</strong>&nbsp;&nbsp;&nbsp;[" + FECH1.Text.ToString() + "]&nbsp;&nbsp;&nbsp;&nbsp; <strong>AL :</strong>&nbsp;&nbsp;&nbsp;[" + FECH2.Text.ToString() + "]</td>");
            htw.Write("</tr>");

            htw.Write("<tr>");
            htw.Write("<td colspan='10'>&nbsp;</td>");
            htw.Write("</tr>");

            htw.Write("<tr style='color: #FFFFFF; font-weight: bold; background-color:#006699;'>");
            htw.Write("<td width='150' align='center'>AREA</td>");
            htw.Write("<td width='200' align='center'>DNI</td>");
            htw.Write("<td width='250' align='center'>TRABAJADOR</td>");
            htw.Write("<td align='center'>LUNES</td>");
            htw.Write("<td align='center'>MARTES</td>");
            htw.Write("<td align='center'>MIERCOLES</td>");
            htw.Write("<td align='center'>JUEVES</td>");
            htw.Write("<td align='center'>VIERNES</td>");
            htw.Write("<td align='center'>SABADO</td>");
            htw.Write("<td align='center'>DOMINGO</td>");

            htw.Write("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                htw.Write("<tr>");
                htw.Write("<td align='center' class='textmode'>" + dr["NBCC2"].ToString().Trim() + "</td>");
                htw.Write("<td class='textmode'>" + dr["DDNNI"].ToString().Trim() + "</td>");
                htw.Write("<td class='textmode'>" + dr["NOMBS"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["LUN"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["MAR"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["MIE"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["JUE"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["VIE"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["SAB"].ToString().Trim() + "</td>");
                htw.Write("<td align='center' class='textmode'>" + dr["DOM"].ToString().Trim() + "</td>");
                htw.Write("</tr>");
            }

            htw.Write("</table>");
            htw.Write("<table><tr><td></td></tr></table>");

            page.RenderControl(htw);

            // string style = @"<style> .textmode { mso-number-format:\@; } .intmode { mso-number-format:'0'; } .decmode { mso-number-format:'\#\,\#\#0\.00'; }</style>";
            string style = @"<style> .textmode { mso-number-format:\@; } </script> ";
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=ListaAsistencia.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            // Escribe estilo
            Response.Write(style);
            Response.Write(sb.ToString());
            Response.End();

            //HttpContext.Current.ApplicationInstance.CompleteRequest();

        }
        catch (Exception ex)
        {
            this.ClientMessage(ex.Message);
        }

        #endregion

    }

    protected void GridView2_PageIndexChanged(object sender, EventArgs e)
    {
       var view = sender as GridView;
       if (view == null) return;
       var pageIndex = view.PageIndex; 
       
       //---->return 0
       
       GridView2.PageIndex = pageIndex;
       GetList();
    }


    protected void GridView2_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {                       
        //if (e.Row.GetType = DataControlRowType.DataRow)
        //{
        //    if (e.Row.RowState == DataControlRowState.Alternate)
        //    {
        //        e.Row.Attributes.Add("onmouseover", "this.className='gridHover'");
        //        e.Row.Attributes.Add("onmouseout", "this.className=''");
        //    }
        //    else
        //    {
        //        e.Row.Attributes.Add("onmouseover", "this.className='gridHover'");
        //        e.Row.Attributes.Add("onmouseout", "this.className=''");
        //    }
        //}
    }
}