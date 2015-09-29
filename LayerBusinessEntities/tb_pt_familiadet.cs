using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics;
using System.Xml;
namespace LayerBusinessEntities
{ 
    public class tb_pt_familiadet
    {

        private String _familiaid;
        public String familiaid
        {
            get { return _familiaid; }
            set { _familiaid = value; }
        }

       private String _lineaid;
       public String lineaid
       {
           get { return _lineaid; }
           set { _lineaid = value; }
       }

       private String _moduloid;
       public String moduloid
       {
           get { return _moduloid; }
           set { _moduloid = value; }
       }

       private String _familianame;
       public String familianame
       {
           get { return _familianame; }
           set { _familianame = value; }
       }

       private String _productid;
       public String productid
       {
           get { return _productid; }
           set { _productid = value; }
       }

       private String _posicion;
       public String posicion
       {
           get { return _posicion; }
           set { _posicion = value; }
       }

       private String _usuar; 
       public String usuar{ 
           get { return _usuar; }

           set { _usuar = value; }
       }

       private DateTime? _fecre; 
       public DateTime? fecre{ 
           get { return _fecre; }

           set { _fecre = value; }
       }

       private DateTime? _feact; 
       public DateTime? feact{ 
           get { return _feact; }

           set { _feact = value; }
       }


       public class Item
       {
           private String _familiaid;
           public String familiaid
           {
               get { return _familiaid; }
               set { _familiaid = value; }
           }

           private String _lineaid;
           public String lineaid
           {
               get { return _lineaid; }
               set { _lineaid = value; }
           }

           private String _moduloid;
           public String moduloid
           {
               get { return _moduloid; }
               set { _moduloid = value; }
           }

           private String _familianame;
           public String familianame
           {
               get { return _familianame; }
               set { _familianame = value; }
           }

           private String _productid;
           public String productid
           {
               get { return _productid; }
               set { _productid = value; }
           }

           private String _unmed;
           public String unmed
           {
               get { return _unmed; }
               set { _unmed = value; }
           }

           private String _posicion;
           public String posicion
           {
               get { return _posicion; }
               set { _posicion = value; }
           }

           private String _usuar;
           public String usuar
           {
               get { return _usuar; }

               set { _usuar = value; }
           }

           private String _status;
           public String status
           {
               get { return _status; }
               set { _status = value; }
           }

           private DateTime? _fecre;
           public DateTime? fecre
           {
               get { return _fecre; }

               set { _fecre = value; }
           }

           private DateTime? _feact;
           public DateTime? feact
           {
               get { return _feact; }

               set { _feact = value; }
           }
       }


       private List<Item> _ListaItems;
       public List<Item> ListaItems
       {
           get { return _ListaItems; }
           set { _ListaItems = value; }
       }

       private List<Item> _ListaItems2;
       public List<Item> ListaItems2
       {
           get { return _ListaItems2; }
           set { _ListaItems2 = value; }
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

               XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("lineaid"); attrib1.Value = obj.lineaid.ToString();
               XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("familiaid"); attrib2.Value = obj.familiaid.ToString();
               XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("productid"); attrib3.Value = obj.productid.ToString();
               XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("unmed"); attrib4.Value = obj.unmed.ToString();
               XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("statu"); attrib5.Value = obj.status.ToString();
               XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib6.Value = obj.usuar.ToString();

               objNode.Attributes.Append(attrib1);
               objNode.Attributes.Append(attrib2);
               objNode.Attributes.Append(attrib3);
               objNode.Attributes.Append(attrib4);
               objNode.Attributes.Append(attrib5);
               objNode.Attributes.Append(attrib6);

               objXMLDoc.DocumentElement.AppendChild(objNode);
           }
           return objXMLDoc.InnerXml;
       }




    }
}
