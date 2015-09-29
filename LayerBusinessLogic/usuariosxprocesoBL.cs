using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class usuariosxprocesoBL
    {
        public string Sql_Error = "";
        usuariosxprocesoDA tablaDA = new usuariosxprocesoDA();

        public bool UsuariosProcesosInsertUpdated(string empresaid, tb_usuariosxproceso BE, DataTable TablaDatos)
        {
            //return tablaDA.UsuariosProcesosInsertUpdated(empresaid, BE, TablaDatos);
            bool xreturn = tablaDA.UsuariosProcesosInsertUpdated(empresaid, BE, TablaDatos);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }
        public bool UsuariosProcesos_Replicar(string empresaid, tb_usuariosxproceso BE)
        {
            //return tablaDA.UsuariosProcesos_Replicar(empresaid, BE);
            bool xreturn = tablaDA.UsuariosProcesos_Replicar(empresaid, BE);
            Sql_Error = tablaDA.Sql_Error;
            return xreturn;
        }

        public DataSet GetAll_U_P(string empresaid, tb_usuariosxproceso BE)
        {
            return tablaDA.GetAll_U_P(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_usuariosxproceso BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
    }
}
