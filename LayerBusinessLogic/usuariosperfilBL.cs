using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class usuariosperfilBL
    {
        usuariosperfilDA tablaDA = new usuariosperfilDA();

        public bool Insert(string empresaid, tb_usuariosperfil BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_usuariosperfil BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_usuariosperfil BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_usuariosperfil BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_union(string empresaid, tb_usuariosperfil BE)
        {
            return tablaDA.GetAll_union(empresaid, BE);
        }
    }
}
