using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_seguridadlog
    {
        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private String _clave;
        public String clave
        {
            get { return _clave; }

            set { _clave = value; }
        }

        private String _cuser;
        public String cuser
        {
            get { return _cuser; }

            set { _cuser = value; }
        }

        private DateTime? _fecha;
        public DateTime? fecha
        {
            get { return _fecha; }

            set { _fecha = value; }
        }

        private TimeSpan _correlativo;
        public TimeSpan correlativo
        {
            get { return _correlativo; }

            set { _correlativo = value; }
        }

        private String _pc;
        public String pc
        {
            get { return _pc; }

            set { _pc = value; }
        }

        private String _accion;
        public String accion
        {
            get { return _accion; }

            set { _accion = value; }
        }

        private String _detalle;
        public String detalle
        {
            get { return _detalle; }

            set { _detalle = value; }
        }

        private DateTime? _fechafin;
        public DateTime? fechafin
        {
            get { return _fechafin; }

            set { _fechafin = value; }
        }
    }
}
