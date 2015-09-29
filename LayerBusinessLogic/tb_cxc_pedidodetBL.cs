using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cxc_pedidodetBL
    {
        tb_cxc_pedidodetDA tablaDA = new tb_cxc_pedidodetDA();

        public string Sql_Error = "";

        public bool Insert(string empresaid, tb_cxc_pedidodet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cxc_pedidodet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cxc_pedidodet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cxc_pedidodet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAllSerdoc(string empresaid, tb_cxc_pedidodet BE)
        {
            return tablaDA.GetAllSerdoc(empresaid, BE);
        }

        public DataSet Upload_row(string empresaid, tb_cxc_pedidodet BE)
        {
            return tablaDA.Upload_row(empresaid, BE);
        }

    }
}
