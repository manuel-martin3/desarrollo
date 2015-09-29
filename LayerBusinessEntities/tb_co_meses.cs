using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_meses
    {
        private String _mesid;
        public String mesid
        {
            get { return _mesid; }

            set { _mesid = value; }
        }

        private String _mesname;
        public String mesname
        {
            get { return _mesname; }

            set { _mesname = value; }
        }

        private int _ntipo;
        public int ntipo
        {
            get { return _ntipo; }

            set { _ntipo = value; }
        }
    }
}
