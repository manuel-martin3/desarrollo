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
    public class tb_co_retenciones
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

        private Decimal _importeoriginal;
        public Decimal importeoriginal
        {
            get { return _importeoriginal; }

            set { _importeoriginal = value; }
        }

        private Decimal _importepago;
        public Decimal importepago
        {
            get { return _importepago; }

            set { _importepago = value; }
        }

        private Decimal _importeretencion;
        public Decimal importeretencion
        {
            get { return _importeretencion; }

            set { _importeretencion = value; }
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
            get { return _fimpresion; }

            set { _fimpresion = value; }
        }

        private String _fechaini;
        public String fechaini
        {
            get { return _fechaini; }

            set { _fechaini = value; }
        }

        private String _fechafin;
        public String fechafin
        {
            get { return _fechafin; }

            set { _fechafin = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }

            set { _norden = value; }
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

            private Decimal _importeorigendolares;
            public Decimal importeorigendolares
            {
                get { return _importeorigendolares; }

                set { _importeorigendolares = value; }
            }

            private Decimal _importepagodolares1;
            public Decimal importepagodolares1
            {
                get { return _importepagodolares1; }

                set { _importepagodolares1 = value; }
            }

            private Decimal _importepagodolares2;
            public Decimal importepagodolares2
            {
                get { return _importepagodolares2; }

                set { _importepagodolares2 = value; }
            }

            private Decimal _importeretenciondolares;
            public Decimal importeretenciondolares
            {
                get { return _importeretenciondolares; }

                set { _importeretenciondolares = value; }
            }

            private Decimal _importenetodolares;
            public Decimal importenetodolares
            {
                get { return _importenetodolares; }

                set { _importenetodolares = value; }
            }

            private Decimal _importedifcambio;
            public Decimal importedifcambio
            {
                get { return _importedifcambio; }

                set { _importedifcambio = value; }
            }

            private Decimal _importeorigensoles;
            public Decimal importeorigensoles
            {
                get { return _importeorigensoles; }

                set { _importeorigensoles = value; }
            }

            private Decimal _importepagosoles;
            public Decimal importepagosoles
            {
                get { return _importepagosoles; }

                set { _importepagosoles = value; }
            }

            private Decimal _importeorigen;
            public Decimal importeorigen
            {
                get { return _importeorigen; }

                set { _importeorigen = value; }
            }

            private Decimal _importepago;
            public Decimal importepago
            {
                get { return _importepago; }

                set { _importepago = value; }
            }

            private Decimal _importeretencionsoles;
            public Decimal importeretencionsoles
            {
                get { return _importeretencionsoles; }

                set { _importeretencionsoles = value; }
            }

            private Decimal _importenetosoles;
            public Decimal importenetosoles
            {
                get { return _importenetosoles; }

                set { _importenetosoles = value; }
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

                //XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib2.Value = obj.moduloid;
                //XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("local"); attrib3.Value = obj.local;
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
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("tipcamb"); attrib12.Value = obj.tipcamb.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("tipcambuso"); attrib13.Value = obj.tipcambuso;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("motivo"); attrib14.Value = obj.motivo;
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("importeorigendolares"); attrib15.Value = obj.importeorigendolares.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("importepagodolares1"); attrib16.Value = obj.importepagodolares1.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("importepagodolares2"); attrib17.Value = obj.importepagodolares2.ToString();
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("importeretenciondolares"); attrib18.Value = obj.importeretenciondolares.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("importenetodolares"); attrib19.Value = obj.importenetodolares.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("importedifcambio"); attrib20.Value = obj.importedifcambio.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("importeorigensoles"); attrib21.Value = obj.importeorigensoles.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("importepagosoles"); attrib22.Value = obj.importepagosoles.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("importeorigen"); attrib23.Value = obj.importeorigen.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("importepago"); attrib24.Value = obj.importepago.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("importeretencionsoles"); attrib25.Value = obj.importeretencionsoles.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("importenetosoles"); attrib26.Value = obj.importenetosoles.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("retencion"); attrib27.Value = obj.retencion.ToString();
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
