using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class rrhh_personalBL
    {
        rrhh_personalDA tablaDA = new rrhh_personalDA();

        public bool Insert(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update2(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.Update2(empresaid, BE);
        }
        public bool Update_foto(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.Update_foto(empresaid, BE);
        }
        public bool Update3(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.Update3(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_cmdConsumo(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.GetAll_cmdConsumo(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll__cumpleanieros_hoy(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.GetAll__cumpleanieros_hoy(empresaid, BE);
        }
        public DataSet GetAll__cumpleanieros_semana(string empresaid, tb_rrhh_personal BE)
        {
            return tablaDA.GetAll__cumpleanieros_semana(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string ddnni)
        {
            return tablaDA.GetOne(empresaid, ddnni);
        }
    }
}
