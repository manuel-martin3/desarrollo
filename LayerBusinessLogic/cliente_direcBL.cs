using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class cliente_direcBL
    {
        cliente_direcDA tablaDA = new cliente_direcDA();

        public bool Insert_XML(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Insert_XML(empresaid, BE);
        }

        public bool Insert(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_dbf(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Insert_dbf(empresaid, BE);
        }

        public bool Update_dbf(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Update_dbf(empresaid, BE);
        }

        public bool Delete_dbf(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Delete_dbf(empresaid, BE);
        }

        public bool Update(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll_CODdbf(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.GetAll_CODdbf(empresaid, BE);
        }

        public DataSet Gen_NumDirecc(string empresaid, tb_cliente_direc BE)
        {
            return tablaDA.Gen_NumDirecc(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, string ctacte, string bancoid)
        {
            return tablaDA.GetOne(empresaid, ctacte, bancoid);
        }

    }
}
