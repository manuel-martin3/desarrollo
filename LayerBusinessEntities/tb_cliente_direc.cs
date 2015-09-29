using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_cliente_direc
    {
        public String ubig1 { get; set; }
        public String ubig2 { get; set; }
        public String ubig3 { get; set; }


        private String _ctacte;
        public String ctacte
        {
            get { return _ctacte; }

            set { _ctacte = value; }
        }

        private String _direcnume;
        public String direcnume
        {
            get { return _direcnume; }

            set { _direcnume = value; }
        }

        private String _direcname;
        public String direcname
        {
            get { return _direcname; }

            set { _direcname = value; }
        }

        private String _direcdeta;
        public String direcdeta
        {
            get { return _direcdeta; }

            set { _direcdeta = value; }
        }

        private String _telef;
        public String telef
        {
            get { return _telef; }

            set { _telef = value; }
        }

        private String _ubige;
        public String ubige
        {
            get { return _ubige; }

            set { _ubige = value; }
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

        private String _status;
        public String status
        {
            get { return _status; }

            set { _status = value; }
        }

        private String _nombrelike1;
        public String nombrelike1
        {
            get { return _nombrelike1; }

            set { _nombrelike1 = value; }
        }

        private String _nombrelike2;
        public String nombrelike2
        {
            get { return _nombrelike2; }

            set { _nombrelike2 = value; }
        }

        private String _nombrelike3;
        public String nombrelike3
        {
            get { return _nombrelike3; }

            set { _nombrelike3 = value; }
        }
        //*********************
        public class Item
        {
            private String _ctacte;
            public String ctacte
            {
                get { return _ctacte; }

                set { _ctacte = value; }
            }

            private String _direcnume;
            public String direcnume
            {
                get { return _direcnume; }

                set { _direcnume = value; }
            }

            private String _direcname;
            public String direcname
            {
                get { return _direcname; }

                set { _direcname = value; }
            }

            private String _direcdeta;
            public String direcdeta
            {
                get { return _direcdeta; }

                set { _direcdeta = value; }
            }

            private String _telef;
            public String telef
            {
                get { return _telef; }

                set { _telef = value; }
            }

            private String _ubige;
            public String ubige
            {
                get { return _ubige; }

                set { _ubige = value; }
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

            private String _status;
            public String status
            {
                get { return _status; }

                set { _status = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("direcnume"); attrib1.Value = obj.direcnume;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("direcname"); attrib2.Value = obj.direcname;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("direcdeta"); attrib3.Value = obj.direcdeta;
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("telef"); attrib4.Value = obj.telef;
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("ubige"); attrib5.Value = obj.ubige;
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib6.Value = obj.usuar;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("status"); attrib7.Value = obj.status;

                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);
                objNode.Attributes.Append(attrib4);
                objNode.Attributes.Append(attrib5);
                objNode.Attributes.Append(attrib6);
                objNode.Attributes.Append(attrib7);

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
