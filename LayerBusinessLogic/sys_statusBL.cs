using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class sys_statusBL
    {
        sys_statusDA tablaDA = new sys_statusDA();

        public bool Insert(string empresaid, tb_sys_status BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_sys_status BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_sys_status BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_sys_status BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string dominioid, string moduloid, string local)
        {
            return tablaDA.GetOne(empresaid, dominioid, moduloid, local);
        }
    }
}
