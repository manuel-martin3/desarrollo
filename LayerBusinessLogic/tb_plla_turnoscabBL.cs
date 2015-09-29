﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_plla_turnoscabBL
    {
        public string Sql_Error = "";
        tb_plla_turnoscabDA tablaDA = new tb_plla_turnoscabDA();

        public bool Insert(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Insert_Update(string empresaid, tb_plla_turnoscab BE, DataTable Cabaecera, DataTable Detalle)
        {
            //return tablaDA.Insert(empresaid, BE);
            bool zreturn = tablaDA.Insert_Update(empresaid, BE, Cabaecera, Detalle);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Update(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.Update(empresaid, BE);
            bool zreturn = tablaDA.Update(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public bool Delete(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Delete(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }
        public bool Eliminar(string empresaid, DataTable TablaDatos)
        {
            //return tablaDA.Delete(empresaid, BE);
            bool zreturn = tablaDA.Eliminar(empresaid, TablaDatos);
            Sql_Error = tablaDA.Sql_Error;
            return zreturn;
        }

        public DataSet GetAll(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.GetAll(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_CONSULTA(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.GetAll_CONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_CONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public DataSet GetAll_GetAllCONSULTA(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.GetAll_GetAllCONSULTA(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_GetAllCONSULTA(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_MaxRubro(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.GetAll_MaxRubro(empresaid, BE);
            DataSet xreturn = null;
            xreturn = tablaDA.GetAll_MaxRubro(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetOne(string empresaid, tb_plla_turnoscab BE)
        {
            //return tablaDA.GetOne(empresaid, tipoplla);
            DataSet xreturn = null;
            xreturn = tablaDA.GetOne(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
    }
}
