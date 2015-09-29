using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_recibosporhonorariosBL
    {
        public string Sql_Error = "";
        tb_co_recibosporhonorariosDA tablaDA = new tb_co_recibosporhonorariosDA();

        public bool Insert(string empresaid, tb_co_recibosporhonorarios BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_recibosporhonorarios BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_recibosporhonorarios BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_recibosporhonorarios BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAllAyuda(string empresaid, tb_co_recibosporhonorarios BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetAllAyuda(empresaid, BE);
        }
        public DataSet GetAsientoNume(string empresaid, tb_co_recibosporhonorarios BE)
        {
            return tablaDA.GetAsientoNume(empresaid, BE);
        }
        public DataSet GetAsientoRoleo(string empresaid, tb_co_recibosporhonorarios BE)
        {
            return tablaDA.GetAsientoRoleo(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_recibosporhonorarios BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetReporteLibroRetenciones(string empresaid, tb_co_recibosporhonorarios BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetReporteLibroRetenciones(empresaid, BE);           
        }
        public DataSet GetReporteCertificadoRetenciones(string empresaid, tb_co_recibosporhonorarios BE)
        {
            Sql_Error = tablaDA.Sql_Error;
            return tablaDA.GetReporteCertificadoRetenciones(empresaid, BE);
        } 
    }
}
