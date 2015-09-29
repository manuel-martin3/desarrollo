using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_rubroventas
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }

        }
        private String _rubroid;
        public String rubroid
        {
            get { return _rubroid; }

            set { _rubroid = value; }
        }

        private String _rubroname;
        public String rubroname
        {
            get { return _rubroname; }

            set { _rubroname = value; }
        }

        private String _cuentaid;
        public String cuentaid
        {
            get { return _cuentaid; }

            set { _cuentaid = value; }
        }

        private String _cuentaname;
        public String cuentaname
        {
            get { return _cuentaname; }

            set { _cuentaname = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
        }
    }
}
