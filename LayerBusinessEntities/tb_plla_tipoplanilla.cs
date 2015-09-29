using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_plla_tipoplanilla
    {
        private String _tipoplla;
        private String _tipopllaname;
        private String _modoplla;
        private String _formapago;
        private Decimal? _diasplla;
        private String _tituloboleta;
        private String _tipopllaemple;
        private Boolean? _gratificacion;
        private Boolean? _pdt;
        private Boolean? _cts;
        private String _tiptrabid;
        private String _status;
        private String _nomlike1;
        private String _nomlike2;
        private String _nomlike3;
        private int _norden;
        private int _ver_blanco;
        private int _solopdt;
        private int _consolidar;
        
        public String Tipoplla
        {
            get { return _tipoplla; }
            
            set { _tipoplla = value; }
        }

        public String Tipopllaname
        {
            get
            {
                return _tipopllaname;
            }
            set
            {
                _tipopllaname = value;
            }
        }

        public String Modoplla
        {
            get
            {
                return _modoplla;
            }
            set
            {
                _modoplla = value;
            }
        }

        public String Formapago
        {
            get
            {
                return _formapago;
            }
            set
            {
                _formapago = value;
            }
        }

        public Decimal? Diasplla
        {
            get
            {
                return _diasplla;
            }
            set
            {
                _diasplla = value;
            }
        }

        public String Tituloboleta
        {
            get
            {
                return _tituloboleta;
            }
            set
            {
                _tituloboleta = value;
            }
        }

        public String Tipopllaemple
        {
            get
            {
                return _tipopllaemple;
            }
            set
            {
                _tipopllaemple = value;
            }
        }

        public Boolean? Gratificacion
        {
            get
            {
                return _gratificacion;
            }
            set
            {
                _gratificacion = value;
            }
        }

        public Boolean? Pdt
        {
            get
            {
                return _pdt;
            }
            set
            {
                _pdt = value;
            }
        }

        public Boolean? Cts
        {
            get
            {
                return _cts;
            }
            set
            {
                _cts = value;
            }
        }

        public String Tiptrabid
        {
            get
            {
                return _tiptrabid;
            }
            set
            {
                _tiptrabid = value;
            }
        }

        public String Status
        {
            get { return _status; }
            
            set { _status = value; }
        }

        public String nomlike1
        {
            get { return _nomlike1; }

            set { _nomlike1 = value; }
        }

        public String nomlike2
        {
            get { return _nomlike2; }

            set { _nomlike2 = value; }
        }

        public String nomlike3
        {
            get { return _nomlike3; }

            set { _nomlike3 = value; }
        }

        public int norden
        {
            get { return _norden; }

            set { _norden = value; }
        }

        public int solopdt
        {
            get { return _solopdt; }

            set { _solopdt = value; }
        }

        public int ver_blanco
        {
            get { return _ver_blanco; }

            set { _ver_blanco = value; }
        }

        public int consolidar
        {
            get { return _consolidar; }

            set { _consolidar = value; }
        }
    }
}
