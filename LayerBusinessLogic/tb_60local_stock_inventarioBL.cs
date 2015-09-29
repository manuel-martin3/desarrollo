using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60local_stock_inventarioBL
    {
        tb_60local_stock_inventarioDA tablaDA = new tb_60local_stock_inventarioDA();

        public bool Insert(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }

        public bool Insert_Archivo(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Insert_Archivo(empresaid, BE);
        }


        public bool Update(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Update(empresaid, BE);
        }

        public bool Update_Archivo(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Update_Archivo(empresaid, BE);
        }

        public bool Update_digitar(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Update_digitar(empresaid, BE);
        }

        public bool Delete(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }

        public DataSet GetAll_listar(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_listar(empresaid, BE);
        }
       
        public bool GetAll_INICIALIZAR(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_INICIALIZAR(empresaid, BE);
        }

        public bool GetAll_INICIALIZAR_ROLLO(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_INICIALIZAR_ROLLO(empresaid, BE);
        }

        public bool Ajuste_Inv(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Ajuste_Inv(empresaid, BE);
        }

        public DataSet GetAll_paginacion(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }

        public bool GetAll_New(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_New(empresaid, BE);
        }

        public bool Delete_archivo(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.Delete_archivo(empresaid, BE);
        }

        public bool GetAll_AjusteInventario_rollos(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_AjusteInventario_rollos(empresaid, BE);
        }

        public DataSet GetOne(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }

        // Nuevo Agregado

        public DataSet GetOneNew(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetOneNew(empresaid, BE);
        }

        public DataSet GetAll_datosdetalle(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_datosdetalle(empresaid, BE);
        }

        public DataSet GetAll_Rollo_datosdetalle(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetAll_Rollo_datosdetalle(empresaid, BE);
        }

        public DataSet GetReport(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }

        public DataSet GetReportDif(string empresaid, tb_60local_stock_inventario BE)
        {
            return tablaDA.GetReportDif(empresaid, BE);
        }


    }
}
