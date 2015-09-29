using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_local_stock_inventario_rolloBL
    {
        mp_local_stock_inventario_rolloDA tablaDA = new mp_local_stock_inventario_rolloDA();

        public bool Insert(string empresaid, tb_mp_local_stock_inventario_rollo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_local_stock_inventario_rollo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_local_stock_inventario_rollo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public bool GetAll__SUMARIZAR(string empresaid, tb_mp_local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAll__SUMARIZAR(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_mp_local_stock_inventario_rollo BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
