using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cp_comercialdetBL
    {
        tb_cp_comercialdetDA tablaDA = new tb_cp_comercialdetDA();

        public bool Insert(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAsientoNume(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.GetAsientoNume(empresaid, BE);
        }
        public DataSet GetAsientoRoleo(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.GetAsientoRoleo(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }

        public DataSet GetAll_datosdetalle(string empresaid, tb_cp_comercialdet BE)
        {
            return tablaDA.GetAll_datosdetalle(empresaid, BE);
        }

    }
}
