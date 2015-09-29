using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_proyeccionBL
    {
        tb_me_proyeccionDA tablaDA = new tb_me_proyeccionDA();

        public bool Insert(string empresaid, tb_me_proyeccion BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_me_proyeccion BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_me_proyeccion BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_me_proyeccion BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_DET(string empresaid, tb_me_proyeccion BE)
        {
            return tablaDA.GetAll_DET(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string lineaid)
        {
            return tablaDA.GetOne(empresaid, lineaid);
        }
    }
}
