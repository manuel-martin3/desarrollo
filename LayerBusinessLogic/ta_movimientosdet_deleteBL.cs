using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class ta_movimientosdet_deleteBL
    {
        ta_movimientosdet_deleteDA tablaDA = new ta_movimientosdet_deleteDA();

        public bool Insert(string empresaid, tb_ta_movimientosdet_delete BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_ta_movimientosdet_delete BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_ta_movimientosdet_delete BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_ta_movimientosdet_delete BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_ta_movimientosdet_delete BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
