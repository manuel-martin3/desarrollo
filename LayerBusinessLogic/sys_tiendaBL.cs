using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class sys_tiendaBL
    {
        sys_tiendaDA tablaDA = new sys_tiendaDA();

        public bool Insert(string empresaid, tb_sys_tienda BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_sys_tienda BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_sys_tienda BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_sys_tienda BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_new(string empresaid, tb_sys_tienda BE)
        {
            return tablaDA.GetAll_new(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_sys_tienda BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
