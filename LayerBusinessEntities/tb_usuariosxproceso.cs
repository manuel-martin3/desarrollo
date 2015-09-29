using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_usuariosxproceso
    {
        private String _procesoid;
        public String procesoid
        {
            get { return _procesoid; }

            set { _procesoid = value; }
        }

        private String _procesoname;
        public String procesoname
        {
            get { return _procesoname; }

            set { _procesoname = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }

            set { _norden = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private String _password;
        public String password
        {
            get { return _password; }

            set { _password = value; }
        }

        private String _login;
        public String login
        {
            get { return _login; }

            set { _login = value; }
        }

        private String _clave;
        public String clave
        {
            get { return _clave; }

            set { _clave = value; }
        }

        private int _ntipo;
        public int ntipo
        {
            get { return _ntipo; }

            set { _ntipo = value; }
        }
    }
}
