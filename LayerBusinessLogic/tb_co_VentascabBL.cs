using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_co_VentascabBL
    {
        tb_co_VentascabDA tablaDA = new tb_co_VentascabDA();

        public bool Insert(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAsientoNume(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.GetAsientoNume(empresaid, BE);
        }
        public DataSet GetAsientoRoleo(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.GetAsientoRoleo(empresaid, BE);
        }
        public DataSet GetGeneraPDBVentas(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.GetGeneraPDBVentas(empresaid, BE);
        }
        public DataSet GetGeneraPDBDUAS(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.GetGeneraPDBDUAS(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_co_Ventascab BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
