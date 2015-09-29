using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cm_ordendecompraBL
    {
        tb_cm_ordendecompraDA tablaDA = new tb_cm_ordendecompraDA();

        public bool Insert(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool Insert_det(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.Insert_det(empresaid, BE);
        }

        public bool GenerarOrdenDetallado(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.GenerarOrdenDetallado(empresaid, BE);
        }        
        public bool Update(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.Update(empresaid, BE);
        }        

        public bool Delete(string empresaid, tb_cm_ordendecompra BE1)
        {
            return tablaDA.Delete(empresaid, BE1);
        }

        public DataSet GetReport(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }

        public DataSet GetReport2(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.GetReport2(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet BuscarOrden(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.BuscaOrden(empresaid, BE);
        }

        // Reporte Kardex 
        public DataSet GetKardex(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.GetKardex(empresaid, BE);
        }

        public DataSet Report_OrdEmitidas(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.Report_OrdEmitidas(empresaid, BE);
        }

        public DataSet Report_OrdEmitidasGen(string empresaid, tb_cm_ordendecompra BE)
        {
            return tablaDA.Report_OrdEmitidasGen(empresaid, BE);
        }

        // Consultar 
        public DataSet Get_ctactename(string empresaid, tb_cm_ordendecompra.Item BE)
        {
            return tablaDA.Get_ctactename(empresaid, BE);
        }
       
    }
}
