using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_familiadetBL
    {
        tb_pt_familiadetDA tablaDA = new tb_pt_familiadetDA();

        public bool Insert(string empresaid, tb_pt_familiadet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_familiadet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_familiadet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_familiadet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_pt_familiadet BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_pt_familiadet BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string familiateladetid)
        {
            return tablaDA.GetOne(empresaid, familiateladetid);
        }
    }
}
