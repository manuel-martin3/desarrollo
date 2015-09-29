﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_temporadaBL
    {
        tb_pt_temporadaDA tablaDA = new tb_pt_temporadaDA();

        public bool Insert(string empresaid, tb_pt_temporada BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_temporada BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_temporada BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_temporada BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_pt_temporada BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string temporadaid)
        {
            return tablaDA.GetOne(empresaid, temporadaid);
        }
    }
}