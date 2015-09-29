using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_rrhh_listadeasistencia
    {

        private String _DDNNI;
        public String DDNNI
        {
            get { return _DDNNI; }

            set { _DDNNI = value; }
        }

        private String _NOMBS;
        public String NOMBS
        {
            get { return _NOMBS; }

            set { _NOMBS = value; }
        }

        private String _NBDIA;
        public String NBDIA
        {
            get { return _NBDIA; }

            set { _NBDIA = value; }
        }

        private DateTime _FECHA;
        public DateTime FECHA
        {
            get { return _FECHA; }

            set { _FECHA = value; }
        }

        private String _MARCA;
        public String MARCA
        {
            get { return _MARCA; }

            set { _MARCA = value; }
        }

        private String _IDCC2;
        public String IDCC2
        {
            get { return _IDCC2; }

            set { _IDCC2 = value; }
        }

        private String _empresaid;
        public String empresaid
        {
            get { return _empresaid; }

            set { _empresaid = value; }
        }

        private DateTime? _FECH1;
        public DateTime? FECH1
        {
            get { return _FECH1; }

            set { _FECH1 = value; }
        }

        private DateTime? _FECH2;
        public DateTime? FECH2
        {
            get { return _FECH2; }

            set { _FECH2 = value; }
        }

        private String _IDCC1;
        public String IDCC1
        {
            get { return _IDCC1; }

            set { _IDCC1 = value; }
        }

        private Boolean _flvis;
        public Boolean flvis
        {
            get { return _flvis; }

            set { _flvis = value; }
        }


        private String _accion;
        public String Accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        /*******************/
        private int _anio;
        public int anio
        {
            get { return _anio; }

            set { _anio = value; }
        }


        private String _perianio;
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }


        private int _mesini;
        public int mesini
        {
            get { return _mesini; }

            set { _mesini = value; }
        }

        private int _mesfin;
        public int mesfin
        {
            get { return _mesfin; }

            set { _mesfin = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }

            set { _filtro = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }
            set { _glosa = value; }
        }

        private String _tipasistenciaid;
        public String tipasistenciaid
        {
            get { return _tipasistenciaid; }
            set { _tipasistenciaid = value; }
        }

    }
}
