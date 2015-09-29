using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class sys_dominioWebBL
    {
        sys_dominioWebDA tablaDA = new sys_dominioWebDA();

        public bool Insert(string empresaid, tb_sys_dominio BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_sys_dominio BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_sys_dominio BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_sys_dominio BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_sys_dominio BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetAll_tienda(string empresaid, tb_sys_dominio BE)
        {
            return tablaDA.GetAll_tienda(empresaid, BE);
        }
        public DataSet GetAllDominioPorUsuario(string empresaid, string usuar)
        {
            return tablaDA.GetAllDominioPorUsuario(empresaid, usuar);
        }
        public DataSet GetAllDominioModuloPorUsuario(string empresaid, string usuar, string dominioid)
        {
            return tablaDA.GetAllDominioModuloPorUsuario(empresaid, usuar, dominioid);
        }
        public DataSet GetOne(string empresaid, string moduloid)
        {
            return tablaDA.GetOne(empresaid, moduloid);
        }
    }
}
