using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_plla_pdt_tabla12BL
    {
        public string Sql_Error = "";
        tb_plla_pdt_tabla12DA tablaDA = new tb_plla_pdt_tabla12DA();

        public bool Insert(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Update(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Delete(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAll(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll_Consulta(string empresaid, tb_plla_pdt_tabla12 BE)
        {
            //return tablaDA.GetAll_Consulta(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_Consulta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetOne(string empresaid, string tipcontratoid)
        {
            //return tablaDA.GetOne(empresaid, tipcontratoid);
            DataSet xreturn = null;
            xreturn = tablaDA.GetOne(empresaid, tipcontratoid);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
    }
}
