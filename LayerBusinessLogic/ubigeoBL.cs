using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class ubigeoBL
    {
        ubigeoDA tablaDA = new ubigeoDA();

        public bool Insert(string empresaid, tb_ubigeo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_ubigeo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_ubigeo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_ubigeo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_depar(string empresaid, tb_ubigeo BE)
        {
            return tablaDA.GetAll_depar(empresaid, BE);
        }
        public DataSet GetAll_provi(string empresaid, tb_ubigeo BE)
        {
            return tablaDA.GetAll_provi(empresaid, BE);
        }
        public DataSet GetAll_distr(string empresaid, tb_ubigeo BE)
        {
            return tablaDA.GetAll_distr(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string ubigeoid)
        {
            return tablaDA.GetOne(empresaid, ubigeoid);
        }
    }
}
