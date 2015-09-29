using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class modulo_local_tipodocseriesBL
    {
        modulo_local_tipodocseriesDA tablaDA = new modulo_local_tipodocseriesDA();

        public bool Insert(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_nuevonumero(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.GetAll_nuevonumero(empresaid, BE);
        }

        public DataSet GetAll_nuevonumero2(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.GetAll_nuevonumero2(empresaid, BE);
        }

        public DataSet CmDocSeries_nuevonumero(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.CmDocSeries_nuevonumero(empresaid, BE);
        }

        public DataSet CmLiqDocSeries_New(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.CmLiqDocSeries_New(empresaid, BE);
        }
        
        public DataSet GetOne(string empresaid, tb_modulo_local_tipodocseries BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
