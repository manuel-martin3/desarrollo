using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_tipoexportacion
    {
        private String _exportacionid;
        public String exportacionid
        {
            get { return _exportacionid; }

            set { _exportacionid = value; }
        }

        private String _exportacionname;
        public String exportacionname
        {
            get { return _exportacionname; }

            set { _exportacionname = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private DateTime? _fecre;
        public DateTime? fecre
        {
            get { return _fecre; }

            set { _fecre = value; }
        }

        private DateTime? _feact;
        public DateTime? feact
        {
            get { return _feact; }

            set { _feact = value; }
        }
    }
}
