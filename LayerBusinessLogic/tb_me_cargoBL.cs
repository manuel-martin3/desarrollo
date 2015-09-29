using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_cargoBL
    {
        tb_me_cargoDA tablaDA = new tb_me_cargoDA();

        public bool Insert(string empresaid, tb_me_cargo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_me_cargo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_me_cargo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_me_cargo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_me_cargo BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetReport(string empresaid, tb_me_cargo BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_me_cargo BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
