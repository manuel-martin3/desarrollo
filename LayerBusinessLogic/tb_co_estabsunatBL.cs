using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_estabsunatBL
    {
        tb_co_estabsunatDA tablaDA = new tb_co_estabsunatDA();

        public bool Insert(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetAll_numgenerado(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.GetAll_numgenerado(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

        public DataSet GetNumComprob(string empresaid, tb_co_estabsunat BE)
        {
            return tablaDA.GetNumComprob(empresaid, BE);
        }
    }
}
