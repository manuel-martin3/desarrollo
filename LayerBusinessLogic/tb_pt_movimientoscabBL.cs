using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_movimientoscabBL
    {
        tb_pt_movimientoscabDA tablaDA = new tb_pt_movimientoscabDA();

        public bool Insert(string empresaid, tb_pt_movimientoscab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_movimientoscab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_movimientoscab BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_movimientoscab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_pedidos(string empresaid, tb_pt_movimientoscab BE)
        {
            return tablaDA.GetAll_pedidos(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_pt_movimientoscab BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_pt_movimientoscab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
