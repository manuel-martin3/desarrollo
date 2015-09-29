using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_plla_fichatrabajadoresBL
    {
        public string Sql_Error = "";
        tb_plla_fichatrabajadoresDA tablaDA = new tb_plla_fichatrabajadoresDA();

        public bool Insert(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Insert_Update(string empresaid, DataTable tablatrabajadores, DataTable tablacontratos, DataTable tablarubroscontrato)
        {
            //return tablaDA.Insert_Update(empresaid, BE);
            bool zreturn = tablaDA.Insert_Update(empresaid, tablatrabajadores, tablacontratos, tablarubroscontrato);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Update(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public bool Delete(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool  Eliminar(string empresaid, DataTable tablatrabajadores)
        {
            //return tablaDA.Eliminar(empresaid, BE);
            bool zreturn = tablaDA.Eliminar(empresaid, tablatrabajadores);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        
        public DataSet GetAll(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll_Consulta(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll_Consulta(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_Consulta(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll_ConsultaMaxCod(string empresaid, String Codigo)
        {
            //return tablaDA.GetAll_ConsultaMaxCod(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_ConsultaMaxCod(empresaid, Codigo);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_FichaDatos(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll_FichaDatos(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_FichaDatos(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_GeneraDatosFormatoContrato(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll_GeneraDatosFormatoContrato(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_GeneraDatosFormatoContrato(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetOne(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetOne(empresaid, tipoplla);
            DataSet xreturn = null;
            xreturn = tablaDA.GetOne(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_EstadoTrabj(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll_EstadoTrabj(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_EstadoTrabj(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_GETTRABAJADORES(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll_GETTRABAJADORES(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_GETTRABAJADORES(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll_TrabajadorRetenciones(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll_TrabajadorRetenciones(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_TrabajadorRetenciones(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_ActivosCesados(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAll_ActivosCesados(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_ActivosCesados(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool CesarTrabajadorUpdate(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.CesarTrabajadorUpdate(empresaid, BE);
            bool zreturn = tablaDA.CesarTrabajadorUpdate(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool DesactivarTrabajadorUpdate(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.DesactivarTrabajadorUpdate(empresaid, BE);
            bool zreturn = tablaDA.DesactivarTrabajadorUpdate(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAllTrabajadoresReactivar(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.GetAllTrabajadoresReactivar(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllTrabajadoresReactivar(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool ReactivarTrabajadorUpdate(string empresaid, tb_plla_fichatrabajadores BE)
        {
            //return tablaDA.ReactivarTrabajadorUpdate(empresaid, BE);
            bool zreturn = tablaDA.ReactivarTrabajadorUpdate(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
    }
}
