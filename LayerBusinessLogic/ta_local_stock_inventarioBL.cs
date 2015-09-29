using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class ta_local_stock_inventarioBL
    {
        ta_local_stock_inventarioDA tablaDA = new ta_local_stock_inventarioDA();

        public bool Insert(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update_digitar(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.Update_digitar(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_listar(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.GetAll_listar(empresaid, BE);
        }
        public bool GetAll_INICIALIZAR(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.GetAll_INICIALIZAR(empresaid, BE);
        }
        public bool GetAll_AjusteInventario_rollos(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.GetAll_AjusteInventario_rollos(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_ta_local_stock_inventario BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
