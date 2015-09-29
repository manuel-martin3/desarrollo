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
    public class tb_co_percepcionesxml
    {
        #region Fields
        private String _perianio;
        private String _perimes;
        private String _moduloid;
        private String _local;
        private String _diarioid;
        private String _asiento;
        private String _tiporegistro;
        private String _ctacte;
        private String _nmruc;
        private String _tipdid;
        private String _ctactename;
        private String _direc;
        private String _ubige;
        private String _tipdoc;
        private String _serdoc;
        private String _numdoc;
        private DateTime? _fechdoc;
        private DateTime? _fechvcto;
        private String _moneda;
        private Decimal? _tipcamb;
        private String _tipcambuso;
        private String _glosa;
        private String _diarioidpago;
        private String _monedap;
        private String _numdocpago;
        private String _flujoefectivo;
        private String _mediopago;
        private Decimal? _importeoriginal;
        private Decimal? _importecobranza;
        private String _percepcionid;
        private Decimal? _porcpercepcion;
        private Decimal? _importepercepcion;
        private Decimal? _importetotal;
        private String _status;
        private String _usuar;
        private DateTime? _fecre;
        private DateTime? _feact;

        #endregion

        #region Properties
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        public String perimes
        {
            get { return _perimes; }
            set { _perimes = value; }
        }

        public String moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        public String local
        {
            get { return _local; }
            set { _local = value; }
        }

        public String diarioid
        {
            get { return _diarioid; }
            set { _diarioid = value; }
        }

        public String asiento
        {
            get { return _asiento; }
            set { _asiento = value; }
        }

        public String tiporegistro
        {
            get { return _tiporegistro; }
            set { _tiporegistro = value; }
        }

        public String ctacte
        {
            get
            {
                return _ctacte;
            }
            set
            {
                _ctacte = value;
            }
        }

        public String tipdid
        {
            get { return _tipdid; }
            set { _tipdid = value; }
        }

        public String nmruc
        {
            get
            {
                return _nmruc;
            }
            set
            {
                _nmruc = value;
            }
        }

        public String ctactename
        {
            get
            {
                return _ctactename;
            }
            set
            {
                _ctactename = value;
            }
        }

        public String direc
        {
            get
            {
                return _direc;
            }
            set
            {
                _direc = value;
            }
        }

        public String ubige
        {
            get
            {
                return _ubige;
            }
            set
            {
                _ubige = value;
            }
        }

        public String tipdoc
        {
            get
            {
                return _tipdoc;
            }
            set
            {
                _tipdoc = value;
            }
        }

        public String serdoc
        {
            get
            {
                return _serdoc;
            }
            set
            {
                _serdoc = value;
            }
        }

        public String numdoc
        {
            get
            {
                return _numdoc;
            }
            set
            {
                _numdoc = value;
            }
        }

        public DateTime? fechdoc
        {
            get
            {
                return _fechdoc;
            }
            set
            {
                _fechdoc = value;
            }
        }

        public DateTime? fechvcto
        {
            get
            {
                return _fechvcto;
            }
            set
            {
                _fechvcto = value;
            }
        }

        public String moneda
        {
            get
            {
                return _moneda;
            }
            set
            {
                _moneda = value;
            }
        }

        public Decimal? tipcamb
        {
            get
            {
                return _tipcamb;
            }
            set
            {
                _tipcamb = value;
            }
        }

        public String tipcambuso
        {
            get
            {
                return _tipcambuso;
            }
            set
            {
                _tipcambuso = value;
            }
        }

        public String glosa
        {
            get
            {
                return _glosa;
            }
            set
            {
                _glosa = value;
            }
        }

        public String diarioidpago
        {
            get
            {
                return _diarioidpago;
            }
            set
            {
                _diarioidpago = value;
            }
        }

        public String monedap
        {
            get
            {
                return _monedap;
            }
            set
            {
                _monedap = value;
            }
        }

        public String numdocpago
        {
            get
            {
                return _numdocpago;
            }
            set
            {
                _numdocpago = value;
            }
        }

        public String flujoefectivo
        {
            get
            {
                return _flujoefectivo;
            }
            set
            {
                _flujoefectivo = value;
            }
        }

        public String mediopago
        {
            get
            {
                return _mediopago;
            }
            set
            {
                _mediopago = value;
            }
        }

        public Decimal? importeoriginal
        {
            get
            {
                return _importeoriginal;
            }
            set
            {
                _importeoriginal = value;
            }
        }

        public Decimal? importecobranza
        {
            get
            {
                return _importecobranza;
            }
            set
            {
                _importecobranza = value;
            }
        }

        public String percepcionid
        {
            get
            {
                return _percepcionid;
            }
            set
            {
                _percepcionid = value;
            }
        }

        public Decimal? porcpercepcion
        {
            get
            {
                return _porcpercepcion;
            }
            set
            {
                _porcpercepcion = value;
            }
        }

        public Decimal? importepercepcion
        {
            get
            {
                return _importepercepcion;
            }
            set
            {
                _importepercepcion = value;
            }
        }

        public Decimal? importetotal
        {
            get
            {
                return _importetotal;
            }
            set
            {
                _importetotal = value;
            }
        }

        public String status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public String usuar
        {
            get
            {
                return _usuar;
            }
            set
            {
                _usuar = value;
            }
        }

        public DateTime? fecre
        {
            get
            {
                return _fecre;
            }
            set
            {
                _fecre = value;
            }
        }

        public DateTime? feact
        {
            get
            {
                return _feact;
            }
            set
            {
                _feact = value;
            }
        }

        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }

        private String _asientoini;
        public String asientoini
        {
            get { return _asientoini; }

            set { _asientoini = value; }
        }

        private String _asientofin;
        public String asientofin
        {
            get { return _asientofin; }

            set { _asientofin = value; }
        }

        private String _fimpresion;
        public String fimpresion
        {
            get
            {
                return _fimpresion;
            }
            set
            {
                _fimpresion = value;
            }
        }
        #endregion

        public class Item
        {
            #region Fields
            private String _perianio;
            private String _perimes;
            private String _moduloid;
            private String _local;
            private String _diarioid;
            private String _asiento;
            private String _asientoitems;
            private String _cuentaid;
            private String _ctacte;
            private String _tipdid;
            private String _nmruc;
            private String _tipdoc;
            private String _serdoc;
            private String _numdoc;
            private DateTime _fechdoc;
            private DateTime _fechvcto;
            private DateTime _fechpago;
            private String _moneda;
            private Decimal? _tipcamb;
            private String _tipcambuso;
            private String _motivo;
            private Decimal? _importeorigendolares;
            private Decimal? _importecobrodolares1;
            private Decimal? _importecobrodolares2;
            private Decimal? _importepercepciondolares;
            private Decimal? _importetotaldolares;
            private Decimal? _importedifcambio;
            private Decimal? _importeorigensoles;
            private Decimal? _importecobrosoles;
            private Decimal? _importeorigen;
            private Decimal? _importecobranza;
            private String _percepcionid;
            private Decimal? _porcpercepcion;
            private Decimal? _importepercepcionsoles;
            private String _derechocreditofiscal;
            private String _zonaafectadaterremoto;
            private String _sujetoagenteperc;
            private Decimal? _importetotalsoles;
            private Boolean? _percepcion;
            private String _status;
            private String _usuar;
            private DateTime? _fecre;
            private DateTime? _feact;
            #endregion

            #region Properties
            public String perianio
            {
                get
                {
                    return _perianio;
                }
                set
                {
                    _perianio = value;
                }
            }

            public String perimes
            {
                get
                {
                    return _perimes;
                }
                set
                {
                    _perimes = value;
                }
            }

            public String moduloid
            {
                get
                {
                    return _moduloid;
                }
                set
                {
                    _moduloid = value;
                }
            }

            public String local
            {
                get
                {
                    return _local;
                }
                set
                {
                    _local = value;
                }
            }

            public String diarioid
            {
                get
                {
                    return _diarioid;
                }
                set
                {
                    _diarioid = value;
                }
            }

            public String asiento
            {
                get
                {
                    return _asiento;
                }
                set
                {
                    _asiento = value;
                }
            }

            public String asientoitems
            {
                get
                {
                    return _asientoitems;
                }
                set
                {
                    _asientoitems = value;
                }
            }

            public String cuentaid
            {
                get
                {
                    return _cuentaid;
                }
                set
                {
                    _cuentaid = value;
                }
            }

            public String ctacte
            {
                get
                {
                    return _ctacte;
                }
                set
                {
                    _ctacte = value;
                }
            }

            public String tipdid
            {
                get { return _tipdid; }
                set { _tipdid = value; }
            }
            
            public String nmruc
            {
                get
                {
                    return _nmruc;
                }
                set
                {
                    _nmruc = value;
                }
            }

            public String tipdoc
            {
                get
                {
                    return _tipdoc;
                }
                set
                {
                    _tipdoc = value;
                }
            }

            public String serdoc
            {
                get
                {
                    return _serdoc;
                }
                set
                {
                    _serdoc = value;
                }
            }

            public String numdoc
            {
                get
                {
                    return _numdoc;
                }
                set
                {
                    _numdoc = value;
                }
            }

            public DateTime fechdoc
            {
                get { return _fechdoc; }
                set { _fechdoc = value; }
            }

            public DateTime fechvcto
            {
                get { return _fechvcto; }
                set { _fechvcto = value; }
            }

            public DateTime fechpago
            {
                get { return _fechpago; }
                set { _fechpago = value; }
            }

            public String moneda
            {
                get
                {
                    return _moneda;
                }
                set
                {
                    _moneda = value;
                }
            }

            public Decimal? tipcamb
            {
                get
                {
                    return _tipcamb;
                }
                set
                {
                    _tipcamb = value;
                }
            }

            public String tipcambuso
            {
                get
                {
                    return _tipcambuso;
                }
                set
                {
                    _tipcambuso = value;
                }
            }

            public String motivo
            {
                get
                {
                    return _motivo;
                }
                set
                {
                    _motivo = value;
                }
            }

            public Decimal? importeorigendolares
            {
                get
                {
                    return _importeorigendolares;
                }
                set
                {
                    _importeorigendolares = value;
                }
            }

            public Decimal? importecobrodolares1
            {
                get
                {
                    return _importecobrodolares1;
                }
                set
                {
                    _importecobrodolares1 = value;
                }
            }

            public Decimal? importecobrodolares2
            {
                get
                {
                    return _importecobrodolares2;
                }
                set
                {
                    _importecobrodolares2 = value;
                }
            }

            public Decimal? importepercepciondolares
            {
                get
                {
                    return _importepercepciondolares;
                }
                set
                {
                    _importepercepciondolares = value;
                }
            }

            public Decimal? importetotaldolares
            {
                get
                {
                    return _importetotaldolares;
                }
                set
                {
                    _importetotaldolares = value;
                }
            }

            public Decimal? importedifcambio
            {
                get
                {
                    return _importedifcambio;
                }
                set
                {
                    _importedifcambio = value;
                }
            }

            public Decimal? importeorigensoles
            {
                get
                {
                    return _importeorigensoles;
                }
                set
                {
                    _importeorigensoles = value;
                }
            }

            public Decimal? importecobrosoles
            {
                get
                {
                    return _importecobrosoles;
                }
                set
                {
                    _importecobrosoles = value;
                }
            }

            public Decimal? importeorigen
            {
                get
                {
                    return _importeorigen;
                }
                set
                {
                    _importeorigen = value;
                }
            }

            public Decimal? importecobranza
            {
                get
                {
                    return _importecobranza;
                }
                set
                {
                    _importecobranza = value;
                }
            }

            public String percepcionid
            {
                get
                {
                    return _percepcionid;
                }
                set
                {
                    _percepcionid = value;
                }
            }

            public Decimal? porcpercepcion
            {
                get
                {
                    return _porcpercepcion;
                }
                set
                {
                    _porcpercepcion = value;
                }
            }

            public Decimal? importepercepcionsoles
            {
                get
                {
                    return _importepercepcionsoles;
                }
                set
                {
                    _importepercepcionsoles = value;
                }
            }

            public String derechocreditofiscal
            {
                get
                {
                    return _derechocreditofiscal;
                }
                set
                {
                    _derechocreditofiscal = value;
                }
            }

            public String zonaafectadaterremoto
            {
                get
                {
                    return _zonaafectadaterremoto;
                }
                set
                {
                    _zonaafectadaterremoto = value;
                }
            }

            public String sujetoagenteperc
            {
                get
                {
                    return _sujetoagenteperc;
                }
                set
                {
                    _sujetoagenteperc = value;
                }
            }

            public Decimal? importetotalsoles
            {
                get
                {
                    return _importetotalsoles;
                }
                set
                {
                    _importetotalsoles = value;
                }
            }

            public Boolean? percepcion
            {
                get
                {
                    return _percepcion;
                }
                set
                {
                    _percepcion = value;
                }
            }

            public String status
            {
                get
                {
                    return _status;
                }
                set
                {
                    _status = value;
                }
            }

            public String usuar
            {
                get
                {
                    return _usuar;
                }
                set
                {
                    _usuar = value;
                }
            }

            public DateTime? fecre
            {
                get
                {
                    return _fecre;
                }
                set
                {
                    _fecre = value;
                }
            }

            public DateTime? feact
            {
                get
                {
                    return _feact;
                }
                set
                {
                    _feact = value;
                }
            }
            #endregion
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

                //XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib2.Value = obj.moduloid;
                //XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("local"); attrib3.Value = obj.local;

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("asientoitems"); attrib1.Value = obj.asientoitems.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("cuentaid"); attrib2.Value = obj.cuentaid.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib3.Value = obj.ctacte.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("tipdid"); attrib4.Value = obj.tipdid.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("nmruc"); attrib5.Value = obj.nmruc.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib6.Value = obj.tipdoc.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib7.Value = obj.serdoc.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib8.Value = obj.numdoc.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib9.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("fechvcto"); attrib10.Value = fecha(obj.fechvcto).ToShortDateString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("fechpago"); attrib11.Value = fecha(obj.fechvcto).ToShortDateString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib12.Value = obj.moneda.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("tipcamb"); attrib13.Value = obj.tipcamb.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("tipcambuso"); attrib14.Value = obj.tipcambuso.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("motivo"); attrib15.Value = obj.motivo.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("importeorigendolares"); attrib16.Value = obj.importeorigendolares.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("importecobrodolares1"); attrib17.Value = obj.importecobrodolares1.ToString();
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("importecobrodolares2"); attrib18.Value = obj.importecobrodolares2.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("importepercepciondolares"); attrib19.Value = obj.importepercepciondolares.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("importetotaldolares"); attrib20.Value = obj.importetotaldolares.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("importedifcambio"); attrib21.Value = obj.importedifcambio.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("importeorigensoles"); attrib22.Value = obj.importeorigensoles.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("importecobrosoles"); attrib23.Value = obj.importecobrosoles.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("importeorigen"); attrib24.Value = obj.importeorigen.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("importecobranza"); attrib25.Value = obj.importecobranza.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("percepcionid"); attrib26.Value = obj.percepcionid.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("porcpercepcion"); attrib27.Value = obj.porcpercepcion.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("importepercepcionsoles"); attrib28.Value = obj.importepercepcionsoles.ToString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("derechocreditofiscal"); attrib29.Value = obj.derechocreditofiscal.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("zonaafectadaterremoto"); attrib30.Value = obj.zonaafectadaterremoto.ToString();
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("sujetoagenteperc"); attrib31.Value = obj.sujetoagenteperc.ToString();
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("importetotalsoles"); attrib32.Value = obj.importetotalsoles.ToString();
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("percepcion"); attrib33.Value = obj.percepcion.ToString();
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("status"); attrib34.Value = obj.status.ToString();
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
