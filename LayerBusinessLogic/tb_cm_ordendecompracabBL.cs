using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cm_ordendecompracabBL
    {
        tb_cm_ordendecompracabDA tablaDA = new tb_cm_ordendecompracabDA();

        public bool Insert(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        //*** OP
        public DataSet GetAll(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_CabDet(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.GetAll_CabDet(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        
        public DataSet GetOne_numdocs(string empresaid, tb_cm_ordendecompracab BE)
        {
            return tablaDA.GetOne_numdocs(empresaid, BE);
        }
    }
}
