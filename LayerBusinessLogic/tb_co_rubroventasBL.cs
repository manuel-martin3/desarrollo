using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_rubroventasBL
    {
        public string Sql_Error = "";
        tb_co_rubroventasDA tablaDA = new tb_co_rubroventasDA();

        public bool Insert(string empresaid, tb_co_rubroventas BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_rubroventas BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_rubroventas BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_rubroventas BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_IR(string empresaid, tb_co_rubroventas BE)
        {
            //return tablaDA.GetAll_IR(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_IR(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetOne(string empresaid, string rubroid)
        {
            return tablaDA.GetOne(empresaid, rubroid);
        }
    }
}
