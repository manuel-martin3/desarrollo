using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class rrhh_listaasistenciaBL
    {
        rrhh_listaasistenciaDA tablaDA = new rrhh_listaasistenciaDA();

        public bool Insert(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Update2(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.Update2(empresaid, BE);
        }

        public bool UpdateFaltas(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.UpdateFaltas(empresaid, BE);
        }

        public bool GetGenera(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetGenera(empresaid, BE);
        }

        public DataSet GetAll(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll2(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetAll2(empresaid, BE);
        }
        public DataSet GetAll3(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetAll3(empresaid, BE);
        }
        public DataSet GetAll_Tardanzas(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetAll_Tardanzas(empresaid, BE);
        }

        public DataSet GetAll_Tardanzas2(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetAll_Tardanzas2(empresaid, BE);
        }

        public DataSet GetAll_FALTAS(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetAll_FALTAS(empresaid, BE);
        }

        public DataSet GetAll_faltas_tardanzas(string empresaid, tb_rrhh_listadeasistencia BE)
        {
            return tablaDA.GetAll_faltas_tardanzas(empresaid, BE);
        }        
    }
}
