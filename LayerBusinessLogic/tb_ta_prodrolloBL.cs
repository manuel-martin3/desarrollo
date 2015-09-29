using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_ta_prodrolloBL
    {
        tb_ta_prodrolloDA tablaDA = new tb_ta_prodrolloDA();

        public bool Insert(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetDatos_Reporte(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.Get_Datos_Reporte(empresaid, BE);
        }
        public DataSet GetAll_prod(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.GetAll_prod(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetAll_codbarra(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.GetAll_codbarra(empresaid, BE);
        }

        //*** OPt ***/
        public DataSet GetAll_numgenerado(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.GetAll_numgenerado(empresaid, BE);
        }
        
        public DataSet GetOne(string empresaid, string rollo)
        {
            return tablaDA.GetOne(empresaid, rollo);
        }
        public DataSet GetAll_Localstock(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.GetAll_Localstock(empresaid, BE);
        }

        public DataSet GetAll_stock(string empresaid, tb_ta_prodrollo BE)
        {
            return tablaDA.GetAll_stock(empresaid, BE);
        }

    }
}
