using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using BlowFishCS;
using System.Data.OleDb;


namespace LayerDataAccess
{
    public class Conex_Fox2DA
    {       
        public String AdmConexion()
        {
            String sconstring = "Provider=VFPOLEDB.1;Data Source=J:\\aplvfp\\datos\\factur.DBC;";  
            return (sconstring);
        }   
    }


}
