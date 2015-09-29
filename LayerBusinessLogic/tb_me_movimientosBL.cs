using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_movimientosBL
    {
        tb_me_movimientosDA tablaDA = new tb_me_movimientosDA();

        public bool Insert(string empresaid, tb_me_movimientos BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_me_movimientos BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_me_movimientos BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetReport(string empresaid, tb_me_movimientos BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }

        public DataSet GetReportDetalle(string empresaid, tb_me_movimientos BE)
        {
            return tablaDA.GetReportDetalle(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_me_movimientoscab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_me_movimientoscab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetOne2(string empresaid, tb_me_movimientoscab BE)
        {
            return tablaDA.GetOne2(empresaid, BE);
        }

        public DataSet Sunat141_RegVentas(string empresaid, tb_me_movimientoscab BE)
        {
            return tablaDA.Sunat141_RegVentas(empresaid, BE);
        }

    }
}
