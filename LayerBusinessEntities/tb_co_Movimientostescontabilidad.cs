using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_Movimientostescontabilidad
    {
        private String _codigoid;
        public String codigoid
        {
            get { return _codigoid; }

            set { _codigoid = value; }
        }

        private String _name;
        public String name
        {
            get { return _name; }

            set { _name = value; }
        }

        private String _sigla;
        public String sigla
        {
            get { return _sigla; }

            set { _sigla = value; }
        }

        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }
    }
}
