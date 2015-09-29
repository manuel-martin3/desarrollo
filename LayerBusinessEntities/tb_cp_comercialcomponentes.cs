using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_cp_comercialcomponentes
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }

        private String _empresa;
        public String empresa
        {
            get { return _empresa; }

            set { _empresa = value; }
        }

        private String _asiento;
        public String asiento
        {
            get { return _asiento; }

            set { _asiento = value; }
        }

        private String _items;
        public String items
        {
            get { return _items; }

            set { _items = value; }
        }

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private String _local;
        public String local
        {
            get { return _local; }

            set { _local = value; }
        }

        private String _estiloid;
        public String estiloid
        {
            get { return _estiloid; }

            set { _estiloid = value; }
        }

        private String _componenteid;
        public String componenteid
        {
            get { return _componenteid; }

            set { _componenteid = value; }
        }

        private String _detallecomponente;
        public String detallecomponente
        {
            get { return _detallecomponente; }

            set { _detallecomponente = value; }
        }

        private int _orden;
        public int orden
        {
            get { return _orden; }

            set { _orden = value; }
        }


    }
}
