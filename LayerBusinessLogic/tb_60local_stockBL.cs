using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60local_stockBL
    {
        tb_60local_stockDA tablaDA = new tb_60local_stockDA();

        public bool Insert(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet ConsumosProd(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.ConsumosProd(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, string moduloid, string local, string productid)
        {
            return tablaDA.GetOne(empresaid, moduloid, local, productid);
        }

        public bool ReorgAnioMes(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.ReorgAnioMes(empresaid, BE);
        }
        public bool ReorgAnio(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.ReorgAnio(empresaid, BE);
        }

        public bool ReorgTotal(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.ReorgTotal(empresaid, BE);
        }

        public bool CierreDePeriodo(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.CierreDePeriodo(empresaid, BE);
        }
        public bool CierreDePeriodoLogistica(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.CierreDePeriodoLogistica(empresaid, BE);
        }
        public bool Reorg_CostUlt(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.Reorg_CostUlt(empresaid, BE);
        }

        public DataSet GetAll_productostock(string empresaid, tb_60local_stock BE)
        {
            return tablaDA.GetAll_productostock(empresaid, BE);
        }

                
    }
}
