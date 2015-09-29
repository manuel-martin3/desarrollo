using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_ejecutorBL
    {
        tb_pp_ejecutorDA tablaDA = new tb_pp_ejecutorDA();

        public bool Insert(string empresaid, tb_pp_ejecutor BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_ejecutor BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
       
        public bool Delete(string empresaid, tb_pp_ejecutor BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pp_ejecutor BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string articid)
        {
            return tablaDA.GetOne(empresaid, articid);
        }
        
    }
}
