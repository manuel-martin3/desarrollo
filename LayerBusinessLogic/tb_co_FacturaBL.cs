using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_FacturaBL
    {
        tb_co_FacturaDA tablaDA = new tb_co_FacturaDA();

        public bool Insert(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAsientoNume(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.GetAsientoNume(empresaid, BE);
        }

        public DataSet GetAllDet(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.GetAllDet(empresaid, BE);
        }
    

        public DataSet RenameVenta(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.RenameVenta(empresaid, BE);
        }
        
        public DataSet GetAllIncoterms_Cab(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.GetAllIncoterms_Cab(empresaid, BE);
        }
        public DataSet GetAllIncoterms_Det(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.GetAllIncoterms_Det(empresaid, BE);
        }

        public DataSet ReporteRegistroVenta(string empresaid, tb_co_Factura BE)
        {
            return tablaDA.ReporteRegistroVenta(empresaid, BE);
        }


        //public DataSet GetOne(string empresaid, tb_co_Factura BE)
        //{
        //    return tablaDA.GetOne(empresaid, BE);
        //}
    }
}
