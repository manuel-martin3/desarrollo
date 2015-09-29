using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_perimesBL
    {
        tb_perimesDA tablaDA = new tb_perimesDA();
        public List<tb_perimes> Get_Mes(string empresaid) 
       {
           return tablaDA.Get_Mes(empresaid);
       }

    }
}
