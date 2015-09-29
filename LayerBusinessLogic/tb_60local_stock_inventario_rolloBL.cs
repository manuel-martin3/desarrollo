using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60local_stock_inventario_rolloBL
    {
        tb_60local_stock_inventario_rolloDA tablaDA = new tb_60local_stock_inventario_rolloDA();

        public bool Insert(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update_digitar(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.Update_digitar(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public bool GetAll_TRANSFERIR(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAll_TRANSFERIR(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetAll_Rollo(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAll_Rollo(empresaid, BE);
        }
        public DataSet GetAllDifRollos(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAllDifRollos(empresaid, BE);
        }
        public DataSet GetAllDifRollos_gen(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAllDifRollos_gen(empresaid, BE);
        }
        public DataSet GetAllUbigeoRollos(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAllUbigeoRollos(empresaid, BE);
        }
        public DataSet GetAllUbigeoRollos_gen(string empresaid, tb_60local_stock_inventario_rollo BE)
        {
            return tablaDA.GetAllUbigeoRollos_gen(empresaid, BE);
        }

    }
}
