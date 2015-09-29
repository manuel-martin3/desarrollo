using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_seguridadlogBL
    {
        public string Sql_Error = "";
        tb_co_seguridadlogDA tablaDA = new tb_co_seguridadlogDA();

        public bool Insert(string empresaid, tb_co_seguridadlog BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_seguridadlog BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_seguridadlog BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_seguridadlog BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet zreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAllListado(string empresaid, tb_co_seguridadlog BE)
        {
            DataSet zreturn = tablaDA.GetAllListado(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAllSeguridadlog(string empresaid, tb_co_seguridadlog BE)
        {
            //return tablaDA.GetAllSeguridadlog(empresaid, BE);
            DataSet zreturn = tablaDA.GetAllSeguridadlog(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }       
        public DataSet GetOne(string empresaid, tb_co_seguridadlog BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
