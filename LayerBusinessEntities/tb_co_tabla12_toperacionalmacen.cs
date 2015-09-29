using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_co_tabla12_toperacionalmacen
    {

        public String cabecera { get; set; }

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

        private String _almacenaccionid;
        public String almacenaccionid
        {
            get { return _almacenaccionid; }

            set { _almacenaccionid = value; }
        }

        private String _docureq;
        public String docureq
        {
            get { return _docureq; }

            set { _docureq = value; }
        }

        private String _contratipo;
        public String contratipo
        {
            get { return _contratipo; }

            set { _contratipo = value; }
        }

        private String _tiptransac;
        public String tiptransac
        {
            get { return _tiptransac; }

            set { _tiptransac = value; }
        }

        private String _statcostopromed;
        public String statcostopromed
        {
            get { return _statcostopromed; }

            set { _statcostopromed = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private Boolean? _visible;
        public Boolean? visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private DateTime _fecre;
        public DateTime fecre
        {
            get { return _fecre; }

            set { _fecre = value; }
        }

        private DateTime _feact;
        public DateTime feact
        {
            get { return _feact; }

            set { _feact = value; }
        }

    }
}
