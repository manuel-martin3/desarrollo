using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_cp_comercialtallas
    {        
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }

        private String _empresa;
        public String empresa
        {
            get { return _empresa; }

            set { _empresa = value; }
        }

        private String _asiento;
        public String asiento
        {
            get { return _asiento; }

            set { _asiento = value; }
        }

        private String _itemstalla;
        public String itemstalla
        {
            get { return _itemstalla; }

            set { _itemstalla = value; }
        }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private String _local;
        public String local
        {
            get { return _local; }

            set { _local = value; }
        }

        private String _tallaid;
        public String tallaid
        {
            get { return _tallaid; }

            set { _tallaid = value; }
        }

        private String _tallaname;
        public String tallaname
        {
            get { return _tallaname; }

            set { _tallaname = value; }
        }

        private int _tallaorden;
        public int tallaorden
        {
            get { return _tallaorden; }

            set { _tallaorden = value; }
        }
    }
}
