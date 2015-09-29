using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_pp_requerimientoprod
    {
        public String dominioid { get; set; }
        public String moduloid { get; set; }
        public String localid { get; set; }

        
        public String tipreq { get; set; }
        public String serreq { get; set; }
        public String numreq { get; set; }
        public String servcorteid { get; set; }
        public DateTime? fechini { get; set; }
        public DateTime? fechfin { get; set; }
        public String estado { get; set; }
        public String usuar { get; set; }
        public String observ { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }
        public String idx { get; set; }        

        public String tipop { get; set; }
        public String serop { get; set; }
        public String numop { get; set; }
        public String familiaid { get; set; }
        public String articidold { get; set; }
        public String articid { get; set; }
        public String coltalla { get; set; }
        public String colorid { get; set; }
        public Int32 cantreal { get; set; }
        public Int32 panios { get; set; }
        public Int32 totprendas { get; set; }
        public String tallaid { get; set; }

        public List<Item> ListaItems { get; set; }
        public class Item
        {
            public String tipreq { get; set; }
            public String serreq { get; set; }
            public String numreq { get; set; }
            public String tipop { get; set; }
            public String serop { get; set; }
            public String numop { get; set; }
            public String familiaid { get; set; }
            public String articidold { get; set; }
            public String articid { get; set; }
            public String coltalla { get; set; }
            public String colorid { get; set; }
            public Int32 cantreal { get; set; }
            public Int32 panios { get; set; }
            public Int32 totprendas { get; set; }
            public String estado { get; set; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("tipop"); attrib1.Value = obj.tipop;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("serop"); attrib2.Value = obj.serop;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("numop"); attrib3.Value = obj.numop;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("tipreq"); attrib4.Value = obj.tipreq;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("serreq"); attrib5.Value = obj.serreq;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("numreq"); attrib6.Value = obj.numreq;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("familiaid"); attrib7.Value = obj.familiaid;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("articidold"); attrib8.Value = obj.articidold;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("articid"); attrib9.Value = obj.articid;
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("coltalla"); attrib10.Value = obj.coltalla;
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib11.Value = obj.colorid;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("cantreal"); attrib12.Value = obj.cantreal.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("panios"); attrib13.Value = obj.panios.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("estado"); attrib14.Value = obj.estado;
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("totalprendas"); attrib15.Value = obj.totprendas.ToString();

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

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }





            
    }
}
