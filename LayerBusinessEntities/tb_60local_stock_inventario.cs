using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_60local_stock_inventario
    {

        #region tb_60local_stock_inventario


        public bool dif { get; set; }

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

        private String _lineaid;
        public String lineaid
        {
            get { return _lineaid; }

            set { _lineaid = value; }
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

        private Decimal _stocklibros;
        public Decimal stocklibros
        {
            get { return _stocklibros; }

            set { _stocklibros = value; }
        }

        private Decimal _stockfisico;
        public Decimal stockfisico
        {
            get { return _stockfisico; }

            set { _stockfisico = value; }
        }

        private Decimal _diferencia;
        public Decimal diferencia
        {
            get { return _diferencia; }

            set { _diferencia = value; }
        }

        private Decimal _costopromlibros;
        public Decimal costopromlibros
        {
            get { return _costopromlibros; }

            set { _costopromlibros = value; }
        }

        private Decimal _costopromfisico;
        public Decimal costopromfisico
        {
            get { return _costopromfisico; }

            set { _costopromfisico = value; }
        }

        private String _codigoubic;
        public String codigoubic
        {
            get { return _codigoubic; }

            set { _codigoubic = value; }
        }

        private DateTime? _fechdoc;
        public DateTime? fechdoc
        {
            get { return _fechdoc; }

            set { _fechdoc = value; }
        }

        private String _userinventario;
        public String userinventario
        {
            get { return _userinventario; }

            set { _userinventario = value; }
        }

        private String _usuar;
        public String usuar
        {
            get { return _usuar; }

            set { _usuar = value; }
        }

        private DateTime? _feact;
        public DateTime? feact
        {
            get { return _feact; }

            set { _feact = value; }
        }

        //** 
        private Decimal _tipcamb;
        public Decimal tipcamb
        {
            get { return _tipcamb; }

            set { _tipcamb = value; }
        }

        //** parametro para generar listado para toma de inventario
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

        private String _descripcion;
        public String descripcion
        {
            get { return _descripcion; }

            set { _descripcion = value; }
        }

        private String _stockmayorcero;
        public String stockmayorcero
        {
            get { return _stockmayorcero; }

            set { _stockmayorcero = value; }
        }

        private String _orden;
        public String orden
        {
            get { return _orden; }

            set { _orden = value; }
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

        private String _totpzasl;
        public String totpzasl
        {
            get { return _totpzasl; }
            set { _totpzasl = value; }
        }

        private String _totpzasf;
        public String totpzasf
        {
            get { return _totpzasf; }
            set { _totpzasf = value; }
        }

        private String _glosa;
        public String glosa
        {
            get { return _glosa; }
            set { _glosa = value; }
        }

        private String _posicion;
        public String posicion
        {
            get { return _posicion; }

            set { _posicion = value; }
        }


        #endregion


        public class Item
        {

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

            private String _lineaid;
            public String lineaid
            {
                get { return _lineaid; }

                set { _lineaid = value; }
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

            private Decimal _stocklibros;
            public Decimal stocklibros
            {
                get { return _stocklibros; }

                set { _stocklibros = value; }
            }

            private Decimal _stockfisico;
            public Decimal stockfisico
            {
                get { return _stockfisico; }

                set { _stockfisico = value; }
            }

            private Decimal _diferencia;
            public Decimal diferencia
            {
                get { return _diferencia; }

                set { _diferencia = value; }
            }

            private Decimal _costopromlibros;
            public Decimal costopromlibros
            {
                get { return _costopromlibros; }

                set { _costopromlibros = value; }
            }

            private Decimal _costopromfisico;
            public Decimal costopromfisico
            {
                get { return _costopromfisico; }

                set { _costopromfisico = value; }
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

            private DateTime _fechdoc;
            public DateTime fechdoc
            {
                get { return _fechdoc; }
                set { _fechdoc = value; }
            }

            private String _usuar;
            public String usuar
            {
                get { return _usuar; }
                set { _usuar = value; }
            }

            private String _glosa;
            public String glosa
            {
                get { return _glosa; }
                set { _glosa = value; }
            }

            private String _userinventariado;
            public String userinventariado
            {
                get { return _userinventariado; }
                set { _userinventariado = value; }
            }

            private String _codigoubic;
            public String codigoubic
            {
                get { return _codigoubic; }
                set { _codigoubic = value; }
            }

            private DateTime _feact;
            public DateTime feact
            {
                get { return _feact; }
                set { _feact = value; }
            }

            private String _rollo;
            public String rollo
            {
                get { return _rollo; }
                set { _rollo = value; }
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
                          
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("items"); attrib1.Value = obj.items;                
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("productid"); attrib2.Value = obj.productid; 
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("stockfisico"); attrib3.Value = obj.stockfisico.ToString(); 
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib4.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("userinventariado"); attrib5.Value = obj.userinventariado;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("codigoubic"); attrib6.Value = obj.codigoubic;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib7.Value = obj.usuar;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("stocklibros"); attrib8.Value = obj.stocklibros.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("costopromlibros"); attrib9.Value = obj.costopromlibros.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("costopromfisico"); attrib10.Value = obj.costopromfisico.ToString();
                             
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
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("items"); attrib1.Value = obj.items;
                objNode.Attributes.Append(attrib1);
                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }


        public string GetItemXML3()
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("rollo"); attrib1.Value = obj.rollo;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("productid"); attrib2.Value = obj.productid;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("stockfisico"); attrib3.Value = obj.stockfisico.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("fechdoc"); attrib4.Value = fecha(obj.fechdoc).ToShortDateString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("userinventariado"); attrib5.Value = obj.userinventariado;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("codigoubic"); attrib6.Value = obj.codigoubic;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib7.Value = obj.usuar;
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("stocklibros"); attrib8.Value = obj.stocklibros.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("costopromlibros"); attrib9.Value = obj.costopromlibros.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("costopromfisico"); attrib10.Value = obj.costopromfisico.ToString();

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

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }

        public static bool IsNotNullOrEmpty(String input)
        {
            return !String.IsNullOrEmpty(input);
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
    }
}
