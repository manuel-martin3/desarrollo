using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_tabla07_tipointangibleBL
    {
        tb_co_tabla07_tipointangibleDA tablaDA = new tb_co_tabla07_tipointangibleDA();

        public bool Insert(string empresaid, tb_co_tabla07_tipointangible BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_tabla07_tipointangible BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_tabla07_tipointangible BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_tabla07_tipointangible BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string codigoid)
        {
            return tablaDA.GetOne(empresaid, codigoid);
        }
    }
}
