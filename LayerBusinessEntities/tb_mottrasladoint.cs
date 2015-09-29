using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_mottrasladoint
    {
        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private Boolean? _visible;
        public Boolean? visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private String _mottrasladointid;
        public String mottrasladointid
        {
            get { return _mottrasladointid; }

            set { _mottrasladointid = value; }
        }

        private String _mottrasladointname;
        public String mottrasladointname
        {
            get { return _mottrasladointname; }

            set { _mottrasladointname = value; }
        }

        private String _codigosunat;
        public String codigosunat
        {
            get { return _codigosunat; }

            set { _codigosunat = value; }
        }

        private Boolean _esventa;
        public Boolean esventa
        {
            get { return _esventa; }

            set { _esventa = value; }
        }

        private Boolean _escompra;
        public Boolean escompra
        {
            get { return _escompra; }

            set { _escompra = value; }
        }

        private String _tipmov;
        public String tipmov
        {
            get { return _tipmov; }

            set { _tipmov = value; }
        }

        //*** OPT
        private String _posicion;
        public String posicion
        {
            get { return _posicion; }

            set { _posicion = value; }
        }

    }
}
