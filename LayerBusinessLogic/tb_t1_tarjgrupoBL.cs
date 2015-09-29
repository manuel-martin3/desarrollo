using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_t1_tarjgrupoBL
    {
        tb_t1_tarjgrupoDA tablaDA = new tb_t1_tarjgrupoDA();

        public string Sql_Error = "";

        public bool Insert(string empresaid, tb_t1_tarjgrupo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_t1_tarjgrupo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_t1_tarjgrupo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_t1_tarjgrupo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_t1_tarjgrupo BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public String GetNextCod(string empresaid, tb_t1_tarjgrupo BE)
        {
            return tablaDA.GetNextCod(empresaid, BE);
        }
        public DataSet GetAll_direc(string empresaid, tb_t1_tarjgrupo BE)
        {
            return tablaDA.GetAll_direc(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string clienteid)
        {
            return tablaDA.GetOne(empresaid, clienteid);
        }
    }
}
