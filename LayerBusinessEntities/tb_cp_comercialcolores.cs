using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_cp_comercialcolores
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

        private String _itemscolor;
        public String itemscolor
        {
            get { return _itemscolor; }

            set { _itemscolor = value; }
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

        private String _colorid;
        public String colorid
        {
            get { return _colorid; }

            set { _colorid = value; }
        }

        private String _colorname;
        public String colorname
        {
            get { return _colorname; }

            set { _colorname = value; }
        }

        private int _ordencolor;
        public int ordencolor
        {
            get { return _ordencolor; }

            set { _ordencolor = value; }
        }
    }
}
