using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_t1_cajaconceptoBL
    {
        tb_t1_cajaconceptoDA tablaDA = new tb_t1_cajaconceptoDA();

        public bool Insert(string empresaid, tb_t1_cajaconcepto BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_t1_cajaconcepto BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_t1_cajaconcepto BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_t1_cajaconcepto BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_t1_cajaconcepto BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
