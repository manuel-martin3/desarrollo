using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
    public class tb_sys_status
    {

        private String _concepto;
        public String concepto
        {
            get { return _concepto; }
            set { _concepto = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }


        private String _statusname;
        public String statusname
        {
            get { return _statusname; }
            set { _statusname = value; }
        }


    }
}
