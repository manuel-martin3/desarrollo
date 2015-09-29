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

        //Se crea el documento PDF
        PdfDocument document = new PdfDocument();

        //Se configura los datos dela pagina
        document.Info.Title = "»» PROFORMA DE PEDIDOS ««";
        document.Info.Author = "HVR";

        //Se crea la pagina A4
        PdfPage page = document.AddPage();
        //page.Width = XUnit.FromMillimeter(210);
        //page.Height = XUnit.FromMillimeter(297);
        page.Orientation = PageOrientation.Portrait;

        Int16 intFila = 20;
        Int16 intColumna = 20;
        Int16 npag = 1;
        Int16 numFilas = 0;
        Int16 numColumna = 0;
        String imagenn = "";
        XFont font;

        //Se crea el objeto dibujo
        XGraphics gfx = XGraphics.FromPdfPage(page);

        //fuente de texto
        string fuente = "MS Mincho";
        string fuente02 = "CCode39";
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


        pen = new XPen(XColors.Black, 1); gfx.DrawRoundedRectangle(pen, intColumna, intFila, 245, 154, 25, 25);

        font = new XFont("Arial", 9.5, XFontStyle.Bold);
        gfx.DrawString("VILCHEZ ROSALES HUGO", font, XBrushes.Black, new XRect(intColumna + 10, intFila + 15, 10, 10), XStringFormats.TopLeft);

        font = new XFont("Arial", 9, XFontStyle.Bold);
        gfx.DrawString(("Area:").PadRight(25, ' '), font, XBrushes.Black, new XRect(intColumna + 10, intFila + 40, 10, 10), XStringFormats.TopLeft);
        gfx.DrawString("SISTEMAS", font, XBrushes.Black, new XRect(intColumna + 25, intFila + 50, 10, 10), XStringFormats.TopLeft);
        gfx.DrawString(("Vencimiento:").PadRight(19, ' '), font, XBrushes.Black, new XRect(intColumna + 10, intFila + 65, 10, 10), XStringFormats.TopLeft);
        gfx.DrawString(("31/12/" + anio).Substring(0, 10), font, XBrushes.Black, new XRect(intColumna + 25, intFila + 75, 10, 10), XStringFormats.TopLeft);

        font = new XFont(fuente02, 21, XFontStyle.Regular);
        gfx.DrawString("*" + "71724167" + "*", font, XBrushes.Black, new XRect(intColumna + 117, intFila + 110, 10, 10), XStringFormats.TopCenter);
        imagenn = Server.MapPath("~/images/" + "blanco.jpg");
        XImage imagennn = XImage.FromFile(imagenn); 
        gfx.DrawImage(imagennn, intColumna + 20, intFila + 106, 210, 15);
        font = new XFont("Arial", 9, XFontStyle.Bold);
        gfx.DrawString("*" + "71724167" + "*", font, XBrushes.Black, new XRect(intColumna + 113, intFila + 106, 10, 10), XStringFormats.TopCenter);

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


}