using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_co_tabla08_libroregistro
    {
        private String _codigoid;
        public String codigoid
        {
            get { return _codigoid; }

            set { _codigoid = value; }
        }

        private String _descripcion;
        public String descripcion
        {
            get { return _descripcion; }

            set { _descripcion = value; }
        }

        private String _sigla;
        public String sigla
        {
            get { return _sigla; }

            set { _sigla = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private DateTime? _fecre;
        public DateTime? fecre
        {
            get { return _fecre; }

            set { _fecre = value; }
        }

        private DateTime? _feact;
        public DateTime? feact
        {
            get { return _feact; }

            set { _feact = value; }
        }
    }
}
