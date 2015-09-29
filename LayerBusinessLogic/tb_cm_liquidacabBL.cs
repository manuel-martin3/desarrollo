using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cm_liquidacabBL
    {
        tb_cm_liquidacabDA tablaDA = new tb_cm_liquidacabDA();

       public bool Insert(string empresaid, tb_cm_liquidacab BE, DataTable dt)
       {
           return tablaDA.Insert(empresaid, BE, dt);
       }

       public bool Update(string empresaid, tb_cm_liquidacab BE, DataTable dt)
       {
           return tablaDA.Update(empresaid, BE, dt);
       }
       public bool Delete(string empresaid, tb_cm_liquidacab BE)
       {
           return tablaDA.Delete(empresaid, BE);
       }
       public List<tb_cm_liquidacab> Get_all(string empresaid, tb_cm_liquidacab BE)
       {
           return tablaDA.Get_all(empresaid, BE).ToList();
       }

       public DataSet GetAll_paginacion(string empresaid, tb_cm_liquidacab BE)
       {
           return tablaDA.GetAll_paginacion(empresaid, BE);
       }

       public List<tb_cm_liquidacab> Get_equivalencia(string empresaid, tb_cm_liquidacab BE)
       {
           return  tablaDA.Get_equivalencia(empresaid, BE).ToList();
       }

       public DataTable GetOne_Shear(string empresaid, Decimal BE) 
       {
           return tablaDA.GetOne_Shear(empresaid, BE);
       }

       public List<tb_cm_liquidacab> Get_xcodigo(string empresaid, tb_cm_liquidacab BE)
       {
           return tablaDA.Get_xcodigo(empresaid, BE).ToList();
       }
     
    }
}
