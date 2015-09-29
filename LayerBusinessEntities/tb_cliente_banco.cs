using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_cliente_banco
    {
        private String _ctacte;
        public String ctacte
        {
            get { return _ctacte; }

            set { _ctacte = value; }
        }

        private String _bancoid;
        public String bancoid
        {
            get { return _bancoid; }

            set { _bancoid = value; }
        }

        private String _ctactemn;
        public String ctactemn
        {
            get { return _ctactemn; }

            set { _ctactemn = value; }
        }

        private String _ctacteme;
        public String ctacteme
        {
            get { return _ctacteme; }

            set { _ctacteme = value; }
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

        //*************************
        public class Item
        {
            private String _ctacte;
            public String ctacte
            {
                get { return _ctacte; }

                set { _ctacte = value; }
            }

            private String _bancoid;
            public String bancoid
            {
                get { return _bancoid; }

                set { _bancoid = value; }
            }

            private String _ctactemn;
            public String ctactemn
            {
                get { return _ctactemn; }

                set { _ctactemn = value; }
            }

            private String _ctacteme;
            public String ctacteme
            {
                get { return _ctacteme; }

                set { _ctacteme = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("bancoid"); attrib1.Value = obj.bancoid;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("ctactemn"); attrib2.Value = obj.ctactemn;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("ctacteme"); attrib3.Value = obj.ctacteme;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib4.Value = obj.usuar;

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }

            return objXMLDoc.InnerXml;
        }

        public static bool IsNotNullOrEmpty(String input)
        {
            return !String.IsNullOrEmpty(input);
        }

        #region *** validar fecha en formato correcto
        public DateTime fechavalida(DateTime pfecha)
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
