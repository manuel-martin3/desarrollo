using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_lineaBL
    {
        tb_pt_lineaDA tablaDA = new tb_pt_lineaDA();

        public bool Insert(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_dbf(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.Insert_dbf(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update_dbf(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.Update_dbf(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public bool Delete_dbf(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.Delete_dbf(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_CODdbf(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.GetAll_CODdbf(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_pt_linea BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, string lineaid)
        {
            return tablaDA.GetOne(empresaid, lineaid);
        }
    }
}
