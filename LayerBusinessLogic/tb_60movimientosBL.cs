using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60movimientosBL
    {
        tb_60movimientosDA tablaDA = new tb_60movimientosDA();

        public bool Insert(string empresaid, tb_60movimientos BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_60movimientos BE)
         {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_60movimientos BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetReport(string empresaid, tb_60movimientos BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetOne2(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetOne2(empresaid, BE);
        }

        public DataSet GetvalidaMov(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetvalidaMov(empresaid, BE);
        }

    }
}
