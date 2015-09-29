using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_pp_constantes
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        private Decimal? _percgadm;
        public Decimal? percgadm
        {
            get { return _percgadm; }
            set { _percgadm = value; }
        }

        private Decimal? _percgvta;
        public Decimal? percgvta
        {
            get { return _percgvta; }
            set { _percgvta = value; }
        }

        private Decimal? _percgfin;
        public Decimal? percgfin
        {
            get { return _percgfin; }
            set { _percgfin = value; }
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
