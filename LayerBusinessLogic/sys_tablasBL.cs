using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class sys_tablasBL
    {
        sys_tablasDA tablaDA = new sys_tablasDA();

        public DataSet GetAll_tablas(string empresaid, tb_sys_tablas BE)
        {
            return tablaDA.GetAll_tablas(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_sys_tablas BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }   
    }
}
