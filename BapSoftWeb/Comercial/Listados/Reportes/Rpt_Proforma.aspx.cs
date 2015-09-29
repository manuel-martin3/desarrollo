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
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;
using System.IO;

public partial class Reportes_Rpt_Proforma : System.Web.UI.Page
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
        Rpt_Proforma();
    }

    private void Rpt_Proforma()
    {
        try
        {
            //Se crea el documento PDF
            PdfDocument document = new PdfDocument();

            //Se configura los datos dela pagina
            document.Info.Title = "»» PROFORMA DE PEDIDOS ««";
            document.Info.Author = "HVR";

            //Se crea la pagina A4
            PdfPage page = document.AddPage();
            page.Orientation = PageOrientation.Portrait;

            Int16 intFila = 20;
            Int16 intColumna = 20;
            Int16 npag = 1;
            Int16 numFilas = 0;
            Int16 numColumna = 0;
            String imagenn = "";
            XFont font2;

            //Se crea el objeto dibujo            
            XGraphics gfx = XGraphics.FromPdfPage(page);            
            XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);            
            XTextFormatter tf = new XTextFormatter(gfx);


            //fuente de texto
            string fuente = "MS Mincho";
            string fuente02 = "CCode39";
            string XTEXTO = "";
            //string fuente02 = "CCode39";

            //Se crea e tipo de letra
            try
            {
                font = new XFont(fuente, 10, XFontStyle.Regular, new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always));
            }
            catch (Exception exc)
            {
            }
            // XFont font = new XFont(fuente, 9, XFontStyle.Regular);
            XPen pen = new XPen(XColors.Navy, 1);
            string anio = Convert.ToString(DateTime.Now).Substring(6, 10);

            #region OBTENIENDO VALORES DE SESSION
            // DECLARANDO VARIBALES QUE RECIBIMOS DE SESSION            
            string XEMPRESANAME = Session["ssEmpresaName"].ToString();
            string XEMPRESARUC = Session["ssEmpresaRuc"].ToString();
            string XGERENTEGENE = Session["ssGerenteGeneral"].ToString();
            string XGERENTEDNI = Session["ssGerenteNrodni"].ToString();
            string XPARTELECTRO = Session["ssPartElectro"].ToString();

            Double XIMPOBRUTO = 0, XIMPONETO = 0;
            string XNUMDOC = "", XSERDOC = "", XTASADESCTO = "", XPLAZODAY = "", XNUMDOCS = "", XMEDIOPAGO = "", XNDIAS = "",
                   XVENDORNAME = "", XCTACTENAME = "", XCLINMRUC = "", XDIREC = "", XREPLEGALNAME = "", XREPLEGALDNI = "",
                   XFECHA = "", XCO = "", XCR = "", XNMONE = "", XIGV = "";
            //VARIABLES RECIEN AGREGADAS EN LA BD
            string XREGPUBLICO = "", XPARTELECTRO2 = "", XESTCIVIL = "";

            tb_cxc_pedidocabBL BL = new tb_cxc_pedidocabBL();
            tb_cxc_pedidocab BE = new tb_cxc_pedidocab();
            DataTable TablaProfor = new DataTable();
            BE.tipdoc = Session["xtipdoc"].ToString();
            BE.serdoc = Session["xserdoc"].ToString();
            BE.numdoc = Session["xnumdoc"].ToString();
            TablaProfor = BL.GetAll2(Session["ssEmpresaID"].ToString(), BE).Tables[0];
            foreach (DataRow fila in TablaProfor.Rows)
            {
                XNUMDOC = fila["numdoc"].ToString();
                XSERDOC = fila["serdoc"].ToString();
                XTASADESCTO = fila["tasadescto"].ToString();
                XPLAZODAY = fila["plazoday"].ToString();
                XNUMDOCS = fila["numdocs"].ToString();
                XMEDIOPAGO = fila["descripcion"].ToString();
                XNDIAS = fila["ndias"].ToString();
                XVENDORNAME = fila["vendorname"].ToString();
                XCTACTENAME = fila["ctactename"].ToString();
                XCLINMRUC = fila["nmruc"].ToString();
                XDIREC = fila["direc"].ToString();
                XREPLEGALNAME = fila["replegal_name"].ToString();
                XREPLEGALDNI = fila["replegal_dni"].ToString();
                XFECHA = fila["fecha"].ToString();
                if (fila["condventaid"].ToString() == "02")
                    XCR = "X";
                else
                    XCO = "X";
                XNMONE = fila["precios"].ToString();
                XIGV = fila["incluye_igv"].ToString();
                XREGPUBLICO = fila["regpublico"].ToString();
                XPARTELECTRO2 = fila["partelectro"].ToString();
                XESTCIVIL = fila["estcivil"].ToString();
                XIMPOBRUTO = Convert.ToDouble(fila["impobruto"].ToString());
                XIMPONETO = Convert.ToDouble(fila["imponeto"].ToString());
            }
            #endregion


            #region HOJA 01
            font = new XFont("Arial", 11, XFontStyle.Underline);
            gfx.DrawString("CONTRATO DE COMPRA VENTA A CRÉDITO", font, XBrushes.Black, new XRect(intColumna + 170, intFila + 15, 10, 10), XStringFormats.TopLeft);

            font = new XFont("Arial", 9, XFontStyle.Bold);
            gfx.DrawString(("CONTRATO Nº " + XNUMDOC + "-VH/PIEERS-" + XSERDOC + ":").PadRight(25, ' '),
                  font, XBrushes.Black, new XRect(intColumna + 30, intFila + 40, 10, 10), XStringFormats.TopLeft);

            // Cabecera Cambia Deacuerdo al NUMERO DE RUC
            if (Equivalencias.Left(XCLINMRUC, 1) == "2")
            {
                #region PERSONA JURIDICA
                XTEXTO ="Conste por el presente documento, que celebran de una parte " + XEMPRESANAME + " con "+
                        "RUC No." + XEMPRESARUC + ", con domicilio legal en Av. Abancay No. 186 Cercado de Lima, representado "+
                        "por su Gerente General, Srta. " + XGERENTEGENE + ", identificada "+
                        "con DNI No." + XGERENTEDNI + "según poder inscrito en la partida No." + XPARTELECTRO + " del Registro de Personas "+
                        "Jurídicas de Lima y Callao, a quien en adelante se le denominará LA EMPRESA, y de otra parte la Empresa "+
                        "" + XCTACTENAME + " con RUC Nº " + XCLINMRUC + " "+
                        "con domicilio en JR." + XDIREC + " "+
                        "debidamente representado por su Gerente General, el Sr(a)." + XREPLEGALNAME + ", según poder Nº" + XPARTELECTRO2 + " "+
                        "inscritos en los Registros Públicos de " + XREGPUBLICO + " identificado con DNI Nº." + XREPLEGALDNI + ", a quien en adelante "+
                        "se le denominara EL CLIENTE en los términos y condiciones siguientes: ";
                #endregion
            }
            else
            {
                #region PERSONA NATURAL
                String estado = "";
                if (XESTCIVIL.ToString() == "1")
                {
                    estado = "CASADO";
                }
                else
                {
                    estado = "SOLTERO";
                }

                XTEXTO = "Conste por el presente documento, que celebran de una parte " + XEMPRESANAME + " con " +
                         "RUC No." + XEMPRESARUC + ", con domicilio legal en Av. Abancay No. 186 Cercado de Lima, representado " +
                         "por su Gerente General, Srta. " + XGERENTEGENE + ", identificada con DNI No." + XGERENTEDNI + " " +
                         "según poder inscrito en la partida No." + XPARTELECTRO + " del Registro de Personas Jurídicas de Lima y Callao, " +
                         "a quien en adelante se le denominará LA EMPRESA y de otra parte " +
                         "el Señor(a)." + XCTACTENAME.Trim() + " con DNI Nº." + Equivalencias.Mid(XCLINMRUC, 3, 8) + ", estado civil " + estado + " " +
                         "y domiciliado en " + XDIREC.Trim() + " a quien en adelante " +
                         "se le denominara EL CLIENTE en los términos y condiciones siguientes: ";       
                #endregion
            }


            XRect rect = new XRect(intColumna + 30, intFila + 60, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(XTEXTO, font, XBrushes.Black, rect, XStringFormats.TopLeft);


            /* DECLARANDO EL TEXTO 02 */
            gfx.DrawString(("PRIMERO.-  LA EMPRESA, es una Institución que se dedica a la confección y venta de prendas de vestir.").PadRight(19, ' '),
                  font, XBrushes.Black, new XRect(intColumna + 30, intFila + 170, 10, 10), XStringFormats.TopLeft);
                            
            rect = new XRect(50, 210, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("SEGUNDO.- Por el presente contrato, LA EMPRESA vende a EL CLIENTE los  productos de su fabricación que " + 
                          "se detallan en el anexo 01 que forma parte del presente contrato.",font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(50, 240, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("TERCERO.- LA EMPRESA y EL CLIENTE de común acuerdo establecen que la presente venta es al crédito "+
                          "con las siguientes condiciones comerciales: ", font, XBrushes.Black, rect, XStringFormats.TopLeft);


            gfx.DrawString("1)  El valor total de la venta, con el " + XTASADESCTO + "% de descuento es de S/. " + XIMPONETO.ToString("#,###,#00.00") + "(nuevos soles), incluido IGV.",
                font, XBrushes.Black, new XRect(intColumna + 30, intFila + 240, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString("2)  El plazo del crédito es de " + XPLAZODAY + " días ",
                font, XBrushes.Black, new XRect(intColumna + 30, intFila + 250, 10, 10), XStringFormats.TopLeft);
            
            rect = new XRect(intColumna + 30, intFila + 260, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("3)  EL CLIENTE, pagará el crédito total con " + XNUMDOCS + " " + XMEDIOPAGO + " por los montos y fechas " +
                          "de vencimiento que se indican a continuación:", font, XBrushes.Black, rect, XStringFormats.TopLeft);
          



            //START RECTANGULO****************************************************************************************************************************************

            pen = new XPen(XColors.LightBlue, 5);
            gfx.DrawRoundedRectangle(pen, intColumna + 70, intFila + 300, 245, 100, 25, 25);


            // Pintamos los Datos de la Tabla de Session
            DataTable tabla01 = new DataTable();
            tabla01 = (DataTable)Session["Tabla01"];

            // AQUI DIBUJAMOS LAS CABECERAS DEL DETALLE
            font = new XFont("Abadi MT Condensed Light", 10, XFontStyle.Bold);
            gfx.DrawString(("DOC. DE PAGO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 75, intFila + 305, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("MONTO (SOLES)").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 166, intFila + 305, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("FECHA VCTO.").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 250, intFila + 305, 10, 10), XStringFormats.TopLeft);

            //Trasamos las Lineas de la Cabecera
            pen = new XPen(XColors.LightBlue, 2);
            //pen.LineCap = XLineCap.Flat;
            gfx.DrawLine(pen, 92, 335, 335, 335);
            //gfx.DrawLine(XPens.Black, 92, 335, 335, 335);

            //CARGAMOS EL DETALLE
            int n = 15;
            foreach (DataRow fila in tabla01.Rows)
            {
                Double monto = Convert.ToDouble(fila["monto"].ToString());
                font = new XFont("Abadi MT Condensed Light", 9, XFontStyle.Bold);
                gfx.DrawString((fila["num_interno"].ToString()).PadRight(19, ' '),
                    font, XBrushes.Black, new XRect(intColumna + 75, intFila + 305 + n, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((monto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 170, intFila + 305 + n, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString(Equivalencias.Left((fila["fechven"].ToString()), 10),
                   font, XBrushes.Black, new XRect(intColumna + 250, intFila + 305 + n, 10, 10), XStringFormats.TopLeft);
                n = n + 10;
            }

            // PIE DEL RECTANGULO
            gfx.DrawLine(pen, 92, 405, 335, 405);
            gfx.DrawString(("TOTAL CREDITO :                   " + XIMPONETO.ToString("##,###,##0.00")).PadRight(19, ' '),
                    font, XBrushes.Black, new XRect(intColumna + 72, intFila + 385, 10, 10), XStringFormats.TopLeft);

            //END RECTANGULO *********************************************************************************************************************************************


            font = new XFont("Arial", 9, XFontStyle.Bold);

            rect = new XRect(intColumna + 30, intFila + 410, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("4)  El pago de las letras se efectuara en el Banco de Crédito del Perú, para este efecto EL CLIENTE " +
                          "deberá mencionar el 'número único' de la respectiva letra de cambio.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(intColumna + 30, intFila + 430, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("5) LA EMPRESA, efectuará el despacho de los productos a los " + XNDIAS + " días de haberse suscrito el presente " +
                          "contrato, en la agencia de transporte que indique EL CLIENTE.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(intColumna + 30, intFila + 450, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("6) EL CLIENTE, asume los costos de transporte de los productos adquiridos siendo de su entera responsabilidad " +
                          "el traslado de los mismos desde la agencia de transporte hasta el lugar o local comercial de destino.", font, XBrushes.Black, rect, XStringFormats.TopLeft);



            rect = new XRect(intColumna + 30, intFila + 480, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("CUARTO.- Si EL CLIENTE incumpliera con el pago de sus letras, LA EMPRESA podrá  ejecutar dichas letras " +
                          "por la vía legal.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(intColumna + 30, intFila + 510, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("QUINTO.-  Si EL CLIENTE pagara el crédito total antes del plazo acordado, se actualizará  las tasas de " +
                          "descuento al plazo que corresponda mediante notas de crédito.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(intColumna + 30, intFila + 540, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("SEXTO.- Si EL CLIENTE incumpliera con el pago total de los créditos concedidos en los plazos acordados, " +
                          "se actualizará las tasas de descuento a los plazos que corresponda mediante notas de débito.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(intColumna + 30, intFila + 570, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("SÉPTIMO.- Si EL CLIENTE, por motivos injustificados, demore con realizar el pago total o lo que resta " +
                          "de su deuda por más de 90 días perderá el 50 % del descuento concedido.", font, XBrushes.Black, rect, XStringFormats.TopLeft);

            rect = new XRect(intColumna + 30, intFila + 600, 500, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString("OCTAVO.- Las partes acuerdan que para todo lo relacionado con el cumplimiento de las cláusulas del " +
                          "presente contrato de  compra venta, se someten a la jurisdicción  de los jueces y tribunales de Lima, "+
                          "o mediante arbitraje, señalando sus domicilios en la parte introductoria del presente contrato.", font, XBrushes.Black, rect, XStringFormats.TopLeft);          

            gfx.DrawString(("" + XFECHA + "").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 310, intFila + 660, 10, 10), XStringFormats.TopLeft);


            // VALIDAMOS PRIMERO QUE TIPO DE PERSONA ES NATURAL O  JURIDICA 
            // 2 = JURIDICA
            // 1 = NATURAL
            if (Equivalencias.Left(XCLINMRUC, 1) == "2")
            {
                // VALIDAMOS EL ESTADO CIVIL DEL CLIENTE
                // 1 = CASADO
                // 2 = SOLTERO
                if (XESTCIVIL.ToString() == "1")
                {
                    gfx.DrawString(("LA EMPRESA").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 100, intFila + 700, 10, 10), XStringFormats.TopLeft);
                    gfx.DrawString(("EL CLIENTE").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 310, intFila + 700, 10, 10), XStringFormats.TopLeft);
                }
                else
                {
                    gfx.DrawString(("LA EMPRESA").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 100, intFila + 700, 10, 10), XStringFormats.TopLeft);
                    gfx.DrawString(("EL CLIENTE").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 310, intFila + 700, 10, 10), XStringFormats.TopLeft);
                }
            }

            if (Equivalencias.Left(XCLINMRUC, 1) == "1")
            {
                if (XESTCIVIL.ToString() == "1")
                {
                    gfx.DrawString(("LA EMPRESA").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 100, intFila + 700, 10, 10), XStringFormats.TopLeft);
                    gfx.DrawString(("EL CLIENTE").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 210, intFila + 700, 10, 10), XStringFormats.TopLeft);
                    gfx.DrawString(("EL CONYUGUE").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 320, intFila + 700, 10, 10), XStringFormats.TopLeft);
                }
                else
                {
                    gfx.DrawString(("LA EMPRESA").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 100, intFila + 700, 10, 10), XStringFormats.TopLeft);
                    gfx.DrawString(("EL CLIENTE").PadRight(19, ' '),
                        font, XBrushes.Black, new XRect(intColumna + 310, intFila + 700, 10, 10), XStringFormats.TopLeft);
                }
            }

            #endregion


            //SE CREA LA PAGINA A4 NUMERO 2
            PdfPage page2 = document.AddPage();
            page2.Orientation = PageOrientation.Portrait;
            XGraphics gfx2 = XGraphics.FromPdfPage(page2);
            tf = new XTextFormatter(gfx2);

            font = new XFont("Arial", 9.5, XFontStyle.Bold);
            gfx2.DrawString("ANEXO 01", font, XBrushes.Black, new XRect(intColumna + 260, intFila + 15, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString("DETALLE DE PRODUCTOS VENDIDOS", font, XBrushes.Black, new XRect(intColumna + 200, intFila + 25, 10, 10), XStringFormats.TopLeft);

            font = new XFont("Arial", 10, XFontStyle.Bold);
            font2 = new XFont("Arial", 9);
            gfx2.DrawString("VENDEDOR", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 50, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XVENDORNAME + "", font2, XBrushes.Black, new XRect(intColumna + 90, intFila + 50, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString("CLIENTE", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 60, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XCTACTENAME + "", font2, XBrushes.Black, new XRect(intColumna + 90, intFila + 60, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString("RUC", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 70, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XCLINMRUC + "", font2, XBrushes.Black, new XRect(intColumna + 90, intFila + 70, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString("DIRECC", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 80, 10, 10), XStringFormats.TopLeft);
            //gfx2.DrawString(": " + XDIREC + "", font2, XBrushes.Black, new XRect(intColumna + 90, intFila + 90, 10, 10), XStringFormats.TopLeft);

            rect = new XRect(intColumna + 90, intFila + 80, 430, 100);
            gfx2.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(": " + XDIREC + "", font2, XBrushes.Black, rect, XStringFormats.TopLeft);

            gfx2.DrawString("NUM-CONTRATO", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 100, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XNUMDOC + "", font2, XBrushes.Black, new XRect(intColumna + 120, intFila + 100, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString("COND-VENTA : ", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 110, 10, 10), XStringFormats.TopLeft);

            // DIBUJAR UN RECTANGULO
            pen = new XPen(XColors.LightBlue, 2);
            gfx2.DrawRoundedRectangle(pen, intColumna + 57, intFila + 125, 90, 30, 25, 25);
            gfx2.DrawString("CONTADO", font, XBrushes.Black, new XRect(intColumna + 60, intFila + 128, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XCO + "", font2, XBrushes.Black, new XRect(intColumna + 120, intFila + 128, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString("CREDITO", font, XBrushes.Black, new XRect(intColumna + 60, intFila + 139, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XCR + "", font2, XBrushes.Black, new XRect(intColumna + 120, intFila + 139, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString("PLAZO EN DIAS", font, XBrushes.Black, new XRect(intColumna + 150, intFila + 139, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XPLAZODAY + " DIAS", font2, XBrushes.Black, new XRect(intColumna + 240, intFila + 139, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString("VENTA TOTAL A PRECIO DE LISTA", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 160, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XIMPOBRUTO.ToString("##,###,##0.00") + "", font2, XBrushes.Black, new XRect(intColumna + 240, intFila + 160, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString("TASA DE DESCUENTO", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 170, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XTASADESCTO + "%", font2, XBrushes.Black, new XRect(intColumna + 240, intFila + 170, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString("VENTA TOTAL CON DESCUENTO", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 180, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XIMPONETO.ToString("##,###,##0.00") + "", font2, XBrushes.Black, new XRect(intColumna + 240, intFila + 180, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString("PRECIOS DE LOS PRODUCTOS", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 190, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XNMONE + "", font2, XBrushes.Black, new XRect(intColumna + 240, intFila + 190, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString("LOS PRECIOS INCLUYEN IGV", font, XBrushes.Black, new XRect(intColumna + 30, intFila + 200, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(": " + XIGV + "", font2, XBrushes.Black, new XRect(intColumna + 240, intFila + 200, 10, 10), XStringFormats.TopLeft);


            //START RECTANGULO II ****************************************************************************************************************************************

            pen = new XPen(XColors.LightBlue, 3);
            //gfx2.DrawRoundedRectangle(pen, intColumna + 0, intFila + 220, 550, 40, 25, 25);


            // Pintamos los Datos de la Tabla de Session
            DataTable tabla02 = new DataTable();
            tabla02 = (DataTable)Session["Tabla02"];

            // AQUI DIBUJAMOS LAS CABECERAS DEL DETALLE
            font = new XFont("Abadi MT Condensed Light", 8.5, XFontStyle.Bold);
            gfx2.DrawString(("CODIGO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 5, intFila + 228, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("MARCA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 35, intFila + 228, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("PRODUCTO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 80, intFila + 228, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("COLOR").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 250, intFila + 228, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("TALLA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 295, intFila + 228, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("CANTIDAD").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 318, intFila + 228, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString(("PRECIOS DE").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 350, intFila + 225, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("LISTA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 358, intFila + 235, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString(("VENTAS A").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 400, intFila + 225, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("PRECIOS DE LISTA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 390, intFila + 235, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString(("PRECIOS CON").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 450, intFila + 225, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("DESCUENTO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 451, intFila + 235, 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString(("VENTAS CON").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 500, intFila + 225, 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("DESCUENTO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 501, intFila + 235, 10, 10), XStringFormats.TopLeft);

            pen = new XPen(XColors.LightBlue, 2);
            gfx2.DrawLine(pen, 20, 265, 570, 265);


            //CARGAMOS EL DETALLE
            int n2 = 15;
            int nfilas = 40;
            foreach (DataRow fila in tabla02.Rows)
            {
                Double precbruto = Convert.ToDouble(fila["precbruto"].ToString());
                Double impobruto = Convert.ToDouble(fila["impobruto"].ToString());
                Double precneto = Convert.ToDouble(fila["precneto"].ToString());
                Double imponeto = Convert.ToDouble(fila["imponeto"].ToString());

                font = new XFont("Abadi MT Condensed Light", 7.5, XFontStyle.Bold);
                gfx2.DrawString((fila["articidold"].ToString()).PadRight(19, ' '),
                    font, XBrushes.Black, new XRect(intColumna + 5, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((fila["marcaname"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 35, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((fila["articname"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 80, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((fila["colorname"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 250, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((fila["talla"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 299, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((fila["cantidad"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 318, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((precbruto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 358, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((impobruto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 400, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((precneto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 458, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx2.DrawString((imponeto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(intColumna + 508, intFila + 235 + n2, 10, 10), XStringFormats.TopLeft);
                n2 = n2 + 10;
                nfilas = nfilas + 12;
            }

            //nfilas = nfilas;

            gfx2.DrawRoundedRectangle(pen, intColumna + 0, intFila + 220, 550, nfilas, 25, 25);
            //PIE DEL RECTANGULO
            gfx2.DrawLine(pen, 20, intFila + 220 + (nfilas - 12), 570, intFila + 220 + (nfilas - 12));
            font = new XFont("Abadi MT Condensed Light", 8, XFontStyle.Bold);
            gfx2.DrawString(("TOTAL").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 80, intFila + 220 + (nfilas - 10), 10, 10), XStringFormats.TopLeft);

            gfx2.DrawString((XIMPOBRUTO.ToString("##,###,##0.00")).PadRight(19, ' '),
                font, XBrushes.Black, new XRect(intColumna + 400, intFila + 220 + (nfilas - 10), 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString((XIMPONETO.ToString("##,###,##0.00")).PadRight(19, ' '),
               font, XBrushes.Black, new XRect(intColumna + 508, intFila + 220 + (nfilas - 10), 10, 10), XStringFormats.TopLeft);

            //END RECTANGULO *********************************************************************************************************************************************


            gfx2.DrawString(("FIRMA GERENCIA GENERAL").PadRight(19, ' '),
               font, XBrushes.Black, new XRect(intColumna + 80, intFila + 220 + (nfilas + 30), 10, 10), XStringFormats.TopLeft);
            gfx2.DrawString(("FIRMA CLIENTE").PadRight(19, ' '),
               font, XBrushes.Black, new XRect(intColumna + 295, intFila + 220 + (nfilas + 30), 10, 10), XStringFormats.TopLeft);


            //Se envia el PDF al browser
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