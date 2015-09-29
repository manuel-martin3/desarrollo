using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_me_movimientostarj
    {

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

        private String _posicion;
        public String posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        private String _tipodoc;
        public String tipodoc
        {
            get { return _tipodoc; }

            set { _tipodoc = value; }
        }

        private String _serdoc;
        public String serdoc
        {
            get { return _serdoc; }

            set { _serdoc = value; }
        }

        private String _numdoc;
        public String numdoc
        {
            get { return _numdoc; }

            set { _numdoc = value; }
        }

        private String _items;
        public String items
        {
            get { return _items; }

            set { _items = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
        }
   
        private Decimal _importe;
        public Decimal importe
        {
            get { return _importe; }

            set { _importe = value; }
        }

        private Decimal _precunit;
        public Decimal precunit
        {
            get { return _precunit; }

            set { _precunit = value; }
        }      

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
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
