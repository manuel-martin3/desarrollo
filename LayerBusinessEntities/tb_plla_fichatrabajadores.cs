using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_plla_fichatrabajadores
    {
        #region Fields
        private String _fichaid;
        private String _apepat;
        private String _apemat;
        private String _nombres;
        private String _nombrelargo;
        private String _tipdocid;
        private String _nrodni;
        private String _nmruc;
        private String _ctactename;
        private String _direcc;
        private String _ubiged;
        private String _ubigen;
        private String _estadocivil;
        private String _sexo;
        private String _telef1;
        private String _telef2;
        private String _carnetsegsoc;
        private DateTime? _fechnacimiento;
        private DateTime? _fechingreso;
        private String _situtrabid;
        private Boolean? _sctr;
        private Boolean? _remintegral;
        private Boolean? _autocontrol;
        private Boolean? _chkdephab;
        private String _bancoidhab;
        private String _ctahaberes;
        private Boolean? _chkdepcts;
        private String _bancoidcts;
        private String _ctacts;
        private String _tipodeta;
        private String _cencosid;
        private String _cargoid;
        private String _detallecontable;
        private String _regipenid;
        private String _cuspp;
        private DateTime? _fechafiliacion;
        private String _tipcomisionafp;
        private Boolean? _essaludvida;
        private String _email;
        private String _niveleduid;
        private Boolean? _discapacitado;
        private String _tipestabid;
        private String _cateocupid;
        private String _fotografia;
        private String _observacion;
        private DateTime? _fechregistro;
        private String _activo;
        private String _status;
        private String _usuar;
        private DateTime? _fecre;
        private DateTime? _feact;
        private String _viaid;
        private String _zonaid;
        private String _epsid;
        private String _tippagoid;
        private String _convendobletribid;
        private String _tipsuspenid;
        private String _motivocese;
        private DateTime? _fechcese;
        private int _norden;
        private String _nomlike1;
        private String _nomlike2;
        private String _nomlike3;
        private int _estado_trabaj;
        private String _tipoplla;
        private String _establec;
        private Boolean? _chkconvenio;
        private String _fichaidIni;
        private String _fichaidFin;
        private String _empresaid;
        private String _F_suscripcion;
        private String _xlistacodigos;
        private int _ntipo;
        private String _jefe;
        private int _ver_inactivos;
        #endregion

        #region Properties
        public System.String Fichaid
        {
            get
            {
                return _fichaid;
            }
            set
            {
                _fichaid = value;
            }
        }

        public System.String Apepat
        {
            get
            {
                return _apepat;
            }
            set
            {
                _apepat = value;
            }
        }

        public System.String Apemat
        {
            get
            {
                return _apemat;
            }
            set
            {
                _apemat = value;
            }
        }

        public System.String Nombres
        {
            get
            {
                return _nombres;
            }
            set
            {
                _nombres = value;
            }
        }

        public System.String Nombrelargo
        {
            get
            {
                return _nombrelargo;
            }
            set
            {
                _nombrelargo = value;
            }
        }

        public System.String Tipdocid
        {
            get
            {
                return _tipdocid;
            }
            set
            {
                _tipdocid = value;
            }
        }

        public System.String Nrodni
        {
            get
            {
                return _nrodni;
            }
            set
            {
                _nrodni = value;
            }
        }

        public System.String Nmruc
        {
            get
            {
                return _nmruc;
            }
            set
            {
                _nmruc = value;
            }
        }

        public System.String Ctactename
        {
            get
            {
                return _ctactename;
            }
            set
            {
                _ctactename = value;
            }
        }

        public System.String Direcc
        {
            get
            {
                return _direcc;
            }
            set
            {
                _direcc = value;
            }
        }

        public System.String Ubiged
        {
            get
            {
                return _ubiged;
            }
            set
            {
                _ubiged = value;
            }
        }

        public System.String Ubigen
        {
            get
            {
                return _ubigen;
            }
            set
            {
                _ubigen = value;
            }
        }

        public System.String Estadocivil
        {
            get
            {
                return _estadocivil;
            }
            set
            {
                _estadocivil = value;
            }
        }

        public System.String Sexo
        {
            get
            {
                return _sexo;
            }
            set
            {
                _sexo = value;
            }
        }

        public System.String Telef1
        {
            get
            {
                return _telef1;
            }
            set
            {
                _telef1 = value;
            }
        }

        public System.String Telef2
        {
            get
            {
                return _telef2;
            }
            set
            {
                _telef2 = value;
            }
        }

        public System.String Carnetsegsoc
        {
            get
            {
                return _carnetsegsoc;
            }
            set
            {
                _carnetsegsoc = value;
            }
        }

        public System.DateTime? Fechnacimiento
        {
            get
            {
                return _fechnacimiento;
            }
            set
            {
                _fechnacimiento = value;
            }
        }

        public System.DateTime? Fechingreso
        {
            get
            {
                return _fechingreso;
            }
            set
            {
                _fechingreso = value;
            }
        }

        public System.String Situtrabid
        {
            get
            {
                return _situtrabid;
            }
            set
            {
                _situtrabid = value;
            }
        }

        public System.Boolean? Sctr
        {
            get
            {
                return _sctr;
            }
            set
            {
                _sctr = value;
            }
        }

        public System.Boolean? Remintegral
        {
            get
            {
                return _remintegral;
            }
            set
            {
                _remintegral = value;
            }
        }

        public System.Boolean? Autocontrol
        {
            get
            {
                return _autocontrol;
            }
            set
            {
                _autocontrol = value;
            }
        }

        public System.Boolean? Chkdephab
        {
            get
            {
                return _chkdephab;
            }
            set
            {
                _chkdephab = value;
            }
        }

        public System.String Bancoidhab
        {
            get
            {
                return _bancoidhab;
            }
            set
            {
                _bancoidhab = value;
            }
        }

        public System.String Ctahaberes
        {
            get
            {
                return _ctahaberes;
            }
            set
            {
                _ctahaberes = value;
            }
        }

        public System.Boolean? Chkdepcts
        {
            get
            {
                return _chkdepcts;
            }
            set
            {
                _chkdepcts = value;
            }
        }

        public System.String Bancoidcts
        {
            get
            {
                return _bancoidcts;
            }
            set
            {
                _bancoidcts = value;
            }
        }

        public System.String Ctacts
        {
            get
            {
                return _ctacts;
            }
            set
            {
                _ctacts = value;
            }
        }

        public System.String Tipodeta
        {
            get
            {
                return _tipodeta;
            }
            set
            {
                _tipodeta = value;
            }
        }

        public System.String Cencosid
        {
            get
            {
                return _cencosid;
            }
            set
            {
                _cencosid = value;
            }
        }

        public System.String Cargoid
        {
            get
            {
                return _cargoid;
            }
            set
            {
                _cargoid = value;
            }
        }

        public System.String Detallecontable
        {
            get
            {
                return _detallecontable;
            }
            set
            {
                _detallecontable = value;
            }
        }

        public System.String Regipenid
        {
            get
            {
                return _regipenid;
            }
            set
            {
                _regipenid = value;
            }
        }

        public System.String Cuspp
        {
            get
            {
                return _cuspp;
            }
            set
            {
                _cuspp = value;
            }
        }

        public System.DateTime? Fechafiliacion
        {
            get
            {
                return _fechafiliacion;
            }
            set
            {
                _fechafiliacion = value;
            }
        }

        public System.String Tipcomisionafp
        {
            get { return _tipcomisionafp; }

            set { _tipcomisionafp = value; }
        }

        public System.Boolean? Essaludvida
        {
            get
            {
                return _essaludvida;
            }
            set
            {
                _essaludvida = value;
            }
        }

        public System.String Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public System.String Niveleduid
        {
            get
            {
                return _niveleduid;
            }
            set
            {
                _niveleduid = value;
            }
        }

        public System.Boolean? Discapacitado
        {
            get
            {
                return _discapacitado;
            }
            set
            {
                _discapacitado = value;
            }
        }

        public System.String Tipestabid
        {
            get
            {
                return _tipestabid;
            }
            set
            {
                _tipestabid = value;
            }
        }

        public System.String Cateocupid
        {
            get
            {
                return _cateocupid;
            }
            set
            {
                _cateocupid = value;
            }
        }

        public System.String Fotografia
        {
            get
            {
                return _fotografia;
            }
            set
            {
                _fotografia = value;
            }
        }

        public System.String Observacion
        {
            get
            {
                return _observacion;
            }
            set
            {
                _observacion = value;
            }
        }

        public System.DateTime? Fechregistro
        {
            get
            {
                return _fechregistro;
            }
            set
            {
                _fechregistro = value;
            }
        }

        public System.String Activo
        {
            get
            {
                return _activo;
            }
            set
            {
                _activo = value;
            }
        }

        public System.String Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public System.String Usuar
        {
            get
            {
                return _usuar;
            }
            set
            {
                _usuar = value;
            }
        }

        public System.DateTime? Fecre
        {
            get
            {
                return _fecre;
            }
            set
            {
                _fecre = value;
            }
        }

        public System.DateTime? Feact
        {
            get
            {
                return _feact;
            }
            set
            {
                _feact = value;
            }
        }

        public System.String Viaid
        {
            get
            {
                return _viaid;
            }
            set
            {
                _viaid = value;
            }
        }

        public System.String Zonaid
        {
            get
            {
                return _zonaid;
            }
            set
            {
                _zonaid = value;
            }
        }

        public System.String Epsid
        {
            get
            {
                return _epsid;
            }
            set
            {
                _epsid = value;
            }
        }

        public System.String Tippagoid
        {
            get
            {
                return _tippagoid;
            }
            set
            {
                _tippagoid = value;
            }
        }

        public System.String Convendobletribid
        {
            get
            {
                return _convendobletribid;
            }
            set
            {
                _convendobletribid = value;
            }
        }

        public System.String Tipsuspenid
        {
            get
            {
                return _tipsuspenid;
            }
            set
            {
                _tipsuspenid = value;
            }
        }

        public String Motivocese
        {
            get { return _motivocese; }
            set { _motivocese = value; }
        }

        public DateTime? Fechcese
        {
            get { return _fechcese; }
            set { _fechcese = value; }
        }

        public int Norden
        {
            get { return _norden; }
            set { _norden = value; }
        }

        public String Nomlike1
        {
            get { return _nomlike1; }
            set { _nomlike1 = value; }
        }

        public String Nomlike2
        {
            get { return _nomlike2; }
            set { _nomlike2 = value; }
        }

        public String Nomlike3
        {
            get { return _nomlike3; }
            set { _nomlike3 = value; }
        }

        public int Estado_trabaj
        {
            get { return _estado_trabaj; }
            set { _estado_trabaj = value; }
        }

        public String Tipoplla
        {
            get { return _tipoplla; }
            set { _tipoplla = value; }
        }

        public String Establec
        {
            get { return _establec; }
            set { _establec = value; }
        }

        public Boolean? Chkconvenio
        {
            get { return _chkconvenio; }
            set { _chkconvenio = value; }
        }

        public String FichaidIni
        {
            get { return _fichaidIni; }
            set { _fichaidIni = value; }
        }

        public String FichaidFin
        {
            get { return _fichaidFin; }
            set { _fichaidFin = value; }
        }

        public String Empresaid
        {
            get { return _empresaid; }
            set { _empresaid = value; }
        }

        public String F_suscripcion
        {
            get { return _F_suscripcion; }
            set { _F_suscripcion = value; }
        }

        public String Xlistacodigos
        {
            get { return _xlistacodigos; }
            set { _xlistacodigos = value; }
        }

        public int Ntipo
        {
            get { return _ntipo; }
            set { _ntipo = value; }
        }

        public String Jefe
        {
            get { return _jefe; }
            set { _jefe = value; }
        }

        public int Ver_inactivos
        {
            get { return _ver_inactivos; }
            set { _ver_inactivos = value; }
        }
        
        #endregion
    }
}
