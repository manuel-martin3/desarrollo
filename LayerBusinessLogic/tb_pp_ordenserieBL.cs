using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_ordenserieBL
    {
        tb_pp_ordenserieDA tablaDA = new tb_pp_ordenserieDA();

        public bool Insert(string empresaid, tb_pp_ordenserie BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_ordenserie BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pp_ordenserie BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_pp_ordenserie BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_NUM(string empresaid, tb_pp_ordenserie BE)
        {
            return tablaDA.GetAll_NUM(empresaid, BE);
        } 

        public DataSet GetOne(string empresaid, string categoriaid)
        {
            return tablaDA.GetOne(empresaid, categoriaid);
        }
    }
}
