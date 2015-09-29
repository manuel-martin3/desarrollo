using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class usuariomodulolocalBL
    {
        usuariomodulolocalDA tablaDA = new usuariomodulolocalDA();

        public bool Insert(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll3(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.GetAll3(empresaid, BE);
        }

        public DataSet GetAllDatos(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.GetAllDatos(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, tb_usuariomodulolocal BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
