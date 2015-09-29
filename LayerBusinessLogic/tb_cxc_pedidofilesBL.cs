using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cxc_pedidofilesBL
    {
        tb_cxc_pedidofilesDA tablaDA = new tb_cxc_pedidofilesDA();

        public string Sql_Error = "";

        public bool Insert(string empresaid, tb_cxc_pedidofiles BE, byte[] data)
        {
            return tablaDA.Insert(empresaid, BE, data);
        }
        public bool Update(string empresaid, tb_cxc_pedidofiles BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cxc_pedidofiles BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cxc_pedidofiles BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAFile(string empresaid, String numdoc)
        {
            return tablaDA.GetAFile(empresaid, numdoc);
        }


    }
}
