using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_pp_dise�ador
    {

        private String _dise�adorid;
        public String dise�adorid
        {
          get { return _dise�adorid; }
          set { _dise�adorid = value; }
        }

        private String _dise�adorname;
        public String dise�adorname
        {
            get { return _dise�adorname; }
            set { _dise�adorname = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
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
