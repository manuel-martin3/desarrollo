using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_me_tienda
    {
 
        private String _posicion;
        public String posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }
            set { _usuar = value; }
        }

        private Int32 _tiendalist;
        public Int32 tiendalist
        {
            get { return _tiendalist; }
            set { _tiendalist = value; }
        }

        private String _tiendalistname;
        public String tiendalistname
        {
            get { return _tiendalistname; }
            set { _tiendalistname = value; }
        }

        private String _local;
        public String local
        {
            get { return _local; }
            set { _local = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }


    }
}
