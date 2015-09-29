﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cxc_fechaBL
    {
        tb_cxc_fechaDA tablaDA = new tb_cxc_fechaDA();

        public bool Insert(string empresaid, tb_cxc_fecha BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cxc_fecha BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cxc_fecha BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cxc_fecha BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_cxc_fecha BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
       
    }
}
