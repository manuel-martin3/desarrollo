using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_retencionesBL
    {
        public string Sql_Error = "";
        tb_co_retencionesDA tablaDA = new tb_co_retencionesDA();

        public bool Insert(string empresaid, tb_co_retenciones BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_retenciones BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public DataSet ReporteLibroRetenciones(string empresaid, tb_co_retenciones BE)
        {
            return tablaDA.ReporteLibroRetenciones(empresaid, BE);
        }
        public DataSet ReporteLibroRetencionesResumen(string empresaid, tb_co_retenciones BE)
        {
            return tablaDA.ReporteLibroRetencionesResumen(empresaid, BE);
        }
        public DataSet GetGeneraPDT0626Retenciones(string empresaid, tb_co_retenciones BE)
        {
            return tablaDA.GetGeneraPDT0626Retenciones(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_co_retenciones BE)
        {
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet ReporteLibroRetencionesNmruc(string empresaid, tb_co_retenciones BE)
        {
            return tablaDA.ReporteLibroRetencionesNmruc(empresaid, BE);
        }

        public DataSet ReporteLibroRetencionesVerificar(string empresaid, tb_co_retenciones BE)
        {
            return tablaDA.ReporteLibroRetencionesVerificar(empresaid, BE);
        }

        //public DataSet GetOne(string empresaid, tb_co_retenciones BE)
        //{
        //    return tablaDA.GetOne(empresaid, BE);
        //}
    }
}
