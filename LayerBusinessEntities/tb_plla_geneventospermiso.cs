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
    public class tb_plla_geneventospermiso
    {
        private String _eventoperid;
        public String eventoperid
        {
            get { return _eventoperid; }
            set { _eventoperid = value; }
        }

        private String _eventopername;
        public String eventopername
        {
            get { return _eventopername; }
            set { _eventopername = value; }
        }

        private int _planilla;
        public int planilla
        {
            get { return _planilla; }
            set { _planilla = value; }
        }

        private int _status;
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }

        private String _tipoevento;
        public String tipoevento
        {
            get { return _tipoevento; }
            set { _tipoevento = value; }
        }

        private String _rtpssunat;
        public String rtpssunat
        {
            get { return _rtpssunat; }
            set { _rtpssunat = value; }
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
    }
}
