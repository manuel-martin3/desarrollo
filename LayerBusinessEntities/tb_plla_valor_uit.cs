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
    public class tb_plla_valor_uit
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

        private Decimal _valoruit;
        public Decimal valoruit
        {
            get { return _valoruit; }
            set { _valoruit = value; }
        }

        private Decimal _cantidad;
        public Decimal cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private Decimal _porcent;
        public Decimal porcent
        {
            get { return _porcent; }
            set { _porcent = value; }
        }

        private Decimal _mes_cal;
        public Decimal mes_cal
        {
            get { return _mes_cal; }
            set { _mes_cal = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

        private Decimal _sdomin;
        public Decimal sdomin
        {
            get { return _sdomin; }
            set { _sdomin = value; }
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
