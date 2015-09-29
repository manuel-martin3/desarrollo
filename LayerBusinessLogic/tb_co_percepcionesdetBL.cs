using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_percepcionesdetBL
    {
        tb_co_percepcionesdetDA tablaDA = new tb_co_percepcionesdetDA();

        public bool Insert(string empresaid, tb_co_percepcionesdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_percepcionesdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_percepcionesdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_percepcionesdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetCPercepcion(string empresaid, tb_co_percepcionesdet BE)
        {
            return tablaDA.GetCPercepcion(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_percepcionesdet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
