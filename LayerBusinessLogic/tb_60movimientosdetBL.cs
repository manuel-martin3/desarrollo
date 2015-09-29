using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60movimientosdetBL
    {
        tb_60movimientosdetDA tablaDA = new tb_60movimientosdetDA();

        public bool Insert(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public bool Borrar_registros(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.Borrar_registros(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_MpvProd(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_MpvProd(empresaid, BE);
        }
        public DataSet GetAll_Rango(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_Rango(empresaid, BE);
        }
        public DataSet GetAll_datosdetalle(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_datosdetalle(empresaid, BE);
        }
        public DataSet GetAll_Balance(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_Balance(empresaid, BE);
        }

        public DataSet GetAll_KardexEstacion(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_KardexEstacion(empresaid, BE);
        }

        public DataSet GetAll_HistorialxProducto(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_HistorialxProducto(empresaid, BE);
        }

        // Agregamos uno nuevo

        public DataSet GetAll_Imprimir(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_Imprimir(empresaid, BE);
        }

        public DataSet Get_DocOP(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.Get_DocOP(empresaid, BE);
        }

        //
        public DataSet GetAll_Docsemitidos(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_Docsemitidos(empresaid, BE);
        }
        public DataSet GetAll_DocsPeriodo_rollo(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_DocsPeriodo_rollo(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
        public DataSet GetAll_ConsumoxOP(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_ConsumoxOP(empresaid, BE);
        }
        #region $$$ MODULO 0320 (almacen de telas)
        public DataSet GetAll_rollokardex(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_rollokardex(empresaid, BE);
        }
        public DataSet GetAll_productokardex_tela(string empresaid, tb_60movimientosdet BE)
        {
            return tablaDA.GetAll_productokardex_tela(empresaid, BE);
        }
        #endregion
    }
}
