using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class pp_ordenproduccioncabBL
    {
        pp_ordenproduccioncabDA tablaDA = new pp_ordenproduccioncabDA();

        public bool Insert(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pp_ordenproduccioncab BE)
        {
            return tablaDA.Delete(empresaid, BE);
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
