using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;

namespace LayerBusinessEntities
{
    public class tb_perfilitems
    {
        private String _idper;
        public String idper
        {
            get { return _idper; }

            set { _idper = value; }
        }

        private String _plataforma;
        public String plataforma
        {
            get { return _plataforma; }

            set { _plataforma = value; }
        }

        private Int32? _menid;
        public Int32? menid
        {
            get { return _menid; }

            set { _menid = value; }
        }

        private Int32 _padid;
        public Int32 padid
        {
            get { return _padid; }

            set { _padid = value; }
        }

        private Int32 _posic;
        public Int32 posic
        {
            get { return _posic; }

            set { _posic = value; }
        }

        private String _descr;
        public String descr
        {
            get { return _descr; }

            set { _descr = value; }
        }

        private String _grupo;
        public String grupo
        {
            get { return _grupo; }

            set { _grupo = value; }
        }

        private String _icono;
        public String icono
        {
            get { return _icono; }

            set { _icono = value; }
        }

        private Boolean? _habil;
        public Boolean? habil
        {
            get { return _habil; }

            set { _habil = value; }
        }

        private String _pgurl;
        public String pgurl
        {
            get { return _pgurl; }

            set { _pgurl = value; }
        }

        private String _nivelacc;
        public String nivelacc
        {
            get { return _nivelacc; }

            set { _nivelacc = value; }
        }

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

        public class Item
        {
            private String _idper;
            public String idper
            {
                get { return _idper; }

                set { _idper = value; }
            }

            private String _plataforma;
            public String plataforma
            {
                get { return _plataforma; }

                set { _plataforma = value; }
            }

            private Int32? _menid;
            public Int32? menid
            {
                get { return _menid; }

                set { _menid = value; }
            }

            private Int32 _padid;
            public Int32 padid
            {
                get { return _padid; }

                set { _padid = value; }
            }

            private Int32 _posic;
            public Int32 posic
            {
                get { return _posic; }

                set { _posic = value; }
            }

            private String _descr;
            public String descr
            {
                get { return _descr; }

                set { _descr = value; }
            }

            private String _grupo;
            public String grupo
            {
                get { return _grupo; }

                set { _grupo = value; }
            }

            private String _icono;
            public String icono
            {
                get { return _icono; }

                set { _icono = value; }
            }

            private Boolean? _habil;
            public Boolean? habil
            {
                get { return _habil; }

                set { _habil = value; }
            }

            private String _pgurl;
            public String pgurl
            {
                get { return _pgurl; }

                set { _pgurl = value; }
            }

            private String _nivelacc;
            public String nivelacc
            {
                get { return _nivelacc; }

                set { _nivelacc = value; }
            }

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

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("idper"); attrib1.Value = obj.idper;
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("plataforma"); attrib2.Value = obj.plataforma;
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("menid"); attrib3.Value = obj.menid.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("padid"); attrib4.Value = obj.padid.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("posic"); attrib5.Value = obj.posic.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("descr"); attrib6.Value = obj.descr;
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("grupo"); attrib7.Value = obj.grupo.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("icono"); attrib8.Value = obj.icono;
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("habil"); attrib9.Value = obj.habil.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("pgurl"); attrib10.Value = obj.pgurl;
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("nivelacc"); attrib11.Value = obj.nivelacc;
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("dominioid"); attrib12.Value = obj.dominioid;
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib13.Value = obj.moduloid;
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("local"); attrib14.Value = obj.local;

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
                objNode.Attributes.Append(attrib13);
                objNode.Attributes.Append(attrib14);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }
    }
}
