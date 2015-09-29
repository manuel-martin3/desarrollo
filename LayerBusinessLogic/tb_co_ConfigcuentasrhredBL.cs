using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_ConfigcuentasrhredBL
    {
        public string Sql_Error = "";
        tb_co_ConfigcuentasrhredDA tablaDA = new tb_co_ConfigcuentasrhredDA();

        public bool Insert(string empresaid, tb_co_Configcuentasrhred BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_Configcuentasrhred BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_Configcuentasrhred BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_Configcuentasrhred BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet Consulta_ConfigCuentas(string empresaid, tb_co_Configcuentasrhred BE)
        {
            //return tablaDA.Consulta_ConfigCuentas(empresaid, BE, TablaDatos);
            DataSet xreturn = tablaDA.Consulta_ConfigCuentas(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        
        public DataSet GetOne(string empresaid, string diarioid)
        {
            return tablaDA.GetOne(empresaid, diarioid);
        }
    }
}
