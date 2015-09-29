using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_Ventascab
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

        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }
    }
}
