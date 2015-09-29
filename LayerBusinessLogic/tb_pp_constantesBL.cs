using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_constantesBL
    {
        tb_pp_constantesDA tablaDA = new tb_pp_constantesDA();

        public bool Insert(string empresaid, tb_pp_constantes BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_constantes BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pp_constantes BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_pp_constantes BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }      

        public DataSet GetOne(string empresaid, string categoriaid)
        {
            return tablaDA.GetOne(empresaid, categoriaid);
        }
    }
}
