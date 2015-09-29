using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_cp_comercial
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

        private DateTime? _fechemision;
        public DateTime? fechemision
        {
            get { return _fechemision; }

            set { _fechemision = value; }
        }

        private DateTime? _fechtermino;
        public DateTime? fechtermino
        {
            get { return _fechtermino; }

            set { _fechtermino = value; }
        }

        private String _mnruc;
        public String mnruc
        {
            get { return _mnruc; }

            set { _mnruc = value; }
        }

        private String _ctactename;
        public String ctactename
        {
            get { return _ctactename; }

            set { _ctactename = value; }
        }

        private String _vendedorid;
        public String vendedorid
        {
            get { return _vendedorid; }

            set { _vendedorid = value; }
        }

        private String _brokerid;
        public String brokerid
        {
            get { return _brokerid; }

            set { _brokerid = value; }
        }

        private String _paisid;
        public String paisid
        {
            get { return _paisid; }

            set { _paisid = value; }
        }

        private String _mercadoid;
        public String mercadoid
        {
            get { return _mercadoid; }

            set { _mercadoid = value; }
        }

        private String _marcaid;
        public String marcaid
        {
            get { return _marcaid; }

            set { _marcaid = value; }
        }

        private String _proforma;
        public String proforma
        {
            get { return _proforma; }

            set { _proforma = value; }
        }

        private Boolean? _status;
        public Boolean? status
        {
            get { return _status; }

            set { _status = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }
    }
}
