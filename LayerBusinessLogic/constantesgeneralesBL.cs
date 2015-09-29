using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class constantesgeneralesBL
    {
        constantesgeneralesDA tablaDA = new constantesgeneralesDA();

        public bool Insert(string empresaid, tb_constantesgenerales BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_constantesgenerales BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_constantesgenerales BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_constantesgenerales BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string dominioid, string moduloid, string local)
        {
            return tablaDA.GetOne(empresaid, dominioid, moduloid, local);
        }
    }
}
