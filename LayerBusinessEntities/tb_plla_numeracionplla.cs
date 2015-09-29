using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_plla_numeracionplla
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        private String _asiento;
        public String asiento
        {
            get { return _asiento; }
            set { _asiento = value; }
        }

        private String _perimes;
        public String perimes
        {
            get { return _perimes; }
            set { _perimes = value; }
        }

        private String _tipoplla;
        public String tipoplla
        {
            get { return _tipoplla; }
            set { _tipoplla = value; }
        }

        private Decimal _planit;
        public Decimal planit
        {
            get { return _planit; }
            set { _planit = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }
            set { _glosa = value; }
        }

        private DateTime? _fechaini;
        public DateTime? fechaini
        {
            get { return _fechaini; }
            set { _fechaini = value; }
        }

        private DateTime? _fechafin;
        public DateTime? fechafin
        {
            get { return _fechafin; }
            set { _fechafin = value; }
        }

        private Decimal _afect;
        public Decimal afect
        {
            get { return _afect; }
            set { _afect = value; }
        }

        private Decimal _tipcamb;
        public Decimal tipcamb
        {
            get { return _tipcamb; }
            set { _tipcamb = value; }
        }

        private Decimal _semana;
        public Decimal semana
        {
            get { return _semana; }
            set { _semana = value; }
        }

        private Decimal _nsemana;
        public Decimal nsemana
        {
            get { return _nsemana; }
            set { _nsemana = value; }
        }

        private Decimal _cierre;
        public Decimal cierre
        {
            get { return _cierre; }
            set { _cierre = value; }
        }

        private DateTime? _fechasiento;
        public DateTime? fechasiento
        {
            get { return _fechasiento; }
            set { _fechasiento = value; }
        }

        private Decimal _selec;
        public Decimal selec
        {
            get { return _selec; }
            set { _selec = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime? _fechpini;
        public DateTime? fechpini
        {
            get { return _fechpini; }
            set { _fechpini = value; }
        }

        private DateTime? _fechpfin;
        public DateTime? fechpfin
        {
            get { return _fechpfin; }
            set { _fechpfin = value; }
        }

        private DateTime? _fechtareo;
        public DateTime? fechtareo
        {
            get { return _fechtareo; }
            set { _fechtareo = value; }
        }

        private Boolean? _hextra;
        public Boolean? hextra
        {
            get { return _hextra; }
            set { _hextra = value; }
        }

        private Boolean? _reintegro;
        public Boolean? reintegro
        {
            get { return _reintegro; }
            set { _reintegro = value; }
        }

        private Decimal _seleche;
        public Decimal seleche
        {
            get { return _seleche; }
            set { _seleche = value; }
        }

        private Boolean? _oficial;
        public Boolean? oficial
        {
            get { return _oficial; }
            set { _oficial = value; }
        }

        private String _tipoquincena;
        public String tipoquincena
        {
            get { return _tipoquincena; }
            set { _tipoquincena = value; }
        }

        private String _nomlike1;
        public String nomlike1
        {
            get { return _nomlike1; }
            set { _nomlike1 = value; }
        }

        private String _nomlike2;
        public String nomlike2
        {
            get { return _nomlike2; }
            set { _nomlike2 = value; }
        }

        private String _nomlike3;
        public String nomlike3
        {
            get { return _nomlike3; }
            set { _nomlike3 = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }
            set { _norden = value; }
        }

        private String _asemana;
        public String asemana
        {
            get { return _asemana; }
            set { _asemana = value; }
        }
    }
}
