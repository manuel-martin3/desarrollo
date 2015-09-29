using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_co_conciliacionbancaria
    {
        #region Fields
        private System.String _perianio;
        private System.String _perimes;
        private System.String _moduloid;
        private System.String _local;
        private System.String _diarioid;
        private System.String _asiento;
        private System.String _asientoitems;
        private System.DateTime? _fechregistro;
        private System.String _cuentaid;
        private System.String _debehaber;
        private System.String _tipdoc;
        private System.String _serdoc;
        private System.String _numdoc;
        private System.String _mediopago;
        private System.String _numdocpago;
        private System.String _ctacte;
        private System.String _nmruc;
        private System.String _ctactename;
        private System.Decimal? _saldoSi;
        private System.Decimal? _cargo;
        private System.Decimal? _abono;
        private System.Decimal? _saldo;
        private System.Decimal? _tipcamb;
        private System.String _moneda;
        private System.Boolean? _esConciliado;
        private System.Boolean? _esManual;
        private System.Boolean? _esOtroperiodo;
        private System.DateTime? _fechextracto;
        private System.String _glosa;
        private System.String _usuar;
        private System.DateTime? _fecre;
        private System.DateTime? _feact;

        private System.DateTime? _fechaini;
        private System.DateTime? _fechafin;
        #endregion


        #region Properties
        public System.String Perianio
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

        public System.String Perimes
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

        public System.String Moduloid
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

        public System.String Local
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

        public System.String Diarioid
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

        public System.String Asiento
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

        public System.String Asientoitems
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

        public System.DateTime? Fechregistro
        {
            get
            {
                return _fechregistro;
            }
            set
            {
                _fechregistro = value;
            }
        }

        public System.String Cuentaid
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

        public System.String Debehaber
        {
            get
            {
                return _debehaber;
            }
            set
            {
                _debehaber = value;
            }
        }

        public System.String Tipdoc
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

        public System.String Serdoc
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

        public System.String Numdoc
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

        public System.String Mediopago
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

        public System.String Numdocpago
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

        public System.String Ctacte
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

        public System.String Nmruc
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

        public System.String Ctactename
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

        public System.Decimal? SaldoSi
        {
            get
            {
                return _saldoSi;
            }
            set
            {
                _saldoSi = value;
            }
        }

        public System.Decimal? Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                _cargo = value;
            }
        }

        public System.Decimal? Abono
        {
            get
            {
                return _abono;
            }
            set
            {
                _abono = value;
            }
        }

        public System.Decimal? Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                _saldo = value;
            }
        }

        public System.Decimal? Tipcamb
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

        public System.String Moneda
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

        public System.Boolean? EsConciliado
        {
            get
            {
                return _esConciliado;
            }
            set
            {
                _esConciliado = value;
            }
        }

        public System.Boolean? EsManual
        {
            get
            {
                return _esManual;
            }
            set
            {
                _esManual = value;
            }
        }

        public System.Boolean? EsOtroperiodo
        {
            get
            {
                return _esOtroperiodo;
            }
            set
            {
                _esOtroperiodo = value;
            }
        }

        public System.DateTime? Fechextracto
        {
            get
            {
                return _fechextracto;
            }
            set
            {
                _fechextracto = value;
            }
        }

        public System.String Glosa
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

        public System.String Usuar
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

        public System.DateTime? Fecre
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

        public System.DateTime? Feact
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

        public System.DateTime? Fechaini
        {
            get
            {
                return _fechaini;
            }
            set
            {
                _fechaini = value;
            }
        }

        public System.DateTime? Fechafin
        {
            get
            {
                return _fechafin;
            }
            set
            {
                _fechafin = value;
            }
        }
        #endregion

        #region Armando XML
        public class Item
        {
            #region Fields
            private System.String _perianio;
            private System.String _perimes;
            private System.String _moduloid;
            private System.String _local;
            private System.String _diarioid;
            private System.String _asiento;
            private System.String _asientoitems;
            private System.DateTime _fechregistro;
            private System.String _cuentaid;
            private System.String _debehaber;
            private System.String _tipdoc;
            private System.String _serdoc;
            private System.String _numdoc;
            private System.String _mediopago;
            private System.String _numdocpago;
            private System.String _ctacte;
            private System.String _nmruc;
            private System.String _ctactename;
            private System.Decimal? _saldoSi;
            private System.Decimal? _cargo;
            private System.Decimal? _abono;
            private System.Decimal? _saldo;
            private System.Decimal? _tipcamb;
            private System.String _moneda;
            private System.Boolean? _esConciliado;
            private System.Boolean? _esManual;
            private System.Boolean? _esOtroperiodo;
            private System.DateTime _fechextracto;
            private System.String _glosa;
            private System.String _usuar;
            private System.DateTime _fecre;
            private System.DateTime _feact;

            #endregion


            #region Properties
            public System.String Perianio
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

            public System.String Perimes
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

            public System.String Moduloid
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

            public System.String Local
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

            public System.String Diarioid
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

            public System.String Asiento
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

            public System.String Asientoitems
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

            public System.DateTime Fechregistro
            {
                get
                {
                    return _fechregistro;
                }
                set
                {
                    _fechregistro = value;
                }
            }

            public System.String Cuentaid
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

            public System.String Debehaber
            {
                get
                {
                    return _debehaber;
                }
                set
                {
                    _debehaber = value;
                }
            }

            public System.String Tipdoc
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

            public System.String Serdoc
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

            public System.String Numdoc
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

            public System.String Mediopago
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

            public System.String Numdocpago
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

            public System.String Ctacte
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

            public System.String Nmruc
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

            public System.String Ctactename
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

            public System.Decimal? SaldoSi
            {
                get
                {
                    return _saldoSi;
                }
                set
                {
                    _saldoSi = value;
                }
            }

            public System.Decimal? Cargo
            {
                get
                {
                    return _cargo;
                }
                set
                {
                    _cargo = value;
                }
            }

            public System.Decimal? Abono
            {
                get
                {
                    return _abono;
                }
                set
                {
                    _abono = value;
                }
            }

            public System.Decimal? Saldo
            {
                get
                {
                    return _saldo;
                }
                set
                {
                    _saldo = value;
                }
            }

            public System.Decimal? Tipcamb
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

            public System.String Moneda
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

            public System.Boolean? EsConciliado
            {
                get
                {
                    return _esConciliado;
                }
                set
                {
                    _esConciliado = value;
                }
            }

            public System.Boolean? EsManual
            {
                get
                {
                    return _esManual;
                }
                set
                {
                    _esManual = value;
                }
            }

            public System.Boolean? EsOtroperiodo
            {
                get
                {
                    return _esOtroperiodo;
                }
                set
                {
                    _esOtroperiodo = value;
                }
            }

            public System.DateTime Fechextracto
            {
                get
                {
                    return _fechextracto;
                }
                set
                {
                    _fechextracto = value;
                }
            }

            public System.String Glosa
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

            public System.String Usuar
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

            public System.DateTime Fecre
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

            public System.DateTime Feact
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

        #endregion

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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("perianio"); attrib1.Value = obj.Perianio.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("perimes"); attrib2.Value = obj.Perimes.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib3.Value = obj.Moduloid.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("local"); attrib4.Value = obj.Local.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("diarioid"); attrib5.Value = obj.Diarioid.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("asiento"); attrib6.Value = obj.Asiento.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("asientoitems"); attrib7.Value = obj.Asientoitems.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("fechregistro"); attrib8.Value = fecha(obj.Fechregistro).ToShortDateString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("cuentaid"); attrib9.Value = obj.Cuentaid.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("debehaber"); attrib10.Value = obj.Debehaber.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib11.Value = obj.Tipdoc.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib12.Value = obj.Serdoc.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib13.Value = obj.Numdoc.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("mediopago"); attrib14.Value = obj.Mediopago.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("numdocpago"); attrib15.Value = obj.Numdocpago.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib16.Value = obj.Ctacte.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("nmruc"); attrib17.Value = obj.Nmruc.ToString();
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("ctactename"); attrib18.Value = obj.Ctactename.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("saldo_si"); attrib19.Value = obj.SaldoSi.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("cargo"); attrib20.Value = obj.Cargo.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("abono"); attrib21.Value = obj.Abono.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("saldo"); attrib22.Value = obj.Saldo.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("tipcamb"); attrib23.Value = obj.Tipcamb.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib24.Value = obj.Moneda.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("es_conciliado"); attrib25.Value = obj.EsConciliado.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("es_manual"); attrib26.Value = obj.EsManual.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("es_otroperiodo"); attrib27.Value = obj.EsOtroperiodo.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("fechextracto"); attrib28.Value = fecha(obj.Fechextracto).ToShortDateString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib29.Value = obj.Glosa.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib30.Value = obj.Usuar.ToString();
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("fecre"); attrib31.Value = obj.Fecre.ToString();
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("feact"); attrib32.Value = obj.Feact.ToString();

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
