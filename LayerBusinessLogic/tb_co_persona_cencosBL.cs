using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;


namespace LayerBusinessLogic
{
    public class tb_co_persona_cencosBL
    {
        tb_co_persona_cencosDA tablaDA = new tb_co_persona_cencosDA();

        public bool Insert(string empresaid, tb_co_persona_cencosBE BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_persona_cencosBE BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_persona_cencosBE BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_persona_cencosBE BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_persona_cencosBE BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }

        public DataSet GetDNI(string empresaid, tb_co_persona_cencosBE BE)
        {
            return tablaDA.GetDNI(empresaid, BE);
        }


        public DataSet GetProductosCencos(string empresaid, tb_co_persona_cencosBE BE)
        {
            return tablaDA.GetProductosCencos(empresaid, BE);
        }
    }
}
