using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_varianteBL
    {
        tb_pp_varianteDA tablaDA = new tb_pp_varianteDA();

        public bool Insert(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Insert_Foto(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.Insert_Foto(empresaid, BE);
        }
        public bool Update_foto(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.Update_foto(empresaid, BE);
        }
        public DataSet GetAll_foto(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.GetAll_foto(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string articid)
        {
            return tablaDA.GetOne(empresaid, articid);
        }
        public DataSet GeneraCod(string empresaid, tb_pp_variante BE)
        {
            return tablaDA.GeneraCod(empresaid, BE);
        }
    }
}
