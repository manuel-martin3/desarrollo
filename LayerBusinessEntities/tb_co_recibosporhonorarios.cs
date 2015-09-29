using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_recibosporhonorarios
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

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private Decimal _totalh1;
        public Decimal totalh1
        {
            get { return _totalh1; }

            set { _totalh1 = value; }
        }

        private Decimal _pretencion;
        public Decimal pretencion
        {
            get { return _pretencion; }

            set { _pretencion = value; }
        }

        private Decimal _retencion1;
        public Decimal retencion1
        {
            get { return _retencion1; }

            set { _retencion1 = value; }
        }

        private Decimal _netoh1;
        public Decimal netoh1
        {
            get { return _netoh1; }

            set { _netoh1 = value; }
        }

        private Decimal _totalh2;
        public Decimal totalh2
        {
            get { return _totalh2; }

            set { _totalh2 = value; }
        }

        private Decimal _retencion2;
        public Decimal retencion2
        {
            get { return _retencion2; }

            set { _retencion2 = value; }
        }

        private Decimal _netoh2;
        public Decimal netoh2
        {
            get { return _netoh2; }

            set { _netoh2 = value; }
        }

        private String _cuentaid;
        public String cuentaid
        {
            get { return _cuentaid; }

            set { _cuentaid = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }

            set { _cencosid = value; }
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

        //Reporte
        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
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

        private int _nQuiebre;
        public int nQuiebre
        {
            get { return _nQuiebre; }

            set { _nQuiebre = value; }
        }

        private int _nOrden;
        public int nOrden
        {
            get { return _nOrden; }

            set { _nOrden = value; }
        }

        private String _f_impresion;
        public String f_impresion
        {
            get { return _f_impresion; }

            set { _f_impresion = value; }
        }

        //
        private String _regpension;
        public String regpension
        {
            get { return _regpension; }

            set { _regpension = value; }
        }

        private String _afp;
        public String afp
        {
            get { return _afp; }

            set { _afp = value; }
        }

        private Decimal _aporte;
        public Decimal aporte
        {
            get { return _aporte; }

            set { _aporte = value; }
        }

        private Decimal _comision;
        public Decimal comision
        {
            get { return _comision; }

            set { _comision = value; }
        }

        private Decimal _pseguro;
        public Decimal pseguro
        {
            get { return _pseguro; }

            set { _pseguro = value; }
        }

        private Decimal _penaporte1;
        public Decimal penaporte1
        {
            get { return _penaporte1; }

            set { _penaporte1 = value; }
        }

        private Decimal _pencomision1;
        public Decimal pencomision1
        {
            get { return _pencomision1; }

            set { _pencomision1 = value; }
        }

        private Decimal _penpseguro1;
        public Decimal penpseguro1
        {
            get { return _penpseguro1; }

            set { _penpseguro1 = value; }
        }

        private Decimal _penaporte2;
        public Decimal penaporte2
        {
            get { return _penaporte2; }

            set { _penaporte2 = value; }
        }

        private Decimal _pencomision2;
        public Decimal pencomision2
        {
            get { return _pencomision2; }

            set { _pencomision2 = value; }
        }

        private Decimal _penpseguro2;
        public Decimal penpseguro2
        {
            get { return _penpseguro2; }

            set { _penpseguro2 = value; }
        }

        private Decimal _totalaporte1;
        public Decimal totalaporte1
        {
            get { return _totalaporte1; }

            set { _totalaporte1 = value; }
        }

        private Decimal _totalaporte2;
        public Decimal totalaporte2
        {
            get { return _totalaporte2; }

            set { _totalaporte2 = value; }
        }

        private String _empresaid;
        public String empresaid
        {
            get { return _empresaid; }

            set { _empresaid = value; }
        }

        private int _xretencion;
        public int xretencion
        {
            get { return _xretencion; }

            set { _xretencion = value; }
        }
    }
}
