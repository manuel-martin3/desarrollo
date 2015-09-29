using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_percepcionesdet
    {
        #region Fields
        private String _perianio;
        private String _perimes;
        private String _moduloid;
        private String _local;
        private String _diarioid;
        private String _asiento;
        private String _asientoitems;
        private String _cuentaid;
        private String _ctacte;
        private String _nmruc;
        private String _tipdoc;
        private String _serdoc;
        private String _numdoc;
        private DateTime? _fechdoc;
        private DateTime? _fechvcto;
        private DateTime? _fechpago;
        private String _moneda;
        private Decimal? _tipcamb;
        private String _tipcambuso;
        private String _motivo;
        private Decimal? _importeorigendolares;
        private Decimal? _importecobrodolares1;
        private Decimal? _importecobrodolares2;
        private Decimal? _importepercepciondolares;
        private Decimal? _importetotaldolares;
        private Decimal? _importedifcambio;
        private Decimal? _importeorigensoles;
        private Decimal? _importecobrosoles;
        private Decimal? _importeorigen;
        private Decimal? _importecobranza;
        private String _percepcionid;
        private Decimal? _porcpercepcion;
        private Decimal? _importepercepcionsoles;
        private String _derechocreditofiscal;
        private String _zonaafectadaterremoto;
        private String _sujetoagenteperc;
        private Decimal? _importetotalsoles;
        private Boolean? _percepcion;
        private String _status;
        private String _usuar;
        private DateTime? _fecre;
        private DateTime? _feact;
        #endregion

        #region Properties
        public String perianio
        {
            get
            {
                return _perianio;
            }
            set
            {
                _perianio = value;
            }
        }

        public String perimes
        {
            get
            {
                return _perimes;
            }
            set
            {
                _perimes = value;
            }
        }

        public String moduloid
        {
            get
            {
                return _moduloid;
            }
            set
            {
                _moduloid = value;
            }
        }

        public String local
        {
            get
            {
                return _local;
            }
            set
            {
                _local = value;
            }
        }

        public String diarioid
        {
            get
            {
                return _diarioid;
            }
            set
            {
                _diarioid = value;
            }
        }

        public String asiento
        {
            get
            {
                return _asiento;
            }
            set
            {
                _asiento = value;
            }
        }

        public String asientoitems
        {
            get
            {
                return _asientoitems;
            }
            set
            {
                _asientoitems = value;
            }
        }

        public String cuentaid
        {
            get
            {
                return _cuentaid;
            }
            set
            {
                _cuentaid = value;
            }
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

        public DateTime? fechpago
        {
            get
            {
                return _fechpago;
            }
            set
            {
                _fechpago = value;
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

        public String motivo
        {
            get
            {
                return _motivo;
            }
            set
            {
                _motivo = value;
            }
        }

        public Decimal? importeorigendolares
        {
            get
            {
                return _importeorigendolares;
            }
            set
            {
                _importeorigendolares = value;
            }
        }

        public Decimal? importecobrodolares1
        {
            get
            {
                return _importecobrodolares1;
            }
            set
            {
                _importecobrodolares1 = value;
            }
        }

        public Decimal? importecobrodolares2
        {
            get
            {
                return _importecobrodolares2;
            }
            set
            {
                _importecobrodolares2 = value;
            }
        }

        public Decimal? importepercepciondolares
        {
            get
            {
                return _importepercepciondolares;
            }
            set
            {
                _importepercepciondolares = value;
            }
        }

        public Decimal? importetotaldolares
        {
            get
            {
                return _importetotaldolares;
            }
            set
            {
                _importetotaldolares = value;
            }
        }

        public Decimal? importedifcambio
        {
            get
            {
                return _importedifcambio;
            }
            set
            {
                _importedifcambio = value;
            }
        }

        public Decimal? importeorigensoles
        {
            get
            {
                return _importeorigensoles;
            }
            set
            {
                _importeorigensoles = value;
            }
        }

        public Decimal? importecobrosoles
        {
            get
            {
                return _importecobrosoles;
            }
            set
            {
                _importecobrosoles = value;
            }
        }

        public Decimal? importeorigen
        {
            get
            {
                return _importeorigen;
            }
            set
            {
                _importeorigen = value;
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

        public Decimal? importepercepcionsoles
        {
            get
            {
                return _importepercepcionsoles;
            }
            set
            {
                _importepercepcionsoles = value;
            }
        }

        public String derechocreditofiscal
        {
            get
            {
                return _derechocreditofiscal;
            }
            set
            {
                _derechocreditofiscal = value;
            }
        }

        public String zonaafectadaterremoto
        {
            get
            {
                return _zonaafectadaterremoto;
            }
            set
            {
                _zonaafectadaterremoto = value;
            }
        }

        public String sujetoagenteperc
        {
            get
            {
                return _sujetoagenteperc;
            }
            set
            {
                _sujetoagenteperc = value;
            }
        }

        public Decimal? importetotalsoles
        {
            get
            {
                return _importetotalsoles;
            }
            set
            {
                _importetotalsoles = value;
            }
        }

        public Boolean? percepcion
        {
            get
            {
                return _percepcion;
            }
            set
            {
                _percepcion = value;
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
        #endregion
    }
}
