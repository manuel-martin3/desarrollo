using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_co_plantillacontable
    {
        private String _creporte;
        public String creporte
        {
            get { return _creporte; }

            set { _creporte = value; }
        }

        private String _cgrupo;
        public String cgrupo
        {
            get { return _cgrupo; }

            set { _cgrupo = value; }
        }

        private String _dgrupo;
        public String dgrupo
        {
            get { return _dgrupo; }

            set { _dgrupo = value; }
        }

        private String _cuentaid;
        public String cuentaid
        {
            get { return _cuentaid; }

            set { _cuentaid = value; }
        }

        private String _codigo;
        public String codigo
        {
            get { return _codigo; }

            set { _codigo = value; }
        }

        private String _descripcion;
        public String descripcion
        {
            get { return _descripcion; }

            set { _descripcion = value; }
        }

        private int _ntipo;
        public int ntipo
        {
            get { return _ntipo; }

            set { _ntipo = value; }
        }
    
        private String _perianio;
        public String perianio
        {
            get { return _perianio; }

            set { _perianio = value; }
        }

        #region //Partidas Estados Financieros
        private String _eeffid;
        public String eeffid
        {
            get { return _eeffid; }

            set { _eeffid = value; }
        }

        private String _eeffname;
        public String eeffname
        {
            get { return _eeffname; }

            set { _eeffname = value; }
        }

        private String _observacion;
        public String observacion
        {
            get { return _observacion; }

            set { _observacion = value; }
        }

        private String _partidaid;
        public String partidaid
        {
            get { return _partidaid; }

            set { _partidaid = value; }
        }

        private String _partidaname;
        public String partidaname
        {
            get { return _partidaname; }

            set { _partidaname = value; }
        }
        #endregion

        //*************************************************        
        public class Item
        {
            //private String _creporte;
            //public String creporte
            //{
            //    get { return _creporte; }

            //    set { _creporte = value; }
            //}

            private String _cgrupo;
            public String cgrupo
            {
                get { return _cgrupo; }

                set { _cgrupo = value; }
            }

            private String _dgrupo;
            public String dgrupo
            {
                get { return _dgrupo; }

                set { _dgrupo = value; }
            }

            private String _cuentaid;
            public String cuentaid
            {
                get { return _cuentaid; }

                set { _cuentaid = value; }
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

                //XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("creporte"); attrib1.Value = obj.creporte;
                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("cgrupo"); attrib1.Value = obj.cgrupo;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("dgrupo"); attrib2.Value = obj.dgrupo;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("cuentaid"); attrib3.Value = obj.cuentaid;
                
                //objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib1);
                objNode.Attributes.Append(attrib2);
                objNode.Attributes.Append(attrib3);

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
