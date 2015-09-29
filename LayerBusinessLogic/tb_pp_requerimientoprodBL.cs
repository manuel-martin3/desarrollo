using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_requerimientoprodBL
    {
        tb_pp_requerimientoprodDA tablaDA = new tb_pp_requerimientoprodDA();

        public bool Insert(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
      
        public bool Update(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
      
        public bool Delete(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll_NUM(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.GetAll_NUM(empresaid, BE);
        }

        public DataSet GetAllCab(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.GetAllCab(empresaid, BE);
        }

        public DataSet GetAllDet(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.GetAllDet(empresaid, BE);
        }

        public DataSet GetAllOrden_PIVOT(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.GetAllOrden_PIVOT(empresaid, BE);
        }

        public DataSet GetAllPropColor_PIVOT(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.GetAllPropColor_PIVOT(empresaid, BE);
        }

        public DataSet GetAll_RptProd(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.GetAll_RptProd(empresaid, BE);
        }

        public DataSet GetOne_Tallaid(string empresaid, tb_pp_requerimientoprod BE)
        {
            return tablaDA.GetOne_Tallaid(empresaid, BE);
        }
    }
}
