using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tipocambioBL
    {
        public string Sql_Error = "";
        tipocambioDA tablaDA = new tipocambioDA();

        public bool Insert_XML(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.Insert_XML(empresaid, BE);
        }
        public bool Insert(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_Update(string empresaid, DataTable Detalle)
        {
            bool zreturn = tablaDA.Insert_Update(empresaid, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Update(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAllReporte(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.GetAllReporte(empresaid, BE);
        }
        public DataSet GetGeneraDataPDBTcambio(string empresaid, tb_tipocambio BE)
        {
            return tablaDA.GetGeneraDataPDBTcambio(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, DateTime fecha)
        {
            return tablaDA.GetOne(empresaid, fecha);
        }
    }
}
