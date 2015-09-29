using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_px_promocionesBL
    {
        tb_px_promocionesDA tablaDA = new tb_px_promocionesDA();

        public bool Insert(string empresaid, tb_px_promociones BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_px_promociones BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_px_promociones BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_px_promociones BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetFiltro(string empresaid, tb_px_promociones BE)
        {
            return tablaDA.GetFiltro(empresaid, BE);
        }

        public DataSet GetAll_paginacion(string empresaid, tb_px_promociones BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
      
    }
}
