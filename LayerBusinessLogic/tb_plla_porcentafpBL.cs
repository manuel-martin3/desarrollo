using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_plla_porcentafpBL
    {
        public string Sql_Error = "";
        tb_plla_porcentafpDA tablaDA = new tb_plla_porcentafpDA();

        public bool Insert(string empresaid, tb_plla_porcentafp BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool BapSoft_PorcentajesAFPInsert(string empresaid, tb_plla_porcentafp BE, DataTable TablaDatos)
        {
            //return tablaDA.BapSoft_PorcentajesAFPInsert(empresaid, BE);
            bool zreturn = tablaDA.BapSoft_PorcentajesAFPInsert(empresaid, BE, TablaDatos);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool Update(string empresaid, tb_plla_porcentafp BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Delete(string empresaid, tb_plla_porcentafp BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAll(string empresaid, tb_plla_porcentafp BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll_Consulta(string empresaid, tb_plla_porcentafp BE)
        {
            //return tablaDA.GetAll_Consulta(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_Consulta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetOne(string empresaid, tb_plla_porcentafp BE)
        {
            //return tablaDA.GetOne(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetOne(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
    }
}
