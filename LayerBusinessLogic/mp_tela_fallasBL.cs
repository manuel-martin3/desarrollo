using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_tela_fallasBL
    {
        mp_tela_fallasDA tablaDA = new mp_tela_fallasDA();

        public bool Insert(string empresaid, tb_mp_tela_fallas BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_tela_fallas BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_tela_fallas BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_tela_fallas BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string fallaid)
        {
            return tablaDA.GetOne(empresaid, fallaid);
        }
    }
}
