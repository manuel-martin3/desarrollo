using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60movimientoscabBL
    {
        tb_60movimientoscabDA tablaDA = new tb_60movimientoscabDA();

        public bool Insert(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll_paginacion(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

        public DataSet GetAll_CabDet(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetAll_CabDet(empresaid, BE);
        }

        public DataSet GetAll2(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }

        public DataSet GetAll3(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetAll3(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetOne_numdocs(string empresaid, tb_60movimientoscab BE)
        {
            return tablaDA.GetOne_numdocs(empresaid, BE);
        }
    }
}
