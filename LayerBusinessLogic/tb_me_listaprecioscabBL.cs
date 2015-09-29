using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_listaprecioscabBL
    {
        tb_me_listaprecioscabDA tablaDA = new tb_me_listaprecioscabDA();

        public bool Insert(string empresaid, tb_me_listaprecioscab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_me_listaprecioscab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_me_listaprecioscab BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_me_listaprecioscab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        //public DataSet GetVigentes(string empresaid, tb_me_listaprecioscab BE)
        //{
        //    return tablaDA.GetVigentes(empresaid, BE);
        //}

        //public DataSet GetAll_datosdetalle(string empresaid, tb_me_listaprecioscab BE)
        //{
        //    return tablaDA.GetAll_datosdetalle(empresaid, BE);
        //}

        //public DataSet FiltroProducto(string empresaid, tb_me_listaprecioscab BE)
        //{
        //    return tablaDA.FiltroProducto(empresaid, BE);
        //}

        public DataSet GetAll_paginacion(string empresaid, tb_me_listaprecioscab BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

    }
}
