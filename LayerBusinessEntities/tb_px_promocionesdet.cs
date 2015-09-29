using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_px_promocionesdet
    {
        private Int32? _promoid;
        public Int32? promoid
        {
          get { return _promoid; }
          set { _promoid = value; }
        }

        private String _articid;
        public String articid
        {
            get { return _articid; }
            set { _articid = value; }
        }

        private String _articidold;
        public String articidold
        {
            get { return _articidold; }
            set { _articidold = value; }
        }

        private String _articname;
        public String articname
        {
            get { return _articname; }
            set { _articname = value; }
        }

        private Boolean _es_dscto;
        public Boolean es_dscto
        {
            get { return _es_dscto; }
            set { _es_dscto = value; }
        }

        private Int32 _cantidad;
        public Int32 cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private Decimal _percdscto;
        public Decimal percdscto
        {
            get { return _percdscto; }
            set { _percdscto = value; }
        }

        private Decimal _precunit;
        public Decimal precunit
        {
            get { return _precunit; }
            set { _precunit = value; }
        }

        private String _status;
        public String status
        {
            get { return _status; }
            set { _status = value; }
        }


        private String _usuarIP;
        public String UsuarIP
        {
            get { return _usuarIP; }
            set { _usuarIP = value; }
        }

        private DateTime _feact;
        public DateTime feact
        {
            get { return _feact; }
            set { _feact = value; }
        }

        public class Item
        {
            private Int32? _promoid;
            public Int32? promoid
            {
                get { return _promoid; }
                set { _promoid = value; }
            }

            private String _articid;
            public String articid
            {
                get { return _articid; }
                set { _articid = value; }
            }

            private String _articidold;
            public String articidold
            {
                get { return _articidold; }
                set { _articidold = value; }
            }

            private String _articname;
            public String articname
            {
                get { return _articname; }
                set { _articname = value; }
            }

            private Boolean _es_dscto;
            public Boolean es_dscto
            {
                get { return _es_dscto; }
                set { _es_dscto = value; }
            }

            private Int32 _cantidad;
            public Int32 cantidad
            {
                get { return _cantidad; }
                set { _cantidad = value; }
            }

            private Decimal _percdscto;
            public Decimal percdscto
            {
                get { return _percdscto; }
                set { _percdscto = value; }
            }

            private Decimal _precunit;
            public Decimal precunit
            {
                get { return _precunit; }
                set { _precunit = value; }
            }

            private String _status;
            public String status
            {
                get { return _status; }
                set { _status = value; }
            }


            private String _usuarIP;
            public String UsuarIP
            {
                get { return _usuarIP; }
                set { _usuarIP = value; }
            }

            private DateTime _feact;
            public DateTime feact
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("promoid"); attrib1.Value = obj.promoid.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("articid"); attrib2.Value = obj.articid.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("articidold"); attrib3.Value = obj.articidold.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("articname"); attrib4.Value = obj.articname.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("es_dscto"); attrib5.Value = obj.es_dscto.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib6.Value = obj.cantidad.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("percdscto"); attrib7.Value = obj.percdscto.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("precunit"); attrib8.Value = obj.precunit.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("status"); attrib9.Value = obj.status.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("usuarIP"); attrib10.Value = obj.UsuarIP.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("feact"); attrib11.Value = obj.feact.ToString();

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

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }

    }

}
