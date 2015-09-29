using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_me_categoriaplanilla
    {
        private String _cateplanid;
        public String cateplanid
        {
            get { return _cateplanid; }
            set { _cateplanid = value; }
        }

        private String _cateplanname;
        public String cateplanname
        {
            get { return _cateplanname; }
            set { _cateplanname = value; }
        }

    }
}
