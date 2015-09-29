using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_comprador_corporativoBL
    {
        tb_comprador_corporativoDA tablaDA = new tb_comprador_corporativoDA();

        public bool Insert(string empresaid, tb_comprador_corporativo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_comprador_corporativo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_comprador_corporativo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_comprador_corporativo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string compradorid)
        {
            return tablaDA.GetOne(empresaid, compradorid);
        }
    }
}
