using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_me_cuota_tiendacargo
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

        private String _local;
        public String local
        {
            get { return _local; }
            set { _local = value; }
        }

        private Int32? _filtro;
        public Int32? filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private String _cargoid;
        public String cargoid
        {
            get { return _cargoid; }
            set { _cargoid = value; }
        }


        private Decimal _cuota;
        public Decimal cuota
        {
            get { return _cuota; }
            set { _cuota = value; }
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

        public class Item
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

            private String _local;
            public String local
            {
                get { return _local; }
                set { _local = value; }
            }

            private String _cargoid;
            public String cargoid
            {
                get { return _cargoid; }
                set { _cargoid = value; }
            }

            private Decimal _cuota;
            public Decimal cuota
            {
                get { return _cuota; }
                set { _cuota = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("perianio"); attrib1.Value = obj.perianio.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("perimes"); attrib2.Value = obj.perimes.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("local"); attrib3.Value = obj.local.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("cargoid"); attrib4.Value = obj.cargoid.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("cuota"); attrib5.Value = obj.cuota.ToString();                
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib6.Value = obj.usuar.ToString();
           
                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);                
                objNode.Attributes.Append(attrib5);
                objNode.Attributes.Append(attrib6);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }


















    }
}
