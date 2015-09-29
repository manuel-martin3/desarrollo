using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
    public class tb_cm_conceptos
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

        private Decimal _tasa;
        public Decimal tasa
        {
            get { return _tasa; }
            set { _tasa = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }


        private String _get_mov;
        public String get_mov
        {
            get { return _get_mov; }
            set { _get_mov = value; }
        }

        private String _analitico;
        public String analitico
        {
            get { return _analitico; }
            set { _analitico = value; }
        }

        private String _cif;
        public String cif
        {
            get { return _cif; }
            set { _cif = value; }
        }

        private String _advalorem;
        public String advalorem
        {
            get { return _advalorem; }
            set { _advalorem = value; }
        }

        private String _igv;
        public String igv
        {
            get { return _igv; }
            set { _igv = value; }
        }

        private String _imp;
        public String imp
        {
            get { return _imp; }
            set { _imp = value; }
        }

        private String _tddua;
        public String tddua
        {
            get { return _tddua; }
            set { _tddua = value; }
        }

        private Decimal _uit;
        public Decimal uit
        {
            get { return _uit; }
            set { _uit = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
