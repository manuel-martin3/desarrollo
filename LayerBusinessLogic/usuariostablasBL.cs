using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class usuariostablasBL
    {
        usuariostablasDA tablaDA = new usuariostablasDA();

        public bool Insert(string empresaid, tb_usuariostablas BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_usuariostablas BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_usuariostablas BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
    }
}
