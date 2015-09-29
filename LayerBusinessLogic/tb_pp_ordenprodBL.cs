using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_pp_ordenprodBL
    {
        tb_pp_ordenprodDA tablaDA = new tb_pp_ordenprodDA();

        public bool Insert(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool InsertFase(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.InsertFase(empresaid, BE);
        }

        public bool InsertMaterial(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.InsertMaterial(empresaid, BE);
        }

        public bool Update(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool UpdateFase(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.UpdateFase(empresaid, BE);
        }

        public bool UpdateMaterial(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.UpdateMaterial(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public bool DeleteFase(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.DeleteFase(empresaid, BE);
        }

        public bool DeleteMaterial(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.DeleteMaterial(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet ListarOrden(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.ListarOrden(empresaid, BE);
        }

        public DataSet GetAll_Fase(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GetAll_Fase(empresaid, BE);
        }

        public DataSet GetAll_Material(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GetAll_Material(empresaid, BE);
        }

        public DataSet GetAllProp_PIVOT(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GetAllProp_PIVOT(empresaid, BE);
        }

        public DataSet GetAllPropColor_PIVOT(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GetAllPropColor_PIVOT(empresaid, BE);
        }

        public DataSet GetAll_Explosion(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GetAll_Explosion(empresaid, BE);
        }

        public bool Gen_Explosion(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.Gen_Explosion(empresaid, BE);
        }

        public DataSet GetAllDet_Explosion(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GetAllDet_Explosion(empresaid, BE);
        }

        public bool GenConsumo(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.GenConsumo(empresaid, BE);
        }

        public DataSet LstConsumoTelas(string empresaid, tb_pp_ordenprod BE)
        {
            return tablaDA.LstConsumoTelas(empresaid, BE);
        }

    }
}
