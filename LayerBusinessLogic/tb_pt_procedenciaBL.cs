using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_procedenciaBL
    {
        tb_pt_procedenciaDA tablaDA = new tb_pt_procedenciaDA();

        public bool Insert(string empresaid, tb_pt_procedencia BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_procedencia BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_procedencia BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_procedencia BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string procedenciaid)
        {
            return tablaDA.GetOne(empresaid, procedenciaid);
        }
    }
}
