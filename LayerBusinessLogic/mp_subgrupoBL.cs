using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_subgrupoBL
    {
        mp_subgrupoDA tablaDA = new mp_subgrupoDA();

        public bool Insert(string empresaid, tb_mp_subgrupo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_subgrupo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_subgrupo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_subgrupo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string lineaid, string grupoid, string subgrupoid)
        {
            return tablaDA.GetOne(empresaid, lineaid, grupoid, subgrupoid);
        }
    }
}
