using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_local_stock_inventarioBL
    {
        mp_local_stock_inventarioDA tablaDA = new mp_local_stock_inventarioDA();

        public bool Insert(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update_digitar(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.Update_digitar(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_listar(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.GetAll_listar(empresaid, BE);
        }
        public bool GetAll_INICIALIZAR(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.GetAll_INICIALIZAR(empresaid, BE);
        }
        public bool GetAll_AjusteInventario(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.GetAll_AjusteInventario(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_mp_local_stock_inventario BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
