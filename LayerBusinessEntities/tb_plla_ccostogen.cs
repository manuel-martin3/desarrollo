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
    public class tb_plla_ccostogen
    {
        private String _codigo;
        public String codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private String _descripcion;
        public String descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }
            set { _cencosid = value; }
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

        private String _empresaid;
        public String empresaid
        {
            get { return _empresaid; }
            set { _empresaid = value; }
        }

        private String _ccostodescartar;
        public String ccostodescartar
        {
            get { return _ccostodescartar; }
            set { _ccostodescartar = value; }
        }
    }
}
