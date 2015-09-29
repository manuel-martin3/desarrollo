using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tributotasaBL
    {
        tributotasaDA tablaDA = new tributotasaDA();

        public bool Insert(string empresaid, tb_tributotasa BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_tributotasa BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_tributotasa BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_tributotasa BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_tributotasa BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string tributoid, DateTime tributofecha)
        {
            return tablaDA.GetOne(empresaid, tributoid,tributofecha);
        }
    }
}
