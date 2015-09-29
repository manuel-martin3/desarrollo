using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_Ventasdet
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

        private Boolean? _status;
        public Boolean? status
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

        private DateTime? _fechref;
        public DateTime? fechref
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
}
