using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_me_ctactelistitem
    {
        private Int32 _ctactelistid;
        public Int32 ctactelistid
        {
            get { return _ctactelistid; }
            set { _ctactelistid = value; }
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

        private String _ctacte;
        public String ctacte
        {
            get { return _ctacte; }
            set { _ctacte = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }



    }
}
