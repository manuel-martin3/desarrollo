﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_tiendaBL
    {
        tb_me_tiendaDA tablaDA = new tb_me_tiendaDA();

        public bool Insert(string empresaid, tb_me_tienda BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Insert_Item(string empresaid, tb_me_tienda BE)
        {
            return tablaDA.Insert_Item(empresaid, BE);
        }
        public bool Update(string empresaid, tb_me_tienda BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_me_tienda BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        
        public bool DeleteItem(string empresaid, tb_me_tienda BE)
        {
            return tablaDA.DeleteItem(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_me_tienda BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_me_tienda BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
    }
}