using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class sys_localBL
    {
        sys_localDA tablaDA = new sys_localDA();

        public bool Insert(string empresaid, tb_sys_local BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_sys_local BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_sys_local BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_sys_local BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string dominioid, string moduloid, string local)
        {
            return tablaDA.GetOne(empresaid, dominioid, moduloid, local);
        }

        public DataSet GenCodigo(string empresaid, tb_sys_local BE)
        {
            return tablaDA.GenCodigo(empresaid, BE);
        }

    }
}
