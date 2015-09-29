using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cm_liquidadetBL
    {
        tb_cm_liquidadetDA tablaDA = new tb_cm_liquidadetDA();
       
       public DataSet GetAll(string empresaid, tb_cm_liquidadet BE)
       {
           return tablaDA.GetAll(empresaid, BE);
       }

       public bool Delete(string empresaid, tb_cm_liquidadet BE)
       {
           return tablaDA.Delete(empresaid, BE);
       }

    }
}
