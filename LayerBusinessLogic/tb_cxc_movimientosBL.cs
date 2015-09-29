using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cxc_movimientosBL
    {
        tb_cxc_movimientosDA tablaDA = new tb_cxc_movimientosDA();

        public string Sql_Error = "";

        public bool Insert(string empresaid, tb_cxc_movimientos BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }      

        public bool Update(string empresaid, tb_cxc_movimientos BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_cxc_movimientos BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_cxc_movimientos BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

            

    }
}
