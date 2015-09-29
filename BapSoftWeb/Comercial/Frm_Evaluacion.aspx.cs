
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



public partial class tb_rrhh_Frm_evaluacion : System.Web.UI.Page
{
    Genericas fungen = new Genericas();
    SimpleAES funcript = new SimpleAES();
    DatoSUNAT myInfoSunat = new DatoSUNAT();
    DataTable TablaEvalCrediticia;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //*** Uso de Boton Cerrar Popup           
            //Lock_or_Unlock_Boton("G", false, "_disabled");
            //Lock_or_Unlock_Boton("E", false, "_disabled");
            //Lock_or_Unlock_Boton("I", false, "_disabled");
            //Lock_or_Unlock_Boton("D", false, "_disabled");
            //Lock_or_Unlock_Boton("C", false, "_disabled");
            Lock_or_UnLock_Paneles("01", false, "fondo_bloqueo", "_disabled");
            //ArmadoTablaCrediticia();
            CargarEvaluacion();
        }
    }

    private void ArmadoTablaCrediticia()
    {
        TablaEvalCrediticia = new DataTable("TablaEvalCrediticia");
        TablaEvalCrediticia.Columns.Add("es_persjuridica", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("copia_constitucionempresa", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("copia_ruc", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("copia_dni", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("lic_func", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("titulo_localcom", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("contra_localcom", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("recibo_agualuz", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("tiene_letraprotestada", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("tiene_morosidad", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("moroso_infocorp", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("refe_comerc", typeof(Decimal));
        TablaEvalCrediticia.Columns.Add("refe_banca", typeof(Decimal));
        TablaEvalCrediticia.Columns.Add("bienes_bienmueble", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("bienes_inmuebles", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("eval_cxcob", typeof(String));
        TablaEvalCrediticia.Columns.Add("obs_cxcob", typeof(String));
        TablaEvalCrediticia.Columns.Add("aprob_gerencial", typeof(Boolean));
        TablaEvalCrediticia.Columns.Add("obs_gerencial", typeof(String));
        Session["TablaEvalCrediticia"] = TablaEvalCrediticia;
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

    private void CargarEvaluacion()
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();

        BE.tipdoc = Session["xtipdoc"].ToString();
        BE.serdoc = Session["xserdoc"].ToString();
        BE.numdoc = Session["xnumdoc"].ToString();
                      
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            es_persjuridica.Value = Convert.ToBoolean(dt.Rows[0]["es_persjuridica"].ToString());
            copia_constitucionempresa.Checked = Convert.ToBoolean(dt.Rows[0]["copia_constitucionempresa"].ToString());
            copia_ruc.Checked = Convert.ToBoolean(dt.Rows[0]["copia_ruc"].ToString());
            copia_dni.Checked = Convert.ToBoolean(dt.Rows[0]["copia_dni"].ToString());
            lic_func.Checked = Convert.ToBoolean(dt.Rows[0]["lic_func"].ToString());
            titulo_localcom.Checked = Convert.ToBoolean(dt.Rows[0]["copia_ruc"].ToString());
            contra_localcom.Checked = Convert.ToBoolean(dt.Rows[0]["contra_localcom"].ToString());
            recibo_agualuz.Checked = Convert.ToBoolean(dt.Rows[0]["recibo_agualuz"].ToString());
            tiene_letraprotestada.Value = Convert.ToBoolean(dt.Rows[0]["tiene_letraprotestada"].ToString());
            tiene_morosidad.Value = Convert.ToBoolean(dt.Rows[0]["tiene_morosidad"].ToString());
            moroso_infocorp.Value = Convert.ToBoolean(dt.Rows[0]["moroso_infocorp"].ToString());
            refe_comerc.Value = dt.Rows[0]["refe_comerc"].ToString();
            refe_banca.Value = dt.Rows[0]["refe_banca"].ToString();
            bienes_bienmueble.Value = Convert.ToBoolean(dt.Rows[0]["bienes_bienmueble"].ToString());
            bienes_inmuebles.Value = Convert.ToBoolean(dt.Rows[0]["bienes_inmuebles"].ToString());               
            eval_cxcob.Value = dt.Rows[0]["eval_cxcob"].ToString();
            obs_cxcob.Text = dt.Rows[0]["obs_cxcob"].ToString();
            if (dt.Rows[0]["aprob_gerencial"].ToString().Length > 0)
            {
                aprob_gerencial.Value = dt.Rows[0]["aprob_gerencial"].ToString();
            }
            obs_gerencial.Text = dt.Rows[0]["obs_gerencial"].ToString();
            lblpuntos.Text = dt.Rows[0]["puntaje"].ToString();
            lblitem.Text = dt.Rows[0]["item"].ToString();            
            lblnumdoc.Text = Session["xtipdoc"].ToString() + "-" 
                           + Session["xserdoc"].ToString()
                           + Equivalencias.Right(Session["xnumdoc"].ToString(),5);
        }
    }


    private void CargarEvaluacionAnterior()
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.filtro = "1";
        dt = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            es_persjuridica.Value = Convert.ToBoolean(dt.Rows[0]["es_persjuridica"].ToString());           
            copia_constitucionempresa.Checked = Convert.ToBoolean(dt.Rows[0]["copia_constitucionempresa"].ToString());
            copia_ruc.Checked = Convert.ToBoolean(dt.Rows[0]["copia_ruc"].ToString());
            copia_dni.Checked = Convert.ToBoolean(dt.Rows[0]["copia_dni"].ToString());
            lic_func.Checked = Convert.ToBoolean(dt.Rows[0]["lic_func"].ToString());
            titulo_localcom.Checked= Convert.ToBoolean(dt.Rows[0]["copia_ruc"].ToString());
            contra_localcom.Checked = Convert.ToBoolean(dt.Rows[0]["contra_localcom"].ToString());
            recibo_agualuz.Checked = Convert.ToBoolean(dt.Rows[0]["recibo_agualuz"].ToString());
            tiene_letraprotestada.Value = Convert.ToBoolean(dt.Rows[0]["tiene_letraprotestada"].ToString());
            tiene_morosidad.Value = Convert.ToBoolean(dt.Rows[0]["tiene_morosidad"].ToString());
            moroso_infocorp.Value = Convert.ToBoolean(dt.Rows[0]["moroso_infocorp"].ToString());
            refe_comerc.Value = dt.Rows[0]["refe_comerc"].ToString();
            refe_banca.Value = dt.Rows[0]["refe_banca"].ToString();
            bienes_bienmueble.Value = Convert.ToBoolean(dt.Rows[0]["bienes_bienmueble"].ToString());
            bienes_inmuebles.Value = Convert.ToBoolean(dt.Rows[0]["bienes_inmuebles"].ToString());
            eval_cxcob.Value = dt.Rows[0]["eval_cxcob"].ToString();
            obs_cxcob.Text = dt.Rows[0]["obs_cxcob"].ToString();
        }
    }

    private void CargamosTablaCrediticia()
    {
        TablaEvalCrediticia = (DataTable)Session["TablaEvalCrediticia"];        
        DataRow workRow;
        workRow = TablaEvalCrediticia.NewRow();
        workRow["es_persjuridica"] = Convert.ToBoolean(es_persjuridica.Value);
        workRow["copia_constitucionempresa"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["copia_ruc"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["copia_dni"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["lic_func"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["titulo_localcom"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["contra_localcom"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["recibo_agualuz"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["tiene_letraprotestada"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["tiene_morosidad"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["moroso_infocorp"] = Convert.ToBoolean(moroso_infocorp.Value);
        workRow["refe_comerc"] = "";
        workRow["refe_banca"] = "";
        workRow["bienes_bienmueble"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["bienes_inmuebles"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["eval_cxcob"] = "";
        workRow["obs_cxcob"] = "";
        workRow["aprob_gerencial"] = Convert.ToBoolean(copia_constitucionempresa.Checked);
        workRow["obs_gerencial"] = "";
        TablaEvalCrediticia.Rows.Add(workRow);
        Session["TablaEvalCrediticia"] = TablaEvalCrediticia;
    }
    
    private void EvalPuntaje()
    {
        int n = 0;
        // Protestas de Letra
        if (Convert.ToBoolean(tiene_letraprotestada.Value))
            n = n + 0;
        else
            n = n + 1;

        // Incumplimiento de Pago
        if (Convert.ToBoolean(tiene_morosidad.Value))
            n = n + 0;
        else
            n = n + 1;

        // Antecedentes INFOCORP
        if (Convert.ToBoolean(moroso_infocorp.Value))
            n = n + 0;
        else
            n = n + 1;

        // Referencias Comerciales
        if (refe_comerc.SelectedIndex != -1)
        {
            if (refe_comerc.Value.ToString() == "B")
                n = n + 2;
            else if (refe_comerc.Value.ToString() == "R")
                n = n + 1;
            else
                n = n + 0;
        }

        // Referencias Bancarias
        if (refe_banca.SelectedIndex != -1)
        {
            if (refe_banca.Value.ToString() == "B")
                n = n + 2;
            else if (refe_banca.Value.ToString() == "R")
                n = n + 1;
            else
                n = n + 0;
        }

        // Bienes Muebles
        if (Convert.ToBoolean(bienes_bienmueble.Value))
            n = n + 1;
        else
            n = n + 0;

        // Bienes Inmuebles
        if (Convert.ToBoolean(bienes_inmuebles.Value))
            n = n + 1;
        else
            n = n + 0;

        lblpuntos.Text = n.ToString();
    }



    private void LimpiarDocumento()
    {
        es_persjuridica.SelectedIndex = -1;
        copia_constitucionempresa.Checked = false;
        copia_ruc.Checked = false;
        copia_dni.Checked = false;
        lic_func.Checked = false;
        titulo_localcom.Checked = false;
        contra_localcom.Checked = false;
        recibo_agualuz.Checked = false;
        tiene_letraprotestada.SelectedIndex = -1;
        tiene_morosidad.SelectedIndex = -1;
        moroso_infocorp.SelectedIndex = -1;
        refe_comerc.SelectedIndex = -1;
        refe_banca.SelectedIndex = -1;
        bienes_bienmueble.SelectedIndex = -1;
        bienes_inmuebles.SelectedIndex = -1;
        eval_cxcob.SelectedIndex = -1;
        obs_cxcob.Text = "";
        lblpuntos.Text = "0";
        aprob_gerencial.SelectedIndex = -1;
        obs_gerencial.Text = "";    
    }

    protected void btn_Nuevo_Click(object sender, ImageClickEventArgs e)
    {
        Session["ssModo"] = "NEW";
        LimpiarDocumento();
        CargarEvaluacionAnterior();
        Lock_or_Unlock_Boton("N", false, "_disabled");
        Lock_or_Unlock_Boton("G", true, "");
        Lock_or_Unlock_Boton("C", true, "");
    }

    private void Lock_or_Unlock_Boton(String xbtn, Boolean xvar, String xval)
    {
        if (xbtn == "G")
        {
            btn_grabar.Enabled = xvar;
            btn_grabar.ImageUrl = "~/images/btn_grabar" + xval + ".png";
        }
        if (xbtn == "N")
        {
            btn_Nuevo.Enabled = xvar;
            btn_Nuevo.ImageUrl = "~/images/btn_new" + xval + ".png";
        }
        if (xbtn == "E")
        {
            //btn_Editar.Enabled = xvar;
            //btn_Editar.ImageUrl = "~/images/btn_edit" + xval + ".png";
        }
        if (xbtn == "I")
        {
            btn_Imprimir.Enabled = xvar;
            btn_Imprimir.ImageUrl = "~/images/btn_imprimir" + xval + ".png";
        }
        if (xbtn == "D")
        {
            //btn_Eliminar.Enabled = xvar;
            //btn_Eliminar.ImageUrl = "~/images/btn_delete" + xval + ".png";
        }
        if (xbtn == "C")
        {
            btn_Cancelar.Enabled = xvar;
            btn_Cancelar.ImageUrl = "~/images/btn_cancel" + xval + ".png";
        }
    }

    private void Lock_or_UnLock_Paneles(String xpnl, Boolean xvar, String xclas, String xval)
    {
        if (xpnl == "01")
        {
            pnlGeren01.Enabled = xvar;
            pnlGeren01.CssClass = xclas;            
        }
    }

    protected void btn_grabar_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["ssModo"].ToString() == "NEW")
        { 
            Insert(); 
        }

        if (Session["ssModo"].ToString() == "EDI")
        {
            Update();
        }
    }

    private void Insert()
    {
        try
        {
            tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
            tb_cxc_evalcred BE = new tb_cxc_evalcred();

            BE.ctacte = Session["ssCtacte"].ToString();
            BE.item = "";
            BE.tipdoc = Session["xtipdoc"].ToString();
            BE.serdoc = Session["xserdoc"].ToString();
            BE.numdoc = Session["xnumdoc"].ToString();
            BE.es_persjuridica = Convert.ToBoolean(es_persjuridica.Value);
            BE.copia_constitucionempresa = copia_constitucionempresa.Checked;
            BE.copia_ruc = copia_ruc.Checked;
            BE.copia_dni = copia_dni.Checked;
            BE.lic_func = lic_func.Checked;
            BE.titulo_localcom = titulo_localcom.Checked;
            BE.contra_localcom = contra_localcom.Checked;
            BE.recibo_agualuz = recibo_agualuz.Checked;
            BE.tiene_letraprotestada = Convert.ToBoolean(tiene_letraprotestada.Value);
            BE.tiene_morosidad = Convert.ToBoolean(tiene_morosidad.Value);
            BE.moroso_infocorp = Convert.ToBoolean(moroso_infocorp.Value);
            BE.refe_comerc = refe_comerc.Value.ToString();
            BE.refe_banca = refe_banca.Value.ToString();
            BE.bienes_bienmueble = Convert.ToBoolean(bienes_bienmueble.Value);
            BE.bienes_inmuebles = Convert.ToBoolean(bienes_inmuebles.Value);
            BE.puntaje = Convert.ToInt32(lblpuntos.Text);
            BE.eval_cxcob = eval_cxcob.Value.ToString();
            BE.obs_cxcob = obs_cxcob.Text;
            BE.aprob_gerencial = aprob_gerencial.Value.ToString();
            BE.obs_gerencial = obs_gerencial.Text;
            BE.usuar = Session["ssUsuar"].ToString();

            if (BL.Insert(Session["ssEmpresaID"].ToString(), BE))
            {
                ClientMessage("Registros Grabados Correctamente !!!");
                LimpiarDocumento();
                Lock_or_Unlock_Boton("N", true, "");
                Lock_or_Unlock_Boton("C", false, "_disabled");
                Lock_or_Unlock_Boton("G", false, "_disabled");
            }
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }
    }

    private void Update()
    {
        try
        {
            var BL = new tb_cxc_evalcredBL();
            var BE = new tb_cxc_evalcred();

            BE.ctacte = Session["ssCtacte"].ToString();
            BE.item = lblitem.Text.Trim();
            BE.tipdoc = Session["xtipdoc"].ToString();
            BE.serdoc = Session["xserdoc"].ToString();
            BE.numdoc = Session["xnumdoc"].ToString();
            BE.es_persjuridica = Convert.ToBoolean(es_persjuridica.Value);
            BE.copia_constitucionempresa = copia_constitucionempresa.Checked;
            BE.copia_ruc = copia_ruc.Checked;
            BE.copia_dni = copia_dni.Checked;
            BE.lic_func = lic_func.Checked;
            BE.titulo_localcom = titulo_localcom.Checked;
            BE.contra_localcom = contra_localcom.Checked;
            BE.recibo_agualuz = recibo_agualuz.Checked;
            BE.tiene_letraprotestada = Convert.ToBoolean(tiene_letraprotestada.Value);
            BE.tiene_morosidad = Convert.ToBoolean(tiene_morosidad.Value);
            BE.moroso_infocorp = Convert.ToBoolean(moroso_infocorp.Value);
            BE.refe_comerc = refe_comerc.Value.ToString();
            BE.refe_banca = refe_banca.Value.ToString();
            BE.bienes_bienmueble = Convert.ToBoolean(bienes_bienmueble.Value);
            BE.bienes_inmuebles = Convert.ToBoolean(bienes_inmuebles.Value);
            BE.puntaje = Convert.ToInt32(lblpuntos.Text);
            BE.eval_cxcob = eval_cxcob.Value.ToString();
            BE.obs_cxcob = obs_cxcob.Text;
            BE.aprob_gerencial = aprob_gerencial.Value.ToString();
            BE.obs_gerencial = obs_gerencial.Text;
            BE.usuar = Session["ssUsuar"].ToString().Trim();
     
            if (BL.Update(Session["ssEmpresaID"].ToString(), BE))
            {
                ClientMessage("Registros Modificados Correctamente !!!");
                //MensajeQuery2("Registros Modificados Correctamente !!!"); 
                LimpiarDocumento();               
            }
        }
        catch (Exception ex)
        {
            ClientMessage(ex.Message);
        }      
    }

    protected void btn_Editar_Click(object sender, ImageClickEventArgs e)
    {
        Session["ssModo"] = "EDI";      
    }

    protected void btn_Cancelar_Click(object sender, ImageClickEventArgs e)
    {
        Session["ssModo"] = "DD";
        LimpiarDocumento();
        //Lock_or_Unlock_Boton("N", true, "");
        //Lock_or_Unlock_Boton("G", false, "_disabled");
        //Lock_or_Unlock_Boton("C", false, "_disabled");
        //Lock_or_Unlock_Boton("D", false, "_disabled");
        //Lock_or_Unlock_Boton("I", false, "_disabled");

        Response.Redirect("Listados/Lst_ProformaEval.aspx");
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

    protected void btn_Imprimir_Click(object sender, ImageClickEventArgs e)
    {
        reporte_pdf();   
    }
    private void reporte_pdf()
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
            sbMensaje.Append("window.open('Reportes/Rpt_EvalCrediticia.aspx?data=" + cifrado + "', 'mywindow','location=0,status=0,scrollbars=0,resizable=1,menubar=0,toolbar=0')");
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


    private void CargarEvaluacion_Paginacion(String xposicion)
    {
        tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
        tb_cxc_evalcred BE = new tb_cxc_evalcred();
        DataTable dt = new DataTable();
        BE.item = lblitem.Text.Trim();
        BE.posicion = xposicion.Trim();
        dt = BL.GetAll_paginacion(Session["ssEmpresaID"].ToString(), BE).Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblitem.Text = dt.Rows[0]["item"].ToString();
            es_persjuridica.Value = Convert.ToBoolean(dt.Rows[0]["es_persjuridica"].ToString());
            copia_constitucionempresa.Checked = Convert.ToBoolean(dt.Rows[0]["copia_constitucionempresa"].ToString());
            copia_ruc.Checked = Convert.ToBoolean(dt.Rows[0]["copia_ruc"].ToString());
            copia_dni.Checked = Convert.ToBoolean(dt.Rows[0]["copia_dni"].ToString());
            lic_func.Checked = Convert.ToBoolean(dt.Rows[0]["lic_func"].ToString());
            titulo_localcom.Checked = Convert.ToBoolean(dt.Rows[0]["copia_ruc"].ToString());
            contra_localcom.Checked = Convert.ToBoolean(dt.Rows[0]["contra_localcom"].ToString());
            recibo_agualuz.Checked = Convert.ToBoolean(dt.Rows[0]["recibo_agualuz"].ToString());
            tiene_letraprotestada.Value = Convert.ToBoolean(dt.Rows[0]["tiene_letraprotestada"].ToString());
            tiene_morosidad.Value = Convert.ToBoolean(dt.Rows[0]["tiene_morosidad"].ToString());
            moroso_infocorp.Value = Convert.ToBoolean(dt.Rows[0]["moroso_infocorp"].ToString());
            refe_comerc.Value = dt.Rows[0]["refe_comerc"].ToString();
            refe_banca.Value = dt.Rows[0]["refe_banca"].ToString();
            bienes_bienmueble.Value = Convert.ToBoolean(dt.Rows[0]["bienes_bienmueble"].ToString());
            bienes_inmuebles.Value = Convert.ToBoolean(dt.Rows[0]["bienes_inmuebles"].ToString());
            lblpuntos.Text = dt.Rows[0]["puntaje"].ToString();
            eval_cxcob.Value = dt.Rows[0]["eval_cxcob"].ToString();
            obs_cxcob.Text = dt.Rows[0]["obs_cxcob"].ToString();
        }
    }


    protected void btn_first_Click(object sender, ImageClickEventArgs e)
    {
        CargarEvaluacion_Paginacion("primero");
    }
    protected void btn_previous_Click(object sender, ImageClickEventArgs e)
    {
        CargarEvaluacion_Paginacion("anterior");
    }
    protected void btn_next_Click(object sender, ImageClickEventArgs e)
    {
        CargarEvaluacion_Paginacion("siguiente");
    }
    protected void btn_last_Click(object sender, ImageClickEventArgs e)
    {
        CargarEvaluacion_Paginacion("ultimo");
    }



    // Estos Metodos Activan el Metodo de Evaluacion de Puntaje
    protected void refe_comerc_SelectedIndexChanged(object sender, EventArgs e)
    {
        EvalPuntaje();
    }
    protected void refe_banca_SelectedIndexChanged(object sender, EventArgs e)
    {
        EvalPuntaje();
    }
    protected void moroso_infocorp_SelectedIndexChanged(object sender, EventArgs e)
    {
        EvalPuntaje();
    }
    protected void tiene_letraprotestada_SelectedIndexChanged(object sender, EventArgs e)
    {
        EvalPuntaje();
    }
    protected void tiene_morosidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        EvalPuntaje();
    }
    protected void bienes_bienmueble_SelectedIndexChanged(object sender, EventArgs e)
    {
        EvalPuntaje();
    }
    protected void bienes_inmuebles_SelectedIndexChanged(object sender, EventArgs e)
    {
        EvalPuntaje();
    }

    protected void btn_volver_Command(object sender, CommandEventArgs e)
    {

    }
    protected void btn_volver_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Listados/Lst_ProformaEval.aspx");
    }

}