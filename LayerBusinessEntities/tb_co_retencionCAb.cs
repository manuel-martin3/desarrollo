using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_retencionCAb
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

        private Decimal _montopago1;
        public Decimal montopago1
        {
            get { return _montopago1; }

            set { _montopago1 = value; }
        }

        private Decimal _impretencion1;
        public Decimal impretencion1
        {
            get { return _impretencion1; }

            set { _impretencion1 = value; }
        }

        private Decimal _montopago2;
        public Decimal montopago2
        {
            get { return _montopago2; }

            set { _montopago2 = value; }
        }
    
        private Decimal _impretencion2;
        public Decimal impretencion2
        {
            get { return _impretencion2; }

            set { _impretencion2 = value; }
        }

        private Decimal _porcretencion;
        public Decimal porcretencion
        {
            get { return _porcretencion; }

            set { _porcretencion = value; }
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

        private String _asientoini;
        public String asientoini
        {
            get { return _asientoini; }

            set { _asientoini = value; }
        }

        private String _asientofin;
        public String asientofin
        {
            get { return _asientofin; }

            set { _asientofin = value; }
        }

        private int _TipOperacion;
        public int TipOperacion
        {
            get { return _TipOperacion; }

            set { _TipOperacion = value; }
        }
    }
}
