using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_ComprasdetBL
    {
        tb_co_ComprasdetDA tablaDA = new tb_co_ComprasdetDA();

        public bool Insert(string empresaid, tb_co_Comprasdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_Comprasdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_Comprasdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_Comprasdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAsientoNume(string empresaid, tb_co_Comprasdet BE)
        {
            return tablaDA.GetAsientoNume(empresaid, BE);
        }
        public DataSet GetGeneraPDBCompras(string empresaid, tb_co_Comprasdet BE)
        {
            return tablaDA.GetGeneraPDBCompras(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_Comprasdet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
