using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_parteprendaBL
    {
        tb_pp_parteprendaDA tablaDA = new tb_pp_parteprendaDA();

        public bool Insert(string empresaid, tb_pp_parteprenda BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_parteprenda BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pp_parteprenda BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pp_parteprenda BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }  
    }
}
