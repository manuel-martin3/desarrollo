using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_me_productosBL
    {
        tb_me_productosDA tablaDA = new tb_me_productosDA();

        public bool Insert(string empresaid, tb_me_productos BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool Insert_Foto(string empresaid, tb_me_productos BE)
        {
            return tablaDA.Insert_Foto(empresaid, BE);
        }

        public bool Update(string empresaid, tb_me_productos BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Update_Foto(string empresaid, tb_me_productos BE)
        {
            return tablaDA.Update_Foto(empresaid, BE);
        }

        public bool Update_CodigoOLD(string empresaid, tb_me_productos BE)
        {
            return tablaDA.Update_CodigoOLD(empresaid, BE);
        }

        public bool Update_fichatecnica(string empresaid, tb_me_productos BE)
        {
            return tablaDA.Update_fichatecnica(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_me_productos BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll_Pocket(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetAll_Pocket(empresaid, BE);
        }

        public DataSet GetPrecList(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetPrecList(empresaid, BE);
        }
        public DataSet GetPrecCostoUltimo(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetPrecCostoUltimo(empresaid, BE);
        }

        public DataSet GetReport(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }
        public DataSet GetAll_nuevocodprod(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetAll_nuevocodprod(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetAll_MaxMin(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetAll_MaxMin(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

        //public DataSet  GetAll_stockrollo(string empresaid, tb_me_productos BE)
        //{
        //    return tablaDA.GetAll_stockrollo(empresaid, BE);
        //}

        public DataSet GenCodigo(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GenCodigo(empresaid, BE);
        }

        public DataSet GenCodAsoc(string empresaid, tb_me_productos BE)
        {
            return tablaDA.GenCodAsoc(empresaid, BE);
        }

    }
}
