using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_me_proyeccion
    {
        public String anio { get; set; }
        public String temporadaid { get; set; }
        public String canalventaid { get; set; }
        public String marcaid { get; set; }
        public String lineaid { get; set; }
        public String entalleid { get; set; }
        public String generoid { get; set; }
        public String lineatelaid { get; set; }
        public Int32 cantmod01 { get; set; }
        public Int32 cantmod02 { get; set; }
        public Int32 cantmod03 { get; set; }
        public Int32 cantmod04 { get; set; }
        public Int32 cantmod05 { get; set; }
        public Int32 cantmod06 { get; set; }
        public Int32 canttotal { get; set; }
        public Int32 profundidad { get; set; }
        public Int32 totalprendas { get; set; }
        public String status { get; set; }
        public String usuar { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }

        public class Item
        {
            public String anio { get; set; }
            public String temporadaid { get; set; }
            public String canalventaid { get; set; }
            public String marcaid { get; set; }
            public String lineaid { get; set; }
            public String entalleid { get; set; }
            public String generoid { get; set; }
            public String lineatelaid { get; set; }
            public Int32 cantmod01 { get; set; }
            public Int32 cantmod02 { get; set; }
            public Int32 cantmod03 { get; set; }
            public Int32 cantmod04 { get; set; }
            public Int32 cantmod05 { get; set; }
            public Int32 cantmod06 { get; set; }
            public Int32 canttotal { get; set; }
            public Int32 profundidad { get; set; }
            public Int32 totalprendas { get; set; }
            public String usuar { get; set; }
            public DateTime? fecre { get; set; }
            public DateTime? feact { get; set; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("perianio"); attrib1.Value = obj.anio;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("temporadaid"); attrib2.Value = obj.temporadaid;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("canalventaid"); attrib3.Value = obj.canalventaid;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("marcaid"); attrib4.Value = obj.marcaid;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("lineaid"); attrib5.Value = obj.lineaid;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("entalleid"); attrib6.Value = obj.entalleid;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("generoid"); attrib7.Value = obj.generoid;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("lineatelaid"); attrib8.Value = obj.lineatelaid;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("cantmod01"); attrib9.Value = obj.cantmod01.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("cantmod02"); attrib10.Value = obj.cantmod02.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("cantmod03"); attrib11.Value = obj.cantmod03.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("cantmod04"); attrib12.Value = obj.cantmod04.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("cantmod05"); attrib13.Value = obj.cantmod05.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("cantmod06"); attrib14.Value = obj.cantmod06.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("canttotal"); attrib15.Value = obj.canttotal.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("profundidad"); attrib16.Value = obj.profundidad.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("totalprendas"); attrib17.Value = obj.totalprendas.ToString();
             
                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);
                objNode.Attributes.Append(attrib5);
                objNode.Attributes.Append(attrib6);
                objNode.Attributes.Append(attrib7);
                objNode.Attributes.Append(attrib8);
                objNode.Attributes.Append(attrib9);
                objNode.Attributes.Append(attrib10);
                objNode.Attributes.Append(attrib11);
                objNode.Attributes.Append(attrib12);
                objNode.Attributes.Append(attrib13);
                objNode.Attributes.Append(attrib14);
                objNode.Attributes.Append(attrib15);
                objNode.Attributes.Append(attrib16);
                objNode.Attributes.Append(attrib17);
               
                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }


    }
}
