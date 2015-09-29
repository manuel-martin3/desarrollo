using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{ 
    public class tb_t1_tarjeta
    {
        private Int32 _tarjetaid;
        public Int32 tarjetaid
        {
            get { return _tarjetaid; }
            set { _tarjetaid = value; }
        }

        private String _tarjetaname;
        public String tarjetaname
        {
            get { return _tarjetaname; }
            set { _tarjetaname = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private Byte[] _tarjetalogo;
        public Byte[] tarjetalogo
        {
            get { return _tarjetalogo; }
            set { _tarjetalogo = value; }
        }


        private String _esnuestro;
        public String esnuestro
        {
            get { return _esnuestro; }
            set { _esnuestro = value; }
        }


        private Int32 _tarjgrupoid;
        public Int32 tarjgrupoid
        {
            get { return _tarjgrupoid; }
            set { _tarjgrupoid = value; }
        }

        private String _tarjgruponame;
        public String tarjgruponame
        {
            get { return _tarjgruponame; }
            set { _tarjgruponame = value; }
        }


    }
}
