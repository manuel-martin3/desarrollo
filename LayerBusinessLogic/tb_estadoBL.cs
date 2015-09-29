using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_estadoBL
    {
        tb_estadoDA tablaDA = new tb_estadoDA();

        public string Sql_Error = "";

        public DataSet GetAll(string empresaid, tb_estado BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }     
  
    }
}
