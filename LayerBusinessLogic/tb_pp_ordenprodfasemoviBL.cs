using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;


namespace LayerBusinessLogic
{
    public class tb_pp_ordenprodfasemoviBL
    {
        tb_pp_ordenprodfasemoviDA DA = new tb_pp_ordenprodfasemoviDA();

        public bool Insert(String xempresaid ,tb_pp_ordenprodfasemovi BE)
        {
            return DA.Insert(xempresaid, BE);
        }
        public bool Update(String xempresaid, tb_pp_ordenprodfasemovi BE)
        {
            return DA.Update(xempresaid, BE);
        }
        public bool Delete(String xempresaid, tb_pp_ordenprodfasemovi BE)
        {
            return DA.Delete(xempresaid, BE);
        }

        public DataSet GetAll(String xempresaid, tb_pp_ordenprodfasemovi BE)
        {
            return DA.GetAll(xempresaid, BE);
        }

        public DataSet GetAll_num(String xempresaid, tb_pp_ordenprodfasemovi BE)
        {
            return DA.GetAll_num(xempresaid, BE);
        }

        public DataSet GetAllPropColor_PIVOT(String xempresaid, tb_pp_ordenprodfasemovi BE)
        {
            return DA.GetAllPropColor_PIVOT(xempresaid, BE);
        }

    }
}
