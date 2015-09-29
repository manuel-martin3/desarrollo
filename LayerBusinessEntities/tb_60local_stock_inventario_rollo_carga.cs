using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{ 
public class tb_60local_stock_inventario_rollo_carga
{ 

   private String _moduloid; 
   public String moduloid{ 
       get { return _moduloid; }

       set { _moduloid = value; }
   }

   private String _local; 
   public String local{ 
       get { return _local; }

       set { _local = value; }
   }

   private String _tipodoc; 
   public String tipodoc{ 
       get { return _tipodoc; }

       set { _tipodoc = value; }
   }

   private String _serdoc; 
   public String serdoc{ 
       get { return _serdoc; }

       set { _serdoc = value; }
   }

   private String _numdoc; 
   public String numdoc{ 
       get { return _numdoc; }

       set { _numdoc = value; }
   }

   private String _rollo; 
   public String rollo{ 
       get { return _rollo; }

       set { _rollo = value; }
   }

   private String _productid; 
   public String productid{ 
       get { return _productid; }

       set { _productid = value; }
   }

   private Decimal _stockfisico; 
   public Decimal stockfisico{ 
       get { return _stockfisico; }

       set { _stockfisico = value; }
   }

   private String _codigoubic; 
   public String codigoubic{ 
       get { return _codigoubic; }

       set { _codigoubic = value; }
   }

   private DateTime? _fechatoma; 
   public DateTime? fechatoma{ 
       get { return _fechatoma; }

       set { _fechatoma = value; }
   }

   private String _userinventario; 
   public String userinventario{ 
       get { return _userinventario; }

       set { _userinventario = value; }
   }

   private String _usuar; 
   public String usuar{ 
       get { return _usuar; }

       set { _usuar = value; }
   }

   private DateTime? _feact; 
   public DateTime? feact{ 
       get { return _feact; }

       set { _feact = value; }
   }

   //*****************DETALLE*********************        
   public class Item
   {
       private String _rollo;
       public String rollo
       {
           get { return _rollo; }

           set { _rollo = value; }
       }

       private String _productid;
       public String productid
       {
           get { return _productid; }

           set { _productid = value; }
       }

       private Decimal _stockfisico;
       public Decimal stockfisico
       {
           get { return _stockfisico; }

           set { _stockfisico = value; }
       }

       private String _codigoubic;
       public String codigoubic
       {
           get { return _codigoubic; }

           set { _codigoubic = value; }
       }

       private DateTime? _fechatoma;
       public DateTime? fechatoma
       {
           get { return _fechatoma; }

           set { _fechatoma = value; }
       }

       private String _userinventario;
       public String userinventario
       {
           get { return _userinventario; }

           set { _userinventario = value; }
       }

       private String _usuar;
       public String usuar
       {
           get { return _usuar; }

           set { _usuar = value; }
       }
   }

   private List<Item> _ListaItems;
   public List<Item> ListaItems
   {
       get { return _ListaItems; }
       set { _ListaItems = value; }
   }

   public string GetItemXML()
   {
       XmlDocument objXMLDoc = new XmlDocument();
       XmlNode objNode = default(XmlNode);

       //Se crea un nodo elemento XML
       objNode = objXMLDoc.CreateElement("Items");

       //Se agrega el nodo al Documento XML
       objXMLDoc.AppendChild(objNode);

       //Se itera la coleccion para generar la estructura XML
       foreach (Item obj in _ListaItems)
       {
           objNode = objXMLDoc.CreateElement("Item");

           XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("rollo"); attrib1.Value = obj.rollo;
           XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("productid"); attrib2.Value = obj.productid;
           XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("stockfisico"); attrib3.Value = obj.stockfisico.ToString();
           XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("codigoubic"); attrib4.Value = obj.codigoubic;
           XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("fechatoma"); attrib5.Value = obj.fechatoma.ToString();
           XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("userinventario"); attrib6.Value = obj.userinventario;
           XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib7.Value = obj.usuar;

           objNode.Attributes.Append(attrib1);
           objNode.Attributes.Append(attrib2);
           objNode.Attributes.Append(attrib3);
           objNode.Attributes.Append(attrib4);
           objNode.Attributes.Append(attrib5);
           objNode.Attributes.Append(attrib6);
           objNode.Attributes.Append(attrib7);

           objXMLDoc.DocumentElement.AppendChild(objNode);
       }

       return objXMLDoc.InnerXml;
   }

   public string GetItemXML2()
   {
       XmlDocument objXMLDoc = new XmlDocument();
       XmlNode objNode = default(XmlNode);

       //Se crea un nodo elemento XML
       objNode = objXMLDoc.CreateElement("Items");

       //Se agrega el nodo al Documento XML
       objXMLDoc.AppendChild(objNode);

       //Se itera la coleccion para generar la estructura XML
       foreach (Item obj in _ListaItems)
       {
           objNode = objXMLDoc.CreateElement("Item");

           XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("rollo"); attrib1.Value = obj.rollo;

           objNode.Attributes.Append(attrib1);

           objXMLDoc.DocumentElement.AppendChild(objNode);
       }

       return objXMLDoc.InnerXml;
   }

   #region *** validar fecha en formato correcto
   public DateTime? fecha(DateTime pfecha)
   {
       //string dia = pfecha.Day.ToString();
       //string mes = pfecha.Month.ToString();
       //string anio = pfecha.Year.ToString();
       //string fecha = anio + "-" + mes + "-" + dia;
       DateTime lfech;
       //DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
       //IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
       if (pfecha != null)
       {
           if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m."))
           {
               lfech = pfecha;
           }
           else
           {
               lfech = DateTime.Parse("01/01/1900");
           }
       }
       else
       {
           lfech = DateTime.Parse("01/01/1900");
       }

       return lfech;
   }

   public DateTime? fecha02(DateTime pfecha)
   {
       String lfech;
       IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
       if (pfecha != null)
       {
           if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.", culture, System.Globalization.DateTimeStyles.AssumeLocal))
           {
               lfech = pfecha.ToString();
           }
           else
           {
               lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
           }
       }
       else
       {
           lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
       }
       return DateTime.Parse(lfech, culture, System.Globalization.DateTimeStyles.AssumeLocal);
   }
   #endregion

}
}
