using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_cm_ordendecompracab
    {

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

        private String _moduloiddes;
        public String moduloiddes
        {
            get { return _moduloiddes; }

            set { _moduloiddes = value; }
        }

        private String _localdes;
        public String localdes
        {
            get { return _localdes; }

            set { _localdes = value; }
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

        private String _almacaccionid;
        public String almacaccionid
        {
            get { return _almacaccionid; }

            set { _almacaccionid = value; }
        }

        private String _ctacteaccionid;
        public String ctacteaccionid
        {
            get { return _ctacteaccionid; }

            set { _ctacteaccionid = value; }
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

        private String _tipped;
        public String tipped
        {
            get { return _tipped; }

            set { _tipped = value; }
        }

        private String _serped;
        public String serped
        {
            get { return _serped; }

            set { _serped = value; }
        }

        private String _numped;
        public String numped
        {
            get { return _numped; }

            set { _numped = value; }
        }

        private String _compradorid;
        public String compradorid
        {
            get { return _compradorid; }

            set { _compradorid = value; }
        }

        private String _condpagoid;
        public String condpagoid
        {
            get { return _condpagoid; }

            set { _condpagoid = value; }
        }

        private String _ubige;
        public String ubige
        {
            get { return _ubige; }

            set { _ubige = value; }
        }

        private Decimal _bruto;
        public Decimal bruto
        {
            get { return _bruto; }

            set { _bruto = value; }
        }

        private Decimal _pdscto;
        public Decimal pdscto
        {
            get { return _pdscto; }

            set { _pdscto = value; }
        }

        private Decimal _idscto;
        public Decimal idscto
        {
            get { return _idscto; }

            set { _idscto = value; }
        }

        private Boolean _afectoigv;
        public Boolean afectoigv
        {
            get { return _afectoigv; }

            set { _afectoigv = value; }
        }

        private Decimal _pigv;
        public Decimal pigv
        {
            get { return _pigv; }

            set { _pigv = value; }
        }

        private String _incprec;
        public String incprec
        {
            get { return _incprec; }

            set { _incprec = value; }
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

        private Decimal _valventa;
        public Decimal valventa
        {
            get { return _valventa; }

            set { _valventa = value; }
        }

        private Decimal _totimpto;
        public Decimal totimpto
        {
            get { return _totimpto; }

            set { _totimpto = value; }
        }

        private Decimal _totimporte;
        public Decimal totimporte
        {
            get { return _totimporte; }

            set { _totimporte = value; }
        }

        private Decimal _valor_ocompra;
        public Decimal valor_ocompra
        {
            get { return _valor_ocompra; }

            set { _valor_ocompra = value; }
        }

        private Decimal _valor_guiado;
        public Decimal valor_guiado
        {
            get { return _valor_guiado; }

            set { _valor_guiado = value; }
        }

        private Decimal _valor_facturado;
        public Decimal valor_facturado
        {
            get { return _valor_facturado; }

            set { _valor_facturado = value; }
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

        private Decimal _items;
        public Decimal items
        {
            get { return _items; }

            set { _items = value; }
        }

        private Boolean _afecdetraccion;
        public Boolean afecdetraccion
        {
            get { return _afecdetraccion; }

            set { _afecdetraccion = value; }
        }

        private String _detraccionid;
        public String detraccionid
        {
            get { return _detraccionid; }

            set { _detraccionid = value; }
        }

        private Decimal _pdetraccion;
        public Decimal pdetraccion
        {
            get { return _pdetraccion; }

            set { _pdetraccion = value; }
        }

        private String _atencion;
        public String atencion
        {
            get { return _atencion; }

            set { _atencion = value; }
        }

        private String _puntollegada;
        public String puntollegada
        {
            get { return _puntollegada; }

            set { _puntollegada = value; }
        }

        private Boolean _visado;
        public Boolean visado
        {
            get { return _visado; }

            set { _visado = value; }
        }

        private String _usuarvisado;
        public String usuarvisado
        {
            get { return _usuarvisado; }

            set { _usuarvisado = value; }
        }

        private String _observacionvisado;
        public String observacionvisado
        {
            get { return _observacionvisado; }

            set { _observacionvisado = value; }
        }

        private DateTime _fechvisado;
        public DateTime fechvisado
        {
            get { return _fechvisado; }

            set { _fechvisado = value; }
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

        //*** OPT
        private String _posicion;
        public String posicion
        {
            get { return _posicion; }

            set { _posicion = value; }
        }

    }
}
