using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_me_linea
    {
        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private String _lineaid;
        public String lineaid
        {
            get { return _lineaid; }

            set { _lineaid = value; }
        }

        private String _lineaidold;
        public String lineaidold
        {
            get { return _lineaidold; }
            set { _lineaidold = value; }
        }

        private String _lineaname;
        public String lineaname
        {
            get { return _lineaname; }

            set { _lineaname = value; }
        }

        private String _estructuraid;
        public String estructuraid
        {
            get { return _estructuraid; }

            set { _estructuraid = value; }
        }

        private String _local;
        public String local
        {
            get { return _local; }
            set { _local = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private DateTime? _feact;
        public DateTime? feact
        {
            get { return _feact; }

            set { _feact = value; }
        }

        private DateTime? _fecre;
        public DateTime? fecre
        {
            get { return _fecre; }

            set { _fecre = value; }
        }

        private Boolean? _nostock;
        public Boolean? nostock
        {
            get { return _nostock; }
            set { _nostock = value; }
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
