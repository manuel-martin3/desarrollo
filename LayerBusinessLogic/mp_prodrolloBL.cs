using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_prodrolloBL
    {
        mp_prodrolloDA tablaDA = new mp_prodrolloDA();

        public bool Insert(string empresaid, tb_mp_prodrollo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_prodrollo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_prodrollo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_prodrollo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_prod(string empresaid, tb_mp_prodrollo BE)
        {
            return tablaDA.GetAll_prod(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string rollo)
        {
            return tablaDA.GetOne(empresaid, rollo);
        }
    }
}
