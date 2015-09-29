using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_pp_rubrocosto
    {
        private String _rubroid;
        public String rubroid
        {
            get { return _rubroid; }
            set { _rubroid = value; }
        }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        private String _rubroname;
        public String rubroname
        {
            get { return _rubroname; }
            set { _rubroname = value; }
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
