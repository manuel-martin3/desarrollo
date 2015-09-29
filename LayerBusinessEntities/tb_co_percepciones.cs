using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_percepciones
    {
        private String _percepcionid;
        public String percepcionid
        {
            get { return _percepcionid; }

            set { _percepcionid = value; }
        }

        private String _percepcionname;
        public String percepcionname
        {
            get { return _percepcionname; }

            set { _percepcionname = value; }
        }

        private String _percepcionporcent;
        public String percepcionporcent
        {
            get { return _percepcionporcent; }

            set { _percepcionporcent = value; }
        }

        private Boolean? _status;
        public Boolean? status
        {
            get { return _status; }

            set { _status = value; }
        }
    }
}
