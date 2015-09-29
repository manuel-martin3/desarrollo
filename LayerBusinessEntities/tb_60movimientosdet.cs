using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_60movimientosdet
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

        private String _codigo;
        public String codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private Int32 _modcalculo;
        public Int32 modcalculo
        {
            get { return _modcalculo; }
            set { _modcalculo = value; }
        }

        private String _ubicacion;

        public String Ubicacion
        {
            get { return _ubicacion; }
            set { _ubicacion = value; }
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

        private String _diarioid;
        public String diarioid
        {
            get { return _diarioid; }

            set { _diarioid = value; }
        }

        private String _asiento;
        public String asiento
        {
            get { return _asiento; }

            set { _asiento = value; }
        }

        private String _asientoitems;
        public String asientoitems
        {
            get { return _asientoitems; }

            set { _asientoitems = value; }
        }

        private String _almacaccionid;
        public String almacaccionid
        {
            get { return _almacaccionid; }

            set { _almacaccionid = value; }
        }

        private String _tipoperacionid;
        public String tipoperacionid
        {
            get { return _tipoperacionid; }

            set { _tipoperacionid = value; }
        }

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

        private String _ctacteaccionid;
        public String ctacteaccionid
        {
            get { return _ctacteaccionid; }

            set { _ctacteaccionid = value; }
        }

        private String _direcnume;
        public String direcnume
        {
            get { return _direcnume; }

            set { _direcnume = value; }
        }

        private String _direcname;
        public String direcname
        {
            get { return _direcname; }

            set { _direcname = value; }
        }

        private String _productid;
        public String productid
        {
            get { return _productid; }

            set { _productid = value; }
        }

        private String _productname;
        public String productname
        {
            get { return _productname; }

            set { _productname = value; }
        }

        private String _rollo;
        public String rollo
        {
            get { return _rollo; }

            set { _rollo = value; }
        }

        private DateTime _fechdoc;
        public DateTime fechdoc
        {
            get { return _fechdoc; }

            set { _fechdoc = value; }
        }

        private String _itemref;
        public String itemref
        {
            get { return _itemref; }

            set { _itemref = value; }
        }

        private Decimal _cantidad;
        public Decimal cantidad
        {
            get { return _cantidad; }

            set { _cantidad = value; }
        }

        private Decimal _valor;
        public Decimal valor
        {
            get { return _valor; }

            set { _valor = value; }
        }

        private Decimal _importe;
        public Decimal importe
        {
            get { return _importe; }

            set { _importe = value; }
        }

        private Decimal _cantidadcta;
        public Decimal cantidadcta
        {
            get { return _cantidadcta; }

            set { _cantidadcta = value; }
        }

        private Decimal _cantidadfac;
        public Decimal cantidadfac
        {
            get { return _cantidadfac; }

            set { _cantidadfac = value; }
        }

        private Decimal _precioanterior;
        public Decimal precioanterior
        {
            get { return _precioanterior; }

            set { _precioanterior = value; }
        }

        private Decimal _precunit;
        public Decimal precunit
        {
            get { return _precunit; }

            set { _precunit = value; }
        }

        private Decimal _importfac;
        public Decimal importfac
        {
            get { return _importfac; }

            set { _importfac = value; }
        }

        private Decimal _dscto1;
        public Decimal dscto1
        {
            get { return _dscto1; }

            set { _dscto1 = value; }
        }

        private Decimal _dscto2;
        public Decimal dscto2
        {
            get { return _dscto2; }

            set { _dscto2 = value; }
        }

        private Decimal _dscto3;
        public Decimal dscto3
        {
            get { return _dscto3; }

            set { _dscto3 = value; }
        }

        private String _tipref;
        public String tipref
        {
            get { return _tipref; }

            set { _tipref = value; }
        }

        private String _serref;
        public String serref
        {
            get { return _serref; }

            set { _serref = value; }
        }

        private String _numref;
        public String numref
        {
            get { return _numref; }

            set { _numref = value; }
        }

        private DateTime _fechref;
        public DateTime fechref
        {
            get { return _fechref; }

            set { _fechref = value; }
        }

        private String _tipoperef;
        public String tipoperef
        {
            get { return _tipoperef; }

            set { _tipoperef = value; }
        }

        private String _tip_op;
        public String tip_op
        {
            get { return _tip_op; }

            set { _tip_op = value; }
        }

        private String _ser_op;
        public String ser_op
        {
            get { return _ser_op; }

            set { _ser_op = value; }
        }

        private String _num_op;
        public String num_op
        {
            get { return _num_op; }

            set { _num_op = value; }
        }

        private String _tipfac;
        public String tipfac
        {
            get { return _tipfac; }

            set { _tipfac = value; }
        }

        private String _serfac;
        public String serfac
        {
            get { return _serfac; }

            set { _serfac = value; }
        }

        private String _numfac;
        public String numfac
        {
            get { return _numfac; }

            set { _numfac = value; }
        }

        private DateTime _fechfac;
        public DateTime fechfac
        {
            get { return _fechfac; }

            set { _fechfac = value; }
        }

        private String _tipguia;
        public String tipguia
        {
            get { return _tipguia; }

            set { _tipguia = value; }
        }

        private String _serguia;
        public String serguia
        {
            get { return _serguia; }

            set { _serguia = value; }
        }

        private String _numguia;
        public String numguia
        {
            get { return _numguia; }

            set { _numguia = value; }
        }

        private DateTime _fechguia;
        public DateTime fechguia
        {
            get { return _fechguia; }

            set { _fechguia = value; }
        }

        private String _tipnotac;
        public String tipnotac
        {
            get { return _tipnotac; }

            set { _tipnotac = value; }
        }

        private String _sernotac;
        public String sernotac
        {
            get { return _sernotac; }

            set { _sernotac = value; }
        }

        private String _numnotac;
        public String numnotac
        {
            get { return _numnotac; }

            set { _numnotac = value; }
        }

        private DateTime _fechnotac;
        public DateTime fechnotac
        {
            get { return _fechnotac; }

            set { _fechnotac = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }

            set { _cencosid = value; }
        }

        private String _vendorid;
        public String vendorid
        {
            get { return _vendorid; }

            set { _vendorid = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }

            set { _moneda = value; }
        }

        private Decimal _tcamb;
        public Decimal tcamb
        {
            get { return _tcamb; }

            set { _tcamb = value; }
        }

        private String _tiptransac;
        public String tiptransac
        {
            get { return _tiptransac; }

            set { _tiptransac = value; }
        }

        private String _motivotrasladoid;
        public String motivotrasladoid
        {
            get { return _motivotrasladoid; }

            set { _motivotrasladoid = value; }
        }

        private String _mottrasladointid;
        public String mottrasladointid
        {
            get { return _mottrasladointid; }

            set { _mottrasladointid = value; }
        }

        private String _statcostopromed;
        public String statcostopromed
        {
            get { return _statcostopromed; }

            set { _statcostopromed = value; }
        }

        private String _incprec;
        public String incprec
        {
            get { return _incprec; }

            set { _incprec = value; }
        }

        private Decimal _igv;
        public Decimal igv
        {
            get { return _igv; }

            set { _igv = value; }
        }

        private Decimal _totimpto;
        public Decimal totimpto
        {
            get { return _totimpto; }

            set { _totimpto = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private String _statdigitadoprec;
        public String statdigitadoprec
        {
            get { return _statdigitadoprec; }

            set { _statdigitadoprec = value; }
        }

        private String _aniosemana;
        public String aniosemana
        {
            get { return _aniosemana; }

            set { _aniosemana = value; }
        }

        private String _aniosemanaconfirm;
        public String aniosemanaconfirm
        {
            get { return _aniosemanaconfirm; }

            set { _aniosemanaconfirm = value; }
        }

        private String _codctadebe;
        public String codctadebe
        {
            get { return _codctadebe; }

            set { _codctadebe = value; }
        }

        private String _codctahaber;
        public String codctahaber
        {
            get { return _codctahaber; }

            set { _codctahaber = value; }
        }

        private DateTime _fechentrega;
        public DateTime fechentrega
        {
            get { return _fechentrega; }

            set { _fechentrega = value; }
        }

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

        //*opt
        private DateTime _fechini;
        public DateTime fechini
        {
            get { return _fechini; }

            set { _fechini = value; }
        }

        private DateTime _fechfin;
        public DateTime fechfin
        {
            get { return _fechfin; }

            set { _fechfin = value; }
        }

        private String _tipmov;
        public String tipmov
        {
            get { return _tipmov; }

            set { _tipmov = value; }
        }

        private String _realpend;
        public String realpend
        {
            get { return _realpend; }

            set { _realpend = value; }
        }

        private String _perianioini;
        public String perianioini
        {
            get { return _perianioini; }

            set { _perianioini = value; }
        }

        private String _perimesini;
        public String perimesini
        {
            get { return _perimesini; }

            set { _perimesini = value; }
        }

        private String _perianiofin;
        public String perianiofin
        {
            get { return _perianiofin; }

            set { _perianiofin = value; }
        }

        private String _perimesfin;
        public String perimesfin
        {
            get { return _perimesfin; }

            set { _perimesfin = value; }
        }

        private String _lineaid;
        public String lineaid
        {
            get { return _lineaid; }

            set { _lineaid = value; }
        }

        private String _grupoid;
        public String grupoid
        {
            get { return _grupoid; }

            set { _grupoid = value; }
        }

        private String _subgrupoid;
        public String subgrupoid
        {
            get { return _subgrupoid; }

            set { _subgrupoid = value; }
        }

        private String _productidini;
        public String productidini
        {
            get { return _productidini; }

            set { _productidini = value; }
        }

        private String _productidfin;
        public String productidfin
        {
            get { return _productidfin; }

            set { _productidfin = value; }
        }

        private DateTime _fechdocini;
        public DateTime fechdocini
        {
            get { return _fechdocini; }

            set { _fechdocini = value; }
        }

        private DateTime _fechdocfin;
        public DateTime fechdocfin
        {
            get { return _fechdocfin; }

            set { _fechdocfin = value; }
        }

        private String _stockmayorquecero;
        public String stockmayorquecero
        {
            get { return _stockmayorquecero; }

            set { _stockmayorquecero = value; }
        }

        private String _accion;
        public String accion
        {
            get { return _accion; }

            set { _accion = value; }
        }

        private String _ser_opi;
        public String ser_opi
        {
            get { return _ser_opi; }

            set { _ser_opi = value; }
        }

        private String _num_opi;
        public String num_opi
        {
            get { return _num_opi; }

            set { _num_opi = value; }
        }

        private String _ser_opf;
        public String ser_opf
        {
            get { return _ser_opf; }

            set { _ser_opf = value; }
        }

        private String _num_opf;
        public String num_opf
        {
            get { return _num_opf; }

            set { _num_opf = value; }
        }

        private String _colorid;
        public String colorid
        {
            get { return _colorid; }

            set { _colorid = value; }
        }

        private String _tipo;
        public String tipo
        {
            get { return _tipo; }

            set { _tipo = value; }
        }
    }
}
