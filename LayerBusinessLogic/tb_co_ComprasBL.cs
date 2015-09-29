using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_ComprasBL
    {
        public string Sql_Error = "";
        tb_co_ComprasDA tablaDA = new tb_co_ComprasDA();

        public bool Insert(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Insert_ImportaExcel(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.Insert_ImportaExcel(empresaid, BE);
            bool zreturn = tablaDA.Insert_ImportaExcel(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool Update(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool DELETE_ImportaExcel(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.DELETE_ImportaExcel(empresaid, BE);
            bool zreturn = tablaDA.DELETE_ImportaExcel(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Delete(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
      
        //public DataSet GetAll(string empresaid, tb_co_Compras BE)
        //{
        //    return tablaDA.GetAll(empresaid, BE);
        //}
        //public DataSet GetAsientoNume(string empresaid, tb_co_Compras BE)
        //{
        //    return tablaDA.GetAsientoNume(empresaid, BE);
        //}
        public DataSet ReporteRegistroCompra(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.ReporteRegistroCompra(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.ReporteRegistroCompra(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet ReporteRegCompraAux(string empresaid, tb_co_Compras BE)
        {
            return tablaDA.ReporteRegCompraAux(empresaid, BE);
        }
        public DataSet ReporteRegCompraAnalitico(string empresaid, tb_co_Compras BE)
        {
            DataSet zreturn = tablaDA.ReporteRegCompraAnalitico(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet ReporteRegCompraResumen(string empresaid, tb_co_Compras BE)
        {
            DataSet zreturn = tablaDA.ReporteRegCompraResumen(empresaid, BE);
            //return tablaDA.ReporteRegCompraResumen(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet ReporteRegCompraResumen01(string empresaid, tb_co_Compras BE)
        {
            return tablaDA.ReporteRegCompraResumen01(empresaid, BE);
        }
        public DataSet ReporteRegistroCompraDetracciones(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.ReporteRegistroCompra(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.ReporteRegistroCompraDetracciones(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet RenameCompra(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.RenameCompra(empresaid, BE);
            DataSet xreturn = tablaDA.RenameCompra(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        //public DataSet GetOne(string empresaid, tb_co_Compras BE)
        //{
        //    return tablaDA.GetOne(empresaid, BE);
        //}

        public DataSet GenPendienteNIAtoRCompra(string empresaid, tb_co_Compras BE)
        {
            //return tablaDA.GenPendienteNIAtoRCompra(empresaid, BE);
            DataSet xreturn = tablaDA.GenPendienteNIAtoRCompra(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
    }
}
