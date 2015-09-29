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
    public class tb_60movimientos
    {

        #region tb60_movimientos

        private String _dominioid;
        public String dominioid
        {
            get { return _dominioid; }

            set { _dominioid = value; }
        }

        private String _perdni;
        public String perdni
        {
            get { return _perdni; }
            set { _perdni = value; }
        }


        private String _estacion;
        public String estacion
        {
            get { return _estacion; }
            set { _estacion = value; }
        }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private String convalor;
        public String Convalor
        {
            get { return convalor; }
            set { convalor = value; }
        }

        private String _ubicacion;
        public String Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
        }

        private String _unmed;
        public String unmed
        {
            get { return _unmed; }
            set { _unmed = value; }
        }
        
        private String _transpnume;
        public String transpnume
        {
            get { return _transpnume; }

            set { _transpnume = value; }
        }

        private String _transnmruc;
        public String transnmruc
        {
            get { return _transnmruc; }

            set { _transnmruc = value; }
        }

        private String _placa;
        public String placa
        {
            get { return _placa; }

            set { _placa = value; }
        }

        private String _certificado;
        public String certificado
        {
            get { return _certificado; }

            set { _certificado = value; }
        }

        private String _licencia;
        public String licencia
        {
            get { return _licencia; }

            set { _licencia = value; }
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

        private String _almacaccionid;
        public String almacaccionid
        {
            get { return _almacaccionid; }

            set { _almacaccionid = value; }
        }

        private String _tipoperacionid;
        public String tipoperacionid
        {
            get { return _tipoperacionid; }

            set { _tipoperacionid = value; }
        }

        private String _ctacteaccionid;
        public String ctacteaccionid
        {
            get { return _ctacteaccionid; }

            set { _ctacteaccionid = value; }
        }

        private DateTime _fechdoc;
        public DateTime fechdoc
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

        private String _direc;
        public String direc
        {
            get { return _direc; }

            set { _direc = value; }
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

        private DateTime _fechref;
        public DateTime fechref
        {
            get { return _fechref; }

            set { _fechref = value; }
        }

        private String _tip_op;
        public String tip_op
        {
            get { return _tip_op; }

            set { _tip_op = value; }
        }

        private String _ser_op;
        public String ser_op
        {
            get { return _ser_op; }

            set { _ser_op = value; }
        }

        private String _num_op;
        public String num_op
        {
            get { return _num_op; }

            set { _num_op = value; }
        }

        private String _tipfac;
        public String tipfac
        {
            get { return _tipfac; }

            set { _tipfac = value; }
        }

        private String _serfac;
        public String serfac
        {
            get { return _serfac; }

            set { _serfac = value; }
        }

        private String _numfac;
        public String numfac
        {
            get { return _numfac; }

            set { _numfac = value; }
        }

        private DateTime _fechfac;
        public DateTime fechfac
        {
            get { return _fechfac; }

            set { _fechfac = value; }
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

        private DateTime _fechguia;
        public DateTime fechguia
        {
            get { return _fechguia; }

            set { _fechguia = value; }
        }

        private String _tipnotac;
        public String tipnotac
        {
            get { return _tipnotac; }

            set { _tipnotac = value; }
        }

        private String _sernotac;
        public String sernotac
        {
            get { return _sernotac; }

            set { _sernotac = value; }
        }

        private String _numnotac;
        public String numnotac
        {
            get { return _numnotac; }

            set { _numnotac = value; }
        }

        private DateTime _fechnotac;
        public DateTime fechnotac
        {
            get { return _fechnotac; }

            set { _fechnotac = value; }
        }

        private String _vendorid;
        public String vendorid
        {
            get { return _vendorid; }

            set { _vendorid = value; }
        }

        private String _ubige;
        public String ubige
        {
            get { return _ubige; }

            set { _ubige = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }

            set { _cencosid = value; }
        }

        private Decimal _dscto3;
        public Decimal dscto3
        {
            get { return _dscto3; }

            set { _dscto3 = value; }
        }

        private Decimal _totdscto1;
        public Decimal totdscto1
        {
            get { return _totdscto1; }

            set { _totdscto1 = value; }
        }

        private Decimal _totdscto2;
        public Decimal totdscto2
        {
            get { return _totdscto2; }

            set { _totdscto2 = value; }
        }

        private Decimal _totdscto3;
        public Decimal totdscto3
        {
            get { return _totdscto3; }

            set { _totdscto3 = value; }
        }

        private String _condpago;
        public String condpago
        {
            get { return _condpago; }

            set { _condpago = value; }
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

        private String _incprec;
        public String incprec
        {
            get { return _incprec; }

            set { _incprec = value; }
        }

        private String _tipoperimptoid;
        public String tipoperimptoid
        {
            get { return _tipoperimptoid; }

            set { _tipoperimptoid = value; }
        }

        private Decimal _totimpto;
        public Decimal totimpto
        {
            get { return _totimpto; }

            set { _totimpto = value; }
        }

        private Decimal _valventa;
        public Decimal valventa
        {
            get { return _valventa; }

            set { _valventa = value; }
        }

        private Decimal _totimporte;
        public Decimal totimporte
        {
            get { return _totimporte; }

            set { _totimporte = value; }
        }

        private Decimal _bruto;
        public Decimal bruto
        {
            get { return _bruto; }

            set { _bruto = value; }
        }

        private Decimal _cargo;
        public Decimal cargo
        {
            get { return _cargo; }

            set { _cargo = value; }
        }

        private Decimal _abono;
        public Decimal abono
        {
            get { return _abono; }

            set { _abono = value; }
        }

        private Decimal _tcamb;
        public Decimal tcamb
        {
            get { return _tcamb; }

            set { _tcamb = value; }
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

        private DateTime _fechentrega;
        public DateTime fechentrega
        {
            get { return _fechentrega; }

            set { _fechentrega = value; }
        }

        private DateTime _fechpago;
        public DateTime fechpago
        {
            get { return _fechpago; }

            set { _fechpago = value; }
        }

        private DateTime _fechcancel;
        public DateTime fechcancel
        {
            get { return _fechcancel; }

            set { _fechcancel = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }

            set { _moneda = value; }
        }

        private String _statborrado;
        public String statborrado
        {
            get { return _statborrado; }

            set { _statborrado = value; }
        }

        private String _transpid;
        public String transpid
        {
            get { return _transpid; }

            set { _transpid = value; }
        }

        private String _transpname;
        public String transpname
        {
            get { return _transpname; }

            set { _transpname = value; }
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

        private String _statdigitadoprec;
        public String statdigitadoprec
        {
            get { return _statdigitadoprec; }

            set { _statdigitadoprec = value; }
        }

        private String _modofactu;
        public String modofactu
        {
            get { return _modofactu; }

            set { _modofactu = value; }
        }

        private String _clientetipo;
        public String clientetipo
        {
            get { return _clientetipo; }

            set { _clientetipo = value; }
        }

        private String _ddnni;
        public String ddnni
        {
            get { return _ddnni; }

            set { _ddnni = value; }
        }

        private Decimal _items;
        public Decimal items
        {
            get { return _items; }

            set { _items = value; }
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

        //opt
        private Boolean? _tipodocmanejaserie;
        public Boolean? tipodocmanejaserie
        {
            get { return _tipodocmanejaserie; }

            set { _tipodocmanejaserie = value; }
        }

        #endregion

        //*************************************************
        public class Item
        {
            private String _itemsdet;
            public String itemsdet
            {
                get { return _itemsdet; }

                set { _itemsdet = value; }
            }

            private String _perdni;
            public String perdni
            {
                get { return _perdni; }
                set { _perdni = value; }
            }

            private String _ubicacion;
            public String Ubicacion
            {
                get { return _ubicacion; }
                set { _ubicacion = value; }
            }

            private String _unmed;
            public String unmed
            {
                get { return _unmed; }
                set { _unmed = value; }
            }

            private String _status;
            public String status
            {
                get { return _status; }

                set { _status = value; }
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

            private String _almacaccionid;
            public String almacaccionid
            {
                get { return _almacaccionid; }

                set { _almacaccionid = value; }
            }

            private String _tipoperacionid;
            public String tipoperacionid
            {
                get { return _tipoperacionid; }

                set { _tipoperacionid = value; }
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

            private String _ctacteaccionid;
            public String ctacteaccionid
            {
                get { return _ctacteaccionid; }

                set { _ctacteaccionid = value; }
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

            private String _rollo;
            public String rollo
            {
                get { return _rollo; }

                set { _rollo = value; }
            }

            private DateTime _fechdoc;
            public DateTime fechdoc
            {
                get { return _fechdoc; }

                set { _fechdoc = value; }
            }

            private String _itemref;
            public String itemref
            {
                get { return _itemref; }

                set { _itemref = value; }
            }

            private Decimal _cantidad;
            public Decimal cantidad
            {
                get { return _cantidad; }

                set { _cantidad = value; }
            }

            private Decimal _valor;
            public Decimal valor
            {
                get { return _valor; }

                set { _valor = value; }
            }

            private Decimal _importe;
            public Decimal importe
            {
                get { return _importe; }

                set { _importe = value; }
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

            private Decimal _precioanterior;
            public Decimal precioanterior
            {
                get { return _precioanterior; }

                set { _precioanterior = value; }
            }

            private Decimal _precunit;
            public Decimal precunit
            {
                get { return _precunit; }

                set { _precunit = value; }
            }

            private Decimal _importfac;
            public Decimal importfac
            {
                get { return _importfac; }

                set { _importfac = value; }
            }

            private Decimal _dscto1;
            public Decimal dscto1
            {
                get { return _dscto1; }

                set { _dscto1 = value; }
            }

            private Decimal _dscto2;
            public Decimal dscto2
            {
                get { return _dscto2; }

                set { _dscto2 = value; }
            }

            private Decimal _dscto3;
            public Decimal dscto3
            {
                get { return _dscto3; }

                set { _dscto3 = value; }
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

            private String _tipoperef;
            public String tipoperef
            {
                get { return _tipoperef; }

                set { _tipoperef = value; }
            }

            private String _tip_op;
            public String tip_op
            {
                get { return _tip_op; }

                set { _tip_op = value; }
            }

            private String _ser_op;
            public String ser_op
            {
                get { return _ser_op; }

                set { _ser_op = value; }
            }

            private String _num_op;
            public String num_op
            {
                get { return _num_op; }

                set { _num_op = value; }
            }

            private String _tipfac;
            public String tipfac
            {
                get { return _tipfac; }

                set { _tipfac = value; }
            }

            private String _serfac;
            public String serfac
            {
                get { return _serfac; }

                set { _serfac = value; }
            }

            private String _numfac;
            public String numfac
            {
                get { return _numfac; }

                set { _numfac = value; }
            }

            private DateTime _fechfac;
            public DateTime fechfac
            {
                get { return _fechfac; }

                set { _fechfac = value; }
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

            private DateTime _fechguia;
            public DateTime fechguia
            {
                get { return _fechguia; }

                set { _fechguia = value; }
            }

            private String _tipnotac;
            public String tipnotac
            {
                get { return _tipnotac; }

                set { _tipnotac = value; }
            }

            private String _sernotac;
            public String sernotac
            {
                get { return _sernotac; }

                set { _sernotac = value; }
            }

            private String _numnotac;
            public String numnotac
            {
                get { return _numnotac; }

                set { _numnotac = value; }
            }

            private DateTime _fechnotac;
            public DateTime fechnotac
            {
                get { return _fechnotac; }

                set { _fechnotac = value; }
            }

            private String _cencosid;
            public String cencosid
            {
                get { return _cencosid; }

                set { _cencosid = value; }
            }

            private String _vendorid;
            public String vendorid
            {
                get { return _vendorid; }

                set { _vendorid = value; }
            }

            private String _estacion;
            public String estacion
            {
                get { return _estacion; }
                set { _estacion = value; }
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

            private String _tiptransac;
            public String tiptransac
            {
                get { return _tiptransac; }

                set { _tiptransac = value; }

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

            private String _statcostopromed;
            public String statcostopromed
            {
                get { return _statcostopromed; }

                set { _statcostopromed = value; }
            }

            private String _incprec;
            public String incprec
            {
                get { return _incprec; }

                set { _incprec = value; }
            }

            private Decimal _igv;
            public Decimal igv
            {
                get { return _igv; }

                set { _igv = value; }
            }

            private Decimal _totimpto;
            public Decimal totimpto
            {
                get { return _totimpto; }

                set { _totimpto = value; }
            }

            private String _glosa;
            public String glosa
            {
                get { return _glosa; }

                set { _glosa = value; }
            }

            private String _statdigitadoprec;
            public String statdigitadoprec
            {
                get { return _statdigitadoprec; }

                set { _statdigitadoprec = value; }
            }

            private String _aniosemana;
            public String aniosemana
            {
                get { return _aniosemana; }

                set { _aniosemana = value; }
            }

            private String _aniosemanaconfirm;
            public String aniosemanaconfirm
            {
                get { return _aniosemanaconfirm; }

                set { _aniosemanaconfirm = value; }
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

            private DateTime _fechentrega;
            public DateTime fechentrega
            {
                get { return _fechentrega; }

                set { _fechentrega = value; }
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

            private String _nserie;
            public String nserie
            {
                get { return _nserie; }
                set { _nserie = value; }
            }

        }

        public class rollos
        {
            private String _rollo;
            public String rollo
            {
                get { return _rollo; }

                set { _rollo = value; }
            }

            private Decimal _cantidad;
            public Decimal cantidad
            {
                get { return _cantidad; }

                set { _cantidad = value; }
            }
        }
      
        private List<Item> _ListaItems;
        public List<Item> ListaItems
        {
            get { return _ListaItems; }
            set { _ListaItems = value; }
        }

        private List<rollos> _ListaRollo;
        public List<rollos> ListaRollo
        {
            get { return _ListaRollo; }
            set { _ListaRollo = value; }
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
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("status"); attrib2.Value = obj.status;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("diarioid"); attrib3.Value = obj.diarioid;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("asiento"); attrib4.Value = obj.asiento;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("asientoitems"); attrib5.Value = obj.asientoitems;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib6.Value = obj.almacaccionid;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("tipoperacionid"); attrib7.Value = obj.tipoperacionid;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib8.Value = obj.ctacte;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("ctactename"); attrib9.Value = obj.ctactename;
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("ctacteaccionid"); attrib10.Value = obj.ctacteaccionid;
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("direcnume"); attrib11.Value = obj.direcnume;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("direcname"); attrib12.Value = obj.direcname;
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("productid"); attrib13.Value = obj.productid;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("productname"); attrib14.Value = obj.productname;
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("rollo"); attrib15.Value = obj.rollo;
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib16.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("itemref"); attrib17.Value = obj.itemref;
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib18.Value = obj.cantidad.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("valor"); attrib19.Value = obj.valor.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("importe"); attrib20.Value = obj.importe.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("cantidadcta"); attrib21.Value = obj.cantidadcta.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("cantidadfac"); attrib22.Value = obj.cantidadfac.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("precioanterior"); attrib23.Value = obj.precioanterior.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib24.Value = obj.precunit.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("importfac"); attrib25.Value = obj.importfac.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("dscto1"); attrib26.Value = obj.dscto1.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("dscto2"); attrib27.Value = obj.dscto2.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("dscto3"); attrib28.Value = obj.dscto3.ToString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib29.Value = obj.tipref;
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("serref"); attrib30.Value = obj.serref;
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("numref"); attrib31.Value = obj.numref;
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib32.Value = fecha(obj.fechref).ToShortDateString();
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("tipoperef"); attrib33.Value = obj.tipoperef;
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("tip_op"); attrib34.Value = obj.tip_op;
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("ser_op"); attrib35.Value = obj.ser_op;
                XmlAttribute attrib36 = objNode.OwnerDocument.CreateAttribute("num_op"); attrib36.Value = obj.num_op;
                XmlAttribute attrib37 = objNode.OwnerDocument.CreateAttribute("tipfac"); attrib37.Value = obj.tipfac;
                XmlAttribute attrib38 = objNode.OwnerDocument.CreateAttribute("serfac"); attrib38.Value = obj.serfac;
                XmlAttribute attrib39 = objNode.OwnerDocument.CreateAttribute("numfac"); attrib39.Value = obj.numfac;
                XmlAttribute attrib40 = objNode.OwnerDocument.CreateAttribute("fechfac"); attrib40.Value = fecha(obj.fechfac).ToShortDateString();
                XmlAttribute attrib41 = objNode.OwnerDocument.CreateAttribute("tipguia"); attrib41.Value = obj.tipguia;
                XmlAttribute attrib42 = objNode.OwnerDocument.CreateAttribute("serguia"); attrib42.Value = obj.serguia;
                XmlAttribute attrib43 = objNode.OwnerDocument.CreateAttribute("numguia"); attrib43.Value = obj.numguia;
                XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("fechguia"); attrib44.Value = fecha(obj.fechguia).ToShortDateString();
                XmlAttribute attrib45 = objNode.OwnerDocument.CreateAttribute("tipnotac"); attrib45.Value = obj.tipnotac;
                XmlAttribute attrib46 = objNode.OwnerDocument.CreateAttribute("sernotac"); attrib46.Value = obj.sernotac;
                XmlAttribute attrib47 = objNode.OwnerDocument.CreateAttribute("numnotac"); attrib47.Value = obj.numnotac;
                XmlAttribute attrib48 = objNode.OwnerDocument.CreateAttribute("fechnotac"); attrib48.Value = fecha(obj.fechnotac).ToShortDateString();
                XmlAttribute attrib49 = objNode.OwnerDocument.CreateAttribute("cencosid"); attrib49.Value = obj.cencosid;
                XmlAttribute attrib50 = objNode.OwnerDocument.CreateAttribute("vendorid"); attrib50.Value = obj.vendorid;
                XmlAttribute attrib51 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib51.Value = obj.moneda;
                XmlAttribute attrib52 = objNode.OwnerDocument.CreateAttribute("tcamb"); attrib52.Value = obj.tcamb.ToString();
                XmlAttribute attrib53 = objNode.OwnerDocument.CreateAttribute("tiptransac"); attrib53.Value = obj.tiptransac;
                XmlAttribute attrib54 = objNode.OwnerDocument.CreateAttribute("motivotrasladoid"); attrib54.Value = obj.motivotrasladoid;
                XmlAttribute attrib55 = objNode.OwnerDocument.CreateAttribute("mottrasladointid"); attrib55.Value = obj.mottrasladointid;
                XmlAttribute attrib56 = objNode.OwnerDocument.CreateAttribute("statcostopromed"); attrib56.Value = obj.statcostopromed;
                XmlAttribute attrib57 = objNode.OwnerDocument.CreateAttribute("incprec"); attrib57.Value = obj.incprec;
                XmlAttribute attrib58 = objNode.OwnerDocument.CreateAttribute("igv"); attrib58.Value = obj.igv.ToString();
                XmlAttribute attrib59 = objNode.OwnerDocument.CreateAttribute("totimpto"); attrib59.Value = obj.totimpto.ToString();
                XmlAttribute attrib60 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib60.Value = obj.glosa;
                XmlAttribute attrib61 = objNode.OwnerDocument.CreateAttribute("statdigitadoprec"); attrib61.Value = obj.statdigitadoprec;
                XmlAttribute attrib62 = objNode.OwnerDocument.CreateAttribute("aniosemana"); attrib62.Value = obj.aniosemana;
                XmlAttribute attrib63 = objNode.OwnerDocument.CreateAttribute("aniosemanaconfirm"); attrib63.Value = obj.aniosemanaconfirm;
                XmlAttribute attrib64 = objNode.OwnerDocument.CreateAttribute("codctadebe"); attrib64.Value = obj.codctadebe;
                XmlAttribute attrib65 = objNode.OwnerDocument.CreateAttribute("codctahaber"); attrib65.Value = obj.codctahaber;
                XmlAttribute attrib66 = objNode.OwnerDocument.CreateAttribute("fechentrega"); attrib66.Value = fecha(obj.fechentrega).ToShortDateString();
                XmlAttribute attrib67 = objNode.OwnerDocument.CreateAttribute("perianio"); attrib67.Value = obj.perianio;
                XmlAttribute attrib68 = objNode.OwnerDocument.CreateAttribute("perimes"); attrib68.Value = obj.perimes;
                XmlAttribute attrib69 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib69.Value = obj.usuar;                
                XmlAttribute attrib70 = objNode.OwnerDocument.CreateAttribute("feact"); attrib70.Value = fecha(obj.feact).ToShortDateString();
                XmlAttribute attrib71 = objNode.OwnerDocument.CreateAttribute("ubicacion"); attrib71.Value = obj.Ubicacion.ToString();
                XmlAttribute attrib72 = objNode.OwnerDocument.CreateAttribute("unmed"); attrib72.Value = obj.unmed.ToString();
                XmlAttribute attrib73 = objNode.OwnerDocument.CreateAttribute("nserie"); attrib73.Value = obj.nserie.ToString();

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

        public string RollosXML()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (rollos obj in ListaRollo)
            {
                objNode = objXMLDoc.CreateElement("rollos");
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("rollo"); attrib1.Value = obj.rollo;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib2.Value = obj.cantidad.ToString();

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);

                objXMLDoc.DocumentElement.AppendChild(objNode);
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
    }
}
