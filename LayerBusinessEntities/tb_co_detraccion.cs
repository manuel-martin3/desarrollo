using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_detraccion
    {
        private String _detraccionid;
        public String detraccionid
        { 
            get { return _detraccionid; }

            set { _detraccionid = value; }
        }

        private String _detraccionname;
        public String detraccionname
        {
            get { return _detraccionname; }

            set { _detraccionname = value; }
        }

        private String _detraccionporcent;
        public String detraccionporcent
        {
            get { return _detraccionporcent; }

            set { _detraccionporcent = value; }
        }

        private DateTime? _fechini;
        public DateTime? fechini
        {
            get { return _fechini; }

            set { _fechini = value; }
        }

        private DateTime? _fechfin;
        public DateTime? fechfin
        {
            get { return _fechfin; }

            set { _fechfin = value; }
        }

        private Boolean? _status;
        public Boolean? status
        {
            get { return _status; }

            set { _status = value; }
        }

        private int _tipo;
        public int tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }

        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }
    }
}
