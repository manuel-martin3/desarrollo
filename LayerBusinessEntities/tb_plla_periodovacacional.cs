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
    public class tb_plla_periodovacacional
    {
        private String _idperiodo;
        public String idperiodo
        {
            get { return _idperiodo; }
            set { _idperiodo = value; }
        }

        private String _periodo;
        public String periodo
        {
            get { return _periodo; }
            set { _periodo = value; }
        }

        private int _glosa;
        public int glosa
        {
            get { return _glosa; }
            set { _glosa = value; }
        }

        private Decimal _status;
        public Decimal status
        {
            get { return _status; }
            set { _status = value; }
        }

        private String _periodoini;
        public String periodoini
        {
            get { return _periodoini; }
            set { _periodoini = value; }
        }

        private String _periodofin;
        public String periodofin
        {
            get { return _periodofin; }
            set { _periodofin = value; }
        }

        private String _nomlike;
        public String nomlike
        {
            get { return _nomlike; }
            set { _nomlike = value; }
        }
    }
}
