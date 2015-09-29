using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_pp_diseñador
    {

        private String _diseñadorid;
        public String diseñadorid
        {
          get { return _diseñadorid; }
          set { _diseñadorid = value; }
        }

        private String _diseñadorname;
        public String diseñadorname
        {
            get { return _diseñadorname; }
            set { _diseñadorname = value; }
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
