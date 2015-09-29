using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_conciliacionbancariaBL
    {
        public string Sql_Error = "";
        tb_co_conciliacionbancariaDA tablaDA = new tb_co_conciliacionbancariaDA();

        public bool Insert(string empresaid, tb_co_conciliacionbancaria BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool Insert_Update(string empresaid, tb_co_conciliacionbancaria BE, DataTable Detalle)
        {
            //return tablaDA.Insert_Update(empresaid, Cabecera, Detalle);
            bool xreturn = tablaDA.Insert_Update(empresaid, BE, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool Insert_Update_Conta(string empresaid, tb_co_conciliacionbancaria BE, DataTable Detalle)
        {
            //return tablaDA.Insert_Update_Conta(empresaid, Cabecera, Detalle);
            bool xreturn = tablaDA.Insert_Update_Conta(empresaid, BE, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet ConciliacionBancariaSaldoAnterior(string empresaid, tb_co_conciliacionbancaria BE)
        {
            //return tablaDA.ConciliacionBancariaSaldoAnterior(empresaid, Cabecera, Detalle);
            DataSet xreturn = tablaDA.ConciliacionBancariaSaldoAnterior(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

    }
}
