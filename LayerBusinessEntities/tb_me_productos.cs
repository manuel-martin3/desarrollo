using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace LayerBusinessEntities
{
    public class tb_me_productos
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

        private Decimal _tcamb;
        public Decimal tcamb
        {
            get { return _tcamb; }
            set { _tcamb = value; }
        }

        private Int32 _listaprecid;
        public Int32 listaprecid
        {
            get { return _listaprecid; }
            set { _listaprecid = value; }
        }

        private String _docname;
        public String docname
        {
            get { return _docname; }
            set { _docname = value; }
        }

        private String _cencosid;
        public String cencosid
        {
            get { return _cencosid; }
            set { _cencosid = value; }
        }

        private String _codigo;
        public String codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private Byte[] _foto;
        public Byte[] Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        //private String _foto;
        //public String foto
        //{
        //    get { return _foto; }
        //    set { _foto = value; }
        //}


        private String _nserie;
        public String nserie
        {
            get { return _nserie; }
            set { _nserie = value; }
        }

        private String _procedenciaid;
        public String procedenciaid
        {
            get { return _procedenciaid; }
            set { _procedenciaid = value; }
        }

        private String _productid;
        public String productid
        {
            get { return _productid; }

            set { _productid = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
        }

        private String _productname;
        public String productname
        {
            get { return _productname; }

            set { _productname = value; }
        }

        private String _unmed;
        public String unmed
        {
            get { return _unmed; }

            set { _unmed = value; }
        }

        private Decimal _peso;
        public Decimal peso
        {
            get { return _peso; }

            set { _peso = value; }
        }

        private String _unmedpeso;
        public String unmedpeso
        {
            get { return _unmedpeso; }

            set { _unmedpeso = value; }
        }

        private String _unmedenvase;
        public String unmedenvase
        {
            get { return _unmedenvase; }

            set { _unmedenvase = value; }
        }

        private Decimal _unidenvase;
        public Decimal unidenvase
        {
            get { return _unidenvase; }
            set { _unidenvase = value; }
        }

        private String _tipodoc;
        public String tipodoc
        {
            get { return _tipodoc; }
            set { _tipodoc = value; }
        }

        private Decimal _precioenvase;
        public Decimal precioenvase
        {
            get { return _precioenvase; }

            set { _precioenvase = value; }
        }

        private String _etiquetaname;
        public String etiquetaname
        {
            get { return _etiquetaname; }

            set { _etiquetaname = value; }
        }

        private String _colorid;
        public String colorid
        {
            get { return _colorid; }

            set { _colorid = value; }
        }

        private String _rollo;

        public String rollo
        {
            get { return _rollo; }
            set { _rollo = value; }
        }

        private String _colorname;
        public String colorname
        {
            get { return _colorname; }

            set { _colorname = value; }
        }

        private String _marcaid;
        public String marcaid
        {
            get { return _marcaid; }

            set { _marcaid = value; }
        }

        private String _coleccionid;
        public String coleccionid
        {
            get { return _coleccionid; }

            set { _coleccionid = value; }
        }

        private String _temporadaid;
        public String temporadaid
        {
            get { return _temporadaid; }

            set { _temporadaid = value; }
        }

        private String _categoriaid;
        public String categoriaid
        {
            get { return _categoriaid; }

            set { _categoriaid = value; }
        }

        private String _generoid;
        public String generoid
        {
            get { return _generoid; }

            set { _generoid = value; }
        }

        private String _tejidoid;
        public String tejidoid
        {
            get { return _tejidoid; }

            set { _tejidoid = value; }
        }

        private String _telaid;
        public String telaid
        {
            get { return _telaid; }

            set { _telaid = value; }
        }

        private String _tallaid;
        public String tallaid
        {
            get { return _tallaid; }

            set { _tallaid = value; }
        }

        private String _coltalla;
        public String coltalla
        {
            get { return _coltalla; }

            set { _coltalla = value; }
        }

        private String _coltallaname;
        public String coltallaname
        {
            get { return _coltallaname; }

            set { _coltallaname = value; }
        }

        private String _moneda;
        public String moneda
        {
            get { return _moneda; }

            set { _moneda = value; }
        }

        private Decimal _precventa;
        public Decimal precventa
        {
            get { return _precventa; }

            set { _precventa = value; }
        }

        private Decimal _precvent2;
        public Decimal precvent2
        {
            get { return _precvent2; }

            set { _precvent2 = value; }
        }

        private Decimal _precvent3;
        public Decimal precvent3
        {
            get { return _precvent3; }

            set { _precvent3 = value; }
        }

        private Decimal _precvent4;
        public Decimal precvent4
        {
            get { return _precvent4; }

            set { _precvent4 = value; }
        }

        private Decimal _precvent5;
        public Decimal precvent5
        {
            get { return _precvent5; }

            set { _precvent5 = value; }
        }

        private Decimal _precventant;
        public Decimal precventant
        {
            get { return _precventant; }

            set { _precventant = value; }
        }

        private String _conce;
        public String conce
        {
            get { return _conce; }

            set { _conce = value; }
        }

        private String _diluc;
        public String diluc
        {
            get { return _diluc; }

            set { _diluc = value; }
        }

        private String _ctacte;
        public String ctacte
        {
            get { return _ctacte; }

            set { _ctacte = value; }
        }

        private String _compo;
        public String compo
        {
            get { return _compo; }

            set { _compo = value; }
        }

        private String _titulo;
        public String titulo
        {
            get { return _titulo; }

            set { _titulo = value; }
        }        

        private String _productidold;
        public String productidold
        {
            get { return _productidold; }

            set { _productidold = value; }
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

        private String _item;
        public String item
        {
            get { return _item; }

            set { _item = value; }
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

        private DateTime? _fepialmac;
        public DateTime? fepialmac
        {
            get { return _fepialmac; }

            set { _fepialmac = value; }
        }

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private DateTime? _feuialmac;
        public DateTime? feuialmac
        {
            get { return _feuialmac; }

            set { _feuialmac = value; }
        }

        //opt
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

        private String _posicion;
        public String posicion
        {
            get { return _posicion; }

            set { _posicion = value; }
        }
    }
}
