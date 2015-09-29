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
    public class tb_pp_ordenprod
    {
        //ORDEN PROC CABECERA        
        public String tipop { get; set; }
        public String serop { get; set; }
        public String numop { get; set; }
        public DateTime? fechemi { get; set; }
        public DateTime? fechini { get; set; }
        public DateTime? fechfin { get; set; }
        public String estado { get; set; }
        public String perianio { get; set; }
        public String articid { get; set; }
        public String canalventaid { get; set; }
        public String ctacte { get; set; }
        public String tipref { get; set; }
        public String serref { get; set; }
        public String numref { get; set; }
        public String observacion { get; set; }
        public Int32? cantprog { get; set; }
        public Int32? cantreal { get; set; }
        public Int32? ejecutorid { get; set; }
        public String usuar { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }
        public String parameters { get; set; }
        public String explosion { get; set; }
        public String version { get; set; }
        public String tallaid { get; set; }
        public String idx { get; set; }

        //ORDEN PROC COLOR
        public String colorid { get; set; }
        public String coltalla { get; set; }
        public Int32? cantidad { get; set; }
        public String status { get; set; }

        //ORDEN PROC PROPORCIÓN
        public String proporcion { get; set; }
        //public String cantprog { get; set; }
        //public String cantreal { get; set; }

        //ORDER PROC FASE
        public int secuencia { get; set; }
        public int faseid { get; set; }
        public DateTime? fechprogini { get; set; }
        public DateTime? fechprogfin { get; set; }

        //ORDEN PROC MATERIAL
        public int partepdaid { get; set; }
        public String productid { get; set; }
        public String ancho { get; set; }
        public String gramaje { get; set; }

        //ORDEN PROD CONSUMO
        public decimal largtizado { get; set; }
        public decimal pdasxpano { get; set; }
        public decimal numpanos { get; set; }
        public decimal porcentolerancia { get; set; }


        public List<ItemProp> ListaItemProp { get; set; }
        public class ItemProp
        {
            public String tipop { get; set; }
            public String serop { get; set; }
            public String numop { get; set; }
            public String coltalla { get; set; }
            public Int32? proporcion { get; set; }
            public Int32? cantprog { get; set; }
            public Int32? cantreal { get; set; }
        }

        public List<ItemColor> ListaItemColor { get; set; }
        public class ItemColor
        {
            public String tipop { get; set; }
            public String serop { get; set; }
            public String numop { get; set; }
            public String colorid { get; set; }
            public String coltalla { get; set; }
            public Int32? cantidad { get; set; }
            public String status { get; set; }
            public String usuar { get; set; }
        }

        //ORDEN DE PRODUCCION FASE


        //

        // XML DE PROPORCION
        public string GetItemXMLProp()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (ItemProp obj in ListaItemProp)
            {
                objNode = objXMLDoc.CreateElement("Item");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("tipop"); attrib1.Value = obj.tipop;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("serop"); attrib2.Value = obj.serop;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("numop"); attrib3.Value = obj.numop;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("coltalla"); attrib4.Value = obj.coltalla;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("proporcion"); attrib5.Value = obj.proporcion.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("cantprog"); attrib6.Value = obj.cantprog.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("cantreal"); attrib7.Value = obj.cantreal.ToString();

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

        // XML DE COLORES
        public string GetItemXMLColor()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (ItemColor obj in ListaItemColor)
            {
                objNode = objXMLDoc.CreateElement("Item");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("tipop"); attrib1.Value = obj.tipop;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("serop"); attrib2.Value = obj.serop;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("numop"); attrib3.Value = obj.numop;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib4.Value = obj.colorid;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("coltalla"); attrib5.Value = obj.coltalla;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib6.Value = obj.cantidad.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("status"); attrib7.Value = obj.status;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib8.Value = obj.usuar;

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);
                objNode.Attributes.Append(attrib5);
                objNode.Attributes.Append(attrib6);
                objNode.Attributes.Append(attrib7);
                objNode.Attributes.Append(attrib8);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }
        


    }





}
