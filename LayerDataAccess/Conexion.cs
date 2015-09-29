using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace LayerDataAccess
{
    public class Conexion
    {
        public String AdmConexion()
        {
            string servername="";
            string database="";
            string user="";
            string password="";
            string sconstring="";

            XmlDocument xDoc = new XmlDocument();

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            string  xArchivo = System.IO.Directory.GetCurrentDirectory() + @"\BapConfig.cfg";

            xDoc.Load(xArchivo);

            XmlNodeList configuration = xDoc.GetElementsByTagName("configuration");

            XmlNodeList lista =
                ((XmlElement)configuration[0]).GetElementsByTagName("AdmConexion");

            foreach (XmlElement nodo in lista)
            {

                int i = 0;

                XmlNodeList nservername =
                nodo.GetElementsByTagName("servername");

                XmlNodeList ndatabase =
                nodo.GetElementsByTagName("database");

                XmlNodeList nuser =
                nodo.GetElementsByTagName("user");

                XmlNodeList npassword =
                nodo.GetElementsByTagName("password");

                servername = nservername[i].InnerText;
                database = ndatabase[i].InnerText;
                user = nuser[i].InnerText;
                password = npassword[i].InnerText;
                
                //Console.WriteLine("Elemento nombre ... {0} {1} {2}",
                //                             nservername[i].InnerText,
                //                             ndatabase[i].InnerText,
                //                             nuser[i++].InnerText);

            }
            
            sconstring = "Data Source=" + servername + ";Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password;
            //Console.WriteLine("Cadena de conexion ... {0}", sconstring);
            return (sconstring);
        }

        public String empConexion(string Empresa)
        {
            string servername = "";
            string database = "";
            string user = "";
            string password = "";
            string sconstring = "";

            XmlDocument xDoc = new XmlDocument();

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            string xArchivo = System.IO.Directory.GetCurrentDirectory() + @"\BapConfig.cfg";

            xDoc.Load(xArchivo);

            XmlNodeList configuration = xDoc.GetElementsByTagName("configuration");
            XmlNodeList lista = ((XmlElement)configuration[0]).GetElementsByTagName("EmpConexion");

            foreach (XmlElement nodo in lista)
            {

                int i = 0;

                XmlNodeList nservername =
                nodo.GetElementsByTagName("servername");

                XmlNodeList ndatabase =
                nodo.GetElementsByTagName("database");

                XmlNodeList nuser =
                nodo.GetElementsByTagName("user");

                XmlNodeList npassword =
                nodo.GetElementsByTagName("password");

                servername = nservername[i].InnerText;
                database = ndatabase[i].InnerText;
                user = nuser[i].InnerText;
                password = npassword[i].InnerText;

                //Console.WriteLine("Elemento nombre ... {0} {1} {2}",
                //                             nservername[i].InnerText,
                //                             ndatabase[i].InnerText,
                //                             nuser[i++].InnerText);

            }

            sconstring = "Data Source=" + servername + ";Initial Catalog=" + database+Empresa + ";User ID=" + user + ";Password=" + password;
            //Console.WriteLine("Cadena de conexion ... {0}", sconstring);
            return (sconstring);


        }

    }
}
