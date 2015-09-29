using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_me_listaprecioscab
    {
        private Int32 _listaprecid;
        public Int32 listaprecid
        {
            get { return _listaprecid; }
            set { _listaprecid = value; }
        }

        private String _listaprecname;
        public String listaprecname
        {
            get { return _listaprecname; }
            set { _listaprecname = value; }
        }

        private DateTime? _fechaini;
        public DateTime? fechaini
        {
            get { return _fechaini; }
            set { _fechaini = value; }
        }

        private DateTime? _fechafin;
        public DateTime? fechafin
        {
            get { return _fechafin; }
            set { _fechafin = value; }
        }

        private Int32 _tiendalist;
        public Int32 tiendalist
        {
            get { return _tiendalist; }
            set { _tiendalist = value; }
        }

        private Int32 _ctactelist;
        public Int32 ctactelist
        {
            get { return _ctactelist; }
            set { _ctactelist = value; }
        }

        private Decimal _tcamb;
        public Decimal tcamb
        {
            get { return _tcamb; }
            set { _tcamb = value; }
        }

        private Boolean _incigv;
        public Boolean incigv
        {
            get { return _incigv; }
            set { _incigv = value; }
        }

        private Boolean _visible;
        public Boolean visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }
            set { _usuar = value; }
        }

        private DateTime? _feact;
        public DateTime? feact
        {
            get { return _feact; }
            set { _feact = value; }
        }

    }
}
