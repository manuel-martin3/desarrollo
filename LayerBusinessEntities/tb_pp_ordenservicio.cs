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

    public class tb_pp_ordenservicio
    {

        // TB_PP_ORDENSERVCAB

        public String dominioid { get; set; }
        public String moduloid { get; set; }
        public String localid { get; set; }

        public String tipos { get; set; }
        public String seros { get; set; }
        public String numos { get; set; }	
        public DateTime? fechini { get; set; }
        public DateTime? fechfin { get; set; }
        public Boolean precprenda { get; set; }
        public Int32 cantidad { get; set; }
        public Decimal peso { get; set; }
        public String moneda { get; set; }
        public Decimal tcambio { get; set; }
        public Decimal bimpo { get; set; }
        public Decimal migv { get; set; }
        public Decimal pvent { get; set; }
        public String ctacte { get; set; }
        public String tipop { get; set; }
        public String serop { get; set; }
        public String numop { get; set; }
        public Int32 secuencia { get; set; }
        public Int32 faseid { get; set; }
        public String estado { get; set; }
        public String tipfac { get; set; }
        public String serfac { get; set; }
        public String numfac { get; set; }
        public String tipgr { get; set; }
        public String sergr { get; set; }
        public String numgr { get; set; }
        public String tipfas { get; set; }
        public String serfas { get; set; }
        public String numfas { get; set; }
        public String usuar { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }
        public String observacion { get; set; }
        public String Idx { get; set; }


        // TB_PP_ORDENSERVDET
        public String proceso { get; set; }
        public String marca { get; set; }
        public String articid { get; set; }
        public String coltalla { get; set; }
        public String colorid { get; set; }
        public String unmed { get; set; }      
        public Decimal precunit { get; set; }
        public Decimal importe { get; set; }        



        public List<Item> ListaItems{ get; set; }
        public class Item
        {
            public String tipos { get; set; }
            public String seros { get; set; }
            public String numos { get; set; }
            public String tipop { get; set; }
            public String serop { get; set; }
            public String numop { get; set; }
            public String tipfac { get; set; }
            public String serfac { get; set; }
            public String numfac { get; set; }
            public String tipgr { get; set; }
            public String sergr { get; set; }
            public String numgr { get; set; }
            public String tipdoc { get; set; }
            public String serdoc { get; set; }
            public String numdoc { get; set; }

            public String proceso { get; set; }
            public String marcaid { get; set; }
            public String articid { get; set; }
            public String coltalla { get; set; }
            public String colorid { get; set; }
            public Int32 cantidad { get; set; }
            public String unmed { get; set; }
            public Decimal peso { get; set; }
            public Decimal precunitpeso { get; set; }
            public Decimal precunit { get; set; }
            public Decimal importe { get; set; }   
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
                
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib1.Value = obj.colorid;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib2.Value = obj.cantidad.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("peso"); attrib3.Value = obj.peso.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("precunitpeso"); attrib4.Value = obj.precunitpeso.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib5.Value = obj.precunit.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("importe"); attrib6.Value = obj.importe.ToString();

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
