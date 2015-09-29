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

public partial class Comercial_Reportes_Rpt_Pedido : System.Web.UI.Page
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
        Rpt_Pedido();
    }


    private void Rpt_Pedido()
    {
        try
        {
            //Se crea el documento PDF
            PdfDocument document = new PdfDocument();

            //Se configura los datos dela pagina
            document.Info.Title = "»» PEDIDO ««";
            document.Info.Author = "HVR";

            //Se crea la pagina A4
            PdfPage page = document.AddPage();
            page.Orientation = PageOrientation.Portrait;

            //Se crea el objeto dibujo
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XPen pen = new XPen(XColors.Navy, 1);
            string anio = Convert.ToString(DateTime.Now).Substring(6, 10);
            XRect rect;
            XFont fontB18 = new XFont("Abadi MT Condensed Light", 20, XFontStyle.Bold);
            XFont fontB12 = new XFont("Abadi MT Condensed Light", 12, XFontStyle.Bold);
            XFont fontB9 = new XFont("Abadi MT Condensed Light", 9, XFontStyle.Bold);
            XFont font9 = new XFont("Abadi MT Condensed Light", 9);
            XFont font; XFont font2;
            XTextFormatter tf = new XTextFormatter(gfx);

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

            #region OBTENIENDO VALORES DE SESSION
            // DECLARANDO VARIBALES QUE RECIBIMOS DE SESSION            
            string XEMPRESANAME = Session["ssEmpresaName"].ToString();
            string XEMPRESARUC = Session["ssEmpresaRuc"].ToString();
            string XGERENTEGENE = Session["ssGerenteGeneral"].ToString();
            string XGERENTEDNI = Session["ssGerenteNrodni"].ToString();
            string XPARTELECTRO = Session["ssPartElectro"].ToString();

            Double XIMPOBRUTO = 0, XIMPONETO = 0;
            string XNUMDOC = "", XSERDOC = "", XTASADESCTO = "", XPLAZODAY = "", XNUMDOCS = "", XMEDIOPAGO = "", XNDIAS = "",
                   XVENDORNAME = "", XCTACTENAME = "", XCLINMRUC = "", XDIREC = "", XDIRECENTREGA = "", XREPLEGALNAME = "", XREPLEGALDNI = "",
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
                XDIRECENTREGA = fila["direc_entrega"].ToString();
                XREPLEGALNAME = fila["replegal_name"].ToString();
                XREPLEGALDNI = fila["replegal_dni"].ToString();
                XFECHA = fila["fechdoc"].ToString();
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

            // TITULO    
            //gfx.DrawString("EMPRESA", fontB9, XBrushes.Black, leftMargin, topMargin + 20);
            //gfx.DrawString(": " + XEMPRESANAME, font9, XBrushes.Black, leftMargin + 30, topMargin + 20);
            gfx.DrawString("CANAL DE VENTAS", fontB9, XBrushes.Black, leftMargin, topMargin + 30);
            gfx.DrawString(": " + "VENTAS HORIZONTALES", font9, XBrushes.Black, leftMargin + 60, topMargin + 30);
            //gfx.DrawString("RUC", fontB9, XBrushes.Black, leftMargin, topMargin + 40);
            //gfx.DrawString(": " + XEMPRESARUC, font9, XBrushes.Black, leftMargin + 30, topMargin + 40);

            gfx.DrawString("PEDIDOS", fontB12, XBrushes.Black, leftMargin + 230, topMargin + 20);


            pen = new XPen(XColors.Black, 2);
            gfx.DrawRoundedRectangle(pen, leftMargin + 400, topMargin + 10, 140, 30, 15, 15);

            // CUADRO
            gfx.DrawString("PEDIDO", fontB9, XBrushes.Black, leftMargin + 410, topMargin + 20);
            gfx.DrawString(": PD-" + Session["xnumdoc"].ToString(), font9, XBrushes.Black, leftMargin + 450, topMargin + 20);
            gfx.DrawString("FECHA", fontB9, XBrushes.Black, leftMargin + 410, topMargin + 30);
            gfx.DrawString(": " + Equivalencias.Left(XFECHA, 10), font9, XBrushes.Black, leftMargin + 450, topMargin + 30);


            font = new XFont("Abadi MT Condensed Light", 10, XFontStyle.Bold);
            font2 = new XFont("Abadi MT Condensed Light", 9);
            gfx.DrawString("VENDEDOR", font, XBrushes.Black, new XRect(leftMargin, topMargin + 50, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XVENDORNAME + "", font2, XBrushes.Black, new XRect(leftMargin + 40, topMargin + 50, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString("CLIENTE", font, XBrushes.Black, new XRect(leftMargin, topMargin + 60, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XCTACTENAME + "", font2, XBrushes.Black, new XRect(leftMargin + 40, topMargin + 60, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString("RUC", font, XBrushes.Black, new XRect(leftMargin, topMargin + 70, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XCLINMRUC + "", font2, XBrushes.Black, new XRect(leftMargin + 40, topMargin + 70, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString("DIRECC", font, XBrushes.Black, new XRect(leftMargin, topMargin + 80, 10, 10), XStringFormats.TopLeft);
            
            rect = new XRect(leftMargin + 40, topMargin + 80, 200, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(": " + XDIREC + "", font2, XBrushes.Black, rect, XStringFormats.TopLeft);
            
            gfx.DrawString("DIR ENTREGA", font, XBrushes.Black, new XRect(leftMargin, topMargin + 100, 10, 10), XStringFormats.TopLeft);
            //gfx.DrawString(": " + XDIRECENTREGA + "", font2, XBrushes.Black, new XRect(leftMargin + 60, topMargin + 100, 10, 10), XStringFormats.TopLeft);

            rect = new XRect(leftMargin + 60, topMargin + 100, 200, 100);
            gfx.DrawRectangle(XBrushes.White, rect);
            tf.Alignment = XParagraphAlignment.Justify;
            tf.DrawString(": " + XDIRECENTREGA + "", font2, XBrushes.Black, rect, XStringFormats.TopLeft);


            gfx.DrawString("NUM-CONTRATO", font, XBrushes.Black, new XRect(leftMargin, topMargin + 110, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XNUMDOC + "", font2, XBrushes.Black, new XRect(leftMargin + 60, topMargin + 110, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString("COND-VENTA : ", font, XBrushes.Black, new XRect(leftMargin, topMargin + 120, 10, 10), XStringFormats.TopLeft);

            // DIBUJAR UN RECTANGULO
            pen = new XPen(XColors.Black, 2);
            gfx.DrawRoundedRectangle(pen, leftMargin + 57, topMargin + 125, 90, 30, 25, 25);
            gfx.DrawString("CONTADO", font, XBrushes.Black, new XRect(leftMargin + 70, topMargin + 128, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XCO + "", font2, XBrushes.Black, new XRect(leftMargin + 120, topMargin + 128, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString("CREDITO", font, XBrushes.Black, new XRect(leftMargin + 70, topMargin + 139, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XCR + "", font2, XBrushes.Black, new XRect(leftMargin + 120, topMargin + 139, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString("PLAZO EN DIAS", font, XBrushes.Black, new XRect(leftMargin + 150, topMargin + 139, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XPLAZODAY + " DIAS", font2, XBrushes.Black, new XRect(leftMargin + 210, topMargin + 139, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString("VENTA TOTAL A PRECIO DE LISTA", font, XBrushes.Black, new XRect(leftMargin, topMargin + 160, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XIMPOBRUTO.ToString("##,###,##0.00") + "", font2, XBrushes.Black, new XRect(leftMargin + 120, topMargin + 160, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString("TASA DE DESCUENTO", font, XBrushes.Black, new XRect(leftMargin, topMargin + 170, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XTASADESCTO + "%", font2, XBrushes.Black, new XRect(leftMargin + 120, topMargin + 170, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString("VENTA TOTAL CON DESCUENTO", font, XBrushes.Black, new XRect(leftMargin, topMargin + 180, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XIMPONETO.ToString("##,###,##0.00") + "", font2, XBrushes.Black, new XRect(leftMargin + 120, topMargin + 180, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString("PRECIOS DE LOS PRODUCTOS", font, XBrushes.Black, new XRect(leftMargin, topMargin + 190, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XNMONE + "", font2, XBrushes.Black, new XRect(leftMargin + 120, topMargin + 190, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString("LOS PRECIOS INCLUYEN IGV", font, XBrushes.Black, new XRect(leftMargin, topMargin + 200, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(": " + XIGV + "", font2, XBrushes.Black, new XRect(leftMargin + 120, topMargin + 200, 10, 10), XStringFormats.TopLeft);




            //START RECTANGULO****************************************************************************************************************************************

            pen = new XPen(XColors.Black, 2);
            gfx.DrawRoundedRectangle(pen, leftMargin + 300, topMargin + 80, 245, 100, 25, 25);


            // Pintamos los Datos de la Tabla de Session
            DataTable tabla01 = new DataTable();
            tabla01 = (DataTable)Session["Tabla01"];

            // AQUI DIBUJAMOS LAS CABECERAS DEL DETALLE
            font = new XFont("Abadi MT Condensed Light", 10, XFontStyle.Bold);
            gfx.DrawString(("DOC. DE PAGO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 305, topMargin + 85, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("MONTO (SOLES)").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 396, topMargin + 85, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("FECHA VCTO.").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 487, topMargin + 85, 10, 10), XStringFormats.TopLeft);

            //Trasamos las Lineas de la Cabecera
            pen = new XPen(XColors.Black, 2);
            //pen.LineCap = XLineCap.Flat;
            gfx.DrawLine(pen, leftMargin + 300, topMargin + 97, leftMargin + 546, topMargin + 97);
            //gfx.DrawLine(pen, x1, y1, x2, y2);

            //CARGAMOS EL DETALLE
            int n = 15;
            foreach (DataRow fila in tabla01.Rows)
            {
                Double monto = Convert.ToDouble(fila["monto"].ToString());
                font = new XFont("Abadi MT Condensed Light", 9, XFontStyle.Bold);
                gfx.DrawString((fila["num_interno"].ToString()).PadRight(19, ' '),
                    font, XBrushes.Black, new XRect(leftMargin + 305, topMargin + 85 + n, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((monto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 396, topMargin + 85 + n, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString(Equivalencias.Left((fila["fechven"].ToString()), 10),
                   font, XBrushes.Black, new XRect(leftMargin + 487, topMargin + 85 + n, 10, 10), XStringFormats.TopLeft);
                n = n + 10;
            }

            // PIE DEL RECTANGULO
            gfx.DrawLine(pen, leftMargin + 300, topMargin + 165, leftMargin + 546, topMargin + 165);
            gfx.DrawString(("TOTAL CREDITO :                   " + XIMPONETO.ToString("##,###,##0.00")).PadRight(19, ' '),
                    font, XBrushes.Black, new XRect(leftMargin + 310, topMargin + 170, 10, 10), XStringFormats.TopLeft);

            //END RECTANGULO *********************************************************************************************************************************************



















            pen = new XPen(XColors.Black, 3);
            //gfx2.DrawRoundedRectangle(pen, leftMargin + 0, topMargin + 220, 550, 40, 25, 25);
            // Pintamos los Datos de la Tabla de Session
            DataTable tabla02 = new DataTable();
            tabla02 = (DataTable)Session["Tabla02"];

            // AQUI DIBUJAMOS LAS CABECERAS DEL DETALLE
            font = new XFont("Abadi MT Condensed Light", 8.5, XFontStyle.Bold);
            gfx.DrawString(("CODIGO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 5, topMargin + 228, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("MARCA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 35, topMargin + 228, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("PRODUCTO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 80, topMargin + 228, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("COLOR").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 250, topMargin + 228, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("TALLA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 295, topMargin + 228, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("CANTIDAD").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 318, topMargin + 228, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("PRECIOS DE").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 350, topMargin + 225, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("LISTA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 358, topMargin + 235, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("VENTAS A").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 400, topMargin + 225, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("PRECIOS DE LISTA").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 390, topMargin + 235, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("PRECIOS CON").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 450, topMargin + 225, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("DESCUENTO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 451, topMargin + 235, 10, 10), XStringFormats.TopLeft);

            gfx.DrawString(("VENTAS CON").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 500, topMargin + 225, 10, 10), XStringFormats.TopLeft);
            gfx.DrawString(("DESCUENTO").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 501, topMargin + 235, 10, 10), XStringFormats.TopLeft);

            pen = new XPen(XColors.Black, 2);
            gfx.DrawLine(pen, 40, 265, 580, 265);


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
                gfx.DrawString((fila["articidold"].ToString()).PadRight(19, ' '),
                    font, XBrushes.Black, new XRect(leftMargin + 5, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((fila["marcaname"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 35, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((fila["articname"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 80, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((fila["colorname"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 250, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((fila["talla"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 299, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((fila["cantidad"].ToString()).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 318, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((precbruto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 358, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((impobruto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 400, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((precneto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 458, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                gfx.DrawString((imponeto.ToString("##,###,##0.00")).PadRight(19, ' '),
                   font, XBrushes.Black, new XRect(leftMargin + 508, topMargin + 235 + n2, 10, 10), XStringFormats.TopLeft);
                n2 = n2 + 10;
                nfilas = nfilas + 12;
            }

            //nfilas = nfilas;

            gfx.DrawRoundedRectangle(pen, leftMargin + 0, topMargin + 220, 540, nfilas, 25, 25);
            //PIE DEL RECTANGULO
            gfx.DrawLine(pen, 40, topMargin + 220 + (nfilas - 12), 570, topMargin + 220 + (nfilas - 12));
            font = new XFont("Abadi MT Condensed Light", 8, XFontStyle.Bold);
            gfx.DrawString(("TOTAL").PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 80, topMargin + 220 + (nfilas - 10), 10, 10), XStringFormats.TopLeft);

            gfx.DrawString((XIMPOBRUTO.ToString("##,###,##0.00")).PadRight(19, ' '),
                font, XBrushes.Black, new XRect(leftMargin + 400, topMargin + 220 + (nfilas - 10), 10, 10), XStringFormats.TopLeft);
            gfx.DrawString((XIMPONETO.ToString("##,###,##0.00")).PadRight(19, ' '),
               font, XBrushes.Black, new XRect(leftMargin + 508, topMargin + 220 + (nfilas - 10), 10, 10), XStringFormats.TopLeft);

     

            #endregion




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
            //Label1.Text = ex.Message;
        }
    }

}