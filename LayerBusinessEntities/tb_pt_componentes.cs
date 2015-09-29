using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_pt_componentes
    {
        private String _componenteid;
        public String componenteid
        {
            get { return _componenteid; }

            set { _componenteid = value; }
        }

        private String _componentename;
        public String componentename
        {
            get { return _componentename; }

            set { _componentename = value; }
        }

        private String _componenteabrev;
        public String componenteabrev
        {
            get { return _componenteabrev; }

            set { _componenteabrev = value; }
        }

        private Decimal _orden;
        public Decimal orden
        {
            get { return _orden; }

            set { _orden = value; }
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
