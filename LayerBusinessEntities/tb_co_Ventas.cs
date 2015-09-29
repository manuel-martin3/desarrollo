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
    public class tb_co_Ventas
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

        private String _origen;
        public String origen
        {
            get { return _origen; }

            set { _origen = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
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

        private String _tiperson;
        public String tiperson
        {
            get { return _tiperson; }

            set { _tiperson = value; }
        }

        private String _tipdid;
        public String tipdid
        {
            get { return _tipdid; }

            set { _tipdid = value; }
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

        private String _condicionvta;
        public String condicionvta
        {
            get { return _condicionvta; }

            set { _condicionvta = value; }
        }

        private Decimal _tipcamb;
        public Decimal tipcamb
        {
            get { return _tipcamb; }

            set { _tipcamb = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }

            set { _moneda = value; }
        }

        private String _ordencompra;
        public String ordencompra
        {
            get { return _ordencompra; }

            set { _ordencompra = value; }
        }

        private String _detraccionid;
        public String detraccionid
        {
            get { return _detraccionid; }

            set { _detraccionid = value; }
        }

        private Decimal _porcdetraccion;
        public Decimal porcdetraccion
        {
            get { return _porcdetraccion; }

            set { _porcdetraccion = value; }
        }

        private String _nctadetraccion;
        public String nctadetraccion
        {
            get { return _nctadetraccion; }

            set { _nctadetraccion = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private String _tipoventa;
        public String tipoventa
        {
            get { return _tipoventa; }

            set { _tipoventa = value; }
        }

        private String _afectoigvid;
        public String afectoigvid
        {
            get { return _afectoigvid; }

            set { _afectoigvid = value; }
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

        private String _aduanaid;
        public String aduanaid
        {
            get { return _aduanaid; }

            set { _aduanaid = value; }
        }

        private String _aniodua;
        public String aniodua
        {
            get { return _aniodua; }

            set { _aniodua = value; }
        }

        private String _numdua;
        public String numdua
        {
            get { return _numdua; }

            set { _numdua = value; }
        }

        private DateTime? _fechembdua;
        public DateTime? fechembdua
        {
            get { return _fechembdua; }

            set { _fechembdua = value; }
        }

        private DateTime? _fechreguldua;
        public DateTime? fechreguldua
        {
            get { return _fechreguldua; }

            set { _fechreguldua = value; }
        }

        private Decimal _valorfobdua;
        public Decimal valorfobdua
        {
            get { return _valorfobdua; }

            set { _valorfobdua = value; }
        }

        private String _tipoexportid;
        public String tipoexportid
        {
            get { return _tipoexportid; }

            set { _tipoexportid = value; }
        }

        private Boolean? _afectoigv;
        public Boolean? afectoigv
        {
            get { return _afectoigv; }

            set { _afectoigv = value; }
        }

        private Boolean? _incprec;
        public Boolean? incprec
        {
            get { return _incprec; }

            set { _incprec = value; }
        }

        private Boolean? _afectretencion;
        public Boolean? afectretencion
        {
            get { return _afectretencion; }

            set { _afectretencion = value; }
        }

        private String _terminovta;
        public String terminovta
        {
            get { return _terminovta; }

            set { _terminovta = value; }
        }

        private String _dpais;
        public String dpais
        {
            get { return _dpais; }

            set { _dpais = value; }
        }

        private String _embarcador;
        public String embarcador
        {
            get { return _embarcador; }

            set { _embarcador = value; }
        }

        private String _condicionpago;
        public String condicionpago
        {
            get { return _condicionpago; }

            set { _condicionpago = value; }
        }

        private String _cartacredito;
        public String cartacredito
        {
            get { return _cartacredito; }

            set { _cartacredito = value; }
        }

        private String _viaembarque;
        public String viaembarque
        {
            get { return _viaembarque; }

            set { _viaembarque = value; }
        }

        private String _referencia;
        public String referencia
        {
            get { return _referencia; }

            set { _referencia = value; }
        }

        private String _bultos;
        public String bultos
        {
            get { return _bultos; }

            set { _bultos = value; }
        }

        private Decimal _pesoneto;
        public Decimal pesoneto
        {
            get { return _pesoneto; }

            set { _pesoneto = value; }
        }

        private Decimal _pesobruto;
        public Decimal pesobruto
        {
            get { return _pesobruto; }

            set { _pesobruto = value; }
        }

        private Decimal _bruto1;
        public Decimal bruto1
        {
            get { return _bruto1; }

            set { _bruto1 = value; }
        }

        private Decimal _dscto1;
        public Decimal dscto1
        {
            get { return _dscto1; }

            set { _dscto1 = value; }
        }

        private Decimal _valorventa1;
        public Decimal valorventa1
        {
            get { return _valorventa1; }

            set { _valorventa1 = value; }
        }

        private Decimal _igv1;
        public Decimal igv1
        {
            get { return _igv1; }

            set { _igv1 = value; }
        }

        private Decimal _total1;
        public Decimal total1
        {
            get { return _total1; }

            set { _total1 = value; }
        }

        private Decimal _pdscto;
        public Decimal pdscto
        {
            get { return _pdscto; }

            set { _pdscto = value; }
        }

        private Decimal _pigv;
        public Decimal pigv
        {
            get { return _pigv; }

            set { _pigv = value; }
        }

        private Decimal _bruto2;
        public Decimal bruto2
        {
            get { return _bruto2; }

            set { _bruto2 = value; }
        }

        private Decimal _dscto2;
        public Decimal dscto2
        {
            get { return _dscto2; }

            set { _dscto2 = value; }
        }

        private Decimal _valorventa2;
        public Decimal valorventa2
        {
            get { return _valorventa2; }

            set { _valorventa2 = value; }
        }

        private Decimal _igv2;
        public Decimal igv2
        {
            get { return _igv2; }

            set { _igv2 = value; }
        }

        private Decimal _total2;
        public Decimal total2
        {
            get { return _total2; }

            set { _total2 = value; }
        }

        private String _tienda;
        public String tienda
        {
            get { return _tienda; }

            set { _tienda = value; }
        }

        private Decimal _ndias;
        public Decimal ndias
        {
            get { return _ndias; }

            set { _ndias = value; }
        }

        private String _vendedorid;
        public String vendedorid
        {
            get { return _vendedorid; }

            set { _vendedorid = value; }
        }

        private Decimal _porcvta;
        public Decimal porcvta
        {
            get { return _porcvta; }

            set { _porcvta = value; }
        }

        private Decimal _porcefect;
        public Decimal porcefect
        {
            get { return _porcefect; }

            set { _porcefect = value; }
        }

        private String _vinculante;
        public String vinculante
        {
            get { return _vinculante; }

            set { _vinculante = value; }
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

        private String _regmesnuevo;
        public String regmesnuevo
        {
            get { return _regmesnuevo; }

            set { _regmesnuevo = value; }
        }

        private String _regdiarionuevo;
        public String regdiarionuevo
        {
            get { return _regdiarionuevo; }

            set { _regdiarionuevo = value; }
        }

        private String _regnumeronuevo;
        public String regnumeronuevo
        {
            get { return _regnumeronuevo; }

            set { _regnumeronuevo = value; }
        }

        private String _maqreg;
        public String maqreg
        {
            get { return _maqreg; }

            set { _maqreg = value; }
        }

        private String _numdocfinal;
        public String numdocfinal
        {
            get { return _numdocfinal; }

            set { _numdocfinal = value; }
        }

        private String _estabsunat;
        public String estabsunat
        {
            get { return _estabsunat; }

            set { _estabsunat = value; }
        }

        //Reporte Registro de Ventas
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

        private String _rubroid;
        public String rubroid
        {
            get { return _rubroid; }

            set { _rubroid = value; }
        }

        private int _nquiebre;
        public int nquiebre
        {
            get { return _nquiebre; }

            set { _nquiebre = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }

            set { _norden = value; }
        }

        private int _resumen;
        public int resumen
        {
            get { return _resumen; }

            set { _resumen = value; }
        }

        private int _nestado;
        public int nestado
        {
            get { return _nestado; }

            set { _nestado = value; }
        }

        private String _fimpresion;
        public String fimpresion
        {
            get { return _fimpresion; }

            set { _fimpresion = value; }
        }

        private String _almacen;
        public String almacen
        {
            get { return _almacen; }

            set { _almacen = value; }
        }

        private String _productid;
        public String productid
        {
            get { return _productid; }

            set { _productid = value; }
        }

        private int _considerar_docs_sin_producto;
        public int considerar_docs_sin_producto
        {
            get { return _considerar_docs_sin_producto; }

            set { _considerar_docs_sin_producto = value; }
        }
        //

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

            private String _items;
            public String items
            {
                get { return _items; }

                set { _items = value; }
            }

            private String _status;
            public String status
            {
                get { return _status; }

                set { _status = value; }
            }

            private String _almacaccionid;
            public String almacaccionid
            {
                get { return _almacaccionid; }

                set { _almacaccionid = value; }
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

            private String _rubroid;
            public String rubroid
            {
                get { return _rubroid; }

                set { _rubroid = value; }
            }

            private String _tippedido;
            public String tippedido
            {
                get { return _tippedido; }

                set { _tippedido = value; }
            }

            private String _serpedido;
            public String serpedido
            {
                get { return _serpedido; }

                set { _serpedido = value; }
            }

            private String _numpedido;
            public String numpedido
            {
                get { return _numpedido; }

                set { _numpedido = value; }
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

            private String _productid;
            public String productid
            {
                get { return _productid; }

                set { _productid = value; }
            }

            private String _productname;
            public String productname
            {
                get { return _productname; }

                set { _productname = value; }
            }

            private String _tallacolor;
            public String tallacolor
            {
                get { return _tallacolor; }

                set { _tallacolor = value; }
            }

            private String _unidmedidaid;
            public String unidmedidaid
            {
                get { return _unidmedidaid; }

                set { _unidmedidaid = value; }
            }

            private Decimal _cantidad;
            public Decimal cantidad
            {
                get { return _cantidad; }

                set { _cantidad = value; }
            }

            private Decimal _precunit1;
            public Decimal precunit1
            {
                get { return _precunit1; }

                set { _precunit1 = value; }
            }

            private Decimal _bruto1;
            public Decimal bruto1
            {
                get { return _bruto1; }

                set { _bruto1 = value; }
            }

            private Decimal _dscto1;
            public Decimal dscto1
            {
                get { return _dscto1; }

                set { _dscto1 = value; }
            }

            private Decimal _valorventa1;
            public Decimal valorventa1
            {
                get { return _valorventa1; }

                set { _valorventa1 = value; }
            }

            private Decimal _igv1;
            public Decimal igv1
            {
                get { return _igv1; }

                set { _igv1 = value; }
            }

            private Decimal _total1;
            public Decimal total1
            {
                get { return _total1; }

                set { _total1 = value; }
            }

            private Decimal _pdscto;
            public Decimal pdscto
            {
                get { return _pdscto; }

                set { _pdscto = value; }
            }

            private Decimal _pigv;
            public Decimal pigv
            {
                get { return _pigv; }

                set { _pigv = value; }
            }

            private Decimal _precunit2;
            public Decimal precunit2
            {
                get { return _precunit2; }

                set { _precunit2 = value; }
            }

            private Decimal _bruto2;
            public Decimal bruto2
            {
                get { return _bruto2; }

                set { _bruto2 = value; }
            }

            private Decimal _dscto2;
            public Decimal dscto2
            {
                get { return _dscto2; }

                set { _dscto2 = value; }
            }

            private Decimal _valorventa2;
            public Decimal valorventa2
            {
                get { return _valorventa2; }

                set { _valorventa2 = value; }
            }

            private Decimal _igv2;
            public Decimal igv2
            {
                get { return _igv2; }

                set { _igv2 = value; }
            }

            private Decimal _total2;
            public Decimal total2
            {
                get { return _total2; }

                set { _total2 = value; }
            }

            private String _tipguia;
            public String tipguia
            {
                get { return _tipguia; }

                set { _tipguia = value; }
            }

            private String _serguia;
            public String serguia
            {
                get { return _serguia; }

                set { _serguia = value; }
            }

            private String _numguia;
            public String numguia
            {
                get { return _numguia; }

                set { _numguia = value; }
            }

            private String _afectoigvid;
            public String afectoigvid
            {
                get { return _afectoigvid; }

                set { _afectoigvid = value; }
            }

            private Boolean? _incprec;
            public Boolean? incprec
            {
                get { return _incprec; }

                set { _incprec = value; }
            }

            private String _vendedorid;
            public String vendedorid
            {
                get { return _vendedorid; }

                set { _vendedorid = value; }
            }

            private String _cencosid;
            public String cencosid
            {
                get { return _cencosid; }

                set { _cencosid = value; }
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

            private Decimal _tcamb;
            public Decimal tcamb
            {
                get { return _tcamb; }

                set { _tcamb = value; }
            }

            private String _ordencs;
            public String ordencs
            {
                get { return _ordencs; }

                set { _ordencs = value; }
            }

            private Decimal _comisionvta;
            public Decimal comisionvta
            {
                get { return _comisionvta; }

                set { _comisionvta = value; }
            }

            private Decimal _porcvta;
            public Decimal porcvta
            {
                get { return _porcvta; }

                set { _porcvta = value; }
            }

            private Decimal _porcefect;
            public Decimal porcefect
            {
                get { return _porcefect; }

                set { _porcefect = value; }
            }

            private String _observ1;
            public String observ1
            {
                get { return _observ1; }

                set { _observ1 = value; }
            }

            private String _observ2;
            public String observ2
            {
                get { return _observ2; }

                set { _observ2 = value; }
            }

            private String _observ3;
            public String observ3
            {
                get { return _observ3; }

                set { _observ3 = value; }
            }

            private String _observ4;
            public String observ4
            {
                get { return _observ4; }

                set { _observ4 = value; }
            }

            private String _observ5;
            public String observ5
            {
                get { return _observ5; }

                set { _observ5 = value; }
            }

            private Decimal _precunit;
            public Decimal precunit
            {
                get { return _precunit; }

                set { _precunit = value; }
            }

            private Decimal _bruto;
            public Decimal bruto
            {
                get { return _bruto; }

                set { _bruto = value; }
            }

            private Decimal _dscto;
            public Decimal dscto
            {
                get { return _dscto; }

                set { _dscto = value; }
            }

            private Decimal _valorventa;
            public Decimal valorventa
            {
                get { return _valorventa; }

                set { _valorventa = value; }
            }

            private Decimal _igvo;
            public Decimal igvo
            {
                get { return _igvo; }

                set { _igvo = value; }
            }

            private Decimal _total;
            public Decimal total
            {
                get { return _total; }

                set { _total = value; }
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
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib2.Value = obj.tipdoc;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib3.Value = obj.serdoc;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib4.Value = obj.numdoc;
                //XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib5.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib5.Value = (obj.fechdoc.ToShortDateString() == "01/01/0001" ? "01/01/1900" : obj.fechdoc.ToShortDateString());
                //XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("fechvcto"); attrib6.Value = fecha(obj.fechvcto).ToShortDateString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("fechvcto"); attrib6.Value = (obj.fechvcto.ToShortDateString() == "01/01/0001" ? "01/01/1900" : obj.fechvcto.ToShortDateString());
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("nmruc"); attrib7.Value = obj.nmruc;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("ctactename"); attrib8.Value = obj.ctactename.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("items"); attrib9.Value = obj.items;
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("status"); attrib10.Value = obj.status.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib11.Value = obj.almacaccionid.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib12.Value = obj.tipref;
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("serref"); attrib13.Value = obj.serref;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("numref"); attrib14.Value = obj.numref;
                //XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib15.Value = fecha(obj.fechref).ToShortDateString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib15.Value = (obj.fechref.ToShortDateString() == "01/01/0001" ? "01/01/1900" : obj.fechref.ToShortDateString());
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("rubroid"); attrib16.Value = obj.rubroid;
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("tippedido"); attrib17.Value = obj.tippedido;
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("serpedido"); attrib18.Value = obj.serpedido;
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("numpedido"); attrib19.Value = obj.numpedido;
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("tipOp"); attrib20.Value = obj.tipOp.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("serOp"); attrib21.Value = obj.serOp.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("numOp"); attrib22.Value = obj.numOp.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("productid"); attrib23.Value = obj.productid;
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("productname"); attrib24.Value = obj.productname.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("tallacolor"); attrib25.Value = obj.tallacolor.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("unidmedidaid"); attrib26.Value = obj.unidmedidaid;
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib27.Value = obj.cantidad.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("precunit1"); attrib28.Value = obj.precunit1.ToString();                
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("bruto1"); attrib29.Value = obj.bruto1.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("dscto1"); attrib30.Value = obj.dscto1.ToString();
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("valorventa1"); attrib31.Value = obj.valorventa1.ToString();
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("igv1"); attrib32.Value = obj.igv1.ToString();
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("total1"); attrib33.Value = obj.total1.ToString();
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("pdscto"); attrib34.Value = obj.pdscto.ToString();
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("pigv"); attrib35.Value = obj.pigv.ToString();
                XmlAttribute attrib36 = objNode.OwnerDocument.CreateAttribute("precunit2"); attrib36.Value = obj.precunit2.ToString();
                XmlAttribute attrib37 = objNode.OwnerDocument.CreateAttribute("bruto2"); attrib37.Value = obj.bruto2.ToString();
                XmlAttribute attrib38 = objNode.OwnerDocument.CreateAttribute("dscto2"); attrib38.Value = obj.dscto2.ToString();
                XmlAttribute attrib39 = objNode.OwnerDocument.CreateAttribute("valorventa2"); attrib39.Value = obj.valorventa2.ToString();
                XmlAttribute attrib40 = objNode.OwnerDocument.CreateAttribute("igv2"); attrib40.Value = obj.igv2.ToString();
                XmlAttribute attrib41 = objNode.OwnerDocument.CreateAttribute("total2"); attrib41.Value = obj.total2.ToString();
                XmlAttribute attrib42 = objNode.OwnerDocument.CreateAttribute("tipguia"); attrib42.Value = obj.tipguia;
                XmlAttribute attrib43 = objNode.OwnerDocument.CreateAttribute("serguia"); attrib43.Value = obj.serguia;
                XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("numguia"); attrib44.Value = obj.numguia.ToString();
                XmlAttribute attrib45 = objNode.OwnerDocument.CreateAttribute("afectoigvid"); attrib45.Value = obj.afectoigvid.ToString();
                XmlAttribute attrib46 = objNode.OwnerDocument.CreateAttribute("incprec"); attrib46.Value = obj.incprec.ToString();
                XmlAttribute attrib47 = objNode.OwnerDocument.CreateAttribute("vendedorid"); attrib47.Value = obj.vendedorid;
                XmlAttribute attrib48 = objNode.OwnerDocument.CreateAttribute("cencosid"); attrib48.Value = obj.cencosid.ToString();
                XmlAttribute attrib49 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib49.Value = obj.glosa;             
                XmlAttribute attrib50 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib50.Value = obj.moneda;
                XmlAttribute attrib51 = objNode.OwnerDocument.CreateAttribute("tcamb"); attrib51.Value = obj.tcamb.ToString();
                XmlAttribute attrib52 = objNode.OwnerDocument.CreateAttribute("ordencs"); attrib52.Value = obj.ordencs;
                XmlAttribute attrib53 = objNode.OwnerDocument.CreateAttribute("comisionvta"); attrib53.Value = obj.comisionvta.ToString();
                XmlAttribute attrib54 = objNode.OwnerDocument.CreateAttribute("porcvta"); attrib54.Value = obj.porcvta.ToString();
                XmlAttribute attrib55 = objNode.OwnerDocument.CreateAttribute("porcefect"); attrib55.Value = obj.porcefect.ToString();
                XmlAttribute attrib56 = objNode.OwnerDocument.CreateAttribute("observ1"); attrib56.Value = obj.observ1;
                XmlAttribute attrib57 = objNode.OwnerDocument.CreateAttribute("observ2"); attrib57.Value = obj.observ2;
                XmlAttribute attrib58 = objNode.OwnerDocument.CreateAttribute("observ3"); attrib58.Value = obj.observ3;
                XmlAttribute attrib59 = objNode.OwnerDocument.CreateAttribute("observ4"); attrib59.Value = obj.observ4;
                XmlAttribute attrib60 = objNode.OwnerDocument.CreateAttribute("observ5"); attrib60.Value = obj.observ5;
                XmlAttribute attrib61 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib61.Value = obj.precunit.ToString();
                XmlAttribute attrib62 = objNode.OwnerDocument.CreateAttribute("bruto"); attrib62.Value = obj.bruto.ToString();
                XmlAttribute attrib63 = objNode.OwnerDocument.CreateAttribute("dscto"); attrib63.Value = obj.dscto.ToString();
                XmlAttribute attrib64 = objNode.OwnerDocument.CreateAttribute("valorventa"); attrib64.Value = obj.valorventa.ToString();
                XmlAttribute attrib65 = objNode.OwnerDocument.CreateAttribute("igvo"); attrib65.Value = obj.igvo.ToString();
                XmlAttribute attrib66 = objNode.OwnerDocument.CreateAttribute("total"); attrib66.Value = obj.total.ToString();
                XmlAttribute attrib67 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib67.Value = obj.usuar;

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
                objNode.Attributes.Append(attrib53);
                objNode.Attributes.Append(attrib54);
                objNode.Attributes.Append(attrib55);
                objNode.Attributes.Append(attrib56);
                objNode.Attributes.Append(attrib57);
                objNode.Attributes.Append(attrib58);
                objNode.Attributes.Append(attrib59);
                objNode.Attributes.Append(attrib60);
                objNode.Attributes.Append(attrib61);
                objNode.Attributes.Append(attrib62);
                objNode.Attributes.Append(attrib63);
                objNode.Attributes.Append(attrib64);
                objNode.Attributes.Append(attrib65);
                objNode.Attributes.Append(attrib66);
                objNode.Attributes.Append(attrib67);
                //objNode.Attributes.Append(attrib68);
                //objNode.Attributes.Append(attrib69);

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
