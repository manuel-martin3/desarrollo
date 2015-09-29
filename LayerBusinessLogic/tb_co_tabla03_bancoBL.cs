using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_tabla03_bancoBL
    {
        public string Sql_Error = "";
        tb_co_tabla03_bancoDA tablaDA = new tb_co_tabla03_bancoDA();

        public bool Insert(string empresaid, tb_co_tabla03_banco BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Update(string empresaid, tb_co_tabla03_banco BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Delete(string empresaid, tb_co_tabla03_banco BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAll(string empresaid, tb_co_tabla03_banco BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAllMaxCodigo(string empresaid, tb_co_tabla03_banco BE)
        {
            //return tablaDA.GetAllMaxRubro(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllMaxCodigo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetOne(string empresaid, string codigoid)
        {
            //return tablaDA.GetOne(empresaid, codigoid);
            DataSet xreturn = null;
            xreturn = tablaDA.GetOne(empresaid, codigoid);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
    }
}
