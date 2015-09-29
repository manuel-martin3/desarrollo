using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cm_conceptoBL
    {
        tb_cm_conceptoDA tablaDA = new tb_cm_conceptoDA();

        public string Sql_Error = "";

        public bool Insert(string empresaid, tb_cm_conceptos BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cm_conceptos BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cm_conceptos BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cm_conceptos BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        //public String GetNextCod(string empresaid, tb_cm_conceptos BE)
        //{
        //    return tablaDA.GetNextCod(empresaid, BE);
        //}
        //public DataSet GetAll_direc(string empresaid, tb_cm_conceptos BE)
        //{
        //    return tablaDA.GetAll_direc(empresaid, BE);
        //}

        public DataSet Upload_row(string empresaid, tb_cm_conceptos BE)
        {
            return tablaDA.Upload_row(empresaid, BE);
        }

    }
}
