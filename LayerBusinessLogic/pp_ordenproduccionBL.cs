using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class pp_ordenproduccionBL
    {
        pp_ordenproduccionDA tablaDA = new pp_ordenproduccionDA();

        public bool Insert(string empresaid, tb_pp_ordenproduccion BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_ordenproduccion BE1, tb_pp_ordenproduccion BE2)
        {
            return tablaDA.Update(empresaid, BE1, BE2);
        }
        public bool Update_aprobado(string empresaid, tb_pp_ordenproduccion BE1)
        {
            return tablaDA.Update_aprobado(empresaid, BE1);
        }
        public bool Delete(string empresaid, tb_pp_ordenproduccion BE1)
        {
            return tablaDA.Delete(empresaid, BE1);
        }
        public DataSet GetAll(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
