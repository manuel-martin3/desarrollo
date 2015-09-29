using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_percepcionescab
    {
        #region Fields
        private String _perianio;
        private String _perimes;
        private String _moduloid;
        private String _local;
        private String _diarioid;
        private String _asiento;
        private String _tiporegistro;
        private String _ctacte;
        private String _nmruc;
        private String _ctactename;
        private String _direc;
        private String _ubige;
        private String _tipdoc;
        private String _serdoc;
        private String _numdoc;
        private DateTime? _fechdoc;
        private DateTime? _fechvcto;
        private String _moneda;
        private Decimal? _tipcamb;
        private String _tipcambuso;
        private String _glosa;
        private String _diarioidpago;
        private String _monedap;
        private String _numdocpago;
        private String _flujoefectivo;
        private String _mediopago;
        private Decimal? _importeoriginal;
        private Decimal? _importecobranza;
        private String _percepcionid;
        private Decimal? _porcpercepcion;
        private Decimal? _importepercepcion;
        private Decimal? _importetotal;
        private String _status;
        private String _usuar;
        private DateTime? _fecre;
        private DateTime? _feact;

        #endregion

        #region Properties
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        public String perimes
        {
            get { return _perimes; }
            set { _perimes = value; }
        }

        public String moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        public String local
        {
            get { return _local; }
            set { _local = value; }
        }

        public String diarioid
        {
            get { return _diarioid; }
            set { _diarioid = value; }
        }

        public String asiento
        {
            get { return _asiento; }
            set { _asiento = value; }
        }

        public String tiporegistro
        {
            get { return _tiporegistro; }
            set { _tiporegistro = value; }
        }

        public String ctacte
        {
            get
            {
                return _ctacte;
            }
            set
            {
                _ctacte = value;
            }
        }

        public String nmruc
        {
            get
            {
                return _nmruc;
            }
            set
            {
                _nmruc = value;
            }
        }

        public String ctactename
        {
            get
            {
                return _ctactename;
            }
            set
            {
                _ctactename = value;
            }
        }

        public String direc
        {
            get
            {
                return _direc;
            }
            set
            {
                _direc = value;
            }
        }

        public String ubige
        {
            get
            {
                return _ubige;
            }
            set
            {
                _ubige = value;
            }
        }

        public String tipdoc
        {
            get
            {
                return _tipdoc;
            }
            set
            {
                _tipdoc = value;
            }
        }

        public String serdoc
        {
            get
            {
                return _serdoc;
            }
            set
            {
                _serdoc = value;
            }
        }

        public String numdoc
        {
            get
            {
                return _numdoc;
            }
            set
            {
                _numdoc = value;
            }
        }

        public DateTime? fechdoc
        {
            get
            {
                return _fechdoc;
            }
            set
            {
                _fechdoc = value;
            }
        }

        public DateTime? fechvcto
        {
            get
            {
                return _fechvcto;
            }
            set
            {
                _fechvcto = value;
            }
        }

        public String moneda
        {
            get
            {
                return _moneda;
            }
            set
            {
                _moneda = value;
            }
        }

        public Decimal? tipcamb
        {
            get
            {
                return _tipcamb;
            }
            set
            {
                _tipcamb = value;
            }
        }

        public String tipcambuso
        {
            get
            {
                return _tipcambuso;
            }
            set
            {
                _tipcambuso = value;
            }
        }

        public String glosa
        {
            get
            {
                return _glosa;
            }
            set
            {
                _glosa = value;
            }
        }

        public String diarioidpago
        {
            get
            {
                return _diarioidpago;
            }
            set
            {
                _diarioidpago = value;
            }
        }

        public String monedap
        {
            get
            {
                return _monedap;
            }
            set
            {
                _monedap = value;
            }
        }

        public String numdocpago
        {
            get
            {
                return _numdocpago;
            }
            set
            {
                _numdocpago = value;
            }
        }

        public String flujoefectivo
        {
            get
            {
                return _flujoefectivo;
            }
            set
            {
                _flujoefectivo = value;
            }
        }

        public String mediopago
        {
            get
            {
                return _mediopago;
            }
            set
            {
                _mediopago = value;
            }
        }

        public Decimal? importeoriginal
        {
            get
            {
                return _importeoriginal;
            }
            set
            {
                _importeoriginal = value;
            }
        }

        public Decimal? importecobranza
        {
            get
            {
                return _importecobranza;
            }
            set
            {
                _importecobranza = value;
            }
        }

        public String percepcionid
        {
            get
            {
                return _percepcionid;
            }
            set
            {
                _percepcionid = value;
            }
        }

        public Decimal? porcpercepcion
        {
            get
            {
                return _porcpercepcion;
            }
            set
            {
                _porcpercepcion = value;
            }
        }

        public Decimal? importepercepcion
        {
            get
            {
                return _importepercepcion;
            }
            set
            {
                _importepercepcion = value;
            }
        }

        public Decimal? importetotal
        {
            get
            {
                return _importetotal;
            }
            set
            {
                _importetotal = value;
            }
        }

        public String status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public String usuar
        {
            get
            {
                return _usuar;
            }
            set
            {
                _usuar = value;
            }
        }

        public DateTime? fecre
        {
            get
            {
                return _fecre;
            }
            set
            {
                _fecre = value;
            }
        }

        public DateTime? feact
        {
            get
            {
                return _feact;
            }
            set
            {
                _feact = value;
            }
        }

        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }
        #endregion
    }
}
