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
    public class tb_tipocambio
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

        private DateTime? _fecha;
        public DateTime? fecha
        {
            get { return _fecha; }

            set { _fecha = value; }
        }

        private Decimal _compra;
        public Decimal compra
        {
            get { return _compra; }

            set { _compra = value; }
        }

        private Decimal _venta;
        public Decimal venta
        {
            get { return _venta; }

            set { _venta = value; }
        }

        private Decimal _promedio;
        public Decimal promedio
        {
            get { return _promedio; }

            set { _promedio = value; }
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

        private int _anio;
        public int anio
        {
            get { return _anio; }

            set { _anio = value; }
        }

        private int _mes;
        public int mes
        {
            get { return _mes; }

            set { _mes = value; }
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

        //*********************
        public class Item
        {
            private DateTime _fecha;
            public DateTime fecha
            {
                get { return _fecha; }

                set { _fecha = value; }
            }

            private Decimal _compra;
            public Decimal compra
            {
                get { return _compra; }

                set { _compra = value; }
            }

            private Decimal _venta;
            public Decimal venta
            {
                get { return _venta; }

                set { _venta = value; }
            }

            private Decimal _promedio;
            public Decimal promedio
            {
                get { return _promedio; }

                set { _promedio = value; }
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

            private int _anio;
            public int anio
            {
                get { return _anio; }

                set { _anio = value; }
            }

            private int _mes;
            public int mes
            {
                get { return _mes; }

                set { _mes = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("fecha"); attrib1.Value = fechavalida(obj.fecha).ToShortDateString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("compra"); attrib2.Value = obj.compra.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("venta"); attrib3.Value = obj.venta.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("promedio"); attrib4.Value = obj.promedio.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib5.Value = obj.usuar;

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);
                objNode.Attributes.Append(attrib5);

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
