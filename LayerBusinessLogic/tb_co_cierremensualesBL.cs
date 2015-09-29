using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_cierremensualesBL
    {
        public string Sql_Error = "";
        tb_co_cierremensualesDA tablaDA = new tb_co_cierremensualesDA();

        public bool Insert(string empresaid, tb_co_cierremensuales BE)
        {          
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Update(string empresaid, tb_co_cierremensuales BE)
        {          
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Delete(string empresaid, tb_co_cierremensuales BE)
        {          
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAll(string empresaid, tb_co_cierremensuales BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet zreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetOne(string empresaid, tb_co_cierremensuales BE)
        {         
            DataSet zreturn = tablaDA.GetOne(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public Boolean Generar(string empresaid, string perianio_ini, string perianio_fin)
        {
            //return tablaDA.Generar(empresaid, perianio_ini, perianio_fin);
            Boolean zreturn = tablaDA.Generar(empresaid, perianio_ini, perianio_fin);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
    }
}
