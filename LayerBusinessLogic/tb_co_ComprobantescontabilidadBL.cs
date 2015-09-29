using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_ComprobantescontabilidadBL
    {
        tb_co_ComprobantescontabilidadDA tablaDA = new tb_co_ComprobantescontabilidadDA();

        public bool Insert(string empresaid, tb_co_Comprobantescontabilidad BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_Comprobantescontabilidad BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_Comprobantescontabilidad BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_Comprobantescontabilidad BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string codigoid)
        {
            return tablaDA.GetOne(empresaid, codigoid);
        }
    }
}
