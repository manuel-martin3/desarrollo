using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cp_comercialtallasBL
    {
        tb_cp_comercialtallasDA tablaDA = new tb_cp_comercialtallasDA();

        public bool Insert(string empresaid, tb_cp_comercialtallas BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cp_comercialtallas BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cp_comercialtallas BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cp_comercialtallas BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_cp_comercialtallas BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
