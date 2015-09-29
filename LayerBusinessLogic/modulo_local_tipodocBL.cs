using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class modulo_local_tipodocBL
    {
        modulo_local_tipodocDA tablaDA = new modulo_local_tipodocDA();

        public bool Insert(string empresaid, tb_modulo_local_tipodoc BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_modulo_local_tipodoc BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_modulo_local_tipodoc BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_modulo_local_tipodoc BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_modulo_local_tipodoc BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetAll_mov(string empresaid, tb_modulo_local_tipodoc BE)
        {
            return tablaDA.GetAll_mov(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string dominioid, string moduloid, string local, string tipodoc)
        {
            return tablaDA.GetOne(empresaid, dominioid, moduloid, local, tipodoc);
        }
    }
}
