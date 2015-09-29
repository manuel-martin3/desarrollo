using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_viatransporte
    {
        private String _codigoid;
        public String codigoid
        {
            get { return _codigoid; }

            set { _codigoid = value; }
        }

        private String _codigoname;
        public String codigoname
        {
            get { return _codigoname; }

            set { _codigoname = value; }
        }

        private String _sigla;
        public String sigla
        {
            get { return _sigla; }

            set { _sigla = value; }
        }
    }
}
