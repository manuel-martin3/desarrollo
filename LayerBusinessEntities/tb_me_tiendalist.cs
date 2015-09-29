using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_me_tiendalist
    {
        private Int32? _tiendalist;
        public Int32? tiendalist
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

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }
            set { _usuar = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
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

        private String _tienda;
        public String tienda
        {
            get { return _tienda; }
            set { _tienda = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }



    }
}
