using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_pedidosdetBL
    {
        tb_pt_pedidosdetDA tablaDA = new tb_pt_pedidosdetDA();

        public bool Insert(string empresaid, tb_pt_pedidosdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_pedidosdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_pedidosdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_pedidosdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_pt_pedidosdet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
