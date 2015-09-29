using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_pp_receta
    {
        public String articid { get; set; }
        public String version { get; set; }
        public String colorid { get; set; }
        public String coltalla { get; set; }
        public String bloqcostid { get; set; }
        public String productid { get; set; }
        public Int32 cantidad { get; set; }
        public String estado { get; set; }
        public DateTime fechemi { get; set; }
        public String usuar { get; set; }

        public List<Item> ListaItems { get; set; }

        public class Item
        {
            public String articid { get; set; }
            public String version { get; set; }
            public String colorid { get; set; }
            public String coltalla { get; set; }
            public String bloqcostid { get; set; }
            public String productid { get; set; }
            public Int32 cantidad { get; set; }
            public String estado { get; set; }
            public DateTime fechemi { get; set; }
            public String usuar { get; set; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("articid"); attrib1.Value = obj.articid;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("version"); attrib2.Value = obj.version;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib3.Value = obj.colorid;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("coltalla"); attrib4.Value = obj.coltalla;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("bloqcostid"); attrib5.Value = obj.bloqcostid;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("productid"); attrib6.Value = obj.productid;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib7.Value = obj.cantidad.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("estado"); attrib8.Value = obj.estado;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib9.Value = obj.usuar;

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);
                objNode.Attributes.Append(attrib5);
                objNode.Attributes.Append(attrib6);
                objNode.Attributes.Append(attrib7);
                objNode.Attributes.Append(attrib8);
                objNode.Attributes.Append(attrib9);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }

    }
}
