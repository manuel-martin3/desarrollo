using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cxc_evalcredBL
    {
        tb_cxc_evalcredDA tablaDA = new tb_cxc_evalcredDA();

        public bool Insert(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool UpdatePendAprob(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.UpdatePendAprob(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_Filtro(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.GetAll_Filtro(empresaid, BE);
        }
        public DataSet GetAll_PendAprob(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.GetAll_PendAprob(empresaid, BE);
        }
        public DataSet GetAll_Estados(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.GetAll_Estados(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_cxc_evalcred BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
       
    }
}
