using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_productosBL
    {
        mp_productosDA tablaDA = new mp_productosDA();

        public bool Insert(string empresaid, tb_mp_productos BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_productos BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update2(string empresaid, tb_mp_productos BE)
        {
            return tablaDA.Update2(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_productos BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_productos BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_mp_productos BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string productid)
        {
            return tablaDA.GetOne(empresaid, productid);
        }
        public DataSet GetAll_MaxMin(string empresaid)
        {
            return tablaDA.GetAll_MaxMin(empresaid);
        }
    }
}
