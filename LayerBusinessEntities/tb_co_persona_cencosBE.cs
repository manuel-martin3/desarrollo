using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_co_persona_cencosBE
    {
        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }
            set { _cencosid = value; }
        }

        private Int32 _item;
        public Int32 item
        {
            get { return _item; }
            set { _item = value; }
        }

        private Boolean _cencosestado;
        public Boolean cencosestado
        {
            get { return _cencosestado; }
            set { _cencosestado = value; }
        }

        private String _cencosestacion;
        public String cencosestacion
        {
            get { return _cencosestacion; }
            set { _cencosestacion = value; }
        }

        private String _filtro;

        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private DateTime? _cencosfecha;
        public DateTime? cencosfecha
        {
            get { return _cencosfecha; }
            set { _cencosfecha = value; }
        }

        private String _perdni;

        public String perdni
        {
            get { return _perdni; }
            set { _perdni = value; }
        }


        private String _pername;
        public String pername
        {
            get { return _pername; }
            set { _pername = value; }
        }

        private Int32 _tipo;
        public Int32 tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        private String _cencosname;

        public String cencosname
        {
            get { return _cencosname; }
            set { _cencosname = value; }
        }


        private String _moduloiddies;

        public String moduloiddies
        {
            get { return _moduloiddies; }
            set { _moduloiddies = value; }
        }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }


        private int _operacion;

        public int operacion
        {
            get { return _operacion; }
            set { _operacion = value; }
        }
   
    }
}
