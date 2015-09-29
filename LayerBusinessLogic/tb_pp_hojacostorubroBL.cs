using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_hojacostorubroBL
    {
        tb_pp_hojacostorubroDA tablaDA = new tb_pp_hojacostorubroDA();

        public bool Insert(string empresaid, tb_pp_hojacostorubro BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_hojacostorubro BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pp_hojacostorubro BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_pp_hojacostorubro BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }      
        public DataSet GetOne(string empresaid, string categoriaid)
        {
            return tablaDA.GetOne(empresaid, categoriaid);
        }
    }
}
