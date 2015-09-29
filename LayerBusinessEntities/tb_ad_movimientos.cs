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
    public class tb_ad_movimientos
    {

        #region tb_ad_movimientoscab

        public String moduloid { get; set; }
        public String local { get; set; }
        public String tipodoc { get; set; }
        public String serdoc { get; set; }
        public String numdoc { get; set; }
        public DateTime fechdoc { get; set; }
        public String almacaccionid { get; set; }
        public String tipoperacionid { get; set; }
        public String ctacteaccionid { get; set; }
        public String ctacte { get; set; }
        public String ctactename { get; set; }
        public String direcnume { get; set; }
        public String direcname { get; set; }
        public String direcdeta { get; set; }
        public String tipdid { get; set; }
        public String nmruc { get; set; }
        public String tipref { get; set; }
        public String serref { get; set; }
        public String numref { get; set; }
        public DateTime fechref { get; set; }
        public String tipfac { get; set; }
        public String serfac { get; set; }
        public String numfac { get; set; }
        public DateTime fechfac { get; set; }
        public String tipguia { get; set; }
        public String serguia { get; set; }
        public String numguia { get; set; }
        public DateTime fechguia { get; set; }
        public String tipnotac { get; set; }
        public String sernotac { get; set; }
        public String numnotac { get; set; }
        public DateTime fechnotac { get; set; }
        public String vendorid { get; set; }
        public String cencosid { get; set; }
        public Decimal totdsctoEmp { get; set; }
        public Decimal totdsctoTar { get; set; }
        public Decimal totdsctoAdd { get; set; }
        public String condpago { get; set; }
        public String tipimptoid { get; set; }
        public Decimal tasaigv { get; set; }
        public String incprec { get; set; }
        public Decimal valventa { get; set; }
        public Decimal totimpto { get; set; }
        public Decimal totimporte { get; set; }
        public Decimal tcamb { get; set; }
        public String glosa { get; set; }
        public Decimal totpzas { get; set; }
        public String moneda { get; set; }
        public String transpid { get; set; }
        public String transpname { get; set; }
        public String motivotrasladoid { get; set; }
        public String mottrasladointid { get; set; }
        public String canalventaid { get; set; }
        public Int32 giftid { get; set; }
        public Int32 clientetipoid { get; set; }
        public Decimal items { get; set; }
        public Int32 listaprecid { get; set; }
        public String localtra { get; set; }
        public String tiptra { get; set; }
        public String sertra { get; set; }
        public String numtra { get; set; }
        public Decimal dsctototal { get; set; }
        public Decimal baseimpo { get; set; }
        public Decimal montoigv { get; set; }
        public Decimal precventa { get; set; }
        public Int32 tarjbonusid { get; set; }
        public Int32 tarjgrupoid { get; set; }
        public Decimal tarjimporte { get; set; }
        public String cajanume { get; set; }
        public Decimal efectivo { get; set; }
        public Decimal vuelto { get; set; }
        public String recepname { get; set; }
        public String recepdni { get; set; }
        public DateTime recepfecha { get; set; }
        public String perianio { get; set; }
        public String perimes { get; set; }
        public String status { get; set; }
        public String usuar { get; set; }
        public DateTime fecre { get; set; }
        public DateTime feact { get; set; }
        public String Convalor { get; set; }
        public String XML { get; set; }
        public String filtro { get; set; }
        public String ncaja { get; set; }
        public String posicion { get; set; }



        #endregion

        #region tb_ad_movimientosdet
        private List<Item> _ListaItems;
        public List<Item> ListaItems
        {
            get { return _ListaItems; }
            set { _ListaItems = value; }
        }

        public class Item
        {
            public String moduloid { get; set; }
            public String local { get; set; }
            public String tipodoc { get; set; }
            public String serdoc { get; set; }
            public String numdoc { get; set; }
            public DateTime fechdoc { get; set; }
            public String items { get; set; }
            public String almacaccionid { get; set; }
            public String tipoperacionid { get; set; }
            public String ctacte { get; set; }
            public String direcnume { get; set; }
            public String prefijo { get; set; }
            public String articid { get; set; }
            public String colorid { get; set; }
            public String coltall { get; set; }
            public String productid { get; set; }
            public String productname { get; set; }
            public String ubicacion { get; set; }
            public String unmed { get; set; }
            public String itemref { get; set; }
            public Decimal cantidad { get; set; }
            public Decimal valor { get; set; }
            public Decimal importe { get; set; }
            public String statcostopromed { get; set; }
            public Decimal precioanterior { get; set; }
            public Int32 listaprecid { get; set; }
            public Int32 promEmp { get; set; }
            public Int32 promTar { get; set; }
            public Int32 promAdd { get; set; }
            public Decimal dsctoEmp { get; set; }
            public Decimal dsctoTar { get; set; }
            public Decimal dsctoAdd { get; set; }
            public Decimal precunit { get; set; }
            public Decimal importfac { get; set; }
            public String tipimptoid { get; set; }
            public Decimal tasaigv { get; set; }
            public Decimal totimpto { get; set; }
            public String status { get; set; }
            public String usuar { get; set; }
            public Decimal fecre { get; set; }
            public Decimal feact { get; set; }    
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("items"); attrib1.Value = obj.items.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib2.Value = obj.almacaccionid.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("tipoperacionid"); attrib3.Value = obj.tipoperacionid.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib4.Value = obj.ctacte.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("direcnume"); attrib5.Value = obj.direcnume.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("prefijo"); attrib6.Value = obj.prefijo.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("articid"); attrib7.Value = obj.articid.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib8.Value = obj.colorid.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("coltall"); attrib9.Value = obj.coltall.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("productid"); attrib10.Value = obj.productid.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("productname"); attrib11.Value = obj.productname.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("ubicacion"); attrib12.Value = obj.ubicacion.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("unmed"); attrib13.Value = obj.unmed.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("itemref"); attrib14.Value = obj.itemref.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib15.Value = obj.cantidad.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("valor"); attrib16.Value = obj.valor.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("importe"); attrib17.Value = obj.importe.ToString();
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("statcostopromed"); attrib18.Value = obj.statcostopromed.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("precioanterior"); attrib19.Value = obj.precioanterior.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("listaprecid"); attrib20.Value = obj.listaprecid.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("promEmp"); attrib21.Value = obj.promEmp.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("promTar"); attrib22.Value = obj.promTar.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("promAdd"); attrib23.Value = obj.promAdd.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("dsctoEmp"); attrib24.Value = obj.dsctoEmp.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("dsctoTar"); attrib25.Value = obj.dsctoTar.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("dsctoAdd"); attrib26.Value = obj.dsctoAdd.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib27.Value = obj.precunit.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("importfac"); attrib28.Value = obj.importfac.ToString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("tipimptoid"); attrib29.Value = obj.tipimptoid.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("tasaigv"); attrib30.Value = obj.tasaigv.ToString();
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("totimpto"); attrib31.Value = obj.totimpto.ToString();
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("status"); attrib32.Value = obj.status.ToString();
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib33.Value = obj.usuar.ToString();
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("fecre"); attrib34.Value = obj.fecre.ToString();
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("feact"); attrib35.Value = obj.feact.ToString();
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
                objNode.Attributes.Append(attrib24);
                objNode.Attributes.Append(attrib25);
                objNode.Attributes.Append(attrib26);
                objNode.Attributes.Append(attrib27);
                objNode.Attributes.Append(attrib28);
                objNode.Attributes.Append(attrib29);
                objNode.Attributes.Append(attrib30);
                objNode.Attributes.Append(attrib31);
                objNode.Attributes.Append(attrib32);
                objNode.Attributes.Append(attrib33);
                objNode.Attributes.Append(attrib34);
                objNode.Attributes.Append(attrib35);
                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }
        #endregion

        #region tb_ad_movimientosTarj
        private List<Tarjetas> _ListaTarjetas;
        public List<Tarjetas> ListaTarjetas
        {
            get { return _ListaTarjetas; }
            set { _ListaTarjetas = value; }
        }

        public class Tarjetas
        {
            public String moduloid { get; set; }         
            public String local { get; set; }          
            public String tipodoc { get; set; }           
            public String serdoc { get; set; }            
            public String numdoc { get; set; }           
            public Int32 tarjetaid { get; set; }        
            public String tarjnumoper { get; set; }           
            public String moneda { get; set; }            
            public Decimal tcamb { get; set; }           
            public Decimal tarjimporte { get; set; }                  
            public String status { get; set; }         
            public String usuar { get; set; }          
        }

        public string TarjetasXML()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (Tarjetas obj in ListaTarjetas)
            {
                objNode = objXMLDoc.CreateElement("Item");
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("tarjetaid"); attrib1.Value = obj.tarjetaid.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("tarjnumoper"); attrib2.Value = obj.tarjnumoper.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib3.Value = obj.moneda.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("tcamb"); attrib4.Value = obj.tcamb.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("tarjimporte"); attrib5.Value = obj.tarjimporte.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("status"); attrib6.Value = obj.status.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib7.Value = obj.usuar.ToString();

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

        #endregion


        #region tb_ad_movimientosOld
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("itemsdet"); attrib1.Value = obj.items;

                objNode.Attributes.Append(attrib1);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }
        #endregion

        #region *** validar fecha en formato correcto
        public DateTime fecha(DateTime pfecha)
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
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.") || pfecha != DateTime.Parse("01/01/0001 00:00:00"))
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
        #endregion
    }
}
