using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_plla_tab0100BL
    {
        public string Sql_Error = "";
        tb_plla_tab0100DA tablaDA = new tb_plla_tab0100DA();

        public bool Insert(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Update(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Delete(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAll(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAllTiRegi(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAllTiRegi(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllTiRegi(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAllEstadoCivil(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAllEstadoCivil(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllEstadoCivil(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAllEstadoContrato(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAllEstadoContrato(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllEstadoContrato(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet gspTbPllaModalidadRubros(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.gspTbPllaModalidadRubros(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.gspTbPllaModalidadRubros(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet gspTbPllaTipoCalculoRubros(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.gspTbPllaTipoCalculoRubros(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.gspTbPllaTipoCalculoRubros(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet gspTbPllaTipoEnRubros(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.gspTbPllaTipoEnRubros(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.gspTbPllaTipoEnRubros(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet gspTbPllaTipoRubro(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.gspTbPllaTipoRubro(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.gspTbPllaTipoRubro(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet gspTbPllaTipoComisionAFP(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.gspTbPllaTipoComisionAFP(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.gspTbPllaTipoComisionAFP(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAllModalidadRubroPermanente(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAllModalidadRubroPermanente(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllModalidadRubroPermanente(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAllTipoRubroPermanente(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAllTipoRubroPermanente(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllTipoRubroPermanente(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetTipoDescuento(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetTipoDescuento(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetTipoDescuento(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetTipoAportacion(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetTipoAportacion(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetTipoAportacion(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetOne(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetOne(empresaid, tipoplla);
            DataSet xreturn = null;
            xreturn = tablaDA.GetOne(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        #region //Motivos Permisos
        public bool MotivosPermiso_InsertUpdate(string empresaid, tb_plla_tab0100 BE, DataTable Detalle)
        {
            //return tablaDA.MotivosPermiso_InsertUpdate(empresaid, BE);
            bool zreturn = tablaDA.MotivosPermiso_InsertUpdate(empresaid, BE, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool MotivosPermiso_ELIMINAR(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.MotivosPermiso_ELIMINAR(empresaid, BE);
            bool zreturn = tablaDA.MotivosPermiso_ELIMINAR(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet GetAllMotivosPermiso(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAllMotivosPermiso(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllMotivosPermiso(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet MotivosPermiso_IR(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.MotivosPermiso_IR(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.MotivosPermiso_IR(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet MotivosPermiso_MAXCODIGO(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.MotivosPermiso_MAXCODIGO(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.MotivosPermiso_MAXCODIGO(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        #endregion

        #region //TipoRubroTareo
        public DataSet TipoRubroTareo(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.TipoRubroTareo(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.TipoRubroTareo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAllConfiguracionRubroTareo(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.GetAllConfiguracionRubroTareo(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAllConfiguracionRubroTareo(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool ConfiguracionRubrotareoInsert(string empresaid, tb_plla_tab0100 BE, DataTable Detalle)
        {
            //return tablaDA.ConfiguracionRubrotareoInsert(empresaid, BE);
            bool zreturn = tablaDA.ConfiguracionRubrotareoInsert(empresaid, BE, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        #endregion

        #region //Tipo Prestamo
        public DataSet TipoPrestamo_CONSULTA(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.TipoPrestamo_CONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.TipoPrestamo_CONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet TipoPrestamo_MAXCODIGO(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.TipoPrestamo_MAXCODIGO(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.TipoPrestamo_MAXCODIGO(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool TipoPrestamo_InsertUpdate(string empresaid, tb_plla_tab0100 BE, DataTable Detalle)
        {
            //return tablaDA.TipoPrestamo_InsertUpdate(empresaid, BE);
            bool zreturn = tablaDA.TipoPrestamo_InsertUpdate(empresaid, BE, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public DataSet TipoPrestamo_IR(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.TipoPrestamo_IR(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.TipoPrestamo_IR(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool TipoPrestamo_ELIMINAR(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.TipoPrestamo_ELIMINAR(empresaid, BE);
            bool zreturn = tablaDA.TipoPrestamo_ELIMINAR(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        #endregion

        #region //Rubros Quincenales
        public DataSet Quincenal_CONSULTA(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.Quincenal_CONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.Quincenal_CONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet QuincenalRubros_CONSULTA(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.QuincenalRubros_CONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.QuincenalRubros_CONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool QuincenalRubros_DELETED(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.QuincenalRubros_DELETED(empresaid, BE);
            bool zreturn = tablaDA.QuincenalRubros_DELETED(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool QuincenalRubros_InsertUpdate(string empresaid, tb_plla_tab0100 BE, DataTable Detalle)
        {
            //return tablaDA.QuincenalRubros_InsertUpdate(empresaid, BE);
            bool zreturn = tablaDA.QuincenalRubros_InsertUpdate(empresaid, BE, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        #endregion

        #region //Telecredito
        public DataSet TeleCredito_CONSULTA(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.TeleCredito_CONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.TeleCredito_CONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool TeleCredito_InsertUpdate(string empresaid, tb_plla_tab0100 BE, DataTable Detalle)
        {
            //return tablaDA.TeleCredito_InsertUpdate(empresaid, BE);
            bool zreturn = tablaDA.TeleCredito_InsertUpdate(empresaid, BE, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        #endregion

        #region //Modalidad Planilla
        public DataSet ModalidadPlanilla_CONSULTA(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.ModalidadPlanilla_CONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.ModalidadPlanilla_CONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        #endregion

        #region //Quincena
        public DataSet TipoQuincena_CONSULTA(string empresaid, tb_plla_tab0100 BE)
        {
            //return tablaDA.TipoQuincena_CONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.TipoQuincena_CONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        #endregion
    }
}
