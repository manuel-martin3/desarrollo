using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace LayerDataAccess
{
    public class ConexionWeb
    {
        public String AdmConexion()
        {
            string servername = "ERPSERVER";
            //string servername = "200.37.233.179";
            //string database = "datapi";
            string database = "bapAdmin";

            string user = "bapsoft";
            string password = "peru@09121824";
            string sconstring;

            sconstring = "Data Source=" + servername + ";Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password;

            return (sconstring);
        }

        public String empConexion(string Empresa)
        {
            string servername = "ERPSERVER";
            //string servername = "200.37.233.179";
            //string database = "datapi";
            string database = "bapEmpresa" + "02";

            string user = "bapsoft";
            string password = "peru@09121824";
            string sconstring;

            sconstring = "Data Source=" + servername + ";Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password;

            return (sconstring);
        }

    }
}
