using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_pp_hojacostodet
    {
        private String _articid;
        public String articid
        {
            get { return _articid; }
            set { _articid = value; }
        }

        private String _version;
        public String version
        {
            get { return _version; }
            set { _version = value; }
        }

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

        private String _lineaid;
        public String lineaid
        {
            get { return _lineaid; }
            set { _lineaid = value; }
        }

        private String _familiaid;
        public String familiaid
        {
            get { return _familiaid; }
            set { _familiaid = value; }
        }

        private Decimal _valor;
        public Decimal valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private Decimal _consumo;
        public Decimal consumo
        {
            get { return _consumo; }
            set { _consumo = value; }
        }

        private String _unmed;
        public String unmed
        {
            get { return _unmed; }
            set { _unmed = value; }
        }

        private Decimal _importe;
        public Decimal importe
        {
            get { return _importe; }
            set { _importe = value; }
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
