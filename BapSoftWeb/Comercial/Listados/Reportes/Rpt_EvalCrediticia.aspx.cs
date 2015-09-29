using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LayerBusinessEntities;
using LayerBusinessLogic;
using bapFunciones;
using System.Text;

//Otros DLL Agregados 
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;
using System.IO;

public partial class Reportes_Rpt_EvalCrediticia : System.Web.UI.Page
{
    Genericas fungen = new Genericas();
    SimpleAES funcript = new SimpleAES();

    protected void Page_Load(object sender, EventArgs e)
    {

        string strCifrado;
        string tipodoc;
        strCifrado = Request.QueryString["data"];
        //ClientMessage(strCifrado);
        string texto = funcript.DecryptString(strCifrado);
        //Label1.Text = texto;
        //Cortar la cadena en pedacitos
        string[] Lista;
        Lista = texto.Split('&');
        tipodoc = Lista[0];
        //rpt_carnet_personal("1");
        Rpt_EvalCrediticia();
    }

    private void Rpt_EvalCrediticia()
    {
        try
        {
            //Se crea el documento PDF
            PdfDocument document = new PdfDocument();

            //Se configura los datos dela pagina
            document.Info.Title = "»» EVALUACIÓN CREDITICIA ««";
            document.Info.Author = "HVR";

            //Se crea la pagina A4
            PdfPage page = document.AddPage();
            page.Orientation = PageOrientation.Portrait;
         
            //Se crea el objeto dibujo
            XGraphics gfx = XGraphics.FromPdfPage(page);         
            XPen pen = new XPen(XColors.Navy, 1);
            string anio = Convert.ToString(DateTime.Now).Substring(6, 10);
            XRect rect;            
            XFont fontB18 = new XFont("Times", 20, XFontStyle.Bold);
            XFont fontB12 = new XFont("Times", 12, XFontStyle.Bold);
            XFont fontB9 = new XFont("Times", 9, XFontStyle.Bold);
            XFont font9 = new XFont("Times", 9);

            #region OBTENIENDO VALORES DE SESSION
            // DECLARANDO VARIBALES QUE RECIBIMOS DE SESSION            
            string XEMPRESANAME = Session["ssEmpresaName"].ToString();
            string XEMPRESARUC = Session["ssEmpresaRuc"].ToString();
            string XGERENTEGENE = Session["ssGerenteGeneral"].ToString();
            string XGERENTEDNI = Session["ssGerenteNrodni"].ToString();
            string XPARTELECTRO = Session["ssPartElectro"].ToString();
            string XUSUAR = Session["ssUsuar"].ToString();

            int XPUNTAJE = 0;
            Boolean XESJURIDICA = false,
                    XCOPIACONST = false,
                    XCOPIARUC = false,
                    XCOPIADNI = false,
                    XLICFUNC = false,
                    XTITLOCAL = false,
                    XCONTLOCAL = false,
                    XRECIBO = false,
                    XTIENLETR = false,
                    XTIENMORO = false,
                    XMOROSO = false,
                    XBIENMUEB = false,
                    XBIENINMUEB = false;
           
            string XNUMDOC = "", XSERDOC = "", XCTACTENAME = "", XCLINMRUC = "", XFECHA = "", XREFCOMER = "",
                   XREFBANCA = "",XEVALCXCOB ="",XOBSCXCOB="",XOBSGEREN="",XAPROBGERE="";
                        
            tb_cxc_evalcredBL BL = new tb_cxc_evalcredBL();
            tb_cxc_evalcred BE = new tb_cxc_evalcred();
            DataTable TablaEval = new DataTable();
            BE.tipdoc = Session["xtipdoc"].ToString();
            BE.serdoc = Session["xserdoc"].ToString();
            BE.numdoc = Session["xnumdoc"].ToString();
            TablaEval = BL.GetAll(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            foreach (DataRow fila in TablaEval.Rows)
            {
                XNUMDOC = fila["numdoc"].ToString();
                XSERDOC = fila["serdoc"].ToString();                
                XCTACTENAME = fila["ctactename"].ToString();
                XCLINMRUC = fila["nmruc"].ToString();     
                XFECHA = fila["fechdoc"].ToString();
                XESJURIDICA = Convert.ToBoolean(fila["es_persjuridica"].ToString());
                XCOPIACONST = Convert.ToBoolean(fila["copia_constitucionempresa"].ToString());
                XCOPIARUC = Convert.ToBoolean(fila["copia_ruc"].ToString());
                XCOPIADNI = Convert.ToBoolean(fila["copia_dni"].ToString());
                XLICFUNC = Convert.ToBoolean(fila["lic_func"].ToString());
                XTITLOCAL = Convert.ToBoolean(fila["titulo_localcom"].ToString());
                XCONTLOCAL = Convert.ToBoolean(fila["contra_localcom"].ToString());
                XRECIBO = Convert.ToBoolean(fila["recibo_agualuz"].ToString());
                XTIENLETR = Convert.ToBoolean(fila["tiene_letraprotestada"].ToString());
                XTIENMORO = Convert.ToBoolean(fila["tiene_morosidad"].ToString());
                XMOROSO = Convert.ToBoolean(fila["moroso_infocorp"].ToString());
                XREFCOMER = fila["refe_comerc"].ToString();
                XREFBANCA = fila["refe_banca"].ToString();
                XBIENMUEB = Convert.ToBoolean(fila["bienes_bienmueble"].ToString());
                XBIENINMUEB = Convert.ToBoolean(fila["bienes_inmuebles"].ToString());
                
                XPUNTAJE = Convert.ToInt32(fila["puntaje"].ToString());
                XEVALCXCOB = fila["eval_cxcob"].ToString();
                XOBSCXCOB = fila["obs_cxcob"].ToString();                
                XAPROBGERE = fila["aprob_gerencial"].ToString();                    
                XOBSGEREN = fila["obs_gerencial"].ToString();
            }
            #endregion

            Double XIMPOBRUTO = 0, XIMPONETO = 0;
            String XVENDORNAME = "";

            //VARIABLES RECIEN AGREGADAS EN LA BD

            tb_cxc_pedidocabBL BL2 = new tb_cxc_pedidocabBL();
            tb_cxc_pedidocab BE2 = new tb_cxc_pedidocab();
            DataTable TablaProfor = new DataTable();
            BE2.tipdoc = Session["xtipdoc"].ToString();
            BE2.serdoc = Session["xserdoc"].ToString();
            BE2.numdoc = Session["xnumdoc"].ToString();
            TablaProfor = BL2.GetAll2(Session["ssEmpresaID"].ToString(), BE2).Tables[0];
            if (TablaProfor.Rows.Count > 0)
            {
                XVENDORNAME = TablaProfor.Rows[0]["vendorname"].ToString();
            }           

            //define margins
            double leftMargin = 40.0;
            double rightMargin = 570.0;
            double topMargin = 20.0;
            double lineTop = 0d;
            double lineFooter = 780d;
            double rowStep = 12d;
            double newRow = topMargin + rowStep;
            double beginRow = newRow;
            double currentRow = beginRow;
            double currentRowCol2 = 0;
            double firstCustomerRow = 100d;            
            double txtShift = 8d;
            string hcString = string.Empty; //---added 6-26-13
            string sim1 = "[";
            string sim2 = "]";
            string space = "   ";


            // TITULO    
            gfx.DrawString("EVALUACION CREDITICIA", fontB18, XBrushes.Black, leftMargin + 20, topMargin + 40);

            pen = new XPen(XColors.Black, 2);
            gfx.DrawRoundedRectangle(pen, leftMargin + 300, topMargin + 15, 240, 50, 15, 15);

            // CUADRO
            gfx.DrawString("PEDIDO", fontB9, XBrushes.Black, leftMargin + 310, topMargin + 30);
            gfx.DrawString(": PD-"+XNUMDOC, font9, XBrushes.Black, leftMargin + 370, topMargin + 30);
            gfx.DrawString("FECHA", fontB9, XBrushes.Black, leftMargin + 440, topMargin + 30);
            gfx.DrawString(": " + Equivalencias.Left(XFECHA, 10), font9, XBrushes.Black, leftMargin + 480, topMargin + 30);
            gfx.DrawString("CLIENTE", fontB9, XBrushes.Black, leftMargin + 310, topMargin + 40);
            gfx.DrawString(": "+Equivalencias.Left(XCTACTENAME,30) , font9, XBrushes.Black, leftMargin + 370, topMargin + 40);
            gfx.DrawString("RUC", fontB9, XBrushes.Black, leftMargin + 310, topMargin + 50);
            gfx.DrawString(": "+XCLINMRUC, font9, XBrushes.Black, leftMargin + 370, topMargin + 50);
            gfx.DrawString("VENDEDOR", fontB9, XBrushes.Black, leftMargin + 310, topMargin + 60);
            gfx.DrawString(": " + XVENDORNAME, font9, XBrushes.Black, leftMargin + 370, topMargin + 60);
            
               
            // CONTENIDO
            gfx.DrawString("I.", fontB9, XBrushes.Black, leftMargin + 20, topMargin + 80);
            gfx.DrawString("DOCUMENTACION PARA LA EVALUACION CREDITICIA :", fontB9, XBrushes.Black, leftMargin + 50, topMargin + 80);

            gfx.DrawString("1.", font9, XBrushes.Black, leftMargin + 50, topMargin + 95);
            gfx.DrawString("CONDICION JURIDICA DEL CLIENTE :", font9, XBrushes.Black, leftMargin + 70, topMargin + 95);
            if (XESJURIDICA)
            {
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 108);
                gfx.DrawString("PERSONA NATURAL", font9, XBrushes.Black, leftMargin + 90, topMargin + 108);
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 118);
                gfx.DrawString("PERSONA JURIDICA", font9, XBrushes.Black, leftMargin + 90, topMargin + 118);
            }
            else {
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 108);
                gfx.DrawString("PERSONA NATURAL", font9, XBrushes.Black, leftMargin + 90, topMargin + 108);
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 118);
                gfx.DrawString("PERSONA JURIDICA", font9, XBrushes.Black, leftMargin + 90, topMargin + 118);
            }

            gfx.DrawString("2.", font9, XBrushes.Black, leftMargin + 50, topMargin + 133);            
            gfx.DrawString("DOCUMENTOS PRESENTADOS POR EL CLIENTE :", font9, XBrushes.Black, leftMargin + 70, topMargin + 133);
            // COLUMNA 1
            if(XCOPIACONST)
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 146);
            else
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 146);
            gfx.DrawString("CONSTITUCION DE LA EMPRESA", font9, XBrushes.Black, leftMargin + 90, topMargin + 146);
            
            if(XCOPIARUC)
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 156);
            else
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 156);           
            gfx.DrawString("RUC", font9, XBrushes.Black, leftMargin + 90, topMargin + 156);
            
            if(XCOPIADNI)
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 166);
            else
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 166);
            gfx.DrawString("DNI", font9, XBrushes.Black, leftMargin + 90, topMargin + 166);
            
            // COLUMNA 2
            if(XLICFUNC)
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 146);
            else
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 146);
            gfx.DrawString("LIC. DE FUNCIONAMIENTO", font9, XBrushes.Black, leftMargin + 320, topMargin + 146);
            
            if(XTITLOCAL)
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 156);
            else
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 156);
            gfx.DrawString("TITULO DE PROPIEDAD", font9, XBrushes.Black, leftMargin + 320, topMargin + 156);
            
            if(XCONTLOCAL)
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 166);
            else
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 166);
            gfx.DrawString("CONTRATO DE LOCAL", font9, XBrushes.Black, leftMargin + 320, topMargin + 166);
            
            if(XRECIBO)
                gfx.DrawString(sim1 + "X" + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 176);
            else
                gfx.DrawString(sim1 + space + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 176);
            gfx.DrawString("RECIBO AGUA O LUZ", font9, XBrushes.Black, leftMargin + 320, topMargin + 176);


            gfx.DrawString("II.", fontB9, XBrushes.Black, leftMargin + 20, topMargin + 200);
            gfx.DrawString("FACTORES DE EVALUACION CREDITICIA:", fontB9, XBrushes.Black, leftMargin + 50, topMargin + 200);

            // COLUMNA 1
            gfx.DrawString("3.", font9, XBrushes.Black, leftMargin + 50, topMargin + 215);
            gfx.DrawString("COMPORTAMIENTO DE PAGO", font9, XBrushes.Black, leftMargin + 70, topMargin + 215);
                        
            gfx.DrawString("3.1", font9, XBrushes.Black, leftMargin + 70, topMargin + 228);
            gfx.DrawString("PROTESTOS DE LETRA", font9, XBrushes.Black, leftMargin + 90, topMargin + 228);
            string x1 = space, x2 = space;
            if (XTIENLETR)
                x1 = "X";
            else
                x2 = "X";            
            gfx.DrawString(sim1 + x1 + sim2, font9, XBrushes.Black, leftMargin + 90, topMargin + 241);
            gfx.DrawString("SI TIENE", font9, XBrushes.Black, leftMargin + 110, topMargin + 241);
            gfx.DrawString(sim1 + x2 + sim2, font9, XBrushes.Black, leftMargin + 90, topMargin + 251);
            gfx.DrawString("NO TIENE", font9, XBrushes.Black, leftMargin + 110, topMargin + 251);

            gfx.DrawString("3.2", font9, XBrushes.Black, leftMargin + 70, topMargin + 264);
            gfx.DrawString("INCUMPLIMIENTO DE PAGO", font9, XBrushes.Black, leftMargin + 90, topMargin + 264);
            string x3 = space, x4 = space;
            if (XTIENMORO)
                x3 = "X";
            else
                x4 = "X";    
            gfx.DrawString(sim1 + x3 + sim2, font9, XBrushes.Black, leftMargin + 90, topMargin + 277);
            gfx.DrawString("SI TIENE", font9, XBrushes.Black, leftMargin + 110, topMargin + 277);
            gfx.DrawString(sim1 + x4 + sim2, font9, XBrushes.Black, leftMargin + 90, topMargin + 287);
            gfx.DrawString("NO TIENE", font9, XBrushes.Black, leftMargin + 110, topMargin + 287);

            gfx.DrawString("4.", font9, XBrushes.Black, leftMargin + 50, topMargin + 310);
            gfx.DrawString("ANTECEDENTES INFOCORP", font9, XBrushes.Black, leftMargin + 70, topMargin + 310);
            string x5 = space, x6 = space;
            if (XMOROSO)
                x5 = "X";
            else
                x6 = "X";
            gfx.DrawString(sim1 + x5 + sim2, font9, XBrushes.Black, leftMargin + 90, topMargin + 323);
            gfx.DrawString("SI TIENE", font9, XBrushes.Black, leftMargin + 110, topMargin + 323);
            gfx.DrawString(sim1 + x6 + sim2, font9, XBrushes.Black, leftMargin + 90, topMargin + 333);
            gfx.DrawString("NO TIENE", font9, XBrushes.Black, leftMargin + 110, topMargin + 333);

            // COLUMNA 2
            gfx.DrawString("5.", font9, XBrushes.Black, leftMargin + 300, topMargin + 215);
            gfx.DrawString("REFERENCIAS COMERCIALES", font9, XBrushes.Black, leftMargin + 320, topMargin + 215);
            string xva1 = space, xva2 = space, xva3 = space;
            if (XREFCOMER.Length > 0)
            {
                if (XREFCOMER.ToString() == "B")
                    xva1 = "X";
                else if (XREFCOMER.ToString() == "R")
                    xva2 = "X";
                else if (XREFCOMER.ToString() == "M")
                    xva3 = "X";
            }
            gfx.DrawString(sim1 + xva1 + sim2, font9, XBrushes.Black, leftMargin + 320, topMargin + 228);
            gfx.DrawString("BUENA", font9, XBrushes.Black, leftMargin + 340, topMargin + 228);
            gfx.DrawString(sim1 + xva2 + sim2, font9, XBrushes.Black, leftMargin + 320, topMargin + 238);
            gfx.DrawString("REGULAR", font9, XBrushes.Black, leftMargin + 340, topMargin + 238);
            gfx.DrawString(sim1 + xva3 + sim2, font9, XBrushes.Black, leftMargin + 320, topMargin + 248);
            gfx.DrawString("MALA", font9, XBrushes.Black, leftMargin + 340, topMargin + 248);

            gfx.DrawString("6.", font9, XBrushes.Black, leftMargin + 300, topMargin + 271);
            gfx.DrawString("REFERENCIAS BANCARIAS", font9, XBrushes.Black, leftMargin + 320, topMargin + 271);
            string xva4 = space, xva5 = space, xva6 = space;
            if (XREFBANCA.Length > 0)
            {
                if (XREFBANCA.ToString() == "B")
                    xva4 = "X";
                else if (XREFBANCA.ToString() == "R")
                    xva5 = "X";
                else if (XREFBANCA.ToString() == "M")
                    xva6 = "X";
            }
            gfx.DrawString(sim1 + xva4 + sim2, font9, XBrushes.Black, leftMargin + 320, topMargin + 284);
            gfx.DrawString("BUENA", font9, XBrushes.Black, leftMargin + 340, topMargin + 284);
            gfx.DrawString(sim1 + xva5 + sim2, font9, XBrushes.Black, leftMargin + 320, topMargin + 294);
            gfx.DrawString("REGULAR", font9, XBrushes.Black, leftMargin + 340, topMargin + 294);
            gfx.DrawString(sim1 + xva6 + sim2, font9, XBrushes.Black, leftMargin + 320, topMargin + 304);
            gfx.DrawString("MALA", font9, XBrushes.Black, leftMargin + 340, topMargin + 304);


            gfx.DrawString("7.", font9, XBrushes.Black, leftMargin + 300, topMargin + 327);
            gfx.DrawString("EVALUACION PATRIMONIAL", font9, XBrushes.Black, leftMargin + 320, topMargin + 327);

            gfx.DrawString("7.1", font9, XBrushes.Black, leftMargin + 320, topMargin + 340);
            gfx.DrawString("BIENES MUEBLES", font9, XBrushes.Black, leftMargin + 340, topMargin + 340);
            string x7 = space, x8 = space;
            if (XBIENMUEB)
                x7 = "X";
            else
                x8 = "X";
            gfx.DrawString(sim1 + x7 + sim2, font9, XBrushes.Black, leftMargin + 340, topMargin + 351);
            gfx.DrawString("SI TIENE", font9, XBrushes.Black, leftMargin + 360, topMargin + 351);
            gfx.DrawString(sim1 + x8 + sim2, font9, XBrushes.Black, leftMargin + 340, topMargin + 361);
            gfx.DrawString("NO TIENE", font9, XBrushes.Black, leftMargin + 360, topMargin + 361);

            gfx.DrawString("7.2", font9, XBrushes.Black, leftMargin + 320, topMargin + 374);
            gfx.DrawString("BIENES INMUEBLES", font9, XBrushes.Black, leftMargin + 340, topMargin + 374);
            string x9 = space, x10 = space;
            if (XBIENINMUEB)
                x9 = "X";
            else
                x10 = "X";
            gfx.DrawString(sim1 + x9 + sim2, font9, XBrushes.Black, leftMargin + 340, topMargin + 387);
            gfx.DrawString("SI TIENE", font9, XBrushes.Black, leftMargin + 360, topMargin + 387);
            gfx.DrawString(sim1 + x10 + sim2, font9, XBrushes.Black, leftMargin + 340, topMargin + 397);
            gfx.DrawString("NO TIENE", font9, XBrushes.Black, leftMargin + 360, topMargin + 397);


            //----------
            gfx.DrawString("III.", fontB9, XBrushes.Black, leftMargin + 20, topMargin + 420);
            gfx.DrawString("OPINION AREA DE VENTAS HORIZONTALES", fontB9, XBrushes.Black, leftMargin + 50, topMargin + 420);
            string xcli1 = space, xcli2 = space, xcli3 = space;
            if (XEVALCXCOB.Length > 0)
            {
                if (XEVALCXCOB.ToString() == "CA")
                    xcli1 = "X";
                else if (XEVALCXCOB.ToString() == "CN")
                    xcli2 = "X";
                else if (XEVALCXCOB.ToString() == "CD")
                    xcli3 = "X";
            }
            gfx.DrawString(sim1 + xcli1 + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 435);
            gfx.DrawString("CLIENTE ACEPTABLE", font9, XBrushes.Black, leftMargin + 90, topMargin + 435);
            gfx.DrawString(sim1 + xcli2 + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 445);
            gfx.DrawString("CLIENTE NO ACEPTABLE", font9, XBrushes.Black, leftMargin + 90, topMargin + 445);
            gfx.DrawString(sim1 + xcli3 + sim2, font9, XBrushes.Black, leftMargin + 70, topMargin + 455);
            gfx.DrawString("CLIENTE DUDOSO", font9, XBrushes.Black, leftMargin + 90, topMargin + 455);

            gfx.DrawString("OTROS COMENTARIOS:", font9, XBrushes.Black, leftMargin + 50, topMargin + 475);
            gfx.DrawString("» "+XOBSCXCOB, font9, XBrushes.Black, leftMargin + 80, topMargin + 490);

            gfx.DrawString("IV.", fontB9, XBrushes.Black, leftMargin + 20, topMargin + 520);
            gfx.DrawString("APROBACIÓN GERENCIA GENERAL", fontB9, XBrushes.Black, leftMargin + 50, topMargin + 520);
            string x11 = space, x12 = space;
            if (XAPROBGERE == "32")
                x11 = "X";
            else if (XAPROBGERE == "39")
                x12 = "X";
            gfx.DrawString(sim1 + x11 + sim2, font9, XBrushes.Black, leftMargin + 200, topMargin + 533);
            gfx.DrawString("APROBADO", font9, XBrushes.Black, leftMargin + 220, topMargin + 533);
            gfx.DrawString(sim1 + x12 + sim2, font9, XBrushes.Black, leftMargin + 300, topMargin + 533);
            gfx.DrawString("NO APROBADO", font9, XBrushes.Black, leftMargin + 320, topMargin + 533);

            gfx.DrawString("OBSERVACIONES:", font9, XBrushes.Black, leftMargin + 50, topMargin + 553);
            gfx.DrawString("» " + XOBSGEREN, font9, XBrushes.Black, leftMargin + 80, topMargin + 568);          
            string texto = "NOTA: A ESTE FORMATO SE DEBERA ANEXAR LA DOCUMENTACIÓN CORRESPONDIENTE";
            gfx.DrawString(texto, fontB9, XBrushes.Black, leftMargin + 50, topMargin + 598);


            //SE ENVIA EL PDF AL BROWSER
            MemoryStream stream = new MemoryStream();
            document.Save(stream, false);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", stream.Length.ToString());
            Response.BinaryWrite(stream.ToArray());
            Response.Flush();
            stream.Close();
            Response.End();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

}