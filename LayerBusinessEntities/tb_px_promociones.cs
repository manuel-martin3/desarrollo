using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_px_promociones
    {
        private Int32? _promoid;
        public Int32? promoid
        {
            get { return _promoid; }
            set { _promoid = value; }
        }

        private String _prioridad;
        public String prioridad
        {
            get { return _prioridad; }
            set { _prioridad = value; }
        }

        private DateTime _fechaActual;
        public DateTime fechaActual
        {
            get { return _fechaActual; }
            set { _fechaActual = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

        private String _exclusivo;
        public String exclusivo
        {
            get { return _exclusivo; }
            set { _exclusivo = value; }
        }

        private Int32 _filtro;
        public Int32 filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private String _promoname;
        public String promoname
        {
            get { return _promoname; }
            set { _promoname = value; }
        }

        private Int32 _tiendalist;
        public Int32 tiendalist
        {
            get { return _tiendalist; }
            set { _tiendalist = value; }
        }

        private Int32 _tarjgrupoid;
        public Int32 tarjgrupoid
        {
            get { return _tarjgrupoid; }
            set { _tarjgrupoid = value; }
        }

        private String _tarjetaid;
        public String tarjetaid
        {
            get { return _tarjetaid; }
            set { _tarjetaid = value; }
        }

        private Decimal _percdscto;
        public Decimal percdscto
        {
            get { return _percdscto; }
            set { _percdscto = value; }
        }

        private Boolean _al_docum;
        public Boolean al_docum
        {
            get { return _al_docum; }
            set { _al_docum = value; }
        }

        private DateTime? _fechaini;
        public DateTime? fechaini
        {
            get { return _fechaini; }
            set { _fechaini = value; }
        }

        private DateTime? _fechafin;
        public DateTime? fechafin
        {
            get { return _fechafin; }
            set { _fechafin = value; }
        }


        private Int32? _promotipoid;
        public Int32? promotipoid
        {
            get { return _promotipoid; }
            set { _promotipoid = value; }
        }
       

        private Int32? _grupopromoid;
        public Int32? grupopromoid
        {
            get { return _grupopromoid; }
            set { _grupopromoid = value; }
        }
    

        private Int32 _campaniaid;
        public Int32 campaniaid
        {
            get { return _campaniaid; }
            set { _campaniaid = value; }
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

        private String _usuarap;
        public String usuarap
        {
            get { return _usuarap; }
            set { _usuarap = value; }
        }

        private DateTime? _fechap;
        public DateTime? fechap
        {
            get { return _fechap; }
            set { _fechap = value; }
        }

        private Boolean _solodias;
        public Boolean solodias
        {
            get { return _solodias; }
            set { _solodias = value; }
        }

        private Boolean _dom;
        public Boolean dom
        {
            get { return _dom; }
            set { _dom = value; }
        }

        private Boolean _lun;
        public Boolean lun
        {
            get { return _lun; }
            set { _lun = value; }
        }

        private Boolean _mar;
        public Boolean mar
        {
            get { return _mar; }
            set { _mar = value; }
        }

        private Boolean _mie;
        public Boolean mie
        {
            get { return _mie; }
            set { _mie = value; }
        }

        private Boolean _jue;
        public Boolean jue
        {
            get { return _jue; }
            set { _jue = value; }
        }

        private Boolean _vie;
        public Boolean vie
        {
            get { return _vie; }
            set { _vie = value; }
        }

        private Boolean _sab;
        public Boolean sab
        {
            get { return _sab; }
            set { _sab = value; }
        }

        private Int32 _npack;
        public Int32 npack
        {
            get { return _npack; }
            set { _npack = value; }
        }

        private Decimal _impopack;
        public Decimal impopack
        {
            get { return _impopack; }
            set { _impopack = value; }
        }


        private Int32 _aplicini;
        public Int32 aplicini
        {
            get { return _aplicini; }
            set { _aplicini = value; }
        }

        private Int32 _aplicfin;
        public Int32 aplicfin
        {
            get { return _aplicfin; }
            set { _aplicfin = value; }
        }

        private Decimal _impodoc;
        public Decimal impodoc
        {
            get { return _impodoc; }
            set { _impodoc = value; }
        }



    }

}
