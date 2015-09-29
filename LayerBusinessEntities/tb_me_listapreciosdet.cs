using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_me_listapreciosdet
    {
        private Int32? _listaprecid;
        public Int32? listaprecid
        {
            get { return _listaprecid; }
            set { _listaprecid = value; }
        }


        private String _codigo;
        public String codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
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

        private DateTime? _feact;
        public DateTime? feact
        {
            get { return _feact; }
            set { _feact = value; }
        }

        public class Item
        {
            private Int32 _listaprecid;
            public Int32 listaprecid
            {
                get { return _listaprecid; }
                set { _listaprecid = value; }
            }

            private String _codigo;
            public String codigo
            {
                get { return _codigo; }
                set { _codigo = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("listaprecid"); attrib1.Value = obj.listaprecid.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("codigo"); attrib2.Value = obj.codigo;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("precunit1"); attrib3.Value = obj.precunit1.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("precunit2"); attrib4.Value = obj.precunit2.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib5.Value = obj.usuar;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("feact"); attrib6.Value = obj.feact.ToString();         

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
