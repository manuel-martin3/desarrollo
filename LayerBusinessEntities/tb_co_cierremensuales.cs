using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_cierremensuales
    {
        private String _dominioid;
        public String dominioid
        {
            get { return _dominioid; }

            set { _dominioid = value; }
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

        private String _periano;
        public String periano
        {
            get { return _periano; }

            set { _periano = value; }
        }

        private String _perimes;
        public String perimes
        {
            get { return _perimes; }

            set { _perimes = value; }
        }

        private String _mesname;
        public String mesname
        {
            get { return _mesname; }

            set { _mesname = value; }
        }

        private Boolean? _status;
        public Boolean? status
        {
            get { return _status; }

            set { _status = value; }
        }

        private String _useripcre;
        public String useripcre
        {
            get { return _useripcre; }

            set { _useripcre = value; }
        }

        private String _userioact;
        public String userioact
        {
            get { return _userioact; }

            set { _userioact = value; }
        }
    }
}
