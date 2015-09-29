using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_Flujoefectivo
    {
        private String _fefectivoorden;
        public String fefectivoorden
        {
            get { return _fefectivoorden; }

            set { _fefectivoorden = value; }
        }

        private String _fefectivoid;
        public String fefectivoid
        {
            get { return _fefectivoid; }

            set { _fefectivoid = value; }
        }

        private String _fefectivoname;
        public String fefectivoname
        {
            get { return _fefectivoname; }

            set { _fefectivoname = value; }
        }

        private String _fefectivoformula;
        public String fefectivoformula
        {
            get { return _fefectivoformula; }

            set { _fefectivoformula = value; }
        }

        private Decimal _importe;
        public Decimal importe
        {
            get { return _importe; }

            set { _importe = value; }
        }

        private Boolean? _fetitulo;
        public Boolean? fetitulo
        {
            get { return _fetitulo; }

            set { _fetitulo = value; }
        }

        private int _incluir_blanco;
        public int incluir_blanco
        {
            get { return _incluir_blanco; }

            set { _incluir_blanco = value; }
        }
    }
}
