using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_ordenservicioBL
    {
        tb_pp_ordenservicioDA tablaDA = new tb_pp_ordenservicioDA();

        public bool Insert(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool Update(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll_NUM(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.GetAll_NUM(empresaid, BE);
        }       

        public DataSet GetAllOrden_PIVOT(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.GetAllOrden_PIVOT(empresaid, BE);
        }

        public DataSet GetAllPropColor_PIVOT(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.GetAllPropColor_PIVOT(empresaid, BE);
        }

        public DataSet GetAllCab(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.GetAllCab(empresaid, BE);
        }

        public DataSet GetAllDet(string empresaid, tb_pp_ordenservicio BE)
        {
            return tablaDA.GetAllDet(empresaid, BE);
        }
        

    }
}
