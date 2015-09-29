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
    
    public class tb_pp_ordenproduccion
    {
        private String _dominioid;
        public String dominioid
        {
            get { return _dominioid; }

            set { _dominioid = value; }
        }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private String _local;
        public String local
        {
            get { return _local; }

            set { _local = value; }
        }

        private String _tipodoc;
        public String tipodoc
        {
            get { return _tipodoc; }

            set { _tipodoc = value; }
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

        private DateTime? _fechdoc;
        public DateTime? fechdoc
        {
            get { return _fechdoc; }

            set { _fechdoc = value; }
        }

        private String _ctacte;
        public String ctacte
        {
            get { return _ctacte; }

            set { _ctacte = value; }
        }

        private String _nmruc;
        public String nmruc
        {
            get { return _nmruc; }

            set { _nmruc = value; }
        }

        private String _ctactename;
        public String ctactename
        {
            get { return _ctactename; }

            set { _ctactename = value; }
        }

        private String _direcnume;
        public String direcnume
        {
            get { return _direcnume; }

            set { _direcnume = value; }
        }

        private String _direcname;
        public String direcname
        {
            get { return _direcname; }

            set { _direcname = value; }
        }

        private String _direcdeta;
        public String direcdeta
        {
            get { return _direcdeta; }

            set { _direcdeta = value; }
        }

        private String _tipref;
        public String tipref
        {
            get { return _tipref; }

            set { _tipref = value; }
        }

        private String _serref;
        public String serref
        {
            get { return _serref; }

            set { _serref = value; }
        }

        private String _numref;
        public String numref
        {
            get { return _numref; }

            set { _numref = value; }
        }

        private DateTime? _fechref;
        public DateTime? fechref
        {
            get { return _fechref; }

            set { _fechref = value; }
        }

        private DateTime? _fechaini;
        public DateTime? fechaini
        {
            get { return _fechaini; }

            set { _fechaini = value; }
        }

        private DateTime? _fechafin;
        public DateTime? fechafin
        {
            get { return _fechafin; }

            set { _fechafin = value; }
        }

        private Decimal _items;
        public Decimal items
        {
            get { return _items; }

            set { _items = value; }
        }

        private Decimal _totpzas;
        public Decimal totpzas
        {
            get { return _totpzas; }

            set { _totpzas = value; }
        }

        private Decimal _totpzas1ra;
        public Decimal totpzas1ra
        {
            get { return _totpzas1ra; }

            set { _totpzas1ra = value; }
        }

        private Decimal _totpzas2da;
        public Decimal totpzas2da
        {
            get { return _totpzas2da; }

            set { _totpzas2da = value; }
        }

        private Decimal _totpzasmerma;
        public Decimal totpzasmerma
        {
            get { return _totpzasmerma; }

            set { _totpzasmerma = value; }
        }

        private Decimal _totpzaspend;
        public Decimal totpzaspend
        {
            get { return _totpzaspend; }

            set { _totpzaspend = value; }
        }

        private DateTime? _fech_pri_aten;
        public DateTime? fech_pri_aten
        {
            get { return _fech_pri_aten; }

            set { _fech_pri_aten = value; }
        }

        private DateTime? _fech_ult_aten;
        public DateTime? fech_ult_aten
        {
            get { return _fech_ult_aten; }

            set { _fech_ult_aten = value; }
        }

        private Decimal _costoestimado;
        public Decimal costoestimado
        {
            get { return _costoestimado; }

            set { _costoestimado = value; }
        }

        private Decimal _costoreal;
        public Decimal costoreal
        {
            get { return _costoreal; }

            set { _costoreal = value; }
        }

        private String _responsable;
        public String responsable
        {
            get { return _responsable; }

            set { _responsable = value; }
        }

        private String _user_apr1;
        public String user_apr1
        {
            get { return _user_apr1; }

            set { _user_apr1 = value; }
        }

        private DateTime? _fech_apr1;
        public DateTime? fech_apr1
        {
            get { return _fech_apr1; }

            set { _fech_apr1 = value; }
        }

        private String _user_apr2;
        public String user_apr2
        {
            get { return _user_apr2; }

            set { _user_apr2 = value; }
        }

        private DateTime? _fech_apr2;
        public DateTime? fech_apr2
        {
            get { return _fech_apr2; }

            set { _fech_apr2 = value; }
        }

        private String _canalventaref;
        public String canalventaref
        {
            get { return _canalventaref; }

            set { _canalventaref = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private String _lineaid;
        public String lineaid
        {
            get { return _lineaid; }

            set { _lineaid = value; }
        }

        private String _marcaid;
        public String marcaid
        {
            get { return _marcaid; }

            set { _marcaid = value; }
        }

        private String _articid;
        public String articid
        {
            get { return _articid; }

            set { _articid = value; }
        }

        private String _articname;
        public String articname
        {
            get { return _articname; }

            set { _articname = value; }
        }

        private String _faseactual;
        public String faseactual
        {
            get { return _faseactual; }

            set { _faseactual = value; }
        }

        private Int32 _fasesrealizadas;
        public Int32 fasesrealizadas
        {
            get { return _fasesrealizadas; }

            set { _fasesrealizadas = value; }
        }

        private Decimal _faseactualpzas;
        public Decimal faseactualpzas
        {
            get { return _faseactualpzas; }

            set { _faseactualpzas = value; }
        }

        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }

        private String _perimes;
        public String perimes
        {
            get { return _perimes; }

            set { _perimes = value; }
        }

        private String _status_aprob;
        public String status_aprob
        {
            get { return _status_aprob; }

            set { _status_aprob = value; }
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

        //*****************DETALLE*********************        
        public class Item
        {
            private String _itemsdet;
            public String itemsdet
            {
                get { return _itemsdet; }

                set { _itemsdet = value; }
            }

            private DateTime? _fechdoc;
            public DateTime? fechdoc
            {
                get { return _fechdoc; }

                set { _fechdoc = value; }
            }

            private String _ctacte;
            public String ctacte
            {
                get { return _ctacte; }

                set { _ctacte = value; }
            }

            private String _itemref;
            public String itemref
            {
                get { return _itemref; }

                set { _itemref = value; }
            }

            private String _tipref;
            public String tipref
            {
                get { return _tipref; }

                set { _tipref = value; }
            }

            private String _serref;
            public String serref
            {
                get { return _serref; }

                set { _serref = value; }
            }

            private String _numref;
            public String numref
            {
                get { return _numref; }

                set { _numref = value; }
            }

            private DateTime? _fechref;
            public DateTime? fechref
            {
                get { return _fechref; }

                set { _fechref = value; }
            }

            private String _tipoperef;
            public String tipoperef
            {
                get { return _tipoperef; }

                set { _tipoperef = value; }
            }

            private String _lineaid;
            public String lineaid
            {
                get { return _lineaid; }

                set { _lineaid = value; }
            }

            private String _marcaid;
            public String marcaid
            {
                get { return _marcaid; }

                set { _marcaid = value; }
            }

            private String _articid;
            public String articid
            {
                get { return _articid; }

                set { _articid = value; }
            }

            private String _productid;
            public String productid
            {
                get { return _productid; }

                set { _productid = value; }
            }

            private String _articidold;
            public String articidold
            {
                get { return _articidold; }

                set { _articidold = value; }
            }

            private String _articname;
            public String articname
            {
                get { return _articname; }

                set { _articname = value; }
            }

            private String _productname;
            public String productname
            {
                get { return _productname; }

                set { _productname = value; }
            }

            private String _colorid;
            public String colorid
            {
                get { return _colorid; }

                set { _colorid = value; }
            }

            private String _colorname;
            public String colorname
            {
                get { return _colorname; }

                set { _colorname = value; }
            }

            private String _tallaid;
            public String tallaid
            {
                get { return _tallaid; }

                set { _tallaid = value; }
            }

            private String _coltalla;
            public String coltalla
            {
                get { return _coltalla; }

                set { _coltalla = value; }
            }

            private String _coltallaname;
            public String coltallaname
            {
                get { return _coltallaname; }

                set { _coltallaname = value; }
            }

            private Decimal _cantidad;
            public Decimal cantidad
            {
                get { return _cantidad; }

                set { _cantidad = value; }
            }

            private Decimal _cantidad1ra;
            public Decimal cantidad1ra
            {
                get { return _cantidad1ra; }

                set { _cantidad1ra = value; }
            }

            private Decimal _cantidad2da;
            public Decimal cantidad2da
            {
                get { return _cantidad2da; }

                set { _cantidad2da = value; }
            }

            private Decimal _cantidadmerma;
            public Decimal cantidadmerma
            {
                get { return _cantidadmerma; }

                set { _cantidadmerma = value; }
            }

            private Decimal _cant_pend;
            public Decimal cant_pend
            {
                get { return _cant_pend; }

                set { _cant_pend = value; }
            }

            private DateTime? _fech_pri_aten;
            public DateTime? fech_pri_aten
            {
                get { return _fech_pri_aten; }

                set { _fech_pri_aten = value; }
            }

            private DateTime? _fech_ult_aten;
            public DateTime? fech_ult_aten
            {
                get { return _fech_ult_aten; }

                set { _fech_ult_aten = value; }
            }

            private String _canalventaref;
            public String canalventaref
            {
                get { return _canalventaref; }

                set { _canalventaref = value; }
            }

            private String _glosa;
            public String glosa
            {
                get { return _glosa; }

                set { _glosa = value; }
            }

            private String _perimes;
            public String perimes
            {
                get { return _perimes; }

                set { _perimes = value; }
            }

            private String _perianio;
            public String perianio
            {
                get { return _perianio; }

                set { _perianio = value; }
            }

            private String _status_aprob;
            public String status_aprob
            {
                get { return _status_aprob; }

                set { _status_aprob = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("itemsdet"); attrib1.Value = obj.itemsdet;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib2.Value = obj.fechdoc.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib3.Value = obj.ctacte;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("itemref"); attrib4.Value = obj.itemref;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib5.Value = obj.tipref;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("serref"); attrib6.Value = obj.serref;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("numref"); attrib7.Value = obj.numref;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib8.Value = obj.fechref.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("tipoperef"); attrib9.Value = obj.tipoperef;
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("lineaid"); attrib10.Value = obj.lineaid;
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("marcaid"); attrib11.Value = obj.marcaid;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("articid"); attrib12.Value = obj.articid;
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("productid"); attrib13.Value = obj.productid;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("articidold"); attrib14.Value = obj.articidold;
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("articname"); attrib15.Value = obj.articname;
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("productname"); attrib16.Value = obj.productname;
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib17.Value = obj.colorid;
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("colorname"); attrib18.Value = obj.colorname;
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("tallaid"); attrib19.Value = obj.tallaid;
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("coltalla"); attrib20.Value = obj.coltalla;
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("coltallaname"); attrib21.Value = obj.coltallaname;
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib22.Value = obj.cantidad.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("cantidad1ra"); attrib23.Value = obj.cantidad1ra.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("cantidad2da"); attrib24.Value = obj.cantidad2da.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("cantidadmerma"); attrib25.Value = obj.cantidadmerma.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("cant_pend"); attrib26.Value = obj.cant_pend.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("fech_pri_aten"); attrib27.Value = obj.fech_pri_aten.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("fech_ult_aten"); attrib28.Value = obj.fech_ult_aten.ToString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("canalventaref"); attrib29.Value = obj.canalventaref.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib30.Value = obj.glosa;
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("perimes"); attrib31.Value = obj.perimes;
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("perianio"); attrib32.Value = obj.perianio;
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("status_aprob"); attrib33.Value = obj.status_aprob;  
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("status"); attrib34.Value = obj.status;  
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib35.Value = obj.usuar;

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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("itemsdet"); attrib1.Value = obj.itemsdet;    

                objNode.Attributes.Append(attrib1);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }

        #region *** validar fecha en formato correcto
        public DateTime? fecha(DateTime pfecha)
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
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m."))
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

        public DateTime? fecha02(DateTime pfecha)
        {
            String lfech;
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.", culture, System.Globalization.DateTimeStyles.AssumeLocal))

                {
                    lfech = pfecha.ToString();
                }
                else
                {
                    lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900 12:00:00 a.m.").ToString();
            }
            return DateTime.Parse(lfech, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }
        #endregion

    }
}
