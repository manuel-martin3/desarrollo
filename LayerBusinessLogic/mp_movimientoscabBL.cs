using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_movimientoscabBL
    {
        mp_movimientoscabDA tablaDA = new mp_movimientoscabDA();

        public bool Insert(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_CabDet(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetAll_CabDet(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetOne2(string empresaid, tb_mp_movimientoscab BE)
        {
            return tablaDA.GetOne2(empresaid, BE);
        }
    }
}
