using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using BlowFishCS;


namespace LayerDataAccess
{
    public class ConexionDA
    {
        private ConfigXml mCfg;
        BlowFish blf = new BlowFish("saltamonte");                

        public String AdmConexion()
        {
            string servername="";
            string database="";
            string user="";
            string password="";
            string sconstring="";

            XmlDocument xDoc = new XmlDocument();
            //BlowFish blf = new BlowFish("");

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            //string xArchivo = System.IO.Directory.GetCurrentDirectory() + @"\BapConfig.cfg";
            string xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";

            if (!File.Exists(xArchivo))
            {                              
                DirectoryInfo DIR = new DirectoryInfo(@"c:\ErpBapSoftNet_Config");
                if (!DIR.Exists) DIR.Create();

                mCfg = new ConfigXml(xArchivo, true);
                mCfg.SetValue("AdmConexion", "servername", blf.Encrypt_CBC("ERPSERVER"));
                mCfg.SetValue("AdmConexion", "database", blf.Encrypt_CBC("bapAdmin"));
                mCfg.SetValue("AdmConexion", "user", blf.Encrypt_CBC("bapsoft")); //pieers
                mCfg.SetValue("AdmConexion", "password", blf.Encrypt_CBC("peru@09121824")); //ECuxmXuo

                mCfg.SetValue("EmpConexion", "servername", blf.Encrypt_CBC("ERPSERVER"));
                mCfg.SetValue("EmpConexion", "database", blf.Encrypt_CBC("bapEmpresa"));
                mCfg.SetValue("EmpConexion", "user", blf.Encrypt_CBC("bapsoft")); //pieers
                mCfg.SetValue("EmpConexion", "password", blf.Encrypt_CBC("peru@09121824")); //ECuxmXuo

                mCfg.Save();
            }

            xDoc.Load(xArchivo);

            XmlNodeList configuration = xDoc.GetElementsByTagName("configuration");
            XmlNodeList lista = ((XmlElement)configuration[0]).GetElementsByTagName("AdmConexion");

            foreach (XmlElement nodo in lista)
            {
                int i = 0;
                XmlNodeList nservername = nodo.GetElementsByTagName("servername");
                XmlNodeList ndatabase = nodo.GetElementsByTagName("database");
                XmlNodeList nuser = nodo.GetElementsByTagName("user");
                XmlNodeList npassword = nodo.GetElementsByTagName("password");

                servername = blf.Decrypt_CBC(nservername[i].InnerText);
                database = blf.Decrypt_CBC(ndatabase[i].InnerText);
                user = blf.Decrypt_CBC(nuser[i].InnerText);
                password = blf.Decrypt_CBC(npassword[i].InnerText);
                
                //Console.WriteLine("Elemento nombre ... {0} {1} {2}",
                //                             nservername[i].InnerText,
                //                             ndatabase[i].InnerText,
                //                             nuser[i++].InnerText);

            }           

            sconstring = "Data Source=" + servername + ";Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password;

            if (user.IndexOf("pieers") == -1)
            {
                //licenserver ls = new licenserver(servername, database, user, password);
                //sconstring = ls.currentlicense() ? sconstring : "";    
            }
            
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
            //string xArchivo = System.IO.Directory.GetCurrentDirectory() + @"\BapConfig.cfg";
            string xArchivo = @"c:\ErpBapSoftNet_Config\BapConfig.cfg";

            if (!File.Exists(xArchivo))
            {
                DirectoryInfo DIR = new DirectoryInfo(@"c:\ErpBapSoftNet_Config");
                if (!DIR.Exists) DIR.Create();

                mCfg = new ConfigXml(xArchivo, true);
                mCfg.SetValue("AdmConexion", "servername", blf.Encrypt_CBC("ERPSERVER"));
                mCfg.SetValue("AdmConexion", "database", blf.Encrypt_CBC("bapAdmin"));
                mCfg.SetValue("AdmConexion", "user", blf.Encrypt_CBC("bapsoft")); //pieers
                mCfg.SetValue("AdmConexion", "password", blf.Encrypt_CBC("peru@09121824")); //ECuxmXuo

                mCfg.SetValue("EmpConexion", "servername", blf.Encrypt_CBC("ERPSERVER"));
                mCfg.SetValue("EmpConexion", "database", blf.Encrypt_CBC("bapEmpresa"));
                mCfg.SetValue("EmpConexion", "user", blf.Encrypt_CBC("bapsoft")); //pieers
                mCfg.SetValue("EmpConexion", "password", blf.Encrypt_CBC("peru@09121824")); //ECuxmXuo

                mCfg.Save();
            }

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

                servername = blf.Decrypt_CBC(nservername[i].InnerText);
                database = blf.Decrypt_CBC(ndatabase[i].InnerText);
                user = blf.Decrypt_CBC(nuser[i].InnerText);
                password = blf.Decrypt_CBC(npassword[i].InnerText);

                //Console.WriteLine("Elemento nombre ... {0} {1} {2}",
                //                             nservername[i].InnerText,
                //                             ndatabase[i].InnerText,
                //                             nuser[i++].InnerText);
                          
            }

            sconstring = "Data Source=" + servername + ";Initial Catalog=" + database+Empresa + ";User ID=" + user + ";Password=" + password;
            
            //licenserver ls = new licenserver(servername, database + Empresa, user, password);
            //sconstring = ls.currentlicense() ? sconstring : "";
            
            //Console.WriteLine("Cadena de conexion ... {0}", sconstring);
            return (sconstring);


        }

        private void AgregarBaseDatos()
        {
            String str;
            String conex = empConexion("02");
            //SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
            SqlConnection myConn = new SqlConnection(conex);
            str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                "FILENAME = 'C:\\MyDatabaseData.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                //MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }


        }
    }
}
