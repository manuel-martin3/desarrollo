using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_tipooperacionBL
    {
        tb_tipooperacionDA tablaDA = new tb_tipooperacionDA();

        public bool Insert(string empresaid, tb_tipooperacion BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_tipooperacion BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_tipooperacion BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_tipooperacion BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string tipooperacionid)
        {
            return tablaDA.GetOne(empresaid, tipooperacionid);
        }
    }
}
