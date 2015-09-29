using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class empresaperiodoperiodoBL
    {
        empresaperiodoDA tablaDA = new empresaperiodoDA();

        public bool Insert(tb_empresaperiodo BE)
        {
            return tablaDA.Insert(BE);
        }
        public bool Update(tb_empresaperiodo BE)
        {
            return tablaDA.Update(BE);
        }
        public bool Delete(tb_empresaperiodo BE)
        {
            return tablaDA.Delete(BE);
        }
        public DataSet GetAll(tb_empresaperiodo BE)
        {
            return tablaDA.GetAll(BE);
        }
        public DataSet GetOne(string empresaid, string periodo)
        {
            return tablaDA.GetOne(empresaid, periodo);
        }
    }
}
