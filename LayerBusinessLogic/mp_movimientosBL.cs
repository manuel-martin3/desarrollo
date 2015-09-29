using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_movimientosBL
    {
        mp_movimientosDA tablaDA = new mp_movimientosDA();

        public bool Insert(string empresaid, tb_mp_movimientos BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_movimientos BE1, tb_mp_movimientos BE2, String cabecera)
        {
            return tablaDA.Update(empresaid, BE1, BE2, cabecera);
        }
        public bool Delete(string empresaid, tb_mp_movimientos BE1, tb_mp_movimientos BE2)
        {
            return tablaDA.Delete(empresaid, BE1,BE2);
        }
        public DataSet GetAll(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetOne2(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetOne2(empresaid, BE);
        }

    }
}
