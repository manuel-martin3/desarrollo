using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_retencionCAbBL
    {
        public string Sql_Error = "";
        tb_co_retencionCAbDA tablaDA = new tb_co_retencionCAbDA();

        //public bool Insert(string empresaid, tb_co_retencionCAb BE)
        //{
        //    //return tablaDA.Insert(empresaid, BE);
        //    bool xreturn = tablaDA.Insert(empresaid, BE);
        //    Sql_Error = tablaDA.Sql_Error;
        //    return xreturn;
        //}
        public bool Insert_Update(string empresaid, DataTable cabecera, DataTable detalle)
        {
            //return tablaDA.Insert_Update(empresaid, BE);
            bool zreturn = tablaDA.Insert_Update(empresaid, cabecera, detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        //public bool Update(string empresaid, tb_co_retencionCAb BE)
        //{
        //    return tablaDA.Update(empresaid, BE);
        //}
        //public bool Delete(string empresaid, tb_co_retencionCAb BE)
        //{
        //    return tablaDA.Delete(empresaid, BE);
        //}
        public bool Eliminar(string empresaid, DataTable cabecera)
        {
            //return tablaDA.Eliminar(empresaid, BE);
            bool zreturn = tablaDA.Eliminar(empresaid, cabecera);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAll(string empresaid, tb_co_retencionCAb BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAsientoNume(string empresaid, tb_co_retencionCAb BE)
        {
            //return tablaDA.GetAsientoNume(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAsientoNume(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetMaxNumComprobRetencion(string empresaid, tb_co_retencionCAb BE)
        {
            //return tablaDA.GetMaxNumComprobRetencion(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetMaxNumComprobRetencion(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAsientoRoleo(string empresaid, tb_co_retencionCAb BE)
        {
            return tablaDA.GetAsientoRoleo(empresaid, BE);
        }
        public DataSet GetGenerarRetencionesCompras(string empresaid, tb_co_retencionCAb BE)
        {
            //return tablaDA.GetGenerarRetencionesCompras(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetGenerarRetencionesCompras(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet FormatoRegistroRegistroRetencion(string empresaid, tb_co_retencionCAb BE)
        {
            //return tablaDA.FormatoRegistroRegistroRetencion(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.FormatoRegistroRegistroRetencion(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataTable GetGeneraAsientoRetencionesIGV_Consulta(string empresaid, tb_co_retencionCAb BE)
        {          
            DataTable xreturn = null;
            xreturn = tablaDA.GetGeneraAsientoRetencionesIGV_Consulta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool GetGeneraAsientoRetencionesIGV_Update(string empresaid, tb_co_retencionCAb BE)
        {
            bool zreturn = tablaDA.GetGeneraAsientoRetencionesIGV_Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }


        //public DataSet GetOne(string empresaid, tb_co_retencionCAb BE)
        //{
        //    return tablaDA.GetOne(empresaid, BE);
        //}
    }
}
