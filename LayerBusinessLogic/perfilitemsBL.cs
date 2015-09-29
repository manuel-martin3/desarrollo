using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class perfilitemsBL
    {
        perfilitemsDA tablaDA = new perfilitemsDA();

        public bool Insert(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_xml(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.Insert_xml(empresaid, BE);
        }
        public bool Update(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update_propied(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.Update_propied(empresaid, BE);
        }
        public bool Update_xml(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.Update_xml(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_actives(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.GetAll_actives(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetAll_nivel_acceso(string empresaid, tb_perfilitems BE)
        {
            return tablaDA.GetAll_nivel_acceso(empresaid, BE);
        }
    }
}
