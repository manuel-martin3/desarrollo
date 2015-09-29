using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pt_articuloBL
    {
        tb_pt_articuloDA tablaDA = new tb_pt_articuloDA();

        public bool Insert(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }       

        public bool Insert_dbf(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.Insert_dbf(empresaid, BE);
        }

        public bool Update(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Update_dbf(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.Update_dbf(empresaid, BE);
        }

        public bool Insert_Foto(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.Insert_Foto(empresaid, BE);
        }
        public bool Update_foto(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.Update_foto(empresaid, BE);
        }
        public DataSet GetAll_foto(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GetAll_foto(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll_Color(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GetAll_Color(empresaid, BE);
        }

        public DataSet GetAll_DESCORT(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GetAll_DESCORT(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll_CODdbf(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GetAll_CODdbf(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string articid)
        {
            return tablaDA.GetOne(empresaid, articid);
        }
        public DataSet GeneraCod(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GeneraCod(empresaid, BE);
        }
        public DataSet GeneraCod2(string empresaid, tb_pt_articulo BE)
        {
            return tablaDA.GeneraCod2(empresaid, BE);
        }
    }
}
