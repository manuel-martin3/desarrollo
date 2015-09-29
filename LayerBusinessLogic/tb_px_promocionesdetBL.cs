using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_px_promocionesdetBL
    {
        tb_px_promocionesdetDA tablaDA = new tb_px_promocionesdetDA();

        public bool Insert(string empresaid, tb_px_promocionesdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool InsertDet(string empresaid, tb_px_promocionesdet BE)
        {
            return tablaDA.InsertDet(empresaid, BE);
        }
        public bool Update(string empresaid, tb_px_promocionesdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_px_promocionesdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public bool Delete2(string empresaid, tb_px_promocionesdet BE)
        {
            return tablaDA.Delete2(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_px_promocionesdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_px_promocionesdet BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

    }
}
