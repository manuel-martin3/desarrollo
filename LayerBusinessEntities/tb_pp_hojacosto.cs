using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Collections.Generic; 
using System.Data; 
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_pp_hojacosto
    {
        private String _articid;
        public String articid
        {
            get { return _articid; }
            set { _articid = value; }
        }

        private String _version;
        public String version
        {
            get { return _version; }
            set { _version = value; }
        }

        private DateTime? _fecha;
        public DateTime? fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private Int32 _cantidad;
        public Int32 cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private Decimal _costoprimo;
        public Decimal costoprimo
        {
            get { return _costoprimo; }
            set { _costoprimo = value; }
        }

        private Decimal _percgadm;
        public Decimal percgadm
        {
            get { return _percgadm; }
            set { _percgadm = value; }
        }

        private Decimal _percgvta;
        public Decimal percgvta
        {
            get { return _percgvta; }
            set { _percgvta = value; }
        }

        private Decimal _percgfin;
        public Decimal percgfin
        {
            get { return _percgfin; }
            set { _percgfin = value; }
        }

        private Decimal _gastoadm;
        public Decimal gastoadm
        {
            get { return _gastoadm; }
            set { _gastoadm = value; }
        }

        private Decimal _gastovta;
        public Decimal gastovta
        {
            get { return _gastovta; }
            set { _gastovta = value; }
        }

        private Decimal _gastofin;
        public Decimal gastofin
        {
            get { return _gastofin; }
            set { _gastofin = value; }
        }

        private Decimal _gastopera;
        public Decimal gastopera
        {
            get { return _gastopera; }
            set { _gastopera = value; }
        }

        private Decimal _costototal;
        public Decimal costototal
        {
            get { return _costototal; }
            set { _costototal = value; }
        }

        private String _perianio;
        public String perianio
        {
            get { return _perianio; }
            set { _perianio = value; }
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
            private String _articid;
            public String articid
            {
                get { return _articid; }
                set { _articid = value; }
            }

            private String _version;
            public String version
            {
                get { return _version; }
                set { _version = value; }
            }

            private String _rubroid;
            public String rubroid
            {
                get { return _rubroid; }
                set { _rubroid = value; }
            }

            private String _moduloid;
            public String moduloid
            {
                get { return _moduloid; }
                set { _moduloid = value; }
            }

            private String _lineaid;
            public String lineaid
            {
                get { return _lineaid; }
                set { _lineaid = value; }
            }

            private String _familiaid;
            public String familiaid
            {
                get { return _familiaid; }
                set { _familiaid = value; }
            }

            private Decimal _valor;
            public Decimal valor
            {
                get { return _valor; }
                set { _valor = value; }
            }

            private Decimal _consumo;
            public Decimal consumo
            {
                get { return _consumo; }
                set { _consumo = value; }
            }

            private String _unmed;
            public String unmed
            {
                get { return _unmed; }
                set { _unmed = value; }
            }

            private Decimal _importe;
            public Decimal importe
            {
                get { return _importe; }
                set { _importe = value; }
            }

            private String _status;
            public String status
            {
                get { return _status; }
                set { _status = value; }
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

        private List<Item> _ListaItems2;
        public List<Item> ListaItems2
        {
            get { return _ListaItems2; }
            set { _ListaItems2 = value; }
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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("articid"); attrib1.Value = obj.articid.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("version"); attrib2.Value = obj.version.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("rubroid"); attrib3.Value = obj.rubroid.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib4.Value = obj.moduloid.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("lineaid"); attrib5.Value = obj.lineaid.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("familiaid"); attrib6.Value = obj.familiaid.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("valor"); attrib7.Value = obj.valor.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("consumo"); attrib8.Value = obj.consumo.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("unmed"); attrib9.Value = obj.unmed.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("importe"); attrib10.Value = obj.importe.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("status"); attrib11.Value = obj.status.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib12.Value = obj.usuar.ToString();

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
            foreach (Item obj in _ListaItems2)
            {
                objNode = objXMLDoc.CreateElement("Item");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("articid"); attrib1.Value = obj.articid.ToString();
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("version"); attrib2.Value = obj.version.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("rubroid"); attrib3.Value = obj.rubroid.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib4.Value = obj.moduloid.ToString();   
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("importe"); attrib5.Value = obj.importe.ToString();
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
