using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics; 
namespace LayerBusinessEntities
{
    public class tb_t1_tarjgrupo
    {

        private Int32? _tarjgrupoid;
        public Int32? tarjgrupoid
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
