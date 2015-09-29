using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_articulocolorWebBL
    {
        tb_pt_articulocolorWebDA tablaDA = new tb_pt_articulocolorWebDA();

        public bool Insert(string empresaid, tb_pt_articulocolor BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pt_articulocolor BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Insert_dbf(string empresaid, tb_pt_articulocolor BE)
        {
            return tablaDA.Insert_dbf(empresaid, BE);
        }
        public bool Update_dbf(string empresaid, tb_pt_articulocolor BE)
        {
            return tablaDA.Update_dbf(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_pt_articulocolor BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_articulocolor BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string articid, string colorid)
        {
            return tablaDA.GetOne(empresaid, articid, colorid);
        }
    }
}
