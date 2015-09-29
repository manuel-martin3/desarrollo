using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_plla_retencionquinta
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

        private String _fichaid;
        public String fichaid
        {
            get { return _fichaid; }
            set { _fichaid = value; }
        }

        private Decimal? _retmensual;
        public Decimal? retmensual
        {
            get { return _retmensual; }
            set { _retmensual = value; }
        }

        private Decimal? _salxretener;
        public Decimal? salxretener
        {
            get { return _salxretener; }
            set { _salxretener = value; }
        }

        private String _fichaini;
        public String fichaini
        {
            get { return _fichaini; }
            set { _fichaini = value; }
        }

        private String _fichafin;
        public String fichafin
        {
            get { return _fichafin; }
            set { _fichafin = value; }
        }

        private int _ntipo;
        public int ntipo
        {
            get { return _ntipo; }
            set { _ntipo = value; }
        }
    }
}
