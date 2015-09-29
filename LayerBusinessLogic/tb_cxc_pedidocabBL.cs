using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cxc_pedidocabBL
    {
        tb_cxc_pedidocabDA tablaDA = new tb_cxc_pedidocabDA();

        public string Sql_Error = "";

        public bool Insert(string empresaid, tb_cxc_pedidocab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
		 public bool Update_Estado(string empresaid, tb_cxc_pedidocab BE)
        {
            return tablaDA.Update_Estado(empresaid, BE);
        }
		
        public bool Update(string empresaid, tb_cxc_pedidocab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cxc_pedidocab BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cxc_pedidocab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll2(string empresaid, tb_cxc_pedidocab BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }

        public DataSet GetNewNumDoc(string empresaid, tb_cxc_pedidocab BE)
        {
            return tablaDA.GetNewNumDoc(empresaid, BE);
        }       

    }
}
