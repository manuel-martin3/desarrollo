using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_percepcionesxmlBL
    {
        public string Sql_Error = "";
        tb_co_percepcionesxmlDA tablaDA = new tb_co_percepcionesxmlDA();

        public bool Insert(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_ImportaExcel(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.Insert_ImportaExcel(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool DELETE_ImportaExcel(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.DELETE_ImportaExcel(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_co_percepcionesxml BE)
        {
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet ReporteLibroPercepciones(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.ReporteLibroPercepciones(empresaid, BE);
        }
        public DataSet ReporteLibroPercepcionesResumen(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.ReporteLibroPercepcionesResumen(empresaid, BE);
        }
        public DataSet GetGeneraPDT0697Percepciones(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.GetGeneraPDT0697Percepciones(empresaid, BE);
        }
        public DataSet GetGeneraPDT0697Percepciones_CP(string empresaid, tb_co_percepcionesxml BE)
        {
            return tablaDA.GetGeneraPDT0697Percepciones_CP(empresaid, BE);
        }
    }
}
