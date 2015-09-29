using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_px_grupo_promociones
    {
        private Int32? _grupopromoid;
        public Int32? grupopromoid
        {
            get { return _grupopromoid; }
            set { _grupopromoid = value; }
        }


        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

        private String _grupopromoname;
        public String grupopromoname
        {
            get { return _grupopromoname; }
            set { _grupopromoname = value; }
        }

    }
}
