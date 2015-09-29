using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_stockdiariocabBL
    {
        tb_me_stockdiariocabDA tablaDA = new tb_me_stockdiariocabDA();

        public DataSet GetAllStkDisp(string empresaid, tb_me_stockdiariocab BE)
        {
            return tablaDA.GetAllStkDisp(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_me_stockdiariocab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll_Grid(string empresaid, tb_me_stockdiariocab BE)
        {
            return tablaDA.GetAll_Grid(empresaid, BE);
        }
        public DataSet GetAll_StockProdDet(string empresaid, tb_me_stockdiariocab BE)
        {
            return tablaDA.GetAll_StockProdDet(empresaid, BE);
        }
		public DataSet GetAll_StockDisp(string empresaid, tb_me_stockdiariocab BE)
        {
            return tablaDA.GetAll_StockDisp(empresaid, BE);
        }
        public bool InsertStk(string empresaid, tb_me_stockdiariocab BE)
        {
            return tablaDA.InsertStk(empresaid, BE);
        }

    }
}
