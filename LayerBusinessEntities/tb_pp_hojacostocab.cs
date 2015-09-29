using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_pp_hojacostocab
    {
        private String _articid;
        public String articid
        {
            get { return _articid; }
            set { _articid = value; }
        }

        private String _articidold;
        public String articidold
        {
            get { return _articidold; }
            set { _articidold = value; }
        }

        private String _version;
        public String version
        {
            get { return _version; }
            set { _version = value; }
        }

        private DateTime? _fecha;
        public DateTime? fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private Int32 _cantidad;
        public Int32 cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private Decimal _costoprimo;
        public Decimal costoprimo
        {
            get { return _costoprimo; }
            set { _costoprimo = value; }
        }

        private Decimal _percgadm;
        public Decimal percgadm
        {
            get { return _percgadm; }
            set { _percgadm = value; }
        }

        private Decimal _percgvta;
        public Decimal percgvta
        {
            get { return _percgvta; }
            set { _percgvta = value; }
        }

        private Decimal _percgfin;
        public Decimal percgfin
        {
            get { return _percgfin; }
            set { _percgfin = value; }
        }

        private Decimal _gastoadm;
        public Decimal gastoadm
        {
            get { return _gastoadm; }
            set { _gastoadm = value; }
        }

        private Decimal _gastovta;
        public Decimal gastovta
        {
            get { return _gastovta; }
            set { _gastovta = value; }
        }

        private Decimal _gastofin;
        public Decimal gastofin
        {
            get { return _gastofin; }
            set { _gastofin = value; }
        }

        private Decimal _gastopera;
        public Decimal gastopera
        {
            get { return _gastopera; }
            set { _gastopera = value; }
        }

        private Decimal _costototal;
        public Decimal costototal
        {
            get { return _costototal; }
            set { _costototal = value; }
        }

        private String _perianio;
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
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
