using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_MovimientosdetBL
    {
        public string Sql_Error = "";
        tb_co_MovimientosdetDA tablaDA = new tb_co_MovimientosdetDA();

        public bool Insert(string empresaid, tb_co_Movimientosdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_Movimientosdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_Movimientosdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_Movimientosdet BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet zreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetAsientoVoucher(string empresaid, tb_co_Movimientosdet BE)
        {
            return tablaDA.GetAsientoVoucher(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, tb_co_Movimientosdet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
