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
    public class tb_co_Movimientos
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

        private String _tipooperacion;
        public String tipooperacion
        {
            get { return _tipooperacion; }

            set { _tipooperacion = value; }
        }

        private String _tipocomprobante;
        public String tipocomprobante
        {
            get { return _tipocomprobante; }

            set { _tipocomprobante = value; }
        }

        private String _cuentaid;
        public String cuentaid
        {
            get { return _cuentaid; }

            set { _cuentaid = value; }
        }

        private String _tipomovimiento;
        public String tipomovimiento
        {
            get { return _tipomovimiento; }

            set { _tipomovimiento = value; }
        }

        private String _mediopago;
        public String mediopago
        {
            get { return _mediopago; }

            set { _mediopago = value; }
        }

        private String _numdocpago;
        public String numdocpago
        {
            get { return _numdocpago; }

            set { _numdocpago = value; }
        }

        private String _bancoid;
        public String bancoid
        {
            get { return _bancoid; }

            set { _bancoid = value; }
        }

        private DateTime? _fechregistro;
        public DateTime? fechregistro
        {
            get { return _fechregistro; }

            set { _fechregistro = value; }
        }

        private DateTime? _fechdoc;
        public DateTime? fechdoc
        {
            get { return _fechdoc; }

            set { _fechdoc = value; }
        }

        private String _tipcamuso;
        public String tipcamuso
        {
            get { return _tipcamuso; }

            set { _tipcamuso = value; }
        }

        private Decimal _tipcamb;
        public Decimal tipcamb
        {
            get { return _tipcamb; }

            set { _tipcamb = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }

            set { _moneda = value; }
        }

        private String _flujoefectivo;
        public String flujoefectivo
        {
            get { return _flujoefectivo; }

            set { _flujoefectivo = value; }
        }

        private Decimal _debesoles;
        public Decimal debesoles
        {
            get { return _debesoles; }

            set { _debesoles = value; }
        }

        private Decimal _habersoles;
        public Decimal habersoles
        {
            get { return _habersoles; }

            set { _habersoles = value; }
        }

        private Decimal _debedolares;
        public Decimal debedolares
        {
            get { return _debedolares; }

            set { _debedolares = value; }
        }

        private Decimal _haberdolares;
        public Decimal haberdolares
        {
            get { return _haberdolares; }

            set { _haberdolares = value; }
        }

        private Boolean? _difcambio;
        public Boolean? difcambio
        {
            get { return _difcambio; }

            set { _difcambio = value; }
        }

        private Boolean? _redondeo;
        public Boolean? redondeo
        {
            get { return _redondeo; }

            set { _redondeo = value; }
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
        //Reportes
        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }

        private String _cmesini;
        public String cmesini
        {
            get { return _cmesini; }

            set { _cmesini = value; }
        }

        private String _cmesfin;
        public String cmesfin
        {
            get { return _cmesfin; }

            set { _cmesfin = value; }
        }

        private String _ctamayini;
        public String ctamayini
        {
            get { return _ctamayini; }

            set { _ctamayini = value; }
        }

        private String _ctamayfin;
        public String ctamayfin
        {
            get { return _ctamayfin; }

            set { _ctamayfin = value; }
        }

        private String _cuentaini;
        public String cuentaini
        {
            get { return _cuentaini; }

            set { _cuentaini = value; }
        }

        private String _cuentafin;
        public String cuentafin
        {
            get { return _cuentafin; }

            set { _cuentafin = value; }
        }

        private String _relctas;
        public String relctas
        {
            get { return _relctas; }

            set { _relctas = value; }
        }

        private String _cantdigitos;
        public String cantdigitos
        {
            get { return _cantdigitos; }

            set { _cantdigitos = value; }
        }

        private int _solohastacantdigitos;
        public int solohastacantdigitos
        {
            get { return _solohastacantdigitos; }

            set { _solohastacantdigitos = value; }
        }

        private int _saldos;
        public int saldos
        {
            get { return _saldos; }

            set { _saldos = value; }
        }

        private String _fimpresion;
        public String fimpresion
        {
            get { return _fimpresion; }

            set { _fimpresion = value; }
        }
        
        private int _mostrar69;
        public int mostrar69
        {
            get { return _mostrar69; }

            set { _mostrar69 = value; }
        }

        private String _tipreporte;
        public String tipreporte
        {
            get { return _tipreporte; }

            set { _tipreporte = value; }
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
        
        private String _nivel;
        public String nivel
        {
            get { return _nivel; }

            set { _nivel = value; }
        }

        private int _tiprepo;
        public int tiprepo
        {
            get { return _tiprepo; }

            set { _tiprepo = value; }
        }

        private String _newperianio;
        public String newperianio
        {
            get { return _newperianio; }

            set { _newperianio = value; }
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

        private String _cta_ganancia;
        public String cta_ganancia
        {
            get { return _cta_ganancia; }

            set { _cta_ganancia = value; }
        }

        private String _cta_perdida;
        public String cta_perdida
        {
            get { return _cta_perdida; }

            set { _cta_perdida = value; }
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

        private int _tipmodal;
        public int tipmodal
        {
            get { return _tipmodal; }

            set { _tipmodal = value; }
        }

        private int _tanalisis;
        public int tanalisis
        {
            get { return _tanalisis; }

            set { _tanalisis = value; }
        }

        private int _origen;
        public int origen
        {
            get { return _origen; }

            set { _origen = value; }
        }

        private int _modalidad;
        public int modalidad
        {
            get { return _modalidad; }

            set { _modalidad = value; }
        }
        
        private int _IncValorVta;
        public int IncValorVta
        {
            get { return _IncValorVta; }

            set { _IncValorVta = value; }
        }

        private Decimal _nValorVenta;
        public Decimal nValorVenta
        {
            get { return _nValorVenta; }

            set { _nValorVenta = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }

            set { _cencosid = value; }
        }

        private String _cencosini;
        public String cencosini
        {
            get { return _cencosini; }

            set { _cencosini = value; }
        }
        private String _cencosfin;
        public String cencosfin
        {
            get { return _cencosfin; }

            set { _cencosfin = value; }
        }

        private Decimal _tipcambtc;
        public Decimal tipcambtc
        {
            get { return _tipcambtc; }

            set { _tipcambtc = value; }
        }

        private Decimal _tipcambtv;
        public Decimal tipcambtv
        {
            get { return _tipcambtv; }

            set { _tipcambtv = value; }
        }

        private int _exp_excel;
        public int exp_excel
        {
            get { return _exp_excel; }

            set { _exp_excel = value; }
        }

        private String _rubroini;
        public String rubroini
        {
            get { return _rubroini; }

            set { _rubroini = value; }
        }

        private String _rubrofin;
        public String rubrofin
        {
            get { return _rubrofin; }

            set { _rubrofin = value; }
        }

        private String _codigopc;
        public String codigopc
        {
            get { return _codigopc; }

            set { _codigopc = value; }
        }

        // XML
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

            private String _cuentaorigen;
            public String cuentaorigen
            {
                get { return _cuentaorigen; }

                set { _cuentaorigen = value; }
            }

            private String _cuentaname;
            public String cuentaname
            {
                get { return _cuentaname; }

                set { _cuentaname = value; }
            }

            private String _glosa;
            public String glosa
            {
                get { return _glosa; }

                set { _glosa = value; }
            }

            private String _cencosid;
            public String cencosid
            {
                get { return _cencosid; }

                set { _cencosid = value; }
            }

            private String _debehaber;
            public String debehaber
            {
                get { return _debehaber; }

                set { _debehaber = value; }
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

            private DateTime _fechregistro;
            public DateTime fechregistro
            {
                get { return _fechregistro; }

                set { _fechregistro = value; }
            }

            private DateTime _fechdoc;
            public DateTime fechdoc
            {
                get { return _fechdoc; }

                set { _fechdoc = value; }
            }

            private DateTime _fechvenc;
            public DateTime fechvenc
            {
                get { return _fechvenc; }

                set { _fechvenc = value; }
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

            private DateTime _fechref;
            public DateTime fechref
            {
                get { return _fechref; }

                set { _fechref = value; }
            }

            private Decimal _importe;
            public Decimal importe
            {
                get { return _importe; }

                set { _importe = value; }
            }

            private Decimal _importecambio;
            public Decimal importecambio
            {
                get { return _importecambio; }

                set { _importecambio = value; }
            }

            private Decimal _soles;
            public Decimal soles
            {
                get { return _soles; }

                set { _soles = value; }
            }

            private Decimal _dolares;
            public Decimal dolares
            {
                get { return _dolares; }

                set { _dolares = value; }
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

            private DateTime _tipcambfech;
            public DateTime tipcambfech
            {
                get { return _tipcambfech; }

                set { _tipcambfech = value; }
            }

            private Boolean? _afectoretencion;
            public Boolean? afectoretencion
            {
                get { return _afectoretencion; }

                set { _afectoretencion = value; }
            }

            private Boolean? _afectopercepcion;
            public Boolean? afectopercepcion
            {
                get { return _afectopercepcion; }

                set { _afectopercepcion = value; }
            }

            private String _percepcionid;
            public String percepcionid
            {
                get { return _percepcionid; }

                set { _percepcionid = value; }
            }

            private String _serperc;
            public String serperc
            {
                get { return _serperc; }

                set { _serperc = value; }
            }

            private String _numperc;
            public String numperc
            {
                get { return _numperc; }

                set { _numperc = value; }
            }

            private String _numdocpago;
            public String numdocpago
            {
                get { return _numdocpago; }

                set { _numdocpago = value; }
            }

            private String _bancoid;
            public String bancoid
            {
                get { return _bancoid; }

                set { _bancoid = value; }
            }

            private String _pagocta;
            public String pagocta
            {
                get { return _pagocta; }

                set { _pagocta = value; }
            }

            private String _mediopago;
            public String mediopago
            {
                get { return _mediopago; }

                set { _mediopago = value; }
            }

            private DateTime _fechpago;
            public DateTime fechpago
            {
                get { return _fechpago; }

                set { _fechpago = value; }
            }

            private String _flujoefectivo;
            public String flujoefectivo
            {
                get { return _flujoefectivo; }

                set { _flujoefectivo = value; }
            }

            private String _asientovinculante;
            public String asientovinculante
            {
                get { return _asientovinculante; }

                set { _asientovinculante = value; }
            }

            private String _cancelacionvinculante;
            public String cancelacionvinculante
            {
                get { return _cancelacionvinculante; }

                set { _cancelacionvinculante = value; }
            }

            private String _productid;
            public String productid
            {
                get { return _productid; }

                set { _productid = value; }
            }

            private String _pedidoid;
            public String pedidoid
            {
                get { return _pedidoid; }

                set { _pedidoid = value; }
            }

            private String _tipOp;
            public String tipOp
            {
                get { return _tipOp; }

                set { _tipOp = value; }
            }

            private String _serOp;
            public String serOp
            {
                get { return _serOp; }

                set { _serOp = value; }
            }

            private String _numOp;
            public String numOp
            {
                get { return _numOp; }

                set { _numOp = value; }
            }

            private String _tipooperacion;
            public String tipooperacion
            {
                get { return _tipooperacion; }

                set { _tipooperacion = value; }
            }

            private String _tipocomprobante;
            public String tipocomprobante
            {
                get { return _tipocomprobante; }

                set { _tipocomprobante = value; }
            }

            private String _tipomovimiento;
            public String tipomovimiento
            {
                get { return _tipomovimiento; }

                set { _tipomovimiento = value; }
            }

            private String _statusdestino;
            public String statusdestino
            {
                get { return _statusdestino; }

                set { _statusdestino = value; }
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
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("cuentaorigen"); attrib3.Value = obj.cuentaorigen;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("cuentaname"); attrib4.Value = obj.cuentaname;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib5.Value = obj.glosa;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("cencosid"); attrib6.Value = obj.cencosid;                
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("debehaber"); attrib7.Value = obj.debehaber;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib8.Value = obj.ctacte;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("nmruc"); attrib9.Value = obj.nmruc;
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("ctactename"); attrib10.Value = obj.ctactename.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib11.Value = obj.tipdoc;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib12.Value = obj.serdoc;
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib13.Value = obj.numdoc;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("fechregistro"); attrib14.Value = fecha(obj.fechregistro).ToShortDateString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib15.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("fechvenc"); attrib16.Value = fecha(obj.fechvenc).ToShortDateString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib17.Value = obj.tipref;
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("serref"); attrib18.Value = obj.serref;
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("numref"); attrib19.Value = obj.numref;
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib20.Value = fecha(obj.fechref).ToShortDateString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("importe"); attrib21.Value = obj.importe.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("importecambio"); attrib22.Value = obj.importecambio.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("soles"); attrib23.Value = obj.soles.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("dolares"); attrib24.Value = obj.dolares.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib25.Value = obj.moneda;
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("tipcamb"); attrib26.Value = obj.tipcamb.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("tipcambuso"); attrib27.Value = obj.tipcambuso;
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("tipcambfech"); attrib28.Value = fecha(obj.tipcambfech).ToShortDateString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("afectoretencion"); attrib29.Value = obj.afectoretencion.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("afectopercepcion"); attrib30.Value = obj.afectopercepcion.ToString();
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("percepcionid"); attrib31.Value = obj.percepcionid;
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("serperc"); attrib32.Value = obj.serperc;
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("numperc"); attrib33.Value = obj.numperc;
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("numdocpago"); attrib34.Value = obj.numdocpago.ToString();
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("bancoid"); attrib35.Value = obj.bancoid.ToString();
                XmlAttribute attrib36 = objNode.OwnerDocument.CreateAttribute("pagocta"); attrib36.Value = obj.pagocta.ToString();
                XmlAttribute attrib37 = objNode.OwnerDocument.CreateAttribute("mediopago"); attrib37.Value = obj.mediopago.ToString();
                XmlAttribute attrib38 = objNode.OwnerDocument.CreateAttribute("fechpago"); attrib38.Value = fecha(obj.fechpago).ToShortDateString();
                XmlAttribute attrib39 = objNode.OwnerDocument.CreateAttribute("flujoefectivo"); attrib39.Value = obj.flujoefectivo.ToString();
                XmlAttribute attrib40 = objNode.OwnerDocument.CreateAttribute("asientovinculante"); attrib40.Value = obj.asientovinculante;
                XmlAttribute attrib41 = objNode.OwnerDocument.CreateAttribute("cancelacionvinculante"); attrib41.Value = obj.cancelacionvinculante;
                XmlAttribute attrib42 = objNode.OwnerDocument.CreateAttribute("productid"); attrib42.Value = obj.productid;
                XmlAttribute attrib43 = objNode.OwnerDocument.CreateAttribute("pedidoid"); attrib43.Value = obj.pedidoid;
                XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("tipOp"); attrib44.Value = obj.tipOp.ToString();
                XmlAttribute attrib45 = objNode.OwnerDocument.CreateAttribute("serOp"); attrib45.Value = obj.serOp.ToString();
                XmlAttribute attrib46 = objNode.OwnerDocument.CreateAttribute("numOp"); attrib46.Value = obj.numOp.ToString();
                XmlAttribute attrib47 = objNode.OwnerDocument.CreateAttribute("tipooperacion"); attrib47.Value = obj.tipooperacion.ToString();
                XmlAttribute attrib48 = objNode.OwnerDocument.CreateAttribute("tipocomprobante"); attrib48.Value = obj.tipocomprobante.ToString();
                XmlAttribute attrib49 = objNode.OwnerDocument.CreateAttribute("tipomovimiento"); attrib49.Value = obj.tipomovimiento.ToString();                
                XmlAttribute attrib50 = objNode.OwnerDocument.CreateAttribute("statusdestino"); attrib50.Value = obj.statusdestino.ToString();
                XmlAttribute attrib51 = objNode.OwnerDocument.CreateAttribute("status"); attrib51.Value = obj.status.ToString();
                XmlAttribute attrib52 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib52.Value = obj.usuar;
                
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
                objNode.Attributes.Append(attrib36);
                objNode.Attributes.Append(attrib37);
                objNode.Attributes.Append(attrib38);
                objNode.Attributes.Append(attrib39);
                objNode.Attributes.Append(attrib40);
                objNode.Attributes.Append(attrib41);
                objNode.Attributes.Append(attrib42);
                objNode.Attributes.Append(attrib43);
                objNode.Attributes.Append(attrib44);
                objNode.Attributes.Append(attrib45);
                objNode.Attributes.Append(attrib46);
                objNode.Attributes.Append(attrib47);
                objNode.Attributes.Append(attrib48);
                objNode.Attributes.Append(attrib49);
                objNode.Attributes.Append(attrib50);
                objNode.Attributes.Append(attrib51);
                objNode.Attributes.Append(attrib52);
                //objNode.Attributes.Append(attrib53);
                //objNode.Attributes.Append(attrib54);

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
