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
    public class tb_plla_fichatrabajadoresrubros
    {
        private String _fichaid;
        public String fichaid
        {
            get { return _fichaid; }
            set { _fichaid = value; }
        }

        private String _ncontrato;
        public String ncontrato
        {
            get { return _ncontrato; }
            set { _ncontrato = value; }
        }

        private String _rubroid;
        public String rubroid
        {
            get { return _rubroid; }
            set { _rubroid = value; }
        }

        private Decimal _importediario;
        public Decimal importediario
        {
            get { return _importediario; }
            set { _importediario = value; }
        }

        private Decimal _importemensual;
        public Decimal importemensual
        {
            get { return _importemensual; }
            set { _importemensual = value; }
        }

        private String _fijo;
        public String fijo
        {
            get { return _fijo; }
            set { _fijo = value; }
        }

        private Boolean? _consimporte;
        public Boolean? consimporte
        {
            get { return _consimporte; }
            set { _consimporte = value; }
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
    }
}
