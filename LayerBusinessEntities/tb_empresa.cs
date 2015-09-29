using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_empresa
    {
        private String _empresaid;
        public String empresaid
        {
            get { return _empresaid; }

            set { _empresaid = value; }
        }

        private String _empresaname;
        public String empresaname
        {
            get { return _empresaname; }

            set { _empresaname = value; }
        }

        private String _empresaruc;
        public String empresaruc
        {
            get { return _empresaruc; }

            set { _empresaruc = value; }
        }

        private String _empresadirec;
        public String empresadirec
        {
            get { return _empresadirec; }

            set { _empresadirec = value; }
        }

        private String _empresatelef;
        public String empresatelef
        {
            get { return _empresatelef; }

            set { _empresatelef = value; }
        }

        private String _empresaperiodo;
        public String empresaperiodo
        {
            get { return _empresaperiodo; }

            set { _empresaperiodo = value; }
        }

        private String _foto;
        public String foto
        {
            get { return _foto; }

            set { _foto = value; }
        }

        private String _status;
        public String status
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
