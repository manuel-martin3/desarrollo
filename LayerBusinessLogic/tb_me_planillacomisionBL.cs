using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_planillacomisionBL
    {
        tb_me_planillacomisionDA tablaDA = new tb_me_planillacomisionDA();

        public bool Insert(string empresaid, tb_me_planillacomision BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_me_planillacomision BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_me_planillacomision BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_me_planillacomision BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_me_planillacomision BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_me_planillacomision BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }      
        public DataSet GetOne(string empresaid, tb_me_planillacomision BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
