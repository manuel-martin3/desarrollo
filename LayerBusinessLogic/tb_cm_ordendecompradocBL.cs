using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
  public  class tb_cm_ordendecompradocBL
    {
        public string Sql_Error = "";
        tb_cm_ordendecompradocDA tablaDA = new tb_cm_ordendecompradocDA();

        public bool Insert(string empresaid, tb_cm_ordendecompradoc BE)
        {
            return tablaDA.Insert(empresaid,BE);
            //bool zreturn = tablaDA.Insert(empresaid, BE);
            //Sql_Error = tablaDA.Sql_Error;
            //return zreturn;
        }
        public bool Insert_Update(string empresaid, tb_cm_ordendecompradoc BE, DataTable Detalle)
        {
            //return tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
             bool zreturn = tablaDA.Insert_Update(empresaid, BE, Detalle);
            return zreturn;
        }

        //public bool Update(string empresaid, tb_cm_ordendecompra BE)
        //{
        //    //return tablaDA.Update(empresaid, BE);
        //    bool zreturn = tablaDA.Update(empresaid, BE);
        //    Sql_Error = tablaDA.Sql_Error;
        //    return zreturn;
        //}

        public bool Delete(string empresaid, tb_cm_ordendecompradoc BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        //public bool Eliminar(string empresaid, DataTable TablaDatos)
        //{
        //    //return tablaDA.Delete(empresaid, BE);
        //    bool zreturn = tablaDA.Eliminar(empresaid, TablaDatos);
        //    Sql_Error = tablaDA.Sql_Error;
        //    return zreturn;
        //}

        public DataSet GetAll(string empresaid, tb_cm_ordendecompradoc BE)
        {
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

      public DataSet GetAll_MaxCodigo(string empresaid, tb_cm_ordendecompradoc BE)
      {
            //return tablaDA.GetAll_MaxRubro(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_MaxCodigo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
      }

      public DataSet GetAll_CONSULTAIR(string empresaid, tb_cm_ordendecompradoc BE)
      {
          //return tablaDA.GetAll_CONSULTAIR(empresaid, BE);
          DataSet xreturn = null;
          xreturn = tablaDA.GetAll_CONSULTAIR(empresaid, BE);
          Sql_Error = tablaDA.Sql_Error;
          return xreturn;
      }

      public DataSet GetAll_CONSULTA(string empresaid, tb_cm_ordendecompradoc BE)
      {
          //return tablaDA.GetAll_CONSULTA(empresaid, BE);
          DataSet xreturn = null;
          xreturn = tablaDA.GetAll_CONSULTA(empresaid, BE);
          Sql_Error = tablaDA.Sql_Error;
          return xreturn;
      }
    }
}
