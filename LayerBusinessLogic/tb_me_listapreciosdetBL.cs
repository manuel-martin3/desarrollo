using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_listapreciosdetBL
    {
        tb_me_listapreciosdetDA tablaDA = new tb_me_listapreciosdetDA();

        public bool Insert(string empresaid, tb_me_listapreciosdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool InsertDet(string empresaid, tb_me_listapreciosdet BE)
        {
            return tablaDA.InsertDet(empresaid, BE);
        }
        public bool Update(string empresaid, tb_me_listapreciosdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_me_listapreciosdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_me_listapreciosdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        //public DataSet GetVigentes(string empresaid, tb_me_listapreciosdet BE)
        //{
        //    return tablaDA.GetVigentes(empresaid, BE);
        //}

        //public DataSet GetAll_datosdetalle(string empresaid, tb_me_listapreciosdet BE)
        //{
        //    return tablaDA.GetAll_datosdetalle(empresaid, BE);
        //}

        //public DataSet FiltroProducto(string empresaid, tb_me_listapreciosdet BE)
        //{
        //    return tablaDA.FiltroProducto(empresaid, BE);
        //}

        public DataSet GetAll_paginacion(string empresaid, tb_me_listapreciosdet BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

    }
}
