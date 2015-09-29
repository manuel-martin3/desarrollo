using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class usuariosWebBL
    {
        usuariosWebDA tablaDA = new usuariosWebDA();

        public bool Insert(string empresaid, tb_usuarios BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_usuarios BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update_modificarclave(string empresaid, tb_usuarios BE)
        {
            return tablaDA.Update_modificarclave(empresaid, BE);
        }
        public bool Update_modificarfoto(string empresaid, tb_usuarios BE)
        {
            return tablaDA.Update_modificarfoto(empresaid, BE);
        }        
        public bool Delete(string empresaid, tb_usuarios BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_usuarios BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_usuarios BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetAll_perfil(string empresaid, tb_usuarios BE)
        {
            return tablaDA.GetAll_perfil(empresaid, BE);
        }     
   
        public DataSet GetAll2(string empresaid)
        {
            return tablaDA.GetAll2(empresaid);
        }

        public DataSet BuscarUsuarios(string empresaid, tb_usuarios BE)
        {
            return tablaDA.BuscarUsuarios(empresaid,BE);
        }

        public DataSet GetOne(string empresaid, string usuar)
        {
            return tablaDA.GetOne(empresaid, usuar);
        }
        public DataTable GetSinPerfil(string empresaid)
        {
            return tablaDA.GetSinPerfil(empresaid);
        }
        public DataSet ValidarUsuario(string empresaid, string usuar, string CLAVE)
        {
            return tablaDA.ValidarUsuario(empresaid, usuar, CLAVE);
        }
        public DataSet GenerarMenuXperfil(string empresaid, string COD_USU, string idper)
        {
            return tablaDA.GenerarMenuXperfil(empresaid, COD_USU, idper);
        }
        public DataSet GenerarMenuXperfil_child(string empresaid, string COD_USU, string idper)
        {
            return tablaDA.GenerarMenuXperfil_child(empresaid, COD_USU, idper);
        }
    }
}
