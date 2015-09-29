using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_tabla05_tipoexistenciaBL
    {
        public string Sql_Error = "";
        tb_co_tabla05_tipoexistenciaDA tablaDA = new tb_co_tabla05_tipoexistenciaDA();

        public bool Insert(string empresaid, tb_co_tabla05_tipoexistencia BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        //public bool Insert(string empresaid, tb_co_tabla05_tipoexistencia BE)
        //{
        //    return tablaDA.Insert(empresaid, BE);
        //}
        public bool Update(string empresaid, tb_co_tabla05_tipoexistencia BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_tabla05_tipoexistencia BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_tabla05_tipoexistencia BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        //public DataSet GetAll(string empresaid, tb_co_tabla05_tipoexistencia BE)
        //{
        //    return tablaDA.GetAll(empresaid, BE);
        //}
        public DataSet GetOne(string empresaid, string codigoid)
        {
            return tablaDA.GetOne(empresaid, codigoid);
        }
    }
}
