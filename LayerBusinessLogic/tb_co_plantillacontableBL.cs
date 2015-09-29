using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_plantillacontableBL
    {
        tb_co_plantillacontableDA tablaDA = new tb_co_plantillacontableDA();

        public bool Insert(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_XML(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.Insert_XML(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetAllPlantilla(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.GetAllPlantilla(empresaid, BE);
        }

        #region
        public DataSet GetAllPartidas(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.GetAllPartidas(empresaid, BE);
        }
        public DataSet GetAllPartidasEEFF(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.GetAllPartidasEEFF(empresaid, BE);
        }
        public DataSet GetAllPartidasEEFFCuentas(string empresaid, tb_co_plantillacontable BE)
        {
            return tablaDA.GetAllPartidasEEFFCuentas(empresaid, BE);
        }
        
        #endregion
    }
}
