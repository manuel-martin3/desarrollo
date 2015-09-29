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
    public class tb_co_Factura
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

        private String _ctacteconces;
        public String ctacteconces
        {
            get { return _ctacteconces; }

            set { _ctacteconces = value; }
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

        private String _tipincoterms;
        public String tipincoterms
        {
            get { return _tipincoterms; }

            set { _tipincoterms = value; }
        }

        private Decimal _valor011;
        public Decimal valor011
        {
            get { return _valor011; }

            set { _valor011 = value; }
        }

        private Decimal _valor012;
        public Decimal valor012
        {
            get { return _valor012; }

            set { _valor012 = value; }
        }

        private Decimal _valor021;
        public Decimal valor021
        {
            get { return _valor021; }

            set { _valor021 = value; }
        }

        private Decimal _valor022;
        public Decimal valor022
        {
            get { return _valor022; }

            set { _valor022 = value; }
        }

        private Decimal _valor031;
        public Decimal valor031
        {
            get { return _valor031; }

            set { _valor031 = value; }
        }

        private Decimal _valor032;
        public Decimal valor032
        {
            get { return _valor032; }

            set { _valor032 = value; }
        }

        private Decimal _totfact01;
        public Decimal totfact01
        {
            get { return _totfact01; }

            set { _totfact01 = value; }
        }

        private Decimal _totfact02;
        public Decimal totfact02
        {
            get { return _totfact02; }

            set { _totfact02 = value; }
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

        private String _agenteaduana;
        public String agenteaduana
        {
            get { return _agenteaduana; }

            set { _agenteaduana = value; }
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

        private String _beneficiodrawback;
        public String beneficiodrawback
        {
            get { return _beneficiodrawback; }

            set { _beneficiodrawback = value; }
        }

        private String _marcaprodexport;
        public String marcaprodexport
        {
            get { return _marcaprodexport; }

            set { _marcaprodexport = value; }
        }

        private Decimal _cantidad;
        public Decimal cantidad
        {
            get { return _cantidad; }

            set { _cantidad = value; }
        }

        private String _bultos;
        public String bultos
        {
            get { return _bultos; }

            set { _bultos = value; }
        }

        private String _fletes;
        public String fletes
        {
            get { return _fletes; }

            set { _fletes = value; }
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

        private Decimal _porcigv;
        public Decimal porcigv
        {
            get { return _porcigv; }

            set { _porcigv = value; }
        }

        private Decimal _pdscto;
        public Decimal pdscto
        {
            get { return _pdscto; }

            set { _pdscto = value; }
        }

        private Decimal _bruto1;
        public Decimal bruto1
        {
            get { return _bruto1; }

            set { _bruto1 = value; }
        }

        private Decimal _dsctopropio1;
        public Decimal dsctopropio1
        {
            get { return _dsctopropio1; }

            set { _dsctopropio1 = value; }
        }

        private Decimal _dsctoconvenio1;
        public Decimal dsctoconvenio1
        {
            get { return _dsctoconvenio1; }

            set { _dsctoconvenio1 = value; }
        }

        private Decimal _dsctototal1;
        public Decimal dsctototal1
        {
            get { return _dsctototal1; }

            set { _dsctototal1 = value; }
        }

        private Decimal _baseimpo1;
        public Decimal baseimpo1
        {
            get { return _baseimpo1; }

            set { _baseimpo1 = value; }
        }

        private Decimal _montoigv1;
        public Decimal montoigv1
        {
            get { return _montoigv1; }

            set { _montoigv1 = value; }
        }

        private Decimal _precioventa1;
        public Decimal precioventa1
        {
            get { return _precioventa1; }

            set { _precioventa1 = value; }
        }

        private Decimal _bruto2;
        public Decimal bruto2
        {
            get { return _bruto2; }

            set { _bruto2 = value; }
        }

        private Decimal _dsctopropio2;
        public Decimal dsctopropio2
        {
            get { return _dsctopropio2; }

            set { _dsctopropio2 = value; }
        }

        private Decimal _dsctoconvenio2;
        public Decimal dsctoconvenio2
        {
            get { return _dsctoconvenio2; }

            set { _dsctoconvenio2 = value; }
        }

        private Decimal _dsctototal2;
        public Decimal dsctototal2
        {
            get { return _dsctototal2; }

            set { _dsctototal2 = value; }
        }

        private Decimal _baseimpo2;
        public Decimal baseimpo2
        {
            get { return _baseimpo2; }

            set { _baseimpo2 = value; }
        }

        private Decimal _montoigv2;
        public Decimal montoigv2
        {
            get { return _montoigv2; }

            set { _montoigv2 = value; }
        }

        private Decimal _precioventa2;
        public Decimal precioventa2
        {
            get { return _precioventa2; }

            set { _precioventa2 = value; }
        }

        private String _promoidlist;
        public String promoidlist
        {
            get { return _promoidlist; }

            set { _promoidlist = value; }
        }

        private String _tarjbonus;
        public String tarjbonus
        {
            get { return _tarjbonus; }

            set { _tarjbonus = value; }
        }

        private int _tarjetaid;
        public int tarjetaid
        {
            get { return _tarjetaid; }

            set { _tarjetaid = value; }
        }

        private String _tarjgrupoid;
        public String tarjgrupoid
        {
            get { return _tarjgrupoid; }

            set { _tarjgrupoid = value; }
        }

        private String _tarjnumoper;
        public String tarjnumoper
        {
            get { return _tarjnumoper; }

            set { _tarjnumoper = value; }
        }

        private Decimal _tarjimporte1;
        public Decimal tarjimporte1
        {
            get { return _tarjimporte1; }

            set { _tarjimporte1 = value; }
        }

        private Decimal _tarjimporte2;
        public Decimal tarjimporte2
        {
            get { return _tarjimporte2; }

            set { _tarjimporte2 = value; }
        }

        private String _motivotrasladoid;
        public String motivotrasladoid
        {
            get { return _motivotrasladoid; }

            set { _motivotrasladoid = value; }
        }

        private String _mottrasladointid;
        public String mottrasladointid
        {
            get { return _mottrasladointid; }

            set { _mottrasladointid = value; }
        }

        private String _transpid;
        public String transpid
        {
            get { return _transpid; }

            set { _transpid = value; }
        }

        private DateTime? _fechinitras;
        public DateTime? fechinitras
        {
            get { return _fechinitras; }

            set { _fechinitras = value; }
        }

        private String _estabsunat;
        public String estabsunat
        {
            get { return _estabsunat; }

            set { _estabsunat = value; }
        }

        private String _cajanume;
        public String cajanume
        {
            get { return _cajanume; }

            set { _cajanume = value; }
        }

        private String _ticketeraid;
        public String ticketeraid
        {
            get { return _ticketeraid; }

            set { _ticketeraid = value; }
        }

        private Decimal _efectivo;
        public Decimal efectivo
        {
            get { return _efectivo; }

            set { _efectivo = value; }
        }

        private Decimal _vuelto;
        public Decimal vuelto
        {
            get { return _vuelto; }

            set { _vuelto = value; }
        }

        private String _almacaccionid;
        public String almacaccionid
        {
            get { return _almacaccionid; }

            set { _almacaccionid = value; }
        }

        private String _vendedorid;
        public String vendedorid
        {
            get { return _vendedorid; }

            set { _vendedorid = value; }
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

        //acciones del formulario
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
        //Consulta Incoterms
        private String _codigoid;
        public String codigoid
        {
            get { return _codigoid; }

            set { _codigoid = value; }
        }

        private String _sigla;
        public String sigla
        {
            get { return _sigla; }

            set { _sigla = value; }
        }

        private int _incluir_blanco;
        public int incluir_blanco
        {
            get { return _incluir_blanco; }

            set { _incluir_blanco = value; }
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

            private String _ctacte;
            public String ctacte
            {
                get { return _ctacte; }

                set { _ctacte = value; }
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

            private String _tip_ped;
            public String tip_ped
            {
                get { return _tip_ped; }

                set { _tip_ped = value; }
            }

            private String _ser_ped;
            public String ser_ped
            {
                get { return _ser_ped; }

                set { _ser_ped = value; }
            }

            private String _num_ped;
            public String num_ped
            {
                get { return _num_ped; }

                set { _num_ped = value; }
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

            private String _articidold;
            public String articidold
            {
                get { return _articidold; }

                set { _articidold = value; }
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

            private String _unimedsigla;
            public String unimedsigla
            {
                get { return _unimedsigla; }

                set { _unimedsigla = value; }
            }

            private Decimal _cantidad;
            public Decimal cantidad
            {
                get { return _cantidad; }

                set { _cantidad = value; }
            }

            private Boolean? _chkdscto;
            public Boolean? chkdscto
            {
                get { return _chkdscto; }

                set { _chkdscto = value; }
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

            private Decimal _preclista;
            public Decimal preclista
            {
                get { return _preclista; }

                set { _preclista = value; }
            }

            private Decimal _bruto;
            public Decimal bruto
            {
                get { return _bruto; }

                set { _bruto = value; }
            }

            private Decimal _dsctopropio;
            public Decimal dsctopropio
            {
                get { return _dsctopropio; }

                set { _dsctopropio = value; }
            }

            private Decimal _dsctoconvenio;
            public Decimal dsctoconvenio
            {
                get { return _dsctoconvenio; }

                set { _dsctoconvenio = value; }
            }

            private Decimal _precunit;
            public Decimal precunit
            {
                get { return _precunit; }

                set { _precunit = value; }
            }

            private Decimal _baseimpo;
            public Decimal baseimpo
            {
                get { return _baseimpo; }

                set { _baseimpo = value; }
            }

            private Decimal _montoigv;
            public Decimal montoigv
            {
                get { return _montoigv; }

                set { _montoigv = value; }
            }

            private Decimal _precventa;
            public Decimal precventa
            {
                get { return _precventa; }

                set { _precventa = value; }
            }

            private String _promoid;
            public String promoid
            {
                get { return _promoid; }

                set { _promoid = value; }
            }

            private String _proveedorid;
            public String proveedorid
            {
                get { return _proveedorid; }

                set { _proveedorid = value; }
            }

            private Decimal _preclista1;
            public Decimal preclista1
            {
                get { return _preclista1; }

                set { _preclista1 = value; }
            }

            private Decimal _bruto1;
            public Decimal bruto1
            {
                get { return _bruto1; }

                set { _bruto1 = value; }
            }

            private Decimal _dsctopropio1;
            public Decimal dsctopropio1
            {
                get { return _dsctopropio1; }

                set { _dsctopropio1 = value; }
            }

            private Decimal _dsctoconvenio1;
            public Decimal dsctoconvenio1
            {
                get { return _dsctoconvenio1; }

                set { _dsctoconvenio1 = value; }
            }

            private Decimal _precunit1;
            public Decimal precunit1
            {
                get { return _precunit1; }

                set { _precunit1 = value; }
            }

            private Decimal _baseimpo1;
            public Decimal baseimpo1
            {
                get { return _baseimpo1; }

                set { _baseimpo1 = value; }
            }

            private Decimal _montoigv1;
            public Decimal montoigv1
            {
                get { return _montoigv1; }

                set { _montoigv1 = value; }
            }

            private Decimal _precventa1;
            public Decimal precventa1
            {
                get { return _precventa1; }

                set { _precventa1 = value; }
            }

            private Decimal _preclista2;
            public Decimal preclista2
            {
                get { return _preclista2; }

                set { _preclista2 = value; }
            }

            private Decimal _bruto2;
            public Decimal bruto2
            {
                get { return _bruto2; }

                set { _bruto2 = value; }
            }

            private Decimal _dsctopropio2;
            public Decimal dsctopropio2
            {
                get { return _dsctopropio2; }

                set { _dsctopropio2 = value; }
            }

            private Decimal _dsctoconvenio2;
            public Decimal dsctoconvenio2
            {
                get { return _dsctoconvenio2; }

                set { _dsctoconvenio2 = value; }
            }

            private Decimal _precunit2;
            public Decimal precunit2
            {
                get { return _precunit2; }

                set { _precunit2 = value; }
            }

            private Decimal _baseimpo2;
            public Decimal baseimpo2
            {
                get { return _baseimpo2; }

                set { _baseimpo2 = value; }
            }

            private Decimal _montoigv2;
            public Decimal montoigv2
            {
                get { return _montoigv2; }

                set { _montoigv2 = value; }
            }

            private Decimal _precventa2;
            public Decimal precventa2
            {
                get { return _precventa2; }

                set { _precventa2 = value; }
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

            private Decimal _tipcamb;
            public Decimal tipcamb
            {
                get { return _tipcamb; }

                set { _tipcamb = value; }
            }

            private String _ordencompra;
            public String ordencompra
            {
                get { return _ordencompra; }

                set { _ordencompra = value; }
            }

            private Decimal _comisionvta;
            public Decimal comisionvta
            {
                get { return _comisionvta; }

                set { _comisionvta = value; }
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

            private String _codartcli;
            public String codartcli
            {
                get { return _codartcli; }

                set { _codartcli = value; }
            }

            private String _codlocalcli;
            public String codlocalcli
            {
                get { return _codlocalcli; }

                set { _codlocalcli = value; }
            }

            private String _nomlocalcli;
            public String nomlocalcli
            {
                get { return _nomlocalcli; }

                set { _nomlocalcli = value; }
            }

            private String _productnamecli;
            public String productnamecli
            {
                get { return _productnamecli; }

                set { _productnamecli = value; }
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

                //XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib1.Value = obj.moduloid;
                //XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("local"); attrib2.Value = obj.local;
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("asientoitems"); attrib1.Value = obj.asientoitems;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("tipdoc"); attrib2.Value = obj.tipdoc;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib3.Value = obj.serdoc;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib4.Value = obj.numdoc;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib5.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("fechvcto"); attrib6.Value = fecha(obj.fechvcto).ToShortDateString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib7.Value = obj.ctacte;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("items"); attrib8.Value = obj.items;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("status"); attrib9.Value = obj.status.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib10.Value = obj.almacaccionid.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib11.Value = obj.tipref;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("serref"); attrib12.Value = obj.serref;
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("numref"); attrib13.Value = obj.numref;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib14.Value = fecha(obj.fechref).ToShortDateString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("rubroid"); attrib15.Value = obj.rubroid;
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("tippedido"); attrib16.Value = obj.tip_ped;
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("serpedido"); attrib17.Value = obj.ser_ped;
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("numpedido"); attrib18.Value = obj.num_ped;
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("tipOp"); attrib19.Value = obj.tipOp.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("serOp"); attrib20.Value = obj.serOp.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("numOp"); attrib21.Value = obj.numOp.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("productid"); attrib22.Value = obj.productid;
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("articidold"); attrib23.Value = obj.articidold;
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("productname"); attrib24.Value = obj.productname.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib25.Value = obj.colorid.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("colorname"); attrib26.Value = obj.colorname.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("tallaid"); attrib27.Value = obj.tallaid.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("coltalla"); attrib28.Value = obj.coltalla.ToString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("unimedsigla"); attrib29.Value = obj.unimedsigla;
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib30.Value = obj.cantidad.ToString();
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("chkdscto"); attrib31.Value = obj.chkdscto.ToString();
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("pdscto"); attrib32.Value = obj.pdscto.ToString();
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("pigv"); attrib33.Value = obj.pigv.ToString();
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("preclista"); attrib34.Value = obj.preclista.ToString();
                //XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("bruto"); attrib35.Value = obj.bruto.ToString();
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("dsctopropio"); attrib35.Value = obj.dsctopropio.ToString();
                XmlAttribute attrib36 = objNode.OwnerDocument.CreateAttribute("dsctoconvenio"); attrib36.Value = obj.dsctoconvenio.ToString();
                XmlAttribute attrib37 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib37.Value = obj.precunit.ToString();
                XmlAttribute attrib38 = objNode.OwnerDocument.CreateAttribute("baseimpo"); attrib38.Value = obj.baseimpo.ToString();
                XmlAttribute attrib39 = objNode.OwnerDocument.CreateAttribute("montoigv"); attrib39.Value = obj.montoigv.ToString();
                XmlAttribute attrib40 = objNode.OwnerDocument.CreateAttribute("precventa"); attrib40.Value = obj.precventa.ToString();
                XmlAttribute attrib41 = objNode.OwnerDocument.CreateAttribute("promoid"); attrib41.Value = obj.promoid;
                XmlAttribute attrib42 = objNode.OwnerDocument.CreateAttribute("proveedorid"); attrib42.Value = obj.proveedorid;
                XmlAttribute attrib43 = objNode.OwnerDocument.CreateAttribute("preclista1"); attrib43.Value = obj.preclista1.ToString();
                //XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("bruto1"); attrib44.Value = obj.bruto1.ToString();
                XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("dsctopropio1"); attrib44.Value = obj.dsctopropio1.ToString();
                XmlAttribute attrib45 = objNode.OwnerDocument.CreateAttribute("dsctoconvenio1"); attrib45.Value = obj.dsctoconvenio1.ToString();
                XmlAttribute attrib46 = objNode.OwnerDocument.CreateAttribute("precunit1"); attrib46.Value = obj.precunit1.ToString();
                XmlAttribute attrib47 = objNode.OwnerDocument.CreateAttribute("baseimpo1"); attrib47.Value = obj.baseimpo1.ToString();
                XmlAttribute attrib48 = objNode.OwnerDocument.CreateAttribute("montoigv1"); attrib48.Value = obj.montoigv1.ToString();
                XmlAttribute attrib49 = objNode.OwnerDocument.CreateAttribute("precventa1"); attrib49.Value = obj.precventa1.ToString();
                XmlAttribute attrib50 = objNode.OwnerDocument.CreateAttribute("preclista2"); attrib50.Value = obj.preclista2.ToString();
                //XmlAttribute attrib51 = objNode.OwnerDocument.CreateAttribute("bruto2"); attrib51.Value = obj.bruto2.ToString();
                XmlAttribute attrib51 = objNode.OwnerDocument.CreateAttribute("dsctopropio2"); attrib51.Value = obj.dsctopropio2.ToString();
                XmlAttribute attrib52 = objNode.OwnerDocument.CreateAttribute("dsctoconvenio2"); attrib52.Value = obj.dsctoconvenio2.ToString();
                XmlAttribute attrib53 = objNode.OwnerDocument.CreateAttribute("precunit2"); attrib53.Value = obj.precunit2.ToString();
                XmlAttribute attrib54 = objNode.OwnerDocument.CreateAttribute("baseimpo2"); attrib54.Value = obj.baseimpo2.ToString();
                XmlAttribute attrib55 = objNode.OwnerDocument.CreateAttribute("montoigv2"); attrib55.Value = obj.montoigv2.ToString();
                XmlAttribute attrib56 = objNode.OwnerDocument.CreateAttribute("precventa2"); attrib56.Value = obj.precventa2.ToString();
                XmlAttribute attrib57 = objNode.OwnerDocument.CreateAttribute("tipguia"); attrib57.Value = obj.tipguia;
                XmlAttribute attrib58 = objNode.OwnerDocument.CreateAttribute("serguia"); attrib58.Value = obj.serguia;
                XmlAttribute attrib59 = objNode.OwnerDocument.CreateAttribute("numguia"); attrib59.Value = obj.numguia.ToString();
                XmlAttribute attrib60 = objNode.OwnerDocument.CreateAttribute("afectoigvid"); attrib60.Value = obj.afectoigvid.ToString();
                XmlAttribute attrib61 = objNode.OwnerDocument.CreateAttribute("incprec"); attrib61.Value = obj.incprec.ToString();
                XmlAttribute attrib62 = objNode.OwnerDocument.CreateAttribute("vendedorid"); attrib62.Value = obj.vendedorid;
                XmlAttribute attrib63 = objNode.OwnerDocument.CreateAttribute("cencosid"); attrib63.Value = obj.cencosid.ToString();
                XmlAttribute attrib64 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib64.Value = obj.glosa;             
                XmlAttribute attrib65 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib65.Value = obj.moneda;
                XmlAttribute attrib66 = objNode.OwnerDocument.CreateAttribute("tipcamb"); attrib66.Value = obj.tipcamb.ToString();
                XmlAttribute attrib67 = objNode.OwnerDocument.CreateAttribute("ordencompra"); attrib67.Value = obj.ordencompra;
                XmlAttribute attrib68 = objNode.OwnerDocument.CreateAttribute("comisionvta"); attrib68.Value = obj.comisionvta.ToString();
                XmlAttribute attrib69 = objNode.OwnerDocument.CreateAttribute("observ1"); attrib69.Value = obj.observ1;
                XmlAttribute attrib70 = objNode.OwnerDocument.CreateAttribute("observ2"); attrib70.Value = obj.observ2;
                XmlAttribute attrib71 = objNode.OwnerDocument.CreateAttribute("observ3"); attrib71.Value = obj.observ3;
                XmlAttribute attrib72 = objNode.OwnerDocument.CreateAttribute("observ4"); attrib72.Value = obj.observ4;
                XmlAttribute attrib73 = objNode.OwnerDocument.CreateAttribute("observ5"); attrib73.Value = obj.observ5;
                XmlAttribute attrib74 = objNode.OwnerDocument.CreateAttribute("codartcli"); attrib74.Value = obj.codartcli;
                XmlAttribute attrib75 = objNode.OwnerDocument.CreateAttribute("codlocalcli"); attrib75.Value = obj.codlocalcli;
                XmlAttribute attrib76 = objNode.OwnerDocument.CreateAttribute("nomlocalcli"); attrib76.Value = obj.nomlocalcli;
                XmlAttribute attrib77 = objNode.OwnerDocument.CreateAttribute("productnamecli"); attrib77.Value = obj.productnamecli;
                XmlAttribute attrib78 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib78.Value = obj.usuar;

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
                objNode.Attributes.Append(attrib68);
                objNode.Attributes.Append(attrib69);
                objNode.Attributes.Append(attrib70);
                objNode.Attributes.Append(attrib71);
                objNode.Attributes.Append(attrib72);
                objNode.Attributes.Append(attrib73);
                objNode.Attributes.Append(attrib74);
                objNode.Attributes.Append(attrib75);
                objNode.Attributes.Append(attrib76);
                objNode.Attributes.Append(attrib77);
                objNode.Attributes.Append(attrib78);

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
