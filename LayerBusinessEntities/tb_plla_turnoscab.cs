using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_plla_turnoscab
    {
        private String _cdiario;
        public String cdiario
        {
            get { return _cdiario; }
            set { _cdiario = value; }
        }

        private String _descripcion;
        public String descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private String _evento;
        public String evento
        {
            get { return _evento; }
            set { _evento = value; }
        }

        private String _horaini;
        public String horaini
        {
            get { return _horaini; }
            set { _horaini = value; }
        }

        private String _horafin;
        public String horafin
        {
            get { return _horafin; }
            set { _horafin = value; }
        }

        private String _tothor;
        public String tothor
        {
            get { return _tothor; }
            set { _tothor = value; }
        }

        private Decimal _totmin;
        public Decimal totmin
        {
            get { return _totmin; }
            set { _totmin = value; }
        }

        private String _quiebre;
        public String quiebre
        {
            get { return _quiebre; }
            set { _quiebre = value; }
        }

        private Decimal _status;
        public Decimal status
        {
            get { return _status; }
            set { _status = value; }
        }

        private String _nomlike1;
        public String nomlike1
        {
            get { return _nomlike1; }
            set { _nomlike1 = value; }
        }

        private String _nomlike2;
        public String nomlike2
        {
            get { return _nomlike2; }
            set { _nomlike2 = value; }
        }

        private String _nomlike3;
        public String nomlike3
        {
            get { return _nomlike3; }
            set { _nomlike3 = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }
            set { _norden = value; }
        }

        private int _ver_blanco;
        public int ver_blanco
        {
            get { return _ver_blanco; }
            set { _ver_blanco = value; }
        }
    
        private int _Tipo_Actualizacion;
        public int Tipo_Actualizacion
        {
            get { return _Tipo_Actualizacion; }
            set { _Tipo_Actualizacion = value; }
        }

        //
        private String _item;
        public String item
        {
            get { return _item; }
            set { _item = value; }
        }  
    }
}
