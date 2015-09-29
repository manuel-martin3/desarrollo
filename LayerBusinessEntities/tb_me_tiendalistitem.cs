using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_me_tiendalistitem
    {
        private Int32 _tiendalist;
        public Int32 tiendalist
        {
            get { return _tiendalist; }
            set { _tiendalist = value; }
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

        private String _localid;
        public String localid
        {
            get { return _localid; }
            set { _localid = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }



    }
}
