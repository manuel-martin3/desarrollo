using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_cm_ordendecompra
    {
        /*
           Atributos De Equivalencias
         */

        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private String _productid;
        public String productid
        {
            get { return _productid; }
            set { _productid = value; }
        }

        private String _grupoid;
        public String grupoid
        {
            get { return _grupoid; }
            set { _grupoid = value; }
        }

        private String _equiv_name;

        public String Equiv_name
        {
            get { return _equiv_name; }
            set { _equiv_name = value; }
        }

        private String _unmed1;
        public String Unmed1
        {
            get { return _unmed1; }
            set { _unmed1 = value; }
        }

        private String _unmed2;
        public String Unmed2
        {
            get { return _unmed2; }
            set { _unmed2 = value; }
        }


        private DateTime? _fechaini;
        public DateTime? fechaini
        {
            get { return _fechaini; }
            set { _fechaini = value; }
        }

        private DateTime? _fechafin;
        public DateTime? fechafin
        {
            get { return _fechafin; }
            set { _fechafin = value; }
        }


        private Decimal _equivalencia;
        public Decimal Equivalencia
        {
            get { return _equivalencia; }
            set { _equivalencia = value; }
        }


        private Int32 _cantidad;
        public Int32 cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }






        //----------------------------------------------

        private String _dominioid;
        public String dominioid
        {
            get { return _dominioid; }

            set { _dominioid = value; }
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

        

        private String _moduloiddes;
        public String moduloiddes
        {
            get { return _moduloiddes; }

            set { _moduloiddes = value; }
        }

        private String _localdes;
        public String localdes
        {
            get { return _localdes; }

            set { _localdes = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
        }

        private DateTime _fechdoc;
        public DateTime fechdoc
        {
            get { return _fechdoc; }

            set { _fechdoc = value; }
        }

        private String _almacaccionid;
        public String almacaccionid
        {
            get { return _almacaccionid; }

            set { _almacaccionid = value; }
        }

        private String _ctacteaccionid;
        public String ctacteaccionid
        {
            get { return _ctacteaccionid; }

            set { _ctacteaccionid = value; }
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

        private String _direc;
        public String direc
        {
            get { return _direc; }

            set { _direc = value; }
        }

        private String _tipdid;
        public String tipdid
        {
            get { return _tipdid; }

            set { _tipdid = value; }
        }

        private String _nmruc;
        public String nmruc
        {
            get { return _nmruc; }

            set { _nmruc = value; }
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

        private String _tipped;
        public String tipped
        {
            get { return _tipped; }

            set { _tipped = value; }
        }

        private String _serped;
        public String serped
        {
            get { return _serped; }

            set { _serped = value; }
        }

        private String _numped;
        public String numped
        {
            get { return _numped; }

            set { _numped = value; }
        }

        private String _compradorid;
        public String compradorid
        {
            get { return _compradorid; }

            set { _compradorid = value; }
        }

        private String _condpagoid;
        public String condpagoid
        {
            get { return _condpagoid; }

            set { _condpagoid = value; }
        }

        private String _ubige;
        public String ubige
        {
            get { return _ubige; }

            set { _ubige = value; }
        }

        private Decimal _bruto;
        public Decimal bruto
        {
            get { return _bruto; }

            set { _bruto = value; }
        }

        private Decimal _pdscto;
        public Decimal pdscto
        {
            get { return _pdscto; }

            set { _pdscto = value; }
        }

        private Decimal _idscto;
        public Decimal idscto
        {
            get { return _idscto; }

            set { _idscto = value; }
        }

        private Boolean _afectoigv;
        public Boolean afectoigv
        {
            get { return _afectoigv; }

            set { _afectoigv = value; }
        }

        private Decimal _pigv;
        public Decimal pigv
        {
            get { return _pigv; }

            set { _pigv = value; }
        }

        private String _incprec;
        public String incprec
        {
            get { return _incprec; }

            set { _incprec = value; }
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

        private Decimal _valventa;
        public Decimal valventa
        {
            get { return _valventa; }

            set { _valventa = value; }
        }

        private Decimal _totimpto;
        public Decimal totimpto
        {
            get { return _totimpto; }

            set { _totimpto = value; }
        }

        private Decimal _totimporte;
        public Decimal totimporte
        {
            get { return _totimporte; }

            set { _totimporte = value; }
        }

        private Decimal _valor_ocompra;
        public Decimal valor_ocompra
        {
            get { return _valor_ocompra; }

            set { _valor_ocompra = value; }
        }

        private Decimal _valor_guiado;
        public Decimal valor_guiado
        {
            get { return _valor_guiado; }

            set { _valor_guiado = value; }
        }

        private Decimal _valor_facturado;
        public Decimal valor_facturado
        {
            get { return _valor_facturado; }

            set { _valor_facturado = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }

            set { _glosa = value; }
        }

        private Decimal _totpzas;
        public Decimal totpzas
        {
            get { return _totpzas; }

            set { _totpzas = value; }
        }

        private DateTime _fechentrega;
        public DateTime fechentrega
        {
            get { return _fechentrega; }

            set { _fechentrega = value; }
        }

       

        private DateTime _fechpago;
        public DateTime fechpago
        {
            get { return _fechpago; }

            set { _fechpago = value; }
        }

        private DateTime _fechcancel;
        public DateTime fechcancel
        {
            get { return _fechcancel; }

            set { _fechcancel = value; }
        }

        private Decimal _items;
        public Decimal items
        {
            get { return _items; }

            set { _items = value; }
        }

        private Boolean _afecdetraccion;
        public Boolean afecdetraccion
        {
            get { return _afecdetraccion; }

            set { _afecdetraccion = value; }
        }

        private String _detraccionid;
        public String detraccionid
        {
            get { return _detraccionid; }

            set { _detraccionid = value; }
        }

        private Decimal _pdetraccion;
        public Decimal pdetraccion
        {
            get { return _pdetraccion; }

            set { _pdetraccion = value; }
        }

        private String _atencion;
        public String atencion
        {
            get { return _atencion; }

            set { _atencion = value; }
        }

        private String _puntollegada;
        public String puntollegada
        {
            get { return _puntollegada; }

            set { _puntollegada = value; }
        }

        private Boolean _visado;
        public Boolean visado
        {
            get { return _visado; }

            set { _visado = value; }
        }

        private String _usuarvisado;
        public String usuarvisado
        {
            get { return _usuarvisado; }

            set { _usuarvisado = value; }
        }

        private String _observacionvisado;
        public String observacionvisado
        {
            get { return _observacionvisado; }

            set { _observacionvisado = value; }
        }

        private DateTime _fechvisado;
        public DateTime fechvisado
        {
            get { return _fechvisado; }

            set { _fechvisado = value; }
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

        //** 

        private String _num_desde;
        public String num_desde
        {
            get { return _num_desde; }
            set { _num_desde = value; }
        }

        private String _num_hasta;
        public String num_hasta
        {
            get { return _num_hasta; }
            set { _num_hasta = value; }
        }


        //** OPT

        private Boolean _tipodocmanejaserie;
        public Boolean tipodocmanejaserie
        {
            get { return _tipodocmanejaserie; }

            set { _tipodocmanejaserie = value; }
        }       


        //*************************************************        
        public class Item
        {
            private String _itemsdet;
            public String itemsdet
            {
                get { return _itemsdet; }

                set { _itemsdet = value; }
            }

            private String _moduloiddes;
            public String moduloiddes
            {
                get { return _moduloiddes; }

                set { _moduloiddes = value; }
            }

            private String _localdes;
            public String localdes
            {
                get { return _localdes; }

                set { _localdes = value; }
            }

            private String _status;
            public String status
            {
                get { return _status; }

                set { _status = value; }
            }

            private String _filtro;
            public String filtro
            {
                get { return _filtro; }
                set { _filtro = value; }
            }


            private DateTime _fechdoc;
            public DateTime fechdoc
            {
                get { return _fechdoc; }

                set { _fechdoc = value; }
            }

            private String _almacaccionid;
            public String almacaccionid
            {
                get { return _almacaccionid; }

                set { _almacaccionid = value; }
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

            private String _productname;
            public String productname
            {
                get { return _productname; }

                set { _productname = value; }
            }

            private String _productid;
            public String productid
            {
                get { return _productid; }
                set { _productid = value; }
            }

            

            private Int32 _equivid;
            public Int32 equivid
            {
                get { return _equivid; }
                set { _equivid = value; }
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

            private DateTime _fechref;
            public DateTime fechref
            {
                get { return _fechref; }

                set { _fechref = value; }
            }

            private String _tipped;
            public String tipped
            {
                get { return _tipped; }

                set { _tipped = value; }
            }

            private String _serped;
            public String serped
            {
                get { return _serped; }

                set { _serped = value; }
            }

            private String _numped;
            public String numped
            {
                get { return _numped; }

                set { _numped = value; }
            }

            private Decimal _cantidad;
            public Decimal cantidad
            {
                get { return _cantidad; }

                set { _cantidad = value; }
            }

            private Decimal _cantidad_c;
            public Decimal cantidad_c
            {
                get { return _cantidad_c; }
                set { _cantidad_c = value; }
            }


            private Decimal _precunit_c;
            public Decimal precunit_c
            {
                get { return _precunit_c; }
                set { _precunit_c = value; }
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

            // cantidad
            private Decimal _cantidadcta_c;

            public Decimal Cantidadcta_c
            {
                get { return _cantidadcta_c; }
                set { _cantidadcta_c = value; }
            }

            private Decimal _precinit;
            public Decimal precinit
            {
                get { return _precinit; }

                set { _precinit = value; }
            }

            private Boolean _chkdcto;
            public Boolean chkdcto
            {
                get { return _chkdcto; }

                set { _chkdcto = value; }
            }

            private Decimal _pdscto;
            public Decimal pdscto
            {
                get { return _pdscto; }

                set { _pdscto = value; }
            }

            private Decimal _idscto;
            public Decimal idscto
            {
                get { return _idscto; }

                set { _idscto = value; }
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

            private String _incprec;
            public String incprec
            {
                get { return _incprec; }

                set { _incprec = value; }
            }

            private Decimal _totimpto;
            public Decimal totimpto
            {
                get { return _totimpto; }

                set { _totimpto = value; }
            }

            private Decimal _pigv;
            public Decimal pigv
            {
                get { return _pigv; }

                set { _pigv = value; }
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

            private DateTime _fechentrega;
            public DateTime fechentrega
            {
                get { return _fechentrega; }

                set { _fechentrega = value; }
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

            private Decimal _precioanterior;
            public Decimal precioanterior
            {
                get { return _precioanterior; }

                set { _precioanterior = value; }
            }

            private String _usuar;
            public String usuar
            {
                get { return _usuar; }

                set { _usuar = value; }
            }            
        }

        private List<Item> _ListaItems;
        public List<Item> ListaItems
        {
            get { return _ListaItems; }
            set { _ListaItems = value; }
        }

        public string GetItemXML()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (Item obj in _ListaItems)
            {
                objNode = objXMLDoc.CreateElement("Item");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("itemsdet"); attrib1.Value = obj.itemsdet;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("moduloiddes"); attrib2.Value = obj.moduloiddes;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("localdes"); attrib3.Value = obj.localdes;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("status"); attrib4.Value = obj.status;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib5.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib6.Value = obj.almacaccionid;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib7.Value = obj.ctacte;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("ctactename"); attrib8.Value = obj.ctactename;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("productid"); attrib9.Value = obj.productid;
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("productname"); attrib10.Value = obj.productname;
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("itemref"); attrib11.Value = obj.itemref;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("tipref"); attrib12.Value = obj.tipref;
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("serref"); attrib13.Value = obj.serref;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("numref"); attrib14.Value = obj.numref;
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("fechref"); attrib15.Value = fecha(obj.fechref).ToShortDateString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("tipped"); attrib16.Value = obj.tipped;
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("serped"); attrib17.Value = obj.serped;
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("numped"); attrib18.Value = obj.numped;
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib19.Value = obj.cantidad.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("valor"); attrib20.Value = obj.valor.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("importe"); attrib21.Value = obj.importe.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("cantidadcta"); attrib22.Value = obj.cantidadcta.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("cantidadfac"); attrib23.Value = obj.cantidadfac.ToString();
                XmlAttribute attrib24 = objNode.OwnerDocument.CreateAttribute("precinit"); attrib24.Value = obj.precinit.ToString();
                XmlAttribute attrib25 = objNode.OwnerDocument.CreateAttribute("chkdcto"); attrib25.Value = obj.chkdcto.ToString();
                XmlAttribute attrib26 = objNode.OwnerDocument.CreateAttribute("pdscto"); attrib26.Value = obj.pdscto.ToString();
                XmlAttribute attrib27 = objNode.OwnerDocument.CreateAttribute("idscto"); attrib27.Value = obj.idscto.ToString();
                XmlAttribute attrib28 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib28.Value = obj.precunit.ToString();
                XmlAttribute attrib29 = objNode.OwnerDocument.CreateAttribute("importfac"); attrib29.Value = obj.importfac.ToString();
                XmlAttribute attrib30 = objNode.OwnerDocument.CreateAttribute("incprec"); attrib30.Value = obj.incprec;
                XmlAttribute attrib31 = objNode.OwnerDocument.CreateAttribute("totimpto"); attrib31.Value = obj.totimpto.ToString();
                XmlAttribute attrib32 = objNode.OwnerDocument.CreateAttribute("pigv"); attrib32.Value = obj.pigv.ToString();
                XmlAttribute attrib33 = objNode.OwnerDocument.CreateAttribute("moneda"); attrib33.Value = obj.moneda;
                XmlAttribute attrib34 = objNode.OwnerDocument.CreateAttribute("tcamb"); attrib34.Value = obj.tcamb.ToString();
                XmlAttribute attrib35 = objNode.OwnerDocument.CreateAttribute("compradorid"); attrib35.Value = obj.compradorid;
                XmlAttribute attrib36 = objNode.OwnerDocument.CreateAttribute("glosa"); attrib36.Value = obj.glosa;
                XmlAttribute attrib37 = objNode.OwnerDocument.CreateAttribute("perianio"); attrib37.Value = obj.perianio;
                XmlAttribute attrib38 = objNode.OwnerDocument.CreateAttribute("perimes"); attrib38.Value = obj.perimes;
                XmlAttribute attrib39 = objNode.OwnerDocument.CreateAttribute("fechentrega"); attrib39.Value = fecha(obj.fechentrega).ToShortDateString();
                XmlAttribute attrib40 = objNode.OwnerDocument.CreateAttribute("aniosemana"); attrib40.Value = obj.aniosemana;
                XmlAttribute attrib41 = objNode.OwnerDocument.CreateAttribute("aniosemanaconfirm"); attrib41.Value = obj.aniosemanaconfirm;
                XmlAttribute attrib42 = objNode.OwnerDocument.CreateAttribute("precioanterior"); attrib42.Value = obj.precioanterior.ToString();
                XmlAttribute attrib43 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib43.Value = obj.usuar;
                XmlAttribute attrib44 = objNode.OwnerDocument.CreateAttribute("equiv_id"); attrib44.Value = obj.equivid.ToString();
                XmlAttribute attrib45 = objNode.OwnerDocument.CreateAttribute("cantidad_c"); attrib45.Value = obj.cantidad_c.ToString();
                XmlAttribute attrib46 = objNode.OwnerDocument.CreateAttribute("precunit_c"); attrib46.Value = obj.precunit_c.ToString();

                XmlAttribute attrib47 = objNode.OwnerDocument.CreateAttribute("cantidadcta_c"); attrib47.Value = obj.Cantidadcta_c.ToString();

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);
                objNode.Attributes.Append(attrib5);
                objNode.Attributes.Append(attrib6);
                objNode.Attributes.Append(attrib7);
                objNode.Attributes.Append(attrib8);
                objNode.Attributes.Append(attrib9);
                objNode.Attributes.Append(attrib10);
                objNode.Attributes.Append(attrib11);
                objNode.Attributes.Append(attrib12);
                objNode.Attributes.Append(attrib13);
                objNode.Attributes.Append(attrib14);
                objNode.Attributes.Append(attrib15);
                objNode.Attributes.Append(attrib16);
                objNode.Attributes.Append(attrib17);
                objNode.Attributes.Append(attrib18);
                objNode.Attributes.Append(attrib19);
                objNode.Attributes.Append(attrib20);
                objNode.Attributes.Append(attrib21);
                objNode.Attributes.Append(attrib22);
                objNode.Attributes.Append(attrib23);
                objNode.Attributes.Append(attrib24);
                objNode.Attributes.Append(attrib25);
                objNode.Attributes.Append(attrib26);
                objNode.Attributes.Append(attrib27);
                objNode.Attributes.Append(attrib28);
                objNode.Attributes.Append(attrib29);
                objNode.Attributes.Append(attrib30);
                objNode.Attributes.Append(attrib31);
                objNode.Attributes.Append(attrib32);
                objNode.Attributes.Append(attrib33);
                objNode.Attributes.Append(attrib34);
                objNode.Attributes.Append(attrib35);
                objNode.Attributes.Append(attrib36);
                objNode.Attributes.Append(attrib37);
                objNode.Attributes.Append(attrib38);
                objNode.Attributes.Append(attrib39);
                objNode.Attributes.Append(attrib40);
                objNode.Attributes.Append(attrib41);
                objNode.Attributes.Append(attrib42);
                objNode.Attributes.Append(attrib43);
                objNode.Attributes.Append(attrib44);
                objNode.Attributes.Append(attrib45);
                objNode.Attributes.Append(attrib46);
                objNode.Attributes.Append(attrib47);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }

        public string GetItemXML2()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("Items");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (Item obj in _ListaItems)
            {
                objNode = objXMLDoc.CreateElement("Item");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("itemsdet"); attrib1.Value = obj.itemsdet;    

                objNode.Attributes.Append(attrib1);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }

        #region *** validar fecha en formato correcto
        public DateTime fecha(DateTime pfecha)
        {
            //string dia = pfecha.Day.ToString();
            //string mes = pfecha.Month.ToString();
            //string anio = pfecha.Year.ToString();
            //string fecha = anio + "-" + mes + "-" + dia;
            DateTime lfech;
            //DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            //IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            if (pfecha != null)
            {
                if (pfecha != DateTime.Parse("01/01/0001 12:00:00 a.m.") || pfecha != DateTime.Parse("01/01/0001 00:00:00"))
                {
                    lfech = pfecha;
                }
                else
                {
                    lfech = DateTime.Parse("01/01/1900");
                }
            }
            else
            {
                lfech = DateTime.Parse("01/01/1900");
            }

            return lfech;
        }
        #endregion

        public DateTime fechaulting { get; set; }
    }
}
