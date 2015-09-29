﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class sys_moduloBL
    {
        sys_moduloDA tablaDA = new sys_moduloDA();

        public bool Insert(string empresaid, tb_sys_modulo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_sys_modulo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_sys_modulo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_sys_modulo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_sys_modulo BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string dominioid, string moduloid)
        {
            return tablaDA.GetOne(empresaid, dominioid, moduloid);
        }
    }
}