using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics; 

namespace LayerBusinessEntities
{
    public class tb_co_Comprasdet
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

        private DateTime? _fechdoc;
        public DateTime? fechdoc
        {
            get { return _fechdoc; }

            set { _fechdoc = value; }
        }

        private String _nmruc;
        public String nmruc
        {
            get { return _nmruc; }

            set { _nmruc = value; }
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

        private String _almacaccionid;
        public String almacaccionid
        {
            get { return _almacaccionid; }

            set { _almacaccionid = value; }
        }

        private String _itemref;
        public String itemref
        {
            get { return _itemref; }

            set { _itemref = value; }
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

        private DateTime? _fechref;
        public DateTime? fechref
        {
            get { return _fechref; }

            set { _fechref = value; }
        }

        private String _tipOp;
        public String tipOp
        {
            get { return _tipOp; }

            set { _tipOp = value; }
        }

        private String _serOp;
        public String serOp
        {
            get { return _serOp; }

            set { _serOp = value; }
        }

        private String _numOp;
        public String numOp
        {
            get { return _numOp; }

            set { _numOp = value; }
        }

        private Decimal _cantidad;
        public Decimal cantidad
        {
            get { return _cantidad; }

            set { _cantidad = value; }
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

        private Decimal _precunit;
        public Decimal precunit
        {
            get { return _precunit; }

            set { _precunit = value; }
        }

        private Decimal _dscto3;
        public Decimal dscto3
        {
            get { return _dscto3; }

            set { _dscto3 = value; }
        }

        private Decimal _valorcompra1;
        public Decimal valorcompra1
        {
            get { return _valorcompra1; }

            set { _valorcompra1 = value; }
        }

        private Boolean? _incprec;
        public Boolean? incprec
        {
            get { return _incprec; }

            set { _incprec = value; }
        }

        private Decimal _igv1;
        public Decimal igv1
        {
            get { return _igv1; }

            set { _igv1 = value; }
        }

        private Decimal _igv;
        public Decimal igv
        {
            get { return _igv; }

            set { _igv = value; }
        }

        private Decimal _preciocompra1;
        public Decimal preciocompra1
        {
            get { return _preciocompra1; }

            set { _preciocompra1 = value; }
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

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }

            set { _cencosid = value; }
        }

        private String _compradorid;
        public String compradorid
        {
            get { return _compradorid; }

            set { _compradorid = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
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

        private String _rubroid;
        public String rubroid
        {
            get { return _rubroid; }

            set { _rubroid = value; }
        }

        private String _unidmedidaid;
        public String unidmedidaid
        {
            get { return _unidmedidaid; }

            set { _unidmedidaid = value; }
        }

        private Decimal _merma;
        public Decimal merma
        {
            get { return _merma; }

            set { _merma = value; }
        }

        private String _tipimptoid;
        public String tipimptoid
        {
            get { return _tipimptoid; }

            set { _tipimptoid = value; }
        }

        private String _pedido;
        public String pedido
        {
            get { return _pedido; }

            set { _pedido = value; }
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
        
        private String _ordencs;
        public String ordencs
        {
            get { return _ordencs; }

            set { _ordencs = value; }
        }

        private Decimal _preciounitario2;
        public Decimal preciounitario2
        {
            get { return _preciounitario2; }

            set { _preciounitario2 = value; }
        }
     
        private Decimal _valorcompra2;
        public Decimal valorcompra2
        {
            get { return _valorcompra2; }

            set { _valorcompra2 = value; }
        }

        private Decimal _igv2;
        public Decimal igv2
        {
            get { return _igv2; }

            set { _igv2 = value; }
        }

        private Decimal _preciocompra2;
        public Decimal preciocompra2
        {
            get { return _preciocompra2; }

            set { _preciocompra2 = value; }
        }

        private String _regalmacen;
        public String regalmacen
        {
            get { return _regalmacen; }

            set { _regalmacen = value; }
        }

        private Decimal _valorcompra;
        public Decimal valorcompra
        {
            get { return _valorcompra; }

            set { _valorcompra = value; }
        }

        private Decimal _igvo;
        public Decimal igvo
        {
            get { return _igvo; }

            set { _igvo = value; }
        }

        private Decimal _preciocompra;
        public Decimal preciocompra
        {
            get { return _preciocompra; }

            set { _preciocompra = value; }
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
    }
}
