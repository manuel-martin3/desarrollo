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
    public class tb_cxc_pedidocab
    {
        public String moduloid { get; set; }
        public String tipdoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public String canalventaid { get; set; }
        public String tipventaid { get; set; }
        public DateTime? fechdoc { get; set; }
        public DateTime? fechentrega { get; set; }
        public String vendorid { get; set; }
        public String ctacte { get; set; }
        public String direcnume { get; set; }
        public String replegal_dni { get; set; }
        public String replegal_name { get; set; }
        public String direc_entrega { get; set; }
        public String condventaid { get; set; }
        public int plazoday { get; set; }
        public Decimal impobruto { get; set; }
        public String rangoid { get; set; }
        public Decimal tasadescto { get; set; }
        public Decimal imponeto { get; set; }
        public String moneda { get; set; }
        public Boolean incluye_igv { get; set; }
        public String observacion { get; set; }
        public String mediopagoid { get; set; }
        public int numdocs { get; set; }
        public String aprob_status { get; set; }
        public String aprob_obser { get; set; }
        public DateTime? aprob_fech { get; set; }
        public String usuar { get; set; }
        public DateTime? fecre { get; set; }
        public DateTime? feact { get; set; }        
        public String local { get; set; }
        public String accion { get; set; }
        public String almacaccionid { get; set; }
        
        public class Item
        {
            public String tipdoc { get; set; }
            public String serdoc { get; set; }
            public String numdoc { get; set; }
            public String articid { get; set; }
            public String articidold { get; set; }
            public String colorid { get; set; }
            public String tallaid { get; set; }
            public String coltall { get; set; }
            public Decimal cantidad { get; set; }
            public Decimal precbruto { get; set; }
            public Decimal impobruto { get; set; }
            public Decimal precneto { get; set; }
            public Decimal imponeto { get; set; }            
            public String usuar { get; set; }
            public DateTime? fecre { get; set; }
            public DateTime? feact { get; set; }
            public String canalventaid { get; set; }
            public String local { get; set; }         
        }

        public class Crono
        {
            public String tipdoc { get; set; }
            public String serdoc { get; set; }
            public String numdoc { get; set; }
            public String item { get; set; }
            public String mediopagoid { get; set; }
            public String num_interno { get; set; }
            public String num_unico { get; set; }
            public Decimal monto { get; set; }
            public DateTime fechven { get; set; }
            public String usuar { get; set; }
            public DateTime? fecre { get; set; }
            public DateTime? feact { get; set; }
        }

        public class ItemsStkDeta
        {
            public DateTime? fecha { get; set; }
            public String articid { get; set; }
            public String colorid { get; set; }
            public String coltall { get; set; }
            public String almacaccionid { get; set; }
            public String tipodoc { get; set; }
            public String serdoc { get; set; }
            public String numdoc { get; set; }
            public Decimal cantidad { get; set; }
            public String ctacte { get; set; }
            public String direcnume { get; set; }
            public String tipoperacionid { get; set; }
            public String tiporef { get; set; }
            public String serref { get; set; }
            public String numref { get; set; }
            public Int32 estado { get; set; }
            public Int32 atendido { get; set; }
            public String vendorid { get; set; }
            public String usuar { get; set; }
            public String canalventaid { get; set; }
            public String local { get; set; }
            public String dominioid { get; set; }
            public String moduloid { get; set; }
        }

        private List<Item> _ListaItems;
        public List<Item> ListaItems
        {
            get { return _ListaItems; }
            set { _ListaItems = value; }
        }


        private List<Crono> _ListaCrono;
        public List<Crono> ListaCrono
        {
            get { return _ListaCrono; }
            set { _ListaCrono = value; }
        }

        private List<ItemsStkDeta> ListaItemsStkDeta;
        public List<ItemsStkDeta> listaItemsStkDeta
        {
            get { return ListaItemsStkDeta; }
            set { ListaItemsStkDeta = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib1.Value = obj.tipdoc;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib2.Value = obj.serdoc;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib3.Value = obj.numdoc;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("articid"); attrib4.Value = obj.articid;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("articidold"); attrib5.Value = obj.articidold;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib6.Value = obj.colorid.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("tallaid"); attrib7.Value = obj.tallaid.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("coltall"); attrib8.Value = obj.coltall;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib9.Value = obj.cantidad.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("precbruto"); attrib10.Value = obj.precbruto.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("impobruto"); attrib11.Value = obj.impobruto.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("precneto"); attrib12.Value = obj.precneto.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("imponeto"); attrib13.Value = obj.imponeto.ToString();  
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib14.Value = obj.usuar.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("fecre"); attrib15.Value = obj.fecre.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("feact"); attrib16.Value = obj.feact.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("canalventaid"); attrib17.Value = obj.canalventaid.ToString();
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("local"); attrib18.Value = obj.local.ToString();
               
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
                objNode.Attributes.Append(attrib18);                          

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }

        public string GetCronoXML()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (Crono obj in ListaCrono)
            {
                objNode = objXMLDoc.CreateElement("Item");
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib1.Value = obj.tipdoc.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib2.Value = obj.serdoc.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib3.Value = obj.numdoc.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("item"); attrib4.Value = obj.item.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("mediopagoid"); attrib5.Value = obj.mediopagoid.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("num_interno"); attrib6.Value = obj.num_interno.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("num_unico"); attrib7.Value = obj.num_unico.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("monto"); attrib8.Value = obj.monto.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("fechven"); attrib9.Value = obj.fechven.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib10.Value = obj.usuar.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("fecre"); attrib11.Value = obj.fecre.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("feact"); attrib12.Value = obj.feact.ToString();

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

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }

        public string GetStkItemXML()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("ItemsStkDeta");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (ItemsStkDeta obj in listaItemsStkDeta)
            {
                objNode = objXMLDoc.CreateElement("ItemsStkDeta");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("fecha"); attrib1.Value = obj.fecha.ToString().Substring(0, 10);
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("articid"); attrib2.Value = obj.articid.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib3.Value = obj.colorid.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("coltall"); attrib4.Value = obj.coltall.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib5.Value = obj.almacaccionid.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("tipodoc"); attrib6.Value = obj.tipodoc.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib7.Value = obj.serdoc.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib8.Value = obj.numdoc.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib9.Value = obj.cantidad.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib10.Value = obj.ctacte.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("direcnume"); attrib11.Value = obj.direcnume.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("tipoperacionid"); attrib12.Value = obj.tipoperacionid.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("tiporef"); attrib13.Value = obj.tipodoc.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("serref"); attrib14.Value = obj.serref.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("numref"); attrib15.Value = obj.numref.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("estado"); attrib16.Value = obj.estado.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("atendido"); attrib17.Value = obj.atendido.ToString();
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("vendorid"); attrib18.Value = obj.vendorid.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib19.Value = obj.usuar.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("canalventaid"); attrib20.Value = obj.canalventaid.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("local"); attrib21.Value = obj.local.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("dominioid"); attrib22.Value = obj.dominioid.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib23.Value = obj.moduloid.ToString();

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
                objNode.Attributes.Append(attrib18);
                objNode.Attributes.Append(attrib19);
                objNode.Attributes.Append(attrib20);
                objNode.Attributes.Append(attrib21);
                objNode.Attributes.Append(attrib22);
                objNode.Attributes.Append(attrib23);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }

    }
}
