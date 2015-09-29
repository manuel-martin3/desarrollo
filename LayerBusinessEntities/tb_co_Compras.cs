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
    public class tb_co_Compras
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

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
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

        private String _tipdid;
        public String tipdid
        {
            get { return _tipdid; }

            set { _tipdid = value; }
        }

        private String _nmruc;
        public String nmruc
        {
            get { return _nmruc; }

            set { _nmruc = value; }
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

        private String _arrayguias;
        public String arrayguias
        {
            get { return _arrayguias; }

            set { _arrayguias = value; }
        }

        private String _arrayfechasguia;
        public String arrayfechasguia
        {
            get { return _arrayfechasguia; }

            set { _arrayfechasguia = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }

            set { _cencosid = value; }
        }

        private String _compradorid;
        public String compradorid
        {
            get { return _compradorid; }

            set { _compradorid = value; }
        }

        private String _condcompraid;
        public String condcompraid
        {
            get { return _condcompraid; }

            set { _condcompraid = value; }
        }

        private Decimal _bruto;
        public Decimal bruto
        {
            get { return _bruto; }

            set { _bruto = value; }
        }

        private Decimal _dscto3;
        public Decimal dscto3
        {
            get { return _dscto3; }

            set { _dscto3 = value; }
        }

        private Decimal _totdscto3;
        public Decimal totdscto3
        {
            get { return _totdscto3; }

            set { _totdscto3 = value; }
        }

        private Decimal _transporte;
        public Decimal transporte
        {
            get { return _transporte; }

            set { _transporte = value; }
        }

        private Decimal _embalaje;
        public Decimal embalaje
        {
            get { return _embalaje; }

            set { _embalaje = value; }
        }

        private Decimal _otros;
        public Decimal otros
        {
            get { return _otros; }

            set { _otros = value; }
        }

        private String _tipimptoid;
        public String tipimptoid
        {
            get { return _tipimptoid; }

            set { _tipimptoid = value; }
        }

        private Decimal _igv;
        public Decimal igv
        {
            get { return _igv; }

            set { _igv = value; }
        }

        private Boolean? _incprec;
        public Boolean? incprec
        {
            get { return _incprec; }

            set { _incprec = value; }
        }

        private Decimal _valorcompra1;
        public Decimal valorcompra1
        {
            get { return _valorcompra1; }

            set { _valorcompra1 = value; }
        }

        private Decimal _impexo;
        public Decimal impexo
        {
            get { return _impexo; }

            set { _impexo = value; }
        }

        private Decimal _igv1;
        public Decimal igv1
        {
            get { return _igv1; }

            set { _igv1 = value; }
        }

        private Decimal _cargo;
        public Decimal cargo
        {
            get { return _cargo; }

            set { _cargo = value; }
        }

        private Decimal _preciocompra1;
        public Decimal preciocompra1
        {
            get { return _preciocompra1; }

            set { _preciocompra1 = value; }
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

        private String _codctadebe;
        public String codctadebe
        {
            get { return _codctadebe; }

            set { _codctadebe = value; }
        }

        private String _tipoid;
        public String tipoid
        {
            get { return _tipoid; }

            set { _tipoid = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private Decimal _totpzas;
        public Decimal totpzas
        {
            get { return _totpzas; }

            set { _totpzas = value; }
        }

        private DateTime? _fechentrega;
        public DateTime? fechentrega
        {
            get { return _fechentrega; }

            set { _fechentrega = value; }
        }

        private DateTime? _fechpago;
        public DateTime? fechpago
        {
            get { return _fechpago; }

            set { _fechpago = value; }
        }

        private DateTime? _fechcancel;
        public DateTime? fechcancel
        {
            get { return _fechcancel; }

            set { _fechcancel = value; }
        }

        private String _modofactu;
        public String modofactu
        {
            get { return _modofactu; }

            set { _modofactu = value; }
        }

        private Decimal _items;
        public Decimal items
        {
            get { return _items; }

            set { _items = value; }
        }

        private DateTime? _fechregistro;
        public DateTime? fechregistro
        {
            get { return _fechregistro; }

            set { _fechregistro = value; }
        }

        private String _vinculante;
        public String vinculante
        {
            get { return _vinculante; }

            set { _vinculante = value; }
        }

        private String _origen;
        public String origen
        {
            get { return _origen; }

            set { _origen = value; }
        }

        private Boolean? _afecdetraccion;
        public Boolean? afecdetraccion
        {
            get { return _afecdetraccion; }

            set { _afecdetraccion = value; }
        }

        private String _nconstdetrac;
        public String nconstdetrac
        {
            get { return _nconstdetrac; }

            set { _nconstdetrac = value; }
        }

        private DateTime? _fechconstdetrac;
        public DateTime? fechconstdetrac
        {
            get { return _fechconstdetrac; }

            set { _fechconstdetrac = value; }
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

        private String _bnctadetraccion;
        public String bnctadetraccion
        {
            get { return _bnctadetraccion; }

            set { _bnctadetraccion = value; }
        }

        private Boolean? _afectretencion;
        public Boolean? afectretencion
        {
            get { return _afectretencion; }

            set { _afectretencion = value; }
        }

        private Boolean? _afecpercepcion;
        public Boolean? afecpercepcion
        {
            get { return _afecpercepcion; }

            set { _afecpercepcion = value; }
        }

        private String _serdocpercepcion;
        public String serdocpercepcion
        {
            get { return _serdocpercepcion; }

            set { _serdocpercepcion = value; }
        }

        private String _numdocpercepcion;
        public String numdocpercepcion
        {
            get { return _numdocpercepcion; }

            set { _numdocpercepcion = value; }
        }

        private String _percepcionid;
        public String percepcionid
        {
            get { return _percepcionid; }

            set { _percepcionid = value; }
        }

        private Boolean? _afectoigvid;
        public Boolean? afectoigvid
        {
            get { return _afectoigvid; }

            set { _afectoigvid = value; }
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

        private Decimal _valor2;
        public Decimal valor2
        {
            get { return _valor2; }

            set { _valor2 = value; }
        }

        private Decimal _dscto2;
        public Decimal dscto2
        {
            get { return _dscto2; }

            set { _dscto2 = value; }
        }

        private Decimal _impexo2;
        public Decimal impexo2
        {
            get { return _impexo2; }

            set { _impexo2 = value; }
        }

        private Decimal _valorcompra2;
        public Decimal valorcompra2
        {
            get { return _valorcompra2; }

            set { _valorcompra2 = value; }
        }

        private Decimal _igv2;
        public Decimal igv2
        {
            get { return _igv2; }

            set { _igv2 = value; }
        }

        private Decimal _preciocompra2;
        public Decimal preciocompra2
        {
            get { return _preciocompra2; }

            set { _preciocompra2 = value; }
        }

        private String _tipersona;
        public String tipersona
        {
            get { return _tipersona; }

            set { _tipersona = value; }
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

        //Rename
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

        //Reporte RC
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

        private int _excl_bventa;
        public int excl_bventa
        {
            get { return _excl_bventa; }

            set { _excl_bventa = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }

            set { _norden = value; }
        }

        private int _nquiebre;
        public int nquiebre
        {
            get { return _nquiebre; }

            set { _nquiebre = value; }
        }

        private int _resumen;
        public int resumen
        {
            get { return _resumen; }

            set { _resumen = value; }
        }

        private int _ntipofecha;
        public int ntipofecha
        {
            get { return _ntipofecha; }

            set { _ntipofecha = value; }
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

        private String _almacen;
        public String almacen
        {
            get { return _almacen; }

            set { _almacen = value; }
        }

        private String _numdocLIKE;
        public String numdocLIKE
        {
            get { return _numdocLIKE; }

            set { _numdocLIKE = value; }
        }

        private int _percepcion;
        public int percepcion
        {
            get { return _percepcion; }

            set { _percepcion = value; }
        }

        private int _excel;
        public int excel
        {
            get { return _excel; }

            set { _excel = value; }
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

            private DateTime _fechdoc;
            public DateTime fechdoc
            {
                get { return _fechdoc; }

                set { _fechdoc = value; }
            }

            private String _nmruc;
            public String nmruc
            {
                get { return _nmruc; }

                set { _nmruc = value; }
            }

            private String _ctacte;
            public String ctacte
            {
                get { return _ctacte; }

                set { _ctacte = value; }
            }

            private String _ctactename;
            public String ctactename
            {
                get { return _ctactename; }

                set { _ctactename = value; }
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

            private String _almacaccionid;
            public String almacaccionid
            {
                get { return _almacaccionid; }

                set { _almacaccionid = value; }
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

            private DateTime _fechref;
            public DateTime fechref
            {
                get { return _fechref; }

                set { _fechref = value; }
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

            private Decimal _cantidad;
            public Decimal cantidad
            {
                get { return _cantidad; }

                set { _cantidad = value; }
            }

            private Decimal _cantidadcta;
            public Decimal cantidadcta
            {
                get { return _cantidadcta; }

                set { _cantidadcta = value; }
            }

            private Decimal _cantidadfac;
            public Decimal cantidadfac
            {
                get { return _cantidadfac; }

                set { _cantidadfac = value; }
            }

            private Decimal _precunit;
            public Decimal precunit
            {
                get { return _precunit; }

                set { _precunit = value; }
            }

            private Decimal _dscto3;
            public Decimal dscto3
            {
                get { return _dscto3; }

                set { _dscto3 = value; }
            }

            private Decimal _valorcompra1;
            public Decimal valorcompra1
            {
                get { return _valorcompra1; }

                set { _valorcompra1 = value; }
            }

            private Boolean? _incprec;
            public Boolean? incprec
            {
                get { return _incprec; }

                set { _incprec = value; }
            }

            private Decimal _igv1;
            public Decimal igv1
            {
                get { return _igv1; }

                set { _igv1 = value; }
            }

            private Decimal _igv;
            public Decimal igv
            {
                get { return _igv; }

                set { _igv = value; }
            }

            private Decimal _preciocompra1;
            public Decimal preciocompra1
            {
                get { return _preciocompra1; }

                set { _preciocompra1 = value; }
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

            private String _cencosid;
            public String cencosid
            {
                get { return _cencosid; }

                set { _cencosid = value; }
            }

            private String _compradorid;
            public String compradorid
            {
                get { return _compradorid; }

                set { _compradorid = value; }
            }

            private String _glosa;
            public String glosa
            {
                get { return _glosa; }

                set { _glosa = value; }
            }

            private String _codctadebe;
            public String codctadebe
            {
                get { return _codctadebe; }

                set { _codctadebe = value; }
            }

            private String _codctahaber;
            public String codctahaber
            {
                get { return _codctahaber; }

                set { _codctahaber = value; }
            }

            private String _rubroid;
            public String rubroid
            {
                get { return _rubroid; }

                set { _rubroid = value; }
            }

            private String _unidmedidaid;
            public String unidmedidaid
            {
                get { return _unidmedidaid; }

                set { _unidmedidaid = value; }
            }

            private Decimal _merma;
            public Decimal merma
            {
                get { return _merma; }

                set { _merma = value; }
            }

            private String _tipimptoid;
            public String tipimptoid
            {
                get { return _tipimptoid; }

                set { _tipimptoid = value; }
            }

            private String _pedido;
            public String pedido
            {
                get { return _pedido; }

                set { _pedido = value; }
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

            private String _ordencs;
            public String ordencs
            {
                get { return _ordencs; }

                set { _ordencs = value; }
            }

            private Decimal _preciounitario2;
            public Decimal preciounitario2
            {
                get { return _preciounitario2; }

                set { _preciounitario2 = value; }
            }

            private Decimal _valorcompra2;
            public Decimal valorcompra2
            {
                get { return _valorcompra2; }

                set { _valorcompra2 = value; }
            }

            private Decimal _igv2;
            public Decimal igv2
            {
                get { return _igv2; }

                set { _igv2 = value; }
            }

            private Decimal _preciocompra2;
            public Decimal preciocompra2
            {
                get { return _preciocompra2; }

                set { _preciocompra2 = value; }
            }

            private String _regalmacen;
            public String regalmacen
            {
                get { return _regalmacen; }

                set { _regalmacen = value; }
            }

            private Decimal _valorcompra;
            public Decimal valorcompra
            {
                get { return _valorcompra; }

                set { _valorcompra = value; }
            }

            private Decimal _igvo;
            public Decimal igvo
            {
                get { return _igvo; }

                set { _igvo = value; }
            }

            private Decimal _preciocompra;
            public Decimal preciocompra
            {
                get { return _preciocompra; }

                set { _preciocompra = value; }
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
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("tipodoc"); attrib2.Value = obj.tipodoc.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib3.Value = obj.serdoc.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib4.Value = obj.numdoc.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("items"); attrib5.Value = obj.items.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("status"); attrib6.Value = obj.status;
                //XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib7.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib7.Value = (obj.fechdoc.ToShortDateString() == "01/01/0001" ? "01/01/1900" : obj.fechdoc.ToShortDateString());
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("nmruc"); attrib8.Value = obj.nmruc.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("ctactename"); attrib9.Value = obj.ctactename.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("productid"); attrib10.Value = obj.productid.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("productname"); attrib11.Value = obj.productname.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib12.Value = obj.almacaccionid.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("itemref"); attrib13.Value = obj.itemref.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib14.Value = obj.tipref;
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("serref"); attrib15.Value = obj.serref;
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("numref"); attrib16.Value = obj.numref;
                //XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib17.Value = fecha(obj.fechref).ToShortDateString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib17.Value = (obj.fechref.ToShortDateString() == "01/01/0001" ? "01/01/1900" : obj.fechref.ToShortDateString());
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("tipOp"); attrib18.Value = obj.tipOp.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("serOp"); attrib19.Value = obj.serOp.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("numOp"); attrib20.Value = obj.numOp.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib21.Value = obj.cantidad.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("cantidadcta"); attrib22.Value = obj.cantidadcta.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("cantidadfac"); attrib23.Value = obj.cantidadfac.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib24.Value = obj.precunit.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("dscto3"); attrib25.Value = obj.dscto3.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("valorcompra1"); attrib26.Value = obj.valorcompra1.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("incprec"); attrib27.Value = obj.incprec.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("igv1"); attrib28.Value = obj.igv1.ToString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("igv"); attrib29.Value = obj.igv.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("preciocompra1"); attrib30.Value = obj.preciocompra1.ToString();
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib31.Value = obj.moneda.ToString();
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("tcamb"); attrib32.Value = obj.tcamb.ToString();
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("cencosid"); attrib33.Value = obj.cencosid.ToString();
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("compradorid"); attrib34.Value = obj.compradorid.ToString();
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib35.Value = obj.glosa.ToString();
                XmlAttribute attrib36 = objNode.OwnerDocument.CreateAttribute("codctadebe"); attrib36.Value = obj.codctadebe;
                XmlAttribute attrib37 = objNode.OwnerDocument.CreateAttribute("codctahaber"); attrib37.Value = obj.codctahaber;
                XmlAttribute attrib38 = objNode.OwnerDocument.CreateAttribute("rubroid"); attrib38.Value = obj.rubroid.ToString();
                XmlAttribute attrib39 = objNode.OwnerDocument.CreateAttribute("unidmedidaid"); attrib39.Value = obj.unidmedidaid.ToString();
                XmlAttribute attrib40 = objNode.OwnerDocument.CreateAttribute("merma"); attrib40.Value = obj.merma.ToString();
                XmlAttribute attrib41 = objNode.OwnerDocument.CreateAttribute("tipimptoid"); attrib41.Value = obj.tipimptoid;
                XmlAttribute attrib42 = objNode.OwnerDocument.CreateAttribute("pedido"); attrib42.Value = obj.pedido.ToString();
                XmlAttribute attrib43 = objNode.OwnerDocument.CreateAttribute("tipguia"); attrib43.Value = obj.tipguia.ToString();
                XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("serguia"); attrib44.Value = obj.serguia.ToString();
                XmlAttribute attrib45 = objNode.OwnerDocument.CreateAttribute("numguia"); attrib45.Value = obj.numguia.ToString();
                XmlAttribute attrib46 = objNode.OwnerDocument.CreateAttribute("ordencs"); attrib46.Value = obj.ordencs.ToString();
                XmlAttribute attrib47 = objNode.OwnerDocument.CreateAttribute("preciounitario2"); attrib47.Value = obj.preciounitario2.ToString();
                XmlAttribute attrib48 = objNode.OwnerDocument.CreateAttribute("valorcompra2"); attrib48.Value = obj.valorcompra2.ToString();
                XmlAttribute attrib49 = objNode.OwnerDocument.CreateAttribute("igv2"); attrib49.Value = obj.igv2.ToString();
                XmlAttribute attrib50 = objNode.OwnerDocument.CreateAttribute("preciocompra2"); attrib50.Value = obj.preciocompra2.ToString();
                XmlAttribute attrib51 = objNode.OwnerDocument.CreateAttribute("regalmacen"); attrib51.Value = obj.regalmacen;
                XmlAttribute attrib52 = objNode.OwnerDocument.CreateAttribute("valorcompra"); attrib52.Value = obj.valorcompra.ToString();
                XmlAttribute attrib53 = objNode.OwnerDocument.CreateAttribute("igvo"); attrib53.Value = obj.igvo.ToString();
                XmlAttribute attrib54 = objNode.OwnerDocument.CreateAttribute("preciocompra"); attrib54.Value = obj.preciocompra.ToString();
                XmlAttribute attrib55 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib55.Value = obj.usuar.ToString();
                //XmlAttribute attrib56 = objNode.OwnerDocument.CreateAttribute("detraccionid"); attrib55.Value = obj.detraccionid.ToString();
                //XmlAttribute attrib57 = objNode.OwnerDocument.CreateAttribute("porcdetraccion"); attrib55.Value = obj.porcdetraccion.ToString();

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
                //objNode.Attributes.Append(attrib56);
                //objNode.Attributes.Append(attrib57);

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
