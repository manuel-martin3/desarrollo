using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_t1_cajaBL
    {
        tb_t1_cajaDA tablaDA = new tb_t1_cajaDA();

        public string Sql_Error = "";

        public bool Insert(string empresaid, tb_t1_caja BE, DataTable Datos)
        {
            return tablaDA.Insert(empresaid, BE, Datos);
        }

        public bool Update(string empresaid, tb_t1_caja BE, DataTable Datos)
        {
            return tablaDA.Update(empresaid, BE, Datos);
        }

        public bool UpdateApertura(string empresaid, tb_t1_caja BE)
        {
            return tablaDA.UpdateApertura(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_t1_caja BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet DetalleActual(string empresaid, tb_t1_caja BE)
        {
            return tablaDA.DetalleActual(empresaid, BE);
        }

        public DataSet GetAllCab(string empresaid, tb_t1_caja BE)
        {
            return tablaDA.GetAllCab(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_t1_caja BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_t1_caja BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
    }
}
