using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_me_ListaPrecio
    {
        private Int32 _listaprecid;
        public Int32 listaprecid
        {
            get { return _listaprecid; }
            set { _listaprecid = value; }
        }

        private String _listaprecname;
        public String listaprecname
        {
            get { return _listaprecname; }
            set { _listaprecname = value; }
        }

        private Int32 _estado;
        public Int32 estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private DateTime _fechaini;
        public DateTime fechaini
        {
            get { return _fechaini; }
            set { _fechaini = value; }
        }


        private String _filtro;
        public String filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private DateTime _fechafin;
        public DateTime fechafin
        {
            get { return _fechafin; }
            set { _fechafin = value; }
        }


        private Int32 _tiendalist;
        public Int32 tiendalist
        {
            get { return _tiendalist; }
            set { _tiendalist = value; }
        }


        private String _productid;
        public String productid
        {
            get { return _productid; }
            set { _productid = value; }
        }

        private Decimal _precunit1;
        public Decimal precunit1
        {
            get { return _precunit1; }
            set { _precunit1 = value; }
        }


        private Decimal _precunit2;
        public Decimal precunit2
        {
            get { return _precunit2; }
            set { _precunit2 = value; }
        }


        private String _usuar;
        public String usuar
        {
            get { return _usuar; }
            set { _usuar = value; }
        }


        private String _moduloid;
        public String moduloid
        {
            get { return _moduloid; }
            set { _moduloid = value; }
        }

        private String _posicion;
        public String posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }


        private Decimal _tcamb;
        public Decimal tcamb
        {
            get { return _tcamb; }
            set { _tcamb = value; }
        }

        private String _productname;
        public String productname
        {
            get { return _productname; }
            set { _productname = value; }
        }

        private String _local;

        public String local
        {
            get { return _local; }
            set { _local = value; }
        }
        
        private DateTime _fecha;
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }



        public class Item
        {
           

            private String _productid;
            public String productid
            {
                get { return _productid; }

                set { _productid = value; }
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

            private Decimal _precunit1;
            public Decimal precunit1
            {
                get { return _precunit1; }

                set { _precunit1 = value; }
            }


            private Decimal _precunit2;
            public Decimal precunit2
            {
                get { return _precunit2; }

                set { _precunit2 = value; }
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


                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("lineaid"); attrib1.Value = obj.lineaid;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("grupoid"); attrib2.Value = obj.grupoid;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("subgrupoid"); attrib3.Value = obj.subgrupoid;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("precunit1"); attrib4.Value = obj.precunit1.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("precunit2"); attrib5.Value = obj.precunit2.ToString();

              
                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);
                objNode.Attributes.Append(attrib5);


                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }


    }
}
