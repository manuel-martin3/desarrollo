using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_tipocambiocierre
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        private String _perimes;
        public String perimes
        {
            get { return _perimes; }
            set { _perimes = value; }
        }

        private String _mesname;
        public String mesname
        {
            get { return _mesname; }
            set { _mesname = value; }
        }

        private Decimal _compra;
        public Decimal compra
        {
            get { return _compra; }
            set { _compra = value; }
        }

        private Decimal _venta;
        public Decimal venta
        {
            get { return _venta; }
            set { _venta = value; }
        }
    }
}
