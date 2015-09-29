using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_local_stock_inventario_rollo_cargaBL
    {
        mp_local_stock_inventario_rollo_cargaDA tablaDA = new mp_local_stock_inventario_rollo_cargaDA();

        public bool Insert(string empresaid, tb_mp_local_stock_inventario_rollo_carga BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_local_stock_inventario_rollo_carga BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_local_stock_inventario_rollo_carga BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_local_stock_inventario_rollo_carga BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_DISTINDOC(string empresaid, tb_mp_local_stock_inventario_rollo_carga BE)
        {
            return tablaDA.GetAll_DISTINDOC(empresaid, BE);
        }        
        public DataSet GetOne(string empresaid, tb_mp_local_stock_inventario_rollo_carga BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetOne_rollodoc(string empresaid, tb_mp_local_stock_inventario_rollo_carga BE)
        {
            return tablaDA.GetOne_rollodoc(empresaid, BE);
        }       
    }
}
