using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class mp_movimientosdetBL
    {
        mp_movimientosdetDA tablaDA = new mp_movimientosdetDA();

        public bool Insert(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_MpvProd(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.GetAll_MpvProd(empresaid, BE);
        }
        public DataSet GetAll_Rango(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.GetAll_Rango(empresaid, BE);
        } 
        public DataSet GetAll6(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.GetAll6(empresaid, BE);
        }
        public DataSet GetAll_Balance(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.GetAll_Balance(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_mp_movimientosdet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        
       
    }
}
