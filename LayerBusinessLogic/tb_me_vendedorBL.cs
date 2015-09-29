using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_vendedorBL
    {
        tb_me_vendedorDA tablaDA = new tb_me_vendedorDA();

        public bool Insert(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }       
        public bool Update(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.Update(empresaid, BE);
        }        
        public bool Delete(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }       
        public DataSet GetReport(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }        
        public DataSet GetOne(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetAll_MaxMin(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.GetAll_MaxMin(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }        


        // 
        public DataSet GetAll_History(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.GetAll_History(empresaid, BE);
        }

        public bool Insert_Freeze(string empresaid, tb_me_vendedor BE)
        {
            return tablaDA.Insert_Freeze(empresaid, BE);
        }  

    }
}
