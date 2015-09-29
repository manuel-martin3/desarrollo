using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class clienteBL
    {
        public string Sql_Error = "";
        clienteDA tablaDA = new clienteDA();
     
        public bool Insert(string empresaid, tb_cliente BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public string BuscarCrear(string empresaid, tb_cliente BE)
        {
            //return tablaDA.BuscarCrear(empresaid, BE);
            string zreturn = tablaDA.BuscarCrear(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Insert_dbf(string empresaid, tb_cliente BE)
        {
            return tablaDA.Insert_dbf(empresaid, BE);
        }

        public bool Update(string empresaid, tb_cliente BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Update_dbf(string empresaid, tb_cliente BE)
        {
            return tablaDA.Update_dbf(empresaid, BE);
        }

        public bool Update2(string empresaid, tb_cliente BE)
        {
            return tablaDA.Update2(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_cliente BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cliente BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_CODdbf(string empresaid, tb_cliente BE)
        {
            return tablaDA.GetAll_CODdbf(empresaid, BE);
        }
        public String GetNextCod(string empresaid, tb_cliente BE)
        {
            return tablaDA.GetNextCod(empresaid, BE);
        }
        public DataSet GetAll_direc(string empresaid, tb_cliente BE)
        {
            return tablaDA.GetAll_direc(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string clienteid)
        {
            return tablaDA.GetOne(empresaid, clienteid);
        }
    }
}
