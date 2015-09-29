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
    public class tb_cm_liquidadet
    {

        private String _tipdoc;
        public String tipdoc
        {
            get { return _tipdoc; }
            set { _tipdoc = value; }
        }

        private String _serdoc;
        public String serdoc
        {
            get { return _serdoc; }
            set { _serdoc = value; }
        }

        private String _numdoc;
        public String numdoc
        {
            get { return _numdoc; }
            set { _numdoc = value; }
        }

        private String _conceptoid;
        public String conceptoid
        {
            get { return _conceptoid; }
            set { _conceptoid = value; }
        }

        private String _tipbou;
        public String tipbou
        {
            get { return _tipbou; }
            set { _tipbou = value; }
        }

        private String _serbou;
        public String serbou
        {
            get { return _serbou; }
            set { _serbou = value; }
        }

        private String _numbou;
        public String numbou
        {
            get { return _numbou; }
            set { _numbou = value; }
        }

        private DateTime _fechbou;
        public DateTime fechbou
        {
            get { return _fechbou; }
            set { _fechbou = value; }
        }

        private Decimal _bimp_sunad2;
        public Decimal bimp_sunad2
        {
            get { return _bimp_sunad2; }
            set { _bimp_sunad2 = value; }
        }

        private Decimal _bimp_sunat2;
        public Decimal bimp_sunat2
        {
            get { return _bimp_sunat2; }
            set { _bimp_sunat2 = value; }
        }

        private Decimal _tipcamb;
        public Decimal tipcamb
        {
            get { return _tipcamb; }
            set { _tipcamb = value; }
        }

        private Decimal _bimp_sunat1;
        public Decimal bimp_sunat1
        {
            get { return _bimp_sunat1; }
            set { _bimp_sunat1 = value; }
        }

        private Decimal _exon;
        public Decimal exon
        {
            get { return _exon; }
            set { _exon = value; }
        }

        private Decimal _migv;
        public Decimal migv
        {
            get { return _migv; }
            set { _migv = value; }
        }

        private Decimal _pven;
        public Decimal pven
        {
            get { return _pven; }
            set { _pven = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }
            set { _usuar = value; }
        }

        private DateTime _fecre;
        public DateTime fecre
        {
            get { return _fecre; }
            set { _fecre = value; }
        }

        private DateTime _feact;
        public DateTime feact
        {
            get { return _feact; }
            set { _feact = value; }
        }


   

        //*************************************************        
        public class Item
        {
            private String _tipdoc;
            public String tipdoc
            {
                get { return _tipdoc; }
                set { _tipdoc = value; }
            }

            private String _serdoc;
            public String serdoc
            {
                get { return _serdoc; }
                set { _serdoc = value; }
            }

            private String _numdoc;
            public String numdoc
            {
                get { return _numdoc; }
                set { _numdoc = value; }
            }

            private String _conceptoid;
            public String conceptoid
            {
                get { return _conceptoid; }
                set { _conceptoid = value; }
            }

            private String _tipbou;
            public String tipbou
            {
                get { return _tipbou; }
                set { _tipbou = value; }
            }

            private String _serbou;
            public String serbou
            {
                get { return _serbou; }
                set { _serbou = value; }
            }

            private String _numbou;
            public String numbou
            {
                get { return _numbou; }
                set { _numbou = value; }
            }

            private DateTime _fechbou;
            public DateTime fechbou
            {
                get { return _fechbou; }
                set { _fechbou = value; }
            }

            private Decimal _bimp_sunad2;
            public Decimal bimp_sunad2
            {
                get { return _bimp_sunad2; }
                set { _bimp_sunad2 = value; }
            }

            private Decimal _bimp_sunat2;
            public Decimal bimp_sunat2
            {
                get { return _bimp_sunat2; }
                set { _bimp_sunat2 = value; }
            }

            private Decimal _tipcamb;
            public Decimal tipcamb
            {
                get { return _tipcamb; }
                set { _tipcamb = value; }
            }

            private Decimal _bimp_sunat1;
            public Decimal bimp_sunat1
            {
                get { return _bimp_sunat1; }
                set { _bimp_sunat1 = value; }
            }

            private Decimal _exon;
            public Decimal exon
            {
                get { return _exon; }
                set { _exon = value; }
            }

            private Decimal _migv;
            public Decimal migv
            {
                get { return _migv; }
                set { _migv = value; }
            }

            private Decimal _pven;
            public Decimal pven
            {
                get { return _pven; }
                set { _pven = value; }
            }

            private String _status;
            public String status
            {
                get { return _status; }
                set { _status = value; }
            }

            private String _usuar;
            public String usuar
            {
                get { return _usuar; }
                set { _usuar = value; }
            }

            private DateTime _fecre;
            public DateTime fecre
            {
                get { return _fecre; }
                set { _fecre = value; }
            }

            private DateTime _feact;
            public DateTime feact
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

                //XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("itemsdet"); attrib1.Value = obj.itemsdet;
                //XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("moduloiddes"); attrib2.Value = obj.moduloiddes;
                //XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("localdes"); attrib3.Value = obj.localdes;
                //XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("status"); attrib4.Value = obj.status;
                //XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib5.Value = fecha(obj.fechdoc).ToShortDateString();
                //XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib6.Value = obj.almacaccionid;
                //XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib7.Value = obj.ctacte;
                //XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("ctactename"); attrib8.Value = obj.ctactename;
                //XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("productid"); attrib9.Value = obj.productid;
                //XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("productname"); attrib10.Value = obj.productname;
                //XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("itemref"); attrib11.Value = obj.itemref;
                //XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib12.Value = obj.tipref;
                //XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("serref"); attrib13.Value = obj.serref;
                //XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("numref"); attrib14.Value = obj.numref;
                //XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib15.Value = fecha(obj.fechref).ToShortDateString();
                //XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("tipped"); attrib16.Value = obj.tipped;
                //XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("serped"); attrib17.Value = obj.serped;
                //XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("numped"); attrib18.Value = obj.numped;
                //XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib19.Value = obj.cantidad.ToString();
                //XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("valor"); attrib20.Value = obj.valor.ToString();
                //XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("importe"); attrib21.Value = obj.importe.ToString();
                //XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("cantidadcta"); attrib22.Value = obj.cantidadcta.ToString();
                //XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("cantidadfac"); attrib23.Value = obj.cantidadfac.ToString();
                //XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("precinit"); attrib24.Value = obj.precinit.ToString();
                //XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("chkdcto"); attrib25.Value = obj.chkdcto.ToString();
                //XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("pdscto"); attrib26.Value = obj.pdscto.ToString();
                //XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("idscto"); attrib27.Value = obj.idscto.ToString();
                //XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib28.Value = obj.precunit.ToString();
                //XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("importfac"); attrib29.Value = obj.importfac.ToString();
                //XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("incprec"); attrib30.Value = obj.incprec;
                //XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("totimpto"); attrib31.Value = obj.totimpto.ToString();
                //XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("pigv"); attrib32.Value = obj.pigv.ToString();
                //XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib33.Value = obj.moneda;
                //XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("tcamb"); attrib34.Value = obj.tcamb.ToString();
                //XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("compradorid"); attrib35.Value = obj.compradorid;
                //XmlAttribute attrib36 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib36.Value = obj.glosa;
                //XmlAttribute attrib37 = objNode.OwnerDocument.CreateAttribute("perianio"); attrib37.Value = obj.perianio;
                //XmlAttribute attrib38 = objNode.OwnerDocument.CreateAttribute("perimes"); attrib38.Value = obj.perimes;
                //XmlAttribute attrib39 = objNode.OwnerDocument.CreateAttribute("fechentrega"); attrib39.Value = fecha(obj.fechentrega).ToShortDateString();
                //XmlAttribute attrib40 = objNode.OwnerDocument.CreateAttribute("aniosemana"); attrib40.Value = obj.aniosemana;
                //XmlAttribute attrib41 = objNode.OwnerDocument.CreateAttribute("aniosemanaconfirm"); attrib41.Value = obj.aniosemanaconfirm;
                //XmlAttribute attrib42 = objNode.OwnerDocument.CreateAttribute("precioanterior"); attrib42.Value = obj.precioanterior.ToString();
                //XmlAttribute attrib43 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib43.Value = obj.usuar;
                //XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("equiv_id"); attrib44.Value = obj.equivid.ToString();
                //XmlAttribute attrib45 = objNode.OwnerDocument.CreateAttribute("cantidad_c"); attrib45.Value = obj.cantidad_c.ToString();
                //XmlAttribute attrib46 = objNode.OwnerDocument.CreateAttribute("precunit_c"); attrib46.Value = obj.precunit_c.ToString();

                //XmlAttribute attrib47 = objNode.OwnerDocument.CreateAttribute("cantidadcta_c"); attrib47.Value = obj.Cantidadcta_c.ToString();

                //objNode.Attributes.Append(attrib1);
                //objNode.Attributes.Append(attrib2);
                //objNode.Attributes.Append(attrib3);
                //objNode.Attributes.Append(attrib4);
                //objNode.Attributes.Append(attrib5);
                //objNode.Attributes.Append(attrib6);
                //objNode.Attributes.Append(attrib7);
                //objNode.Attributes.Append(attrib8);
                //objNode.Attributes.Append(attrib9);
                //objNode.Attributes.Append(attrib10);
                //objNode.Attributes.Append(attrib11);
                //objNode.Attributes.Append(attrib12);
                //objNode.Attributes.Append(attrib13);
                //objNode.Attributes.Append(attrib14);
                //objNode.Attributes.Append(attrib15);
                //objNode.Attributes.Append(attrib16);
                //objNode.Attributes.Append(attrib17);
                //objNode.Attributes.Append(attrib18);
                //objNode.Attributes.Append(attrib19);
                //objNode.Attributes.Append(attrib20);
                //objNode.Attributes.Append(attrib21);
                //objNode.Attributes.Append(attrib22);
                //objNode.Attributes.Append(attrib23);
                //objNode.Attributes.Append(attrib24);
                //objNode.Attributes.Append(attrib25);
                //objNode.Attributes.Append(attrib26);
                //objNode.Attributes.Append(attrib27);
                //objNode.Attributes.Append(attrib28);
                //objNode.Attributes.Append(attrib29);
                //objNode.Attributes.Append(attrib30);
                //objNode.Attributes.Append(attrib31);
                //objNode.Attributes.Append(attrib32);
                //objNode.Attributes.Append(attrib33);
                //objNode.Attributes.Append(attrib34);
                //objNode.Attributes.Append(attrib35);
                //objNode.Attributes.Append(attrib36);
                //objNode.Attributes.Append(attrib37);
                //objNode.Attributes.Append(attrib38);
                //objNode.Attributes.Append(attrib39);
                //objNode.Attributes.Append(attrib40);
                //objNode.Attributes.Append(attrib41);
                //objNode.Attributes.Append(attrib42);
                //objNode.Attributes.Append(attrib43);
                //objNode.Attributes.Append(attrib44);
                //objNode.Attributes.Append(attrib45);
                //objNode.Attributes.Append(attrib46);
                //objNode.Attributes.Append(attrib47);

                //objXMLDoc.DocumentElement.AppendChild(objNode);
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
                //objNode = objXMLDoc.CreateElement("Item");

                //XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("itemsdet"); attrib1.Value = obj.itemsdet;

                //objNode.Attributes.Append(attrib1);

                //objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }

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

        public DateTime fechaulting { get; set; }
    }
}
