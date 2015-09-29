using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{

    public class tb_sys_formulario
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

        private String _moduloname;
        public String moduloname
        {
            get { return _moduloname; }

            set { _moduloname = value; }
        }

        private String _moduloshort;
        public String moduloshort
        {
            get { return _moduloshort; }

            set { _moduloshort = value; }
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

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
        }

        private String _formname;
        public String formname
        {
            get { return _formname; }
            set { _formname = value; }
        }


        private String _formfunc;
        public String formfunc
        {
            get { return _formfunc; }
            set { _formfunc = value; }
        }


    }
}
