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
    public class tb_plla_feriados
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

        private String _peridia;
        public String peridia
        {
            get { return _peridia; }
            set { _peridia = value; }
        }

        private String _descrip;
        public String descrip
        {
            get { return _descrip; }
            set { _descrip = value; }
        }

        private Boolean? _status;
        public Boolean? status
        {
            get { return _status; }
            set { _status = value; }
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

        private String _perianioini;
        public String perianioini
        {
            get { return _perianioini; }
            set { _perianioini = value; }
        }

        private String _perianiofin;
        public String perianiofin
        {
            get { return _perianiofin; }
            set { _perianiofin = value; }
        }

        private int _deleteoall;
        public int deleteoall
        {
            get { return _deleteoall; }
            set { _deleteoall = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }
            set { _norden = value; }
        }

        private int _ver_blanco;
        public int ver_blanco
        {
            get { return _ver_blanco; }
            set { _ver_blanco = value; }
        }
    }
}
