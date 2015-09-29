using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_t1_caja
    {

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        private String _local;
        public String local
        {
            get { return _local; }
            set { _local = value; }
        }

        private DateTime? _fecha;
        public DateTime? fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private Decimal _tcambio;
        public Decimal tcambio
        {
            get { return _tcambio; }
            set { _tcambio = value; }
        }

        private String _posicion;
        public String posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        private String _adminid;
        public String adminid
        {
            get { return _adminid; }
            set { _adminid = value; }
        }

        private String _cajeroid;
        public String cajeroid
        {
            get { return _cajeroid; }
            set { _cajeroid = value; }
        }

        private Decimal _apertura1;
        public Decimal apertura1
        {
            get { return _apertura1; }
            set { _apertura1 = value; }
        }

        private Decimal _apertura2;
        public Decimal apertura2
        {
            get { return _apertura2; }
            set { _apertura2 = value; }
        }

        private Decimal _cierre1;
        public Decimal cierre1
        {
            get { return _cierre1; }
            set { _cierre1 = value; }
        }

        private Decimal _cierre2;
        public Decimal cierre2
        {
            get { return _cierre2; }
            set { _cierre2 = value; }
        }


        private Boolean? _cerrado;
        public Boolean? cerrado
        {
            get { return _cerrado; }
            set { _cerrado = value; }
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

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

    }
}
