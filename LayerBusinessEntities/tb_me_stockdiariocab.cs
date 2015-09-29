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
    
    public class tb_me_stockdiariocab
    {        
        #region MyRegion
        public String filtro { get; set; }
        public String marcaid { get; set; }
        public String lineaid { get; set; }
        public String generoid { get; set; }

        private String Valorfind;
        private DateTime Fecha; 
        private String Articid;
        private String Colorid;
        private String Coltall;
        private String Almacaccionid;
        
        private String Tipodoc;
        private String Serdoc;
        private String Numdoc;
        private Decimal Cantidad;
        private String Ctacte;
        private String Direcnume;
        private String Tipoperacionid;
        private String Tiporef;
        private String Serref;
        private String Numref;
        private Int32 Estado;
        private Int32 Atendido;
        private String Vendorid;
        private String Usuar;
        private String Canalventaid;
        private String Local;
        private String Dominioid;
        private String Moduloid;
        private String Articidold;
        private String Articname;
        private String Accion;

        public String accion
        {
            get { return Accion; }
            set { Accion = value; }
        }

        public String articname
        {
            get { return Articname; }
            set { Articname = value; }
        }

        public String articidold
        {
            get { return Articidold; }
            set { Articidold = value; }
        }

        public String moduloid
        {
            get { return Moduloid; }
            set { Moduloid = value; }
        }

        public String dominioid
        {
            get { return Dominioid; }
            set { Dominioid = value; }
        }

        public String local
        {
            get { return Local; }
            set { Local = value; }
        }

        public String vendorid
        {
            get { return Vendorid; }
            set { Vendorid = value; }
        }

        public Int32 atendido
        {
            get { return Atendido; }
            set { Atendido = value; }
        }

        public Int32 estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public String numref
        {
            get { return Numref; }
            set { Numref = value; }
        }

        public String serref
        {
            get { return Serref; }
            set { Serref = value; }
        }

        public String tiporef
        {
            get { return Tiporef; }
            set { Tiporef = value; }
        }
        
        public String tipoperacionid
        {
            get { return Tipoperacionid; }
            set { Tipoperacionid = value; }
        }

        public String direcnume
        {
            get { return Direcnume; }
            set { Direcnume = value; }
        }

        public String ctacte
        {
            get { return Ctacte; }
            set { Ctacte = value; }
        }

        public Decimal cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public String numdoc
        {
            get { return Numdoc; }
            set { Numdoc = value; }
        }
        
        public String serdoc
        {
            get { return Serdoc; }
            set { Serdoc = value; }
        }

        public String tipodoc
        {
            get { return Tipodoc; }
            set { Tipodoc = value; }
        }

        public String almacaccionid
        {
            get { return Almacaccionid; }
            set { Almacaccionid = value; }
        }

        public DateTime fecha
        {
            get { return Fecha; }

            set { Fecha = value; }
        }

        public String articid
        {
            get { return Articid; }

            set { Articid = value; }
        }

        public String colorid
        {
            get { return Colorid; }

            set { Colorid = value; }
        }
        
        public String coltall
        {
            get { return Coltall; }

            set { Coltall = value; }
        }

        public String valorfind
        {
            get { return Valorfind; }
            set { Valorfind = value; }
        }

        public String usuar
        {
            get { return Usuar; }
            set { Usuar = value; }
        }
        
        public String canalventaid
        {
            get { return Canalventaid; }
            set { Canalventaid = value; }
        }

        #endregion

        public class ItemsStkDeta
        {
            public DateTime? fecha { get; set; }
            public String articid { get; set; }
            public String colorid { get; set; }
            public String coltall { get; set; }
            public String almacaccionid { get; set; }
            public String tipodoc { get; set; }
            public String serdoc { get; set; }
            public String numdoc { get; set; }
            public Decimal cantidad { get; set; }
            public String ctacte { get; set; }
            public String direcnume { get; set; }
            public String tipoperacionid { get; set; }
            public String tiporef { get; set; }
            public String serref { get; set; }
            public String numref { get; set; }
            public Int32 estado { get; set; }
            public Int32 atendido { get; set; }
            public String vendorid { get; set; }
            public String usuar { get; set; }
            public String canalventaid { get; set; }
            public String local { get; set; }
            public String dominioid { get; set; }
            public String moduloid { get; set; }
        }

        private List<ItemsStkDeta> ListaItemsStkDeta;
        public List<ItemsStkDeta> listaItemsStkDeta
        {
            get { return ListaItemsStkDeta; }
            set { ListaItemsStkDeta = value; }
        }

        public string GetItemXML()
        {
            XmlDocument objXMLDoc = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            //Se crea un nodo elemento XML
            objNode = objXMLDoc.CreateElement("ItemsStkDeta");

            //Se agrega el nodo al Documento XML
            objXMLDoc.AppendChild(objNode);

            //Se itera la coleccion para generar la estructura XML
            foreach (ItemsStkDeta obj in listaItemsStkDeta)
            {
                objNode = objXMLDoc.CreateElement("ItemsStkDeta");

                XmlAttribute attrib1 = objNode.OwnerDocument.CreateAttribute("fecha"); attrib1.Value = obj.fecha.ToString().Substring(0,10);
                XmlAttribute attrib2 = objNode.OwnerDocument.CreateAttribute("articid"); attrib2.Value = obj.articid.ToString();
                XmlAttribute attrib3 = objNode.OwnerDocument.CreateAttribute("colorid"); attrib3.Value = obj.colorid.ToString();
                XmlAttribute attrib4 = objNode.OwnerDocument.CreateAttribute("coltall"); attrib4.Value = obj.coltall.ToString();
                XmlAttribute attrib5 = objNode.OwnerDocument.CreateAttribute("almacaccionid"); attrib5.Value = obj.almacaccionid.ToString();
                XmlAttribute attrib6 = objNode.OwnerDocument.CreateAttribute("tipodoc"); attrib6.Value = obj.tipodoc.ToString();
                XmlAttribute attrib7 = objNode.OwnerDocument.CreateAttribute("serdoc"); attrib7.Value = obj.serdoc.ToString();
                XmlAttribute attrib8 = objNode.OwnerDocument.CreateAttribute("numdoc"); attrib8.Value = obj.numdoc.ToString();
                XmlAttribute attrib9 = objNode.OwnerDocument.CreateAttribute("cantidad"); attrib9.Value = obj.cantidad.ToString();
                XmlAttribute attrib10 = objNode.OwnerDocument.CreateAttribute("ctacte"); attrib10.Value = obj.ctacte.ToString();
                XmlAttribute attrib11 = objNode.OwnerDocument.CreateAttribute("direcnume"); attrib11.Value = obj.direcnume.ToString();
                XmlAttribute attrib12 = objNode.OwnerDocument.CreateAttribute("tipoperacionid"); attrib12.Value = obj.tipoperacionid.ToString();
                XmlAttribute attrib13 = objNode.OwnerDocument.CreateAttribute("tiporef"); attrib13.Value = obj.tipodoc.ToString();
                XmlAttribute attrib14 = objNode.OwnerDocument.CreateAttribute("serref"); attrib14.Value = obj.serref.ToString();
                XmlAttribute attrib15 = objNode.OwnerDocument.CreateAttribute("numref"); attrib15.Value = obj.numref.ToString();
                XmlAttribute attrib16 = objNode.OwnerDocument.CreateAttribute("estado"); attrib16.Value = obj.estado.ToString();
                XmlAttribute attrib17 = objNode.OwnerDocument.CreateAttribute("atendido"); attrib17.Value = obj.atendido.ToString();
                XmlAttribute attrib18 = objNode.OwnerDocument.CreateAttribute("vendorid"); attrib18.Value = obj.vendorid.ToString();
                XmlAttribute attrib19 = objNode.OwnerDocument.CreateAttribute("usuar"); attrib19.Value = obj.usuar.ToString();
                XmlAttribute attrib20 = objNode.OwnerDocument.CreateAttribute("canalventaid"); attrib20.Value = obj.canalventaid.ToString();
                XmlAttribute attrib21 = objNode.OwnerDocument.CreateAttribute("local"); attrib21.Value = obj.local.ToString();
                XmlAttribute attrib22 = objNode.OwnerDocument.CreateAttribute("dominioid"); attrib22.Value = obj.dominioid.ToString();
                XmlAttribute attrib23 = objNode.OwnerDocument.CreateAttribute("moduloid"); attrib23.Value = obj.moduloid.ToString();
                
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
                objNode.Attributes.Append(attrib15);
                objNode.Attributes.Append(attrib16);
                objNode.Attributes.Append(attrib17);
                objNode.Attributes.Append(attrib18);
                objNode.Attributes.Append(attrib19);
                objNode.Attributes.Append(attrib20);
                objNode.Attributes.Append(attrib21);
                objNode.Attributes.Append(attrib22);
                objNode.Attributes.Append(attrib23);

                objXMLDoc.DocumentElement.AppendChild(objNode);
            }
            return objXMLDoc.InnerXml;
        }

    }   
       
}       