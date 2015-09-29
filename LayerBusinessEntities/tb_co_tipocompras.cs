using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_tipocompras
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }
        private String _tipoid;
        public String tipoid
        {
            get { return _tipoid; }

            set { _tipoid = value; }
        }

        private String _tiponame;
        public String tiponame
        {
            get { return _tiponame; }

            set { _tiponame = value; }
        }

        private String _cuenta1id;
        public String cuenta1id
        {
            get { return _cuenta1id; }

            set { _cuenta1id = value; }
        }

        private String _cuenta1name;
        public String cuenta1name
        {
            get { return _cuenta1name; }

            set { _cuenta1name = value; }
        }

        private String _cuenta2id;
        public String cuenta2id
        {
            get { return _cuenta2id; }

            set { _cuenta2id = value; }
        }

        private String _cuenta2name;
        public String cuenta2name
        {
            get { return _cuenta2name; }

            set { _cuenta2name = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }

            set { _moneda = value; }
        }

        //private String _usuar;
        //public String usuar
        //{
        //    get { return _usuar; }

        //    set { _usuar = value; }
        //}

        //private DateTime? _fecre;
        //public DateTime? fecre
        //{
        //    get { return _fecre; }

        //    set { _fecre = value; }
        //}

        //private DateTime? _feact;
        //public DateTime? feact
        //{
        //    get { return _feact; }

        //    set { _feact = value; }
        //}
    }
}
