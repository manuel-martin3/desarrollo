using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cp_canalventaBL
    {
        tb_cp_canalventaDA tablaDA = new tb_cp_canalventaDA();

        public bool Insert(string empresaid, tb_cp_canalventa BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cp_canalventa BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cp_canalventa BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_cp_canalventa BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll2(string empresaid, tb_cp_canalventa BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, tb_cp_canalventa BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }


    }
}
