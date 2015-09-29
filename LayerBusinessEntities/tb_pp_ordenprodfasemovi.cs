using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_pp_ordenprodfasemovi
    { 

        // CABECERA 
        public String dominioid { get; set; }
        public String tipodoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public DateTime? fechdoc { get; set; }
        public String almacaccionid { get; set; }
        public String moduloid { get; set; }
        public String mottrasladointid { get; set; }
        public String tipop { get; set; }
        public String serop { get; set; }
        public String numop { get; set; }
        public Int32 secuencia { get; set; }
        public Int32 faseid { get; set; }
        public String status { get; set; }
        public String usuar { get; set; }
        public String filtro { get; set; }     



        //DETALLE
        public Boolean primera { get; set; }
        public String colorid { get; set; }
        public String coltalla { get; set; }       
        public Int32 cantidad { get; set; }


        public List<Item> ListaItems { get; set; }
        public class Item
        {          
            public Boolean primera { get; set; }
            public String colorid { get; set; }
            public String coltalla { get; set; }
            public String almacaccionid { get; set; }
            public Int32 cantidad { get; set; }
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
            foreach (Item obj in ListaItems)
            {
                objNode = objXMLDoc.CreateElement("Item");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("primera"); attrib1.Value = obj.primera.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib2.Value = obj.colorid.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("coltalla"); attrib3.Value = obj.coltalla.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib4.Value = obj.cantidad.ToString();               

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);                

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }



      

    }
}
