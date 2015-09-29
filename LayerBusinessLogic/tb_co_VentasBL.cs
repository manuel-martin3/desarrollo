using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_VentasBL
    {
        public String Sql_Error = "";
        tb_co_VentasDA tablaDA = new tb_co_VentasDA();

        public bool Insert(string empresaid, tb_co_Ventas BE)
        {       
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool Insert_ImportaExcel(string empresaid, tb_co_Ventas BE)
        {
            bool zreturn = tablaDA.Insert_ImportaExcel(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool Update(string empresaid, tb_co_Ventas BE)
        {
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool DELETE_ImportaExcel(string empresaid, tb_co_Ventas BE)
        {
            bool zreturn = tablaDA.DELETE_ImportaExcel(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Delete(string empresaid, tb_co_Ventas BE)
        {
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        //public DataSet GetAll(string empresaid, tb_co_Ventas BE)
        //{
        //    return tablaDA.GetAll(empresaid, BE);
        //}
        //public DataSet GetAsientoNume(string empresaid, tb_co_Ventas BE)
        //{
        //    return tablaDA.GetAsientoNume(empresaid, BE);
        //}
        public DataSet RenameVenta(string empresaid, tb_co_Ventas BE)
        {
            DataSet zreturn = tablaDA.RenameVenta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet ReporteRegistroVenta(string empresaid, tb_co_Ventas BE)
        {           
            DataSet zreturn = tablaDA.ReporteRegistroVenta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet ReporteRegVentaResumen(string empresaid, tb_co_Ventas BE)
        {
            DataSet zreturn = tablaDA.ReporteRegVentaResumen(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet ReporteRegVentaAnalitico(string empresaid, tb_co_Ventas BE)
        {
            DataSet zreturn = tablaDA.ReporteRegVentaAnalitico(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetGeneraPDT3550(string empresaid, tb_co_Ventas BE)
        {
            DataSet zreturn = tablaDA.GetGeneraPDT3550(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        //public DataSet GetOne(string empresaid, tb_co_Ventas BE)
        //{
        //    return tablaDA.GetOne(empresaid, BE);
        //}
    }
}
