using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_retencionDEtBL
    {
        public string Sql_Error = "";
        tb_co_retencionDEtDA tablaDA = new tb_co_retencionDEtDA();

        //public bool Insert(string empresaid, tb_co_retencionDEt BE)
        //{
        //    //return tablaDA.Insert(empresaid, BE);
        //    bool xreturn = tablaDA.Insert(empresaid, BE);
        //    Sql_Error = tablaDA.Sql_Error;
        //    return xreturn;
        //}
        //public bool Update(string empresaid, tb_co_retencionDEt BE)
        //{
        //    return tablaDA.Update(empresaid, BE);
        //}
        //public bool Delete(string empresaid, tb_co_retencionDEt BE)
        //{
        //    return tablaDA.Delete(empresaid, BE);
        //}
        public DataSet GetAll(string empresaid, tb_co_retencionDEt BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        //public DataSet GetCRetencion(string empresaid, tb_co_retencionDEt BE)
        //{
        //    return tablaDA.GetCRetencion(empresaid, BE);
        //}
        //public DataSet GetOne(string empresaid, tb_co_retencionDEt BE)
        //{
        //    return tablaDA.GetOne(empresaid, BE);
        //}
    }
}
