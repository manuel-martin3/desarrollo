using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LayerBusinessEntities
{
    public class tb_plla_plantilla_contratos
    {
        private String _plantillaid;

        public String plantillaid
        {
            get { return _plantillaid; }
            set { _plantillaid = value; }
        }

        private String _plantillaname;
        public String plantillaname
        {
            get { return _plantillaname; }
            set { _plantillaname = value; }
        }

        private String _plantilladoc;
        public String plantilladoc
        {
            get { return _plantilladoc; }
            set { _plantilladoc = value; }
        }



        private String _tipocontratoid;
        public String tipocontratoid
        {
            get { return _tipocontratoid; }
            set { _tipocontratoid = value; }
        }

        private String _tipoestado;
        public String tipoestado
        {
            get { return _tipoestado; }
            set { _tipoestado = value; }
        }



        private BitArray _plantillaword;
        public BitArray plantillaword
        {
            get { return _plantillaword; }
            set { _plantillaword = value; }
        }

        private String _nomlike1;
        public String nomlike1
        {
            get { return _nomlike1; }
            set { _nomlike1 = value; }
        }

        private String _nomlike2;
        public String nomlike2
        {
            get { return _nomlike2; }
            set { _nomlike2 = value; }
        }

        private String _nomlike3;
        public String nomlike3
        {
            get { return _nomlike3; }
            set { _nomlike3 = value; }
        }

        private String _empresaid;
        public String empresaid
        {
            get { return _empresaid; }
            set { _empresaid = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }
            set { _norden = value; }
        }

        private int _ver_blanco;
        public int ver_blanco
        {
            get { return _ver_blanco; }
            set { _ver_blanco = value; }
        }
        private int _vista;
        public int vista
        {
            get { return _vista; }
            set { _vista = value; }
        }
    }
}
