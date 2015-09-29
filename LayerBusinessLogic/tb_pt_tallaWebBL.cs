using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_tallaWebBL
    {
        tb_pt_tallaWebDA tablaDA = new tb_pt_tallaWebDA();

        public bool Insert(string empresaid, tb_pt_talla BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_talla BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_talla BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_talla BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_pt_talla BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetAll_vertical(string empresaid, tb_pt_talla BE)
        {
            return tablaDA.GetAll_vertical(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string tallaid)
        {
            return tablaDA.GetOne(empresaid, tallaid);
        }
    }
}
