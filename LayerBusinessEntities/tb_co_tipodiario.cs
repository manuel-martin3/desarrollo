using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_tipodiario
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }

        private String _diarioid;
        public String diarioid
        {
            get { return _diarioid; }

            set { _diarioid = value; }
        }

        private String _sigla;
        public String sigla
        {
            get { return _sigla; }

            set { _sigla = value; }
        }

        private String _diarioname;
        public String diarioname
        {
            get { return _diarioname; }

            set { _diarioname = value; }
        }

        private Boolean? _tesoreria;
        public Boolean? tesoreria
        {
            get { return _tesoreria; }

            set { _tesoreria = value; }
        }

        private String _cuentaid;
        public String cuentaid
        {
            get { return _cuentaid; }

            set { _cuentaid = value; }
        }

        private String _cuentaname;
        public String cuentaname
        {
            get { return _cuentaname; }

            set { _cuentaname = value; }
        }

        private Boolean? _contabilidad;
        public Boolean? contabilidad
        {
            get { return _contabilidad; }

            set { _contabilidad = value; }
        }

        private Boolean? _registrocompra;
        public Boolean? registrocompra
        {
            get { return _registrocompra; }

            set { _registrocompra = value; }
        }

        private Boolean? _registroventa;
        public Boolean? registroventa
        {
            get { return _registroventa; }

            set { _registroventa = value; }
        }

        private Boolean? _almacen;
        public Boolean? almacen
        {
            get { return _almacen; }

            set { _almacen = value; }
        }

        private Boolean? _consolidardiario;
        public Boolean? consolidardiario
        {
            get { return _consolidardiario; }

            set { _consolidardiario = value; }
        }

        private Boolean? _canjeletra;
        public Boolean? canjeletra
        {
            get { return _canjeletra; }

            set { _canjeletra = value; }
        }

        private Boolean? _serie;
        public Boolean? serie
        {
            get { return _serie; }

            set { _serie = value; }
        }

        private Boolean? _generasientodestino;
        public Boolean? generasientodestino
        {
            get { return _generasientodestino; }

            set { _generasientodestino = value; }
        }

        private Boolean? _status;
        public Boolean? status
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

        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }

            set { _moduloid = value; }
        }

        private int _norden;
        public int norden
        {
            get { return _norden; }

            set { _norden = value; }
        }
    }
}
