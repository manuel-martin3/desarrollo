using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60subgrupoBL
    {
        tb_60subgrupoDA tablaDA = new tb_60subgrupoDA();

        public bool Insert(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_Marca(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.Insert_Marca(empresaid, BE);
        }
        public bool Update(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update_Marca(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.Update_Marca(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public bool Delete_Marca(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.Delete_Marca(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetReport(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_60subgrupo BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
