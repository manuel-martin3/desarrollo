using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
   public  class tb_perianio
    {
        private String _codigo;

        public String Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private String _perianio;

        public String Perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }
    }
}
