using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_Movimientosdet
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

        private String _asientoi;
        public String asientoi
        {
            get { return _asientoi; }

            set { _asientoi = value; }
        }

        private String _asientof;
        public String asientof
        {
            get { return _asientof; }

            set { _asientof = value; }
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

        private DateTime? _fechvenc;
        public DateTime? fechvenc
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

        private DateTime? _fechref;
        public DateTime? fechref
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

        private DateTime? _tipcambfech;
        public DateTime? tipcambfech
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

        private DateTime? _fechpago;
        public DateTime? fechpago
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

        private String _statusdestino;
        public String statusdestino
        {
            get { return _statusdestino; }

            set { _statusdestino = value; }
        }


        private Boolean? _status;
        public Boolean? status
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
}
