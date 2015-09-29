using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
   public  class tb_cm_equivalenciaBL
    {
       tb_cm_equivalenciaDA tablaDA = new tb_cm_equivalenciaDA();
       
       public bool Insert(string empresaid, tb_cm_equivalencia BE)
       {
           return tablaDA.Insert(empresaid, BE);
       }
       public bool Update(string empresaid, tb_cm_equivalencia BE)
       {
           return tablaDA.Update(empresaid, BE);
       }
       public bool Delete(string empresaid, tb_cm_equivalencia BE)
       {
           return tablaDA.Delete(empresaid, BE);
       }
       public List<tb_cm_equivalencia> Get_all(string empresaid, tb_cm_equivalencia BE)
       {
           return tablaDA.Get_all(empresaid, BE).ToList();
       }

       public List<tb_cm_equivalencia> Get_equivalencia(string empresaid, tb_cm_equivalencia BE)
       {
           return  tablaDA.Get_equivalencia(empresaid, BE).ToList();
       }

       public DataTable GetOne_Shear(string empresaid, Decimal BE) 
       {
           return tablaDA.GetOne_Shear(empresaid, BE);
       }

       public List<tb_cm_equivalencia> Get_xcodigo(string empresaid, tb_cm_equivalencia BE)
       {
           return tablaDA.Get_xcodigo(empresaid, BE).ToList();
       }
     
    }
}
