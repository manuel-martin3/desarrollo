using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_plancontableBL
    {
        public string Sql_Error = "";
        tb_co_plancontableDA tablaDA = new tb_co_plancontableDA();

        public bool Insert(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.Update(empresaid, BE);
        }
        public bool UpdateDJ(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.UpdateDJ(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll_PCEDJ(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetAll_PCEDJ(empresaid, BE);
        }
        public DataSet GetAll_NPCEDJ(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetAll_NPCEDJ(empresaid, BE);
        }

        public DataSet GetAll_IR(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetAll_IR(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_plancontable BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetOne(empresaid, BE);
        }
        public Boolean Generar(string empresaid, string perianio_ini, string perianio_fin)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.Generar(empresaid, perianio_ini, perianio_fin);
        }
    }
}
