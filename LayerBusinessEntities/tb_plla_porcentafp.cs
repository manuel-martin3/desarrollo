using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_plla_porcentafp
    {
        private String _regipenid;
        public String regipenid
        {
            get { return _regipenid; }
            set { _regipenid = value; }
        }

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

        private Decimal _remmaxaseg;
        public Decimal remmaxaseg
        {
            get { return _remmaxaseg; }
            set { _remmaxaseg = value; }
        }

        private Decimal _aporteobli;
        public Decimal aporteobli
        {
            get { return _aporteobli; }
            set { _aporteobli = value; }
        }

        private Decimal _comisionfija;
        public Decimal comisionfija
        {
            get { return _comisionfija; }
            set { _comisionfija = value; }
        }

        private Decimal _comisionflujo;
        public Decimal comisionflujo
        {
            get { return _comisionflujo; }
            set { _comisionflujo = value; }
        }

        private Decimal _comisionmixta;
        public Decimal comisionmixta
        {
            get { return _comisionmixta; }
            set { _comisionmixta = value; }
        }

        private Decimal _primaseguro;
        public Decimal primaseguro
        {
            get { return _primaseguro; }
            set { _primaseguro = value; }
        }

        private String _estado;
        public String estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
