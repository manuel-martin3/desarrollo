using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_condpago
    {

        private String _condpagoid;
        public String condpagoid
        {
            get { return _condpagoid; }

            set { _condpagoid = value; }
        }

        private String _condpagoname;
        public String condpagoname
        {
            get { return _condpagoname; }

            set { _condpagoname = value; }
        }

        //*** opt

        private String _posicion;
        public String posicion
        {
            get { return _posicion; }

            set { _posicion = value; }
        }

    }
}
