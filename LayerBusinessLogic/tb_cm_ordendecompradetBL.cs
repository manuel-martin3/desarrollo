using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_cm_ordendecompradetBL
    {
        tb_cm_ordendecompradetDA tablaDA = new tb_cm_ordendecompradetDA();

        public bool Insert(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool Update(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Updatectacte(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.Updatectacte(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll2(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }

        public DataSet GetAll_Producto(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.GetAll_Producto(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }

        public DataSet GetAll_datosdetalle(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.GetAll_datosdetalle(empresaid, BE);
        }

        public DataSet GetAll_ordendeCompra(string empresaid, tb_cm_ordendecompradet BE)
        {
            return tablaDA.GetAll_ordendeCompra(empresaid,BE);
        }



    }
}
