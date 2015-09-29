using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{

    public class tb_usuarios
    {

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private String _nombr;
        public String nombr
        {
            get { return _nombr; }

            set { _nombr = value; }
        }

        private String _clave;
        public String clave
        {
            get { return _clave; }

            set { _clave = value; }
        }

        private Boolean? _admin;
        public Boolean? admin
        {
            get { return _admin; }

            set { _admin = value; }
        }

        private Boolean? _activo;
        public Boolean? activo
        {
            get { return _activo; }

            set { _activo = value; }
        }

        private Byte[] _foto;

        public Byte[] Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        

        private String _idper;
        public String idper
        {
            get { return _idper; }

            set { _idper = value; }
        }

        //*** opt
        private String _posicion;
        public String posicion
        {
            get { return _posicion; }

            set { _posicion = value; }
        }

    }
}
