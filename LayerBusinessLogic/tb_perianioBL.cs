using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
   public class tb_perianioBL
    {
       tb_perianioDA tablaDA = new tb_perianioDA();
       public List<tb_perianio> Get_anio(string empresaid) 
       {
           return tablaDA.Get_anio(empresaid);
       }
    }
}
