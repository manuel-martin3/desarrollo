using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_pp_diseņador
    {

        private String _diseņadorid;
        public String diseņadorid
        {
          get { return _diseņadorid; }
          set { _diseņadorid = value; }
        }

        private String _diseņadorname;
        public String diseņadorname
        {
            get { return _diseņadorname; }
            set { _diseņadorname = value; }
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
