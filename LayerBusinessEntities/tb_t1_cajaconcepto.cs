using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_t1_cajaconcepto
    {

        private String _conceptoid;
        public String conceptoid
        {
            get { return _conceptoid; }
            set { _conceptoid = value; }
        }

        private String _conceptoname;
        public String conceptoname
        {
            get { return _conceptoname; }
            set { _conceptoname = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private String _cajaaccionid;
        public String cajaaccionid
        {
            get { return _cajaaccionid; }
            set { _cajaaccionid = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }
            set { _usuar = value; }
        }

        private DateTime _fecre;
        public DateTime fecre
        {
            get { return _fecre; }
            set { _fecre = value; }
        }

        private DateTime _feact;
        public DateTime feact
        {
            get { return _feact; }
            set { _feact = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

        private Boolean _editable;
        public Boolean editable
        {
            get { return _editable; }
            set { _editable = value; }
        }

        private Int32 _fila;
        public Int32 fila
        {
            get { return _fila; }
            set { _fila = value; }
        }	

    }
}
