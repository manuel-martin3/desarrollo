using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_tipodiarioBL
    {
        public string Sql_Error = "";
        tb_co_tipodiarioDA tablaDA = new tb_co_tipodiarioDA();

        public bool Insert(string empresaid, tb_co_tipodiario BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool xreturn = false;
            xreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool Update(string empresaid, tb_co_tipodiario BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool xreturn = false;
            xreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool Delete(string empresaid, tb_co_tipodiario BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool xreturn = false;
            xreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll(string empresaid, tb_co_tipodiario BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll_IR(string empresaid, tb_co_tipodiario BE)
        {
            //return tablaDA.GetAll_IR(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_IR(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetOne(string empresaid, tb_co_tipodiario BE)
        {
            //return tablaDA.GetOne(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetOne(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public Boolean Generar(string empresaid, string perianio_ini, string perianio_fin)
        {
            //return tablaDA.Generar(empresaid, perianio_ini, perianio_fin);
            bool xreturn = false;
            xreturn = tablaDA.Generar(empresaid, perianio_ini, perianio_fin);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
    }
}
