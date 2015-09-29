using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_cliente
    {

        public int listaprecid { get; set; }

        private String _ctacte;
        public String ctacte
        {
            get { return _ctacte; }

            set { _ctacte = value; }
        }

        private String _ctactename;
        public String ctactename
        {
            get { return _ctactename; }

            set { _ctactename = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private String _docuidentid;
        public String docuidentid
        {
            get { return _docuidentid; }

            set { _docuidentid = value; }
        }

        private String _nmruc;
        public String nmruc
        {
            get { return _nmruc; }

            set { _nmruc = value; }
        }

        private String _tpperson;
        public String tpperson
        {
            get { return _tpperson; }

            set { _tpperson = value; }
        }

        private Boolean? _agerent;
        public Boolean? agerent
        {
            get { return _agerent; }

            set { _agerent = value; }
        }

        private String _appat;
        public String appat
        {
            get { return _appat; }

            set { _appat = value; }
        }

        private String _apmat;
        public String apmat
        {
            get { return _apmat; }

            set { _apmat = value; }
        }

        private String _nombr;
        public String nombr
        {
            get { return _nombr; }

            set { _nombr = value; }
        }

        private String _direc;
        public String direc
        {
            get { return _direc; }

            set { _direc = value; }
        }

        private String _paisid;
        public String paisid
        {
            get { return _paisid; }

            set { _paisid = value; }
        }

        private String _ubige;
        public String ubige
        {
            get { return _ubige; }

            set { _ubige = value; }
        }

        private String _telef1;
        public String telef1
        {
            get { return _telef1; }

            set { _telef1 = value; }
        }

        private String _email;
        public String email
        {
            get { return _email; }

            set { _email = value; }
        }

        private String _urweb;
        public String urweb
        {
            get { return _urweb; }

            set { _urweb = value; }
        }

        private Decimal _dscto3;
        public Decimal dscto3
        {
            get { return _dscto3; }

            set { _dscto3 = value; }
        }

        private String _telef2;
        public String telef2
        {
            get { return _telef2; }

            set { _telef2 = value; }
        }

        private String _telef3;
        public String telef3
        {
            get { return _telef3; }

            set { _telef3 = value; }
        }

        private String _clientetipo;
        public String clientetipo
        {
            get { return _clientetipo; }

            set { _clientetipo = value; }
        }

        private String _contacto;
        public String contacto
        {
            get { return _contacto; }

            set { _contacto = value; }
        }

        private String _vendorid;
        public String vendorid
        {
            get { return _vendorid; }

            set { _vendorid = value; }
        }

        private Boolean? _diralter;
        public Boolean? diralter
        {
            get { return _diralter; }

            set { _diralter = value; }
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

        private String _nctactedetraccion;
        public String nctactedetraccion
        {
            get { return _nctactedetraccion; }

            set { _nctactedetraccion = value; }
        }

        private Boolean? _defacliepub;
        public Boolean? defacliepub
        {
            get { return _defacliepub; }
            set { _defacliepub = value; }
        }

        public String canalventaid { get; set; }

        public String replegaldni { get; set; }
        public String replegalname { get; set; }


    }
}
