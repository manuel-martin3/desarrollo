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
    public class tb_plla_fichatrabajadorescontratos
    {
        private String _fichaid;
        public String fichaid
        {
            get { return _fichaid; }
            set { _fichaid = value; }
        }

        private String _empresaid;
        public String empresaid
        {
            get { return _empresaid; }
            set { _empresaid = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }
            set { _cencosid = value; }
        }

        private String _ncontrato;
        public String ncontrato
        {
            get { return _ncontrato; }
            set { _ncontrato = value; }
        }

        private String _ncomiezo;
        public String ncomiezo
        {
            get { return _ncomiezo; }
            set { _ncomiezo = value; }
        }

        private DateTime? _vlfechaini;
        public DateTime? vlfechaini
        {
            get { return _vlfechaini; }
            set { _vlfechaini = value; }
        }

        private DateTime? _vlfechafin;
        public DateTime? vlfechafin
        {
            get { return _vlfechafin; }
            set { _vlfechafin = value; }
        }

        private DateTime? _dcfechaini;
        public DateTime? dcfechaini
        {
            get { return _dcfechaini; }
            set { _dcfechaini = value; }
        }

        private DateTime? _dcfechafin;
        public DateTime? dcfechafin
        {
            get { return _dcfechafin; }
            set { _dcfechafin = value; }
        }

        private Decimal _horarioentrada;
        public Decimal horarioentrada
        {
            get { return _horarioentrada; }
            set { _horarioentrada = value; }
        }
      
        private Decimal _minutosentrada;
        public Decimal minutosentrada
        {
            get { return _minutosentrada; }
            set { _minutosentrada = value; }
        }

        private Decimal _horariosalida;
        public Decimal horariosalida
        {
            get { return _horariosalida; }
            set { _horariosalida = value; }
        }

        private Decimal _minutossalida;
        public Decimal minutossalida
        {
            get { return _minutossalida; }
            set { _minutossalida = value; }
        }

        private String _tipoplla;
        public String tipoplla
        {
            get { return _tipoplla; }
            set { _tipoplla = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }

        private Decimal _remuneracion;
        public Decimal remuneracion
        {
            get { return _remuneracion; }
            set { _remuneracion = value; }
        }

        private String _estado;
        public String estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private String _observcese;
        public String observcese
        {
            get { return _observcese; }
            set { _observcese = value; }
        }

        private String _nuevo;
        public String nuevo
        {
            get { return _nuevo; }
            set { _nuevo = value; }
        }

        private Boolean? _vigencia;
        public Boolean? vigencia
        {
            get { return _vigencia; }
            set { _vigencia = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }

        private String _tipcontratoid;
        public String tipcontratoid
        {
            get { return _tipcontratoid; }
            set { _tipcontratoid = value; }
        }

        private String _motfinperiodid;
        public String motfinperiodid
        {
            get { return _motfinperiodid; }
            set { _motfinperiodid = value; }
        }

        private String _tipmodalformid;
        public String tipmodalformid
        {
            get { return _tipmodalformid; }
            set { _tipmodalformid = value; }
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
