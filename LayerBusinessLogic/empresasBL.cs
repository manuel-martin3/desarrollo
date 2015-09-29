using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    
    public class empresasBL
    {                

        empresaDA tablaDA = new empresaDA();

        public bool Insert(tb_empresa BE)
        {
            return tablaDA.Insert(BE);
        }
        public bool Update(tb_empresa BE)
        {
            return tablaDA.Update(BE);
        }
        public bool Delete(tb_empresa BE)
        {
            return tablaDA.Delete(BE);
        }
        public bool CrearBase_sdf(string BE)
        {
            return tablaDA.CrearBase_sdf(BE);
        }
        public DataSet GetAll(tb_empresa BE)
        {
            return tablaDA.GetAll(BE);
        }
        public DataSet GetOne(string empresaid)
        {
            return tablaDA.GetOne(empresaid);
        }
    }
}
