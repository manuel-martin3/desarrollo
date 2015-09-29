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
    public class tb_co_canjeletraretencion
    {
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

        private String _diarioid;
        public String diarioid
        {
            get { return _diarioid; }

            set { _diarioid = value; }
        }

        private String _asiento;
        public String asiento
        {
            get { return _asiento; }

            set { _asiento = value; }
        }

        private String _tiporegistro;
        public String tiporegistro
        {
            get { return _tiporegistro; }

            set { _tiporegistro = value; }
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

        private String _direc;
        public String direc
        {
            get { return _direc; }

            set { _direc = value; }
        }

        private String _ubige;
        public String ubige
        {
            get { return _ubige; }

            set { _ubige = value; }
        }

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

        private DateTime? _fechdoc;
        public DateTime? fechdoc
        {
            get { return _fechdoc; }

            set { _fechdoc = value; }
        }

        private DateTime? _fechvcto;
        public DateTime? fechvcto
        {
            get { return _fechvcto; }

            set { _fechvcto = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }

            set { _moneda = value; }
        }

        private Decimal _tipcamb;
        public Decimal tipcamb
        {
            get { return _tipcamb; }

            set { _tipcamb = value; }
        }

        private String _tipcambuso;
        public String tipcambuso
        {
            get { return _tipcambuso; }

            set { _tipcambuso = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private String _diarioidpago;
        public String diarioidpago
        {
            get { return _diarioidpago; }

            set { _diarioidpago = value; }
        }

        private String _monedap;
        public String monedap
        {
            get { return _monedap; }

            set { _monedap = value; }
        }

        private String _numdocpago;
        public String numdocpago
        {
            get { return _numdocpago; }

            set { _numdocpago = value; }
        }

        private String _flujoefectivo;
        public String flujoefectivo
        {
            get { return _flujoefectivo; }

            set { _flujoefectivo = value; }
        }

        private String _mediopago;
        public String mediopago
        {
            get { return _mediopago; }

            set { _mediopago = value; }
        }

        private Decimal _importesoles;
        public Decimal importesoles
        {
            get { return _importesoles; }

            set { _importesoles = value; }
        }

        private Decimal _importedolares;
        public Decimal importedolares
        {
            get { return _importedolares; }

            set { _importedolares = value; }
        }

        private Decimal _importeotros;
        public Decimal importeotros
        {
            get { return _importeotros; }

            set { _importeotros = value; }
        }

        private String _ctacteaval;
        public String ctacteaval
        {
            get { return _ctacteaval; }

            set { _ctacteaval = value; }
        }

        private String _nmrucaval;
        public String nmrucaval
        {
            get { return _nmrucaval; }

            set { _nmrucaval = value; }
        }

        private String _referencia;
        public String referencia
        {
            get { return _referencia; }

            set { _referencia = value; }
        }

        private String _lugargiro;
        public String lugargiro
        {
            get { return _lugargiro; }

            set { _lugargiro = value; }
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

        //*************************************************        
        public class Item
        {
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

            private String _diarioid;
            public String diarioid
            {
                get { return _diarioid; }

                set { _diarioid = value; }
            }

            private String _asiento;
            public String asiento
            {
                get { return _asiento; }

                set { _asiento = value; }
            }

            private String _asientoitems;
            public String asientoitems
            {
                get { return _asientoitems; }

                set { _asientoitems = value; }
            }

            private String _cuentaid;
            public String cuentaid
            {
                get { return _cuentaid; }

                set { _cuentaid = value; }
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

            private DateTime _fechdoc;
            public DateTime fechdoc
            {
                get { return _fechdoc; }

                set { _fechdoc = value; }
            }

            private DateTime _fechvcto;
            public DateTime fechvcto
            {
                get { return _fechvcto; }

                set { _fechvcto = value; }
            }

            private DateTime _fechpago;
            public DateTime fechpago
            {
                get { return _fechpago; }

                set { _fechpago = value; }
            }

            private String _moneda;
            public String moneda
            {
                get { return _moneda; }

                set { _moneda = value; }
            }

            private Decimal _tipcamb;
            public Decimal tipcamb
            {
                get { return _tipcamb; }

                set { _tipcamb = value; }
            }

            private String _tipcambuso;
            public String tipcambuso
            {
                get { return _tipcambuso; }

                set { _tipcambuso = value; }
            }

            private String _motivo;
            public String motivo
            {
                get { return _motivo; }

                set { _motivo = value; }
            }

            private Decimal _importe1;
            public Decimal importe1
            {
                get { return _importe1; }

                set { _importe1 = value; }
            }

            private Decimal _total1;
            public Decimal total1
            {
                get { return _total1; }

                set { _total1 = value; }
            }

            private Decimal _importe2;
            public Decimal importe2
            {
                get { return _importe2; }

                set { _importe2 = value; }
            }

            private Decimal _total2;
            public Decimal total2
            {
                get { return _total2; }

                set { _total2 = value; }
            }

            private String _ctacte1;
            public String ctacte1
            {
                get { return _ctacte1; }

                set { _ctacte1 = value; }
            }

            private String _nmruc1;
            public String nmruc1
            {
                get { return _nmruc1; }

                set { _nmruc1 = value; }
            }

            private String _ctactename1;
            public String ctactename1
            {
                get { return _ctactename1; }

                set { _ctactename1 = value; }
            }

            private String _direc1;
            public String direc1
            {
                get { return _direc1; }

                set { _direc1 = value; }
            }

            private String _ctacte2;
            public String ctacte2
            {
                get { return _ctacte2; }

                set { _ctacte2 = value; }
            }

            private String _nmruc2;
            public String nmruc2
            {
                get { return _nmruc2; }

                set { _nmruc2 = value; }
            }

            private String _ctactename2;
            public String ctactename2
            {
                get { return _ctactename2; }

                set { _ctactename2 = value; }
            }

            private String _direc2;
            public String direc2
            {
                get { return _direc2; }

                set { _direc2 = value; }
            }

            private String _importeenletras;
            public String importeenletras
            {
                get { return _importeenletras; }

                set { _importeenletras = value; }
            }

            private String _telefaval;
            public String telefaval
            {
                get { return _telefaval; }

                set { _telefaval = value; }
            }

            private Decimal _cantletras;
            public Decimal cantletras
            {
                get { return _cantletras; }

                set { _cantletras = value; }
            }

            private Decimal _cantdias;
            public Decimal cantdias
            {
                get { return _cantdias; }

                set { _cantdias = value; }
            }

            private Boolean? _retencion;
            public Boolean? retencion
            {
                get { return _retencion; }

                set { _retencion = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("asientoitems"); attrib1.Value = obj.asientoitems;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("cuentaid"); attrib2.Value = obj.cuentaid;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib3.Value = obj.ctacte;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("nmruc"); attrib4.Value = obj.nmruc;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib5.Value = obj.tipdoc;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib6.Value = obj.serdoc;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib7.Value = obj.numdoc;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib8.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("fechvcto"); attrib9.Value = fecha(obj.fechvcto).ToShortDateString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("fechpago"); attrib10.Value = fecha(obj.fechpago).ToShortDateString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib11.Value = obj.moneda;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("importe1"); attrib12.Value = obj.importe1.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("total1"); attrib13.Value = obj.total1.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("importe2"); attrib14.Value = obj.importe2.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("total2"); attrib15.Value = obj.total2.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("ctacte1"); attrib16.Value = obj.ctacte1;
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("nmruc1"); attrib17.Value = obj.nmruc1;
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("ctactename1"); attrib18.Value = obj.ctactename1;
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("direc1"); attrib19.Value = obj.direc1;
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("ctacte2"); attrib20.Value = obj.ctacte2;
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("nmruc2"); attrib21.Value = obj.nmruc2;
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("ctactename2"); attrib22.Value = obj.ctactename2;
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("direc2"); attrib23.Value = obj.direc2;
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("importeenletras"); attrib24.Value = obj.importeenletras;
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("telefaval"); attrib25.Value = obj.telefaval;
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("cantletras"); attrib26.Value = obj.cantletras.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("cantdias"); attrib27.Value = obj.cantdias.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("status"); attrib28.Value = obj.status;
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib29.Value = obj.usuar;

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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("asientoitems"); attrib1.Value = obj.asientoitems;

                objNode.Attributes.Append(attrib1);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }

        public static bool IsNotNullOrEmpty(String input)
        {
            return !String.IsNullOrEmpty(input);
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
    }
}
