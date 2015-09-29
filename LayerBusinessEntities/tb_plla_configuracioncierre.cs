using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace LayerBusinessEntities
{
    public class tb_plla_configuracioncierre
    {
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
        }

        private String _perimes;
        public String perimes
        {
            get { return _perimes; }
            set { _perimes = value; }
        }

        private String _tipoafectaciones;
        public String tipoafectaciones
        {
            get { return _tipoafectaciones; }
            set { _tipoafectaciones = value; }
        }

        private String _tipoplla;
        public String tipoplla
        {
            get { return _tipoplla; }
            set { _tipoplla = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }
            set { _usuar = value; }
        }

        private String _pcacceso;
        public String pcacceso
        {
            get { return _pcacceso; }
            set { _pcacceso = value; }
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

        private Boolean? _cerrado;
        public Boolean? cerrado
        {
            get { return _cerrado; }
            set { _cerrado = value; }
        }

        private String _descriplike1;
        public String descriplike1
        {
            get { return _descriplike1; }
            set { _descriplike1 = value; }
        }

        private String _descriplike2;
        public String descriplike2
        {
            get { return _descriplike2; }
            set { _descriplike2 = value; }
        }

        private String _descriplike3;
        public String descriplike3
        {
            get { return _descriplike3; }
            set { _descriplike3 = value; }
        }
    }
}
