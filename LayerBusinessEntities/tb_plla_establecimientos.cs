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
    public class tb_plla_establecimientos
    {
        private String _empresaid;
        public String empresaid
        {
            get { return _empresaid; }
            set { _empresaid = value; }
        }

        private String _estabid;
        public String estabid
        {
            get { return _estabid; }
            set { _estabid = value; }
        }

        private String _estabname;
        public String estabname
        {
            get { return _estabname; }
            set { _estabname = value; }
        }

        private String _estabrtps;
        public String estabrtps
        {
            get { return _estabrtps; }
            set { _estabrtps = value; }
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
        
        private int _vista;
        public int vista
        {
            get { return _vista; }
            set { _vista = value; }
        }

        private Boolean? _status;
        public Boolean? status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
