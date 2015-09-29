using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_tabla12_toperacionalmacenBL
    {
        tb_co_tabla12_toperacionalmacenDA tablaDA = new tb_co_tabla12_toperacionalmacenDA();
        List<tb_co_tabla12_toperacionalmacenDA> carga = new List<tb_co_tabla12_toperacionalmacenDA>();

        public bool Insert(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }

        public List<tb_co_tabla12_toperacionalmacen> CargarCombo(string empresaid, tb_co_tabla12_toperacionalmacen BE)
        {
            return tablaDA.CargarCombo(empresaid, BE);
        }

    }
}
