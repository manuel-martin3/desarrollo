using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class vendedor_corporativoBL
    {
        vendedor_corporativoDA tablaDA = new vendedor_corporativoDA();

        public bool Insert(string empresaid, tb_vendedor_corporativo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_vendedor_corporativo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_vendedor_corporativo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_vendedor_corporativo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string vendorid)
        {
            return tablaDA.GetOne(empresaid, vendorid);
        }
    }
}
